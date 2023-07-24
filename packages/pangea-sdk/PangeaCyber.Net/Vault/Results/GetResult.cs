using Newtonsoft.Json;
using PangeaCyber.Net.Vault.Models;

namespace PangeaCyber.Net.Vault.Results
{
    ///
    public class GetResult : ItemData
    {
        ///
        [JsonProperty("versions")]
        public ItemVersionData[] Versions { get; set; } = default!;

        ///
        [JsonProperty("rotation_grace_period")]
        public string? RotationGracePeriod { get; set; }

        ///
        public GetResult()
        {
        }
    }
}
