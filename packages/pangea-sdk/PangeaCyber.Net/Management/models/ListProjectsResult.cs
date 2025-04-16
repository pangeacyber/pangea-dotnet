using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace PangeaCyber.Net.Management;

[JsonObject(NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
public sealed class ListProjectsResult
{
    public IList<Project> Results { get; set; } = default!;
    public int Count { get; set; }
    public int? Offset { get; set; }
}
