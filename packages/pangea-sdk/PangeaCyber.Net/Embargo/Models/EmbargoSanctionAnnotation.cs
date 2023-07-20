using Newtonsoft.Json;

namespace PangeaCyber.Net.Embargo
{
    ///
    public class EmbargoSanctionAnnotation
    {
        ///
        [JsonProperty("reference")]
        public EmbargoSanctionAnnotationReference Reference { get; set; } = new EmbargoSanctionAnnotationReference();

        ///
        [JsonProperty("restriction_name")]
        public string RestrictionName { get; set; } = default!;
    }
}
