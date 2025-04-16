using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace PangeaCyber.Net.Redact;

[JsonObject(NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
public sealed class ServiceConfigFilter
{
    /// <summary>
    /// Only records where id equals this value.
    /// </summary>
    [JsonProperty("id")]
    public string? Id { get; set; }

    /// <summary>
    /// Only records where id includes each substring.
    /// </summary>
    [JsonProperty("id__contains")]
    public IList<string>? IdContains { get; set; }

    /// <summary>
    /// Only records where id equals one of the provided substrings.
    /// </summary>
    [JsonProperty("id__in")]
    public IList<string>? IdIn { get; set; }

    /// <summary>
    /// Only records where created_at equals this value.
    /// </summary>
    [JsonProperty("created_at")]
    public string? CreatedAt { get; set; }

    /// <summary>
    /// Only records where created_at is greater than this value.
    /// </summary>
    [JsonProperty("created_at__gt")]
    public string? CreatedAtGt { get; set; }

    /// <summary>
    /// Only records where created_at is greater than or equal to this value.
    /// </summary>
    [JsonProperty("created_at__gte")]
    public string? CreatedAtGte { get; set; }

    /// <summary>
    /// Only records where created_at is less than this value.
    /// </summary>
    [JsonProperty("created_at__lt")]
    public string? CreatedAtLt { get; set; }

    /// <summary>
    /// Only records where created_at is less than or equal to this value.
    /// </summary>
    [JsonProperty("created_at__lte")]
    public string? CreatedAtLte { get; set; }

    /// <summary>
    /// Only records where updated_at equals this value.
    /// </summary>
    [JsonProperty("updated_at")]
    public string? UpdatedAt { get; set; }

    /// <summary>
    /// Only records where updated_at is greater than this value.
    /// </summary>
    [JsonProperty("updated_at__gt")]
    public string? UpdatedAtGt { get; set; }

    /// <summary>
    /// Only records where updated_at is greater than or equal to this value.
    /// </summary>
    [JsonProperty("updated_at__gte")]
    public string? UpdatedAtGte { get; set; }

    /// <summary>
    /// Only records where updated_at is less than this value.
    /// </summary>
    [JsonProperty("updated_at__lt")]
    public string? UpdatedAtLt { get; set; }

    /// <summary>
    /// Only records where updated_at is less than or equal to this value.
    /// </summary>
    [JsonProperty("updated_at__lte")]
    public string? UpdatedAtLte { get; set; }
}
