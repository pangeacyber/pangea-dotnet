using Newtonsoft.Json;
using PangeaCyber.Net.Exceptions;
using System.Net.Http;

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
        public ResultType Result { get; private set; } = default!;

        ///
        public AcceptedResult? AcceptedResult { get; private set; } = null;

        ///
        public HttpResponseMessage HttpResponse { get; set; } = default!;

        ///
        public List<AttachedFile> AttachedFiles = new();

        ///
        public Response()
        {
        }

        ///
        public Response(Response<PangeaErrors> response, AcceptedResult acceptedResult) : base(response)
        {
            AcceptedResult = acceptedResult;
            HttpResponse = response.HttpResponse;
        }
    }
}
