using Newtonsoft.Json;

namespace PangeaCyber.Net.Vault
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
