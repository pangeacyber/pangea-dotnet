using System;
using System.Text;
using PangeaCyber.Net;
using PangeaCyber.Net.Exceptions;
using PangeaCyber.Net.Vault;
using PangeaCyber.Net.Vault.Requests;
using PangeaCyber.Net.Vault.Models;

class Program
{
    static async Task Main(string[] args)
    {
        try
        {
            // Load client config. Can create it manually with Config constructor and setters
            Config cfg = Config.FromEnvironment("vault");

            DateTime now = DateTime.Now;
            string time = now.ToString("yyyyMMdd_HHmmss");

            // Create client with builder
            VaultClient client = new VaultClient.Builder(cfg).Build();
            string name = "my secret's name " + time;
            string secretV1 = "mysecret";
            string secretV2 = "mynewsecret";

            Console.WriteLine("Store...");
            var storeRequest = new SecretStoreRequest.Builder(secretV1, name).Build();
            var storeResponse = await client.SecretStore(storeRequest);

            Console.WriteLine("Store result ID: " + storeResponse.Result.ID);
            Console.WriteLine("Store version: " + storeResponse.Result.Version );
            
            Console.WriteLine("Rotate...");
            var rotateRequest = new SecretRotateRequest.Builder(storeResponse.Result.ID, secretV2)
                .WithRotationState(ItemVersionState.Suspended)
                .Build();
            var rotateResponse = await client.SecretRotate(rotateRequest);
            Console.WriteLine("Rotate version: " + rotateResponse.Result.Version);

            Console.WriteLine("Get...");
            var getRequest = new GetRequest.Builder(storeResponse.Result.ID).Build();
            var getResponse = await client.Get(getRequest);

            Console.WriteLine("Get version: " + getResponse.Result.CurrentVersion?.Version );
            Console.WriteLine("Success!");
        }
        catch (PangeaAPIException e)
        {
            Console.WriteLine("Failed with exception: " + e.ToString());
        }
    }
}
