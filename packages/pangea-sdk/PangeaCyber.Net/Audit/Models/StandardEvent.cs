using Newtonsoft.Json;

namespace PangeaCyber.Net.Audit
{
    /// <kind>class</kind>
    /// <summary>
    /// Event
    /// </summary>
    public class StandardEvent : IEvent
    {
        ///
        [JsonProperty("actor")]
        public string? Actor { get; set; }

        ///
        [JsonProperty("action")]
        public string? Action { get; set; }

        ///
        [JsonProperty("message", Required = Required.Always)]
        public string Message { get; set; }

        ///
        [JsonProperty("new")]
        public string? NewField { get; set; }

        ///
        [JsonProperty("old")]
        public string? Old { get; set; }

        ///
        [JsonProperty("source")]
        public string? Source { get; set; }

        ///
        [JsonProperty("status")]
        public string? Status { get; set; }

        ///
        [JsonProperty("target")]
        public string? Target { get; set; }

        ///
        [JsonProperty("timestamp")]
        public string? Timestamp { get; set; }

        ///
        private StandardEvent(Builder builder)
        {
            Actor = builder.Actor;
            Action = builder.Action;
            Message = builder.Message;
            NewField = builder.NewField;
            Old = builder.Old;
            Source = builder.Source;
            Status = builder.Status;
            Target = builder.Target;
            Timestamp = builder.Timestamp;
            TenantID = builder.TenantID;
        }

        ///
        public StandardEvent(string message)
        {
            Message = message;
        }

        ///
        public class Builder
        {
            ///
            public string? Actor { get; private set; } = null;

            ///
            public string? Action { get; private set; } = null;

            ///
            public string Message { get; private set; }

            ///
            public string? NewField { get; private set; } = null;

            ///
            public string? Old { get; private set; } = null;

            ///
            public string? Source { get; private set; } = null;

            ///
            public string? Status { get; private set; } = null;

            ///
            public string? Target { get; private set; } = null;

            ///
            public string? Timestamp { get; private set; } = null;

            ///
            public string? TenantID { get; private set; } = null;

            ///
            public Builder(string Message)
            {
                this.Message = Message;
            }

            ///
            public Builder WithActor(string actor)
            {
                Actor = actor;
                return this;
            }

            ///
            public Builder WithAction(string action)
            {
                Action = action;
                return this;
            }

            ///
            public Builder WithNewField(string newField)
            {
                NewField = newField;
                return this;
            }

            ///
            public Builder WithOld(string old)
            {
                Old = old;
                return this;
            }

            ///
            public Builder WithSource(string source)
            {
                Source = source;
                return this;
            }

            ///
            public Builder WithStatus(string status)
            {
                Status = status;
                return this;
            }

            ///
            public Builder WithTarget(string target)
            {
                Target = target;
                return this;
            }

            ///
            public Builder WithTimestamp(string timestamp)
            {
                Timestamp = timestamp;
                return this;
            }

            ///
            public Builder WithTenantID(string tenantID)
            {
                TenantID = tenantID;
                return this;
            }

            ///
            public StandardEvent Build()
            {
                return new StandardEvent(this);
            }
        }

    }
}
