using Newtonsoft.Json;

namespace PangeaCyber.Net.Intel
{
    ///
    public class DomainReputationDataItem : DomainReputationData
    {
        ///
        [JsonProperty("indicator")]
        public string Indicator { get; }

        ///
        public DomainReputationDataItem() : base()
        {
            Indicator = default!;
        }

    }
}
