using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace PangeaCyber.Net.DataGuard.Requests;

/// <summary>File guard request.</summary>
[JsonObject(NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
public sealed class FileGuardRequest : BaseRequest
{
    /// <summary>File URL.</summary>
    public string FileUrl { get; set; }

    /// <summary>Constructor.</summary>
    public FileGuardRequest(string fileUrl)
    {
        FileUrl = fileUrl ?? throw new ArgumentNullException(nameof(fileUrl));
    }
}
