using System;
namespace PangeaCyber.Net.Exceptions
{
    /// <kind>class</kind>
    /// <summary>
    /// ValidationException
    /// </summary>
    public class ValidationException : PangeaAPIException
    {
        ///
        public ValidationException(string message, Response<PangeaErrors> response) : base(message, response)
        {
        }
    }
}
