using System;

namespace PangeaCyber.Net.Exceptions
{
    /// <kind>class</kind>
    /// <summary>
    /// PangeaException
    /// </summary>
    public class PangeaException : Exception
    {
        ///
        public Exception Cause { get; private set; }

        ///
        public PangeaException(string message, Exception cause) : base(message)
        {
            this.Cause = cause;
        }
    }
}