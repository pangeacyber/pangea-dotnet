using Newtonsoft.Json;

namespace PangeaCyber.Net.Intel
{
    ///
    public class FileReputationBulkResult : IntelCommonResult
    {
        ///
        [JsonProperty("data")]
        public FileReputationBulkData Data { get; private set; } = new FileReputationBulkData();
    }
}
