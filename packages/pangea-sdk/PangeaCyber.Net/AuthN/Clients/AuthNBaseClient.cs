namespace PangeaCyber.Net.AuthN.Clients
{
    ///
    public class AuthNBaseClient : BaseClient<AuthNBaseClient.Builder>
    {
        ///
        public static string ServiceName {get; }= "authn";

        ///
        protected const bool supportMultiConfig = false;

        ///
        public AuthNBaseClient(AuthNBaseClient.Builder builder) : base(builder, ServiceName, supportMultiConfig)
        {
        }

        ///
        public class Builder : BaseClient<AuthNBaseClient.Builder>.ClientBuilder {

            ///
            public Builder(Config config) : base(config){

            }
        }

    }
}
