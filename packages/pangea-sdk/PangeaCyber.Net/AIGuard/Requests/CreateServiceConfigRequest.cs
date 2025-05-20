using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using PangeaCyber.Net.AIGuard.Models;

namespace PangeaCyber.Net.AIGuard.Requests;

[JsonObject(NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
public sealed class CreateServiceConfigRequest : BaseRequest
{
    public string Name { get; set; }

    public string? Id { get; set; }
    public AuditDataActivityConfig? AuditDataActivity { get; set; }
    public ConnectionsConfig? Connections { get; set; }
    public object? Recipes { get; set; }

    /// <summary>Constructor</summary>
    public CreateServiceConfigRequest(string name)
    {
        Name = name ?? throw new ArgumentNullException(nameof(name));
    }
}
