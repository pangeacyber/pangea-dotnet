using Newtonsoft.Json;

namespace PangeaCyber.Net.Vault
{
    ///
    public class VerifyRequest : BaseRequest
    {
        ///
        [JsonProperty("id")]
        public string Id { get; private set; }

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
            Id = builder.Id;
            Message = builder.Message;
            Signature = builder.Signature;
            Version = builder.Version;
        }

        ///
        public class Builder
        {
            ///
            public string Id { get; private set; }

            ///
            public string Message { get; private set; }

            ///
            public string Signature { get; private set; }

            ///
            public int? Version { get; private set; }

            ///
            public Builder(string id, string message, string signature)
            {
                Id = id;
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
