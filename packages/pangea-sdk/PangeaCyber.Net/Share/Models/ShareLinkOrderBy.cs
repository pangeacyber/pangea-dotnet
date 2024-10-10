using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace PangeaCyber.Net.Share.Models
{
    /// <summary>
    /// Represents the order by options for share links.
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum ShareLinkOrderBy
    {
        /// <summary>
        /// Order by share link ID.
        /// </summary>
        [EnumMember(Value = "id")]
        Id,

        /// <summary>Order by bucket ID.</summary>
        [EnumMember(Value = "bucket_id")]
        BucketId,

        /// <summary>
        /// Order by share link target.
        /// </summary>
        [EnumMember(Value = "target")]
        Target,

        /// <summary>
        /// Order by share link type.
        /// </summary>
        [EnumMember(Value = "link_type")]
        LinkType,

        /// <summary>
        /// Order by access count.
        /// </summary>
        [EnumMember(Value = "access_count")]
        AccessCount,

        /// <summary>
        /// Order by maximum access count.
        /// </summary>
        [EnumMember(Value = "max_access_count")]
        MaxAccessCount,

        /// <summary>
        /// Order by share link creation timestamp.
        /// </summary>
        [EnumMember(Value = "created_at")]
        CreatedAt,

        /// <summary>
        /// Order by share link expiration timestamp.
        /// </summary>
        [EnumMember(Value = "expires_at")]
        ExpiresAt,

        /// <summary>
        /// Order by last accessed timestamp.
        /// </summary>
        [EnumMember(Value = "last_accessed_at")]
        LastAccessedAt,

        /// <summary>
        /// Order by share link URL.
        /// </summary>
        [EnumMember(Value = "link")]
        Link
    }
}
