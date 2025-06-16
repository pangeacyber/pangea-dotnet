using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using PangeaCyber.Net.AIGuard.Models;

namespace PangeaCyber.Net.AIGuard.Requests;

[JsonObject(NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
public sealed class GuardRequest : BaseRequest
{
    /// <summary>
    /// Prompt content and role array in JSON format. The content is the
    /// multimodal text or image input that will be analyzed.
    /// </summary>
    public required List<MultimodalMessage> Messages { get; set; }

    /// <summary>
    /// Recipe key of a configuration of data types and settings defined in the
    /// Pangea User Console. It specifies the rules that are to be applied to
    /// the text, such as defang malicious URLs.
    /// </summary>
    public string? Recipe { get; set; }

    /// <summary>
    /// Setting this value to true will provide a detailed analysis of the text
    /// data
    /// </summary>
    public bool? Debug { get; set; }

    public Overrides? Overrides { get; set; }

    /// <summary>
    /// Model version used to perform the event. Example: &#39;3.5&#39;.
    /// </summary>
    public string? ModelVersion { get; set; }

    /// <summary>
    /// Number of tokens in the request.
    /// </summary>
    public int? RequestTokenCount { get; set; }

    /// <summary>
    /// Number of tokens in the response.
    /// </summary>
    public int? ResponseTokenCount { get; set; }

    /// <summary>
    /// IP address of user or app or agent.
    /// </summary>
    public string? SourceIp { get; set; }

    /// <summary>
    /// Location of user or app or agent.
    /// </summary>
    public string? SourceLocation { get; set; }

    /// <summary>
    /// For gateway-like integrations with multi-tenant support.
    /// </summary>
    public string? TenantId { get; set; }

    /// <summary>
    /// (AIDR) sensor mode.
    /// </summary>
    public string? SensorMode { get; set; }

    /// <summary>
    /// (AIDR) Logging schema.
    /// </summary>
    public IDictionary<string, object>? Context { get; set; }
}
