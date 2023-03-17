using System;
using System.Net.Http;
using System.Net.Mime;
using System.Text;
using Newtonsoft.Json;

using PangeaCyber.Net;
using PangeaCyber.Net.Audit.arweave;
using PangeaCyber.Net.Exceptions;
using PangeaCyber.Net.Audit.Utils;

namespace PangeaCyber.Net.Audit
{
    /// <kind>class</kind>
    /// <summary>
    /// Audit Client
    /// </summary>
    public class AuditClient : Client
    {
        ///
        public static string ServiceName = "audit";

        ///
        public LogSigner Signer;

        ///
        public Dictionary<int, PublishedRoot> PublishedRoots;

        ///
        public bool AllowServerRoots = true;    // In case of Arweave failure, ask the server for the roots

        ///
        public string PrevUnpublishedRoot = default!;

        ///
        public string TenantID = default!;

        /// Constructor
        public AuditClient(Config config) : base(config, ServiceName)
        {
            this.Signer = default!;
            this.PublishedRoots = new Dictionary<int, PublishedRoot>();
        }

        /// Constructor
        public AuditClient(Config config, string privateKeyFilename) : base(config, ServiceName)
        {
            this.Signer = new LogSigner(privateKeyFilename);
            this.PublishedRoots = new Dictionary<int, PublishedRoot>();
        }

        /// Constructor
        public AuditClient(Config config, string privateKeyFilename, string tenantID) : base(config, ServiceName)
        {
            this.Signer = !string.IsNullOrEmpty(privateKeyFilename) ? new LogSigner(privateKeyFilename) : default!;
            this.TenantID = tenantID;
            this.PublishedRoots = new Dictionary<int, PublishedRoot>();
        }

        private async Task<Response<LogResult>> logPost(Event requestEvent, bool verbose, string signature, string publicKey, bool verify)
        {
            string prevRoot = default!;
            if (verify)
            {
                verbose = true;
                prevRoot = this.PrevUnpublishedRoot;
            }
            LogRequest request = new LogRequest(requestEvent, verbose, signature, publicKey, prevRoot);
            return await DoPost<LogResult>("/v1/log", request);
        }

        private async Task<Response<LogResult>> doLog(Event requestEvent, SignMode signMode, bool verbose, bool verify)
        {
            string signature = default!;
            string publicKey = default!;

            requestEvent.TenantID = this.TenantID;

            if (signMode == SignMode.Local && this.Signer == null)
            {
                throw new SignerException("Signer not initialized", new Exception());
            }
            else if (signMode == SignMode.Local && this.Signer != null)
            {
                string canEvent;
                try
                {
                    canEvent = Event.Canonicalize(requestEvent);
                }
                catch (Exception e)
                {
                    throw new SignerException("Failed to convert event to string", e);
                }

                signature = this.Signer.Sign(canEvent);
                publicKey = this.Signer.GetPublicKey();
            }

            Response<LogResult> response = await logPost(requestEvent, verbose, signature, publicKey, verify);
            await processLogResponse(response.Result, verify);
            return response;
        }

        private Task processLogResponse(LogResult result, bool verify)
        {
            string newUnpublishedRoot = result.UnpublishedRoot;
            result.EventEnvelope = EventEnvelope.FromRaw(result.RawEnvelope);
            if (verify)
            {
                EventEnvelope.VerifyHash(result.RawEnvelope, result.Hash);
                result.VerifySignature();
                if (newUnpublishedRoot != null)
                {
                    result.MembershipVerification = Verification.VerifyMembershipProof(newUnpublishedRoot, result.Hash, result.MembershipProof);
                    if (result.ConsistencyProof != null && this.PrevUnpublishedRoot != null)
                    {
                        ConsistencyProof conProof = Verification.DecodeConsistencyProof(result.ConsistencyProof);
                        result.ConsistencyVerification = Verification.VerifyConsistencyProof(newUnpublishedRoot, this.PrevUnpublishedRoot, conProof);
                    }
                }
            }

            if (newUnpublishedRoot != null)
            {
                this.PrevUnpublishedRoot = newUnpublishedRoot;
            }

            return Task.CompletedTask;
        }

