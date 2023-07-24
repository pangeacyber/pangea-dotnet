using Newtonsoft.Json;
using PangeaCyber.Net.Vault.Models;

namespace PangeaCyber.Net.Vault.Requests
{
    ///
    public class AsymmetricStoreRequest : CommonStoreRequest<AsymmetricStoreRequest.Builder>
    {
        ///
        [JsonProperty("type")]
        public ItemType Type { get; private set; }

        ///
        [JsonProperty("algorithm")]
        public AsymmetricAlgorithm Algorithm { get; private set; }

        ///
        [JsonProperty("purpose")]
        public KeyPurpose Purpose { get; private set; }

        ///
        [JsonProperty("public_key")]
        public string EncodedPublicKey { get; set; }

        ///
        [JsonProperty("private_key")]
        public string EncodedPrivateKey { get; set; }

        ///
        protected AsymmetricStoreRequest(Builder builder)
            : base(builder)
        {
            Type = ItemType.AsymmetricKey;
            Algorithm = builder.Algorithm;
            Purpose = builder.Purpose;
            EncodedPublicKey = builder.EncodedPublicKey;
            EncodedPrivateKey = builder.EncodedPrivateKey;
        }

        ///
        public class Builder : CommonStoreRequest<AsymmetricStoreRequest.Builder>.CommonBuilder
        {
            ///
            public AsymmetricAlgorithm Algorithm { get; private set; }

            ///
            public KeyPurpose Purpose { get; private set; }

            ///
            public string EncodedPublicKey { get; private set; }

            ///
            public string EncodedPrivateKey { get; private set; }

            ///
            public Builder(
                string encodedPrivateKey,
                string encodedPublicKey,
                AsymmetricAlgorithm algorithm,
                KeyPurpose purpose,
                string name)
                : base(name)
            {
                Algorithm = algorithm;
                Purpose = purpose;
                EncodedPublicKey = encodedPublicKey;
                EncodedPrivateKey = encodedPrivateKey;
            }

            ///
            public new AsymmetricStoreRequest Build()
            {
                return new AsymmetricStoreRequest(this);
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
