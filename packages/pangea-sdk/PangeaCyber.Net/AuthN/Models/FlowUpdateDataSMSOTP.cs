using Newtonsoft.Json;

namespace PangeaCyber.Net.AuthN.Models
{
    /// <summary>
    ///
    /// </summary>
    public class FlowUpdateDataSMSOTP : FlowUpdateData
    {
        /// <summary>
        ///
        /// </summary>
        [JsonProperty("code")]
        public string Code { get; private set; }

        /// <summary>
        ///
        /// </summary>
        /// <param name="builder"></param>
        private FlowUpdateDataSMSOTP(Builder builder) : base(builder)
        {
            Code = builder.Code;
        }

        /// <summary>
        ///
        /// </summary>
        new public class Builder : FlowUpdateData.Builder
        {
            /// <summary>
            ///
            /// </summary>
            public string Code { get; }

            /// <summary>
            ///
            /// </summary>
            /// <param name="code"></param>
            public Builder(string code)
            {
                Code = code;
            }

            /// <summary>
            ///
            /// </summary>
            /// <returns></returns>
            public FlowUpdateDataSMSOTP Build()
            {
                return new FlowUpdateDataSMSOTP(this);
            }
        }
    }
}
