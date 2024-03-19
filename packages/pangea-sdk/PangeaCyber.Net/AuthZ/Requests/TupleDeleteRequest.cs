
using Newtonsoft.Json;

namespace PangeaCyber.Net.AuthZ.Requests
{
    /// <kind>class</kind>
    /// <summary>
    /// TupleDeleteRequest
    /// </summary>
    public class TupleDeleteRequest : BaseRequest
    {
        ///
        [JsonProperty("tuples")]
        public Models.Tuple[] Tuples { get; set; } = Array.Empty<Models.Tuple>();

        ///
        public TupleDeleteRequest(Models.Tuple[] tuples)
        {
            Tuples = tuples;
        }
    }
}
