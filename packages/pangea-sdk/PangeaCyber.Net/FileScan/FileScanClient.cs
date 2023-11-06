using Newtonsoft.Json;
using PangeaCyber.Net.FileScan.Models;

namespace PangeaCyber.Net.FileScan
{
    /// <kind>class</kind>
    /// <summary>
    /// FileScan Client
    /// </summary>
    public class FileScanClient : BaseClient<FileScanClient.Builder>
    {
        ///
        public static readonly string ServiceName = "file-scan";

        ///
        public FileScanClient(Builder builder) : base(builder, ServiceName)
        {
        }

        ///
        public class Builder : ClientBuilder
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
        /// <param name="transferMethod" type="TransferMethod">Used to choice between multipart post or presigned URL</param>
        /// <returns>Response&lt;FileScanResult&gt;</returns>
        /// <example>
        /// <code>
        /// string filepath = "./path/to/file.pdf";
        ///
        /// var file = new FileStream(filepath, FileMode.Open, FileAccess.Read);
        ///
        /// var request = new FileScanRequest.Builder().WithProvider("crowdstrike").WithRaw(true).WithVerbose(true).Build();
        /// var response = await client.Scan(request, file, TransferMethod.Direct);
        ///
        /// FileScanData data = response.Result.Data;
        /// </code>
        /// </example>
        public async Task<Response<FileScanResult>> Scan(FileScanRequest request, FileStream file)
        {
            FileScanFullRequest fullRequest;
            if (request.TransferMethod == TransferMethod.Direct)
            {
                var fileParams = Utils.GetFSparams(file);
                fullRequest = new FileScanFullRequest(request, fileParams);
            }
            else
            {
                fullRequest = new FileScanFullRequest(request);
            }

            return await DoPost<FileScanResult>("/v1/scan", fullRequest, file);
        }

        ///
        private class FileScanFullRequest : FileScanRequest
        {
            ///
            [JsonProperty("transfer_size")]
            public int? Size { get; private set; }

            ///
            [JsonProperty("transfer_crc32c")]
            public string? Crc32c { get; private set; }

            ///
            [JsonProperty("transfer_sha256")]
            public string? Sha256 { get; private set; }

            ///
            public FileScanFullRequest(FileScanRequest request, FileParams fileParams) : base(request)
            {
                Size = fileParams.Size;
                Crc32c = fileParams.CRC32C;
                Sha256 = fileParams.SHA256;
            }

            ///
            public FileScanFullRequest(FileScanRequest request) : base(request)
            {
                Size = null;
                Crc32c = null;
                Sha256 = null;
            }

        }

    }

}
