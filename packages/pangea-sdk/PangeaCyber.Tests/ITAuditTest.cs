using Newtonsoft.Json;
using PangeaCyber.Net;
using PangeaCyber.Net.Audit;
using PangeaCyber.Net.Audit.Models;
using PangeaCyber.Net.Exceptions;

namespace PangeaCyber.Tests;

///
public class ITAuditTest
{
    private AuditClient generalClient, signClient, tenantIDClient, signNtenantIDClient, customSchemaClient, customSchemaNSignClient, vaultSignClient;

    CustomEvent customEvent;

    private readonly TestEnvironment environment = Helper.LoadTestEnvironment("audit", TestEnvironment.LVE);

    private const string ACTOR = "csharp-sdk";
    private const string MSG_NO_SIGNED = "test-message";
    private const string MSG_SIGNED_LOCAL = "sign-test-local";
    private const string MSG_SIGNED_VAULT = "sign-test-vault";
    private const string STATUS_NO_SIGNED = "no-signed";
    private const string STATUS_SIGNED = "signed";
    private const string TENANT_ID = "test_tenant";
    private const string PRIVATE_KEY_FILE = "./data/privkey";
    private const string MSG_CUSTOM_SCHEMA_NO_SIGNED = "java-sdk-custom-schema-no-signed";
    private const string MSG_CUSTOM_SCHEMA_SIGNED_LOCAL = "java-sdk-custom-schema-sign-local";
    private const string LONG_FIELD = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed lacinia, orci eget commodo commodo non.";

    public ITAuditTest()
    {
        // Standard schema clients
        var generalCfg = Config.FromIntegrationEnvironment(environment);
        var builder = new AuditClient.Builder(generalCfg);

        this.generalClient = builder.Build();

        this.signClient = builder.WithPrivateKey(PRIVATE_KEY_FILE).Build();
        this.tenantIDClient = builder.WithTenantID(TENANT_ID).Build();
        this.signNtenantIDClient = builder.WithTenantID(TENANT_ID).WithPrivateKey(PRIVATE_KEY_FILE).Build();

        // Vault client
        var vaultCfg = Config.FromVaultIntegrationEnvironment(environment);
        this.vaultSignClient = new AuditClient.Builder(vaultCfg).Build();

        // Custom schema clients
        var customSchemaCfg = Config.FromCustomSchemaIntegrationEnvironment(environment);
        this.customSchemaClient = new AuditClient.Builder(customSchemaCfg).WithCustomSchema<CustomEvent>().Build();
        this.customSchemaNSignClient = new AuditClient.Builder(customSchemaCfg).WithCustomSchema<CustomEvent>().WithPrivateKey(PRIVATE_KEY_FILE).Build();

        this.customEvent =
            new CustomEvent.Builder(MSG_CUSTOM_SCHEMA_NO_SIGNED)
                .WithFieldInt(1)
                .WithFieldBool(true)
                .WithFieldStrShort(STATUS_NO_SIGNED)
                .WithFieldStrLong(LONG_FIELD)
                .Build();
    }

    [Fact]
    public async Task TestLog()
    {
        StandardEvent evt = new StandardEvent.Builder(MSG_NO_SIGNED)
                            .WithActor(ACTOR)
                            .WithStatus(STATUS_NO_SIGNED)
                            .Build();

        var response = await generalClient.Log(evt, new LogConfig.Builder().WithVerify(false).Build());

        Assert.True(response.IsOK);
        Assert.Null(response.Result.EventEnvelope);
        Assert.NotNull(response.Result.Hash);
        Assert.Null(response.Result.ConsistencyProof);
        Assert.Null(response.Result.MembershipProof);
        Assert.Equal(EventVerification.NotVerified, response.Result.ConsistencyVerification);
        Assert.Equal(EventVerification.NotVerified, response.Result.MembershipVerification);
        Assert.Equal(EventVerification.NotVerified, response.Result.SignatureVerification);
    }

    [Fact]
    public async Task TestLog_CustomSchema()
    {
        var response = await customSchemaClient.Log(this.customEvent, new LogConfig.Builder().WithVerify(false).Build());

        Assert.True(response.IsOK);
        Assert.Null(response.Result.EventEnvelope);
        Assert.NotNull(response.Result.Hash);
        Assert.Null(response.Result.ConsistencyProof);
        Assert.Null(response.Result.MembershipProof);
        Assert.Equal(EventVerification.NotVerified, response.Result.ConsistencyVerification);
        Assert.Equal(EventVerification.NotVerified, response.Result.MembershipVerification);
        Assert.Equal(EventVerification.NotVerified, response.Result.SignatureVerification);
    }

    [Fact]
    public async Task TestLogNoVerbose()
    {
        StandardEvent evt = new StandardEvent.Builder(MSG_NO_SIGNED)
                            .WithActor(ACTOR)
                            .WithStatus(STATUS_NO_SIGNED)
                            .Build();

        var response = await generalClient.Log(evt, new LogConfig.Builder().WithVerify(false).WithVerbose(false).WithSignLocal(false).Build());

        Assert.True(response.IsOK);
        Assert.Null(response.Result.EventEnvelope);
        Assert.NotNull(response.Result.Hash);
        Assert.Null(response.Result.ConsistencyProof);
        Assert.Null(response.Result.MembershipProof);
        Assert.Equal(EventVerification.NotVerified, response.Result.ConsistencyVerification);
        Assert.Equal(EventVerification.NotVerified, response.Result.MembershipVerification);
        Assert.Equal(EventVerification.NotVerified, response.Result.SignatureVerification);
    }

