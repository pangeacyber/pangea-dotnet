using PangeaCyber.Net.Intel;
using PangeaCyber.Net;
namespace PangeaCyber.Tests.Intel
{
    public class ITUserIntelTest
    {
        private UserIntelClient client;
        private TestEnvironment environment = TestEnvironment.LVE;

        public ITUserIntelTest()
        {
            client = new UserIntelClient.Builder(Config.FromIntegrationEnvironment(environment)).Build();
        }

        [Fact]
        public async Task TestUserBreached_1()
        {
            var response = await client.Breached(new UserBreachedRequest.Builder().WithPhoneNumber("8005550123").Build());
            Assert.True(response.IsOK);

            var data = response.Result.Data;
            Assert.True(data.FoundInBreach);
            Assert.True(data.BreachCount > 0);
            Assert.Null(response.Result.Parameters);
            Assert.Null(response.Result.RawData);
        }

        [Fact]
        public async Task TestUserBreached_2()
        {
            var response = await client.Breached(new UserBreachedRequest.Builder().WithPhoneNumber("8005550123").WithProvider("spycloud").Build());
            Assert.True(response.IsOK);

            var data = response.Result.Data;
            Assert.True(data.FoundInBreach);
            Assert.True(data.BreachCount > 0);
            Assert.Null(response.Result.Parameters);
            Assert.Null(response.Result.RawData);
        }

        [Fact]
        public async Task TestUserBreached_3()
        {
            var response = await client.Breached(new UserBreachedRequest.Builder().WithPhoneNumber("8005550123").WithVerbose(true).Build());
            Assert.True(response.IsOK);

            var data = response.Result.Data;
            Assert.True(data.FoundInBreach);
            Assert.True(data.BreachCount > 0);
            Assert.NotNull(response.Result.Parameters);
            Assert.Null(response.Result.RawData);
        }

        [Fact]
        public async Task TestUserBreached_4()
        {
            var response = await client.Breached(new UserBreachedRequest.Builder().WithPhoneNumber("8005550123").WithRaw(true).Build());
            Assert.True(response.IsOK);

            var data = response.Result.Data;
            Assert.True(data.FoundInBreach);
            Assert.True(data.BreachCount > 0);
            Assert.Null(response.Result.Parameters);
            Assert.NotNull(response.Result.RawData);
        }

        [Fact]
        public async Task TestUserBreached_ByEmail()
        {
            var response = await client.Breached(new UserBreachedRequest.Builder().WithEmail("test@example.com").WithProvider("spycloud").Build());
            Assert.True(response.IsOK);

            var data = response.Result.Data;
            Assert.True(data.FoundInBreach);
            Assert.True(data.BreachCount > 0);
            Assert.Null(response.Result.Parameters);
            Assert.Null(response.Result.RawData);
        }

        [Fact]
        public async Task TestUserBreached_ByUsername()
        {
            var response = await client.Breached(new UserBreachedRequest.Builder().WithUsername("shortpatrick").WithProvider("spycloud").Build());
            Assert.True(response.IsOK);

            var data = response.Result.Data;
            Assert.True(data.FoundInBreach);
            Assert.True(data.BreachCount > 0);
            Assert.Null(response.Result.Parameters);
            Assert.Null(response.Result.RawData);
        }

        [Fact]
        public async Task TestUserBreached_ByIP()
        {
            var response = await client.Breached(new UserBreachedRequest.Builder().WithIP("192.168.140.37").WithProvider("spycloud").Build());
            Assert.True(response.IsOK);

            var data = response.Result.Data;
            Assert.True(data.FoundInBreach);
            Assert.True(data.BreachCount > 0);
            Assert.Null(response.Result.Parameters);
            Assert.Null(response.Result.RawData);
        }

        [Fact]
        public async Task TestUserPasswordBreached_1()
        {
            var response = await client.Breached(new UserPasswordBreachedRequest.Builder(HashType.SHA256, "5baa6").Build());
            Assert.True(response.IsOK);

            var data = response.Result.Data;
            Assert.True(data.FoundInBreach);
            Assert.True(data.BreachCount > 0);
            Assert.Null(response.Result.Parameters);
            Assert.Null(response.Result.RawData);
        }

        [Fact]
        public async Task TestUserPasswordBreached_2()
        {
            var response = await client.Breached(new UserPasswordBreachedRequest.Builder(HashType.SHA256, "5baa6").WithProvider("spycloud").Build());
            Assert.True(response.IsOK);

            var data = response.Result.Data;
            Assert.True(data.FoundInBreach);
            Assert.True(data.BreachCount > 0);
            Assert.Null(response.Result.Parameters);
            Assert.Null(response.Result.RawData);
        }

        [Fact]
        public async Task TestUserPasswordBreached_3()
        {
            var response = await client.Breached(new UserPasswordBreachedRequest.Builder(HashType.SHA256, "5baa6").WithVerbose(true).Build());
            Assert.True(response.IsOK);

            var data = response.Result.Data;
            Assert.True(data.FoundInBreach);
            Assert.True(data.BreachCount > 0);
            Assert.NotNull(response.Result.Parameters);
            Assert.Null(response.Result.RawData);
        }

        [Fact]
        public async Task TestUserPasswordBreached_4()
        {
            var response = await client.Breached(new UserPasswordBreachedRequest.Builder(HashType.SHA256, "5baa6").WithRaw(true).Build());
            Assert.True(response.IsOK);

            var data = response.Result.Data;
            Assert.True(data.FoundInBreach);
            Assert.True(data.BreachCount > 0);
            Assert.Null(response.Result.Parameters);
            Assert.NotNull(response.Result.RawData);
        }
    }
}