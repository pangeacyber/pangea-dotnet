using Newtonsoft.Json;

namespace PangeaCyber.Net.Intel
{
    ///
    public class UserBreachedBulkRequest : IntelCommonRequest<UserBreachedBulkRequest.Builder>
    {
        ///
        [JsonProperty("emails")]
        public string[]? Emails { get; set; }

        ///
        [JsonProperty("usernames")]
        public string[]? Usernames { get; set; }

        ///
        [JsonProperty("ips")]
        public string[]? Ips { get; set; }

        ///
        [JsonProperty("phone_numbers")]
        public string[]? PhoneNumbers { get; set; }

        ///
        [JsonProperty("start")]
        public string? Start { get; set; }

        ///
        [JsonProperty("end")]
        public string? End { get; set; }

        ///
        public UserBreachedBulkRequest(Builder builder) : base(builder)
        {
            Emails = builder.Emails;
            Usernames = builder.Usernames;
            Ips = builder.Ips;
            PhoneNumbers = builder.PhoneNumbers;
            Start = builder.Start;
            End = builder.End;
        }

        ///
        public class Builder : CommonBuilder
        {
            ///
            public string[]? Emails { get; set; }
            ///
            public string[]? Usernames { get; set; }
            ///
            public string[]? Ips { get; set; }
            ///
            public string[]? PhoneNumbers { get; set; }
            ///
            public string? Start { get; set; }
            ///
            public string? End { get; set; }

            ///
            public new UserBreachedBulkRequest Build()
            {
                return new UserBreachedBulkRequest(this);
            }

            ///
            public Builder WithEmails(string[] emails)
            {
                Emails = emails;
                return this;
            }

            ///
            public Builder WithUsernames(string[] usernames)
            {
                Usernames = usernames;
                return this;
            }

            ///
            public Builder WithIPs(string[] ips)
            {
                Ips = ips;
                return this;
            }

            ///
            public Builder WithPhoneNumbers(string[] phoneNumbers)
            {
                PhoneNumbers = phoneNumbers;
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
        }
    }
}
