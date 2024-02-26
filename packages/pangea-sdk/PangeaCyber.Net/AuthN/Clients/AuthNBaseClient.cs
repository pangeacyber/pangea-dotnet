namespace PangeaCyber.Net.AuthN.Clients
{
    /// <kind>class</kind>
    /// <summary>
    /// AuthN Client
    /// </summary>
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
