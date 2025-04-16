using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace PangeaCyber.Net.Management;

[JsonObject(NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
public class ListClientSecretMetadataRequest : BaseRequest
{
    /// <summary>
    /// The client ID to list secrets for
    /// </summary>
    [JsonProperty(Required = Required.Always)]
    public string Id { get; set; } = default!;

    /// <summary>
    /// Only records where created_at equals this value
    /// </summary>
    [JsonProperty("created_at")]
    public string? CreatedAt { get; set; }

    /// <summary>
    /// Only records where created_at is greater than this value
    /// </summary>
    [JsonProperty("created_at__gt")]
    public string? CreatedAtGt { get; set; }

    /// <summary>
    /// Only records where created_at is greater than or equal to this value
    /// </summary>
    [JsonProperty("created_at__gte")]
    public string? CreatedAtGte { get; set; }

    /// <summary>
    /// Only records where created_at is less than this value
    /// </summary>
    [JsonProperty("created_at__lt")]
    public string? CreatedAtLt { get; set; }

    /// <summary>
    /// Only records where created_at is less than or equal to this value
    /// </summary>
    [JsonProperty("created_at__lte")]
    public string? CreatedAtLte { get; set; }

    /// <summary>
    /// Only records where name equals this value
    /// </summary>
    [JsonProperty("client_secret_name")]
    public string? ClientSecretName { get; set; }

    /// <summary>
    /// Only records where name includes each substring
    /// </summary>
    [JsonProperty("client_secret_name__contains")]
    public IList<string>? ClientSecretNameContains { get; set; }

    /// <summary>
    /// Only records where name equals one of the provided substrings
    /// </summary>
    [JsonProperty("client_secret_name__in")]
    public IList<string>? ClientSecretNameIn { get; set; }

    /// <summary>
    /// Reflected value from a previous response to obtain the next page of results
    /// </summary>
    [JsonProperty("last")]
    public string? Last { get; set; }

    /// <summary>
    /// Order results asc(ending) or desc(ending)
    /// </summary>
    [JsonProperty("order")]
    public string? Order { get; set; }

    /// <summary>
    /// Which field to order results by
    /// </summary>
    [JsonProperty("order_by")]
    public string? OrderBy { get; set; }

    /// <summary>
    /// Maximum results to include in the response
    /// </summary>
    [JsonProperty("size")]
    public int? Size { get; set; }
}
