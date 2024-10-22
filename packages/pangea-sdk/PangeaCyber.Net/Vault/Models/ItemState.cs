using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;

namespace PangeaCyber.Net.Vault.Models
{
    /// <summary>Item state.</summary>
    [JsonConverter(typeof(StringEnumConverter), typeof(SnakeCaseNamingStrategy))]
    public enum ItemState
    {
        /// <summary>Enabled.</summary>
        Enabled,

        /// <summary>Disabled.</summary>
        Disabled,
    }
}
