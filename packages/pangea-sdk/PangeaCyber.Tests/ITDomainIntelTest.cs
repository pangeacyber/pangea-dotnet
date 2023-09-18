using PangeaCyber.Net.Exceptions;

namespace PangeaCyber.Net.Intel.Tests
{
    public class ITDomainIntelTest
    {
        private DomainIntelClient client;
        private TestEnvironment environment = TestEnvironment.LVE;

        public ITDomainIntelTest()
        {
            client = new DomainIntelClient.Builder(Config.FromIntegrationEnvironment(environment)).Build();
        }

        [Fact]
        public async Task TestDomainReputationMalicious_1()
        {
            // Default provider, not verbose by default, not raw by default;
            var response = await client.Reputation(
                new DomainReputationRequest.Builder("737updatesboeing.com").Build()
            );

            Assert.True(response.IsOK);

            var data = response.Result.Data;
            Assert.NotEmpty(data.Verdict);
            Assert.Null(response.Result.Parameters);
            Assert.Null(response.Result.RawData);
            Assert.Null(response.Result.DataDetails);
        }

        [Fact]
        public async Task TestDomainReputationMalicious_2()
        {
            // With provider, not verbose by default, not raw by default;
            var response = await client.Reputation(
                new DomainReputationRequest.Builder("737updatesboeing.com").WithProvider("crowdstrike").Build()
            );

            Assert.True(response.IsOK);

            var data = response.Result.Data;
            Assert.Equal("malicious", data.Verdict);
            Assert.Null(response.Result.Parameters);
            Assert.Null(response.Result.RawData);
            Assert.Null(response.Result.DataDetails);
        }

        [Fact]
        public async Task TestDomainReputationMalicious_3()
        {
            // Default provider, no verbose, no raw
            var response = await client.Reputation(
                new DomainReputationRequest.Builder("737updatesboeing.com")
                    .WithVerbose(false)
                    .WithRaw(false)
                    .Build()
            );

            Assert.True(response.IsOK);

            var data = response.Result.Data;
            Assert.NotEmpty(data.Verdict);
            Assert.Null(response.Result.Parameters);
            Assert.Null(response.Result.RawData);
            Assert.Null(response.Result.DataDetails);
        }

        [Fact]
        public async Task TestDomainReputationMalicious_4()
        {
            // Default provider, verbose, no raw
            var response = await client.Reputation(
                new DomainReputationRequest.Builder("737updatesboeing.com")
                    .WithVerbose(true)
                    .WithRaw(false)
                    .Build()
            );

            Assert.True(response.IsOK);

            var data = response.Result.Data;
            Assert.NotEmpty(data.Verdict);
            Assert.NotNull(response.Result.Parameters);
            Assert.Null(response.Result.RawData);
            Assert.Null(response.Result.DataDetails);
        }

        [Fact]
        public async Task TestDomainReputationMalicious_5()
        {
            // Default provider, no verbose, raw
            var response = await client.Reputation(
                new DomainReputationRequest.Builder("737updatesboeing.com")
                    .WithVerbose(false)
                    .WithRaw(true)
                    .Build()
            );

            Assert.True(response.IsOK);

            var data = response.Result.Data;
            Assert.NotEmpty(data.Verdict);
            Assert.Null(response.Result.Parameters);
            Assert.NotNull(response.Result.RawData);
            Assert.Null(response.Result.DataDetails);
        }

        [Fact]
        public async Task TestDomainReputationMalicious_6()
        {
            // Default provider, verbose, raw
            var response = await client.Reputation(
                new DomainReputationRequest.Builder("737updatesboeing.com")
                    .WithVerbose(true)
                    .WithRaw(true)
                    .Build()
            );

            Assert.True(response.IsOK);

            var data = response.Result.Data;
            Assert.NotEmpty(data.Verdict);
            Assert.NotNull(response.Result.Parameters);
            Assert.NotNull(response.Result.RawData);
            Assert.Null(response.Result.DataDetails);
        }


