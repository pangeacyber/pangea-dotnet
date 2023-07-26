using Newtonsoft.Json;

namespace PangeaCyber.Net.Intel
{
    ///
    public class IPGeolocateResult : IntelCommonResult
    {
        ///
        [JsonProperty("data")]
        public IPGeolocateData Data { get; set; } = new IPGeolocateData();

    }
}
