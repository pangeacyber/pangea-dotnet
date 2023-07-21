using Newtonsoft.Json;

namespace PangeaCyber.Net.AuthN
{
    ///
    public class UserListResult
    {
        ///
        [JsonProperty("users")]
        public User[] Users { get; private set; } = default!;

        ///
        [JsonProperty("last")]
        public string? Last { get; private set; }

        ///
        [JsonProperty("count")]
        public int? Count { get; private set; }

        ///
        public UserListResult(){}
    }
}
