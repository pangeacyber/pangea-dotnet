using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace PangeaCyber.Net
{
    ///
    [JsonConverter(typeof(StringEnumConverter))]
    public enum TransferMethod
    {
        ///
        [EnumMember(Value = "multipart")]
        Multipart,

        ///
        [EnumMember(Value = "post-url")]
        PostURL,

        ///
        [EnumMember(Value = "put-url")]
        PutURL,

        ///
        [EnumMember(Value = "source-url")]
        SourceURL,

        ///
        [EnumMember(Value = "dest-url")]
        DestURL,

    }
}
