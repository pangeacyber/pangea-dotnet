using Newtonsoft.Json;

namespace PangeaCyber.Net
{
    /// <kind>class</kind>
    /// <summary>
    /// ResponseHeader
    /// </summary>
    public class Response<ResultType> : ResponseHeader
    {
        ///
        [JsonProperty("result")]
        public ResultType Result { get; set; } = default!;

        ///
        public HttpResponseMessage HttpResponse { get; set; } = default!;

        ///
        public Response()
        {
        }
    }
}
