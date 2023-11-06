using Newtonsoft.Json;

namespace PangeaCyber.Net.AuthN.Models
{
    /// <summary>
    ///
    /// </summary>
    public class FlowUpdateDataTOTP : FlowUpdateData
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
        private FlowUpdateDataTOTP(Builder builder) : base(builder)
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
            public FlowUpdateDataTOTP Build()
            {
                return new FlowUpdateDataTOTP(this);
            }
        }
    }
}
