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

        /// <summary>The IDs of the objects to include in the archive. Folders include all children.</summary>
        [JsonProperty("ids")]
        public List<string> IDs { get; set; } = new List<string>();

        /// <summary>The format to use to build the archive.</summary>
        [JsonProperty("format")]
        public ArchiveFormat? Format { get; set; }

        /// <summary>The requested transfer method for the file data.</summary>
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
