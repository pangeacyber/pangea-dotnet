using System;

namespace PangeaCyber.Net.Exceptions
{
    /// <kind>class</kind>
    /// <summary>
    /// ServiceNotAvailableException
    /// </summary>
    public class ServiceNotAvailableException : PangeaAPIException
    {
        ///
        public ServiceNotAvailableException(string message, Response<PangeaErrors> response) : base(message, response)
        {
        }
    }
}
