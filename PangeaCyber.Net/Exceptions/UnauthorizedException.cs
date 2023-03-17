
using System;
namespace PangeaCyber.Net.Exceptions
{
    /// <kind>class</kind>
    /// <summary>
    /// UnauthorizedException
    /// </summary>
    public class UnauthorizedException : PangeaAPIException
    {
        ///
        public UnauthorizedException(string message, Response<PangeaErrors> response) : base(message, response)
        {
        }
    }
}

