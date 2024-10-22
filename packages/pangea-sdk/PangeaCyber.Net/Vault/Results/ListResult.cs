using Newtonsoft.Json;
using PangeaCyber.Net.Vault.Models;

namespace PangeaCyber.Net.Vault.Results
{
    ///
    public class ListResult
    {
        ///
        [JsonProperty("items")]
        public List<ListItemData> Items { get; set; } = default!;

        /// <summary>
        /// Internal ID returned in the previous look up response. Used for pagination.
        /// </summary>
        [JsonProperty("last")]
        public string? Last { get; set; }
    }
}
