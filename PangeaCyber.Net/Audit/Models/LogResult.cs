using Newtonsoft.Json;

namespace PangeaCyber.Net.Audit
{
    /// <kind>class</kind>
    /// <summary>
    /// LogResult
    /// </summary>
    public sealed class LogResult
    {
        ///
        [JsonProperty("envelope", NullValueHandling = NullValueHandling.Ignore)]
        public object RawEnvelope { get; private set; } = default!;

        ///
        [JsonIgnore]
        public EventEnvelope EventEnvelope { get; set; } = default!;

        ///
        [JsonProperty("hash")]
        public string Hash { get; private set; } = default!;

        ///
        [JsonProperty("unpublished_root")]
        public string UnpublishedRoot { get; private set; } = default!;

        ///
        [JsonProperty("membership_proof")]
        public string MembershipProof { get; private set; } = default!;

        ///
        [JsonProperty("consistency_proof")]
        public string[] ConsistencyProof { get; private set; } = default!;

        ///
        [JsonIgnore]
        public EventVerification MembershipVerification { get; set; } = EventVerification.NotVerified;

        ///
        [JsonIgnore]
        public EventVerification ConsistencyVerification { get; set; } = EventVerification.NotVerified;

        ///
        [JsonIgnore]
        public EventVerification SignatureVerification { get; set; } = EventVerification.NotVerified;

        ///
        public void VerifySignature()
        {
            if (this.EventEnvelope != null)
            {
                this.SignatureVerification = this.EventEnvelope.VerifySignature();
            }
            else
            {
                this.SignatureVerification = EventVerification.NotVerified;
            }
        }
    }
}
