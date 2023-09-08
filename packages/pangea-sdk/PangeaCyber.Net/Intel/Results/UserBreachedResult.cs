using Newtonsoft.Json;

namespace PangeaCyber.Net.Intel
{
    ///
    public class UserBreachedResult : IntelCommonResult
    {
        ///
        [JsonProperty("data")]
        public UserBreachedData Data { get; private set; } = new UserBreachedData();
    }
}
