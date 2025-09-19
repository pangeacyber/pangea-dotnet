using System.Net;
using System.Net.Http;

namespace PangeaCyber.Net;

/// <summary>Retry handler for Pangea API requests.</summary>
public sealed class RetryHandler : DelegatingHandler
{
    private readonly int maxRetries;

    /// <summary>Constructor.</summary>
    public RetryHandler(int maxRetries)
    {
        InnerHandler = new HttpClientHandler();
        this.maxRetries = maxRetries;
    }

    /// <inheritdoc />
    protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
    {
        var previousRequestIds = new HashSet<string>();
        HttpResponseMessage? response = null;

        for (var retryCount = 0; retryCount <= maxRetries; retryCount++)
        {
            if (previousRequestIds.Any())
            {
                request.Headers.Remove("X-Pangea-Retried-Request-Ids");
                request.Headers.Add("X-Pangea-Retried-Request-Ids", string.Join(",", previousRequestIds));
            }

            response = await base.SendAsync(request, cancellationToken).ConfigureAwait(false);

            if (!ShouldRetry(response) || retryCount > maxRetries)
            {
                return response;
            }

            if (response.Headers.TryGetValues("x-request-id", out var values))
            {
                previousRequestIds.Add(values.First());
            }

            var delay = 0.5 * Math.Pow(2, retryCount);
            delay = Math.Min(delay, 8);
            await Task.Delay(TimeSpan.FromSeconds(delay), cancellationToken).ConfigureAwait(false);
        }

        return response!;
    }

    private bool ShouldRetry(HttpResponseMessage response)
    {
        return response.StatusCode == HttpStatusCode.InternalServerError
            || response.StatusCode == HttpStatusCode.BadGateway
            || response.StatusCode == HttpStatusCode.ServiceUnavailable
            || response.StatusCode == HttpStatusCode.GatewayTimeout;
    }
}
