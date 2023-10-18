namespace PangeaCyber.Net.AuthN.Clients
{
    ///
    public class AuthNBaseClient : BaseClient<AuthNBaseClient.Builder>
    {
        ///
        public static string ServiceName { get; } = "authn";

        ///
        public AuthNBaseClient(Builder builder) : base(builder, ServiceName)
        {
        }

        ///
        public class Builder : ClientBuilder
        {

            ///
            public Builder(Config config) : base(config)
            {

            }
        }

    }
}
