using Newtonsoft.Json;

namespace PangeaCyber.Net.Intel
{
    ///
    public class DomainWhoIsRequest : IntelCommonRequest<DomainWhoIsRequest.Builder>
    {
        ///
        [JsonProperty("domain")]
        public string Domain { get; }

        ///
        protected DomainWhoIsRequest(Builder builder)
            : base(builder)
        {
            Domain = builder.Domain;
        }

        ///
        public class Builder : CommonBuilder
        {
            ///
            public string Domain { get; set; }

            ///
            public Builder(string domain)
            {
                Domain = domain;
            }

            ///
            public new DomainWhoIsRequest Build()
            {
                return new DomainWhoIsRequest(this);
            }
        }
    }
}
