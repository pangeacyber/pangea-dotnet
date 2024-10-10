using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using PangeaCyber.Net.Share.Models;

namespace PangeaCyber.Net.Share.Results
{
    /// <summary>Buckets.</summary>
    [JsonObject(NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
    public sealed class BucketsResult
    {
        /// <summary>A list of available buckets.</summary>
        public IList<Bucket> Buckets { get; set; } = new List<Bucket>();
    }
}
