using Newtonsoft.Json;
using PangeaCyber.Net.Share.Models;

namespace PangeaCyber.Net.Share.Requests
{
    /// <summary>
    /// Represents a put request.
    /// </summary>
    public class PutRequest : BaseRequest
    {
        ///
        [JsonProperty("name")]
        public string? Name { get; set; }

        ///
        [JsonProperty("format")]
        public FileFormat? Format { get; set; }

        ///
        [JsonProperty("metadata")]
        public Metadata? Metadata { get; set; }

        ///
        [JsonProperty("mimetype")]
        public string? MimeType { get; set; }

        ///
        [JsonProperty("parent_id")]
        public string? ParentId { get; set; }

        ///
        [JsonProperty("path")]
        public string? Path { get; set; }

        ///
        [JsonProperty("crc32c")]
        public string? CRC32c { get; set; }

        ///
        [JsonProperty("md5")]
        public string? MD5 { get; set; }

        ///
        [JsonProperty("sha1")]
        public string? SHA1 { get; set; }

        ///
        [JsonProperty("sha256")]
        public string? SHA256 { get; set; }

        ///
        [JsonProperty("sha512")]
        public string? SHA512 { get; set; }

        ///
        [JsonProperty("size")]
        public int? Size { get; set; }

        ///
        [JsonProperty("tags")]
        public Tags? Tags { get; set; }


        ///
        [JsonIgnore]
        public TransferMethod? RequestTransferMethod
        {
            set
            {
                TransferMethod = value;
            }
        }
    }
}
