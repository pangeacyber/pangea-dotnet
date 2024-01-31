using System;

namespace PangeaCyber.Net.Exceptions
{
    /// <kind>class</kind>
    /// <summary>
    /// RateLimitException
    /// </summary>
    public class RateLimitException : PangeaAPIException
    {
        ///
        public RateLimitException(string message, Response<PangeaErrors> response) : base(message, response)
        {
        }
    }
}
