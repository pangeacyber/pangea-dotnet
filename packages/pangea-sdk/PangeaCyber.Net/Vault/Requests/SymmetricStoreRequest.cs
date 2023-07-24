using Newtonsoft.Json;
using PangeaCyber.Net.Vault.Models;

namespace PangeaCyber.Net.Vault.Requests
{
    ///
    public class SymmetricStoreRequest : CommonStoreRequest<SymmetricStoreRequest.Builder>
    {
        ///
        [JsonProperty("type")]
        public ItemType Type { get; private set; }

        ///
        [JsonProperty("algorithm")]
        public SymmetricAlgorithm Algorithm { get; private set; }

        ///
        [JsonProperty("key")]
        public string EncodedSymmetricKey { get; set; }

        ///
        [JsonProperty("purpose")]
        public KeyPurpose Purpose { get; private set; }

        ///
        public SymmetricStoreRequest(Builder builder)
            : base(builder)
        {
            Type = ItemType.SymmetricKey;
            Algorithm = builder.Algorithm;
            EncodedSymmetricKey = builder.EncodedSymmetricKey;
            Purpose = builder.Purpose;
        }

        ///
        public class Builder : CommonStoreRequest<SymmetricStoreRequest.Builder>.CommonBuilder
        {
            ///
            public SymmetricAlgorithm Algorithm { get; private set; }

            ///
            public string EncodedSymmetricKey { get; private set; }

            ///
            public KeyPurpose Purpose { get; private set; }

            ///
            public Builder(string encodedSymmetricKey, SymmetricAlgorithm algorithm, KeyPurpose purpose, string name)
                : base(name)
            {
                Algorithm = algorithm;
                EncodedSymmetricKey = encodedSymmetricKey;
                Purpose = purpose;
            }

            ///
            public new SymmetricStoreRequest Build()
            {
                return new SymmetricStoreRequest(this);
            }

            ///
            public Builder WithPurpose(KeyPurpose purpose)
            {
                Purpose = purpose;
                return this;
            }
        }
    }
}