    [Fact]
    public async Task TestLogNoVerbose_CustomSchema()
    {
        var response = await customSchemaClient.Log(customEvent, new LogConfig.Builder().WithVerify(false).WithVerbose(false).WithSignLocal(false).Build());

        Assert.True(response.IsOK);
        Assert.Null(response.Result.EventEnvelope);
        Assert.NotNull(response.Result.Hash);
        Assert.Null(response.Result.ConsistencyProof);
        Assert.Null(response.Result.MembershipProof);
        Assert.Equal(EventVerification.NotVerified, response.Result.ConsistencyVerification);
        Assert.Equal(EventVerification.NotVerified, response.Result.MembershipVerification);
        Assert.Equal(EventVerification.NotVerified, response.Result.SignatureVerification);
    }

    [Fact]
    public async Task TestLogVerbose()
    {
        StandardEvent? evt = new StandardEvent.Builder(MSG_NO_SIGNED)
                            .WithActor(ACTOR)
                            .WithStatus(STATUS_NO_SIGNED)
                            .Build();

        LogConfig cfg = new LogConfig.Builder().WithVerify(false).WithVerbose(true).WithSignLocal(false).Build();
        var response = await generalClient.Log(evt, cfg);

        Assert.True(response.IsOK);
        Assert.NotNull(response.Result.EventEnvelope);
        Assert.NotNull(response.Result.Hash);
        evt = (StandardEvent?)response.Result.EventEnvelope.Event;
        Assert.Equal(MSG_NO_SIGNED, evt?.Message);
        Assert.Null(response.Result.ConsistencyProof);
        Assert.NotNull(response.Result.MembershipProof);
        Assert.Equal(EventVerification.NotVerified, response.Result.ConsistencyVerification);
        Assert.Equal(EventVerification.NotVerified, response.Result.MembershipVerification);
        Assert.Equal(EventVerification.NotVerified, response.Result.SignatureVerification);
    }

    [Fact]
    public async Task TestLogVerbose_CustomSchema()
    {
        LogConfig cfg = new LogConfig.Builder().WithVerify(false).WithVerbose(true).WithSignLocal(false).Build();
        var response = await customSchemaClient.Log(customEvent, cfg);

        Assert.True(response.IsOK);
        Assert.NotNull(response.Result.EventEnvelope);
        Assert.NotNull(response.Result.Hash);
        CustomEvent? evt = (CustomEvent?)response.Result.EventEnvelope.Event;
        Assert.Equal(MSG_CUSTOM_SCHEMA_NO_SIGNED, evt?.Message);
        Assert.Null(response.Result.ConsistencyProof);
        Assert.NotNull(response.Result.MembershipProof);
        Assert.Equal(EventVerification.NotVerified, response.Result.ConsistencyVerification);
        Assert.Equal(EventVerification.NotVerified, response.Result.MembershipVerification);
        Assert.Equal(EventVerification.NotVerified, response.Result.SignatureVerification);
    }


    [Fact]
    public async Task TestLogTenantID()
    {

        StandardEvent? evt = new StandardEvent.Builder(MSG_NO_SIGNED)
                            .WithActor(ACTOR)
                            .WithStatus(STATUS_NO_SIGNED)
                            .Build();

        var response = await tenantIDClient.Log(evt, new LogConfig.Builder().WithVerify(false).WithVerbose(true).Build());
        Assert.True(response.IsOK);

        Assert.NotNull(response.Result.EventEnvelope);
        Assert.NotNull(response.Result.Hash);
        evt = (StandardEvent?)response.Result.EventEnvelope.Event;
        Assert.Equal(MSG_NO_SIGNED, evt?.Message);
        Assert.Null(response.Result.ConsistencyProof);
        Assert.NotNull(response.Result.MembershipProof);
        Assert.Equal(EventVerification.NotVerified, response.Result.ConsistencyVerification);
        Assert.Equal(EventVerification.NotVerified, response.Result.MembershipVerification);
        Assert.Equal(EventVerification.NotVerified, response.Result.SignatureVerification);
        Assert.Equal(TENANT_ID, evt?.TenantID);
    }

    [Fact]
    public async Task TestLogVerify()
    {

        StandardEvent? evt = new StandardEvent.Builder(MSG_NO_SIGNED)
                            .WithActor(ACTOR)
                            .WithStatus(STATUS_NO_SIGNED)
                            .Build();

        var response = await generalClient.Log(evt, new LogConfig.Builder().WithVerify(true).WithVerbose(true).Build());

        Assert.True(response.IsOK);

        Assert.NotNull(response.Result.EventEnvelope);
        Assert.NotNull(response.Result.Hash);
        evt = (StandardEvent?)response.Result.EventEnvelope.Event;
        Assert.Equal(MSG_NO_SIGNED, evt?.Message);
        Assert.Equal(EventVerification.NotVerified, response.Result.ConsistencyVerification);
        Assert.Equal(EventVerification.Success, response.Result.MembershipVerification);
        Assert.Equal(EventVerification.NotVerified, response.Result.SignatureVerification);

        // Second log
        evt = new StandardEvent.Builder(MSG_NO_SIGNED)
                            .WithActor(ACTOR)
                            .WithStatus(STATUS_NO_SIGNED)
                            .Build();

        response = await generalClient.Log(evt, new LogConfig.Builder().WithVerify(true).WithVerbose(true).Build());

        Assert.True(response.IsOK);
        Assert.NotNull(response.Result.EventEnvelope);
        Assert.NotNull(response.Result.Hash);
        evt = (StandardEvent?)response.Result.EventEnvelope.Event;
        Assert.Equal(MSG_NO_SIGNED, evt?.Message);
        Assert.Equal(EventVerification.Success, response.Result.ConsistencyVerification);
        Assert.Equal(EventVerification.Success, response.Result.MembershipVerification);
        Assert.Equal(EventVerification.NotVerified, response.Result.SignatureVerification);
    }

