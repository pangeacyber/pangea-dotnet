using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace PangeaCyber.Net.AIGuard.Models;

/// <summary>Malicious entity detection overrides.</summary>
[JsonObject(NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
public sealed class MaliciousEntityOverride
{
    /// <summary>Whether malicious entity detection is disabled.</summary>
    public bool? Disabled { get; set; }

    /// <summary>Action for IP address detection.</summary>
    public MaliciousEntityAction? IpAddress { get; set; }

    /// <summary>Action for URL detection.</summary>
    public MaliciousEntityAction? Url { get; set; }

    /// <summary>Action for domain detection.</summary>
    public MaliciousEntityAction? Domain { get; set; }
}
