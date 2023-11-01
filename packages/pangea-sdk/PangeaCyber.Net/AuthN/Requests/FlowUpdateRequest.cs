using Newtonsoft.Json;
using PangeaCyber.Net.AuthN.Models;

namespace PangeaCyber.Net.AuthN.Requests
{
    /// <summary>
    ///
    /// </summary>
    public class FlowUpdateRequest : BaseRequest
    {
        /// <summary>
        /// Gets the flow ID property.
        /// </summary>
        [JsonProperty("flow_id")]
        public string FlowID { get; private set; }

        /// <summary>
        /// Gets the choice property.
        /// </summary>
        [JsonProperty("choice")]
        public FlowChoice Choice { get; private set; }

        /// <summary>
        /// Gets the data property.
        /// </summary>
        [JsonProperty("data")]
        public FlowUpdateData Data { get; private set; }

        /// <summary>
        /// Private constructor for <see cref="FlowUpdateRequest"/>.
        /// </summary>
        private FlowUpdateRequest(string flowID, FlowChoice choice, FlowUpdateData data)
        {
            FlowID = flowID;
            Choice = choice;
            Data = data;
        }

        /// <summary>
        /// Builder class for constructing instances of <see cref="FlowUpdateRequest"/>.
        /// </summary>
        public class Builder
        {
            /// <summary>
            /// Gets or sets the flow ID property.
            /// </summary>
            public string FlowID { get; private set; }

            /// <summary>
            /// Gets or sets the choice property.
            /// </summary>
            public FlowChoice Choice { get; private set; }

            /// <summary>
            /// Gets or sets the data property.
            /// </summary>
            public FlowUpdateData Data { get; private set; }

            /// <summary>
            /// Constructs a new instance of <see cref="Builder"/> with the specified parameters.
            /// </summary>
            public Builder(string flowID, FlowChoice choice, FlowUpdateData data)
            {
                FlowID = flowID;
                Choice = choice;
                Data = data;
            }

            /// <summary>
            /// Builds the <see cref="FlowUpdateRequest"/> instance.
            /// </summary>
            public FlowUpdateRequest Build()
            {
                return new FlowUpdateRequest(FlowID, Choice, Data);
            }
        }
    }
}
