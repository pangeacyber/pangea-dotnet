using Newtonsoft.Json;
using PangeaCyber.Net.Vault.Models;

namespace PangeaCyber.Net.Vault.Results
{
    ///
    public class GetResult : ItemData
    {
        ///
        [JsonProperty("versions")]
        public ItemVersionData[] Versions { get; private set; } = default!;

        ///
        [JsonProperty("rotation_grace_period")]
        public string? RotationGracePeriod { get; private set; }

        ///
        [JsonProperty("inherited_settings")]
        public InheritedSettings? InheritedSettings { get; private set; } = null;

        ///
        public GetResult()
        {
        }
    }
}
