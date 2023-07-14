using Newtonsoft.Json;

namespace PangeaCyber.Net.Redact
{
    /// <kind>class</kind>
    /// <summary>
    /// RedactTextRequest
    /// </summary>
    public class RedactTextRequest : BaseRequest
    {
        ///
        [JsonProperty("text")]
        public string Text { get; private set; }

        ///
        [JsonProperty("debug")]
        public bool? Debug { get; private set; }

        ///
        [JsonProperty("rules")]
        public string[]? Rules { get; private set; }

        ///
        [JsonProperty("return_result")]
        public bool? ReturnResult { get; private set; }

        ///
        protected RedactTextRequest(Builder builder)
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
        public class Builder
        {
            ///
            public string Text { get; private set; }

            ///
            public bool? Debug { get; private set; }

            ///
            public string[]? Rules { get; private set; }

            ///
            public bool? ReturnResult { get; private set; }

            ///
            public Builder(string text)
            {
                this.Text = text;
            }

            ///
            public Builder WithDebug(bool debug)
            {
                this.Debug = debug;
                return this;
            }

            ///
            public Builder WithRules(string[] rules)
            {
                this.Rules = rules;
                return this;
            }

            ///
            public Builder WithReturnResult(bool returnResult)
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
