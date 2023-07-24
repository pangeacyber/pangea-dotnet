using Newtonsoft.Json;

namespace PangeaCyber.Net.Vault.Models
{
    ///
    public class ListItemData : ItemData
    {
        ///
        [JsonProperty("compromised_versions")]
        public ItemVersionData[] CompromisedVersions { get; set; } = default!;
    }
}
