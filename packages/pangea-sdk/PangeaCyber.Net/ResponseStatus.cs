using System;
using static System.Net.Mime.MediaTypeNames;
using System.Runtime.InteropServices;

namespace PangeaCyber.Net
{
    /// <kind>enum</kind>
    /// <summary>
    /// ResponseStatus
    /// </summary>
    public enum ResponseStatus
    {
        ///
        Success,
        ///
        Failed,
        ///
        ValidationError,
        ///
        TooManyRequests,
        ///
        NoCredit,
        ///
        Unauthorized,
        ///
        ServiceNotEnabled,
        ///
        ProviderError,
        ///
        MissingConfigID,
        ///
        MissingConfigIDScope,
        ///
        ServiceNotAvailable,
        ///
        TreeNotFound,
        ///
        IPNotFound,
        /// 
        Accepted
    }
}
