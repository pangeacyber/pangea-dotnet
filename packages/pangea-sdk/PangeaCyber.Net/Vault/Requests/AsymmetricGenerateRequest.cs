using Newtonsoft.Json;

namespace PangeaCyber.Net.Vault
{
    ///
    public class AsymmetricGenerateRequest : CommonGenerateRequest<AsymmetricGenerateRequest.Builder>
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
        protected AsymmetricGenerateRequest(Builder builder)
            : base(builder)
        {
            Type = ItemType.ASYMMETRIC_KEY;
            Algorithm = builder.Algorithm;
            Purpose = builder.Purpose;
        }

        ///
        public class Builder : CommonGenerateRequest<AsymmetricGenerateRequest.Builder>.CommonBuilder
        {
            ///
            public AsymmetricAlgorithm Algorithm { get; private set; }

            ///
            public KeyPurpose Purpose { get; private set; }

            ///
            public Builder(AsymmetricAlgorithm algorithm, KeyPurpose purpose, string name)
                : base(name)
            {
                Algorithm = algorithm;
                Purpose = purpose;
            }

            ///
            public new AsymmetricGenerateRequest Build()
            {
                return new AsymmetricGenerateRequest(this);
            }

            ///
            public Builder WithAlgorithm(AsymmetricAlgorithm algorithm)
            {
                Algorithm = algorithm;
                return this;
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
