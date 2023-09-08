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
        [JsonProperty("domain_list")]
        public string[]? DomainList { get; }

        ///
        protected DomainReputationRequest(Builder builder)
            : base(builder)
        {
            Domain = builder.Domain;
            DomainList = builder.DomainList;
        }

        ///
        public class Builder : CommonBuilder
        {
            ///
            public string? Domain { get; private set; } = null;

            ///
            public string[]? DomainList { get; private set; } = null;


            ///
            public Builder(string domain)
            {
                Domain = domain;
            }

            ///
            public Builder(string[] domainList)
            {
                DomainList = domainList;
            }

            ///
            public new DomainReputationRequest Build()
            {
                return new DomainReputationRequest(this);
            }
        }
    }
}
