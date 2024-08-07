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
        [JsonProperty("rulesets")]
        public string[]? Rulesets { get; private set; }

        ///
        [JsonProperty("return_result")]
        public bool? ReturnResult { get; private set; }

        ///
        [JsonProperty("redaction_method_overrides")]
        public RedactionMethodOverrides? RedactionMethodOverrides { get; private set; }

        ///
        protected RedactTextRequest(Builder builder)
        {
            this.Text = builder.Text;
            this.Debug = builder.Debug;
            this.Rules = builder.Rules;
            this.Rulesets = builder.Rulesets;
            this.ReturnResult = builder.ReturnResult;
            this.RedactionMethodOverrides = builder.RedactionMethodOverrides;
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
            public string[]? Rulesets { get; private set; }

            ///
            public bool? ReturnResult { get; private set; }

            ///
            public RedactionMethodOverrides? RedactionMethodOverrides { get; private set; }

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
            public Builder WithRulesets(string[] rulesets)
            {
                this.Rulesets = rulesets;
                return this;
            }

            ///
            public Builder WithReturnResult(bool returnResult)
            {
                this.ReturnResult = returnResult;
                return this;
            }

            ///
            public Builder WithRedactionMethodOverrides(RedactionMethodOverrides rmo)
            {
                this.RedactionMethodOverrides = rmo;
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
