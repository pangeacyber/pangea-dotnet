using Newtonsoft.Json;
using PangeaCyber.Net.Vault.Models;

namespace PangeaCyber.Net.Vault.Requests
{
    ///
    public class UpdateRequest : BaseRequest
    {
        ///
        [JsonProperty("id")]
        public string ID { get; private set; }

        ///
        [JsonProperty("name")]
        public string? Name { get; private set; }

        ///
        [JsonProperty("folder")]
        public string? Folder { get; private set; }

        ///
        [JsonProperty("metadata")]
        public Metadata? Metadata { get; private set; }

        ///
        [JsonProperty("tags")]
        public Tags? Tags { get; private set; }

        ///
        [JsonProperty("rotation_frequency")]
        public string? RotationFrequency { get; private set; }

        ///
        [JsonProperty("rotation_state")]
        public string? RotationState { get; private set; }

        ///
        [JsonProperty("rotation_grace_period")]
        public string? RotationGracePeriod { get; private set; }

        ///
        [JsonProperty("expiration")]
        public string? Expiration { get; private set; }

        ///
        public UpdateRequest(Builder builder)
        {
            ID = builder.ID;
            Name = builder.Name;
            Folder = builder.Folder;
            Metadata = builder.Metadata;
            Tags = builder.Tags;
            RotationFrequency = builder.RotationFrequency;
            RotationState = builder.RotationState;
            RotationGracePeriod = builder.RotationGracePeriod;
            Expiration = builder.Expiration;
        }

        ///
        public class Builder
        {
            ///
            public string ID { get; private set; }
            ///
            public string? Name { get; private set; }
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
            public string? RotationGracePeriod { get; private set; }

            ///
            public Builder(string id)
            {
                ID = id;
            }

            ///
            public UpdateRequest Build()
            {
                return new UpdateRequest(this);
            }

            ///
            public Builder WithName(string name)
            {
                Name = name;
                return this;
            }

            ///
            public Builder WithFolder(string folder)
            {
                Folder = folder;
                return this;
            }

            ///
            public Builder WithMetadata(Metadata metadata)
            {
                Metadata = metadata;
                return this;
            }

            ///
            public Builder WithTags(Tags tags)
            {
                Tags = tags;
                return this;
            }

            ///
            public Builder WithAutoRotate(bool? autoRotate)
            {
                AutoRotate = autoRotate;
                return this;
            }

            ///
            public Builder WithRotationFrequency(string rotationFrequency)
            {
                RotationFrequency = rotationFrequency;
                return this;
            }

            ///
            public Builder WithRotationState(string rotationState)
            {
                RotationState = rotationState;
                return this;
            }

            ///
            public Builder WithExpiration(string expiration)
            {
                Expiration = expiration;
                return this;
            }

            ///
            public Builder WithRotationGracePeriod(string rotationGracePeriod)
            {
                RotationGracePeriod = rotationGracePeriod;
                return this;
            }
        }
    }
}
