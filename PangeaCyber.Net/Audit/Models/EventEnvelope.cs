using System.Text;
using Newtonsoft.Json;
using PangeaCyber.Net.Exceptions;

namespace PangeaCyber.Net.Audit
{
    /// <kind>class</kind>
    /// <summary>
    /// EventEnvelope
    /// </summary>
    public sealed class EventEnvelope
    {
        ///
        [JsonProperty("event", Required = Required.Always)]
        public IEvent? Event { get; private set; } = default!;

        ///
        [JsonProperty("signature")]
        public string Signature { get; private set; } = default!;

        ///
        [JsonProperty("public_key")]
        public string PublicKey { get; private set; } = default!;

        ///
        [JsonProperty("received_at")]
        public string ReceivedAt { get; private set; } = default!;

        ///
        public EventEnvelope(IEvent @event, string signature, string publicKey, string receivedAt)
        {
            this.Event = @event;
            this.Signature = signature;
            this.PublicKey = publicKey;
            this.ReceivedAt = receivedAt;
        }

        ///
        public EventVerification VerifySignature()
        {
            if( this.Event == null){
                return EventVerification.NotVerified;
            }

            // If does not have signature information, it's not verified
            if (this.Signature == null && this.PublicKey == null)
            {
                return EventVerification.NotVerified;
            }

            // But if one field is missing, it's verification failed
            if (this.Signature == null || this.PublicKey == null)
            {
                return EventVerification.Failed;
            }

            if (this.PublicKey != null && this.PublicKey.StartsWith("-----"))
            {
                return EventVerification.NotVerified;
            }

            string canonicalJson;
            try
            {
                canonicalJson = IEvent.Canonicalize(this.Event);
            }
            catch (EncoderFallbackException)
            {
                return EventVerification.Failed;
            }

            Verifier verifier = new Verifier();
            return verifier.Verify(this?.PublicKey ?? default!, this?.Signature ?? default!, canonicalJson);
        }

        ///
        public static EventEnvelope? FromRaw(Dictionary<string, object> RawEnvelope, Type customSchemaClass)
        {
            if (!typeof(IEvent).IsAssignableFrom(customSchemaClass))
            {
                throw new ArgumentException("customSchemaClass must implement IEvent");
            }

            if (RawEnvelope == null)
            {
                return default!;
            }
            var jsonSettings = new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore, DateParseHandling = DateParseHandling.None, DateFormatString = "yyyy'-'MM'-'dd'T'HH':'mm':'ss.fffffffK" };
            EventEnvelope EventEnvelope;
            try
            {
                EventEnvelope = JsonConvert.DeserializeObject<EventEnvelope>(JsonConvert.SerializeObject(RawEnvelope, jsonSettings), jsonSettings) ?? null!;
            }
            catch (Exception e)
            {
                throw new PangeaException("Failed to process event envelope", e);
            }

            object rawEvent;
            if(RawEnvelope.TryGetValue("event", out rawEvent!)){
                IEvent? @event = IEvent.FromRaw(rawEvent, customSchemaClass);
                EventEnvelope.Event = @event;
            }

            return EventEnvelope;
        }

        ///
        public static void VerifyHash(object RawEnvelope, string hash)
        {
            if (RawEnvelope == null || String.IsNullOrEmpty(hash))
            {
                return;
            }

            string canonicalJson;
            try
            {
                canonicalJson = EventEnvelope.Canonicalize(RawEnvelope);
            }
            catch (PangeaException e)
            {
                throw new VerificationFailed("Failed to canonicalize envelope in hash verification. Event hash: " + hash, e, hash);
            }

            string calcHash = Utils.Hash.GetHash(canonicalJson);
            if (!calcHash.Equals(hash, StringComparison.OrdinalIgnoreCase))
            {
                throw new VerificationFailed("Failed hash verification. Calculated and received hash are not equals. Event hash: " + hash, new Exception(), hash);
            }
        }

        ///
        public static string Canonicalize(object eventEnvelope)
        {
            // Convert the rawEnvelope from object to a sorted dictionary
            SortedDictionary<string, object>? objectMap = Newtonsoft.Json.Linq.JObject.FromObject(eventEnvelope).ToObject<SortedDictionary<string, object>>();
            if (objectMap != null && objectMap?["event"] != null)
            {
                // Convert the rawEnvelope.event from object to a sorted dictionary
                var evt = Newtonsoft.Json.Linq.JObject.FromObject(objectMap["event"]).ToObject<SortedDictionary<string, object>>() ?? default!;
                objectMap["event"] = evt;
            }
            return JsonConvert.SerializeObject(objectMap, Formatting.None, new JsonSerializerSettings { ContractResolver = new OrderedContractResolver() });
        }
    }
}
