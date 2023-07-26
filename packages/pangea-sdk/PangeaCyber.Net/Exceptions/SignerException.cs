using System;

namespace PangeaCyber.Net.Exceptions
{
    /// <kind>class</kind>
    /// <summary>
    /// SignerException
    /// </summary>
    public class SignerException : PangeaException
    {
        ///
        public SignerException(string message, Exception cause) : base(message, cause)
        {

        }
    }
}
