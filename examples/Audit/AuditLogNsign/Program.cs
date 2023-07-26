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
            var client = new AuditClient.Builder(config)
                .WithPrivateKey("./privkey")    // Setup private key to sign
                .Build();

            // Create log config
            var logCfg = new LogConfig.Builder()
                .WithVerbose(true)
                .WithVerify(true)
                .WithSignLocal(true)        // Setup to sign locally
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
            Console.WriteLine("Public key: " + res.Result.EventEnvelope.PublicKey);
            Console.WriteLine("Signature: " + res.Result.EventEnvelope.Signature);

        }
        catch (PangeaAPIException e)
        {
            Console.WriteLine("Failed with exception: " + e.ToString());
        }
    }
}
