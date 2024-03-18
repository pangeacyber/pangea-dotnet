using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace PangeaCyber.Net.Share.Models
{
    /// <summary>
    /// Represents the order by options for items.
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum ItemOrderBy
    {
        /// <summary>
        /// Order by item ID.
        /// </summary>
        [EnumMember(Value = "id")]
        Id,

        /// <summary>
        /// Order by item creation timestamp.
        /// </summary>
        [EnumMember(Value = "created_at")]
        CreatedAt,

        /// <summary>
        /// Order by item name.
        /// </summary>
        [EnumMember(Value = "name")]
        Name,

        /// <summary>
        /// Order by parent item ID.
        /// </summary>
        [EnumMember(Value = "parent_id")]
        ParentId,

        /// <summary>
        /// Order by item type.
        /// </summary>
        [EnumMember(Value = "type")]
        Type,

        /// <summary>
        /// Order by item last update timestamp.
        /// </summary>
        [EnumMember(Value = "updated_at")]
        UpdatedAt
    }
}
