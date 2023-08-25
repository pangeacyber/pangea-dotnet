using Newtonsoft.Json;
using PangeaCyber.Net.AuthN.Models; // Import AgreementType from appropriate namespace

namespace PangeaCyber.Net.AuthN.Requests
{
    ///
    public class AgreementCreateRequest : BaseRequest
    {
        ///
        [JsonProperty("type")]
        public AgreementType Type { get; private set; }

        ///
        [JsonProperty("name")]
        public string Name { get; private set; }

        ///
        [JsonProperty("text")]
        public string Text { get; private set; }

        ///
        [JsonProperty("active")]
        public bool? Active { get; private set; }

        private AgreementCreateRequest(Builder builder)
        {
            this.Type = builder.Type;
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
            public string Name { get; private set; }
            ///
            public string Text { get; private set; }
            ///
            public bool? Active { get; private set; }

            ///
            public Builder(AgreementType type, string name, string text)
            {
                this.Type = type;
                this.Name = name;
                this.Text = text;
            }

            ///
            public Builder WithActive(bool? active)
            {
                this.Active = active;
                return this;
            }

            ///
            public AgreementCreateRequest Build()
            {
                return new AgreementCreateRequest(this);
            }
        }
    }
}
