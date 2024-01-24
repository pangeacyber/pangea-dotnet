using System;
using Newtonsoft.Json;

namespace PangeaCyber.Net
{
    /// <kind>class</kind>
    /// <summary>
    /// ResponseHeader
    /// </summary>
    public class ResponseHeader
    {
        ///
        [JsonProperty("request_id")]
        public string RequestId { get; private set; } = default!;

        ///
        [JsonProperty("request_time")]
        public string RequestTime { get; private set; } = default!;

        ///
        [JsonProperty("response_time")]
        public string ResponseTime { get; private set; } = default!;

        ///
        [JsonProperty("status")]
        public string Status { get; private set; } = default!;

        ///
        [JsonProperty("summary")]
        public string Summary { get; private set; } = default!;

        ///
        public Boolean IsOK
        {
            get
            {
                return this.Status.Equals(ResponseStatus.Success.ToString());
            }
        }

        ///
        public ResponseHeader()
        {
        }

        ///
        protected ResponseHeader(ResponseHeader header)
        {
            Summary = header.Summary;
            Status = header.Status;
            RequestId = header.RequestId;
            RequestTime = header.RequestTime;
            ResponseTime = header.ResponseTime;
        }
    }
}
