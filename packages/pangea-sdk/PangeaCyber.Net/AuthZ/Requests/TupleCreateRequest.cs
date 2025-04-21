
using Newtonsoft.Json;

namespace PangeaCyber.Net.AuthZ.Requests;

/// <kind>class</kind>
/// <summary>
/// TupleCreateRequest
/// </summary>
public sealed class TupleCreateRequest : BaseRequest
{
    ///
    [JsonProperty("tuples")]
    public Models.Tuple[] Tuples { get; set; } = Array.Empty<Models.Tuple>();

    ///
    public TupleCreateRequest(Models.Tuple[] tuples)
    {
        Tuples = tuples;
    }

}
