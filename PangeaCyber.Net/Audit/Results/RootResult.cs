using System;
using System.Runtime.InteropServices;
using Newtonsoft.Json;

namespace PangeaCyber.Net.Audit
{
    /// <kind>class</kind>
    /// <summary>
    /// RootResult
    /// </summary>
    public class RootResult
    {
        ///
        [JsonProperty("data")]
        public Root Root { get; private set; } = default!;
    }
}
