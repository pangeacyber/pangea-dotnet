using Newtonsoft.Json;

namespace PangeaCyber.Net.AuthN.Models
{
    /// <summary>A user profile as a collection of string properties.</summary>
    public class Profile : Dictionary<string, string?>
    {
        /// <summary>Deprecated alias for <c>Profile["first_name"]</c>.</summary>
        [Obsolete("`Profile.FirstName` is deprecated. Use `Profile[\"first_name\"] instead.")]
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

        /// <summary>Deprecated alias for <c>Profile["last_name"]</c>.</summary>
        [Obsolete("`Profile.LastName` is deprecated. Use `Profile[\"last_name\"] instead.")]
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

        /// <summary>Deprecated constructor.</summary>
        /// <param name="firstName">First name.</param>
        /// <param name="lastName">Last name.</param>
        [Obsolete("Use the parameterless `Profile()` constructor instead.")]
        public Profile(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }

        /// <summary>Constructor.</summary>
        public Profile() { }
    }
}
