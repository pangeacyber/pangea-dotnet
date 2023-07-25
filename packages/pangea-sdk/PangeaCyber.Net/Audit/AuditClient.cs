using PangeaCyber.Net.Audit.arweave;
using PangeaCyber.Net.Exceptions;
using PangeaCyber.Net.Audit.Utils;
using Newtonsoft.Json;

namespace PangeaCyber.Net.Audit
{
    /// <kind>class</kind>
    /// <summary>
    /// Audit Client
    /// </summary>
    public class AuditClient : BaseClient<AuditClient.Builder>
    {
        ///
        public static string ServiceName {get; }= "audit";

        ///
        private static bool supportMultiConfig = true;

        ///
        private LogSigner? signer;

        ///
        private Dictionary<int, PublishedRoot> publishedRoots;

        ///
        private bool allowServerRoots = true;    // In case of Arweave failure, ask the server for the roots

        ///
        private string prevUnpublishedRoot = default!;

        ///
        private string? tenantID;

        ///
        private Type customSchemaClass;

        ///
        private Dictionary<string, string> pkInfo;

        /// Constructor
        protected AuditClient(AuditClient.Builder builder) : base(builder, ServiceName, supportMultiConfig)
        {
            this.signer = !string.IsNullOrEmpty(builder.privateKeyFilename)? new LogSigner(builder.privateKeyFilename!) : null;
            this.publishedRoots = new Dictionary<int, PublishedRoot>();
            this.customSchemaClass = builder.customSchemaClass;
            this.tenantID = builder.tenantID;
            this.pkInfo = builder.pkInfo ?? new Dictionary<string, string>();
        }

        private async Task<Response<LogResult>> logPost(IEvent evt, bool? verbose, string signature, string publicKey, bool verify)
        {
            string prevRoot = default!;
            if (verify)
            {
                verbose = true;
                prevRoot = this.prevUnpublishedRoot;
            }
            LogRequest request = new LogRequest(evt, verbose ?? false, signature, publicKey, prevRoot);
            return await DoPost<LogResult>("/v1/log", request);
        }

        private Task processLogResponse(LogResult result, bool verify)
        {
            string newUnpublishedRoot = result.UnpublishedRoot;
            if(result.RawEnvelope != null){
                result.EventEnvelope = EventEnvelope.FromRaw(result.RawEnvelope, this.customSchemaClass)!;
                if (verify)
                {
                    result.VerifySignature();
                    EventEnvelope.VerifyHash(result.RawEnvelope, result.Hash);
                    if (newUnpublishedRoot != null)
                    {
                        result.MembershipVerification = Verification.VerifyMembershipProof(newUnpublishedRoot, result.Hash, result.MembershipProof);
                        if (result.ConsistencyProof != null && this.prevUnpublishedRoot != null)
                        {
                            ConsistencyProof conProof = Verification.DecodeConsistencyProof(result.ConsistencyProof);
                            result.ConsistencyVerification = Verification.VerifyConsistencyProof(newUnpublishedRoot, this.prevUnpublishedRoot, conProof);
                        }
                    }
                }

                if (newUnpublishedRoot != null)
                {
                    this.prevUnpublishedRoot = newUnpublishedRoot;
                }
            }

            return Task.CompletedTask;
        }

