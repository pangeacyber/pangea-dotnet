
using System;
namespace PangeaCyber.Net.Exceptions
{
    /// <kind>class</kind>
    /// <summary>
    /// ProviderErrorException
    /// </summary>
    public class ProviderErrorException : PangeaAPIException
    {
        ///
        public ProviderErrorException(string message, Response<PangeaErrors> response) : base(message, response)
        {
        }
    }
}

