using PangeaCyber.Net;
using PangeaCyber.Net.Audit;
using PangeaCyber.Net.Exceptions;
using PangeaCyber.Examples;

class Program
{

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

            // Create AuditClient with builder and custom schema
            var client = new AuditClient.Builder(config)
                .WithCustomSchema<CustomEvent>()
                .Build();

            // Create search config
            var searchCfg = new SearchConfig.Builder()
                .WithVerifyConsistency(true)
                .WithVerifyEvents(true)
                .Build();

            // Create search request
            var searchReq = new SearchRequest.Builder("message:\"\"")
                .WithOrder("desc")
                .WithMaxResults(5)
                .WithVerbose(true)
                .Build();

            // Perform search
            var res = await client.Search(searchReq, searchCfg);

            // Print results
            Console.WriteLine($"Success. Found {res.Result.Count} events");
            foreach (var evt in res.Result.Events)
            {
                var logEvt = (CustomEvent?)evt.EventEnvelope.Event;
                Console.WriteLine($"Event message: {logEvt?.Message} \t long field: {logEvt?.FieldStrLong} \t short field: {logEvt?.FieldStrShort}");
            }

        }
        catch (PangeaAPIException e)
        {
            Console.WriteLine("Failed with exception: " + e.ToString());
        }
    }
}