        /// <kind>method</kind>
        /// <summary>
        /// Log an event to Audit Secure Log. By default does not sign event and verbose is left as server default
        /// </summary>
        /// <remarks>Log an entry</remarks>
        /// <operationid>audit_post_v1_log</operationid>
        /// <param name="evt" type="PangeaCyber.Net.Audit.IEvent">Event to log</param>
        /// <param name="config">Include verbosity, local signature and verify events setup</param>
        /// <returns>Response&lt;LogResult&gt;</returns>
        /// <exception cref="PangeaException"></exception>
        /// <exception cref="PangeaAPIException"></exception>
        /// <example>
        /// <code>
        /// string msg = "Event's message";
        /// Event event = new Event.Builder(msg).Build();
        /// var response = await client.log(event, new LogConfig.Builder().Build());
        /// </code>
        /// </example>
        public async Task<Response<LogResult>> Log(IEvent evt, LogConfig config)
        {
            string signature = default!;
            string publicKey = default!;

            if(string.IsNullOrEmpty(evt.GetTenantID()) && this.tenantID != default){
                evt.SetTenantID(this.tenantID);
            }

            if (config.SignLocal && this.signer == null)
            {
                throw new SignerException("Signer not initialized", new Exception("Signer not initialized"));
            }
            else if (config.SignLocal && this.signer != null)
            {
                string canEvent;
                try
                {
                    canEvent = IEvent.Canonicalize(evt);
                }
                catch (Exception e)
                {
                    throw new SignerException("Failed to convert event to string", e);
                }

                signature = this.signer.Sign(canEvent);
                publicKey = this.GetPublicKeyData();
            }

            Response<LogResult> response = await logPost(evt, config.Verbose, signature, publicKey, config.Verify);
            await processLogResponse(response.Result, config.Verify);
            return response;
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
        /// var response = await client.GetRoot();
        /// </code>
        /// </example>
        public async Task<Response<RootResult>> GetRoot()
        {
            return await this.rootPost(default!);
        }

        /// <kind>method</kind>
        /// <summary>Return current root hash and consistency proof.</summary>
        /// <remarks>Tamperproof Verification</remarks>
        /// <operationid>audit_post_v1_root</operationid>
        /// <param name="treeSize" type="System.Int32">tree size to get root</param>
        /// <returns>Response&lt;RootResult&gt;</returns>
        /// <exception cref="PangeaException"></exception>
        /// <exception cref="PangeaAPIException"></exception>
        /// <example>
        /// <code>
        /// var response = await client.GetRoot(treeSize);
        /// </code>
        /// </example>
        public async Task<Response<RootResult>> GetRoot(int? treeSize)
        {
            return await rootPost(treeSize);
        }

        private async Task processSearchResult(ResultsOutput result, SearchConfig config)
        {
            foreach (SearchEvent searchEvent in result.Events)
            {
                searchEvent.EventEnvelope = EventEnvelope.FromRaw(searchEvent.RawEnvelope, this.customSchemaClass)!;
            }

            if (config.VerifyEvents)
            {
                foreach (SearchEvent searchEvent in result.Events)
                {
                    EventEnvelope.VerifyHash(searchEvent.RawEnvelope, searchEvent.Hash);
                    searchEvent.VerifySignature();
                }
            }

            Root root = result.Root;
            Root UnpublishedRoot = result.UnpublishedRoot;

            if (config.VerifyConsistency)
            {
                if (root != null)
                {
                    await updatePublishedRoots(result);
                }

                foreach (SearchEvent searchEvent in result.Events)
                {
                    string rootHash = "";
                    if (searchEvent.Published)
                    {
                        rootHash = root?.RootHash ?? "";
                    }
                    else
                    {
                        rootHash = UnpublishedRoot.RootHash;
                    }

                    searchEvent.VerifyMembershipProof(rootHash);
                    searchEvent.VerifyConsistency(this.publishedRoots);
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
                if (searchEvent.Published)
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
            treeSizes.RemoveWhere(this.publishedRoots.ContainsKey);

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
                    this.publishedRoots.Add(treeSize, arweaveRoots[treeSize]);
                }
                else if (allowServerRoots)
                {
                    Response<RootResult> response;
                    try
                    {
                        response = await this.GetRoot(treeSize);

                        Root localRoot = response.Result.Root;
                        PublishedRoot pubRoot = new PublishedRoot(root.Size, root.RootHash, root.PublishedAt, root.ConsistencyProof, "pangea");
                        this.publishedRoots[treeSize] = pubRoot;
                    }
                    catch (Exception)
                    {
                        break;
                    }
                }
            }
        }

        /// <kind>method</kind>
        /// <summary>Perform a search of logs according to input param. By default verify logs consistency and events hash and signature.</summary>
        /// <remarks>Search</remarks>
        /// <operationid>audit_post_v1_search</operationid>
        /// <param name="request">Request to be sent to /search endpoint</param>
        /// <param name="config">Config include event and consistency verification setup</param>
        /// <returns>Response&lt;SearchOutput&gt;</returns>
        /// <exception cref="PangeaException"></exception>
        /// <exception cref="PangeaAPIException"></exception>
        /// <example>
        /// <code>
        /// var input = new SearchInput("message:Integration test msg");
        /// input.setMaxResults(10);
        /// var response = Client.Search(input);
        /// </code>
        /// </example>
        public async Task<Response<SearchOutput>> Search(SearchRequest request, SearchConfig config)
        {
            Response<SearchOutput> response = await DoPost<SearchOutput>("/v1/search", request);
            await processSearchResult(response.Result, config);
            return response;
        }

        /// <kind>method</kind>
        /// <summary>Return result's page from search id.</summary>
        /// <remarks>Results</remarks>
        /// <operationid>audit_post_v1_results</operationid>
        /// <param name="request">Request to be sent to /results endpoint</param>
        /// <param name="config">Config include event and consistency verification setup</param>
        /// <returns>Response&lt;ResultsOutput&gt;</returns>
        /// <exception cref="PangeaException"></exception>
        /// <exception cref="PangeaAPIException"></exception>
        public async Task<Response<ResultsOutput>> Results(ResultRequest request, SearchConfig config)
        {
            var response = await DoPost<ResultsOutput>("/v1/results", request);
            await processSearchResult(response.Result, config);
            return response;
        }

        private string GetPublicKeyData(){
            try {
                if(this.signer != null){
                    this.pkInfo.Add("key", this.signer.GetPublicKey());
                    this.pkInfo.Add("algorithm", this.signer.GetAlgorithm());
                }
                return JsonConvert.SerializeObject(this.pkInfo);
            } catch (Exception e) {
                throw new PangeaException("Failed to stringify public key info", e);
            }
        }

        /// <kind>class</kind>
        /// <summary>
        /// AuditClient Builder
        /// </summary>
        public class Builder : BaseClient<AuditClient.Builder>.ClientBuilder
        {

            ///
            public string? privateKeyFilename = null;

            ///
            public string? tenantID = null;

            ///
            public Type customSchemaClass = typeof(StandardEvent);

            ///
            public Dictionary<string, string>? pkInfo = null;

            ///
            public Builder(Config config) : base(config)
            {
            }

            /// Add a private key in case want to use local signature
            public Builder WithPrivateKey(string privateKeyFilename)
            {
                this.privateKeyFilename = privateKeyFilename;
                return this;
            }

            /// Add a tenant ID to be sent in each logged event
            public Builder WithTenantID(string tenantID)
            {
                this.tenantID = tenantID;
                return this;
            }

            /// Setup user custom schema 
            public Builder WithCustomSchema<TEventType>() where TEventType : IEvent
            {
                if (!typeof(IEvent).IsAssignableFrom(typeof(TEventType)))
                {
                    throw new ArgumentException("TEventType must implement IEvent");
                }

                customSchemaClass = typeof(TEventType);
                return this;
            }

            /// Add extra public key information
            public Builder WithPKInfo(Dictionary<string, string> pkInfo){
                this.pkInfo = pkInfo;
                return this;
            }

            /// Build an AuditClient
            public AuditClient Build()
            {
                return new AuditClient(this);
            }
        }

    }

}

