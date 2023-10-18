using Newtonsoft.Json;

namespace PangeaCyber.Net.AuthN.Models
{
    /// <summary>
    ///
    /// </summary>
    public class FlowUpdateDataSetEmail : FlowUpdateData
    {
        /// <summary>
        ///
        /// </summary>
        [JsonProperty("email")]
        public string Email { get; private set; }

        /// <summary>
        ///
        /// </summary>
        /// <param name="builder"></param>
        private FlowUpdateDataSetEmail(Builder builder) : base(builder)
        {
            Email = builder.Email;
        }

        /// <summary>
        ///
        /// </summary>
        new public class Builder : FlowUpdateData.Builder
        {
            /// <summary>
            ///
            /// </summary>
            public string Email { get; }

            /// <summary>
            ///
            /// </summary>
            /// <param name="email"></param>
            public Builder(string email)
            {
                Email = email;
            }

            /// <summary>
            ///
            /// </summary>
            /// <returns></returns>
            public FlowUpdateDataSetEmail Build()
            {
                return new FlowUpdateDataSetEmail(this);
            }
        }
    }
}