    [Fact]
    public async Task TestLogVerify_CustomSchema()
    {
        var response = await customSchemaClient.Log(customEvent, new LogConfig.Builder().WithVerify(true).WithVerbose(true).Build());

        Assert.True(response.IsOK);

        Assert.NotNull(response.Result.EventEnvelope);
        Assert.NotNull(response.Result.Hash);
        CustomEvent? evt = (CustomEvent?)response.Result.EventEnvelope.Event;
        Assert.Equal(MSG_CUSTOM_SCHEMA_NO_SIGNED, evt?.Message);
        Assert.Equal(EventVerification.NotVerified, response.Result.ConsistencyVerification);
        Assert.Equal(EventVerification.Success, response.Result.MembershipVerification);
        Assert.Equal(EventVerification.NotVerified, response.Result.SignatureVerification);

        // Second log
        response = await customSchemaClient.Log(customEvent, new LogConfig.Builder().WithVerify(true).WithVerbose(true).Build());

        Assert.True(response.IsOK);
        Assert.NotNull(response.Result.EventEnvelope);
        Assert.NotNull(response.Result.Hash);
        evt = (CustomEvent?)response.Result.EventEnvelope.Event;
        Assert.Equal(MSG_CUSTOM_SCHEMA_NO_SIGNED, evt?.Message);
        Assert.Equal(EventVerification.Success, response.Result.ConsistencyVerification);
        Assert.Equal(EventVerification.Success, response.Result.MembershipVerification);
        Assert.Equal(EventVerification.NotVerified, response.Result.SignatureVerification);
    }


    [Fact]
    public async Task TestLogLocalSignature()
    {
        StandardEvent? evt = new StandardEvent.Builder(MSG_SIGNED_LOCAL)
                            .WithActor(ACTOR)
                            .WithAction("Action")
                            .WithSource("Source")
                            .WithStatus(STATUS_SIGNED)
                            .WithTarget("Target")
                            .WithNewField("New")
                            .WithOld("Old")
                            .Build();

        var response = await signClient.Log(evt, new LogConfig.Builder().WithVerify(true).WithVerbose(true).WithSignLocal(true).Build());

        Assert.True(response.IsOK);
        Assert.NotNull(response.Result.EventEnvelope);
        Assert.NotNull(response.Result.Hash);
        evt = (StandardEvent?)response.Result.EventEnvelope.Event;
        Assert.Equal(MSG_SIGNED_LOCAL, evt?.Message);
        Assert.Equal(@"{""algorithm"":""ED25519"",""key"":""-----BEGIN PUBLIC KEY-----\nMCowBQYDK2VwAyEAlvOyDMpK2DQ16NI8G41yINl01wMHzINBahtDPoh4+mE=\n-----END PUBLIC KEY-----\n""}", response.Result.EventEnvelope.PublicKey);
        Assert.Equal(EventVerification.Success, response.Result.SignatureVerification);
    }

    [Fact]
    public async Task TestLogLocalSignature_CustomSchema()
    {
        CustomEvent? evt = new CustomEvent.Builder(MSG_CUSTOM_SCHEMA_SIGNED_LOCAL)
                            .WithFieldInt(1)
                            .WithFieldBool(true)
                            .WithFieldStrShort(STATUS_SIGNED)
                            .WithFieldStrLong(LONG_FIELD)
                            .Build();

        var response = await customSchemaNSignClient.Log(evt, new LogConfig.Builder().WithVerify(true).WithVerbose(true).WithSignLocal(true).Build());

        Assert.True(response.IsOK);
        Assert.NotNull(response.Result.EventEnvelope);
        Assert.NotNull(response.Result.Hash);
        evt = (CustomEvent?)response.Result.EventEnvelope.Event;
        Assert.Equal(MSG_CUSTOM_SCHEMA_SIGNED_LOCAL, evt?.Message);
        Assert.Equal(@"{""algorithm"":""ED25519"",""key"":""-----BEGIN PUBLIC KEY-----\nMCowBQYDK2VwAyEAlvOyDMpK2DQ16NI8G41yINl01wMHzINBahtDPoh4+mE=\n-----END PUBLIC KEY-----\n""}", response.Result.EventEnvelope.PublicKey);
        Assert.Equal(EventVerification.Success, response.Result.SignatureVerification);
    }

