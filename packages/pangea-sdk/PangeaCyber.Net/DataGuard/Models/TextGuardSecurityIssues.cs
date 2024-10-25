using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace PangeaCyber.Net.DataGuard.Models;

/// <summary>Security issues.</summary>
[JsonObject(NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
public sealed class TextGuardSecurityIssues
{
    /// <summary>
    /// Compromised email addresses count.
    /// </summary>
    public int CompromisedEmailAddresses { get; set; }

    /// <summary>
    /// Malicious domains count.
    /// </summary>
    public int MaliciousDomainCount { get; set; }

    /// <summary>
    /// Malicious IP addresses count.
    /// </summary>
    public int MaliciousIpCount { get; set; }

    /// <summary>
    /// Malicious URLs count.
    /// </summary>
    public int MaliciousUrlCount { get; set; }

    /// <summary>
    /// Matched rules count.
    /// </summary>
    public int MatchedRulesCount { get; set; }
}
