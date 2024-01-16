using PangeaCyber.Net;
using PangeaCyber.Net.Intel;

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
        public async Task TestUserBreached_ByPhoneNumberBulk()
        {
            var response = await client.BreachedBulk(
                new UserBreachedBulkRequest.Builder()
                    .WithPhoneNumbers(new string[] { "8005550123", "8005550124" })
                    .WithRaw(true)
                    .Build());
            Assert.True(response.IsOK);

            var data = response.Result.Data;
            Assert.Null(response.Result.Parameters);
            Assert.NotNull(response.Result.RawData);
            Assert.Equal(2, data.Count);
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
        public async Task TestUserBreached_ByEmailBulk()
        {
            var response = await client.BreachedBulk(
                new UserBreachedBulkRequest.Builder()
                    .WithEmails(new string[] { "test@example.com", "noreply@example.com" })
                    .WithRaw(true)
                    .Build());
            Assert.True(response.IsOK);

            var data = response.Result.Data;
            Assert.Null(response.Result.Parameters);
            Assert.NotNull(response.Result.RawData);
            Assert.Equal(2, data.Count);
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
        public async Task TestUserBreached_ByUsernameBulk()
        {
            var response = await client.BreachedBulk(
                new UserBreachedBulkRequest.Builder()
                    .WithUsernames(new string[] { "shortpatrick", "user1" })
                    .WithRaw(true)
                    .Build());
            Assert.True(response.IsOK);

            var data = response.Result.Data;
            Assert.Null(response.Result.Parameters);
            Assert.NotNull(response.Result.RawData);
            Assert.Equal(2, data.Count);
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
        public async Task TestUserBreached_ByIPBulk()
        {
            var response = await client.BreachedBulk(
                new UserBreachedBulkRequest.Builder()
                    .WithIPs(new string[] { "192.168.140.37", "1.1.1.1" })
                    .WithRaw(true)
                    .Build());
            Assert.True(response.IsOK);

            var data = response.Result.Data;
            Assert.Null(response.Result.Parameters);
            Assert.NotNull(response.Result.RawData);
            Assert.Equal(2, data.Count);
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

        [Fact]
        public async Task TestUserPasswordBreached_Bulk()
        {
            var response = await client.BreachedBulk(
                new UserPasswordBreachedBulkRequest.Builder(
                    HashType.SHA256,
                    new string[] { "5baa6", "5baa7" })
                .WithRaw(true).Build());
            Assert.True(response.IsOK);

            var data = response.Result.Data;
            Assert.Null(response.Result.Parameters);
            Assert.NotNull(response.Result.RawData);
            Assert.Equal(2, data.Count);
        }
    }
}
