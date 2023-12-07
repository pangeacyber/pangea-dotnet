using Newtonsoft.Json;

namespace PangeaCyber.Net.Exceptions
{
    ///
    public class AcceptedResult
    {
        ///
        [JsonProperty("ttl_mins")]
        public int TTLMins { get; private set; }

        ///
        [JsonProperty("retry_counter")]
        public int RetryCounter { get; private set; }

        ///
        [JsonProperty("location")]
        public string Location { get; private set; } = default!;

        ///
        [JsonProperty("post_url")]
        public string? PostURL { get; private set; } = null;

        ///
        [JsonProperty("put_url")]
        public string? PutURL { get; private set; } = null;

        ///
        [JsonProperty("post_form_data")]
        public Dictionary<string, string> PostFormData { get; private set; } = new Dictionary<string, string>();

        ///
        public AcceptedResult() { }

        ///
        public bool HasUploadURL()
        {
            return PutURL != null || PostURL != null;
        }


    }
}
