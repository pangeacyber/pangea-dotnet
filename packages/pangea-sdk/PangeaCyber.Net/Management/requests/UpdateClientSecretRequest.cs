using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace PangeaCyber.Net.Management;

[JsonObject(NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
public class UpdateClientSecretRequest : BaseRequest
{
    public int? ClientSecretExpiresIn { get; set; }
    public string? ClientSecretName { get; set; }
    public string? ClientSecretDescription { get; set; }
}
