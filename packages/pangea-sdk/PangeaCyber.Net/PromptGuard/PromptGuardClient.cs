using PangeaCyber.Net.PromptGuard.Requests;
using PangeaCyber.Net.PromptGuard.Results;

namespace PangeaCyber.Net.PromptGuard;

/// <summary>Data Guard API client.</summary>
/// <remarks>Data Guard</remarks>
/// <example>
/// <code>
/// var config = new Config("pangea_token", "pangea_domain");
/// var builder = new DataGuard.Builder(config);
/// var client = builder.Build();
/// </code>
/// </example>
public class PromptGuardClient : BaseClient<PromptGuardClient.Builder>
{
    /// <summary>Service name.</summary>
    public const string ServiceName = "prompt-guard";

    /// <summary>Create a new <see cref="PromptGuardClient"/> using the given builder.</summary>
    public PromptGuardClient(Builder builder)
        : base(builder, ServiceName)
    {
    }

    /// <summary><see cref="PromptGuardClient"/> builder.</summary>
    public class Builder : ClientBuilder
    {
        /// <summary>Create a new <see cref="PromptGuardClient"/> builder.</summary>
        public Builder(Config config)
            : base(config)
        {
        }

        /// <summary>Build an <see cref="PromptGuardClient"/>.</summary>
        public PromptGuardClient Build()
        {
            return new PromptGuardClient(this);
        }
    }

    /// <kind>method</kind>
    /// <summary>Guard messages.</summary>
    /// <remarks>Guard (Beta)</remarks>
    /// <operationid></operationid>
    /// <param name="request">Request parameters.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <example>
    /// <code>
    /// var response = await client.Guard("TODO");
    /// </code>
    /// </example>
    public Task<Response<GuardResult>> Guard(GuardRequest request, CancellationToken cancellationToken = default)
    {
        return DoPost<GuardResult>("/v1/guard", request, cancellationToken: cancellationToken);
    }
}
