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
                var logEvt = (StandardEvent?)evt.EventEnvelope.Event;
                Console.WriteLine($"Event time: {evt.EventEnvelope.ReceivedAt} \t message: {logEvt?.Message}");
            }

        }
        catch (PangeaAPIException e)
        {
            Console.WriteLine("Failed with exception: " + e.ToString());
        }
    }
}
