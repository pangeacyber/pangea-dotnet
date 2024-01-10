using PangeaCyber.Net;
using PangeaCyber.Net.Audit;
using PangeaCyber.Net.Exceptions;
using PangeaCyber.Examples;

class Program
{

    private const string fieldStrShort = "python-sdk-signed";
    private const string fieldStrLong = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed lacinia, orci eget commodo commodo non.";

    static async Task Main(string[] args)
    {
        // Audit sample
        try
        {
            // Get token from environment variable. Setup PANGEA_AUDIT_CUSTOM_SCHEMA_TOKEN environment variable or set your own token
            var token = Config.LoadEnvironmentVariable("PANGEA_AUDIT_CUSTOM_SCHEMA_TOKEN");

            // Get domain from environment variable. Setup PANGEA_DOMAIN environment variable or set your own domain
            var domain = Config.LoadEnvironmentVariable("PANGEA_DOMAIN");

            // Create service config with domain and token
            var config = new Config(token, domain);

            // Create AuditClient with builder
            var client = new AuditClient.Builder(config)
                .WithCustomSchema<CustomEvent>()
                .Build();

            // Create log config
            var logCfg = new LogConfig.Builder()
                .WithVerbose(true)
                .WithVerify(true)
                .WithSignLocal(false)
                .Build();

            // Create a basic event to log
            var evt = new CustomEvent.Builder("Hello World!")
                .WithFieldInt(2)
                .WithFieldBool(true)
                .WithFieldStrShort(fieldStrShort)
                .WithFieldStrLong(fieldStrLong)
                .Build();

            // Log the event
            var res = await client.Log(evt, logCfg);

            // Check the hash result
            Console.WriteLine("Success. Hash: " + res.Result.Hash);

            // Convert IEvent to CustomEvent
            CustomEvent? logEvt = (CustomEvent?)res.Result.EventEnvelope?.Event;

            // Log fields of the received event
            Console.WriteLine("Message: " + logEvt?.Message);
            Console.WriteLine("Long field: " + logEvt?.FieldStrLong);
            Console.WriteLine("Short field: " + logEvt?.FieldStrShort);
        }
        catch (PangeaException e)
        {
            Console.WriteLine("Failed with exception: " + e.Cause);
        }
    }
}
