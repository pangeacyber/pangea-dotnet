using Newtonsoft.Json;
using PangeaCyber.Net.Store.Models;

namespace PangeaCyber.Net.Store.Results
{
    /// <summary>
    /// Represents the result of an update operation.
    /// </summary>
    public class UpdateResult
    {
        ///
        [JsonProperty("object")]
        public ItemData Object { get; set; } = new ItemData();
    }
}
