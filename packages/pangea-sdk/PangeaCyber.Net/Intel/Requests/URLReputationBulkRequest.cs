using Newtonsoft.Json;

namespace PangeaCyber.Net.Intel
{
    ///
    public class URLReputationBulkRequest : IntelCommonRequest<URLReputationBulkRequest.Builder>
    {
        ///
        [JsonProperty("urls")]
        public string[] URLs { get; set; }

        ///
        protected URLReputationBulkRequest(Builder builder)
            : base(builder)
        {
            URLs = builder.URLs;
        }

        ///
        public class Builder : CommonBuilder
        {
            ///
            public string[] URLs { get; private set; }

            ///
            public Builder(string[] urls)
            {
                URLs = urls;
            }

            ///
            public new URLReputationBulkRequest Build()
            {
                return new URLReputationBulkRequest(this);
            }
        }
    }
}
