using Newtonsoft.Json;

namespace PangeaCyber.Net.AuthZ.Results
{
    /// <kind>class</kind>
    /// <summary>
    /// ListResourcesResult
    /// </summary>
    public sealed class ListResourcesResult
    {
        ///
        [JsonProperty("ids")]
        public string[] IDs { get; private set; } = { };

    }
}
