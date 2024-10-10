using Newtonsoft.Json;
using PangeaCyber.Net.Share.Models;

namespace PangeaCyber.Net.Share.Results
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
