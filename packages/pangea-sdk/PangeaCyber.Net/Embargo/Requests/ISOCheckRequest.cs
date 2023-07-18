using Newtonsoft.Json;

namespace PangeaCyber.Net.Embargo
{
    ///
    public class ISOCheckRequest : BaseRequest
    {
        ///
        [JsonProperty("iso_code")]
        public string IsoCode { get; set; }

        ///
        public ISOCheckRequest(string isoCode)
        {
            IsoCode = isoCode;
        }

    }
}