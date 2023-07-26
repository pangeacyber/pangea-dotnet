using Newtonsoft.Json;
using PangeaCyber.Net.Audit;

namespace PangeaCyber.Examples
{
    [JsonObject(MemberSerialization.OptIn)]
    public class CustomEvent : IEvent
    {
        [JsonProperty("message")]
        public string Message { get; set; }

        [JsonProperty("field_int")]
        public int? FieldInt { get; set; }

        [JsonProperty("field_bool")]
        public bool? FieldBool { get; set; }

        [JsonProperty("field_str_short")]
        public string? FieldStrShort { get; set; }

        [JsonProperty("field_str_long")]
        public string? FieldStrLong { get; set; }

        [JsonProperty("field_time")]
        public string? FieldTime { get; set; }

        ///
        public CustomEvent() {
            Message = default!;
        } // Needed for JSON deserialization

        private CustomEvent(Builder builder)
        {
            Message = builder.Message;
            FieldInt = builder.FieldInt;
            FieldBool = builder.FieldBool;
            FieldStrShort = builder.FieldStrShort;
            FieldStrLong = builder.FieldStrLong;
            FieldTime = builder.FieldTime;
            TenantID = builder.TenantID;
        }

        public class Builder
        {
            public string Message { get; set; }
            public int? FieldInt { get; set; }
            public bool? FieldBool { get; set; }
            public string? FieldStrShort { get; set; }
            public string? FieldStrLong { get; set; }
            public string? FieldTime { get; set; }
            public string? TenantID { get; set; }

            public Builder(string message)
            {
                Message = message;
            }

            public Builder WithFieldInt(int? fieldInt)
            {
                FieldInt = fieldInt;
                return this;
            }

            public Builder WithFieldBool(bool? fieldBool)
            {
                FieldBool = fieldBool;
                return this;
            }

            public Builder WithFieldStrShort(string fieldStrShort)
            {
                FieldStrShort = fieldStrShort;
                return this;
            }

            public Builder WithFieldStrLong(string fieldStrLong)
            {
                FieldStrLong = fieldStrLong;
                return this;
            }

            public Builder WithFieldTime(string fieldTime)
            {
                FieldTime = fieldTime;
                return this;
            }

            public Builder WithTenantID(string tenantID)
            {
                TenantID = tenantID;
                return this;
            }

            public CustomEvent Build()
            {
                return new CustomEvent(this);
            }
        }
    }
}
