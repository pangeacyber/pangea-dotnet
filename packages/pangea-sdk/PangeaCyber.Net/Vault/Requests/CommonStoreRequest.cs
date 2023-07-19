using Newtonsoft.Json;

namespace PangeaCyber.Net.Vault
{
    ///
    public class CommonStoreRequest<TBuilder> : BaseRequest where TBuilder : CommonStoreRequest<TBuilder>.CommonBuilder
    {
        ///
        [JsonProperty("name")]
        public string Name { get; set; }

        ///
        [JsonProperty("folder")]
        public string? Folder { get; set; }

        ///
        [JsonProperty("metadata")]
        public Metadata? Metadata { get; set; }

        ///
        [JsonProperty("tags")]
        public Tags? Tags { get; set; }

        ///
        [JsonProperty("rotation_frequency")]
        public string? RotationFrequency { get; set; }

        ///
        [JsonProperty("rotation_state")]
        public string? RotationState { get; set; }

        ///
        [JsonProperty("expiration")]
        public string? Expiration { get; set; }

        ///
        protected CommonStoreRequest(TBuilder builder)
        {
            Name = builder.Name;
            Folder = builder.Folder;
            Metadata = builder.Metadata;
            Tags = builder.Tags;
            RotationFrequency = builder.RotationFrequency;
            RotationState = builder.RotationState;
            Expiration = builder.Expiration;
        }

        ///
        public class CommonBuilder
        {
            ///
            public string Name { get; private set; }

            ///
            public string? Folder { get; private set; }

            ///
            public Metadata? Metadata { get; private set; }

            ///
            public Tags? Tags { get; private set; }

            ///
            public bool? AutoRotate { get; private set; }

            ///
            public string? RotationFrequency { get; private set; }

            ///
            public string? RotationState { get; private set; }

            ///
            public string? Expiration { get; private set; }

            ///
            public CommonBuilder(string name)
            {
                Name = name;
            }

            ///
            public CommonStoreRequest<TBuilder> Build()
            {
                return new CommonStoreRequest<TBuilder>((TBuilder)this);
            }

            ///
            public TBuilder WithFolder(string folder)
            {
                Folder = folder;
                return (TBuilder)this;
            }

            ///
            public TBuilder WithMetadata(Metadata metadata)
            {
                Metadata = metadata;
                return (TBuilder)this;
            }

            ///
            public TBuilder WithTags(Tags tags)
            {
                Tags = tags;
                return (TBuilder)this;
            }

            ///
            public TBuilder WithAutoRotate(bool? autoRotate)
            {
                AutoRotate = autoRotate;
                return (TBuilder)this;
            }

            ///
            public TBuilder WithRotationFrequency(string rotationFrequency)
            {
                RotationFrequency = rotationFrequency;
                return (TBuilder)this;
            }

            ///
            public TBuilder WithRotationState(string rotationState)
            {
                RotationState = rotationState;
                return (TBuilder)this;
            }

            ///
            public TBuilder WithExpiration(string expiration)
            {
                Expiration = expiration;
                return (TBuilder)this;
            }
        }
    }
}
