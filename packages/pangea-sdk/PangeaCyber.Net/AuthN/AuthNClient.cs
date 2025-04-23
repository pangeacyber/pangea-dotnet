using PangeaCyber.Net.AuthN.Clients;

namespace PangeaCyber.Net.AuthN;

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
    /// <summary>Agreements</summary>
    public Agreements Agreements { get; }

    /// <summary>Client</summary>
    public Client Client { get; }

    /// <summary>Flow</summary>
    public Flow Flow { get; }

    /// <summary>Group</summary>
    public Group Group { get; }

    /// <summary>Session</summary>
    public Session Session { get; }

    /// <summary>User</summary>
    public User User { get; }

    /// <summary>Create a new <see cref="AuthNClient"/> using the given builder.</summary>
    public AuthNClient(Builder builder) : base(builder)
    {
        this.Agreements = new Agreements(builder);
        this.Client = new Client(builder);
        this.Flow = new Flow(builder);
        this.Group = new Group(builder);
        this.Session = new Session(builder);
        this.User = new User(builder);
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
