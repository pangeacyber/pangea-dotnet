using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using PangeaCyber.Net.Intel;

namespace PangeaCyber.Net.DataGuard.Models;

/// <summary>Report.</summary>
[JsonObject(NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
public sealed class TextGuardReport
{
    /// <summary>Domain Intel.</summary>
    public IntelResults domainIntel { get; set; } = default!;

    /// <summary>IP Intel.</summary>
    public IntelResults ipIntel { get; set; } = default!;

    /// <summary>Redact.</summary>
    public RedactReport redact { get; set; } = default!;

    /// <summary>URL Intel.</summary>
    public IntelResults urlIntel { get; set; } = default!;

    /// <summary>User Intel.</summary>
    public UserBreachedData userIntel { get; set; } = default!;
}
