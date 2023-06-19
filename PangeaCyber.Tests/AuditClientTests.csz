using Newtonsoft.Json;
using PangeaCyber.Net;
using PangeaCyber.Net.Audit;
using PangeaCyber.Net.Exceptions;

namespace PangeaCyber.Tests;

///
public class AuditClientTests
{
    private AuditClient client, signClient, signNtenandIDClient;

    TestEnvironment environment = TestEnvironment.LVE;

    private const string ACTOR = "csharp-sdk";
    private const string MSG_NO_SIGNED = "test-message";
    private const string MSG_SIGNED_LOCAL = "sign-test-local";
    private const string STATUS_NO_SIGNED = "no-signed";
    private const string STATUS_SIGNED = "signed";

    private const string TENANT_ID = "test_tenant";

    private const string PRIVATE_KEY_FILE = "./data/privkey";

    public AuditClientTests()
    {
        // var cfg = Config.FromIntegrationEnvironment(environment);
        var config = Config.FromIntegrationEnvironment(TestEnvironment.LVE);
        var builder = new AuditClientBuilder(config);
        this.client = builder.Build();
        this.signClient = builder.WithPrivateKey(PRIVATE_KEY_FILE).Build();
        this.signNtenandIDClient = builder.WithTenantID(TENANT_ID).Build();
    }

    [Fact]
    public async Task TestLog()
    {
        Event evt = new Event(MSG_NO_SIGNED);
        evt.Actor = ACTOR;
        evt.Status = STATUS_NO_SIGNED;

        var response = await client.Log(evt);

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
        Event evt = new Event(MSG_NO_SIGNED);
        evt.Actor = ACTOR;
        evt.Status = STATUS_NO_SIGNED;

        var response = await client.Log(evt, SignMode.Unsigned, false, false);

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
        Event evt = new Event(MSG_NO_SIGNED);
        evt.Actor = ACTOR;
        evt.Status = STATUS_NO_SIGNED;

        var response = await client.Log(evt, SignMode.Unsigned, true, false);

        Assert.True(response.IsOK);
        Assert.NotNull(response.Result.EventEnvelope);
        Assert.NotNull(response.Result.Hash);
        Assert.Equal(MSG_NO_SIGNED, response.Result.EventEnvelope.RequestEvent.Message);
        Assert.Null(response.Result.ConsistencyProof);
        Assert.NotNull(response.Result.MembershipProof);
        Assert.Equal(EventVerification.NotVerified, response.Result.ConsistencyVerification);
        Assert.Equal(EventVerification.NotVerified, response.Result.MembershipVerification);
        Assert.Equal(EventVerification.NotVerified, response.Result.SignatureVerification);
    }

    [Fact]
    public async Task TestLogTenantID()
    {
        Event evt = new Event(MSG_NO_SIGNED);
        evt.Actor = ACTOR;
        evt.Status = STATUS_NO_SIGNED;

        var response = await signNtenandIDClient.Log(evt, SignMode.Unsigned, true, false);
        Assert.True(response.IsOK);

        Assert.NotNull(response.Result.EventEnvelope);
        Assert.NotNull(response.Result.Hash);
        Assert.Equal(MSG_NO_SIGNED, response.Result.EventEnvelope.RequestEvent.Message);
        Assert.Null(response.Result.ConsistencyProof);
        Assert.NotNull(response.Result.MembershipProof);
        Assert.Equal(EventVerification.NotVerified, response.Result.ConsistencyVerification);
        Assert.Equal(EventVerification.NotVerified, response.Result.MembershipVerification);
        Assert.Equal(EventVerification.NotVerified, response.Result.SignatureVerification);
        Assert.Equal(TENANT_ID, response.Result.EventEnvelope.RequestEvent.TenantID);
    }

