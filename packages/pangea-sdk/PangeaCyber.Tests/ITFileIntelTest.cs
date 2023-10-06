using PangeaCyber.Net;
using PangeaCyber.Net.Intel;
using PangeaCyber.Net.Exceptions;

namespace PangeaCyber.Tests.Intel
{
    public class ITFileIntelTest
    {
        private FileIntelClient client;
        private TestEnvironment environment = TestEnvironment.LVE;

        public ITFileIntelTest()
        {
            client = new FileIntelClient.Builder(Config.FromIntegrationEnvironment(environment)).Build();
        }

        [Fact]
        public async Task TestFileReputationMalicious_1()
        {
            var response = await client.Reputation(new FileHashReputationRequest.Builder(
                    "142b638c6a60b60c7f9928da4fb85a5a8e1422a9ffdc9ee49e17e56ccca9cf6e",
                    "sha256")
                .WithProvider("reversinglabs")
                .WithVerbose(false)
                .WithRaw(false)
                .Build());

            Assert.True(response.IsOK);

            var data = response.Result.Data;
            Assert.Equal("malicious", data.Verdict);
            Assert.Equal("Trojan", data.Category[0]);
            Assert.Null(response.Result.Parameters);
            Assert.Null(response.Result.RawData);
        }

        [Fact]
        public async Task TestFileReputationMalicious_2()
        {
            var response = await client.Reputation(new FileHashReputationRequest.Builder(
                    "142b638c6a60b60c7f9928da4fb85a5a8e1422a9ffdc9ee49e17e56ccca9cf6e",
                    "sha256")
                .WithProvider("reversinglabs")
                .WithVerbose(true)
                .WithRaw(true)
                .Build());

            Assert.True(response.IsOK);

            var data = response.Result.Data;
            Assert.Equal("malicious", data.Verdict);
            Assert.Equal("Trojan", data.Category[0]);
            Assert.NotNull(response.Result.Parameters);
            Assert.NotNull(response.Result.RawData);
        }

        [Fact]
        public async Task TestFileReputationMalicious_3()
        {
            // Provider, no verbose by default, no raw data by default
            var response = await client.Reputation(new FileHashReputationRequest.Builder(
                "142b638c6a60b60c7f9928da4fb85a5a8e1422a9ffdc9ee49e17e56ccca9cf6e",
                "sha256"
            )
                .WithProvider("reversinglabs")
                .Build());

            Assert.True(response.IsOK);

            var data = response.Result.Data;
            Assert.Equal("malicious", data.Verdict);
            Assert.Equal("Trojan", data.Category[0]);
            Assert.Null(response.Result.Parameters);
            Assert.Null(response.Result.RawData);
        }

        [Fact]
        public async Task TestFileReputationMalicious_4()
        {
            // Default provider, no verbose by default, no raw data by default
            var response = await client.Reputation(new FileHashReputationRequest.Builder(
                "142b638c6a60b60c7f9928da4fb85a5a8e1422a9ffdc9ee49e17e56ccca9cf6e",
                "sha256"
            )
                .Build());

            // NOTE: because we're using the default provider in this test,
            // the resulting verdict can change based on the provider set as default
            // so only assert the response is successful
            Assert.True(response.IsOK);

            Assert.Null(response.Result.Parameters);
            Assert.Null(response.Result.RawData);
        }

        [Fact]
        public async Task TestFileReputationMalicious_5()
        {
            // Provider, verbose, no raw data
            var response = await client.Reputation(new FileHashReputationRequest.Builder(
                "142b638c6a60b60c7f9928da4fb85a5a8e1422a9ffdc9ee49e17e56ccca9cf6e",
                "sha256"
            )
                .WithProvider("reversinglabs")
                .WithVerbose(true)
                .WithRaw(false)
                .Build());

            Assert.True(response.IsOK);

            var data = response.Result.Data;
            Assert.Equal("malicious", data.Verdict);
            Assert.Equal("Trojan", data.Category[0]);
            Assert.NotNull(response.Result.Parameters);
            Assert.Null(response.Result.RawData);
        }

        [Fact]
        public async Task TestFileReputationMalicious_6()
        {
            // Provider, no verbose, raw data
            var response = await client.Reputation(new FileHashReputationRequest.Builder(
                "142b638c6a60b60c7f9928da4fb85a5a8e1422a9ffdc9ee49e17e56ccca9cf6e",
                "sha256"
            )
                .WithProvider("reversinglabs")
                .WithVerbose(false)
                .WithRaw(true)
                .Build());

            Assert.True(response.IsOK);

            var data = response.Result.Data;
            Assert.Equal("malicious", data.Verdict);
            Assert.Equal("Trojan", data.Category[0]);
            Assert.Null(response.Result.Parameters);
            Assert.NotNull(response.Result.RawData);
        }

