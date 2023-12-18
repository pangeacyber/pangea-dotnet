using Newtonsoft.Json;

namespace PangeaCyber.Net.Intel
{
    ///
    public class IPGeolocateBulkResult : IntelCommonResult
    {
        ///
        [JsonProperty("data")]
        public IPGeolocateBulkData Data { get; private set; } = new IPGeolocateBulkData();


    }
}
