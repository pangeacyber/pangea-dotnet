using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace PangeaCyber.Net.AuthN.Models;

/// <summary>GroupsFilter</summary>
[JsonObject(NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
public sealed class GroupsFilter
{
    /// <summary>Only records where created_at equals this value.</summary>
    [JsonProperty("created_at")]
    public string? CreatedAt { get; set; }

    /// <summary>Only records where created_at is greater than this value.</summary>
    [JsonProperty("created_at__gt")]
    public string? CreatedAtGreaterThan { get; set; }

    /// <summary>Only records where created_at is greater than or equal to this value.</summary>
    [JsonProperty("created_at__gte")]
    public string? CreatedAtGreaterThanOrEqual { get; set; }

    /// <summary>Only records where created_at is less than this value.</summary>
    [JsonProperty("created_at__lt")]
    public string? CreatedAtLessThan { get; set; }

    /// <summary>Only records where created_at is less than or equal to this value.</summary>
    [JsonProperty("created_at__lte")]
    public string? CreatedAtLessThanOrEqual { get; set; }

    /// <summary>Only records where created_at includes this value.</summary>
    [JsonProperty("created_at__contains")]
    public string? CreatedAtContains { get; set; }

    /// <summary>Only records where id equals this value.</summary>
    [JsonProperty("id")]
    public string? Id { get; set; }

    /// <summary>Only records where id includes each substring.</summary>
    [JsonProperty("id__contains")]
    public IReadOnlyList<string>? IdContains { get; set; }

    /// <summary>Only records where id equals one of the provided substrings.</summary>
    [JsonProperty("id__in")]
    public IReadOnlyList<string>? IdIn { get; set; }

    /// <summary>Only records where name equals this value.</summary>
    [JsonProperty("name")]
    public string? Name { get; set; }

    /// <summary>Only records where name includes each substring.</summary>
    [JsonProperty("name__contains")]
    public IReadOnlyList<string>? NameContains { get; set; }

    /// <summary>Only records where name equals one of the provided substrings.</summary>
    [JsonProperty("name__in")]
    public IReadOnlyList<string>? NameIn { get; set; }

    /// <summary>Only records where type equals this value.</summary>
    [JsonProperty("type")]
    public string? Type { get; set; }

    /// <summary>Only records where type includes each substring.</summary>
    [JsonProperty("type__contains")]
    public IReadOnlyList<string>? TypeContains { get; set; }

    /// <summary>Only records where type equals one of the provided substrings.</summary>
    [JsonProperty("type__in")]
    public IReadOnlyList<string>? TypeIn { get; set; }

    /// <summary>Only records where updated_at equals this value.</summary>
    [JsonProperty("updated_at")]
    public string? UpdatedAt { get; set; }

    /// <summary>Only records where updated_at is greater than this value.</summary>
    [JsonProperty("updated_at__gt")]
    public string? UpdatedAtGreaterThan { get; set; }

    /// <summary>Only records where updated_at is greater than or equal to this value.</summary>
    [JsonProperty("updated_at__gte")]
    public string? UpdatedAtGreaterThanOrEqual { get; set; }

    /// <summary>Only records where updated_at is less than this value.</summary>
    [JsonProperty("updated_at__lt")]
    public string? UpdatedAtLessThan { get; set; }

    /// <summary>Only records where updated_at is less than or equal to this value.</summary>
    [JsonProperty("updated_at__lte")]
    public string? UpdatedAtLessThanOrEqual { get; set; }

    /// <summary>Only records where updated_at includes this value.</summary>
    [JsonProperty("updated_at__contains")]
    public string? UpdatedAtContains { get; set; }
}
