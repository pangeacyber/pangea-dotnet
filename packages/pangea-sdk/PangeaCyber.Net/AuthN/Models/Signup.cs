using Newtonsoft.Json;

namespace PangeaCyber.Net.AuthN.Models
{
    ///
    public class Signup
    {
        ///
        [JsonProperty("social_signup")]
        public SocialSignup SocialSignup { get; set; } = new SocialSignup();

        ///
        [JsonProperty("password_signup")]
        public PasswordSignup PasswordSignup { get; set; } = new PasswordSignup();
    }
}
