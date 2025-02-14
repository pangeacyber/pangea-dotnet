using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using PangeaCyber.Net.AIGuard.Models;

namespace PangeaCyber.Net.AIGuard.Requests;

/// <summary>LLM input guard request</summary>
[JsonObject(NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
public sealed class LlmInputGuardRequest<T> : BaseRequest
{
    /// <summary>
    /// Structured full llm payload data to be scanned by AI Guard for PII, sensitive data, malicious content, and other
    /// data types defined by the configuration. Supports processing up to 10KB of JSON text.
    /// </summary>
    public T LlmInput { get; set; }

    /// <summary>
    /// Recipe key of a configuration of data types and settings defined in the Pangea User Console. It specifies the
    /// rules that are to be applied to the text, such as defang malicious URLs.
    /// </summary>
    public string? Recipe { get; set; }

    /// <summary>Setting this value to true will provide a detailed analysis of the text data</summary>
    public bool Debug { get; set; }

    /// <summary>Short string hint for the LLM Provider information</summary>
    public string? LlmInfo { get; set; }

    /// <summary>Additional fields to include in activity log</summary>
    public LogFields? LogFields { get; set; }

    /// <summary>Constructor.</summary>
    public LlmInputGuardRequest(T llmInput)
    {
        LlmInput = llmInput ?? throw new ArgumentNullException(nameof(llmInput));
    }
}