    [Fact]
    public async Task TestLogVaultSignature()
    {
        StandardEvent? evt = new StandardEvent.Builder(MSG_SIGNED_VAULT)
                            .WithActor(ACTOR)
                            .WithAction("Action")
                            .WithSource("Source")
                            .WithStatus(STATUS_SIGNED)
                            .WithTarget("Target")
                            .WithNewField("New")
                            .WithOld("Old")
                            .Build();

        var response = await vaultSignClient.Log(evt, new LogConfig.Builder().WithVerify(true).WithVerbose(true).WithSignLocal(false).Build());

        Assert.True(response.IsOK);
        Assert.NotNull(response.Result.EventEnvelope);
        Assert.NotNull(response.Result.Hash);
        Assert.NotNull(response.Result.EventEnvelope.PublicKey);
        Assert.NotNull(response.Result.EventEnvelope.Signature);
        evt = (StandardEvent?)response.Result.EventEnvelope.Event;
        Assert.Equal(MSG_SIGNED_VAULT, evt?.Message);
        Assert.Equal(EventVerification.Success, response.Result.SignatureVerification);
    }

    [Fact]
    public async Task TestLogLocalSignatureAndTenantID()
    {
        StandardEvent? evt = new StandardEvent.Builder(MSG_SIGNED_LOCAL)
                            .WithActor(ACTOR)
                            .WithAction("Action")
                            .WithSource("Source")
                            .WithStatus(STATUS_SIGNED)
                            .WithTarget("Target")
                            .WithNewField("New")
                            .WithOld("Old")
                            .Build();

        var response = await signNtenantIDClient.Log(evt, new LogConfig.Builder().WithVerify(true).WithVerbose(true).WithSignLocal(true).Build());

        Assert.True(response.IsOK);

        Assert.NotNull(response.Result.EventEnvelope);
        Assert.NotNull(response.Result.Hash);
        evt = (StandardEvent?)response.Result.EventEnvelope.Event;
        Assert.Equal(MSG_SIGNED_LOCAL, evt?.Message);
        Assert.Equal(@"{""algorithm"":""ED25519"",""key"":""-----BEGIN PUBLIC KEY-----\nMCowBQYDK2VwAyEAlvOyDMpK2DQ16NI8G41yINl01wMHzINBahtDPoh4+mE=\n-----END PUBLIC KEY-----\n""}", response.Result.EventEnvelope.PublicKey);
        Assert.Equal(EventVerification.Success, response.Result.SignatureVerification);
        Assert.Equal(TENANT_ID, evt?.TenantID);
    }


    // [Fact]
    // public async Task ErrorOnEmptyMessage()
    // {
    //     Event evt = new Event("");
    //     await Assert.ThrowsAsync<ValidationException>(async () => await client.Log(evt));
    // }

    [SkippableFact(typeof(AcceptedRequestException))]
    public async Task TestSearchDefault()
    {
        int limit = 4;
        int maxResults = 6;
        SearchRequest req = new SearchRequest.Builder("message:\"\"")
                            .WithMaxResults(maxResults)
                            .WithLimit(limit)
                            .WithOrder("asc")
                            .Build();


        var response = await generalClient.Search(req, new SearchConfig.Builder().Build());
        Assert.True(response.IsOK);
        Assert.True(response.Result.Count <= maxResults);

        foreach (SearchEvent evt in response.Result.Events)
        {
            Assert.Contains(evt.ConsistencyVerification, new List<EventVerification>() { EventVerification.NotVerified, EventVerification.Success });
            Assert.Equal(EventVerification.NotVerified, evt.MembershipVerification);
            Assert.NotNull(evt.EventEnvelope);
            Assert.NotNull(evt.Hash);
        }
    }

    [SkippableFact(typeof(AcceptedRequestException))]
    public async Task TestSearchDefault_CustomSchema()
    {
        int limit = 4;
        int maxResults = 6;
        SearchRequest req = new SearchRequest.Builder("message:\"\"")
                            .WithMaxResults(maxResults)
                            .WithLimit(limit)
                            .WithOrder("asc")
                            .Build();

        var response = await customSchemaClient.Search(req, new SearchConfig.Builder().Build());
        Assert.True(response.IsOK);
        Assert.True(response.Result.Count <= maxResults);

        foreach (SearchEvent evt in response.Result.Events)
        {
            Assert.Contains(evt.ConsistencyVerification, new List<EventVerification>() { EventVerification.NotVerified, EventVerification.Success });
            Assert.Equal(EventVerification.NotVerified, evt.MembershipVerification);
            Assert.NotNull(evt.EventEnvelope);
            Assert.NotNull(evt.Hash);
        }
    }

    [Fact]
    public async Task TestSearchNoVerify()
    {
        int limit = 10;
        SearchRequest req = new SearchRequest.Builder("message:\"\"")
                            .WithMaxResults(limit)
                            .WithOrder("desc")
                            .Build();


        var response = await generalClient.Search(req, new SearchConfig.Builder().WithVerifyConsistency(false).WithVerifyEvents(false).Build());
        Assert.True(response.IsOK);
        Assert.True(response.Result.Count <= limit);

        foreach (SearchEvent evt in response.Result.Events)
        {
            Assert.Equal(EventVerification.NotVerified, evt.ConsistencyVerification);
            Assert.Equal(EventVerification.NotVerified, evt.MembershipVerification);
            Assert.Equal(EventVerification.NotVerified, evt.SignatureVerification);
        }
    }

