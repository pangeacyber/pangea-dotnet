using Newtonsoft.Json;

namespace PangeaCyber.Net.Intel
{
    ///
    public class UserBreachedBulkResult : IntelCommonResult
    {
        ///
        [JsonProperty("data")]
        public UserBreachedBulkData Data { get; private set; } = new UserBreachedBulkData();
    }
}
