using Newtonsoft.Json;
using PangeaCyber.Net.AuthN.Models; // Import AgreementType from appropriate namespace

namespace PangeaCyber.Net.AuthN.Requests
{
    ///
    public class AgreementDeleteRequest : BaseRequest
    {
        ///
        [JsonProperty("type")]
        public AgreementType Type { get; private set; }

        ///
        [JsonProperty("id")]
        public string Id { get; private set; }

        private AgreementDeleteRequest(Builder builder)
        {
            this.Type = builder.Type;
            this.Id = builder.Id;
        }

        ///
        public class Builder
        {
            ///
            public AgreementType Type { get; private set; }
            ///
            public string Id { get; private set; }

            ///
            public Builder(AgreementType type, string id)
            {
                this.Type = type;
                this.Id = id;
            }

            ///
            public AgreementDeleteRequest Build()
            {
                return new AgreementDeleteRequest(this);
            }
        }
    }
}
