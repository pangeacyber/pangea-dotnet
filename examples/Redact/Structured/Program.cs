using PangeaCyber.Net;
using PangeaCyber.Net.Redact;
using PangeaCyber.Net.Exceptions;

class Program
{

    static async Task Main(string[] args)
    {
        // Audit sample
        try
        {
            // Load client config. Can create it manually with Config constructor and setters
            var redactConfig = Config.FromEnvironment(RedactClient.ServiceName);

            // Create RedactClient with builder
            RedactClient redactClient = new RedactClient.Builder(redactConfig).Build();

            // Load structured data to redact
            var data = new Dictionary<string, string>();
            data.Add("Name", "My name is Andres");
            data.Add("Contact", "My phone number is 123-456-7890");

            // Create request to be send with text to redact
            var structuredRequest = new RedactStructuredRequest.Builder(data).WithReturnResult(true).Build();

            // Send request
            var structuredResponse = await redactClient.RedactStructured(structuredRequest);

            // If success, print redacted data
            Console.WriteLine("Redact Structured Response: " + structuredResponse.Result.RedactedData);
        }
        catch (PangeaAPIException e)
        {
            Console.WriteLine("Failed with exception: " + e.ToString());
        }
    }
}
