using Newtonsoft.Json;

namespace PangeaCyber.Net.Vault
{
    ///
    public class GetRequest : BaseRequest
    {
        ///
        [JsonProperty("id")]
        public string ID { get; private set; }

        ///
        [JsonProperty("version")]
        public string? Version { get; private set; }

        ///
        [JsonProperty("verbose")]
        public bool? Verbose { get; private set; }

        ///
        [JsonProperty("version_state")]
        public ItemVersionState? VersionState { get; private set; }

        ///
        protected GetRequest(Builder builder)
        {
            ID = builder.ID;
            Version = builder.Version;
            Verbose = builder.Verbose;
            VersionState = builder.VersionState;
        }

        ///
        public class Builder
        {
            ///
            public string ID { get; private set; }
            ///
            public string? Version { get; private set; }
            ///
            public bool? Verbose { get; private set; }
            ///
            public ItemVersionState? VersionState { get; private set; }

            ///
            public Builder(string id)
            {
                ID = id;
            }

            ///
            public GetRequest Build()
            {
                return new GetRequest(this);
            }

            ///
            public Builder WithVersion(string version)
            {
                Version = version;
                return this;
            }

            ///
            public Builder WithVerbose(bool verbose)
            {
                Verbose = verbose;
                return this;
            }

            ///
            public Builder WithVersionState(ItemVersionState versionState)
            {
                VersionState = versionState;
                return this;
            }
        }
    }
}
