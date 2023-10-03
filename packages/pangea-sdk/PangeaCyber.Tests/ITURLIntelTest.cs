using PangeaCyber.Net;
using PangeaCyber.Net.Intel;
using PangeaCyber.Net.Exceptions;

namespace PangeaCyber.Tests.Intel
{
    public class ITURLIntelTest
    {
        private URLIntelClient client;
        private TestEnvironment environment = TestEnvironment.DEV;

        public ITURLIntelTest()
        {
            var config = Config.FromIntegrationEnvironment(environment);
            client = new URLIntelClient.Builder(config).Build();
        }

        [Fact]
        public async Task TestUrlReputationMalicious_1()
        {
            var response = await client.Reputation(new URLReputationRequest.Builder("http://113.235.101.11:54384").Build());

            Assert.True(response.IsOK);

            IntelReputationData data = response.Result.Data;
            Assert.Equal("malicious", data.Verdict);
            Assert.Null(response.Result.Parameters);
            Assert.Null(response.Result.RawData);
        }

        [Fact]
        public async Task TestUrlReputationMalicious_2()
        {
            var response = await client.Reputation(
                new URLReputationRequest.Builder("http://113.235.101.11:54384").WithProvider("crowdstrike").Build()
            );

            Assert.True(response.IsOK);

            IntelReputationData data = response.Result.Data;
            Assert.Equal("malicious", data.Verdict);
            Assert.Null(response.Result.Parameters);
            Assert.Null(response.Result.RawData);
        }

        [Fact]
        public async Task TestUrlReputationMalicious_3()
        {
            var response = await client.Reputation(
                new URLReputationRequest.Builder("http://113.235.101.11:54384")
                    .WithVerbose(false)
                    .WithRaw(false)
                    .Build()
            );

            Assert.True(response.IsOK);

            IntelReputationData data = response.Result.Data;
            Assert.Equal("malicious", data.Verdict);
            Assert.Null(response.Result.Parameters);
            Assert.Null(response.Result.RawData);
        }

        [Fact]
        public async Task TestUrlReputationMalicious_4()
        {
            var response = await client.Reputation(
                new URLReputationRequest.Builder("http://113.235.101.11:54384")
                    .WithVerbose(true)
                    .WithRaw(false)
                    .Build()
            );

            Assert.True(response.IsOK);

            IntelReputationData data = response.Result.Data;
            Assert.Equal("malicious", data.Verdict);
            Assert.NotNull(response.Result.Parameters);
            Assert.Null(response.Result.RawData);
        }

        [Fact]
        public async Task TestUrlReputationMalicious_5()
        {
            var response = await client.Reputation(
                new URLReputationRequest.Builder("http://113.235.101.11:54384")
                    .WithVerbose(false)
                    .WithRaw(true)
                    .Build()
            );

            Assert.True(response.IsOK);

            IntelReputationData data = response.Result.Data;
            Assert.Equal("malicious", data.Verdict);
            Assert.Null(response.Result.Parameters);
            Assert.NotNull(response.Result.RawData);
        }

        [Fact]
        public async Task TestUrlReputationMalicious_6()
        {
            var response = await client.Reputation(
                new URLReputationRequest.Builder("http://113.235.101.11:54384")
                    .WithVerbose(true)
                    .WithRaw(true)
                    .Build()
            );

            Assert.True(response.IsOK);

            IntelReputationData data = response.Result.Data;
            Assert.Equal("malicious", data.Verdict);
            Assert.NotNull(response.Result.Parameters);
            Assert.NotNull(response.Result.RawData);
        }

        [Fact]
        public async Task TestUrlReputationMalicious_7()
        {
            var response = await client.Reputation(
                new URLReputationRequest.Builder("http://113.235.101.11:54384")
                    .WithProvider("crowdstrike")
                    .WithVerbose(false)
                    .WithRaw(false)
                    .Build()
            );

            Assert.True(response.IsOK);

            IntelReputationData data = response.Result.Data;
            Assert.Equal("malicious", data.Verdict);
            Assert.Null(response.Result.Parameters);
            Assert.Null(response.Result.RawData);
        }

        [Fact]
        public async Task TestUrlReputationMalicious_8()
        {
            var response = await client.Reputation(
                new URLReputationRequest.Builder("http://113.235.101.11:54384")
                    .WithProvider("crowdstrike")
                    .WithVerbose(true)
                    .WithRaw(true)
                    .Build()
            );

            Assert.True(response.IsOK);

            IntelReputationData data = response.Result.Data;
            Assert.Equal("malicious", data.Verdict);
            Assert.NotNull(response.Result.Parameters);
            Assert.NotNull(response.Result.RawData);
        }

        [Fact]
        public async Task TestUrlReputationMaliciousBulk()
        {
            string[] urls = {"http://113.235.101.11:54384",
                "http://45.14.49.109:54819",
                "https://chcial.ru/uplcv?utm_term%3Dcost%2Bto%2Brezone%2Bland"};
            var response = await client.ReputationBulk(
                new URLReputationBulkRequest.Builder(urls)
                    .WithProvider("crowdstrike")
                    .WithVerbose(true)
                    .WithRaw(true)
                    .Build()
            );

            Assert.True(response.IsOK);

            var data = response.Result.Data;
            Assert.NotNull(response.Result.Parameters);
            Assert.NotNull(response.Result.RawData);
            Assert.Equal(3, data.Count);
        }

        [Fact]
        public async Task TestUrlReputationMalicious_NotFound()
        {
            var response = await client.Reputation(
                new URLReputationRequest.Builder("http://thisshouldbeafakeurl123asd:54384")
                    .WithProvider("crowdstrike")
                    .WithVerbose(true)
                    .WithRaw(true)
                    .Build()
            );

            Assert.True(response.IsOK);

            IntelReputationData data = response.Result.Data;
            Assert.NotNull(data);
            Assert.NotEmpty(data.Verdict);
            Assert.NotNull(data.Category);
            Assert.NotNull(response.Result.Parameters);
        }


        [Fact]
        public async Task TestEmptyURL()
        {
            await Assert.ThrowsAsync<ValidationException>(async () => await client.Reputation(
                new URLReputationRequest.Builder("")
                    .WithProvider("crowdstrike")
                    .WithVerbose(true)
                    .WithRaw(true)
                    .Build()
                )
            );
        }

        [Fact]
        public async Task TestEmptyProvider()
        {
            await Assert.ThrowsAsync<ValidationException>(async () => await client.Reputation(
                new URLReputationRequest.Builder("http://113.235.101.11:54384")
                    .WithProvider("")
                    .WithVerbose(true)
                    .WithRaw(true)
                    .Build()
                )
            );
        }

        [Fact]
        public async Task TestEmptyNotValidProvider()
        {
            await Assert.ThrowsAsync<ValidationException>(async () =>
                await client.Reputation(
                    new URLReputationRequest.Builder("http://113.235.101.11:54384")
                        .WithProvider("notavalidprovider")
                        .WithVerbose(true)
                        .WithRaw(true)
                        .Build()
                )
            );
        }

    }
}
