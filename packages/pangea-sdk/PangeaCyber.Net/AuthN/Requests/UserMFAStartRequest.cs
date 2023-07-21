using Newtonsoft.Json;

namespace PangeaCyber.Net.AuthN
{
    ///
    public class UserMFAStartRequest : BaseRequest
    {
        ///
        [JsonProperty("user_id")]
        public string UserID { get; private set; }

        ///
        [JsonProperty("mfa_provider")]
        public MFAProvider MFAProvider { get; private set; }

        ///
        [JsonProperty("enroll")]
        public bool? Enroll { get; private set; }

        ///
        [JsonProperty("phone")]
        public string? Phone { get; private set; }

        ///
        private UserMFAStartRequest(Builder builder)
        {
            this.UserID = builder.UserID;
            this.MFAProvider = builder.MFAProvider;
            this.Enroll = builder.Enroll;
            this.Phone = builder.Phone;
        }

        ///
        public class Builder
        {
            ///
            public string UserID { get; private set; }
            ///
            public MFAProvider MFAProvider { get; private set; }
            ///
            public bool? Enroll { get; private set; }
            ///
            public string? Phone { get; private set; }

            ///
            public Builder(string userID, MFAProvider mfaProvider)
            {
                this.UserID = userID;
                this.MFAProvider = mfaProvider;
            }

            ///
            public Builder WithEnroll(bool enroll)
            {
                this.Enroll = enroll;
                return this;
            }

            ///
            public Builder WithPhone(string phone)
            {
                this.Phone = phone;
                return this;
            }

            ///
            public UserMFAStartRequest Build()
            {
                return new UserMFAStartRequest(this);
            }
        }
    }
}
