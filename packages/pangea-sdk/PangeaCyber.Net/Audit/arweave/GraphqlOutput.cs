using Newtonsoft.Json;

namespace PangeaCyber.Net.Audit.arweave
{
    /// <kind>class</kind>
    /// <summary>
    /// GraphqlOutput
    /// </summary>
    public class GraphqlOutput
    {
        ///
        [JsonProperty("data", Required = Required.AllowNull)]
        public Data Data { get; private set; } = default!;
    }


    ///
    public sealed class Data
    {
        ///
        [JsonProperty("transactions", Required = Required.AllowNull)]
        public Transactions Transactions { get; private set; } = default!;
    }

    ///
    public sealed class Transactions
    {
        ///
        [JsonProperty("edges", Required = Required.AllowNull)]
        public Edge[] Edges { get; private set; } = default!;
    }

    ///
    public sealed class Edge
    {
        ///
        [JsonProperty("node", Required = Required.AllowNull)]
        public Node Node { get; private set; } = default!;
    }

    ///
    public sealed class Node
    {
        ///
        [JsonProperty("id", Required = Required.AllowNull)]
        public string ID { get; private set; } = default!;

        ///
        [JsonProperty("tags", Required = Required.AllowNull)]
        public Tag[] Tags { get; private set; } = default!;
    }

    ///
    public sealed class Tag
    {
        ///
        [JsonProperty("name", Required = Required.AllowNull)]
        public string Name { get; private set; } = default!;

        ///
        [JsonProperty("value", Required = Required.AllowNull)]
        public object Value { get; private set; } = default!;
    }
}
