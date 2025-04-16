using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace PangeaCyber.Net.Management;

[JsonObject(NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
public class ListProjectsFilter
{
    public string Search { get; set; } = default!;

    public string Geo { get; set; } = default!;

    public string Region { get; set; } = default!;
}
