using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using PangeaCyber.Net.AIGuard.Models;

namespace PangeaCyber.Net.AIGuard.Requests;

[JsonObject(NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
public sealed class UpdateServiceConfigRequest : BaseRequest
{
    public string Id { get; set; }
    public string Name { get; set; }

    public AuditDataActivityConfig? AuditDataActivity { get; set; }
    public ConnectionsConfig? Connections { get; set; }
    public object? Recipes { get; set; }

    /// <summary>Constructor</summary>
    public UpdateServiceConfigRequest(string id, string name)
    {
        Id = id ?? throw new ArgumentNullException(nameof(id));
        Name = name ?? throw new ArgumentNullException(nameof(name));
    }
}
