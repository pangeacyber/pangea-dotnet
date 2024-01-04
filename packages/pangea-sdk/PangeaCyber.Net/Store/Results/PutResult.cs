using Newtonsoft.Json;
using PangeaCyber.Net.Store.Models;

namespace PangeaCyber.Net.Store.Results
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
