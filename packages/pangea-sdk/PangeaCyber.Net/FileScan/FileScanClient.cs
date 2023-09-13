namespace PangeaCyber.Net.FileScan
{
    /// <kind>class</kind>
    /// <summary>
    /// FileScan Client
    /// </summary>
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

        /// <kind>method</kind>
        /// <summary>Scan a file for malicious content.</summary>
        /// <remarks>Scan</remarks>
        /// <operationid>file_scan_post_v1_scan</operationid>
        /// <param name="request" type="PangeaCyber.Net.FileScan.FileScanRequest">FileScanRequest</param>
        /// <param name="file" type="System.IO.FileStream">FileStream file</param>
        /// <returns>Response&lt;FileScanResult&gt;</returns>
        /// <example>
        /// <code>
        /// string filepath = "./path/to/file.pdf";
        /// 
        /// var file = new FileStream(filepath, FileMode.Open, FileAccess.Read);
        /// 
        /// var request = new FileScanRequest.Builder().WithProvider("crowdstrike").WithRaw(true).WithVerbose(true).Build();
        /// var response = await client.Scan(request, file);
        /// 
        /// FileScanData data = response.Result.Data;
        /// </code>
        /// </example>
        public async Task<Response<FileScanResult>> Scan(FileScanRequest request, FileStream file)
        {
            return await DoPost<FileScanResult>("/v1/scan", request, file);
        }
    }
}
