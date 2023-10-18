using Newtonsoft.Json;

namespace PangeaCyber.Net.AuthN.Models
{
    ///
    public class Profile : Dictionary<string, string?>
    {
        /// <summary>
        ///
        /// </summary>
        [JsonIgnore]
        public string? FirstName
        {
            get
            {
                TryGetValue("first_name", out string? value);
                return value;
            }
            set
            {
                this["first_name"] = value;
            }
        }

        /// <summary>
        ///
        /// </summary>
        [JsonIgnore]
        public string? LastName
        {
            get
            {
                TryGetValue("last_name", out string? value);
                return value;
            }
            set
            {
                this["last_name"] = value;
            }
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="firstName"></param>
        /// <param name="lastName"></param>
        public Profile(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }

        /// <summary>
        ///
        /// </summary>
        public Profile() { }

    }
}