        /// <kind>method</kind>
        /// <summary>
        /// Log an event to Audit Secure Log. By default does not sign event and verbose is left as server default
        /// </summary>
        /// <remarks>Log an entry</remarks>
        /// <param name="requestEvent" type="PangeaCyber.Net.Audit.Event">Event to log</param>
        /// <returns>Response&lt;LogResult&gt;</returns>
        /// <exception cref="PangeaException"></exception>
        /// <exception cref="PangeaAPIException"></exception>
        /// <example>
        /// <code>
        ///     string msg = "Event's message";
        ///     Event event = new Event(msg);
        ///     var response = await client.log(event);
        /// </code>
        /// </example>
        public async Task<Response<LogResult>> Log(Event requestEvent)
        {
            return await this.doLog(requestEvent, SignMode.Unsigned, false, false);
        }

        /// <kind>method</kind>
        /// <summary>
        /// Log an event to Audit Secure Log. Can select sign event or not and verbosity of the response.
        /// </summary>
        /// <remarks>Log an entry - event, sign, verbose</remarks>
        /// <param name="requestEvent" type="PangeaCyber.Net.Audit.Event">Event to log</param>
        /// <param name="signMode" type="PangeaCyber.Net.Audit.SignMode">"Unsigned" or "Local"</param>
        /// <param name="verbose" type="System.Boolean">true to more verbose response</param>
        /// <param name="verify" type="System.Boolean">true to verify the hashes</param>
        /// <returns>Response&lt;LogResult&gt;</returns>
        /// <exception cref="PangeaException"></exception>
        /// <exception cref="PangeaAPIException"></exception>
        /// <example>
        /// <code>
        ///     string msg = "Event's message";
        ///     Event event = new Event(msg);
        ///     var response = await client.log(event, "Local", true, false);
        /// </code>
        /// </example>
        public async Task<Response<LogResult>> Log(Event requestEvent, SignMode signMode, bool verbose, bool verify)
        {
            return await this.doLog(requestEvent, signMode, verbose, verify);
        }

        private async Task<Response<RootResult>> rootPost(int? treeSize)
        {
            return await this.DoPost<RootResult>("/v1/root", new RootRequest(treeSize));
        }

        /// <kind>method</kind>
        /// <summary>Get last root from Pangea Server</summary>
        /// <remarks>Get last root</remarks>
        /// <returns>Response&lt;RootResult&gt;</returns>
        /// <exception cref="PangeaException"></exception>
        /// <exception cref="PangeaAPIException"></exception>
        /// <example>
        /// <code>
        ///     var response = await client.GetRoot();
        /// </code>
        /// </example>
        public async Task<Response<RootResult>> GetRoot()
        {
            return await this.rootPost(default!);
        }

        /// <kind>method</kind>
        /// <summary>Get last root from Pangea Server</summary>
        /// <remarks>Get root from three of treeSize from Pangea Server</remarks>
        /// <param name="treeSize" type="System.Int32">tree size to get root</param>
        /// <returns>Response&lt;RootResult&gt;</returns>
        /// <exception cref="PangeaException"></exception>
        /// <exception cref="PangeaAPIException"></exception>
        /// <example>
        /// <code>
        ///     var response = await client.GetRoot(treeSize);
        /// </code>
        /// </example>
        public async Task<Response<RootResult>> GetRoot(int? treeSize)
        {
            return await rootPost(treeSize);
        }

