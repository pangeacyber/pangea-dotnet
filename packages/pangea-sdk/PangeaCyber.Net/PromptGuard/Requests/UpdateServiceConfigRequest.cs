using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using PangeaCyber.Net.PromptGuard.Models;

namespace PangeaCyber.Net.PromptGuard.Requests;

[JsonObject(NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
public sealed class UpdateServiceConfigRequest : BaseRequest
{
    public string? Id { get; set; }
    public string? Version { get; set; }
    public Dictionary<string, bool>? Analyzers { get; set; }
    public decimal? MaliciousDetectionThreshold { get; set; }
    public decimal? BenignDetectionThreshold { get; set; }
    public AuditDataActivityConfig? AuditDataActivity { get; set; }
}
