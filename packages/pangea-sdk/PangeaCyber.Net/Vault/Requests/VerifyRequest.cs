using Newtonsoft.Json;

namespace PangeaCyber.Net.Vault.Requests
{
    ///
    public class VerifyRequest : BaseRequest
    {
        ///
        [JsonProperty("id")]
        public string ID { get; private set; }

        ///
        [JsonProperty("message")]
        public string Message { get; private set; }

        ///
        [JsonProperty("signature")]
        public string Signature { get; private set; }

        ///
        [JsonProperty("version")]
        public int? Version { get; private set; }

        ///
        private VerifyRequest(Builder builder)
        {
            ID = builder.ID;
            Message = builder.Message;
            Signature = builder.Signature;
            Version = builder.Version;
        }

        ///
        public class Builder
        {
            ///
            public string ID { get; private set; }

            ///
            public string Message { get; private set; }

            ///
            public string Signature { get; private set; }

            ///
            public int? Version { get; private set; }

            ///
            public Builder(string id, string message, string signature)
            {
                ID = id;
                Message = message;
                Signature = signature;
            }

            ///
            public Builder WithVersion(int version)
            {
                Version = version;
                return this;
            }

            ///
            public VerifyRequest Build()
            {
                return new VerifyRequest(this);
            }
        }
    }
}
