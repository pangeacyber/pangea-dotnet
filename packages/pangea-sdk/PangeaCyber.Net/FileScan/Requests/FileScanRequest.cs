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
        [JsonProperty("source_url")]
        public string? SourceURL { get; set; }


        ///
        protected FileScanRequest(Builder builder)
        {
            Provider = builder.Provider;
            Verbose = builder.Verbose;
            Raw = builder.Raw;
            SourceURL = builder.SourceURL;
            TransferMethod = builder.TransferMethod;
        }

        ///
        protected FileScanRequest() { }

        ///
        protected FileScanRequest(FileScanRequest request)
        {
            Provider = request.Provider;
            Verbose = request.Verbose;
            Raw = request.Raw;
            SourceURL = request.SourceURL;
            TransferMethod = request.TransferMethod;
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
            public string? SourceURL { get; private set; }

            ///
            public TransferMethod TransferMethod { get; private set; } = TransferMethod.PostURL;

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

            ///
            public Builder WithSourceURL(string url)
            {
                SourceURL = url;
                return this;
            }

            ///
            public Builder WithTransferMethod(TransferMethod transferMethod)
            {
                TransferMethod = transferMethod;
                return this;
            }

        }
    }
}
