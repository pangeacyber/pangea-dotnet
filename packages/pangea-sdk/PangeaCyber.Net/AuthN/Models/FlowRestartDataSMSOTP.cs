using Newtonsoft.Json;

namespace PangeaCyber.Net.AuthN.Models
{
    /// <summary>
    ///
    /// </summary>
    public class FlowRestartDataSMSOTP : FlowRestartData
    {
        /// <summary>
        ///
        /// </summary>
        [JsonProperty("phone")]
        public string Phone { get; private set; }

        /// <summary>
        ///
        /// </summary>
        /// <param name="builder"></param>
        private FlowRestartDataSMSOTP(Builder builder) : base(builder)
        {
            Phone = builder.Phone;
        }

        /// <summary>
        ///
        /// </summary>
        new public class Builder : FlowRestartData.Builder
        {
            /// <summary>
            ///
            /// </summary>
            public string Phone { get; }

            /// <summary>
            ///
            /// </summary>
            /// <param name="phone"></param>
            public Builder(string phone)
            {
                Phone = phone;
            }

            /// <summary>
            ///
            /// </summary>
            /// <returns></returns>
            public new FlowRestartDataSMSOTP Build()
            {
                return new FlowRestartDataSMSOTP(this);
            }
        }
    }
}
