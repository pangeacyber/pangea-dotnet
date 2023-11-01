using Newtonsoft.Json;

namespace PangeaCyber.Net.Intel
{
    ///
    public class UserPasswordBreachedBulkResult : IntelCommonResult
    {
        ///
        [JsonProperty("data")]
        public UserPasswordBreachedBulkData Data { get; private set; } = new UserPasswordBreachedBulkData();
    }
}
