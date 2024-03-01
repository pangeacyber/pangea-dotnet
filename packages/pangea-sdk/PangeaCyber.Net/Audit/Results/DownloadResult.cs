using Newtonsoft.Json;

namespace PangeaCyber.Net.Audit
{
    /// <kind>class</kind>
    /// <summary>
    /// DownloadResult
    /// </summary>
    public sealed class DownloadResult
    {
        ///
        [JsonProperty("dest_url")]
        public String DestURL { get; private set; } = default!;

    }
}
