using Newtonsoft.Json;
using PangeaCyber.Net.Share.Models;

namespace PangeaCyber.Net.Share.Results
{
    /// <summary>
    /// Represents the result of a put operation.
    /// </summary>
    public class PutResult
    {
        ///
        [JsonProperty("object")]
        public ItemData Object { get; set; } = new ItemData();
    }
}
