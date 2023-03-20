using Newtonsoft.Json;

namespace PangeaCyber.Net.Audit
{
    /// <kind>class</kind>
    /// <summary>
    /// ResultsRequest
    /// </summary>
    public sealed class ResultsRequest
    {
        ///
        [JsonProperty("id")]
        string ID = default!;

        ///
        [JsonProperty("limit")]
        int Limit = 20;

        ///
        [JsonProperty("offset")]
        int Offset = default!;

        ///
        public ResultsRequest(string id, int limit, int offset)
        {
            this.ID = id;
            this.Limit = limit;
            this.Offset = offset;
        }
    }
}

