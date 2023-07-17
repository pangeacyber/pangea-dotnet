using Newtonsoft.Json;

namespace PangeaCyber.Net.Intel
{
    ///
    public class URLReputationRequest : IntelCommonRequest<URLReputationRequest.Builder>
    {
        ///
        [JsonProperty("url")]
        public string Url { get; set; }

        ///
        protected URLReputationRequest(Builder builder)
            : base(builder)
        {
            Url = builder.Url;
        }

        ///
        public class Builder : IntelCommonRequest<URLReputationRequest.Builder>.CommonBuilder
        {
            ///
            public string Url { get; private set; }

            ///
            public Builder(string url)
            {
                Url = url;
            }

            ///
            public new URLReputationRequest Build()
            {
                return new URLReputationRequest(this);
            }
        }

        ///
        public string GetUrl()
        {
            return Url;
        }
    }
}
