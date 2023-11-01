using Newtonsoft.Json;

namespace PangeaCyber.Net.AuthN.Models
{
    /// <summary>
    ///
    /// </summary>
    public class FlowUpdateDataProfile : FlowUpdateData
    {
        /// <summary>
        ///
        /// </summary>
        [JsonProperty("profile")]
        public Profile Profile { get; private set; }

        /// <summary>
        ///
        /// </summary>
        /// <param name="builder"></param>
        private FlowUpdateDataProfile(Builder builder) : base(builder)
        {
            Profile = builder.Profile;
        }

        /// <summary>
        ///
        /// </summary>
        new public class Builder : FlowUpdateData.Builder
        {
            /// <summary>
            ///
            /// </summary>
            public Profile Profile { get; }

            /// <summary>
            ///
            /// </summary>
            /// <param name="profile"></param>
            public Builder(Profile profile)
            {
                Profile = profile;
            }

            /// <summary>
            ///
            /// </summary>
            /// <returns></returns>
            public FlowUpdateDataProfile Build()
            {
                return new FlowUpdateDataProfile(this);
            }
        }
    }
}
