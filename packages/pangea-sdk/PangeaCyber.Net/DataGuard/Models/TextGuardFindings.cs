using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace PangeaCyber.Net.DataGuard.Models;

/// <summary>Text guard findings.</summary>
[JsonObject(NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
public sealed class TextGuardFindings
{
    /// <summary>Artifact count.</summary>
    public int ArtifactCount { get; set; }

    /// <summary>Malicious count.</summary>
    public int MaliciousCount { get; set; }

    /// <summary>Security issues.</summary>
    public TextGuardSecurityIssues SecurityIssues { get; set; } = default!;
}
