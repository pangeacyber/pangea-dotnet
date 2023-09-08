using Newtonsoft.Json;

namespace PangeaCyber.Net.Intel
{
    ///
    public class IntelReputationDataItem : IntelReputationData
    {
        ///
        [JsonProperty("indicator")]
        public string Indicator { get; }

        ///
        public IntelReputationDataItem() : base()
        {
            Indicator = default!;
        }

    }
}
