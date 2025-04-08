using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace PangeaCyber.Net.AIGuard.Models;

/// <summary>Secrets detection overrides.</summary>
[JsonObject(NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
public sealed class SecretsDetectionOverride
{
    /// <summary>Whether secrets detection is disabled.</summary>
    public bool? Disabled { get; set; }

    /// <summary>Action for Slack token detection.</summary>
    public PiiEntityAction? SlackToken { get; set; }

    /// <summary>Action for RSA private key detection.</summary>
    public PiiEntityAction? RsaPrivateKey { get; set; }

    /// <summary>Action for SSH DSA private key detection.</summary>
    public PiiEntityAction? SshDsaPrivateKey { get; set; }

    /// <summary>Action for SSH EC private key detection.</summary>
    public PiiEntityAction? SshEcPrivateKey { get; set; }

    /// <summary>Action for PGP private key block detection.</summary>
    public PiiEntityAction? PgpPrivateKeyBlock { get; set; }

    /// <summary>Action for Amazon AWS access key ID detection.</summary>
    public PiiEntityAction? AmazonAwsAccessKeyId { get; set; }

    /// <summary>Action for Amazon AWS secret access key detection.</summary>
    public PiiEntityAction? AmazonAwsSecretAccessKey { get; set; }

    /// <summary>Action for Amazon MWS auth token detection.</summary>
    public PiiEntityAction? AmazonMwsAuthToken { get; set; }

    /// <summary>Action for Facebook access token detection.</summary>
    public PiiEntityAction? FacebookAccessToken { get; set; }

    /// <summary>Action for GitHub access token detection.</summary>
    public PiiEntityAction? GithubAccessToken { get; set; }

    /// <summary>Action for JWT token detection.</summary>
    public PiiEntityAction? JwtToken { get; set; }

    /// <summary>Action for Google API key detection.</summary>
    public PiiEntityAction? GoogleApiKey { get; set; }

    /// <summary>Action for Google Cloud Platform API key detection.</summary>
    public PiiEntityAction? GoogleCloudPlatformApiKey { get; set; }

    /// <summary>Action for Google Drive API key detection.</summary>
    public PiiEntityAction? GoogleDriveApiKey { get; set; }

    /// <summary>Action for Google Cloud Platform service account detection.</summary>
    public PiiEntityAction? GoogleCloudPlatformServiceAccount { get; set; }

    /// <summary>Action for Google Gmail API key detection.</summary>
    public PiiEntityAction? GoogleGmailApiKey { get; set; }

    /// <summary>Action for YouTube API key detection.</summary>
    public PiiEntityAction? YoutubeApiKey { get; set; }

    /// <summary>Action for Mailchimp API key detection.</summary>
    public PiiEntityAction? MailchimpApiKey { get; set; }

    /// <summary>Action for Mailgun API key detection.</summary>
    public PiiEntityAction? MailgunApiKey { get; set; }

    /// <summary>Action for basic auth detection.</summary>
    public PiiEntityAction? BasicAuth { get; set; }

    /// <summary>Action for Picatic API key detection.</summary>
    public PiiEntityAction? PicaticApiKey { get; set; }

    /// <summary>Action for Slack webhook detection.</summary>
    public PiiEntityAction? SlackWebhook { get; set; }

    /// <summary>Action for Stripe API key detection.</summary>
    public PiiEntityAction? StripeApiKey { get; set; }

    /// <summary>Action for Stripe restricted API key detection.</summary>
    public PiiEntityAction? StripeRestrictedApiKey { get; set; }

    /// <summary>Action for Square access token detection.</summary>
    public PiiEntityAction? SquareAccessToken { get; set; }

    /// <summary>Action for Square OAuth secret detection.</summary>
    public PiiEntityAction? SquareOauthSecret { get; set; }

    /// <summary>Action for Twilio API key detection.</summary>
    public PiiEntityAction? TwilioApiKey { get; set; }

    /// <summary>Action for Pangea token detection.</summary>
    public PiiEntityAction? PangeaToken { get; set; }
}
