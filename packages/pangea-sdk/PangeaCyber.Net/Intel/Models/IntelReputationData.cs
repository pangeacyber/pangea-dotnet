using Newtonsoft.Json;

namespace PangeaCyber.Net.Intel
{
    ///
    public class IntelReputationData
    {
        ///
        [JsonProperty("category")]
        public string[] Category { get; set; }

        ///
        [JsonProperty("score")]
        public int Score { get; set; }

        ///
        [JsonProperty("verdict")]
        public string Verdict { get; set; }

        ///
        public IntelReputationData()
        {
            Category = new string[] { };
            Verdict = default!;
        }

    }
}
