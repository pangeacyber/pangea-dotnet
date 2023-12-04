using Newtonsoft.Json;

namespace PangeaCyber.Net.Exceptions
{

    ///
    public class AcceptedRequestException : PangeaAPIException
    {
        ///
        public string RequestID { get; }

        ///
        public AcceptedResult AcceptedResult { get; private set; } = new AcceptedResult();

        ///
        protected AcceptedRequestException(string message, Response<PangeaErrors> response) : base(message, response)
        {
            RequestID = response.RequestId;
        }

        /// This Factory method is needed due to async read of the body
        public static async Task<AcceptedRequestException> Create(string message, Response<PangeaErrors> response)
        {
            var resultResponse = JsonConvert.DeserializeObject<Response<AcceptedResult>>(await response.HttpResponse.Content.ReadAsStringAsync()) ?? default!;
            var ae = new AcceptedRequestException(message, response)
            {
                AcceptedResult = resultResponse.Result
            };
            return ae;
        }

    }
}
