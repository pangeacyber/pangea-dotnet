using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace PangeaCyber.Net.AIGuard.Requests;

/// <summary>Text guard request.</summary>
[JsonObject(NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
public sealed class TextGuardRequest : BaseRequest
{
    /// <summary>Text.</summary>
    public string Text { get; set; }

    /// <summary>Recipe.</summary>
    public string? Recipe { get; set; }

    /// <summary>Debug.</summary>
    public bool Debug { get; set; }

    /// <summary>Constructor.</summary>
    public TextGuardRequest(string text)
    {
        Text = text ?? throw new ArgumentNullException(nameof(text));
    }
}
