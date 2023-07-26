using Newtonsoft.Json;

namespace PangeaCyber.Net.AuthN.Requests
{
    ///
    public class ClientSessionRefreshRequest : BaseRequest
    {
        ///
        [JsonProperty("refresh_token")]
        public string RefreshToken { get; private set; }

        ///
        [JsonProperty("user_token")]
        public string? UserToken { get; private set; }

        ///
        protected ClientSessionRefreshRequest(Builder builder)
        {
            RefreshToken = builder.RefreshToken;
            UserToken = builder.UserToken;
        }

        ///
        public class Builder
        {
            ///
            public string RefreshToken { get; private set; } = default!;
            ///
            public string? UserToken { get; private set; }

            /// Set the refresh token for the request
            public Builder(string refreshToken)
            {
                RefreshToken = refreshToken;
            }

            /// Set the user token for the request.
            public Builder WithUserToken(string userToken)
            {
                UserToken = userToken;
                return this;
            }

            /// Build the ClientSessionRefreshRequest instance.
            public ClientSessionRefreshRequest Build()
            {
                return new ClientSessionRefreshRequest(this);
            }
        }
    }
}