    [Fact]
    public async Task TestSearchVerifyConsistency()
    {
        int limit = 10;
        SearchRequest req = new SearchRequest.Builder("message:\"\"")
                            .WithMaxResults(limit)
                            .WithLimit(limit)
                            .WithOrder("asc")
                            .Build();


        var response = await generalClient.Search(req, new SearchConfig.Builder().WithVerifyConsistency(true).WithVerifyEvents(true).Build());

        Assert.True(response.IsOK);
        Assert.True(response.Result.Count <= limit);

        foreach (SearchEvent evt in response.Result.Events)
        {
            Assert.Contains(evt.ConsistencyVerification, new List<EventVerification>() { EventVerification.NotVerified, EventVerification.Success });
            Assert.Equal(EventVerification.Success, evt.MembershipVerification);
        }
    }

    [Fact]
    public async Task TestSearchVerifyConsistency_CustomSchema()
    {
        int limit = 10;
        SearchRequest req = new SearchRequest.Builder("message:\"\"")
                            .WithMaxResults(limit)
                            .WithLimit(limit)
                            .WithOrder("asc")
                            .Build();


        var response = await customSchemaClient.Search(req, new SearchConfig.Builder().WithVerifyConsistency(true).WithVerifyEvents(true).Build());

        Assert.True(response.IsOK);
        Assert.True(response.Result.Count <= limit);

        foreach (SearchEvent evt in response.Result.Events)
        {
            Assert.Contains(evt.ConsistencyVerification, new List<EventVerification>() { EventVerification.NotVerified, EventVerification.Success });
            Assert.Equal(EventVerification.Success, evt.MembershipVerification);
        }
    }

    [Fact]
    public async Task TestSearchVerifySignature()
    {
        int limit = 10;
        SearchRequest req = new SearchRequest.Builder("message:" + MSG_SIGNED_LOCAL + " status:" + STATUS_SIGNED)
                            .WithMaxResults(limit)
                            .WithLimit(limit)
                            .WithOrder("desc")
                            .Build();


        var response = await generalClient.Search(req, new SearchConfig.Builder().WithVerifyConsistency(true).WithVerifyEvents(true).Build());
        Assert.True(response.IsOK);
        Assert.True(response.Result.Count <= limit);

        foreach (SearchEvent evt in response.Result.Events)
        {
            Assert.Equal(EventVerification.Success, evt.SignatureVerification);
        }
    }

    [Fact]
    public async Task TestSearchVerifySignature_CustomSchema()
    {
        int limit = 10;
        SearchRequest req = new SearchRequest.Builder("message:" + MSG_CUSTOM_SCHEMA_SIGNED_LOCAL)
                            .WithMaxResults(limit)
                            .WithLimit(limit)
                            .WithOrder("desc")
                            .Build();

        var response = await customSchemaNSignClient.Search(req, new SearchConfig.Builder().WithVerifyConsistency(true).WithVerifyEvents(true).Build());
        Assert.True(response.IsOK);
        Assert.True(response.Result.Count > 0);
        Assert.True(response.Result.Count <= limit);

        foreach (SearchEvent evt in response.Result.Events)
        {
            Assert.Equal(EventVerification.Success, evt.SignatureVerification);
        }
    }

    [SkippableFact(typeof(AcceptedRequestException))]
    public async Task TestResultsDefault()
    {
        int limit = 10;

        SearchRequest req = new SearchRequest.Builder("message:\"\"")
                            .WithMaxResults(limit)
                            .WithOrder("asc")
                            .Build();

        var searchResponse = await generalClient.Search(req, new SearchConfig.Builder().WithVerifyConsistency(true).WithVerifyEvents(true).Build());

        Assert.True(searchResponse.IsOK);
        Assert.True(searchResponse.Result.Count <= limit);
        Assert.True(searchResponse.Result.Count > 0);


        int resultsLimit = 3;
        ResultRequest resultRequest = new ResultRequest.Builder(searchResponse.Result.ID)
                                        .WithLimit(resultsLimit)
                                        .Build();

        var resultsResponse = await generalClient.Results(resultRequest, new SearchConfig.Builder().Build());

        Assert.Equal(resultsResponse.Result.Count, resultsLimit);
        foreach (SearchEvent evt in resultsResponse.Result.Events)
        {
            Assert.Equal(EventVerification.NotVerified, evt.ConsistencyVerification);
            Assert.Equal(EventVerification.NotVerified, evt.MembershipVerification);
        }
    }

    [Fact]
    public async Task TestResultsVerify()
    {
        int searchLimit = 10;
        SearchRequest req = new SearchRequest.Builder("message:\"\"")
                                .WithMaxResults(searchLimit)
                                .WithOrder("asc")
                                .Build();

        var searchResponse = await generalClient.Search(req, new SearchConfig.Builder().WithVerifyConsistency(true).WithVerifyEvents(true).Build());

        Assert.True(searchResponse.IsOK);
        Assert.True(searchResponse.Result.Count <= searchLimit);
        Assert.True(searchResponse.Result.Count > 0);

        int resultsLimit = 3;
        ResultRequest resultRequest = new ResultRequest.Builder(searchResponse.Result.ID)
                                        .WithLimit(resultsLimit)
                                        .Build();

        var resultsResponse = await generalClient.Results(resultRequest, new SearchConfig.Builder().WithVerifyConsistency(true).WithVerifyEvents(true).Build());

        Assert.Equal(resultsResponse.Result.Count, resultsLimit);
        foreach (SearchEvent evt in resultsResponse.Result.Events)
        {
            Assert.Equal(EventVerification.Success, evt.ConsistencyVerification);
            Assert.Equal(EventVerification.Success, evt.MembershipVerification);
        }
    }

