using Newtonsoft.Json;
using PangeaCyber.Net.Share.Models;

namespace PangeaCyber.Net.Share.Results
{
    /// <summary>
    /// Represents the result of a folder creation operation.
    /// </summary>
    public class FolderCreateResult
    {
        ///
        [JsonProperty("object")]
        public ItemData Object { get; set; } = new ItemData();
    }
}
