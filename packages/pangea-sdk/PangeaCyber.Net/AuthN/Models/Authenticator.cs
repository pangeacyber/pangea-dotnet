using Newtonsoft.Json;

namespace PangeaCyber.Net.AuthN.Models
{
    /// <summary>
    ///
    /// </summary>
    public class Authenticator
    {
        /// <summary>
        /// Gets or sets the id property.
        /// </summary>
        [JsonProperty("id")]
        public string Id { get; private set; } = default!;

        /// <summary>
        /// Gets or sets the type property.
        /// </summary>
        [JsonProperty("type")]
        public string Type { get; private set; } = default!;

        /// <summary>
        /// Gets or sets the enable property.
        /// </summary>
        [JsonProperty("enable")]
        public bool Enable { get; private set; }

        /// <summary>
        /// Gets or sets the provider property.
        /// </summary>
        [JsonProperty("provider")]
        public string? Provider { get; private set; }

        /// <summary>
        /// Gets or sets the rpid property.
        /// </summary>
        [JsonProperty("rpid")]
        public string? Rpid { get; private set; }

        /// <summary>
        /// Gets or sets the phase property.
        /// </summary>
        [JsonProperty("phase")]
        public string? Phase { get; private set; }

        /// <summary>
        /// Default constructor for <see cref="Authenticator"/>.
        /// </summary>
        public Authenticator() { }
    }
}
