using Newtonsoft.Json;
using PangeaCyber.Net.Vault.Models;

namespace PangeaCyber.Net.Vault.Requests
{
    ///
    public class CommonGenerateRequest<TBuilder> : BaseRequest where TBuilder : CommonGenerateRequest<TBuilder>.CommonBuilder
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

        /// <summary>Whether the key is exportable or not.</summary>
        [JsonProperty("exportable")]
        public bool Exportable { get; set; }

        ///
        protected CommonGenerateRequest(TBuilder builder)
        {
            Name = builder.Name;
            Folder = builder.Folder;
            Metadata = builder.Metadata;
            Tags = builder.Tags;
            RotationFrequency = builder.RotationFrequency;
            RotationState = builder.RotationState;
            Expiration = builder.Expiration;
            Exportable = builder.Exportable;
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

            /// <inheritdoc cref="AsymmetricStoreRequest.Exportable" />
            internal bool Exportable { get; set; }

            ///
            public CommonBuilder(string name)
            {
                Name = name;
            }

            ///
            public CommonGenerateRequest<TBuilder> Build()
            {
                return new CommonGenerateRequest<TBuilder>((TBuilder)this);
            }

            ///
            public TBuilder WithName(string name)
            {
                Name = name;
                return (TBuilder)this;
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

            /// <inheritdoc cref="Exportable" />
            public TBuilder WithExportable(bool exportable)
            {
                Exportable = exportable;
                return (TBuilder)this;
            }
        }
    }
}
