using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace PangeaCyber.Net.AIGuard.Models;

/// <summary>Additional fields to include in activity log</summary>
[JsonObject(NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
public sealed class LogFields
{
    /// <summary>Origin or source application of the event</summary>
    public string? Citation { get; set; }

    /// <summary>Stores supplementary details related to the event</summary>
    public string? ExtraInfo { get; set; }

    /// <summary>Model used to perform the event</summary>
    public string? Model { get; set; }

    /// <summary>IP address of user or app or agent</summary>
    public string? Source { get; set; }

    /// <summary>Tools used to perform the event</summary>
    public string? Tools { get; set; }
}
