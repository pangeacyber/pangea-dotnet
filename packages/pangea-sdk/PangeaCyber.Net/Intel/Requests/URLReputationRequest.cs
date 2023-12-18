using Newtonsoft.Json;

namespace PangeaCyber.Net.Intel
{
    ///
    public class URLReputationRequest : IntelCommonRequest<URLReputationRequest.Builder>
    {
        ///
        [JsonProperty("url")]
        public string? URL { get; set; }

        ///
        [JsonProperty("url_list")]
        public string[]? URLList { get; private set; }

        ///
        protected URLReputationRequest(Builder builder)
            : base(builder)
        {
            URL = builder.URL;
            URLList = builder.URLList;
        }

        ///
        public class Builder : CommonBuilder
        {
            ///
            public string? URL { get; private set; } = null;

            ///
            public string[]? URLList { get; private set; } = null;

            ///
            public Builder(string url)
            {
                URL = url;
            }

            ///
            public Builder(string[] urlList)
            {
                URLList = urlList;
            }

            ///
            public new URLReputationRequest Build()
            {
                return new URLReputationRequest(this);
            }
        }
    }
}
