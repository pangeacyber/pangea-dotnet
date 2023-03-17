using System;
using System.Runtime.InteropServices;
using Newtonsoft.Json;

namespace PangeaCyber.Net.Audit
{
    /// <kind>class</kind>
    /// <summary>
    /// Root
    /// </summary>
    public class Root
    {
        ///
        [JsonProperty("tree_name")]
        public string TreeName { get; private set; } = default!;

        ///
        [JsonProperty("size")]
        public int Size { get; private set; } = default!;

        ///
        [JsonProperty("root_hash")]
        public string RootHash { get; private set; } = default!;

        ///
        [JsonProperty("url")]
        public string URL { get; private set; } = default!;

        ///
        [JsonProperty("published_at")]
        public string PublishedAt { get; private set; } = default!;

        ///
        [JsonProperty("consistency_proof")]
        public string[] ConsistencyProof { get; private set; } = default!;
    }
}
