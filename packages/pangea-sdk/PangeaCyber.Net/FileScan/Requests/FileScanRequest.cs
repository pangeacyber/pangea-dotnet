using Newtonsoft.Json;

namespace PangeaCyber.Net.FileScan
{
    ///
    public class FileScanRequest : BaseRequest
    {

        ///
        [JsonProperty("provider")]
        public string? Provider { get; set; }

        ///
        [JsonProperty("verbose")]
        public bool? Verbose { get; set; }

        ///
        [JsonProperty("raw")]
        public bool? Raw { get; set; }

        ///
        protected FileScanRequest(Builder builder)
        {
            Provider = builder.Provider;
            Verbose = builder.Verbose;
            Raw = builder.Raw;
        }

        ///
        protected FileScanRequest(FileScanRequest request)
        {
            Provider = request.Provider;
            Verbose = request.Verbose;
            Raw = request.Raw;
        }

        ///
        public class Builder
        {

            ///
            public string? Provider { get; private set; }

            ///
            public bool? Verbose { get; private set; }

            ///
            public bool? Raw { get; private set; }

            ///
            public Builder() { }

            ///
            public FileScanRequest Build()
            {
                return new FileScanRequest(this);
            }

            ///
            public Builder WithProvider(string provider)
            {
                Provider = provider;
                return this;
            }

            ///
            public Builder WithVerbose(bool? verbose)
            {
                Verbose = verbose;
                return this;
            }

            ///
            public Builder WithRaw(bool? raw)
            {
                Raw = raw;
                return this;
            }
        }
    }
}
