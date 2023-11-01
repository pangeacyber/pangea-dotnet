using Newtonsoft.Json;

namespace PangeaCyber.Net.AuthN.Models
{
    /// <summary>
    ///
    /// </summary>
    public class FlowUpdateDataPassword : FlowUpdateData
    {
        /// <summary>
        ///
        /// </summary>
        [JsonProperty("password")]
        public string Password { get; private set; }

        /// <summary>
        ///
        /// </summary>
        /// <param name="builder"></param>
        private FlowUpdateDataPassword(Builder builder) : base(builder)
        {
            Password = builder.Password;
        }

        /// <summary>
        ///
        /// </summary>
        new public class Builder : FlowUpdateData.Builder
        {
            /// <summary>
            ///
            /// </summary>
            public string Password { get; }

            /// <summary>
            ///
            /// </summary>
            /// <param name="password"></param>
            public Builder(string password)
            {
                Password = password;
            }

            /// <summary>
            ///
            /// </summary>
            /// <returns></returns>
            public FlowUpdateDataPassword Build()
            {
                return new FlowUpdateDataPassword(this);
            }
        }
    }
}
