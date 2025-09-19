using System.Net.Http;
using System.Text;
using Newtonsoft.Json;

namespace PangeaCyber.Net.Audit.arweave
{
    /// <kind>class</kind>
    /// <summary>
    /// ArweaveRequest
    /// </summary>
    public sealed class ArweaveRequest
    {
        ///
        [JsonProperty("query")]
        string query { get; set; } = default!;

        ///
        public ArweaveRequest(string query)
        {
            this.query = query;
        }
    }

    /// <kind>class</kind>
    /// <summary>
    /// Arweave
    /// </summary>
    public class Arweave
    {
        ///
        public static string BaseURL = "https://arweave.net";

        ///
        public string TreeName { get; set; } = default!;

        ///
        public Arweave(string treeName)
        {
            this.TreeName = treeName;
        }

        private string getTransactionURL(string transactionID)
        {
            return String.Format("{0}/{1}/", BaseURL, transactionID);
        }

        private string getGraphqlURL()
        {
            return String.Format("{0}/graphql", BaseURL);
        }

        private string getQuery(int[] treeSizes)
        {
            string sizes = string.Join(", ", Array.ConvertAll(treeSizes, ele => String.Format("\"{0}\"", ele)));

            string query = @"
                {
                transactions(
                    tags: [
                            {
                                name: ""tree_size""
                                values: [{tree_sizes}]
                            },
                            {
                                name: ""tree_name""
                                values: [""{tree_name}""]
                            }
                        ]
                    ) {
                        edges {
                            node {
                                id
                                tags {
                                    name
                                    value
                                }
                            }
                        }
                    }
                }
                ".Replace("{tree_sizes}", sizes).Replace("{tree_name}", this.TreeName);

            return query;
        }

        private async Task<GraphqlOutput?> DoPostGraphql(int[] treeSizes)
        {
            var request = new ArweaveRequest(getQuery(treeSizes));
            string body;

            try
            {
                body = JsonConvert.SerializeObject(request);
            }
            catch (Exception)
            {
                return default;
            }

            using var localClient = new HttpClient();
            HttpResponseMessage httpResponse;

            try
            {
                var payload = new StringContent(body, Encoding.UTF8, "application/json");
                httpResponse = await localClient.PostAsync(new Uri(getGraphqlURL()), payload);
            }
            catch (Exception)
            {
                return default;
            }

            if (httpResponse.StatusCode != System.Net.HttpStatusCode.OK)
            {
                return default;
            }

            body = await httpResponse.Content.ReadAsStringAsync();
            GraphqlOutput response;
            try
            {
                var jsonSettings = new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore, DateParseHandling = DateParseHandling.None, DateFormatString = "yyyy'-'MM'-'dd'T'HH':'mm':'ss.fffffffK" };
                response = JsonConvert.DeserializeObject<GraphqlOutput>(body, jsonSettings) ?? default!;
            }
            catch (Exception)
            {
                return default;
            }
            return response;
        }

        private async Task<HttpResponseMessage?> doGet(string url)
        {
            using var localClient = new HttpClient();
            HttpResponseMessage httpResponse;

            try
            {
                httpResponse = await localClient.GetAsync(new Uri(url));
            }
            catch (Exception)
            {
                return default;
            }

            if (httpResponse.StatusCode == System.Net.HttpStatusCode.Found)
            {
                return await doGet(httpResponse?.Headers?.Location?.ToString() ?? "");
            }

            if (httpResponse.StatusCode != System.Net.HttpStatusCode.OK)
            {
                return default;
            }

            return httpResponse;
        }

        private async Task<PublishedRoot?> doGetRoot(string nodeID)
        {
            var httpResponse = await doGet(getTransactionURL(nodeID));
            if (httpResponse == null)
            {
                return default;
            }

            var body = await httpResponse.Content.ReadAsStringAsync();
            PublishedRoot root;
            try
            {
                var jsonSettings = new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore, DateParseHandling = DateParseHandling.None, DateFormatString = "yyyy'-'MM'-'dd'T'HH':'mm':'ss.fffffffK" };
                root = JsonConvert.DeserializeObject<PublishedRoot>(body, jsonSettings) ?? default!;
            }
            catch (Exception)
            {
                return default;
            }

            return root;
        }

        ///
        public async Task<Dictionary<int, PublishedRoot>> GetPublishedRoots(int[] treeSizes)
        {
            Dictionary<int, PublishedRoot> publishedRoots = new Dictionary<int, PublishedRoot>();

            var response = await DoPostGraphql(treeSizes);

            if (response?.Data != null)
            {
                foreach (Edge edge in response.Data.Transactions.Edges)
                {
                    string nodeID = edge.Node.ID;
                    Object value = default!;

                    foreach (Tag tag in edge.Node.Tags)
                    {
                        if (tag.Name.Equals("tree_size"))
                        {
                            value = tag.Value;
                            break;
                        }
                    }

                    if (value != null)
                    {
                        var root = await doGetRoot(nodeID);
                        if (root != null)
                        {
                            try
                            {
                                publishedRoots.Add(int.Parse((string)value), root);
                            }
                            catch (Exception)
                            {
                            }
                        }
                    }
                }
            }

            return publishedRoots;
        }
    }
}
