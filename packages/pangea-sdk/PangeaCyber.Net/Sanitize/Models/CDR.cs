using Newtonsoft.Json;

namespace PangeaCyber.Net.Sanitize
{
    /// <summary>Content Disarm and Reconstruct.</summary>
    public class CDR
    {
        /// <summary>Number of file attachments removed.</summary>
        [JsonProperty("file_attachments_removed")]
        public int? FileAttachmentsRemoved { get; set; }

        /// <summary>Number of interactive content items removed.</summary>
        [JsonProperty("interactive_contents_removed")]
        public int? InteractiveContentsRemoved { get; set; }

        /// <summary>Constructor.</summary>
        public CDR() { }
    }
}
