using PangeaCyber.Net;

namespace PangeaCyber.Tests;

public sealed class ConfigTests
{
    [Fact]
    public void ServiceUrl()
    {
        var config = new Config("placeholder");
        Assert.Equal("https://audit.aws.us.pangea.cloud/api", config.GetServiceUrl("audit", "api").ToString());
        Assert.Equal("https://audit.aws.us.pangea.cloud/api", config.GetServiceUrl("audit", "/api").ToString());

        config.BaseUrlTemplate = "https://example.org/{SERVICE_NAME}";
        Assert.Equal("https://example.org/audit/api", config.GetServiceUrl("audit", "api").ToString());

        config.BaseUrlTemplate = "https://example.org";
        Assert.Equal("https://example.org/api", config.GetServiceUrl("audit", "api").ToString());

        config.Domain = "example.org";
        Assert.Equal("https://audit.example.org/api", config.GetServiceUrl("audit", "api").ToString());
    }
}
