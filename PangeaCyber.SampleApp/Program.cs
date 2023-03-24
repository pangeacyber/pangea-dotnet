using PangeaCyber.Net;
using PangeaCyber.Net.Audit;

class Program
{
    static async Task Main(string[] args)
    {
        var config = Config.FromEnvironment("audit");
        AuditClientBuilder builder = new AuditClientBuilder(config);
        var client = builder.Build();

        try
        {
            var res = await client.Log(new Event("Hello World!"));
            Console.WriteLine("Success: " + res.Result.Hash);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Failed with exception: " + ex.Message);
        }
    }
}