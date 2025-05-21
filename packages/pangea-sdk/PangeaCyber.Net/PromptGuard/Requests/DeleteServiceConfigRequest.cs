using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace PangeaCyber.Net.PromptGuard.Requests;

[DataContract]
[JsonObject(NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
public sealed class DeleteServiceConfigRequest : BaseRequest
{
    [DataMember(Name = "id", IsRequired = true)]
    public string Id { get; set; }

    /// <summary>Constructor</summary>
    public DeleteServiceConfigRequest(string id)
    {
        Id = id ?? throw new ArgumentNullException(nameof(id));
    }
}
