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

            // Set root size to 1
            int rootSize = 1;

            // Request root
            var res = await client.GetRoot(rootSize);

            // Check root result
            Console.WriteLine("Success. Root size: " + res.Result.Root.Size);
            Console.WriteLine("Tree name: " + res.Result.Root.TreeName);
            Console.WriteLine("Hash: " + res.Result.Root.RootHash);
            Console.WriteLine("Published at: " + res.Result.Root.PublishedAt);
        }
        catch (PangeaAPIException e)
        {
            Console.WriteLine("Failed with exception: " + e.ToString());
        }
    }
}
