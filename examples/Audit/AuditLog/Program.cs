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
            // Load client config. Can create it manually with Config constructor and setters
            var config = Config.FromEnvironment(AuditClient.ServiceName);

            // Create AuditClient with builder
            var client = new AuditClient.Builder(config).Build();

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