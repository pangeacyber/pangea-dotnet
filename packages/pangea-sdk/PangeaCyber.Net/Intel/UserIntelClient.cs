using PangeaCyber.Net.Exceptions;

namespace PangeaCyber.Net.Intel
{
    ///
    public class UserIntelClient : Client
    {
        private const string ServiceName = "user-intel";
        private static readonly bool SupportMultiConfig = false;

        ///
        public UserIntelClient(Builder builder)
            : base(builder, ServiceName, SupportMultiConfig)
        {
        }

        ///
        public class Builder : Client.ClientBuilder
        {
            ///
            public Builder(Config config)
                : base(config)
            {
            }

            ///
            public UserIntelClient Build()
            {
                return new UserIntelClient(this);
            }
        }

        ///
        public Task<Response<UserBreachedResult>> Breached(UserBreachedRequest request)
        {
            return DoPost<UserBreachedResult>("/v1/user/breached", request);
        }

        ///
        public Task<Response<UserPasswordBreachedResult>> Breached(UserPasswordBreachedRequest request)
        {
            return DoPost<UserPasswordBreachedResult>("/v1/password/breached", request);
        }

        ///
        public static PasswordStatus IsPasswordBreached(UserPasswordBreachedResult result, string hash)
        {
            Dictionary<string, object>? rawData = result.RawData;
            if (rawData == null)
            {
                throw new PangeaException("Need raw data to check if hash is breached. Send request with raw=true", null);
            }

            object hashData;
            if (rawData.TryGetValue(hash, out hashData!))
            {
                // If hash is present in raw data, it's because it was breached
                return PasswordStatus.Breached;
            }
            else if (rawData.Count >= 1000)
            {
                // If it's not present, should check if I have all breached hash
                // Server will return a maximum of 1000 hash, so if breached count is greater than that,
                // I can't conclude if the password is breached or not
                return PasswordStatus.Inconclusive;
            }
            else
            {
                return PasswordStatus.Unbreached;
            }
        }
    }
}
