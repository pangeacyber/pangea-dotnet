using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using PangeaCyber.Net.AIGuard.Models;

namespace PangeaCyber.Net.AIGuard.Requests;

/// <summary>GuardRequest</summary>
[JsonObject(NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
public sealed class GuardRequest : BaseRequest
{
    /// <summary>
    /// 'messages' (required) contains Prompt content and role array in JSON format.
    /// The `content` is the multimodal text or image input that will be analyzed.
    ///  Additional properties such as 'tools' may be provided for analysis.
    /// </summary>
    public required object Input { get; set; }

    /// <summary>
    /// User/Service account id/service account
    /// </summary>
    public string? ActorID { get; set; }

    /// <summary>
    /// Id of source application/agent
    /// </summary>
    public string? AppID { get; set; }

    /// <summary>
    /// (AIDR) collector instance id.
    /// </summary>
    public string? CollectorInstanceID { get; set; }

    /// <summary>
    /// Provide input and output token count.
    /// </summary>
    public bool? CountTokens { get; set; }

    /// <summary>
    /// Setting this value to true will provide a detailed analysis of the text data
    /// </summary>
    public bool? Debug { get; set; }

    /// <summary>
    /// (AIDR) Event Type.
    /// </summary>
    public string? EventType { get; set; }

    /// <summary>
    /// (AIDR) Logging schema.
    /// </summary>
    public IDictionary<string, object>? ExtraInfo { get; set; }

    /// <summary>
    /// Underlying LLM.  Example: 'OpenAI'.
    /// </summary>
    public string? LlmProvider { get; set; }

    /// <summary>
    /// Model used to perform the event. Example: 'gpt'.
    /// </summary>
    public string? Model { get; set; }

    /// <summary>
    /// Model version used to perform the event. Example: '3.5'.
    /// </summary>
    public string? ModelVersion { get; set; }

    /// <summary>
    /// Overrides flags. Note: This parameter has no effect when the request is made
    /// by AIDR
    /// </summary>
    public Overrides? Overrides { get; set; }

    /// <summary>
    /// Recipe key of a configuration of data types and settings defined in the Pangea
    /// User Console. It specifies the rules that are to be applied to the text, such
    /// as defang malicious URLs. Note: This parameter has no effect when the request
    /// is made by AIDR
    /// </summary>
    public string? Recipe { get; set; }

    /// <summary>
    /// Number of tokens in the request.
    /// </summary>
    public long? RequestTokenCount { get; set; }

    /// <summary>
    /// Number of tokens in the response.
    /// </summary>
    public long? ResponseTokenCount { get; set; }

    /// <summary>
    /// IP address of user or app or agent.
    /// </summary>
    public string? SourceIP { get; set; }

    /// <summary>
    /// Location of user or app or agent.
    /// </summary>
    public string? SourceLocation { get; set; }

    /// <summary>
    /// For gateway-like integrations with multi-tenant support.
    /// </summary>
    public string? TenantID { get; set; }
}
