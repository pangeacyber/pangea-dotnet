using Newtonsoft.Json;

namespace PangeaCyber.Net.Vault
{
    ///
    public class DeleteRequest : BaseRequest
    {
        ///
        [JsonProperty("id")]
        public string ID { get; private set; }

        ///
        private DeleteRequest(Builder builder)
        {
            ID = builder.ID;
        }

        ///
        public class Builder
        {
            ///
            public string ID { get; private set; }

            ///
            public Builder(string id)
            {
                ID = id;
            }

            ///
            public DeleteRequest Build()
            {
                return new DeleteRequest(this);
            }
        }
    }
}
