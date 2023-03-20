using System.Globalization;
using System.Security.Cryptography;
using System.Text;

namespace PangeaCyber.Net.Audit.Utils
{
    /// <kind>class</kind>
    /// <summary>
    /// Hash
    /// </summary>
    public class Hash
    {
        ///
        public static string GetHash(string data)
        {
            string hash = String.Empty;

            // Initialize a SHA256 hash object
            using (SHA256 sha256 = SHA256.Create())
            {
                // Compute the hash of the given string
                byte[] hashValue = sha256.ComputeHash(Encoding.UTF8.GetBytes(data));

                // Convert the byte array to string format
                foreach (byte b in hashValue)
                {
                    hash += $"{b:X2}";
                }
            }

            return hash.ToLower();
        }

        ///
        public static byte[] Unhexlify(string hexString)
        {
            if (hexString.Length % 2 != 0)
            {
                throw new ArgumentException(String.Format(CultureInfo.InvariantCulture, "The binary key cannot have an odd number of digits: {0}", hexString));
            }

            byte[] data = new byte[hexString.Length / 2];
            for (int index = 0; index < data.Length; index++)
            {
                string byteValue = hexString.Substring(index * 2, 2);
                data[index] = byte.Parse(byteValue, NumberStyles.HexNumber, CultureInfo.InvariantCulture);
            }

            return data;
        }

        ///
        public static byte[] Decode(string hash)
        {
            return Unhexlify(hash);
        }

        ///
        public static byte[] GetHash(byte[] h1, byte[] h2)
        {
            var combinedArray = new byte[h1.Length + h2.Length];

            System.Buffer.BlockCopy(h1, 0, combinedArray, 0, h1.Length);
            System.Buffer.BlockCopy(h2, 0, combinedArray, h1.Length, h2.Length);

            // Initialize a SHA256 hash object
            using (SHA256 sha256 = SHA256.Create())
            {
                // Compute the hash of the given byte[]
                return sha256.ComputeHash(combinedArray);
            }
        }

    }

}