        private async Task processSearchResult(ResultsOutput result, bool VerifyConsistency, bool verifyEvents)
        {
            foreach (SearchEvent searchEvent in result.Events)
            {
                searchEvent.EventEnvelope = EventEnvelope.FromRaw(searchEvent.RawEnvelope);
            }

            if (verifyEvents)
            {
                foreach (SearchEvent searchEvent in result.Events)
                {
                    EventEnvelope.VerifyHash(searchEvent.RawEnvelope, searchEvent.Hash);
                    searchEvent.VerifySignature();
                }
            }

            Root root = result.Root;
            Root UnpublishedRoot = result.UnpublishedRoot;

            if (VerifyConsistency)
            {
                if (root != null)
                {
                    await updatePublishedRoots(result);
                }

                foreach (SearchEvent searchEvent in result.Events)
                {
                    string rootHash = "";
                    if (searchEvent.published)
                    {
                        rootHash = root?.RootHash ?? "";
                    }
                    else
                    {
                        rootHash = UnpublishedRoot.RootHash;
                    }

                    searchEvent.VerifyMembershipProof(rootHash);
                    searchEvent.VerifyConsistency(this.PublishedRoots);
                }
            }
        }

        private async Task updatePublishedRoots(ResultsOutput result)
        {
            Root root = result.Root;
            if (root == null)
            {
                return;
            }

            HashSet<int> treeSizes = new HashSet<int>();
            foreach (SearchEvent searchEvent in result.Events)
            {
                if (searchEvent.published)
                {
                    int? LeafIndex = searchEvent.LeafIndex;
                    if (LeafIndex.HasValue)
                    {
                        treeSizes.Add(LeafIndex.Value + 1);
                        if (LeafIndex.Value > 0)
                        {
                            treeSizes.Add(LeafIndex.Value);
                        }
                    }

                }
            }

            treeSizes.Add(root.Size);
            treeSizes.RemoveWhere(this.PublishedRoots.ContainsKey);

            int[] sizes = new int[treeSizes.Count];
            treeSizes.CopyTo(sizes);

            Dictionary<int, PublishedRoot> arweaveRoots;
            if (sizes.Length > 0)
            {
                Arweave arweave = new Arweave(root.TreeName);
                arweaveRoots = await arweave.GetPublishedRoots(sizes);
            }
            else
            {
                return;
            }

            foreach (int treeSize in sizes)
            {
                if (arweaveRoots.ContainsKey(treeSize))
                {
                    arweaveRoots[treeSize].Source = "arweave";
                    this.PublishedRoots.Add(treeSize, arweaveRoots[treeSize]);
                }
                else if (AllowServerRoots)
                {
                    Response<RootResult> response;
                    try
                    {
                        response = await this.GetRoot(treeSize);

                        Root localRoot = response.Result.Root;
                        PublishedRoot pubRoot = new PublishedRoot(root.Size, root.RootHash, root.PublishedAt, root.ConsistencyProof, "pangea");
                        this.PublishedRoots[treeSize] = pubRoot;
                    }
                    catch (Exception)
                    {
                        break;
                    }
                }
            }
        }

        private async Task<Response<SearchOutput>> SearchPost(SearchInput request, bool VerifyConsistency, bool verifyEvents)
        {
            Response<SearchOutput> response = await DoPost<SearchOutput>("/v1/search", request);
            await processSearchResult(response.Result, VerifyConsistency, verifyEvents);
            return response;
        }

        /// <kind>method</kind>
        /// <summary>Perform a search of logs according to input param. By default verify logs consistency and events hash and signature.</summary>
        /// <remarks>Search</remarks>
        /// <param name="input" type="PangeaCyber.Net.Audit.SearchInput">query filters to perform search</param>
        /// <returns>Response&lt;SearchOutput&gt;</returns>
        /// <exception cref="PangeaException"></exception>
        /// <exception cref="PangeaAPIException"></exception>
        /// <example>
        /// <code>
        ///     var input = new SearchInput("message:Integration test msg");
        ///     input.setMaxResults(10);
        ///     var response = Client.Search(input);
        /// </code>
        /// </example>
        public async Task<Response<SearchOutput>> Search(SearchInput input)
        {
            return await SearchPost(input, true, true);
        }

