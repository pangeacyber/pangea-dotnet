using PangeaCyber.Net;
using PangeaCyber.Net.Redact;
using PangeaCyber.Net.Exceptions;


class Program
{

    static async Task Main(string[] args)
    {
        try
        {
            // Load client config. Can create it manually with Config constructor and setters
            var redactConfig = Config.FromEnvironment(RedactClient.ServiceName);

            // Create RedactClient with builder
            RedactClient redactClient = new RedactClient.Builder(redactConfig).Build();

            // Create request to be send with text to redact
            var request = new RedactTextRequest.Builder("Jenny Jenny... 415-867-5309").WithReturnResult(true).Build();

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