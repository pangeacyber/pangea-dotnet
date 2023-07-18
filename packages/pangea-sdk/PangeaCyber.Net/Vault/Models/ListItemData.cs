using Newtonsoft.Json;

namespace PangeaCyber.Net.Vault
{
    ///
    public class ListItemData : ItemData
    {
        ///
        [JsonProperty("compromised_versions")]
        public ItemVersionData[] CompromisedVersions { get; set; } = default!;
    }
}
