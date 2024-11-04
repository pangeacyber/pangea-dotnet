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

            Console.WriteLine("Create key...");
            SymmetricGenerateRequest generateRequest = new SymmetricGenerateRequest(
                SymmetricAlgorithm.AES128_CFB,
                KeyPurpose.Encryption,
                name
            );

            var generateResp = await client.SymmetricGenerate(generateRequest);
            string id = generateResp.Result.ID ?? default!;
            Console.WriteLine("Key ID: " + id);

            Console.WriteLine("Encrypt...");
            string message = "thisisamessagetoencrypt";
            string dataB64 = Utils.StringToStringB64(message);
            Console.WriteLine($"Original text to encrypt: {dataB64}");

            // Encrypt
            var encryptResponse = await client.Encrypt(new EncryptRequest(id, dataB64));
            Console.WriteLine("Cipher text: " + encryptResponse.Result.CipherText);

            Console.WriteLine("Decrypt...");
            // Decrypt
            var decryptResponse1 = await client.Decrypt(new DecryptRequest(id, encryptResponse.Result.CipherText) {
                Version = 1,
            });

            Console.WriteLine($"Recovered text: {decryptResponse1.Result.PlainText}");

            if (dataB64.Equals(decryptResponse1.Result.PlainText))
            {
                Console.WriteLine("Encrypt/decrypt success");
            }
            else
            {
                Console.WriteLine("Encrypt/decrypt failed");
            }
        }
        catch (PangeaAPIException e)
        {
            Console.WriteLine("Failed with exception: " + e.ToString());
        }
    }
}
