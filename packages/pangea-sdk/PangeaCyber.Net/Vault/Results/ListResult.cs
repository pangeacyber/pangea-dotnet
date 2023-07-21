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

        ///
        [JsonProperty("count")]
        public int Count { get; set; }

        ///
        [JsonProperty("last")]
        public string? Last { get; set; }

        ///
        public ListResult()
        {
        }

        ///
        public List<ListItemData> GetItems()
        {
            return Items;
        }
    }
}
