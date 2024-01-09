using PangeaCyber.Net;
using PangeaCyber.Net.Intel;
using PangeaCyber.Net.Exceptions;


class Program
{

    static async Task Main(string[] args)
    {
        try
        {
            // Load client config. Can create it manually with Config constructor and setters
            var clientCfg = Config.FromEnvironment("url-intel");

            // Create URLIntelClient with builder
            URLIntelClient urlClient = new URLIntelClient.Builder(clientCfg).Build();

            // Create DomainIntelClient with builder
            DomainIntelClient domainClient = new DomainIntelClient.Builder(clientCfg).Build();

            // Set url to analyze
            string url = "http://113.235.101.11:54384";

            // Create request
            var urlReq = new URLReputationRequest.Builder(url)
                .WithProvider("crowdstrike")
                .WithVerbose(true)
                .WithRaw(true)
                .Build();

            // Send request
            var urlRes = await urlClient.Reputation(urlReq);

            if (urlRes.Result.Data.Verdict.Equals("malicious"))
            {
                Console.WriteLine($"Defanged URL: {DefangURL(url)}");
            }
            else
            {
                string domain = GetDomain(url);

                // Create request
                var domainReq = new DomainReputationRequest.Builder(domain)
                    .WithProvider("domaintools")
                    .WithVerbose(true)
                    .WithRaw(true)
                    .Build();

                // Send request
                var domainRes = await domainClient.Reputation(domainReq);

                if (domainRes.Result.Data.Verdict.Equals("malicious"))
                {
                    Console.WriteLine($"Defanged URL: {DefangURL(url)}");
                }
                else
                {
                    Console.WriteLine($"URL {url} seems to be safe");
                }
            }

        }
        catch (PangeaAPIException e)
        {
            Console.WriteLine("Failed with exception: " + e.ToString());
        }
    }

    public static string DefangURL(string url)
    {
        Dictionary<string, string> defangedProtocols = new Dictionary<string, string>
        {
            { "http", "hxxp" },
            { "https", "hxxps" }
        };

        Uri aURL;
        if (Uri.TryCreate(url, UriKind.Absolute, out aURL!))
        {
            string protocol = aURL.Scheme;
            string defangedProtocol;
            if (defangedProtocols.TryGetValue(protocol, out defangedProtocol!))
            {
                return url.Replace(protocol, defangedProtocol);
            }
        }
        return url;
    }

    public static string GetDomain(string url)
    {
        Uri aURL;
        if (Uri.TryCreate(url, UriKind.Absolute, out aURL!))
        {
            return aURL.Host;
        }
        return url;
    }

}