        [Fact]
        public async Task TestDomainReputationMalicious_7()
        {
            // Provider, no verbose, no raw
            var response = await client.Reputation(
                new DomainReputationRequest.Builder("737updatesboeing.com")
                    .WithProvider("crowdstrike")
                    .WithVerbose(false)
                    .WithRaw(false)
                    .Build()
            );

            Assert.True(response.IsOK);

            var data = response.Result.Data;
            Assert.Equal("malicious", data.Verdict);
            Assert.Null(response.Result.Parameters);
            Assert.Null(response.Result.RawData);
            Assert.Null(response.Result.DataDetails);
        }

        [Fact]
        public async Task TestDomainReputationMalicious_8()
        {
            // Provider, verbose, raw
            var response = await client.Reputation(
                new DomainReputationRequest.Builder("737updatesboeing.com")
                    .WithProvider("crowdstrike")
                    .WithVerbose(true)
                    .WithRaw(true)
                    .Build()
            );

            Assert.True(response.IsOK);

            var data = response.Result.Data;
            Assert.Equal("malicious", data.Verdict);
            Assert.NotNull(response.Result.Parameters);
            Assert.NotNull(response.Result.RawData);
            Assert.Null(response.Result.DataDetails);
        }

        [Fact]
        public async Task TestDomainReputationBulk()
        {
            string[] domainList = { "pemewizubidob.cafij.co.za", "redbomb.com.tr", "kmbk8.hicp.net" };

            // Provider, verbose, raw
            var response = await client.Reputation(
                new DomainReputationRequest.Builder(domainList)
                    .WithProvider("crowdstrike")
                    .WithVerbose(true)
                    .WithRaw(true)
                    .Build()
            );

            Assert.True(response.IsOK);

            var data = response.Result.Data;
            Assert.Equal("malicious", data.Verdict);
            Assert.NotNull(response.Result.Parameters);
            Assert.NotNull(response.Result.RawData);
            Assert.NotNull(response.Result.DataDetails);
            Assert.Equal(3, response.Result.DataDetails.Count);
        }

        [Fact]
        public async Task TestDomainReputationMalicious_NotFound()
        {
            // Provider, verbose, raw
            var response = await client.Reputation(
                new DomainReputationRequest.Builder("thisshouldbeafakedomain123asd.com")
                    .WithProvider("crowdstrike")
                    .WithVerbose(true)
                    .WithRaw(true)
                    .Build()
            );

            Assert.True(response.IsOK);

            var data = response.Result.Data;
            Assert.NotNull(data);
            Assert.NotEmpty(data.Verdict);
            Assert.NotNull(data.Category);
            Assert.NotNull(response.Result.Parameters);
        }

        [Fact]
        public async Task TestEmptyIP()
        {
            await Assert.ThrowsAsync<ValidationException>(async () =>
            {
                var response = await client.Reputation(
                    new DomainReputationRequest.Builder("")
                        .Build()
                );
            });
        }

        [Fact]
        public async Task TestEmptyProvider()
        {
            await Assert.ThrowsAsync<ValidationException>(async () =>
            {
                var response = await client.Reputation(
                    new DomainReputationRequest.Builder("737updatesboeing.com")
                        .WithProvider("")
                        .Build()
                );
            });
        }

        [Fact]
        public async Task TestEmptyNotValidProvider()
        {
            await Assert.ThrowsAsync<ValidationException>(async () =>
            {
                var response = await client.Reputation(
                    new DomainReputationRequest.Builder("737updatesboeing.com")
                        .WithProvider("notavalidprovider")
                        .Build()
                );
            });
        }

        [Fact]
        public async Task TestUnauthorized()
        {
            Config cfg = Config.FromIntegrationEnvironment(environment);
            cfg = new Config("notarealtoken", cfg.Domain);
            DomainIntelClient fakeClient = new DomainIntelClient.Builder(cfg).Build();

            await Assert.ThrowsAsync<UnauthorizedException>(async () =>
            {
                var response = await fakeClient.Reputation(
                    new DomainReputationRequest.Builder("737updatesboeing.com")
                        .Build()
                );
            });
        }
    }
}
