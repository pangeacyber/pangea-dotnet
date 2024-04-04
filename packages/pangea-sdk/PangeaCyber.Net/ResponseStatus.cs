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

        /// <summary>The request has not yet completed. The result can be fetched from the async response endpoint when it is ready.</summary>
        Accepted,

        /// <summary>The URL passed in the request did not resolve to an existing resource.</summary>
        NotFound
    }
}
