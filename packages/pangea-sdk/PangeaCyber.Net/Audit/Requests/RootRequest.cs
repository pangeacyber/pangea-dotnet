using System;
using Newtonsoft.Json;

namespace PangeaCyber.Net.Audit
{
    /// <kind>class</kind>
    /// <summary>
    /// RootRequest
    /// </summary>
    public sealed class RootRequest : BaseRequest
    {
        ///
        [JsonProperty("tree_size")]
        int? TreeSize;

        ///
        public RootRequest(int? treeSize)
        {
            this.TreeSize = treeSize;
        }
    }
}

