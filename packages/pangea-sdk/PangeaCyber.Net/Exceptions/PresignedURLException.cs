namespace PangeaCyber.Net.Exceptions
{
    /// <kind>class</kind>
    /// <summary>
    /// ParseResultFailed
    /// </summary>
    public class PresignedURLException : PangeaException
    {
        ///
        public string? Body { get; private set; }

        ///
        public PresignedURLException(string message, Exception? cause, string? body) : base(message, cause)
        {
            Body = body;
        }
    }
}
