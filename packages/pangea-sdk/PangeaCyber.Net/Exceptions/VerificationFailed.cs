using System;
namespace PangeaCyber.Net.Exceptions
{
    /// <kind>class</kind>
    /// <summary>
    /// VerificationFailed
    /// </summary>
    public class VerificationFailed : AuditException
    {
        ///
        public string Hash { get; private set; }

        ///
        public VerificationFailed(string message, Exception cause, string hash) : base(message, cause)
        {
            this.Hash = hash;
        }
    }
}
