using PangeaCyber.Net;
using PangeaCyber.Net.Audit;

class Program
{
    static async Task Main(string[] args)
    {
        var config = Config.FromEnvironment("audit");
        AuditClientBuilder builder = new AuditClientBuilder(config);
        var client = builder.Build();

        // try
        // {
        //     var evt = new Event("Hello World! " + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff"));
        //     var res1 = await client.Log(evt);

        //     Console.WriteLine("Hash: " + res1.Result.Hash);

        //     evt.Actor = "PangeaCyber.SampleApp";
        //     evt.Action = "Auditable Action";
        //     evt.Source = "Sample source";
        //     evt.Old = "Tracking value changes, this is the old value";
        //     evt.NewField = "the new value";

        //     var res2 = await client.Log(evt);
        //     Console.WriteLine("Hash: " + res2.Result.Hash);
        // }
        // catch (Exception ex)
        // {
        //     Console.WriteLine("Failed with exception: " + ex.Message);
        // }

        try
        {
            var input = new SearchInput("message:");
            int limit = 10;
            input.MaxResults = limit;
            input.Order = "asc";

            var res = await client.Search(input, true, true);

            foreach (SearchEvent evt in res.Result.Events)
            {
                Console.WriteLine(evt.ConsistencyVerification);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Failed with exception: " + ex.Message);
        }
    }
}