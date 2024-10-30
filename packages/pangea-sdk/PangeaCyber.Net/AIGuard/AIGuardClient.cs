using PangeaCyber.Net.AIGuard.Requests;
using PangeaCyber.Net.AIGuard.Results;

namespace PangeaCyber.Net.AIGuard;

/// <summary>AI Guard API client.</summary>
/// <remarks>AI Guard</remarks>
/// <example>
/// <code>
/// var config = new Config("pangea_token", "pangea_domain");
/// var builder = new AIGuardClient.Builder(config);
/// var client = builder.Build();
/// </code>
/// </example>
public class AIGuardClient : BaseClient<AIGuardClient.Builder>
{
    /// <summary>Service name.</summary>
    public const string ServiceName = "ai-guard";

    /// <summary>Create a new <see cref="AIGuardClient"/> using the given builder.</summary>
    public AIGuardClient(Builder builder)
        : base(builder, ServiceName)
    {
    }

    /// <summary><see cref="AIGuardClient"/> builder.</summary>
    public class Builder : ClientBuilder
    {
        /// <summary>Create a new <see cref="AIGuardClient"/> builder.</summary>
        public Builder(Config config)
            : base(config)
        {
        }

        /// <summary>Build an <see cref="AIGuardClient"/>.</summary>
        public AIGuardClient Build()
        {
            return new AIGuardClient(this);
        }
    }

    /// <kind>method</kind>
    /// <summary>Guard text.</summary>
    /// <remarks>Text guard (Beta)</remarks>
    /// <operationid>ai_guard_post_v1beta_text_guard</operationid>
    /// <param name="request">Request parameters.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <example>
    /// <code>
    /// var response = await client.GuardText(new TextGuardRequest("hello world"));
    /// </code>
    /// </example>
    public Task<Response<TextGuardResult>> GuardText(TextGuardRequest request, CancellationToken cancellationToken = default)
    {
        return DoPost<TextGuardResult>("/v1beta/text/guard", request, cancellationToken: cancellationToken);
    }
}
