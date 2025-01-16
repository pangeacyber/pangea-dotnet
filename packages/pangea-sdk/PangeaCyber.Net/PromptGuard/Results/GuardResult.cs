using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace PangeaCyber.Net.PromptGuard.Results;

/// <summary>Guard result.</summary>
[JsonObject(NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
public sealed class GuardResult
{
    /// <summary>Boolean response for if the prompt was considered malicious or no</summary>
    public bool Detected { get; set; }

    /// <summary>Type of analysis, either direct or indirect</summary>
    public string? Type { get; set; }

    /// <summary>Prompt Analyzers for identifying and rejecting properties of prompts</summary>
    public string? Analyzer { get; set; }

    /// <summary>Percent of confidence in the detection result, ranging from 0 to 100</summary>
    public int Confidence { get; set; }
}
