using Newtonsoft.Json;
using PangeaCyber.Net.Share.Models;

namespace PangeaCyber.Net.Share.Requests
{
    ///
    public class GetArchiveRequest : BaseRequest
    {
        /// <summary>The bucket to use, if not the default.</summary>
        [JsonProperty("bucket_id")]
        public string? BucketID { get; set; }

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
