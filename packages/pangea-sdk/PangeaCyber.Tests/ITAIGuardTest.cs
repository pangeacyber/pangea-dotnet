using PangeaCyber.Net;
using PangeaCyber.Net.AIGuard;
using PangeaCyber.Net.AIGuard.Requests;

namespace PangeaCyber.Tests;

public class ITAIGuardTest
{
    private static readonly TestEnvironment environment = Helper.LoadTestEnvironment("ai-guard", TestEnvironment.LVE);
    private static readonly AIGuardClient client = new AIGuardClient.Builder(Config.FromIntegrationEnvironment(environment)).Build();

    [Fact]
    public async Task TestGuardText()
    {
        var response = await client.GuardText(new TextGuardRequest("hello world") { Recipe = "pangea_prompt_guard" });
        Assert.True(response.IsOK);
        Assert.NotNull(response.Result.Prompt);
        Assert.False(response.Result.Detectors.MaliciousEntity?.Detected);
        Assert.False(response.Result.Detectors.PiiEntity?.Detected);
        Assert.False(response.Result.Detectors.PromptInjection?.Detected);

        response = await client.GuardText(new TextGuardRequest("security@pangea.cloud") { Recipe = "pangea_prompt_guard" });
        Assert.True(response.IsOK);
        Assert.NotNull(response.Result.Prompt);
        Assert.NotNull(response.Result.Detectors.PiiEntity);
        Assert.NotNull(response.Result.Detectors.PiiEntity.Data);
        Assert.Single(response.Result.Detectors.PiiEntity.Data.Entities);
    }
}
