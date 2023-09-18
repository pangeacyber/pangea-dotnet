using Newtonsoft.Json;

namespace PangeaCyber.Net
{
    /// <kind>class</kind>
    /// <summary>
    /// ErrorField
    /// </summary>
    public class ErrorField
    {
        // """
        // Field errors denote errors in fields provided in request payloads

        // Fields:
        //     code(str): The field code
        //     detail(str): A human readable detail explaining the error
        //     source(str): A JSON pointer where the error occurred
        //     path(str): If verbose mode was enabled, a path to the JSON Schema used to validate the field
        // """
        ///
        [JsonProperty("code")]
        public string Code { get; private set; } = default!;

        ///
        [JsonProperty("detail")]
        public string Detail { get; private set; } = default!;

        ///
        [JsonProperty("source")]
        public string Source { get; private set; } = default!;

        ///
        [JsonProperty("path")]
        public string Path { get; private set; } = default!;

        /// 
        public override string ToString()
        {
            return Source + " " + Code + ": " + Detail + ".";
        }
    }
}
