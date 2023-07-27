using System.Text;
using System.Security.Cryptography;

namespace PangeaCyber.Net
{
    ///
    public class Utils
    {

        ///
        public static string StringToStringB64(string input)
        {
            // Convert the string to a byte array
            byte[] bytes = Encoding.UTF8.GetBytes(input);

            // Convert the byte array to a Base64 string
            return Convert.ToBase64String(bytes);
        }

        ///
        public static string Base64ToString(string input){
            // Convert Base64 string to byte array
            byte[] bytes = Convert.FromBase64String(input);

            // Decode byte array to string
            return Encoding.UTF8.GetString(bytes);
        }

        ///
        public static string GetSHA256Hash(string input)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] inputBytes = Encoding.UTF8.GetBytes(input);
                byte[] hashBytes = sha256.ComputeHash(inputBytes);
                StringBuilder builder = new StringBuilder();

                foreach (byte b in hashBytes)
                {
                    builder.Append(b.ToString("x2")); // Convert each byte to its hexadecimal representation
                }

                return builder.ToString();
            }
        }

        ///
        public static string GetHashPrefix(string input, int len = 5){
            if(string.IsNullOrEmpty(input))
            {
                return input;
            }
            return input.Substring(0, len);
        }

    }
}
