using Newtonsoft.Json;

namespace PangeaCyber.Net.Vault.Requests
{
    ///
    public class EncryptRequest : BaseRequest
    {
        ///
        [JsonProperty("id")]
        public string ID { get; private set; }

        ///
        [JsonProperty("plain_text")]
        public string PlainText { get; private set; }

        ///
        [JsonProperty("version")]
        public int? Version { get; private set; }

        ///
        [JsonProperty("additional_data")]
        public string? AdditionalData { get; private set; }

        ///
        protected EncryptRequest(Builder builder)
        {
            ID = builder.ID;
            PlainText = builder.PlainText;
            Version = builder.Version;
            AdditionalData = builder.AdditionalData;
        }

        ///
        public class Builder
        {
            ///
            public string ID { get; private set; }
            ///
            public string PlainText { get; private set; }
            ///
            public int? Version { get; private set; }
            ///
            public string? AdditionalData { get; private set; }

            ///
            public Builder(string id, string plainText)
            {
                ID = id;
                PlainText = plainText;
            }

            ///
            public EncryptRequest Build()
            {
                return new EncryptRequest(this);
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
