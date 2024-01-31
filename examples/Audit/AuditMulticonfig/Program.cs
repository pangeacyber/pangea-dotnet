using System.Runtime.CompilerServices;
using System.Security.Principal;
using PangeaCyber.Net;
using PangeaCyber.Net.Audit;
using PangeaCyber.Net.Exceptions;

class Program
{

    static async Task Main(string[] args)
    {
        // Audit sample
        try
        {
            string token = System.Environment.GetEnvironmentVariable("PANGEA_AUDIT_MULTICONFIG_TOKEN") ?? string.Empty;
            string domain = System.Environment.GetEnvironmentVariable("PANGEA_DOMAIN") ?? string.Empty;
            string configId = System.Environment.GetEnvironmentVariable("PANGEA_AUDIT_CONFIG_ID") ?? string.Empty;

            var config = new Config(token, domain);

            // Create AuditClient with builder
            // Set configId with service builder
            var client = new AuditClient.Builder(config).WithConfigID(configId).Build();

            // Create log config
            var logCfg = new LogConfig.Builder()
                .WithVerbose(true)
                .WithVerify(true)
                .WithSignLocal(false)
                .Build();

            // Create a basic event to log
            var evt = new StandardEvent.Builder("Hello World!")
                .WithAction("Login")
                .WithActor("Terminal")
                .Build();

            // Log the event
            var res = await client.Log(evt, logCfg);

            // Check the hash result
            Console.WriteLine("Success: " + res.Result.Hash);
        }
        catch (PangeaAPIException e)
        {
            Console.WriteLine("Failed with exception: " + e.ToString());
        }
    }
}
