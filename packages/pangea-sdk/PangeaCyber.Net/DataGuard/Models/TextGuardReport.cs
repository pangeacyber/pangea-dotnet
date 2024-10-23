using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using PangeaCyber.Net.Intel;

namespace PangeaCyber.Net.DataGuard.Models;

/// <summary>Report.</summary>
[JsonObject(NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
public sealed class TextGuardReport
{
    /// <summary>Domain Intel.</summary>
    public IntelResults DomainIntel { get; set; } = default!;

    /// <summary>IP Intel.</summary>
    public IntelResults IpIntel { get; set; } = default!;

    /// <summary>Redact.</summary>
    public RedactReport Redact { get; set; } = default!;

    /// <summary>URL Intel.</summary>
    public IntelResults UrlIntel { get; set; } = default!;

    /// <summary>User Intel.</summary>
    public UserBreachedData UserIntel { get; set; } = default!;
}
