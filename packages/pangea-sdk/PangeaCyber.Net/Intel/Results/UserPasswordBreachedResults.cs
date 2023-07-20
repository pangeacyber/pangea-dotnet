using Newtonsoft.Json;

namespace PangeaCyber.Net.Intel
{
    ///
    public class UserPasswordBreachedResult : IntelCommonResult
    {
        ///
        [JsonProperty("data")]
        public UserPasswordBreachedData Data { get; set; } = new UserPasswordBreachedData();
    }
}
