using Newtonsoft.Json;

namespace PangeaCyber.Net.Intel
{
    ///
    public class DomainReputationBulkRequest : IntelCommonRequest<DomainReputationBulkRequest.Builder>
    {
        ///
        [JsonProperty("domains")]
        public string[] Domains { get; }

        ///
        protected DomainReputationBulkRequest(Builder builder)
            : base(builder)
        {
            Domains = builder.Domains;
        }

        ///
        public class Builder : CommonBuilder
        {
            ///
            public string[] Domains { get; private set; }

            ///
            public Builder(string[] domainList)
            {
                Domains = domainList;
            }

            ///
            public new DomainReputationBulkRequest Build()
            {
                return new DomainReputationBulkRequest(this);
            }
        }
    }
}
