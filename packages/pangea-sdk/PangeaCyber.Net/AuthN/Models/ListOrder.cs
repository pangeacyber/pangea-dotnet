using Newtonsoft.Json;

namespace PangeaCyber.Net.AuthN.Models
{
    ///
    [JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
    public enum ListOrder
    {
        ///
        [JsonProperty("asc")]
        Ascending,
        
        ///
        [JsonProperty("desc")]
        Descending
    }
}
