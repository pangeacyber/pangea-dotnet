using Newtonsoft.Json;

namespace PangeaCyber.Net.Embargo
{
    ///
    public class EmbargoSanctionAnnotationReference
    {
        ///
        [JsonProperty("paragraph")]
        public string Paragraph { get; set; } = default!;

        ///
        [JsonProperty("regulation")]
        public string Regulation { get; set; } = default!;
    }
}