    [Fact]
    public async Task TestLogVerify()
    {
        Event evt = new Event(MSG_NO_SIGNED);
        evt.Actor = ACTOR;
        evt.Status = STATUS_NO_SIGNED;

        var response = await client.Log(evt, SignMode.Unsigned, true, true);
        Assert.True(response.IsOK);

        Assert.NotNull(response.Result.EventEnvelope);
        Assert.NotNull(response.Result.Hash);
        Assert.Equal(MSG_NO_SIGNED, response.Result.EventEnvelope.RequestEvent.Message);
        Assert.Equal(EventVerification.NotVerified, response.Result.ConsistencyVerification);
        Assert.Equal(EventVerification.Success, response.Result.MembershipVerification);
        Assert.Equal(EventVerification.NotVerified, response.Result.SignatureVerification);

        // Second log
        evt = new Event(MSG_NO_SIGNED);
        evt.Actor = ACTOR;
        evt.Status = STATUS_NO_SIGNED;
        response = await client.Log(evt, SignMode.Unsigned, true, true);
        Assert.True(response.IsOK);
        Assert.NotNull(response.Result.EventEnvelope);
        Assert.NotNull(response.Result.Hash);
        Assert.Equal(MSG_NO_SIGNED, response.Result.EventEnvelope.RequestEvent.Message);
        Assert.Equal(EventVerification.Success, response.Result.ConsistencyVerification);
        Assert.Equal(EventVerification.Success, response.Result.MembershipVerification);
        Assert.Equal(EventVerification.NotVerified, response.Result.SignatureVerification);
    }

    [Fact]
    public async Task TestLogLocalSignature()
    {
        Event evt = new Event(MSG_SIGNED_LOCAL);
        evt.Actor = ACTOR;
        evt.Action = "Action";
        evt.Source = "Source";
        evt.Status = STATUS_SIGNED;
        evt.Target = "Target";
        evt.NewField = "New";
        evt.Old = "Old";

        var response = await signClient.Log(evt, SignMode.Local, true, true);
        Assert.True(response.IsOK);
        Assert.NotNull(response.Result.EventEnvelope);
        Assert.NotNull(response.Result.Hash);
        Assert.Equal(MSG_SIGNED_LOCAL, response.Result.EventEnvelope.RequestEvent.Message);
        Assert.Equal("lvOyDMpK2DQ16NI8G41yINl01wMHzINBahtDPoh4+mE=", response.Result.EventEnvelope.PublicKey);
        Assert.Equal(EventVerification.Success, response.Result.SignatureVerification);
    }

    [Fact]
    public async Task TestLogLocalSignatureAndTenantID()
    {
        Event evt = new Event(MSG_SIGNED_LOCAL);
        evt.Actor = ACTOR;
        evt.Action = "Action";
        evt.Source = "Source";
        evt.Status = STATUS_SIGNED;
        evt.Target = "Target";
        evt.NewField = "New";
        evt.Old = "Old";

        var response = await signNtenandIDClient.Log(evt, SignMode.Local, true, true);
        Assert.True(response.IsOK);

        Assert.NotNull(response.Result.EventEnvelope);
        Assert.NotNull(response.Result.Hash);
        Assert.Equal(MSG_SIGNED_LOCAL, response.Result.EventEnvelope.RequestEvent.Message);
        Assert.Equal("lvOyDMpK2DQ16NI8G41yINl01wMHzINBahtDPoh4+mE=", response.Result.EventEnvelope.PublicKey);
        Assert.Equal(EventVerification.Success, response.Result.SignatureVerification);
        Assert.Equal(TENANT_ID, response.Result.EventEnvelope.RequestEvent.TenantID);
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
        SearchInput input = new SearchInput("message:\"\"");
        int limit = 4;
        int maxResults = 6;
        input.MaxResults = limit;
        input.MaxResults = maxResults;
        input.Order = "asc";

        var response = await client.Search(input);
        Assert.True(response.IsOK);
        Assert.True(response.Result.Count <= maxResults);

        foreach (SearchEvent evt in response.Result.Events)
        {
            Assert.Contains(evt.ConsistencyVerification, new List<EventVerification>() { EventVerification.NotVerified, EventVerification.Success });
            Assert.Equal(EventVerification.Success, evt.MembershipVerification);
            Assert.NotNull(evt.EventEnvelope);
            Assert.NotNull(evt.Hash);
        }
    }

