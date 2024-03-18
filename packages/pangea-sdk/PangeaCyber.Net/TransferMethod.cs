using Newtonsoft.Json;
using System.Runtime.Serialization;

namespace PangeaCyber.Net
{
    ///
    [JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
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
