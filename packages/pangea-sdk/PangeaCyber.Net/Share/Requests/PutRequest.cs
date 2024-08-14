using Newtonsoft.Json;
using PangeaCyber.Net.Share.Models;

namespace PangeaCyber.Net.Share.Requests
{
    ///<summary>
    /// Represents a put request.
    /// </summary>
    public class PutRequest : BaseRequest
    {
        ///<summary>The name of the object to store.</summary>
        [JsonProperty("name")]
        public string? Name { get; set; }

        ///<summary>The format of the file, which will be verified by the server if provided. Uploads not matching the supplied format will be rejected.</summary>
        [JsonProperty("format")]
        public FileFormat? Format { get; set; }

        ///<summary>A set of string-based key/value pairs used to provide additional data about an object.</summary>
        [JsonProperty("metadata")]
        public Metadata? Metadata { get; set; }

        ///<summary>The MIME type of the file, which will be verified by the server if provided. Uploads not matching the supplied MIME type will be rejected.</summary>
        [JsonProperty("mimetype")]
        public string? MimeType { get; set; }

        ///<summary>The parent ID of the object (a folder). Leave blank to keep in the root folder.</summary>
        [JsonProperty("parent_id")]
        public string? ParentId { get; set; }

        ///<summary>An optional path where the file should be placed. It will auto-create directories if necessary.</summary>
        [JsonProperty("path")]
        public string? Path { get; set; }

        ///<summary>An optional password to protect the file with. Downloading the file will require this password.</summary>
        [JsonProperty("password")]
        public string? Password { get; set; }

        ///<summary>An optional password algorithm to protect the file with. See symmetric vault password_algorithm.</summary>
        [JsonProperty("password_algorithm")]
        public string? PasswordAlgorithm { get; set; }

        ///<summary>The hexadecimal-encoded CRC32C hash of the file data, which will be verified by the server if provided.</summary>
        [JsonProperty("crc32c")]
        public string? CRC32c { get; set; }

        ///<summary>The hexadecimal-encoded MD5 hash of the file data, which will be verified by the server if provided.</summary>
        [JsonProperty("md5")]
        public string? MD5 { get; set; }

        ///<summary>The hexadecimal-encoded SHA1 hash of the file data, which will be verified by the server if provided.</summary>
        [JsonProperty("sha1")]
        public string? SHA1 { get; set; }

        ///<summary>The SHA256 hash of the file data, which will be verified by the server if provided.</summary>
        [JsonProperty("sha256")]
        public string? SHA256 { get; set; }

        ///<summary>The hexadecimal-encoded SHA512 hash of the file data, which will be verified by the server if provided.</summary>
        [JsonProperty("sha512")]
        public string? SHA512 { get; set; }

        ///<summary>The size (in bytes) of the file. If the upload doesn't match, the call will fail.</summary>
        [JsonProperty("size")]
        public int? Size { get; set; }

        ///<summary>The URL to fetch the file payload from (for transfer_method source-url).</summary>
        [JsonProperty("source_url")]
        public string? SourceURL { get; set; }

        ///<summary>A list of user-defined tags.</summary>
        [JsonProperty("tags")]
        public Tags? Tags { get; set; }

        ///<summary>The bucket to use, if not the default.</summary>
        [JsonProperty("bucket_id")]
        public string? BucketID { get; set; }

        ///<summary>The transfer method used to upload the file data.</summary>
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
