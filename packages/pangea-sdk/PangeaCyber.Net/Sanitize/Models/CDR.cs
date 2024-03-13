using Newtonsoft.Json;

namespace PangeaCyber.Net.Sanitize
{
    ///
    public class CDR
    {
        ///
        [JsonProperty("file_attachments_removed")]
        public int? FileAttachmentsRemoved { get; set; }

        ///
        [JsonProperty("interactive_contents_removed")]
        public int? InteractiveContentsRemoved { get; set; }

        ///
        public CDR() { }
    }
}
