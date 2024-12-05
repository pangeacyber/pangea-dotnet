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
        public Object Data { get; private set; }

        ///
        [JsonProperty("jsonp")]
        public string[]? Jsonp { get; private set; }

        ///
        [JsonProperty("format")]
        public string? Format { get; private set; }

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

        /// <summary>
        /// Is this redact call going to be used in an LLM request?
        /// </summary>
        [JsonProperty("llm_request")]
        public bool? LLMrequest { get; private set; }

        ///
        [JsonProperty("vault_parameters")]
        public VaultParameters? VaultParameters { get; private set; }

        ///
        protected RedactStructuredRequest(Builder builder)
        {
            this.Data = builder.Data;
            this.Jsonp = builder.Jsonp;
            this.Format = builder.Format;
            this.Debug = builder.Debug;
            this.Rules = builder.Rules;
            this.Rulesets = builder.Rulesets;
            this.ReturnResult = builder.ReturnResult;
            this.RedactionMethodOverrides = builder.RedactionMethodOverrides;
            this.LLMrequest = builder.LLMrequest;
            this.VaultParameters = builder.VaultParameters;
        }

        /// <kind>class</kind>
        /// <summary>
        /// RedactStructuredRequestBuilder
        /// </summary>
        public class Builder
        {
            ///
            public Object Data { get; private set; }

            ///
            public string[]? Jsonp { get; private set; } = null;

            ///
            public string? Format { get; private set; } = null;

            ///
            public bool? Debug { get; private set; } = null;

            ///
            public string[]? Rules { get; private set; } = null;

            ///
            public string[]? Rulesets { get; private set; } = null;

            ///
            public bool? ReturnResult { get; private set; } = null;

            ///
            public RedactionMethodOverrides? RedactionMethodOverrides { get; private set; }

            ///
            public bool? LLMrequest { get; private set; } = null;

            ///
            public VaultParameters? VaultParameters { get; private set; } = null;

            ///
            public Builder(Object data)
            {
                this.Data = data;
            }

            ///
            public Builder WithJsonp(string[] jsonp)
            {
                this.Jsonp = jsonp;
                return this;
            }

            ///
            public Builder WithFormat(string format)
            {
                this.Format = format;
                return this;
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
            public Builder WithLLMrequest(bool llmRequest)
            {
                this.LLMrequest = llmRequest;
                return this;
            }

            ///
            public Builder WithVaultParameters(VaultParameters vaultParameters)
            {
                this.VaultParameters = vaultParameters;
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
