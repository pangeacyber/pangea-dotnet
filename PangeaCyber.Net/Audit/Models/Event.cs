using Newtonsoft.Json;

namespace PangeaCyber.Net.Audit
{
    /// <kind>class</kind>
    /// <summary>
    /// Event
    /// </summary>
    public class Event
    {
        ///
        [JsonProperty("actor")]
        public string Actor { get; set; } = default!;

        ///
        [JsonProperty("action")]
        public string Action { get; set; } = default!;

        ///
        [JsonProperty("message", Required = Required.Always)]
        public string Message { get; set; } = default!;

        ///
        [JsonProperty("new")]
        public string NewField { get; set; } = default!;

        ///
        [JsonProperty("old")]
        public string Old { get; set; } = default!;

        ///
        [JsonProperty("source")]
        public string Source { get; set; } = default!;

        ///
        [JsonProperty("status")]
        public string Status { get; set; } = default!;

        ///
        [JsonProperty("target")]
        public string Target { get; set; } = default!;

        ///
        [JsonProperty("timestamp")]
        public string Timestamp { get; set; } = default!;

        ///
        [JsonProperty("tenant_id")]
        public string TenantID { get; set; } = default!;

        ///
        public Event()
        {
        }

        ///
        public Event(string message)
        {
            this.Message = message;
        }

        ///
        public Event(string actor, string action, string message, string newField, string old, string source, string status,
            string target, string timestamp)
        {
            this.Actor = actor;
            this.Action = action;
            this.Message = message;
            this.NewField = newField;
            this.Old = old;
            this.Source = source;
            this.Status = status;
            this.Target = target;
            this.Timestamp = timestamp;
        }

        ///
        public static string Canonicalize(Event evt)
        {
            return JsonConvert.SerializeObject(evt, Formatting.None, new JsonSerializerSettings { ContractResolver = new OrderedContractResolver() });
        }
    }
}
