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
        public static string ServiceName { get; } = "audit";

        ///
        private readonly LogSigner? Signer;

        ///
        private readonly Dictionary<int, PublishedRoot> PublishedRoots;

        ///
        private readonly bool AllowServerRoots = true;    // In case of Arweave failure, ask the server for the roots

        ///
        private string PrevUnpublishedRoot = default!;

        ///
        private readonly string? TenantID;

        ///
        private readonly Type CustomSchemaClass;

        ///
        private readonly Dictionary<string, string> PKInfo;

        /// Constructor
        protected AuditClient(Builder builder) : base(builder, ServiceName)
        {
            Signer = !string.IsNullOrEmpty(builder.privateKeyFilename) ? new LogSigner(builder.privateKeyFilename!) : null;
            PublishedRoots = new Dictionary<int, PublishedRoot>();
            CustomSchemaClass = builder.customSchemaClass;
            TenantID = builder.tenantID;
            PKInfo = builder.pkInfo ?? new Dictionary<string, string>();

            if (!string.IsNullOrEmpty(builder.configID))
            {
                ConfigID = builder.configID;
            }
            else if (!string.IsNullOrEmpty(builder.config.ConfigID))
            {
                ConfigID = builder.config.ConfigID;
            }

        }

        private LogBulkRequest GetLogBulkRequest(IEvent[] events, LogConfig config)
        {
            LogEvent[] logEvents = new LogEvent[events.Length];
            for (int i = 0; i < events.Length; i++)
            {
                logEvents[i] = GetLogEvent(events[i], config);
            }
            return new LogBulkRequest(logEvents, config.Verbose);
        }



        private LogRequest GetLogRequest(IEvent evt, LogConfig config)
        {
            LogEvent logEvent = GetLogEvent(evt, config);
            bool? verbose = config.Verbose;

            string prevRoot = default!;
            if (config.Verify)
            {
                verbose = true;
                prevRoot = PrevUnpublishedRoot;
            }

            return new LogRequest(logEvent.Event, verbose ?? false, logEvent.Signature, logEvent.PublicKey, prevRoot);
        }

        private Task ProcessLogResponse(LogResult result, bool verify)
        {
            string newUnpublishedRoot = result.UnpublishedRoot;
            if (result.RawEnvelope != null)
            {
                result.EventEnvelope = EventEnvelope.FromRaw(result.RawEnvelope, CustomSchemaClass)!;
                if (verify)
                {
                    result.VerifySignature();
                    EventEnvelope.VerifyHash(result.RawEnvelope, result.Hash);
                    if (newUnpublishedRoot != null)
                    {
                        result.MembershipVerification = Verification.VerifyMembershipProof(newUnpublishedRoot, result.Hash, result.MembershipProof);
                        if (result.ConsistencyProof != null && PrevUnpublishedRoot != null)
                        {
                            ConsistencyProof conProof = Verification.DecodeConsistencyProof(result.ConsistencyProof);
                            result.ConsistencyVerification = Verification.VerifyConsistencyProof(newUnpublishedRoot, PrevUnpublishedRoot, conProof);
                        }
                    }
                }

                if (newUnpublishedRoot != null)
                {
                    PrevUnpublishedRoot = newUnpublishedRoot;
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
        /// <param name="config" type="PangeaCyber.Net.Audit.LogConfig">Include verbosity, local signature and verify events setup</param>
        /// <returns>Response&lt;LogResult&gt;</returns>
        /// <exception cref="PangeaException"></exception>
        /// <exception cref="PangeaAPIException"></exception>
        /// <example>
        /// <code>
        /// string msg = "hello world";
        /// var event = new StandardEvent.Builder(msg)
        ///     .Build();
        ///
        /// var config = new LogConfig.Builder()
        ///     .WithVerbose(true)
        ///     .Build();
        ///
        /// var response = await client.Log(event, config);
        /// </code>
        /// </example>
        public async Task<Response<LogResult>> Log(IEvent evt, LogConfig config)
        {
            LogRequest request = GetLogRequest(evt, config);
            Response<LogResult> response = await DoPost<LogResult>("/v1/log", request);
            await ProcessLogResponse(response.Result, config.Verify);
            return response;
        }

        /// <kind>method</kind>
        /// <summary>
        /// Create multiple log entries in the Secure Audit Log.
        /// </summary>
        /// <remarks>Log multiple entries</remarks>
        /// <operationid>audit_post_v2_log</operationid>
        /// <param name="events" type="PangeaCyber.Net.Audit.IEvent[]">Events to log</param>
        /// <param name="config" type="PangeaCyber.Net.Audit.LogConfig">Include verbosity, local signature and verify events setup</param>
        /// <returns>Response&lt;LogBulkResult&gt;</returns>
        /// <exception cref="PangeaException"></exception>
        /// <exception cref="PangeaAPIException"></exception>
        /// <example>
        /// <code>
        /// var event = new StandardEvent.Builder("hello world").Build();
        /// StandardEvent[] events = {event};
        ///
        /// var response = await client.LogBulk(events, new LogConfig.Builder().Build());
        /// </code>
        /// </example>
        public async Task<Response<LogBulkResult>> LogBulk(IEvent[] events, LogConfig config)
        {
            LogBulkRequest request = GetLogBulkRequest(events, config);
            Response<LogBulkResult> response = await DoPost<LogBulkResult>("/v2/log", request);
            if (response.Result != null)
            {
                foreach (LogResult result in response.Result.Results)
                {
                    await ProcessLogResponse(result, config.Verify);
                }
            }
            return response;
        }

        /// <kind>method</kind>
        /// <summary>
        /// Asynchronously create multiple log entries in the Secure Audit Log.
        /// </summary>
        /// <remarks>Log multiple entries asynchronously</remarks>
        /// <operationid>audit_post_v2_log_async</operationid>
        /// <param name="events" type="PangeaCyber.Net.Audit.IEvent[]"></param>
        /// <param name="config" type="PangeaCyber.Net.Audit.LogConfig"></param>
        /// <returns>Response&lt;LogBulkResult&gt;</returns>
        /// <exception cref="PangeaException"></exception>
        /// <exception cref="PangeaAPIException"></exception>
        /// <example>
        /// <code>
        /// var event = new StandardEvent.Builder("hello world").Build();
        /// StandardEvent[] events = {event};
        ///
        /// var response = await client.LogBulkAsync(events, new LogConfig.Builder().Build());
        /// </code>
        /// </example>
        public async Task<Response<LogBulkResult>> LogBulkAsync(IEvent[] events, LogConfig config)
        {
            LogBulkRequest request = GetLogBulkRequest(events, config);
            Response<LogBulkResult> response;
            try
            {
                response = await DoPost<LogBulkResult>("/v2/log_async", request, new PostConfig.Builder().WithPollResult(false).Build());
            }
            catch (AcceptedRequestException e)
            {
                return new Response<LogBulkResult>(e.Response, e.AcceptedResult);
            }

            if (response.Result != null)
            {
                foreach (LogResult result in response.Result.Results)
                {
                    await ProcessLogResponse(result, config.Verify);
                }
            }
            return response;
        }

        private LogEvent GetLogEvent(IEvent evt, LogConfig config)
        {
            string signature = default!;
            string publicKey = default!;

            if (string.IsNullOrEmpty(evt.GetTenantID()) && TenantID != default)
            {
                evt.SetTenantID(TenantID);
            }

            if (config.SignLocal && Signer == null)
            {
                throw new SignerException("Signer not initialized", new Exception("Signer not initialized"));
            }
            else if (config.SignLocal && Signer != null)
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

                signature = Signer.Sign(canEvent);
                publicKey = GetPublicKeyData();
            }
            return new LogEvent(evt, signature, publicKey);
        }

        private async Task<Response<RootResult>> RootPost(int? treeSize)
        {
            return await DoPost<RootResult>("/v1/root", new RootRequest(treeSize));
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
            return await RootPost(default!);
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
        /// var response = await client.GetRoot(1);
        /// </code>
        /// </example>
        public async Task<Response<RootResult>> GetRoot(int? treeSize)
        {
            return await RootPost(treeSize);
        }

        private async Task ProcessSearchResult(ResultsOutput result, SearchConfig config)
        {
            foreach (SearchEvent searchEvent in result.Events)
            {
                searchEvent.EventEnvelope = EventEnvelope.FromRaw(searchEvent.RawEnvelope, CustomSchemaClass)!;
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
                    await UpdatePublishedRoots(result);
                }

                foreach (SearchEvent searchEvent in result.Events)
                {
                    string rootHash;
                    if (searchEvent.Published)
                    {
                        rootHash = root?.RootHash ?? "";
                    }
                    else
                    {
                        rootHash = UnpublishedRoot.RootHash;
                    }

                    searchEvent.VerifyMembershipProof(rootHash);
                    searchEvent.VerifyConsistency(PublishedRoots);
                }
            }
        }

        private async Task UpdatePublishedRoots(ResultsOutput result)
        {
            Root root = result.Root;
            if (root == null)
            {
                return;
            }

            HashSet<int> treeSizes = new();
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
            treeSizes.RemoveWhere(PublishedRoots.ContainsKey);

            int[] sizes = new int[treeSizes.Count];
            treeSizes.CopyTo(sizes);

            Dictionary<int, PublishedRoot> arweaveRoots;
            if (sizes.Length > 0)
            {
                Arweave arweave = new(root.TreeName);
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
                    PublishedRoots.Add(treeSize, arweaveRoots[treeSize]);
                }
                else if (AllowServerRoots)
                {
                    Response<RootResult> response;
                    try
                    {
                        response = await GetRoot(treeSize);

                        Root localRoot = response.Result.Root;
                        PublishedRoot pubRoot = new(root.Size, root.RootHash, root.PublishedAt, root.ConsistencyProof, "pangea");
                        PublishedRoots[treeSize] = pubRoot;
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
        /// <param name="request" type="PangeaCyber.Net.Audit.SearchRequest">Request to be sent to /search endpoint</param>
        /// <param name="config" type="PangeaCyber.Net.Audit.SearchConfig">Config include event and consistency verification setup</param>
        /// <returns>Response&lt;SearchOutput&gt;</returns>
        /// <exception cref="PangeaException"></exception>
        /// <exception cref="PangeaAPIException"></exception>
        /// <example>
        /// <code>
        /// var request = new SearchRequest
        ///     .Builder("message:hello world")
        ///     .Build();
        /// var config = new SearchConfig
        ///     .Builder()
        ///     .Build();
        ///
        /// var response = await client.Search(request, config);
        /// </code>
        /// </example>
        public async Task<Response<SearchOutput>> Search(SearchRequest request, SearchConfig config)
        {
            Response<SearchOutput> response = await DoPost<SearchOutput>("/v1/search", request);
            await ProcessSearchResult(response.Result, config);
            return response;
        }

        /// <kind>method</kind>
        /// <summary>Return result's page from search id.</summary>
        /// <remarks>Results</remarks>
        /// <operationid>audit_post_v1_results</operationid>
        /// <param name="request" type="PangeaCyber.Net.Audit.ResultRequest">Request to be sent to /results endpoint</param>
        /// <param name="config" type="PangeaCyber.Net.Audit.SearchConfig">Config include event and consistency verification setup</param>
        /// <returns>Response&lt;ResultsOutput&gt;</returns>
        /// <exception cref="PangeaException"></exception>
        /// <exception cref="PangeaAPIException"></exception>
        /// <example>
        /// <code>
        /// var request = new ResultRequest
        ///     .Builder("pas_sqilrhruwu54uggihqj3aie24wrctakr")
        ///     .Build();
        /// var config = new SearchConfig
        ///     .Builder()
        ///     .Build();
        ///
        /// var response = await client.Results(request, config);
        /// </code>
        /// </example>
        public async Task<Response<ResultsOutput>> Results(ResultRequest request, SearchConfig config)
        {
            var response = await DoPost<ResultsOutput>("/v1/results", request);
            await ProcessSearchResult(response.Result, config);
            return response;
        }

        private string GetPublicKeyData()
        {
            try
            {
                if (Signer != null)
                {
                    PKInfo["key"] = Signer.GetPublicKey();
                    PKInfo["algorithm"] = Signer.GetAlgorithm();
                }
                return JsonConvert.SerializeObject(PKInfo);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                throw new PangeaException("Failed to stringify public key info", e);
            }
        }

        /// <kind>class</kind>
        /// <summary>
        /// AuditClient Builder
        /// </summary>
        public class Builder : ClientBuilder
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
            public string configID = "";

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
            public Builder WithPKInfo(Dictionary<string, string> pkInfo)
            {
                this.pkInfo = pkInfo;
                return this;
            }

            /// Add extra public key information
            public Builder WithConfigID(string configID)
            {
                this.configID = configID;
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
