using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace PangeaCyber.Net.Share.Models
{
    /// <summary>Bucket.</summary>
    [JsonObject(NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
    public sealed class Bucket
    {
        /// <summary>If true, is the default bucket.</summary>
        public bool Default { get; set; }

        /// <summary>The ID of a share bucket resource.</summary>
        public string ID { get; set; } = string.Empty;

        /// <summary>The bucket's friendly name.</summary>
        public string Name { get; set; } = string.Empty;

        /// <summary>Transfer methods.</summary>
        public IList<TransferMethod> TransferMethods { get; set; } = new List<TransferMethod>();
    }
}
