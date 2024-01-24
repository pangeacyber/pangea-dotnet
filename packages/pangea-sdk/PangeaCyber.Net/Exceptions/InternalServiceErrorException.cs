using System;

namespace PangeaCyber.Net.Exceptions
{
    /// <kind>class</kind>
    /// <summary>
    /// InternalServiceErrorException
    /// </summary>
    public class InternalServiceErrorException : PangeaAPIException
    {
        ///
        public InternalServiceErrorException(string message, Response<PangeaErrors> response) : base(message, response)
        {
        }
    }
}
