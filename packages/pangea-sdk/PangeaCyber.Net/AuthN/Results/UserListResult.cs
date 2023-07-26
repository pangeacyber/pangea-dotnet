using Newtonsoft.Json;
using PangeaCyber.Net.AuthN.Models;

namespace PangeaCyber.Net.AuthN.Results
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
        public UserListResult() { }
    }
}
