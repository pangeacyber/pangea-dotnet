using Newtonsoft.Json;

namespace PangeaCyber.Net.AuthN.Models
{
    /// <summary>
    ///
    /// </summary>
    public class FlowUpdateDataAgreements : FlowUpdateData
    {
        /// <summary>
        ///
        /// </summary>
        [JsonProperty("agreed")]
        public List<string> Agreed { get; private set; }

        private FlowUpdateDataAgreements(Builder builder) : base(builder)
        {
            Agreed = builder.Agreed;
        }

        /// <summary>
        ///
        /// </summary>
        new public class Builder : FlowUpdateData.Builder
        {
            /// <summary>
            ///
            /// </summary>
            public List<string> Agreed { get; private set; }

            /// <summary>
            ///
            /// </summary>
            /// <param name="agreed"></param>
            public Builder(List<string> agreed)
            {
                Agreed = agreed;
            }

            /// <summary>
            ///
            /// </summary>
            /// <param name="agreed"></param>
            /// <returns></returns>
            public Builder WithAgreed(string agreed)
            {
                Agreed.Add(agreed);
                return this;
            }

            /// <summary>
            ///
            /// </summary>
            /// <returns></returns>
            public FlowUpdateDataAgreements Build()
            {
                return new FlowUpdateDataAgreements(this);
            }
        }
    }
}
