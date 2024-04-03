using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace PangeaCyber.Net
{
    /// <summary>Transfer methods for uploading file data.</summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum TransferMethod
    {
        /// <summary>
        /// Upload the file at the time of the initial request.
        /// </summary>
        [EnumMember(Value = "multipart")]
        Multipart,

        /// <summary>
        /// Ensure the integrity of uploaded content by locking it to specific file properties like size, SHA256 hash,
        /// and CRC32C signature.
        /// </summary>
        [EnumMember(Value = "post-url")]
        PostURL,

        /// <summary>
        /// Upload any file content.
        /// </summary>
        [EnumMember(Value = "put-url")]
        PutURL,

        /// <summary>
        /// Pangea fetches the file from a caller-specified URL.
        /// </summary>
        [EnumMember(Value = "source-url")]
        SourceURL,

        /// <summary>
        /// Pangea will place the output file at a presigned URL and return that URL for downloading.
        /// </summary>
        [EnumMember(Value = "dest-url")]
        DestURL,
    }
}
