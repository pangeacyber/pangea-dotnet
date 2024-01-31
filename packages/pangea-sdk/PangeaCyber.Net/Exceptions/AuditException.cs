using System;

namespace PangeaCyber.Net.Exceptions
{
    /// <kind>class</kind>
    /// <summary>
    /// AuditException
    /// </summary>
    public class AuditException : PangeaException
    {
        ///
        public AuditException(string message, Exception cause) : base(message, cause)
        {
        }
    }
}
