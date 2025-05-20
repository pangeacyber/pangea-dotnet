using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace PangeaCyber.Net.AIGuard.Models;

/// <summary>Response from an analyzer.</summary>
[DataContract]
[JsonObject(NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
public sealed class ServiceConfigListFilter
{
    /// <summary>
    /// Only records where id equals this value.
    /// </summary>
    [DataMember(Name = "id", EmitDefaultValue = false)]
    public string? Id { get; set; }

    /// <summary>
    /// Only records where id includes each substring.
    /// </summary>
    [DataMember(Name = "id__contains", EmitDefaultValue = false)]
    public List<string>? IdContains { get; set; }

    /// <summary>
    /// Only records where id equals one of the provided substrings.
    /// </summary>
    [DataMember(Name = "id__in", EmitDefaultValue = false)]
    public List<string>? IdIn { get; set; }

    /// <summary>
    /// Only records where created_at equals this value.
    /// </summary>
    [DataMember(Name = "created_at", EmitDefaultValue = false)]
    public DateTimeOffset CreatedAt { get; set; }

    /// <summary>
    /// Only records where created_at is greater than this value.
    /// </summary>
    [DataMember(Name = "created_at__gt", EmitDefaultValue = false)]
    public DateTimeOffset CreatedAtGt { get; set; }

    /// <summary>
    /// Only records where created_at is greater than or equal to this value.
    /// </summary>
    [DataMember(Name = "created_at__gte", EmitDefaultValue = false)]
    public DateTimeOffset CreatedAtGte { get; set; }

    /// <summary>
    /// Only records where created_at is less than this value.
    /// </summary>
    [DataMember(Name = "created_at__lt", EmitDefaultValue = false)]
    public DateTimeOffset CreatedAtLt { get; set; }

    /// <summary>
    /// Only records where created_at is less than or equal to this value.
    /// </summary>
    [DataMember(Name = "created_at__lte", EmitDefaultValue = false)]
    public DateTimeOffset CreatedAtLte { get; set; }

    /// <summary>
    /// Only records where updated_at equals this value.
    /// </summary>
    [DataMember(Name = "updated_at", EmitDefaultValue = false)]
    public DateTimeOffset UpdatedAt { get; set; }

    /// <summary>
    /// Only records where updated_at is greater than this value.
    /// </summary>
    [DataMember(Name = "updated_at__gt", EmitDefaultValue = false)]
    public DateTimeOffset UpdatedAtGt { get; set; }

    /// <summary>
    /// Only records where updated_at is greater than or equal to this value.
    /// </summary>
    [DataMember(Name = "updated_at__gte", EmitDefaultValue = false)]
    public DateTimeOffset UpdatedAtGte { get; set; }

    /// <summary>
    /// Only records where updated_at is less than this value.
    /// </summary>
    [DataMember(Name = "updated_at__lt", EmitDefaultValue = false)]
    public DateTimeOffset UpdatedAtLt { get; set; }

    /// <summary>
    /// Only records where updated_at is less than or equal to this value.
    /// </summary>
    [DataMember(Name = "updated_at__lte", EmitDefaultValue = false)]
    public DateTimeOffset UpdatedAtLte { get; set; }
}