        [Fact]
        public async Task TestFileReputationNotProvided()
        {
            var response = await client.Reputation(new FileHashReputationRequest.Builder(
                "178e2b8a4162372cd9344b81793cbf74a9513a002eda3324e6331243f3137a63",
                "sha256"
            )
                .WithProvider("reversinglabs")
                .WithVerbose(true)
                .WithRaw(true)
                .Build());

            Assert.True(response.IsOK);

            var data = response.Result.Data;
            Assert.Equal("unknown", data.Verdict);
            Assert.NotNull(response.Result.Parameters);
            Assert.NotNull(response.Result.RawData);
        }

        [Fact]
        public async Task TestEmptyProvider()
        {
            await Assert.ThrowsAsync<ValidationException>(async () =>
            {
                await client.Reputation(new FileHashReputationRequest.Builder(
                    "322ccbd42b7e4fd3a9d0167ca2fa9f6483d9691364c431625f1df542706",
                    "sha256"
                )
                    .WithProvider("")
                    .WithVerbose(true)
                    .WithRaw(true)
                    .Build());
            });
        }

        [Fact]
        public async Task TestNotValidProvider()
        {
            await Assert.ThrowsAsync<ValidationException>(async () =>
            {
                await client.Reputation(new FileHashReputationRequest.Builder(
                    "322ccbd42b7e4fd3a9d0167ca2fa9f6483d9691364c431625f1df542706",
                    "sha256"
                )
                    .WithProvider("notvalid")
                    .WithVerbose(true)
                    .WithRaw(true)
                    .Build());
            });
        }

        [Fact]
        public async Task TestEmptyHash()
        {
            await Assert.ThrowsAsync<ValidationException>(async () =>
            {
                await client.Reputation(new FileHashReputationRequest.Builder("", "sha256")
                    .WithProvider("reversinglabs")
                    .WithVerbose(true)
                    .WithRaw(true)
                    .Build());
            });
        }

        [Fact]
        public async Task TestNotValidHash()
        {
            await Assert.ThrowsAsync<ValidationException>(async () =>
            {
                await client.Reputation(new FileHashReputationRequest.Builder("notavalidhash", "sha256")
                    .WithProvider("reversinglabs")
                    .WithVerbose(true)
                    .WithRaw(true)
                    .Build());
            });
        }

        [Fact]
        public async Task TestEmptyHashType()
        {
            await Assert.ThrowsAsync<ValidationException>(async () =>
            {
                await client.Reputation(new FileHashReputationRequest.Builder(
                    "322ccbd42b7e4fd3a9d0167ca2fa9f6483d9691364c431625f1df542706",
                    "sha256"
                )
                    .WithProvider("")
                    .WithVerbose(true)
                    .WithRaw(true)
                    .Build());
            });
        }

        [Fact]
        public async Task TestNotValidHashType()
        {
            await Assert.ThrowsAsync<ValidationException>(async () =>
            {
                await client.Reputation(new FileHashReputationRequest.Builder(
                    "322ccbd42b7e4fd3a9d0167ca2fa9f6483d9691364c431625f1df542706",
                    "notvalid"
                )
                    .WithProvider("reversinglabs")
                    .WithVerbose(true)
                    .WithRaw(true)
                    .Build());
            });
        }

        [Fact]
        public async Task TestUnauthorized()
        {
            var cfg = Config.FromIntegrationEnvironment(TestEnvironment.LVE);
            cfg = new Config("notarealtoken", cfg.Domain);
            var fakeClient = new FileIntelClient.Builder(cfg).Build();
            await Assert.ThrowsAsync<UnauthorizedException>(async () =>
            {
                await fakeClient.Reputation(new FileHashReputationRequest.Builder(
                    "322ccbd42b7e4fd3a9d0167ca2fa9f6483d9691364c431625f1df542706",
                    "sha256"
                )
                    .WithProvider("reversinglabs")
                    .WithVerbose(true)
                    .WithRaw(true)
                    .Build());
            });
        }

        [Fact]
        public void TestSHA256fromFilepath()
        {
            var hash = FileIntelClient.CalculateSHA256fromFile("../../../../README.md");
            Assert.NotNull(hash);
            Assert.NotEqual(hash, string.Empty);
        }

        [Fact]
        public void TestSHA256fromFilepathNoFile()
        {
            Assert.Throws<PangeaException>(() =>
            {
                var hash = FileIntelClient.CalculateSHA256fromFile("./not/a/real/path/file.exe");
            });
        }

    }
}
