using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using PangeaCyber.Net.PromptGuard.Models;

namespace PangeaCyber.Net.PromptGuard.Requests;

/// <summary>Guard request.</summary>
[JsonObject(NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
public sealed class GuardRequest : BaseRequest
{
    /// <summary>Messages.</summary>
    public IEnumerable<Message> Messages { get; set; }

    /// <summary>Constructor.</summary>
    public GuardRequest(IEnumerable<Message> messages)
    {
        Messages = messages ?? throw new ArgumentNullException(nameof(messages));
    }
}