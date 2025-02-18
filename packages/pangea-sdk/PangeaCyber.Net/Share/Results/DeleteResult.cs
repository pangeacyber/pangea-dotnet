using Newtonsoft.Json;

namespace PangeaCyber.Net.Share.Results
{
    /// <summary>
    /// Represents the result of a delete operation.
    /// </summary>
    public class DeleteResult
    {
        /// <summary> Number of objects deleted.</summary>
        [JsonProperty("count")]
        public int Count { get; set; }
    }
}
