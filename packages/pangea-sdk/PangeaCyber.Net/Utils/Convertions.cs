using System.Text;

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
    }
}
