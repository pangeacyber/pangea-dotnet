using PangeaCyber.Net;
using PangeaCyber.Net.Audit;
using PangeaCyber.Net.Exceptions;

namespace PangeaCyber.Tests;

///
public class AuditClientTests
{
    private AuditClient generalClient, signClient, tenantIDClient, signNtenantIDClient, customSchemaClient, customSchemaNSignClient, vaultSignClient;
    private const TestEnvironment environment = TestEnvironment.LVE;

    private const string ACTOR = "csharp-sdk";
    private const string MSG_NO_SIGNED = "test-message";
    private const string MSG_SIGNED_LOCAL = "sign-test-local";
    private const string STATUS_NO_SIGNED = "no-signed";
    private const string STATUS_SIGNED = "signed";
    private const string TENANT_ID = "test_tenant";
    private const string PRIVATE_KEY_FILE = "./data/privkey";

    public AuditClientTests()
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
        this.customSchemaClient = new AuditClient.Builder(customSchemaCfg).Build();
        this.customSchemaNSignClient = new AuditClient.Builder(customSchemaCfg).WithPrivateKey(PRIVATE_KEY_FILE).Build();
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
        Assert.Equal("lvOyDMpK2DQ16NI8G41yINl01wMHzINBahtDPoh4+mE=", response.Result.EventEnvelope.PublicKey);
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
        Assert.Equal("lvOyDMpK2DQ16NI8G41yINl01wMHzINBahtDPoh4+mE=", response.Result.EventEnvelope.PublicKey);
        Assert.Equal(EventVerification.Success, response.Result.SignatureVerification);
        Assert.Equal(TENANT_ID, evt?.TenantID);
    }


    // [Fact]
    // public async Task ErrorOnEmptyMessage()
    // {
    //     Event evt = new Event("");
    //     await Assert.ThrowsAsync<ValidationException>(async () => await client.Log(evt));
    // }

    [Fact]
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
    public async Task TestSearchVerifySignature()
    {
        int limit = 10;
        SearchRequest req = new SearchRequest.Builder("message:" + MSG_SIGNED_LOCAL + " status:" + STATUS_SIGNED)
                            .WithMaxResults(limit)
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

    [Fact]
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
    public async Task TestLogUnathorized()
    {
        Config cfg = Config.FromIntegrationEnvironment(environment);
        cfg.Token = "notarealtoken";
        AuditClient fakeClient = new AuditClient.Builder(cfg).Build();
        StandardEvent evt = new StandardEvent.Builder("Test msg").Build();
        await Assert.ThrowsAsync<UnauthorizedException>(async () => await fakeClient.Log(evt, new LogConfig.Builder().Build()));
    }

    [Fact]
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
        cfg.ConfigID = Config.GetConfigID(environment, AuditClient.ServiceName, 1);
        var client = new AuditClient.Builder(cfg).Build();

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
        cfg.ConfigID = Config.GetConfigID(environment, AuditClient.ServiceName, 2);
        var client = new AuditClient.Builder(cfg).Build();

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

}