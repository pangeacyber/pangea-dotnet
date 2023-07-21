using Newtonsoft.Json;

namespace PangeaCyber.Net.Embargo
{
    ///
    public class EmbargoSanction
    {
        ///
        [JsonProperty("embargoed_country_iso_code")]
        public string EmbargoedCountryISOCode { get; set; } = default!;

        ///
        [JsonProperty("issuing_country")]
        public string IssuingCountry { get; set; } = default!;

        ///
        [JsonProperty("list_name")]
        public string ListName { get; set; } = default!;

        ///
        [JsonProperty("embargoed_country_name")]
        public string EmbargoedCountryName { get; set; } = default!; 

        ///
        [JsonProperty("annotations")]
        public EmbargoSanctionAnnotation? Annotations { get; set; }
    }
}
