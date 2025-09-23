using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace PangeaCyber.Net.AIGuard.Models;

/// <summary>Image detection overrides.</summary>
[JsonObject(NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
public sealed class ImageOverride
{
    /// <summary>Whether image detection is disabled.</summary>
    public bool? Disabled { get; set; }

    /// <summary>Action to take on detection.</summary>
    public ImageAction? Action { get; set; }

    /// <summary>Topics.</summary>
    public List<string>? Topics { get; set; }

    /// <summary>Detection threshold.</summary>
    public double? Threshold { get; set; }
}
