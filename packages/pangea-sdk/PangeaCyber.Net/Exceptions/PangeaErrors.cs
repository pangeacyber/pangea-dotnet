using System;
using Newtonsoft.Json;

namespace PangeaCyber.Net
{
    /// <kind>class</kind>
    /// <summary>
    /// PangeaErrors
    /// </summary>
    public class PangeaErrors
    {

        ///
        [JsonProperty("errors")]
        public ErrorField[] Errors { get; private set; } = default!;

    }
}
