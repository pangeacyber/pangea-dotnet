using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;
using PangeaCyber.Net.AIGuard.Models;

namespace PangeaCyber.Net.AIGuard.Requests;

[JsonObject(NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
public sealed class ListServiceConfigsRequest : BaseRequest
{
    [DataMember(Name = "filter", EmitDefaultValue = false)]
    public ServiceConfigListFilter? Filter { get; set; }

    /// <summary>
    /// Reflected value from a previous response to obtain the next page of results.
    /// </summary>
    [DataMember(Name = "last", EmitDefaultValue = false)]
    public string? Last { get; set; }

    /// <summary>
    /// Maximum results to include in the response.
    /// </summary>
    [DataMember(Name = "size", EmitDefaultValue = false)]
    public int Size { get; set; } = 30;

    /// <summary>
    /// Order results asc(ending) or desc(ending).
    /// </summary>
    [DataMember(Name = "order", EmitDefaultValue = false)]
    public OrderEnum? Order { get; set; }

    /// <summary>
    /// Which field to order results by.
    /// </summary>
    [DataMember(Name = "order_by", EmitDefaultValue = false)]
    public OrderByEnum? OrderBy { get; set; }

    /// <summary>
    /// Order results asc(ending) or desc(ending).
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum OrderEnum
    {
        [EnumMember(Value = "asc")]
        Asc = 1,

        [EnumMember(Value = "desc")]
        Desc = 2
    }

    /// <summary>
    /// Which field to order results by.
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum OrderByEnum
    {
        [EnumMember(Value = "id")]
        Id = 1,

        [EnumMember(Value = "created_at")]
        CreatedAt = 2,

        [EnumMember(Value = "updated_at")]
        UpdatedAt = 3
    }
}
