
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace PangeaCyber.Net.AuthZ.Models;

/// <summary>Tuple</summary>
[JsonObject(NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
public sealed class Tuple
{
    /// <summary>Resource</summary>
    public Resource Resource { get; set; }

    /// <summary>Relation</summary>
    public string Relation { get; set; }

    /// <summary>Subject</summary>
    public Subject Subject { get; set; }

    /// <summary>ExpiresAt</summary>
    public DateTimeOffset? ExpiresAt { get; set; }

    /// <summary>Constructor</summary>
    public Tuple(Resource resource, string relation, Subject subject)
    {
        Resource = resource;
        Relation = relation;
        Subject = subject;
    }
}
