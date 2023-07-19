using Newtonsoft.Json;

namespace PangeaCyber.Net.Vault
{
    ///
    public class DecryptRequest : BaseRequest
    {
        ///
        [JsonProperty("id")]
        public string ID { get; private set; }

        ///
        [JsonProperty("cipher_text")]
        public string CipherText { get; private set; }

        ///
        [JsonProperty("version")]
        public int? Version { get; private set; }

        ///
        [JsonProperty("additional_data")]
        public string? AdditionalData { get; private set; }

        ///
        protected DecryptRequest(Builder builder)
        {
            ID = builder.ID;
            CipherText = builder.CipherText;
            Version = builder.Version;
            AdditionalData = builder.AdditionalData;
        }

        ///
        public class Builder
        {
            ///
            public string ID { get; private set; }
            ///
            public string CipherText { get; private set; }
            ///
            public int? Version { get; private set; }
            ///
            public string? AdditionalData { get; private set; }

            ///
            public Builder(string id, string cipherText)
            {
                ID = id;
                CipherText = cipherText;
            }

            ///
            public DecryptRequest Build()
            {
                return new DecryptRequest(this);
            }

            ///
            public Builder WithVersion(int? version)
            {
                Version = version;
                return this;
            }

            ///
            public Builder WithAdditionalData(string additionalData)
            {
                AdditionalData = additionalData;
                return this;
            }
        }
    }
}
