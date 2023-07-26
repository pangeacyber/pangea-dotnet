using Newtonsoft.Json;
using PangeaCyber.Net.Exceptions;

namespace PangeaCyber.Net.Audit
{
    /// <kind>class</kind>
    /// <summary>
    /// Event
    /// </summary>
    public class IEvent
    {
        ///
        [JsonProperty("tenant_id")]
        public string? TenantID { get; set; }


        ///
        public void SetTenantID(String tenantID)
        {
            TenantID = tenantID;
        }

        ///
        public String? GetTenantID()
        {
            return TenantID;
        }


        ///
        public static string Canonicalize(IEvent evt)
        {
            var jsonSettings = new JsonSerializerSettings { ContractResolver = new OrderedContractResolver(), NullValueHandling = NullValueHandling.Ignore, DateParseHandling = DateParseHandling.None, DateFormatString = "yyyy'-'MM'-'dd'T'HH':'mm':'ss.fffffffK" };
            return JsonConvert.SerializeObject(evt, Formatting.None, jsonSettings);
        }

        ///
        public static IEvent? FromRaw(object rawEvent, Type customSchemaClass)
        {
            if (!typeof(IEvent).IsAssignableFrom(customSchemaClass))
            {
                throw new ArgumentException("customSchemaClass must implement IEvent");
            }

            if (rawEvent == null)
            {
                return default!;
            }

            IEvent? @event = null;
            try
            {
                var jsonSettings = new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore, DateParseHandling = DateParseHandling.None, DateFormatString = "yyyy'-'MM'-'dd'T'HH':'mm':'ss.fffffffK" };
                @event = (IEvent?)JsonConvert.DeserializeObject(JsonConvert.SerializeObject(rawEvent, jsonSettings), customSchemaClass, jsonSettings);
            }
            catch (Exception e)
            {
                throw new PangeaException("Failed to process event", e);
            }

            return @event;
        }

    }
}
