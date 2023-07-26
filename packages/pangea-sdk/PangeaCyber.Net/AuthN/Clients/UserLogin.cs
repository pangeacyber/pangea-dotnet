using PangeaCyber.Net.AuthN.Models;
using PangeaCyber.Net.AuthN.Results;
using Newtonsoft.Json;

namespace PangeaCyber.Net.AuthN.Clients
{
    ///
    public class UserLogin : AuthNBaseClient
    {
        ///
        public UserLogin(AuthNClient.Builder builder) : base(builder) { }

        // TODO: Doc
        ///
        public async Task<Response<UserLoginResult>> Password(string email, string password, Profile? extraProfile = null)
        {
            var request = new UserLoginPasswordRequest(email, password, extraProfile);
            return await DoPost<UserLoginResult>("/v1/user/login/password", request);
        }

        // TODO: Doc
        ///
        public async Task<Response<UserLoginResult>> Social(IDProvider provider, string email, string socialID, Profile? extraProfile = null)
        {
            var request = new UserLoginSocialRequest(provider, email, socialID, extraProfile);
            return await DoPost<UserLoginResult>("/v1/user/login/social", request);
        }

        internal sealed class UserLoginPasswordRequest : BaseRequest
        {
            [JsonProperty("email")]
            public string Email { get; private set; }

            [JsonProperty("password")]
            public string Password { get; private set; }

            [JsonProperty("extra_profile")]
            public Profile? ExtraProfile { get; private set; }

            public UserLoginPasswordRequest(string email, string password, Profile? extraProfile)
            {
                Email = email;
                Password = password;
                ExtraProfile = extraProfile;
            }
        }

        internal sealed class UserLoginSocialRequest : BaseRequest
        {
            [JsonProperty("provider")]
            public IDProvider Provider { get; private set; }

            [JsonProperty("email")]
            public string Email { get; private set; }

            [JsonProperty("social_id")]
            public string SocialID { get; private set; }

            [JsonProperty("extra_profile")]
            public Profile? ExtraProfile { get; private set; }

            public UserLoginSocialRequest(IDProvider provider, string email, string socialID, Profile? extraProfile)
            {
                Provider = provider;
                Email = email;
                SocialID = socialID;
                ExtraProfile = extraProfile;
            }
        }

    }
}
