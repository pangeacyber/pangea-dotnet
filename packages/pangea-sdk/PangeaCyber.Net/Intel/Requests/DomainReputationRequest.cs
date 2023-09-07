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
        public class Builder : IntelCommonRequest<DomainReputationRequest.Builder>.CommonBuilder
        {
            ///
            public string? Domain { get; private set; }

            ///
            public string[]? DomainList { get; private set; }


            ///
            public Builder(string domain)
            {
                Domain = domain;
                DomainList = null;
            }

            ///
            public Builder(string[] domainList)
            {
                Domain = null;
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
