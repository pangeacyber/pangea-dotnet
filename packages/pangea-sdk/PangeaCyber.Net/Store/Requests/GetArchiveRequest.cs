using Newtonsoft.Json;
using PangeaCyber.Net.Store.Models;

namespace PangeaCyber.Net.Store.Requests
{
    ///
    public class GetArchiveRequest : BaseRequest
    {
        ///
        [JsonProperty("ids")]
        public List<string> IDs { get; set; } = new List<string>();

        ///
        [JsonProperty("format")]
        public ArchiveFormat? Format { get; set; }

        ///
        [JsonIgnore]
        public TransferMethod? RequestTransferMethod
        {
            set
            {
                TransferMethod = value;
            }
        }
    }
}
