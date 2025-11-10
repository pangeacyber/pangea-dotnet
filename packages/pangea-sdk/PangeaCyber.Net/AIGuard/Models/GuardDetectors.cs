using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace PangeaCyber.Net.AIGuard.Models;

[JsonObject(NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
public sealed class GuardDetectors
{
    public MaliciousPromptDetector? MaliciousPrompt { get; set; } = null;

    public ConfidentialAndPiiEntityDetector? ConfidentialAndPiiEntity { get; set; } = null;

    public MaliciousEntityDetector? MaliciousEntity { get; set; } = null;

    public CustomEntityDetector? CustomEntity { get; set; } = null;

    public SecretAndKeyEntityDetector? SecretAndKeyEntity { get; set; } = null;

    public CompetitorsDetector? Competitors { get; set; } = null;

    public PromptHardeningDetector? PromptHardening { get; set; } = null;

    public LanguageDetector? Language { get; set; } = null;

    public TopicDetector? Topic { get; set; } = null;

    public CodeDetector? Code { get; set; } = null;

    [JsonObject(NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
    public sealed class MaliciousPromptDetector
    {
        /// <summary>
        /// Whether or not the Malicious Prompt was detected.
        /// </summary>
        /// <value>Whether or not the Malicious Prompt was detected.</value>
        public bool Detected { get; set; }

        /// <summary>
        /// Details about the analyzers.
        /// </summary>
        /// <value>Details about the analyzers.</value>
        public PromptInjectionResult? Data { get; set; } = null;
    }

    [JsonObject(NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
    public sealed class ConfidentialAndPiiEntityDetector { }

    [JsonObject(NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
    public sealed class MaliciousEntityDetector
    {
        /// <summary>Whether or not the PII Entities were detected.</summary>
        public bool? Detected { get; set; } = null;

        /// <summary>Details about the detected entities.</summary>
        public RedactEntityResult? Data { get; set; } = null;
    }

    [JsonObject(NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
    public sealed class CustomEntityDetector
    {
        /// <summary>
        /// Whether or not the Custom Entities were detected.
        /// </summary>
        /// <value>Whether or not the Custom Entities were detected.</value>
        public bool? Detected { get; set; } = null;

        /// <summary>
        /// Details about the detected entities.
        /// </summary>
        /// <value>Details about the detected entities.</value>
        public RedactEntityResult? Data { get; set; } = null;
    }

    [JsonObject(NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
    public sealed class SecretAndKeyEntityDetector
    {
        /// <summary>
        /// Whether or not the Secret Entities were detected.
        /// </summary>
        /// <value>Whether or not the Secret Entities were detected.</value>
        public bool? Detected { get; set; } = null;

        /// <summary>
        /// Details about the detected entities.
        /// </summary>
        /// <value>Details about the detected entities.</value>
        public RedactEntityResult? Data { get; set; } = null;
    }

    [JsonObject(NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
    public sealed class CompetitorsDetector
    {
        /// <summary>
        /// Whether or not the Competitors were detected.
        /// </summary>
        /// <value>Whether or not the Competitors were detected.</value>
        public bool? Detected { get; set; } = null;

        /// <summary>
        /// Details about the detected entities.
        /// </summary>
        /// <value>Details about the detected entities.</value>
        public SingleEntityResult? Data { get; set; } = null;
    }

    [JsonObject(NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
    public sealed class PromptHardeningDetector
    {
        /// <summary>
        /// Details about the detected languages.
        /// </summary>
        /// <value>Details about the detected languages.</value>
        public HardeningResult? Data { get; set; } = null;
    }

    [JsonObject(NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
    public sealed class LanguageDetector
    {
        /// <summary>
        /// Whether or not the Languages were detected.
        /// </summary>
        /// <value>Whether or not the Languages were detected.</value>
        public bool? Detected { get; set; } = null;

        /// <summary>
        /// Details about the detected languages.
        /// </summary>
        /// <value>Details about the detected languages.</value>
        public LanguageResult? Data { get; set; } = null;
    }

    [JsonObject(NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
    public sealed class TopicDetector
    {
        /// <summary>
        /// Whether or not the Topics were detected.
        /// </summary>
        /// <value>Whether or not the Topics were detected.</value>
        public bool? Detected { get; set; } = null;

        /// <summary>
        /// Details about the detected topics.
        /// </summary>
        /// <value>Details about the detected topics.</value>
        public TopicResult? Data { get; set; } = null;
    }

    [JsonObject(NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
    public sealed class CodeDetector
    {
        /// <summary>
        /// Whether or not the Code was detected.
        /// </summary>
        /// <value>Whether or not the Code was detected.</value>
        public bool? Detected { get; set; } = null;

        /// <summary>
        /// Details about the detected code.
        /// </summary>
        /// <value>Details about the detected code.</value>
        public LanguageResult? Data { get; set; } = null;
    }
}