    [SkippableFact(typeof(AcceptedRequestException))]
    public async Task TestResultsVerify_CustomSchema()
    {
        int searchLimit = 10;
        SearchRequest req = new SearchRequest.Builder("message:\"\"")
                    .WithMaxResults(searchLimit)
                    .WithOrder("asc")
                    .Build();

        var searchResponse = await customSchemaClient.Search(req, new SearchConfig.Builder().WithVerifyConsistency(true).WithVerifyEvents(true).Build());

        Assert.True(searchResponse.IsOK);
        Assert.True(searchResponse.Result.Count <= searchLimit);
        Assert.True(searchResponse.Result.Count > 0);

        int resultsLimit = 3;
        ResultRequest resultRequest = new ResultRequest.Builder(searchResponse.Result.ID)
                                        .WithLimit(resultsLimit)
                                        .Build();

        var resultsResponse = await customSchemaClient.Results(resultRequest, new SearchConfig.Builder().WithVerifyConsistency(true).WithVerifyEvents(true).Build());

        Assert.Equal(resultsResponse.Result.Count, resultsLimit);
        foreach (SearchEvent evt in resultsResponse.Result.Events)
        {
            Assert.Equal(EventVerification.Success, evt.ConsistencyVerification);
            Assert.Equal(EventVerification.Success, evt.MembershipVerification);
        }
    }

    [SkippableFact(typeof(AcceptedRequestException))]
    public async Task TestResultsNoVerify()
    {
        int searchLimit = 10;
        SearchRequest req = new SearchRequest.Builder("message:\"\"")
                            .WithMaxResults(searchLimit)
                            .WithOrder("asc")
                            .Build();

        var searchResponse = await generalClient.Search(req, new SearchConfig.Builder().WithVerifyConsistency(true).WithVerifyEvents(true).Build());
        Assert.True(searchResponse.IsOK);
        Assert.True(searchResponse.Result.Count <= searchLimit);

        int resultsLimit = 3;
        // Skip verifications
        ResultRequest resultRequest = new ResultRequest.Builder(searchResponse.Result.ID)
                                        .WithLimit(resultsLimit)
                                        .Build();

        var resultsResponse = await generalClient.Results(resultRequest, new SearchConfig.Builder().WithVerifyConsistency(false).WithVerifyEvents(false).Build());


        Assert.Equal(resultsResponse.Result.Count, resultsLimit);
        foreach (SearchEvent evt in resultsResponse.Result.Events)
        {
            // This should be NotVerified
            Assert.Equal(EventVerification.NotVerified, evt.ConsistencyVerification);
            Assert.Equal(EventVerification.NotVerified, evt.MembershipVerification);
        }
    }

    [Fact]
    public async Task TestRoot()
    {
        var response = await generalClient.GetRoot();
        Assert.True(response.IsOK);

        RootResult result = response.Result;
        Root root = result.Root;
        Assert.NotNull(root);
        Assert.NotNull(root.TreeName);
        Assert.NotNull(root.RootHash);
    }

    [Fact]
    public async Task TestRootWithSize()
    {
        int treeSize = 2;
        var response = await generalClient.GetRoot(treeSize);
        Assert.True(response.IsOK);

        RootResult result = response.Result;
        Root root = response.Result.Root;
        Assert.NotNull(root);
        Assert.NotNull(root.TreeName);
        Assert.NotNull(root.RootHash);
        Assert.Equal(treeSize, root.Size);
    }

    [Fact]
    public async Task TestRootTreeNotFound()
    {
        int treeSize = 1000000;
        await Assert.ThrowsAsync<PangeaAPIException>(async () => await generalClient.GetRoot(treeSize));
    }

    [Fact]
    public async Task TestRootUnauthorized()
    {
        int treeSize = 1;
        Config cfg = Config.FromIntegrationEnvironment(environment);
        cfg.Token = "notarealtoken";
        AuditClient fakeClient = new AuditClient.Builder(cfg).Build();
        await Assert.ThrowsAsync<UnauthorizedException>(async () => await fakeClient.GetRoot(treeSize));
    }

    [Fact]
    public async Task TestLogUnauthorized()
    {
        Config cfg = Config.FromIntegrationEnvironment(environment);
        cfg.Token = "notarealtoken";
        AuditClient fakeClient = new AuditClient.Builder(cfg).Build();
        StandardEvent evt = new StandardEvent.Builder("Test msg").Build();
        await Assert.ThrowsAsync<UnauthorizedException>(async () => await fakeClient.Log(evt, new LogConfig.Builder().Build()));
    }

    [SkippableFact(typeof(AcceptedRequestException))]
    public async Task TestSearchValidationException()
    {
        int searchLimit = 100;
        SearchRequest req = new SearchRequest.Builder("message:\"\"")
            .WithLimit(searchLimit)
            .WithOrder("notavalidorder")
            .Build();
        await Assert.ThrowsAsync<ValidationException>(async () => await generalClient.Search(req, new SearchConfig.Builder().Build()));
    }

    [Fact]
    public async Task TestLogSignerNotSet()
    {
        StandardEvent evt = new StandardEvent.Builder(MSG_NO_SIGNED).Build();
        await Assert.ThrowsAsync<SignerException>(async () => await generalClient.Log(evt, new LogConfig.Builder().WithSignLocal(true).Build()));
    }


