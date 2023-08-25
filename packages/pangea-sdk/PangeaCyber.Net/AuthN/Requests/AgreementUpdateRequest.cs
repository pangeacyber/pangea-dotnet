using Newtonsoft.Json;
using PangeaCyber.Net.AuthN.Models; // Import AgreementType from appropriate namespace

namespace PangeaCyber.Net.AuthN.Requests
{
    ///
    public class AgreementUpdateRequest : BaseRequest
    {
        ///
        [JsonProperty("type")]
        public AgreementType Type { get; private set; }

        ///
        [JsonProperty("id")]
        public string Id { get; private set; }

        ///
        [JsonProperty("name")]
        public string? Name { get; private set; }

        ///
        [JsonProperty("text")]
        public string? Text { get; private set; }

        ///
        [JsonProperty("active")]
        public bool? Active { get; private set; }

        private AgreementUpdateRequest(Builder builder)
        {
            this.Type = builder.Type;
            this.Id = builder.Id;
            this.Name = builder.Name;
            this.Text = builder.Text;
            this.Active = builder.Active;
        }

        ///
        public class Builder
        {
            ///
            public AgreementType Type { get; private set; }
            ///
            public string Id { get; private set; }
            ///
            public string? Name { get; private set; }
            ///
            public string? Text { get; private set; }
            ///
            public bool? Active { get; private set; }

            ///
            public Builder(AgreementType type, string id)
            {
                this.Type = type;
                this.Id = id;
            }

            ///
            public AgreementUpdateRequest Build()
            {
                return new AgreementUpdateRequest(this);
            }

            ///
            public Builder WithName(string name)
            {
                this.Name = name;
                return this;
            }

            ///
            public Builder WithText(string text)
            {
                this.Text = text;
                return this;
            }

            ///
            public Builder WithActive(bool? active)
            {
                this.Active = active;
                return this;
            }
        }
    }
}
