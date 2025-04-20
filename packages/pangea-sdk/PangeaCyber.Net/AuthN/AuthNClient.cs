using PangeaCyber.Net.AuthN.Clients;

namespace PangeaCyber.Net.AuthN
{
    /// <summary>AuthN client.</summary>
    /// <remarks>AuthN</remarks>
    /// <example>
    /// <code>
    /// var config = new Config("pangea_token");
    /// var builder = new AuthNClient.Builder(config);
    /// var client = builder.Build();
    /// </code>
    /// </example>
    public class AuthNClient : AuthNBaseClient
    {
        ///
        public User User { get; }

        ///
        public Flow Flow { get; }

        ///
        public Client Client { get; }

        ///
        public Session Session { get; }

        ///
        public Agreements Agreements { get; }

        /// <summary>Create a new <see cref="AuthNClient"/> using the given builder.</summary>
        public AuthNClient(Builder builder) : base(builder)
        {
            User = new User(builder);
            Flow = new Flow(builder);
            Client = new Client(builder);
            Session = new Session(builder);
            Agreements = new Agreements(builder);
        }

        /// <summary><see cref="AuthNClient"/> builder.</summary>
        public new class Builder : AuthNBaseClient.Builder
        {
            /// <summary>Create a new <see cref="AuthNClient"/> builder.</summary>
            public Builder(Config config) : base(config)
            {
            }

            /// <summary>Build an <see cref="AuthNClient"/>.</summary>
            public AuthNClient Build()
            {
                return new AuthNClient(this);
            }
        }
    }
}
