using System;
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

            // Create some events to log
            var evt1 = new StandardEvent.Builder("Hello World!")
                .WithAction("Sign up")
                .WithActor("Terminal")
                .Build();

            var evt2 = new StandardEvent.Builder("Hello World!")
                .WithAction("Sign in")
                .WithActor("Terminal")
                .Build();

            // Log the event
            var response = await client.LogBulkAsync(new IEvent[] { evt1, evt2 }, new LogConfig.Builder().WithVerify(false).Build());

            Console.WriteLine("Sent success: " + response.Summary);
        }
        catch (PangeaAPIException e)
        {
            Console.WriteLine("Failed with exception: " + e.ToString());
        }
    }
}
