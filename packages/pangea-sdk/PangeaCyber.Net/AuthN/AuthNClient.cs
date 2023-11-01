using PangeaCyber.Net.AuthN.Clients;

namespace PangeaCyber.Net.AuthN
{
    /// <kind>class</kind>
    /// <summary>
    /// AuthN Client
    /// </summary>
    public class AuthNClient : AuthNBaseClient
    {
        ///
        public User User { get; private set; }

        ///
        public Flow Flow { get; private set; }

        ///
        public Client Client { get; private set; }

        ///
        public Session Session { get; private set; }

        ///
        public Agreements Agreements { get; private set; }

        ///
        public AuthNClient(Builder builder) : base(builder)
        {
            User = new User(builder);
            Flow = new Flow(builder);
            Client = new Client(builder);
            Session = new Session(builder);
            Agreements = new Agreements(builder);
        }

        ///
        public new class Builder : AuthNBaseClient.Builder
        {
            ///
            public Builder(Config config) : base(config)
            {
            }

            ///
            public AuthNClient Build()
            {
                return new AuthNClient(this);
            }
        }
    }
}
