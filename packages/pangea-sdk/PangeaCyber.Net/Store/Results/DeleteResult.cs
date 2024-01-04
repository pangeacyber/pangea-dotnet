using Newtonsoft.Json;

namespace PangeaCyber.Net.Store.Results
{
    /// <summary>
    /// Represents the result of a delete operation.
    /// </summary>
    public class DeleteResult
    {
        ///
        [JsonProperty("count")]
        public int Count { get; set; }
    }
}
