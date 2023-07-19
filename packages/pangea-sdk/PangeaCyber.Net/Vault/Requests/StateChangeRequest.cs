using Newtonsoft.Json;

namespace PangeaCyber.Net.Vault
{
    ///
    public class StateChangeRequest : BaseRequest
    {
        ///
        [JsonProperty("id")]
        public string ID { get; private set; }

        ///
        [JsonProperty("version")]
        public int Version { get; private set; }

        ///
        [JsonProperty("state")]
        public ItemVersionState State { get; private set; }

        ///
        private StateChangeRequest(Builder builder)
        {
            ID = builder.ID;
            Version = builder.Version;
            State = builder.State;
        }

        ///
        public class Builder
        {
            ///
            public string ID { get; private set; }

            ///
            public int Version { get; private set; }

            ///
            public ItemVersionState State { get; private set; }

            ///
            public Builder(string id, int version, ItemVersionState state)
            {
                ID = id;
                Version = version;
                State = state;
            }

            ///
            public StateChangeRequest Build()
            {
                return new StateChangeRequest(this);
            }
        }
    }
}
