using Newtonsoft.Json;

namespace PangeaCyber.Net.Intel
{
    ///
    public class DomainReputationRequest : IntelCommonRequest<DomainReputationRequest.Builder>
    {
        ///
        [JsonProperty("domain")]
        public string? Domain { get; }

        ///
        protected DomainReputationRequest(Builder builder)
            : base(builder)
        {
            Domain = builder.Domain;
        }

        ///
        public class Builder : CommonBuilder
        {
            ///
            public string? Domain { get; private set; } = null;

            ///
            public Builder(string domain)
            {
                Domain = domain;
            }

            ///
            public new DomainReputationRequest Build()
            {
                return new DomainReputationRequest(this);
            }
        }
    }
}
