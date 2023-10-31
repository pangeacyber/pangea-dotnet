using Newtonsoft.Json;

namespace PangeaCyber.Net.Exceptions
{
    ///
    public class AcceptedStatus
    {
        ///
        [JsonProperty("upload_url")]
        public string? UploadURL { get; private set; } = null;

        ///
        [JsonProperty("upload_details")]
        public Dictionary<string, string> UploadDetails { get; private set; } = new Dictionary<string, string>();

        ///
        public AcceptedStatus() { }

    }
}
