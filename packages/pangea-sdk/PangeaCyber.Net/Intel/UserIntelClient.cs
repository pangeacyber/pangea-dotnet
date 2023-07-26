using PangeaCyber.Net.Exceptions;

namespace PangeaCyber.Net.Intel
{
    /// <kind>class</kind>
    /// <summary>
    /// UserIntel Client
    /// </summary>
    public class UserIntelClient : BaseClient<UserIntelClient.Builder>
    {
        private const string ServiceName = "user-intel";
        private static readonly bool SupportMultiConfig = false;

        /// Constructor
        public UserIntelClient(Builder builder)
            : base(builder, ServiceName, SupportMultiConfig)
        {
        }

        ///
        public class Builder : BaseClient<UserIntelClient.Builder>.ClientBuilder
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

        /// <kind>method</kind>
        /// <summary>Determine if an email address, username, phone number, or IP address was exposed in a security breach.</summary>
        /// <remarks>Look up breached users</remarks>
        /// <operationid>user_intel_post_v1_user_breached</operationid>
        /// <param name="request" type="PangeaCyber.Net.Intel.UserBreachedRequest">UserBreachedRequest with the user data to be looked up</param>
        /// <returns>Response&lt;UserBreachedResult&gt;</returns>
        /// <example>
        /// <code>
        /// var request = new UserBreachedRequest.Builder()
        ///     .WithPhoneNumber("8005550123")
        ///     .WithProvider("spycloud")
        ///     .Build();
        /// var response = await client.Breached(request);
        /// </code>
        /// </example>
        public Task<Response<UserBreachedResult>> Breached(UserBreachedRequest request)
        {
            return DoPost<UserBreachedResult>("/v1/user/breached", request);
        }

        /// <kind>method</kind>
        /// <summary>Determine if a password has been exposed in a security breach using a 5 character prefix of the password hash.</summary>
        /// <remarks>Look up breached passwords</remarks>
        /// <operationid>user_intel_post_v1_password_breached</operationid>
        /// <param name="request" type="PangeaCyber.Net.Intel.UserPasswordBreachedRequest">UserPasswordBreachedRequest with the password hash to be looked up</param>
        /// <returns>Response&lt;UserPasswordBreachedResult&gt;</returns>
        /// <example>
        /// <code>
        /// var request = new UserPasswordBreachedRequest.Builder(
        ///     HashType.SHA256,
        ///     "5baa6")
        ///     .WithProvider("spycloud")
        ///     .Build();
        /// var response = await client.Breached(request);
        /// </code>
        /// </example>
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
