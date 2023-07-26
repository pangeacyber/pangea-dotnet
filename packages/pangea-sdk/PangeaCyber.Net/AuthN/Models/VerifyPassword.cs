using Newtonsoft.Json;

namespace PangeaCyber.Net.AuthN.Models
{
    ///
    public class VerifyPassword
    {
        ///
        [JsonProperty("password_chars_min")]
        public int CharsMin { get; set; }

        ///
        [JsonProperty("password_chars_max")]
        public int CharsMax { get; set; }

        ///
        [JsonProperty("password_lower_min")]
        public int LowerMin { get; set; }

        ///
        [JsonProperty("password_upper_min")]
        public int UpperMin { get; set; }

        ///
        [JsonProperty("password_punct_min")]
        public int PunctMin { get; set; }

        ///
        [JsonProperty("password_number_min")]
        public int NumberMin { get; set; }
    }
}
