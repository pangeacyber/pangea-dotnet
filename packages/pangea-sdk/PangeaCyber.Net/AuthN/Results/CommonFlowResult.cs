using Newtonsoft.Json;
using PangeaCyber.Net.AuthN.Models;

namespace PangeaCyber.Net.AuthN.Results
{
    /// <summary>
    ///
    /// </summary>
    public class CommonFlowResult
    {
        ///
        [JsonProperty("flow_id")]
        public string FlowID { get; private set; } = default!;

        ///
        [JsonProperty("flow_type")]
        public string[]? FlowType { get; private set; }

        ///
        [JsonProperty("email")]
        public string? Email { get; private set; }

        ///
        [JsonProperty("disclaimer")]
        public string? Disclaimer { get; private set; }

        ///
        [JsonProperty("flow_phase")]
        public string? FlowPhase { get; private set; }

        ///
        [JsonProperty("flow_choices")]
        public FlowChoiceItem[]? FlowChoices { get; private set; }
    }

}
