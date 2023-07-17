using Newtonsoft.Json;

namespace PangeaCyber.Net.Intel
{
    ///
    public class URLReputationRequest : IntelCommonRequest<URLReputationRequest.Builder>
    {
        ///
        [JsonProperty("url")]
        public string URL { get; set; }

        ///
        protected URLReputationRequest(Builder builder)
            : base(builder)
        {
            URL = builder.URL;
        }

        ///
        public class Builder : IntelCommonRequest<URLReputationRequest.Builder>.CommonBuilder
        {
            ///
            public string URL { get; private set; }

            ///
            public Builder(string url)
            {
                URL = url;
            }

            ///
            public new URLReputationRequest Build()
            {
                return new URLReputationRequest(this);
            }
        }
    }
}