    [Fact]
    public async Task TestSearchNoVerify()
    {
        SearchInput input = new SearchInput("message:Integration test msg");
        int limit = 10;
        input.MaxResults = limit;
        input.Order = "desc";

        var response = await client.Search(input, false, false);
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
        SearchInput input = new SearchInput("message:\"\"");
        int limit = 10;
        input.MaxResults = limit;
        input.Order = "asc";

        var response = await client.Search(input, true, true);
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
        SearchInput input = new SearchInput("message:" + MSG_SIGNED_LOCAL + " status:" + STATUS_SIGNED);
        int limit = 10;
        input.MaxResults = limit;
        input.Order = "desc";

        var response = await client.Search(input, true, true);
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
        SearchInput input = new SearchInput("message:\"\"");
        int searchLimit = 10;
        input.MaxResults = searchLimit;
        input.Order = "asc";

        var searchResponse = await client.Search(input, true, true);
        Assert.True(searchResponse.IsOK);
        Assert.True(searchResponse.Result.Count <= searchLimit);
        Assert.True(searchResponse.Result.Count > 0);

        int resultsLimit = 3;
        var resultsResponse = await client.Results(searchResponse.Result.ID, resultsLimit, 0);

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
        SearchInput input = new SearchInput("message:\"\"");
        int searchLimit = 10;
        input.MaxResults = searchLimit;
        input.Order = "asc";

        var searchResponse = await client.Search(input, true, true);
        Assert.True(searchResponse.IsOK);
        Assert.True(searchResponse.Result.Count <= searchLimit);
        Assert.True(searchResponse.Result.Count > 0);

        int resultsLimit = 3;
        var resultsResponse = await client.Results(
            searchResponse.Result.ID,
            resultsLimit,
            0,
            true,
            true
        );
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
        SearchInput input = new SearchInput("message:\"\"");
        int searchLimit = 10;
        input.MaxResults = searchLimit;
        input.Order = "asc";

        var searchResponse = await client.Search(input, true, true);
        Assert.True(searchResponse.IsOK);
        Assert.True(searchResponse.Result.Count <= searchLimit);

        int resultsLimit = 3;
        // Skip verifications
        var resultsResponse = await client.Results(
            searchResponse.Result.ID,
            resultsLimit,
            0,
            false,
            false
        );
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
        var response = await client.GetRoot();
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
        var response = await client.GetRoot(treeSize);
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
        await Assert.ThrowsAsync<PangeaAPIException>(async () => await client.GetRoot(treeSize));
    }

    [Fact]
    public async Task TestRootUnauthorized()
    {
        int treeSize = 1;
        Config cfg = Config.FromIntegrationEnvironment(environment);
        cfg.Token = "notarealtoken";
        AuditClient fakeClient = new AuditClientBuilder(cfg).Build();
        await Assert.ThrowsAsync<UnauthorizedException>(async () => await fakeClient.GetRoot(treeSize));
    }

    [Fact]
    public async Task TestLogUnathorized()
    {
        Config cfg = Config.FromIntegrationEnvironment(environment);
        cfg.Token = "notarealtoken";
        AuditClient fakeClient = new AuditClientBuilder(cfg).Build();
        Event evt = new Event("Test msg");
        await Assert.ThrowsAsync<UnauthorizedException>(async () => await fakeClient.Log(evt));
    }

    [Fact]
    public async Task TestSearchValidationException()
    {
        SearchInput input = new SearchInput("message:\"\"");
        int searchLimit = 100;
        input.MaxResults = searchLimit;
        input.Order = "notavalidorder";
        await Assert.ThrowsAsync<ValidationException>(async () => await client.Search(input, true, true));
    }

    [Fact]
    public async Task TestSearchValidationException2()
    {
        Config cfg = Config.FromIntegrationEnvironment(environment);
        cfg.Token = "notarealtoken";
        AuditClient fakeClient = new AuditClientBuilder(cfg).Build();
        SearchInput input = new SearchInput("message:\"\"");
        int searchLimit = 100;
        input.MaxResults = searchLimit;
        input.Order = "notavalidorder";
        await Assert.ThrowsAsync<UnauthorizedException>(async () => await fakeClient.Search(input, true, true));
    }

    [Fact]
    public async Task TestLogSignerNotSet()
    {
        Event evt = new Event(MSG_NO_SIGNED);
        await Assert.ThrowsAsync<SignerException>(async () => await client.Log(evt, SignMode.Local, true, true));
    }

}