    [Fact]
    public async Task TestLogMultiConfig_1()
    {
        StandardEvent? evt = new StandardEvent.Builder(MSG_NO_SIGNED)
                            .WithActor(ACTOR)
                            .WithStatus(STATUS_NO_SIGNED)
                            .Build();

        var cfg = new Config(Config.GetMultiConfigTestToken(environment), Config.GetTestDomain(environment));
        String ConfigID = Config.GetConfigID(environment, AuditClient.ServiceName, 1);
        var client = new AuditClient.Builder(cfg).WithConfigID(ConfigID).Build();

        var response = await client.Log(evt, new LogConfig.Builder().WithVerify(false).WithVerbose(true).Build());

        Assert.True(response.IsOK);
        Assert.NotNull(response.Result.EventEnvelope);
        Assert.NotNull(response.Result.Hash);
        evt = (StandardEvent?)response.Result.EventEnvelope.Event;
        Assert.Equal(MSG_NO_SIGNED, evt?.Message);
        Assert.Null(response.Result.ConsistencyProof);
        Assert.NotNull(response.Result.MembershipProof);
        Assert.Equal(EventVerification.NotVerified, response.Result.ConsistencyVerification);
        Assert.Equal(EventVerification.NotVerified, response.Result.MembershipVerification);
        Assert.Equal(EventVerification.NotVerified, response.Result.SignatureVerification);
    }

    [Fact]
    public async Task TestLogMultiConfig_2()
    {
        StandardEvent? evt = new StandardEvent.Builder(MSG_NO_SIGNED)
                            .WithActor(ACTOR)
                            .WithStatus(STATUS_NO_SIGNED)
                            .Build();

        var cfg = new Config(Config.GetMultiConfigTestToken(environment), Config.GetTestDomain(environment));
        String ConfigID = Config.GetConfigID(environment, AuditClient.ServiceName, 2);
        var client = new AuditClient.Builder(cfg).WithConfigID(ConfigID).Build();

        var response = await client.Log(evt, new LogConfig.Builder().WithVerify(false).WithVerbose(true).Build());

        Assert.True(response.IsOK);
        Assert.NotNull(response.Result.EventEnvelope);
        Assert.NotNull(response.Result.Hash);
        evt = (StandardEvent?)response.Result.EventEnvelope.Event;
        Assert.Equal(MSG_NO_SIGNED, evt?.Message);
        Assert.Null(response.Result.ConsistencyProof);
        Assert.NotNull(response.Result.MembershipProof);
        Assert.Equal(EventVerification.NotVerified, response.Result.ConsistencyVerification);
        Assert.Equal(EventVerification.NotVerified, response.Result.MembershipVerification);
        Assert.Equal(EventVerification.NotVerified, response.Result.SignatureVerification);
    }

    [Fact]
    public async Task TestMultiConfigWithoutConfigID()
    {
        StandardEvent? evt = new StandardEvent.Builder(MSG_NO_SIGNED)
                            .Build();

        var cfg = new Config(Config.GetMultiConfigTestToken(environment), Config.GetTestDomain(environment));
        var client = new AuditClient.Builder(cfg).Build();

        await Assert.ThrowsAsync<PangeaAPIException>(async () => await client.Log(evt, new LogConfig.Builder().Build()));
    }

    [Fact]
    public async Task TestLogBulk()
    {
        StandardEvent evt = new StandardEvent.Builder(MSG_NO_SIGNED)
                            .WithActor(ACTOR)
                            .WithStatus(STATUS_NO_SIGNED)
                            .Build();

        var response = await generalClient.LogBulk(new IEvent[] { evt, evt }, new LogConfig.Builder().WithVerify(false).Build());

        Assert.True(response.IsOK);
        foreach (LogResult result in response.Result.Results)
        {
            Assert.Null(result.EventEnvelope);
            Assert.NotNull(result.Hash);
            Assert.Null(result.ConsistencyProof);
            Assert.Null(result.MembershipProof);
            Assert.Equal(EventVerification.NotVerified, result.ConsistencyVerification);
            Assert.Equal(EventVerification.NotVerified, result.MembershipVerification);
            Assert.Equal(EventVerification.NotVerified, result.SignatureVerification);
        }
    }

    [Fact]
    public async Task TestLogBulkAndSign()
    {
        StandardEvent evt = new StandardEvent.Builder(MSG_SIGNED_LOCAL)
                            .WithActor(ACTOR)
                            .WithStatus(STATUS_SIGNED)
                            .Build();

        var response = await signClient.LogBulk(new IEvent[] { evt, evt }, new LogConfig.Builder().WithVerify(true).WithVerbose(true).WithSignLocal(true).Build());

        Assert.True(response.IsOK);
        foreach (LogResult result in response.Result.Results)
        {
            Assert.NotNull(result.EventEnvelope);
            Assert.NotNull(result.Hash);
            Assert.Null(result.ConsistencyProof);
            Assert.Null(result.MembershipProof);
            Assert.Equal(EventVerification.NotVerified, result.ConsistencyVerification);
            Assert.Equal(EventVerification.NotVerified, result.MembershipVerification);
            Assert.Equal(EventVerification.Success, result.SignatureVerification);
        }
    }

