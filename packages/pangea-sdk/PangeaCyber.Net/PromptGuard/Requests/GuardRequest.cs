using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using PangeaCyber.Net.PromptGuard.Models;

namespace PangeaCyber.Net.PromptGuard.Requests;

/// <summary>Guard request.</summary>
[JsonObject(NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
public sealed class GuardRequest : BaseRequest
{
    /// <summary>Prompt content and role array</summary>
    public IEnumerable<Message> Messages { get; set; }

    /// <summary>Specific analyzers to be used in the call</summary>
    public IEnumerable<string>? Analyzers { get; set; }

    /// <summary>Boolean to enable classification of the content</summary>
    public bool? Classify { get; set; }

    /// <summary>Constructor.</summary>
    public GuardRequest(IEnumerable<Message> messages)
    {
        Messages = messages ?? throw new ArgumentNullException(nameof(messages));
    }
}
