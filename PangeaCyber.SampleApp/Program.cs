using PangeaCyber.Net;
using PangeaCyber.Net.Audit;
using PangeaCyber.Net.Redact;

class Program
{
    static async Task Log(AuditClient client, Event e)
    {

    }

    static async Task Main(string[] args)
    {
        // Audit sample
        try
        {
            // var config = Config.FromEnvironment("audit");
            // AuditClientBuilder builder = new AuditClientBuilder(config);
            // var client = builder.Build();
            // var res = await client.Log(new Event("Hello World!"));
            // Console.WriteLine("Success: " + res.Result.Hash);

            // Redact sample
            var redactConfig = Config.FromEnvironment("redact");
            RedactClient redactClient = new RedactClient(redactConfig);

            // Redact text example
            // var request = new RedactTextRequest.RedactTextRequestBuilder("Jenny Jenny... 415-867-5309").SetReturnResult(true).Build();
            // var redactResponse = await redactClient.RedactText(request);
            // Console.WriteLine("Redact Response: " + redactResponse.Result.RedactedText);

            // Redact structured example
            var data = new Dictionary<string, string>();
            data.Add("Name", "My name is Andres");
            data.Add("Contact", "My phone number is 123-456-7890");

            var structuredRequest = new RedactStructuredRequest.RedactStructuredRequestBuilder(data).SetReturnResult(true).Build();
            var structuredResponse = await redactClient.RedactStructured(structuredRequest);
            Console.WriteLine("Redact Structured Response: " + structuredResponse.Result.RedactedData);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Failed with exception: " + ex.Message);
        }
    }
}