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
        ///
        [JsonProperty("data")]
        public T data { get; private set; } = default!;
    }
}
