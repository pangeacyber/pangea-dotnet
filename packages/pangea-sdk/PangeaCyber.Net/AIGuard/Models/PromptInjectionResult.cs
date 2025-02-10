using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace PangeaCyber.Net.AIGuard.Models;

/// <summary>Result containing triggered prompt injection analyzers.</summary>
[JsonObject(NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
public sealed class PromptInjectionResult
{
    /// <summary>Action</summary>
    public string Action { get; set; } = default!;

    /// <summary>List of analyzer responses that were triggered.</summary>
    public List<AnalyzerResponse> AnalyzerResponses { get; set; } = default!;
}
