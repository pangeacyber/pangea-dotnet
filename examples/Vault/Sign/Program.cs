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
            string name = "my_key_s_name_" + time;
            string dataToSign = Utils.StringToStringB64("thisisamessagetosign");

            // Generate key pair
            Console.WriteLine("Generate key...");
            var generateRequest = new AsymmetricGenerateRequest(AsymmetricAlgorithm.ED25519, KeyPurpose.Signing, name);
            var generateResp = await client.AsymmetricGenerate(generateRequest);
            string id = generateResp.Result.ID ?? default!;
            Console.WriteLine("Key ID: " + id);

            // Sign
            Console.WriteLine("Sign...");
            var signRequest = new SignRequest(id, dataToSign);
            var signResp = await client.Sign(signRequest);
            string signatureBase64 = signResp.Result.Signature;

            // Verify
            Console.WriteLine("Verify...");
            var verifyRequest = new VerifyRequest(id, dataToSign, signatureBase64);
            var verifyResp = await client.Verify(verifyRequest);

            if (verifyResp.Result.ValidSignature)
            {
                Console.WriteLine("Signature verification success");
            }
            else
            {
                Console.WriteLine("Signature verification failed");
            }
        }
        catch (PangeaAPIException e)
        {
            Console.WriteLine("Failed with exception: " + e.ToString());
        }
    }
}
