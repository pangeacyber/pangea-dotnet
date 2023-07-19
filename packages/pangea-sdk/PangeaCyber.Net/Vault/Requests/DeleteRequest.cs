using Newtonsoft.Json;

namespace PangeaCyber.Net.Vault
{
    ///
    public class DeleteRequest : BaseRequest
    {
        ///
        [JsonProperty("id")]
        public string Id { get; private set; }

        ///
        private DeleteRequest(Builder builder)
        {
            Id = builder.Id;
        }

        ///
        public class Builder
        {
            ///
            public string Id { get; private set; }

            ///
            public Builder(string id)
            {
                Id = id;
            }

            ///
            public DeleteRequest Build()
            {
                return new DeleteRequest(this);
            }
        }
    }
}