        /// <kind>method</kind>
        /// <summary>Perform a search of logs according to input param. Allow to select to verify or nor consistency proof and events.</summary>
        /// <remarks>Search - input, VerifyConsistency, verifyEvents</remarks>
        /// <param name="input" type="PangeaCyber.Net.Audit.SearchInput">query filters to perform search</param>
        /// <param name="VerifyConsistency" type="System.Boolean">true to verify logs consistency proofs</param>
        /// <param name="verifyEvents" type="System.Boolean">true to verify logs hash and signature</param>
        /// <returns>Response&lt;SearchOutput&gt;</returns>
        /// <exception cref="PangeaException"></exception>
        /// <exception cref="PangeaAPIException"></exception>
        /// <example>
        /// <code>
        ///     var input = new SearchInput("message:Integration test msg");
        ///     input.setMaxResults(10);
        ///     var response = Client.Search(input, true, true);
        /// </code>
        /// </example>
        public async Task<Response<SearchOutput>> Search(SearchInput input, bool VerifyConsistency, bool verifyEvents)
        {
            if (VerifyConsistency)
            {
                input.Verbose = true;
            }

            return await SearchPost(input, VerifyConsistency, verifyEvents);
        }

        private async Task<Response<ResultsOutput>> resultPost(string id, int limit, int offset, bool VerifyConsistency, bool verifyEvents)
        {
            var request = new ResultsRequest(id, limit, offset);
            var response = await DoPost<ResultsOutput>("/v1/results", request);
            await processSearchResult(response.Result, VerifyConsistency, verifyEvents);
            return response;
        }

        /// <kind>method</kind>
        /// <summary>Return result's page from search id.</summary>
        /// <remarks>Results</remarks>
        /// <param name="id" type="System.Int32">A search results identifier returned by the search call. By default verify events and do not verify consistency.</param>
        /// <param name="limit" type="System.Int32">Number of audit records to include in a single set of results.</param>
        /// <param name="offset" type="System.Int32">Offset from the start of the result set to start returning results from.</param>
        /// <returns>Response&lt;ResultsOutput&gt;</returns>
        /// <exception cref="PangeaException"></exception>
        /// <exception cref="PangeaAPIException"></exception>
        public async Task<Response<ResultsOutput>> Results(string id, int limit, int offset)
        {
            return await resultPost(id, limit, offset, false, true);
        }

        /// <kind>method</kind>
        /// <summary>"Return result's page from search id. Allow to select to verify or nor consistency proof and events.</summary>
        /// <remarks>Results - id, limit, offset, VerifyConsistency, verifyEvents</remarks>
        /// <param name="id" type="System.Int32">A search results identifier returned by the search call. By default verify events and do not verify consistency.</param>
        /// <param name="limit" type="System.Int32">Number of audit records to include in a single set of results.</param>
        /// <param name="offset" type="System.Int32">Offset from the start of the result set to start returning results from.</param>
        /// <param name="VerifyConsistency" type="System.Boolean">true to verify logs consistency proofs.</param>
        /// <param name="verifyEvents" type="System.Boolean">true to verify logs hash and signature.</param>
        /// <returns>Response&lt;ResultsOutput&gt;</returns>
        /// <exception cref="PangeaException"></exception>
        /// <exception cref="PangeaAPIException"></exception>
        public async Task<Response<ResultsOutput>> Results(string id, int limit, int offset, bool VerifyConsistency, bool verifyEvents)
        {
            return await resultPost(id, limit, offset, VerifyConsistency, verifyEvents);
        }
    }

    /// <kind>class</kind>
    /// <summary>
    /// AuditClient Builder
    /// </summary>
    public class AuditClientBuilder
    {
        private Config config;
        private string privateKeyFilename = default!;
        private string tenantID = default!;

        ///
        public AuditClientBuilder(Config config)
        {
            this.config = config;
        }

        ///
        public AuditClientBuilder WithPrivateKey(string privateKeyFilename)
        {
            this.privateKeyFilename = privateKeyFilename;
            return this;
        }


        ///
        public AuditClientBuilder WithTenantID(string tenantID)
        {
            this.tenantID = tenantID;
            return this;
        }


        ///
        public AuditClient Build()
        {
            return new AuditClient(this.config, this.privateKeyFilename, this.tenantID);
        }
    }

}

