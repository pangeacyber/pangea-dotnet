using Newtonsoft.Json;

namespace PangeaCyber.Net.Vault
{
    ///
    public class SignRequest : BaseRequest
    {
        ///
        [JsonProperty("id")]
        public string ID { get; private set; }

        ///
        [JsonProperty("message")]
        public string Message { get; private set; }

        ///
        [JsonProperty("version")]
        public int? Version { get; private set; }

        ///
        private SignRequest(Builder builder)
        {
            ID = builder.ID;
            Message = builder.Message;
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
            public int? Version { get; private set; }

            ///
            public Builder(string id, string message)
            {
                ID = id;
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
