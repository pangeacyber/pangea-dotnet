using Newtonsoft.Json;

namespace PangeaCyber.Net.Vault
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
        protected FolderCreateRequest(Builder builder)
        {
            Name = builder.Name;
            Folder = builder.Folder;
            Metadata = builder.Metadata;
            Tags = builder.Tags;
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
        }
    }
}
