using PangeaCyber.Net.AIGuard.Models;
using PangeaCyber.Net.AIGuard.Requests;
using PangeaCyber.Net.AIGuard.Results;

namespace PangeaCyber.Net.AIGuard;

/// <summary>AI Guard API client.</summary>
/// <remarks>AI Guard</remarks>
/// <example>
/// <code>
/// var config = new Config("pangea_token");
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
    /// <summary>
    /// Analyze and redact text to avoid manipulation of the model, addition of malicious content, and other undesirable
    /// data transfers.
    /// </summary>
    /// <remarks>Text guard</remarks>
    /// <operationid>ai_guard_post_v1_text_guard</operationid>
    /// <param name="request">Request parameters.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <example>
    /// <code>
    /// var response = await client.GuardText(new TextGuardRequest("hello world"));
    /// </code>
    /// </example>
    public Task<Response<TextGuardResult>> GuardText(TextGuardRequest request, CancellationToken cancellationToken = default)
    {
        return DoPost<TextGuardResult>("/v1/text/guard", request, cancellationToken: cancellationToken);
    }

    /// <kind>method</kind>
    /// <summary>
    /// Analyze and redact text to avoid manipulation of the model, addition of malicious content, and other undesirable
    /// data transfers.
    /// </summary>
    /// <remarks>Text guard</remarks>
    /// <operationid>ai_guard_post_v1_text_guard</operationid>
    /// <param name="request">Request parameters.</param>
    /// <param name="onlyRelevantContent">Whether or not to only send relevant content to AI Guard.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <example>
    /// <code>
    /// var response = await client.GuardText(
    ///     new MessagesGuardRequest(new[]
    ///     {
    ///         new Message { Role = "user", Content = "what was pangea?" }
    ///     }),
    ///     true);
    /// </code>
    /// </example>
    public async Task<Response<TextGuardResult>> GuardText(
        MessagesGuardRequest request,
        bool onlyRelevantContent = false,
        CancellationToken cancellationToken = default)
    {
        if (!onlyRelevantContent)
        {
            return await DoPost<TextGuardResult>("/v1/text/guard", request, cancellationToken: cancellationToken);
        }

        var relevantContent = GetRelevantContent(request.Messages.ToList());
        var relevantRequest = new MessagesGuardRequest(relevantContent.RelevantMessages)
        {
            Recipe = request.Recipe,
            Debug = request.Debug,
            LogFields = request.LogFields
        };

        var response = await DoPost<TextGuardResult>("/v1/text/guard", relevantRequest, cancellationToken: cancellationToken);

        if (response.Result != null && response.Result.PromptMessages != null)
        {
            var patchedMessages = PatchMessages(request.Messages.ToList(), relevantContent.OriginalIndices, response.Result.PromptMessages);
            response.Result.PromptMessages = patchedMessages;
        }

        return response;
    }

    private sealed class RelevantContent
    {
        public List<Message> RelevantMessages { get; }
        public List<int> OriginalIndices { get; }

        public RelevantContent(List<Message> relevantMessages, List<int> originalIndices)
        {
            RelevantMessages = relevantMessages;
            OriginalIndices = originalIndices;
        }
    }

    private static RelevantContent GetRelevantContent(IReadOnlyList<Message> messages)
    {
        if (messages.Count == 0)
        {
            return new RelevantContent(new List<Message>(), new List<int>());
        }

        var systemMessages = new List<Message>();
        var systemIndices = new List<int>();

        for (var i = 0; i < messages.Count; i++)
        {
            if (messages[i].Role == "system")
            {
                systemMessages.Add(messages[i]);
                systemIndices.Add(i);
            }
        }

        if (messages[messages.Count - 1].Role == "assistant")
        {
            systemMessages.Add(messages[messages.Count - 1]);
            systemIndices.Add(messages.Count - 1);
            return new RelevantContent(systemMessages, systemIndices);
        }

        var lastAssistantIndex = -1;
        for (var i = messages.Count - 1; i >= 0; i--)
        {
            if (messages[i].Role == "assistant")
            {
                lastAssistantIndex = i;
                break;
            }
        }

        var relevantMessages = new List<Message>();
        var originalIndices = new List<int>();

        for (var i = 0; i < messages.Count; i++)
        {
            if (messages[i].Role == "system" || i > lastAssistantIndex)
            {
                relevantMessages.Add(messages[i]);
                originalIndices.Add(i);
            }
        }

        return new RelevantContent(relevantMessages, originalIndices);
    }

    private static List<Message> PatchMessages(
        IReadOnlyList<Message> original,
        IReadOnlyList<int> originalIndices,
        IReadOnlyList<Message> transformed)
    {
        if (original.Count == transformed.Count)
        {
            return transformed.ToList();
        }

        var transformedMap = new Dictionary<int, Message>();
        for (var i = 0; i < originalIndices.Count; i++)
        {
            if (i < transformed.Count)
            {
                transformedMap[originalIndices[i]] = transformed[i];
            }
        }

        var patched = new List<Message>();
        for (var i = 0; i < original.Count; i++)
        {
            patched.Add(transformedMap.TryGetValue(i, out Message value) ? value : original[i]);
        }

        return patched;
    }
}
