using Newtonsoft.Json;

namespace PangeaCyber.Net.Redact
{
    /// <kind>class</kind>
    /// <summary>
    /// RedactTextRequest
    /// </summary>
    public class RedactTextRequest
    {
        ///
        [JsonProperty("text")]
        public string Text { get; private set; } = default!;

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
        protected RedactTextRequest(RedactTextRequestBuilder builder)
        {
            this.Text = builder.Text;
            this.Debug = builder.Debug;
            this.Rules = builder.Rules;
            this.ReturnResult = builder.ReturnResult;
        }

        /// <kind>class</kind>
        /// <summary>
        /// RedactTextRequestBuilder
        /// </summary>
        public class RedactTextRequestBuilder
        {
            ///
            public string Text { get; private set; } = default!;

            ///
            public bool Debug { get; private set; } = default!;

            ///
            public string[] Rules { get; private set; } = default!;

            ///
            public bool ReturnResult { get; private set; } = default!;

            ///
            public RedactTextRequestBuilder(string text)
            {
                this.Text = text;
            }

            ///
            public RedactTextRequestBuilder SetDebug(bool debug)
            {
                this.Debug = debug;
                return this;
            }

            ///
            public RedactTextRequestBuilder SetRules(string[] rules)
            {
                this.Rules = rules;
                return this;
            }

            ///
            public RedactTextRequestBuilder SetReturnResult(bool returnResult)
            {
                this.ReturnResult = returnResult;
                return this;
            }

            ///
            public RedactTextRequest Build()
            {
                return new RedactTextRequest(this);
            }
        }
    }
}
