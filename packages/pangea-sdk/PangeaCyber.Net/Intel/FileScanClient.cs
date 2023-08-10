namespace PangeaCyber.Net.Intel
{
    ///
    public class FileScanClient : BaseClient<FileScanClient.Builder>
    {
        ///
        public static string ServiceName = "file-scan";
        private static readonly bool SupportMultiConfig = false;

        ///
        public FileScanClient(Builder builder) : base(builder, ServiceName, SupportMultiConfig)
        {
        }

        ///
        public class Builder : BaseClient<FileScanClient.Builder>.ClientBuilder
        {
            ///
            public Builder(Config config) : base(config)
            {
            }

            ///
            public FileScanClient Build()
            {
                return new FileScanClient(this);
            }
        }

        ///
        public async Task<Response<FileScanResult>> Scan(FileScanRequest request, FileStream file)
        {
            return await DoPost<FileScanResult>("/v1/scan", request, file);
        }
    }
}
