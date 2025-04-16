using Newtonsoft.Json;

namespace PangeaCyber.Net.Audit;

/// <summary>
/// A description of a field in an audit log.
/// </summary>
public sealed class AuditSchemaField
{
    /// <summary>
    /// Prefix name / identity for the field.
    /// </summary>
    [JsonProperty("id")]
    public string Id { get; set; } = default!;

    /// <summary>
    /// The data type for the field.
    /// </summary>
    [JsonProperty("type")]
    public string Type { get; set; } = default!;

    /// <summary>
    /// Human display description of the field.
    /// </summary>
    [JsonProperty("description")]
    public string? Description { get; set; }

    /// <summary>
    /// Human display name/title of the field.
    /// </summary>
    [JsonProperty("name")]
    public string? Name { get; set; }

    /// <summary>
    /// If true, redaction is performed against this field (if configured.) Only valid for string type.
    /// </summary>
    [JsonProperty("redact")]
    public bool? Redact { get; set; }

    /// <summary>
    /// If true, this field is required to exist in all logged events.
    /// </summary>
    [JsonProperty("required")]
    public bool? Required { get; set; }

    /// <summary>
    /// The maximum size of the field. Only valid for strings, which limits number of UTF-8 characters.
    /// </summary>
    [JsonProperty("size")]
    public int? Size { get; set; }

    /// <summary>
    /// If true, this field is visible by default in audit UIs.
    /// </summary>
    [JsonProperty("ui_default_visible")]
    public bool? UiDefaultVisible { get; set; }
}
