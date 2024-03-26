using Newtonsoft.Json;
using PangeaCyber.Net.AuthZ.Models;

namespace PangeaCyber.Net.AuthZ.Results
{
    /// <kind>class</kind>
    /// <summary>
    /// ListSubjectsResult
    /// </summary>
    public sealed class ListSubjectsResult
    {
        ///
        [JsonProperty("subjects")]
        public Subject[] Subjects { get; private set; } = { };

    }
}
