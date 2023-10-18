using Newtonsoft.Json;

namespace PangeaCyber.Net.AuthN.Models
{
    /// <summary>
    ///
    /// </summary>
    public class FlowUpdateDataVerifyEmail : FlowUpdateData
    {
        /// <summary>
        ///
        /// </summary>
        [JsonProperty("state")]
        public string State { get; private set; }

        /// <summary>
        ///
        /// </summary>
        [JsonProperty("code")]
        public string Code { get; private set; }

        /// <summary>
        ///
        /// </summary>
        /// <param name="builder"></param>
        private FlowUpdateDataVerifyEmail(Builder builder) : base(builder)
        {
            State = builder.State;
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
            public string State { get; }

            /// <summary>
            ///
            /// </summary>
            public string Code { get; }

            /// <summary>
            ///
            /// </summary>
            /// <param name="state"></param>
            /// <param name="code"></param>
            public Builder(string state, string code)
            {
                State = state;
                Code = code;
            }

            /// <summary>
            ///
            /// </summary>
            /// <returns></returns>
            public FlowUpdateDataVerifyEmail Build()
            {
                return new FlowUpdateDataVerifyEmail(this);
            }
        }
    }
}
