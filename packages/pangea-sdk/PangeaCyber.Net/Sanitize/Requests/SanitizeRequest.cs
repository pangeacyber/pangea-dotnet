using Newtonsoft.Json;

namespace PangeaCyber.Net.Sanitize
{
    ///
    public class SanitizeRequest : BaseRequest
    {
        ///
        [JsonProperty("source_url")]
        public string? SourceURL { get; set; }

        ///
        [JsonProperty("share_id")]
        public string? ShareID { get; set; }

        ///
        [JsonProperty("file")]
        public SanitizeFile? File { get; set; }

        ///
        [JsonProperty("content")]
        public Content? Content { get; set; }

        ///
        [JsonProperty("share_output")]
        public ShareOutput? ShareOutput { get; set; }

        ///
        [JsonProperty("size")]
        public int? Size { get; set; }

        ///
        [JsonProperty("crc32c")]
        public string? CRC32c { get; set; }

        ///
        [JsonProperty("sha256")]
        public string? SHA256 { get; set; }

        ///
        [JsonProperty("uploaded_file_name")]
        public string? UploadedFileName { get; set; }

        /// <inheritdoc cref="BaseRequest.TransferMethod" />
        [JsonIgnore]
        public TransferMethod RequestTransferMethod
        {
            get { return TransferMethod ?? Net.TransferMethod.PostURL; }
            set
            {
                TransferMethod = value;
            }
        }

        ///
        public SanitizeRequest()
        {
            RequestTransferMethod = Net.TransferMethod.PostURL;
        }
    }
}