    [Fact]
    public async Task TestLogBulkAsync()
    {
        StandardEvent evt = new StandardEvent.Builder(MSG_NO_SIGNED)
                            .WithActor(ACTOR)
                            .WithStatus(STATUS_NO_SIGNED)
                            .Build();

        var response = await generalClient.LogBulkAsync(new IEvent[] { evt, evt }, new LogConfig.Builder().WithVerify(false).Build());
        Assert.NotNull(response.AcceptedResult);
        Assert.NotEmpty(response.RequestId);
        Assert.NotEmpty(response.RequestTime);
        Assert.NotEmpty(response.ResponseTime);
        Assert.NotEmpty(response.Status);
        Assert.NotEmpty(response.Summary);

    }

    [SkippableFact(typeof(AcceptedRequestException))]
    public async Task TestDownloadResults()
    {
        const int searchLimit = 10;
        SearchRequest req = new SearchRequest.Builder("message:\"\"")
                                .WithMaxResults(searchLimit)
                                .WithOrder("asc")
                                .Build();

        var searchResponse = await generalClient.Search(req, new SearchConfig.Builder().WithVerifyConsistency(true).WithVerifyEvents(true).Build());

        Assert.True(searchResponse.IsOK);
        Assert.NotNull(searchResponse.Result.ID);
        Assert.True(searchResponse.Result.Count <= searchLimit);
        Assert.True(searchResponse.Result.Count > 0);

        var downloadResponse = await generalClient.DownloadResults(
            new DownloadRequest
            {
                ResultID = searchResponse.Result.ID,
                Format = DownloadFormat.CSV
            }
        );
        Assert.NotEmpty(downloadResponse.Result.DestURL);

        var file = await generalClient.DownloadFile(downloadResponse.Result.DestURL);

        // FIXME: Commented due to Permission denied
        // file.Save("./", file.Filename);
    }

    [Fact]
    public async Task TestLogStream()
    {
        var input = new LogStreamRequest
        {
            Logs = new List<LogStreamEvent>
            {
                new LogStreamEvent
                {
                    LogId = "some log ID",
                    Data = new LogStreamEventData
                    {
                        ClientId = "test client ID",
                        Date = DateTimeOffset.UtcNow,
                        Description = "Create a log stream",
                        Ip = "127.0.0.1",
                        Type = "some_type",
                        UserAgent = "AppleWebKit/537.36 (KHTML, like Gecko) Chrome/123.0.0.0",
                        UserId = "test user ID"
                    }
                }
            }
        };

        var config = new Config(Config.GetMultiConfigTestToken(environment), Config.GetTestDomain(environment));
        var configId = Config.GetConfigID(environment, AuditClient.ServiceName, 3);
        var client = new AuditClient.Builder(config).WithConfigID(configId).Build();

        var response = await client.LogStream(input);
        Assert.Equal(nameof(ResponseStatus.Success), response.Status);
    }

    [SkippableFact(typeof(AcceptedRequestException))]
    public async Task TestExportDownload()
    {
        var exportResponse = await generalClient.Export(new ExportRequest
        {
            Start = DateTimeOffset.UtcNow.AddDays(-1),
            End = DateTimeOffset.UtcNow,
            Verbose = false,
        });
        Assert.Equal(nameof(ResponseStatus.Accepted), exportResponse.Status);

        const int maxRetries = 10;
        for (int retry = 0; retry < maxRetries; retry++)
        {
            try
            {
                var response = await generalClient.PollResult<object>(exportResponse.RequestId);
                if (response.IsOK)
                {
                    break;
                }
            }
            catch (PangeaAPIException error) when (error.Response.Status == nameof(ResponseStatus.Accepted) || error.Response.Status == nameof(ResponseStatus.NotFound))
            {
                // Allow.
            }

            Skip.If(retry == maxRetries - 1, "exceeded maximum retries");
            await Task.Delay(3 * 1000);
        }

        var dlResponse = await generalClient.DownloadResults(new DownloadRequest { RequestID = exportResponse.RequestId });
        Assert.True(dlResponse.IsOK);
        Assert.NotNull(dlResponse.Result.DestURL);
        Assert.NotEmpty(dlResponse.Result.DestURL);
    }

    private sealed class LogStreamEventData
    {
        [JsonProperty("date")]
        public DateTimeOffset Date { get; set; }

        [JsonProperty("type")]
        public string? Type { get; set; }

        [JsonProperty("description")]
        public string? Description { get; set; }

        [JsonProperty("client_id")]
        public string? ClientId { get; set; }

        [JsonProperty("ip")]
        public string? Ip { get; set; }

        [JsonProperty("user_agent")]
        public string? UserAgent { get; set; }

        [JsonProperty("user_id")]
        public string? UserId { get; set; }

        [JsonProperty("connection", NullValueHandling = NullValueHandling.Ignore)]
        public string? Connection { get; set; }

        [JsonProperty("connection_id", NullValueHandling = NullValueHandling.Ignore)]
        public string? ConnectionId { get; set; }

        [JsonProperty("strategy", NullValueHandling = NullValueHandling.Ignore)]
        public string? Strategy { get; set; }

        [JsonProperty("strategy_type", NullValueHandling = NullValueHandling.Ignore)]
        public string? StrategyType { get; set; }
    }

    private sealed class LogStreamEvent
    {
        [JsonProperty("log_id")]
        public string? LogId { get; set; }

        [JsonProperty("data")]
        public LogStreamEventData? Data { get; set; }
    }

    private sealed class LogStreamRequest : BaseRequest
    {
        [JsonProperty("logs")]
        public IEnumerable<LogStreamEvent> Logs { get; set; } = Enumerable.Empty<LogStreamEvent>();
    }
}
