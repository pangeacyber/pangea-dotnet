using System;

namespace PangeaCyber.Net.Exceptions
{
    /// <kind>class</kind>
    /// <summary>
    /// ParseResultFailed
    /// </summary>
    public class ParseResultFailed : PangeaException
    {
        ///
        public ResponseHeader Header { get; private set; }

        ///
        public string Body { get; private set; }

        ///
        public ParseResultFailed(string message, Exception cause, ResponseHeader header, string body) : base(message, cause)
        {
            Header = header;
            Body = body;
        }
    }
}
