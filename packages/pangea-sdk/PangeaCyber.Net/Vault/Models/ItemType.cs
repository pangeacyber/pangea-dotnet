using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace PangeaCyber.Net.Vault.Models
{
    ///
    [JsonConverter(typeof(StringEnumConverter))]
    public enum ItemType
    {
        ///
        [EnumMember(Value = "asymmetric_key")]
        AsymmetricKey,

        ///
        [EnumMember(Value = "symmetric_key")]
        SymmetricKey,

        ///
        [EnumMember(Value = "secret")]
        Secret,

        ///
        [EnumMember(Value = "pangea_token")]
        PangeaToken,

        ///
        [EnumMember(Value = "folder")]
        Folder,

        ///
        [EnumMember(Value = "pangea_client_secret")]
        PangeaClientSecret,

        ///
        [EnumMember(Value = "pangea_platform_client_secret")]
        PangeaPlatformClientSecret
    }
}
