using PangeaCyber.Net.DataGuard.Requests;
using PangeaCyber.Net.DataGuard.Results;

namespace PangeaCyber.Net.DataGuard;

/// <summary>Data Guard API client.</summary>
/// <remarks>Data Guard</remarks>
/// <example>
/// <code>
/// var config = new Config("pangea_token", "pangea_domain");
/// var builder = new DataGuard.Builder(config);
/// var client = builder.Build();
/// </code>
/// </example>
public class DataGuardClient : BaseClient<DataGuardClient.Builder>
{
    /// <summary>Service name.</summary>
    public const string ServiceName = "data-guard";

    /// <summary>Create a new <see cref="DataGuardClient"/> using the given builder.</summary>
    public DataGuardClient(Builder builder)
        : base(builder, ServiceName)
    {
    }

    /// <summary><see cref="DataGuardClient"/> builder.</summary>
    public class Builder : ClientBuilder
    {
        /// <summary>Create a new <see cref="DataGuardClient"/> builder.</summary>
        public Builder(Config config)
            : base(config)
        {
        }

        /// <summary>Build an <see cref="DataGuardClient"/>.</summary>
        public DataGuardClient Build()
        {
            return new DataGuardClient(this);
        }
    }

    /// <kind>method</kind>
    /// <summary>Guard text.</summary>
    /// <remarks>Text guard (Beta)</remarks>
    /// <operationid>data_guard_post_v1_text_guard</operationid>
    /// <param name="request">Request parameters.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <example>
    /// <code>
    /// var response = await client.GuardText("TODO");
    /// </code>
    /// </example>
    public Task<Response<TextGuardResult>> GuardText(TextGuardRequest request, CancellationToken cancellationToken = default)
    {
        return DoPost<TextGuardResult>("/v1/text/guard", request, cancellationToken: cancellationToken);
    }

    /// <kind>method</kind>
    /// <summary>Guard text.</summary>
    /// <remarks>Text guard (Beta)</remarks>
    /// <operationid>data_guard_post_v1_text_guard</operationid>
    /// <param name="request">Request parameters.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <example>
    /// <code>
    /// var response = await client.GuardText("TODO");
    /// </code>
    /// </example>
    public Task<Response<object>> GuardFile(FileGuardRequest request, CancellationToken cancellationToken = default)
    {
        return DoPost<object>("/v1/file/guard", request, cancellationToken: cancellationToken);
    }
}
