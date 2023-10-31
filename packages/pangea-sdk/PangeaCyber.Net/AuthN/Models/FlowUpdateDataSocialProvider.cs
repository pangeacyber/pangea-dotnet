using Newtonsoft.Json;

namespace PangeaCyber.Net.AuthN.Models
{
    /// <summary>
    ///
    /// </summary>
    public class FlowUpdateDataSocialProvider : FlowUpdateData
    {
        /// <summary>
        ///
        /// </summary>
        [JsonProperty("social_provider")]
        public string SocialProvider { get; private set; }

        /// <summary>
        ///
        /// </summary>
        [JsonProperty("uri")]
        public string Uri { get; private set; }

        /// <summary>
        ///
        /// </summary>
        /// <param name="builder"></param>
        private FlowUpdateDataSocialProvider(Builder builder) : base(builder)
        {
            SocialProvider = builder.SocialProvider;
            Uri = builder.Uri;
        }

        /// <summary>
        ///
        /// </summary>
        new public class Builder : FlowUpdateData.Builder
        {
            /// <summary>
            ///
            /// </summary>
            public string SocialProvider { get; }

            /// <summary>
            ///
            /// </summary>
            public string Uri { get; }

            /// <summary>
            ///
            /// </summary>
            /// <param name="socialProvider"></param>
            /// <param name="uri"></param>
            public Builder(string socialProvider, string uri)
            {
                SocialProvider = socialProvider;
                Uri = uri;
            }

            /// <summary>
            ///
            /// </summary>
            /// <returns></returns>
            public FlowUpdateDataSocialProvider Build()
            {
                return new FlowUpdateDataSocialProvider(this);
            }
        }
    }
}
