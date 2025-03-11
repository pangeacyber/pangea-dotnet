using Newtonsoft.Json;

namespace PangeaCyber.Net.Redact
{
    /// <kind>class</kind>
    /// <summary>
    /// UnredactResult
    /// </summary>
    /// <typeparam name="T">Structured data type.</typeparam>
    public sealed class UnredactResult<T>
    {
        /// <summary>The unredacted data</summary>
        [JsonProperty("data")]
        public T Data { get; private set; } = default!;
    }
}
