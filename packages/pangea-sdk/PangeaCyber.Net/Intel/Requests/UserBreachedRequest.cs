using Newtonsoft.Json;

namespace PangeaCyber.Net.Intel
{
    ///
    public class UserBreachedRequest : IntelCommonRequest<UserBreachedRequest.Builder>
    {
        ///
        [JsonProperty("email")]
        public string? Email { get; set; }

        ///
        [JsonProperty("username")]
        public string? Username { get; set; }

        ///
        [JsonProperty("ip")]
        public string? Ip { get; set; }

        ///
        [JsonProperty("phone_number")]
        public string? PhoneNumber { get; set; }

        ///
        [JsonProperty("start")]
        public string? Start { get; set; }

        ///
        [JsonProperty("end")]
        public string? End { get; set; }

        /// A token given in the raw response from SpyCloud. Post this back to paginate results
        [JsonProperty("cursor")]
        public string? Cursor { get; set; }

        ///
        public UserBreachedRequest(Builder builder) : base(builder)
        {
            Email = builder.Email;
            Username = builder.Username;
            Ip = builder.IP;
            PhoneNumber = builder.PhoneNumber;
            Start = builder.Start;
            End = builder.End;
            Cursor = builder.Cursor;
        }

        ///
        public class Builder : CommonBuilder
        {
            ///
            public string? Email { get; set; }
            ///
            public string? Username { get; set; }
            ///
            public string? IP { get; set; }
            ///
            public string? PhoneNumber { get; set; }
            ///
            public string? Start { get; set; }
            ///
            public string? End { get; set; }
            ///
            public string? Cursor { get; set; }

            ///
            public new UserBreachedRequest Build()
            {
                return new UserBreachedRequest(this);
            }

            ///
            public Builder WithEmail(string email)
            {
                Email = email;
                return this;
            }

            ///
            public Builder WithUsername(string username)
            {
                Username = username;
                return this;
            }

            ///
            public Builder WithIP(string ip)
            {
                IP = ip;
                return this;
            }

            ///
            public Builder WithPhoneNumber(string phoneNumber)
            {
                PhoneNumber = phoneNumber;
                return this;
            }

            ///
            public Builder WithStart(string start)
            {
                Start = start;
                return this;
            }

            ///
            public Builder WithEnd(string end)
            {
                End = end;
                return this;
            }

            ///
            public Builder WithCursor(string cursor)
            {
                Cursor = cursor;
                return this;
            }
        }
    }
}
