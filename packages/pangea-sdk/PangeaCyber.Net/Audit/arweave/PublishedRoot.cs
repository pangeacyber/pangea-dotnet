using Newtonsoft.Json;

namespace PangeaCyber.Net.Audit.arweave
{
    /// <kind>class</kind>
    /// <summary>
    /// PublishedRoot
    /// </summary>
    public class PublishedRoot
    {
        ///
        [JsonProperty("size")]
        public int Size { get; private set; } = default!;

        ///
        [JsonProperty("root_hash")]
        public string RootHash { get; private set; } = default!;

        ///
        [JsonProperty("published_at")]
        public string PublishedAt { get; private set; } = default!;

        ///
        [JsonProperty("consistency_proof")]
        public string[] ConsistencyProof { get; private set; } = default!;

        ///
        [JsonIgnore]
        public string Source { get; set; } = "unknown";

        ///
        public PublishedRoot()
        {
        }

        ///
        public PublishedRoot(int size, string rootHash, string publishedAt, string[] ConsistencyProof, string source)
        {
            this.Size = size;
            this.RootHash = rootHash;
            this.PublishedAt = publishedAt;
            this.ConsistencyProof = ConsistencyProof;
            this.Source = source;
        }
    }
}
