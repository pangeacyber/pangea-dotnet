using Newtonsoft.Json;

namespace PangeaCyber.Net.Vault.Models
{
    ///
    public class InheritedSettings
    {
        ///
        [JsonProperty("rotation_frequency")]
        public bool RotationFrequency { get; private set;}

        ///
        [JsonProperty("rotation_state")]
        public bool RotationState { get; private set;}

        ///
        [JsonProperty("rotation_grace_period")]
        public bool RotationGracePeriod { get; private set;}

    }
}
