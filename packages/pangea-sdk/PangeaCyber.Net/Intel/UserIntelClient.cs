using PangeaCyber.Net.Exceptions;

namespace PangeaCyber.Net.Intel
{
    /// <summary>User Intel client.</summary>
    /// <remarks>User Intel</remarks>
    /// <example>
    /// <code>
    /// var config = new Config("pangea_token", "pangea_domain");
    /// var builder = new UserIntelClient.Builder(config);
    /// var client = builder.Build();
    /// </code>
    /// </example>
    public class UserIntelClient : BaseClient<UserIntelClient.Builder>
    {
        ///
        public static string ServiceName { get; } = "user-intel";

        /// <summary>Create a new <see cref="UserIntelClient"/> using the given builder.</summary>
        public UserIntelClient(Builder builder)
            : base(builder, ServiceName)
        {
        }

        /// <summary><see cref="UserIntelClient"/> builder.</summary>
        public class Builder : ClientBuilder
        {
            /// <summary>Create a new <see cref="UserIntelClient"/> builder.</summary>
            public Builder(Config config)
                : base(config)
            {
            }

            /// <summary>Build an <see cref="UserIntelClient"/>.</summary>
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
        /// <summary>Determine if an email address, username, phone number, or IP address was exposed in a security breach.</summary>
        /// <remarks>Look up breached users V2</remarks>
        /// <operationid>user_intel_post_v2_user_breached</operationid>
        /// <param name="request" type="PangeaCyber.Net.Intel.UserBreachedBulkRequest">UserBreachedBulkRequest with the user data to be looked up</param>
        /// <returns>Response&lt;UserBreachedBulkResult&gt;</returns>
        /// <example>
        /// <code>
        /// string[] phoneNumbers = new string[1] {"8005550123"};
        /// var request = new UserBreachedBulkRequest.Builder()
        ///     .WithPhoneNumbers(phoneNumbers)
        ///     .WithProvider("spycloud")
        ///     .Build();
        /// var response = await client.BreachedBulk(request);
        /// </code>
        /// </example>
        public Task<Response<UserBreachedBulkResult>> BreachedBulk(UserBreachedBulkRequest request)
        {
            return DoPost<UserBreachedBulkResult>("/v2/user/breached", request);
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

        /// <kind>method</kind>
        /// <summary>Determine if a password has been exposed in a security breach using a 5 character prefix of the password hash.</summary>
        /// <remarks>Look up breached passwords V2</remarks>
        /// <operationid>user_intel_post_v2_password_breached</operationid>
        /// <param name="request" type="PangeaCyber.Net.Intel.UserPasswordBreachedBulkRequest">UserPasswordBreachedBulkRequest with the password hash to be looked up</param>
        /// <returns>Response&lt;UserPasswordBreachedBulkResult&gt;</returns>
        /// <example>
        /// <code>
        /// string[] hashPrefixes = new string[1] {"5baa6"};
        /// var request = new UserPasswordBreachedBulkRequest.Builder(
        ///     HashType.SHA256,
        ///     hashPrefixes)
        ///     .WithProvider("spycloud")
        ///     .Build();
        /// var response = await client.BreachedBulk(request);
        /// </code>
        /// </example>
        public Task<Response<UserPasswordBreachedBulkResult>> BreachedBulk(UserPasswordBreachedBulkRequest request)
        {
            return DoPost<UserPasswordBreachedBulkResult>("/v2/password/breached", request);
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
