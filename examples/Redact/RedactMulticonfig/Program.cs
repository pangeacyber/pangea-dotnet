using PangeaCyber.Net;
using PangeaCyber.Net.Redact;
using PangeaCyber.Net.Exceptions;


class Program
{
    static async Task Main(string[] args)
    {
        try
        {
            var token = System.Environment.GetEnvironmentVariable("PANGEA_REDACT_MULTICONFIG_TOKEN") ?? string.Empty;
            var domain = System.Environment.GetEnvironmentVariable("PANGEA_DOMAIN") ?? string.Empty;
            var configId = System.Environment.GetEnvironmentVariable("PANGEA_REDACT_CONFIG_ID") ?? string.Empty;

            // Create config manually with Config constructor and setters
            var config = new Config(token) { Domain = domain };

            // Create RedactClient with builder
            RedactClient redactClient = new RedactClient.Builder(config).WithConfigID(configId).Build();

            // Create request to be send with text to redact
            var request = new RedactTextRequest("Jenny Jenny... 415-867-5309")
            {
                ReturnResult = true
            };

            // Send request
            var redactResponse = await redactClient.RedactText(request);

            // If success, print redacted text
            Console.WriteLine("Redact Response: " + redactResponse.Result.RedactedText);

        }
        catch (PangeaAPIException e)
        {
            Console.WriteLine("Failed with exception: " + e.ToString());
        }
    }
}
