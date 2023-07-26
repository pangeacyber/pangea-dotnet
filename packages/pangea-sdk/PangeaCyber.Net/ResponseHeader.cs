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
        public string RequestId { get; set; } = default!;

        ///
        [JsonProperty("request_time")]
        public string RequestTime { get; set; } = default!;

        ///
        [JsonProperty("response_time")]
        public string ResponseTime { get; set; } = default!;

        ///
        [JsonProperty("status")]
        public string Status { get; set; } = default!;

        ///
        [JsonProperty("summary")]
        public string Summary { get; set; } = default!;

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
    }
}
