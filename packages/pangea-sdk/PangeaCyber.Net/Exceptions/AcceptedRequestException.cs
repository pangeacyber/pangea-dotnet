
namespace PangeaCyber.Net.Exceptions{

    ///
    public class AcceptedRequestException : PangeaAPIException
    {
        ///
        public string RequestID { get; }

        ///
        public AcceptedRequestException(string message, Response<PangeaErrors> response) : base(message, response)
        {
            RequestID = response.RequestId;
        }
    }
}
