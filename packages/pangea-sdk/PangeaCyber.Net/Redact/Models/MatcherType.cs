using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace PangeaCyber.Net.Redact;

[JsonConverter(typeof(StringEnumConverter))]
public enum MatcherType
{
    [EnumMember(Value = "CREDIT_CARD")]
    CreditCard,
    [EnumMember(Value = "CRYPTO")]
    Crypto,
    [EnumMember(Value = "DATE_TIME")]
    DateTime,
    [EnumMember(Value = "EMAIL_ADDRESS")]
    EmailAddress,
    [EnumMember(Value = "IBAN_CODE")]
    IbanCode,
    [EnumMember(Value = "IP_ADDRESS")]
    IpAddress,
    [EnumMember(Value = "NRP")]
    Nrp,
    [EnumMember(Value = "LOCATION")]
    Location,
    [EnumMember(Value = "PERSON")]
    Person,
    [EnumMember(Value = "PHONE_NUMBER")]
    PhoneNumber,
    [EnumMember(Value = "MEDICAL_LICENSE")]
    MedicalLicense,
    [EnumMember(Value = "URL")]
    Url,
    [EnumMember(Value = "US_BANK_NUMBER")]
    UsBankNumber,
    [EnumMember(Value = "US_DRIVER_LICENSE")]
    UsDriverLicense,
    [EnumMember(Value = "US_ITIN")]
    UsItin,
    [EnumMember(Value = "US_PASSPORT")]
    UsPassport,
    [EnumMember(Value = "US_SSN")]
    UsSsn,
    [EnumMember(Value = "UK_NHS")]
    UkNhs,
    [EnumMember(Value = "NIF")]
    Nif,
    [EnumMember(Value = "FIN/NRIC")]
    FinNric,
    [EnumMember(Value = "AU_ABN")]
    AuAbn,
    [EnumMember(Value = "AU_ACN")]
    AuAcn,
    [EnumMember(Value = "AU_TFN")]
    AuTfn,
    [EnumMember(Value = "AU_MEDICARE")]
    AuMedicare,
    [EnumMember(Value = "FIREBASE_URL")]
    FirebaseUrl,
    [EnumMember(Value = "RSA_PRIVATE_KEY")]
    RsaPrivateKey,
    [EnumMember(Value = "SSH_DSA_PRIVATE_KEY")]
    SshDsaPrivateKey,
    [EnumMember(Value = "SSH_EC_PRIVATE_KEY")]
    SshEcPrivateKey,
    [EnumMember(Value = "PGP_PRIVATE_KEY_BLOCK")]
    PgpPrivateKeyBlock,
    [EnumMember(Value = "AMAZON_AWS_ACCESS_KEY_ID")]
    AmazonAwsAccessKeyId,
    [EnumMember(Value = "AMAZON_AWS_SECRET_ACCESS_KEY")]
    AmazonAwsSecretAccessKey,
    [EnumMember(Value = "AMAZON_MWS_AUTH_TOKEN")]
    AmazonMwsAuthToken,
    [EnumMember(Value = "FACEBOOK_ACCESS_TOKEN")]
    FacebookAccessToken,
    [EnumMember(Value = "GITHUB_ACCESS_TOKEN")]
    GithubAccessToken,
    [EnumMember(Value = "JWT_TOKEN")]
    JwtToken,
    [EnumMember(Value = "GOOGLE_API_KEY")]
    GoogleApiKey,
    [EnumMember(Value = "GOOGLE_CLOUD_PLATFORM_API_KEY")]
    GoogleCloudPlatformApiKey,
    [EnumMember(Value = "GOOGLE_DRIVE_API_KEY")]
    GoogleDriveApiKey,
    [EnumMember(Value = "GOOGLE_CLOUD_PLATFORM_SERVICE_ACCOUNT")]
    GoogleCloudPlatformServiceAccount,
    [EnumMember(Value = "GOOGLE_GMAIL_API_KEY")]
    GoogleGmailApiKey,
    [EnumMember(Value = "YOUTUBE_API_KEY")]
    YoutubeApiKey,
    [EnumMember(Value = "MAILCHIMP_API_KEY")]
    MailchimpApiKey,
    [EnumMember(Value = "MAILGUN_API_KEY")]
    MailgunApiKey,
    [EnumMember(Value = "MONEY")]
    Money,
    [EnumMember(Value = "BASIC_AUTH")]
    BasicAuth,
    [EnumMember(Value = "PICATIC_API_KEY")]
    PicaticApiKey,
    [EnumMember(Value = "SLACK_TOKEN")]
    SlackToken,
    [EnumMember(Value = "SLACK_WEBHOOK")]
    SlackWebhook,
    [EnumMember(Value = "STRIPE_API_KEY")]
    StripeApiKey,
    [EnumMember(Value = "STRIPE_RESTRICTED_API_KEY")]
    StripeRestrictedApiKey,
    [EnumMember(Value = "SQUARE_ACCESS_TOKEN")]
    SquareAccessToken,
    [EnumMember(Value = "SQUARE_OAUTH_SECRET")]
    SquareOauthSecret,
    [EnumMember(Value = "TWILIO_API_KEY")]
    TwilioApiKey,
    [EnumMember(Value = "PANGEA_TOKEN")]
    PangeaToken,
    [EnumMember(Value = "PROFANITY")]
    Profanity
}
