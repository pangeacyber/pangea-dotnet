using PangeaCyber.Net;
using PangeaCyber.Net.Redact;
using PangeaCyber.Net.Exceptions;

var redactConfig = Config.FromEnvironment(RedactClient.ServiceName);
var redactClient = new RedactClient.Builder(redactConfig).Build();

var redacted = await redactClient.RedactText(new RedactTextRequest("Visit our website at https://pangea.cloud")
{
    RedactionMethodOverrides = new Dictionary<string, RedactionMethodOverrides>
    {
        {
            "PHONE_NUMBER",
            new RedactionMethodOverrides { RedactionType = RedactType.FPE, FpeAlphabet = FPEAlphabet.NUMERIC }
        }
    }
});
Console.WriteLine("Redacted text: " + redacted.Result.RedactedText);

if (redacted.Result.FPEContext == null)
{
    Console.WriteLine("Expected FPEContext to be non-null");
    return;
}

var unredacted = await redactClient.Unredact(new UnredactRequest<string>(redacted.Result.RedactedText, redacted.Result.FPEContext));
Console.WriteLine("Unredacted text: " + unredacted.Result.Data);
