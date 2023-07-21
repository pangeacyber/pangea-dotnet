using Newtonsoft.Json;

namespace PangeaCyber.Net.Intel
{
    ///
    public class FileReputationResult : IntelCommonResult
    {
        ///
        [JsonProperty("data")]
        public FileReputationData Data { get; set; } = new FileReputationData();
    }
}
