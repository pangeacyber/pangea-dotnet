using Newtonsoft.Json;

namespace PangeaCyber.Net.Vault
{
    ///
    public class SignRequest : BaseRequest
    {
        ///
        [JsonProperty("id")]
        public string Id { get; private set; }

        ///
        [JsonProperty("message")]
        public string Message { get; private set; }

        ///
        [JsonProperty("version")]
        public int? Version { get; private set; }

        ///
        private SignRequest(Builder builder)
        {
            Id = builder.Id;
            Message = builder.Message;
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
            public int? Version { get; private set; }

            ///
            public Builder(string id, string message)
            {
                Id = id;
                Message = message;
            }

            ///
            public Builder WithVersion(int? version)
            {
                Version = version;
                return this;
            }

            ///
            public SignRequest Build()
            {
                return new SignRequest(this);
            }
        }
    }
}
