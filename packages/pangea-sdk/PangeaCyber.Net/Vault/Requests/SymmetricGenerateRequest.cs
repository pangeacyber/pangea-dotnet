using Newtonsoft.Json;

namespace PangeaCyber.Net.Vault
{
    ///
    public class SymmetricGenerateRequest : CommonGenerateRequest<SymmetricGenerateRequest.Builder>
    {
        ///
        [JsonProperty("type")]
        public ItemType Type { get; private set; }

        ///
        [JsonProperty("algorithm")]
        public SymmetricAlgorithm Algorithm { get; private set; }

        ///
        [JsonProperty("purpose")]
        public KeyPurpose Purpose { get; private set; }

        ///
        public SymmetricGenerateRequest(Builder builder)
            : base(builder)
        {
            Type = ItemType.SYMMETRIC_KEY;
            Algorithm = builder.Algorithm;
            Purpose = builder.Purpose;
        }

        ///
        public class Builder : CommonGenerateRequest<Builder>.CommonBuilder
        {
            ///
            public SymmetricAlgorithm Algorithm { get; private set; }

            ///
            public KeyPurpose Purpose { get; private set; }

            ///
            public Builder(SymmetricAlgorithm algorithm, KeyPurpose purpose, string name)
                : base(name)
            {
                Algorithm = algorithm;
                Purpose = purpose;
            }

            ///
            public new SymmetricGenerateRequest Build()
            {
                return new SymmetricGenerateRequest(this);
            }

            ///
            public Builder WithAlgorithm(SymmetricAlgorithm algorithm)
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
