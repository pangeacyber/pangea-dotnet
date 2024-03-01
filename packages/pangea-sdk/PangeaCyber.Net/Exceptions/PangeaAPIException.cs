namespace PangeaCyber.Net.Exceptions
{
    /// <kind>class</kind>
    /// <summary>
    /// Pangea API exception.
    /// </summary>
    public class PangeaAPIException : Exception
    {
        ///
        public Response<PangeaErrors> Response { get; }

        ///
        public PangeaAPIException(string message, Response<PangeaErrors> response) : base(message)
        {
            Response = response;
        }

        ///
        public new string ToString()
        {
            string ret = "";
            ret += "message: " + Message + "\n";
            ret += "summary: " + Response.Summary + "\n";
            ret += "status: " + Response.Status + "\n";
            ret += "request_id: " + Response.RequestId + "\n";
            ret += "request_time: " + Response.RequestTime + "\n";
            ret += "response_time: " + Response.ResponseTime + "\n";
            if (Response.Result.Errors?.Length > 0)
            {
                ret += "Errors: \n";
                foreach (ErrorField errorField in Response.Result.Errors)
                {
                    ret += "\t" + errorField + "\n";
                }
            }

            return ret;
        }
    }
}
