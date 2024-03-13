using Newtonsoft.Json;
using PangeaCyber.Net.Audit.Models;

namespace PangeaCyber.Net.Audit
{
    /// <kind>class</kind>
    /// <summary>
    /// DownloadRequest
    /// </summary>
    public class DownloadRequest : BaseRequest
    {
        ///
        [JsonProperty("result_id", Required = Required.Always)]
        public String ResultID { get; set; } = default!;

        ///
        [JsonProperty("format")]
        public DownloadFormat? Format { get; set; } = null;

        ///
        public DownloadRequest(String resultID, DownloadFormat? format = null)
        {
            ResultID = resultID;
            Format = format;
        }
    }
}
