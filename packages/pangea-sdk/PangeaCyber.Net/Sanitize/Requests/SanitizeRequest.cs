using Newtonsoft.Json;

namespace PangeaCyber.Net.Sanitize
{
    /// <summary></summary>
    public class SanitizeRequest : BaseRequest
    {
        /// <summary>A URL where the file to be Sanitized can be downloaded.</summary>
        [JsonProperty("source_url")]
        public string? SourceURL { get; set; }

        /// <summary>A Pangea Secure Share ID where the file to be Sanitized is stored.</summary>
        [JsonProperty("share_id")]
        public string? ShareID { get; set; }

        /// <summary>File.</summary>
        [JsonProperty("file")]
        public SanitizeFile? File { get; set; }

        /// <summary>Content.</summary>
        [JsonProperty("content")]
        public Content? Content { get; set; }

        /// <summary>Share output.</summary>
        [JsonProperty("share_output")]
        public ShareOutput? ShareOutput { get; set; }

        /// <summary>The size (in bytes) of the file. If the upload doesn't match, the call will fail.</summary>
        [JsonProperty("size")]
        public int? Size { get; set; }

        /// <summary>The CRC32C hash of the file data, which will be verified by the server if provided.</summary>
        [JsonProperty("crc32c")]
        public string? CRC32c { get; set; }

        /// <summary>The hexadecimal-encoded SHA256 hash of the file data, which will be verified by the server if provided.</summary>
        [JsonProperty("sha256")]
        public string? SHA256 { get; set; }

        /// <summary>Name of the user-uploaded file, required for transfer-method 'put-url' and 'post-url'.</summary>
        [JsonProperty("uploaded_file_name")]
        public string? UploadedFileName { get; set; }

        ///
        [JsonIgnore]
        public TransferMethod? RequestTransferMethod
        {
            get { return TransferMethod; }
            set
            {
                TransferMethod = value;
            }
        }

        /// <summary>Constructor.</summary>
        public SanitizeRequest() { }
    }
}
