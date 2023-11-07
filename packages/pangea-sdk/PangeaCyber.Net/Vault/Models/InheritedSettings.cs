using Newtonsoft.Json;

namespace PangeaCyber.Net.Vault.Models
{
    ///
    public class InheritedSettings
    {
        ///
        [JsonProperty("rotation_frequency")]
        public string? RotationFrequency { get; private set; }

        ///
        [JsonProperty("rotation_state")]
        public string? RotationState { get; private set; }

        ///
        [JsonProperty("rotation_grace_period")]
        public string? RotationGracePeriod { get; private set; }

    }
}
