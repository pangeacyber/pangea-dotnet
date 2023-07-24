using Newtonsoft.Json;
using PangeaCyber.Net.Vault.Models;

namespace PangeaCyber.Net.Vault.Requests
{
    ///
    public class KeyRotateRequest : CommonRotateRequest<KeyRotateRequest.Builder>
    {
        ///
        [JsonProperty("public_key")]
        public string? EncodedPublicKey { get; private set; }

        ///
        [JsonProperty("private_key")]
        public string? EncodedPrivateKey { get; private set; }

        ///
        [JsonProperty("key")]
        public string? EncodedSymmetricKey { get; private set; }

        ///
        protected KeyRotateRequest(Builder builder) : base(builder)
        {
            EncodedPublicKey = builder.EncodedPublicKey;
            EncodedPrivateKey = builder.EncodedPrivateKey;
            EncodedSymmetricKey = builder.EncodedSymmetricKey;
        }

        ///
        public class Builder : CommonRotateRequest<Builder>.CommonBuilder
        {
            ///
            public string? EncodedPublicKey { get; private set; }
            ///
            public string? EncodedPrivateKey { get; private set; }
            ///
            public string? EncodedSymmetricKey { get; private set; }

            ///
            public Builder(string id, ItemVersionState rotationState) : base(id)
            {
                RotationState = rotationState;
            }

            ///
            public new KeyRotateRequest Build()
            {
                return new KeyRotateRequest(this);
            }

            ///
            public Builder WithEncodedPublicKey(string encodedPublicKey)
            {
                EncodedPublicKey = encodedPublicKey;
                return this;
            }

            ///
            public Builder WithEncodedPrivateKey(string encodedPrivateKey)
            {
                EncodedPrivateKey = encodedPrivateKey;
                return this;
            }

            ///
            public Builder WithEncodedSymmetricKey(string encodedSymmetricKey)
            {
                EncodedSymmetricKey = encodedSymmetricKey;
                return this;
            }
        }
    }
}
