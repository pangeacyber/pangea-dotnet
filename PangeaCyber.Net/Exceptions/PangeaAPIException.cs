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
    }
}

