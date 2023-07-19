using System;
namespace PangeaCyber.Net.Exceptions
{
    /// <kind>class</kind>
    /// <summary>
    /// NoCreditException
    /// </summary>
    public class PangeaAPIException : Exception
    {
        ///
        public Response<PangeaErrors> Response { get; private set; }

        ///
        public PangeaAPIException(string message, Response<PangeaErrors> response) : base(message)
        {
            this.Response = response;
        }

        ///
        public new string ToString() {
            String ret = "";
            ret += "message: " + this.Message + "\n";
            ret += "summary: " + this.Response.Summary + "\n";
            ret += "request_id: " + this.Response.RequestId + "\n";
            if (this.Response.Result.Errors?.Length > 0)
            {
                ret += "Errors: \n";
                foreach (ErrorField errorField in this.Response.Result.Errors)
                {
                    ret += "\t " + errorField.Detail + "\n";
                }
            }

            return ret;
        } 
    }
}

