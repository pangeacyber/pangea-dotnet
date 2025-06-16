using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using PangeaCyber.Net;
using PangeaCyber.Net.AIGuard;
using PangeaCyber.Net.AIGuard.Models;
using PangeaCyber.Net.AIGuard.Requests;
using Xunit;
using CreateServiceConfigRequest = PangeaCyber.Net.AIGuard.Requests.CreateServiceConfigRequest;
using GetServiceConfigRequest = PangeaCyber.Net.AIGuard.Requests.GetServiceConfigRequest;
using ListServiceConfigsRequest = PangeaCyber.Net.AIGuard.Requests.ListServiceConfigsRequest;

namespace PangeaCyber.Tests.Clients;

public sealed class AIGuardClientTests
{
    private const string BASE_URL = "http://localhost:4010";

    private static async Task CheckTestServer(CancellationToken cancellationToken = default)
    {
        try
        {
            using var httpClient = new HttpClient();
            await httpClient.GetAsync(BASE_URL, cancellationToken: cancellationToken);
        }
        catch (Exception)
        {
            Skip.If(true, "Mock OpenAPI server is not running.");
        }
    }

    [SkippableFact]
    public async Task GuardText()
    {
        await CheckTestServer();

        var client = new AIGuardClient.Builder(new Config("token") { BaseUrlTemplate = "http://localhost:4010" }).Build();
        var response = await client.GuardText(new TextGuardRequest("hello world")
        {
            Recipe = "recipe",
            Debug = true
        });
        Assert.NotNull(response);
        Assert.True(response.IsOK);
        Assert.NotNull(response.Result);
    }

    [SkippableFact]
    public async Task Guard()
    {
        await CheckTestServer();

        var client = new AIGuardClient.Builder(new Config("token") { BaseUrlTemplate = "http://localhost:4010" }).Build();
        var response = await client.Guard(new GuardRequest()
        {
            Messages = [
                new MultimodalMessage
                {
                    Role = "user",
                    Content = [
                        new TextContent { Text = "hello world" },
                        new ImageContent { ImageSrc = "https://example.org/favicon.ico" }
                    ]
                }
            ],
            Recipe = "recipe",
            Debug = true
        });
        Assert.NotNull(response);
        Assert.True(response.IsOK);
        Assert.True(response.HttpResponse.IsSuccessStatusCode);
        Assert.NotNull(response.Result);
    }

    [SkippableFact]
    public async Task GetServiceConfig()
    {
        await CheckTestServer();

        var client = new AIGuardClient.Builder(new Config("token") { BaseUrlTemplate = "http://localhost:4010" }).Build();
        var response = await client.GetServiceConfig(new GetServiceConfigRequest("pci_6zr62lzlvnsrz37kt2yqnwr2qmyurtpa"));
        Assert.NotNull(response);
        Assert.True(response.IsOK);
        Assert.True(response.HttpResponse.IsSuccessStatusCode);
        Assert.NotNull(response.Result);
    }

    [SkippableFact]
    public async Task CreateServiceConfig()
    {
        await CheckTestServer();

        var client = new AIGuardClient.Builder(new Config("token") { BaseUrlTemplate = "http://localhost:4010" }).Build();
        var response = await client.CreateServiceConfig(new CreateServiceConfigRequest("pci_6zr62lzlvnsrz37kt2yqnwr2qmyurtpa"));
        Assert.NotNull(response);
        Assert.True(response.IsOK);
        Assert.True(response.HttpResponse.IsSuccessStatusCode);
        Assert.NotNull(response.Result);
    }

    [SkippableFact]
    public async Task UpdateServiceConfig()
    {
        await CheckTestServer();

        var client = new AIGuardClient.Builder(new Config("token") { BaseUrlTemplate = "http://localhost:4010" }).Build();
        var response = await client.UpdateServiceConfig(new UpdateServiceConfigRequest("pci_6zr62lzlvnsrz37kt2yqnwr2qmyurtpa", "name"));
        Assert.NotNull(response);
        Assert.True(response.IsOK);
        Assert.True(response.HttpResponse.IsSuccessStatusCode);
        Assert.NotNull(response.Result);
    }

    [SkippableFact]
    public async Task DeleteServiceConfig()
    {
        await CheckTestServer();

        var client = new AIGuardClient.Builder(new Config("token") { BaseUrlTemplate = "http://localhost:4010" }).Build();
        var response = await client.DeleteServiceConfig(new DeleteServiceConfigRequest("pci_6zr62lzlvnsrz37kt2yqnwr2qmyurtpa"));
        Assert.NotNull(response);
        Assert.True(response.IsOK);
        Assert.True(response.HttpResponse.IsSuccessStatusCode);
        Assert.NotNull(response.Result);
    }

    [SkippableFact]
    public async Task ListServiceConfigs()
    {
        await CheckTestServer();

        var client = new AIGuardClient.Builder(new Config("token") { BaseUrlTemplate = "http://localhost:4010" }).Build();
        var response = await client.ListServiceConfigs(new ListServiceConfigsRequest
        {
            Filter = new ServiceConfigListFilter
            {
                Id = "id",
                IdContains = ["id1", "id2"],
                CreatedAt = DateTimeOffset.UtcNow,
            },
        });
        Assert.NotNull(response);
        Assert.True(response.IsOK);
        Assert.True(response.HttpResponse.IsSuccessStatusCode);
        Assert.NotNull(response.Result);
        Assert.NotNull(response.Result.Items);
    }
}
