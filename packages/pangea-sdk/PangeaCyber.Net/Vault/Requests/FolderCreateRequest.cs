using Newtonsoft.Json;
using PangeaCyber.Net.Vault.Models;

namespace PangeaCyber.Net.Vault.Requests
{
    ///
    public class FolderCreateRequest : BaseRequest
    {
        ///
        [JsonProperty("name")]
        public string Name { get; private set; }

        ///
        [JsonProperty("folder")]
        public string Folder { get; private set; }

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
        protected FolderCreateRequest(Builder builder)
        {
            Name = builder.Name;
            Folder = builder.Folder;
            Metadata = builder.Metadata;
            Tags = builder.Tags;
            RotationFrequency = builder.RotationFrequency;
            RotationState = builder.RotationState;
            RotationGracePeriod = builder.RotationGracePeriod;
        }

        ///
        public class Builder
        {
            ///
            public string Name { get; private set; }
            ///
            public string Folder { get; private set; }
            ///
            public Metadata? Metadata { get; private set; }
            ///
            public Tags? Tags { get; private set; }

            ///
            public string? RotationFrequency { get; private set; }
            ///
            public string? RotationState { get; private set; }
            ///
            public string? RotationGracePeriod { get; private set; }

            ///
            public Builder(string name, string folder)
            {
                Name = name;
                Folder = folder;
            }

            ///
            public FolderCreateRequest Build()
            {
                return new FolderCreateRequest(this);
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
            public Builder WithRotationGracePeriod(string rotationGracePeriod)
            {
                RotationGracePeriod = rotationGracePeriod;
                return this;
            }
        }
    }
}
