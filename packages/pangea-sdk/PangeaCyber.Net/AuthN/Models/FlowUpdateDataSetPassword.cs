using Newtonsoft.Json;

namespace PangeaCyber.Net.AuthN.Models
{
    /// <summary>
    ///
    /// </summary>
    public class FlowUpdateDataSetPassword : FlowUpdateData
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
        private FlowUpdateDataSetPassword(Builder builder) : base(builder)
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
            public FlowUpdateDataSetPassword Build()
            {
                return new FlowUpdateDataSetPassword(this);
            }
        }
    }
}
