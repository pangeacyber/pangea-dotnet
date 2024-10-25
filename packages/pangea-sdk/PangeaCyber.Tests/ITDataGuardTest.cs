using PangeaCyber.Net;
using PangeaCyber.Net.DataGuard;
using PangeaCyber.Net.DataGuard.Requests;

namespace PangeaCyber.Tests;

public class ITDataGuardTest
{
    private static readonly TestEnvironment environment = Helper.LoadTestEnvironment("data-guard", TestEnvironment.LVE);
    private static readonly DataGuardClient client = new DataGuardClient.Builder(Config.FromIntegrationEnvironment(environment)).Build();

    [Fact]
    public async Task TestGuardText()
    {
        var response = await client.GuardText(new TextGuardRequest("hello world"));
        Assert.True(response.IsOK);
        Assert.NotNull(response.Result.RedactedPrompt);
        Assert.Equal(0, response.Result.Findings.ArtifactCount);
        Assert.Equal(0, response.Result.Findings.MaliciousCount);

        response = await client.GuardText(new TextGuardRequest("security@pangea.cloud"));
        Assert.True(response.IsOK);
        Assert.NotNull(response.Result.RedactedPrompt);
        Assert.Equal(1, response.Result.Findings.ArtifactCount);
        Assert.Equal(0, response.Result.Findings.MaliciousCount);
    }
}
