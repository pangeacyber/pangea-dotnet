using Newtonsoft.Json;

namespace PangeaCyber.Net.Redact
{
    /// <kind>class</kind>
    /// <summary>
    /// RedactStructuredRequest
    /// </summary>
    public class RedactStructuredRequest : BaseRequest
    {
        /// <summary>Structured data to redact</summary>
        [JsonProperty("data")]
        public object Data { get; set; }

        /// <summary>
        /// JSON path(s) used to identify the specific JSON fields to redact in the structured data. Note: If jsonp
        /// parameter is used, the data parameter must be in JSON format.
        /// </summary>
        [JsonProperty("jsonp")]
        public string[]? Jsonp { get; set; }

        /// <summary>The format of the structured data to redact</summary>
        [JsonProperty("format")]
        public string? Format { get; set; }

        /// <summary>
        /// Setting this value to true will provide a detailed analysis of the redacted data and the rules that caused
        /// redaction
        /// </summary>
        [JsonProperty("debug")]
        public bool? Debug { get; set; }

        /// <summary>An array of redact rule short names</summary>
        [JsonProperty("rules")]
        public string[]? Rules { get; set; }

        /// <summary>An array of redact ruleset short names</summary>
        [JsonProperty("rulesets")]
        public string[]? Rulesets { get; set; }

        /// <summary>Setting this value to false will omit the redacted result only returning count</summary>
        [JsonProperty("return_result")]
        public bool? ReturnResult { get; set; }

        /// <summary>
        /// This field allows users to specify the redaction method per rule and its various parameters.
        /// </summary>
        [JsonProperty("redaction_method_overrides")]
        public IDictionary<string, RedactionMethodOverrides>? RedactionMethodOverrides { get; set; }

        /// <summary>
        /// Is this redact call going to be used in an LLM request?
        /// </summary>
        [JsonProperty("llm_request")]
        public bool? LLMRequest { get; set; }

        ///
        [JsonProperty("vault_parameters")]
        public VaultParameters? VaultParameters { get; set; }

        /// <summary>Constructor.</summary>
        public RedactStructuredRequest(object data)
        {
            this.Data = data ?? throw new ArgumentNullException(nameof(data));
        }
    }
}
