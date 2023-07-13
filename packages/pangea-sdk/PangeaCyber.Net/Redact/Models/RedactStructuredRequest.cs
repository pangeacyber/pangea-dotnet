using Newtonsoft.Json;

namespace PangeaCyber.Net.Redact
{
    /// <kind>class</kind>
    /// <summary>
    /// RedactStructuredRequest
    /// </summary>
    public class RedactStructuredRequest : BaseRequest
    {
        ///
        [JsonProperty("data")]
        public Object Data { get; private set; } = default!;

        ///
        [JsonProperty("jsonp")]
        public string[] Jsonp { get; private set; } = default!;

        ///
        [JsonProperty("format")]
        public string Format { get; private set; } = default!;

        ///
        [JsonProperty("debug")]
        public bool Debug { get; private set; } = default!;

        ///
        [JsonProperty("rules")]
        public string[] Rules { get; private set; } = default!;

        ///
        [JsonProperty("return_result")]
        public bool ReturnResult { get; private set; } = default!;

        ///
        protected RedactStructuredRequest(RedactStructuredRequestBuilder builder)
        {
            this.Data = builder.Data;
            this.Jsonp = builder.Jsonp;
            this.Format = builder.Format;
            this.Debug = builder.Debug;
            this.Rules = builder.Rules;
            this.ReturnResult = builder.ReturnResult;
        }

        /// <kind>class</kind>
        /// <summary>
        /// RedactStructuredRequestBuilder
        /// </summary>
        public class RedactStructuredRequestBuilder
        {
            ///
            public Object Data { get; private set; } = default!;

            ///
            public string[] Jsonp { get; private set; } = default!;

            ///
            public string Format { get; private set; } = default!;

            ///
            public bool Debug { get; private set; } = default!;

            ///
            public string[] Rules { get; private set; } = default!;

            ///
            public bool ReturnResult { get; private set; } = default!;

            ///
            public RedactStructuredRequestBuilder(Object data)
            {
                this.Data = data;
            }

            ///
            public RedactStructuredRequestBuilder SetJsonp(string[] jsonp)
            {
                this.Jsonp = jsonp;
                return this;
            }

            ///
            public RedactStructuredRequestBuilder SetFormat(string format)
            {
                this.Format = format;
                return this;
            }

            ///
            public RedactStructuredRequestBuilder SetDebug(bool debug)
            {
                this.Debug = debug;
                return this;
            }

            ///
            public RedactStructuredRequestBuilder SetRules(string[] rules)
            {
                this.Rules = rules;
                return this;
            }

            ///
            public RedactStructuredRequestBuilder SetReturnResult(bool returnResult)
            {
                this.ReturnResult = returnResult;
                return this;
            }

            ///
            public RedactStructuredRequest Build()
            {
                return new RedactStructuredRequest(this);
            }
        }
    }
}