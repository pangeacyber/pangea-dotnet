using PangeaCyber.Net.Exceptions;
using PangeaCyber.Tests;

namespace PangeaCyber.Net.Embargo.Tests
{
    public class ITEmbargoTest
    {
        private EmbargoClient client;
        private readonly TestEnvironment environment = Helper.LoadTestEnvironment("embargo", TestEnvironment.LVE);

        public ITEmbargoTest()
        {
            client = new EmbargoClient.Builder(Config.FromIntegrationEnvironment(environment)).Build();
        }

        [Fact]
        public async void TestISOCheckSanctionedCountry()
        {
            Response<EmbargoSanctions> response = await client.ISOCheck("CU");
            Assert.True(response.IsOK);

            EmbargoSanctions result = response.Result;
            Assert.True(result.Count > 0);
            Assert.NotNull(result.Sanctions);
            EmbargoSanction sanction = result.Sanctions.ElementAt(0);
            Assert.Equal("Cuba", sanction.EmbargoedCountryName);
        }

        [Fact]
        public async void TestISOCheckNoSanctionedCountry()
        {
            Response<EmbargoSanctions> response = await client.ISOCheck("AR");
            Assert.True(response.IsOK);

            EmbargoSanctions result = response.Result;
            Assert.True(result.Count == 0);
        }

        [Fact]
        public async void TestIPCheckSanctionedCountry()
        {
            Response<EmbargoSanctions> response = await client.IPCheck("213.24.238.26");
            Assert.True(response.IsOK);

            EmbargoSanctions result = response.Result;
            Assert.True(result.Count > 0);
            Assert.NotNull(result.Sanctions);
            EmbargoSanction sanction = result.Sanctions.ElementAt(0);
            Assert.Equal("Russia", sanction.EmbargoedCountryName);
            Assert.Equal("RU", sanction.EmbargoedCountryISOCode);
            Assert.Equal("US", sanction.IssuingCountry);
            Assert.Equal("US - ITAR", sanction.ListName);
        }

        [Fact]
        public async void TestEmptyIP()
        {
            await Assert.ThrowsAsync<ValidationException>(async () =>
            {
                await client.IPCheck("");
            });
        }

        [Fact]
        public async void TestPrintError()
        {
            try
            {
                await client.IPCheck("");
                Assert.True(false);
            }
            catch (PangeaAPIException e)
            {
                Assert.NotEmpty(e.ToString());
                Console.WriteLine(e.ToString());
            }
        }

        [Fact]
        public async void TestUnauthorized()
        {
            Config cfg = Config.FromIntegrationEnvironment(environment);
            cfg = new Config("notarealtoken", cfg.Domain);
            EmbargoClient fakeClient = new EmbargoClient.Builder(cfg).Build();

            await Assert.ThrowsAsync<UnauthorizedException>(async () =>
            {
                await fakeClient.IPCheck("1.1.1.1");
            });
        }
    }
}
