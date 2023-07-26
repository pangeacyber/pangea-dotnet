using Newtonsoft.Json;

namespace PangeaCyber.Net.Intel
{
    ///
    public class IPGeolocateData
    {
        ///
        [JsonProperty("country")]
        public string Country { get; set; } = default!;

        ///
        [JsonProperty("city")]
        public string City { get; set; } = default!;

        ///
        [JsonProperty("latitude")]
        public float Latitude { get; set; }

        ///
        [JsonProperty("longitude")]
        public float Longitude { get; set; }

        ///
        [JsonProperty("postal_code")]
        public string PostalCode { get; set; } = default!;

        ///
        [JsonProperty("country_code")]
        public string CountryCode { get; set; } = default!;
    }
}
