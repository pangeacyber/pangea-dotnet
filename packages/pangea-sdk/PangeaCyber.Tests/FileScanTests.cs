using PangeaCyber.Net.Exceptions;

namespace PangeaCyber.Net.Intel.Tests
{
    public class ITFileScanTest
    {
        private const string TESTFILE_PATH = "./data/testfile.pdf";
        private FileScanClient client;
        private readonly TestEnvironment environment = TestEnvironment.LVE;

        public ITFileScanTest()
        {
            Config config = Config.FromIntegrationEnvironment(environment);
            client = new FileScanClient.Builder(config).Build();
        }

        [Fact]
        public async Task TestFileScan_Scan()
        {
            var file = new FileStream(TESTFILE_PATH, FileMode.Open, FileAccess.Read);
            var response = await client.Scan(new FileScanRequest.Builder().WithProvider("crowdstrike").WithRaw(true).WithVerbose(true).Build(), file);
            Assert.True(response.IsOK);

            FileScanData data = response.Result.Data;
            Assert.Equal("benign", data.Verdict);
            Assert.NotNull(response.Result.Parameters);
            Assert.NotNull(response.Result.RawData);
        }

        [Fact]
        public async Task TestFileScan_ScanAsync()
        {
            Config config = Config.FromIntegrationEnvironment(environment);
            config.QueuedRetryEnabled = false;
            client = new FileScanClient.Builder(config).Build();

            var file = new FileStream(TESTFILE_PATH, FileMode.Open, FileAccess.Read);
            await Assert.ThrowsAsync<AcceptedRequestException>(async () => {
                var response = await client.Scan(new FileScanRequest.Builder().WithProvider("crowdstrike").Build(), file);
            });
        }

        [Fact]
        public async Task TestFileScan_ScanAsyncPollResult()
        {
            Config config = Config.FromIntegrationEnvironment(environment);
            config.QueuedRetryEnabled = false;
            client = new FileScanClient.Builder(config).Build();

            var file = new FileStream(TESTFILE_PATH, FileMode.Open, FileAccess.Read);
            AcceptedRequestException exception = default!;
            try
            {
                var res = await client.Scan(new FileScanRequest.Builder().WithProvider("crowdstrike").WithVerbose(true).WithRaw(true).Build(), file);
                Assert.False(true);
            }
            catch (AcceptedRequestException e)
            {
                exception = e;
            }

            // Sleep 20 seconds until result is (should) be ready
            await Task.Delay(20 * 1000);

            // Poll result, this could raise another AcceptedRequestException if result is not ready
            var response = await client.PollResult<FileScanResult>(exception.RequestID);
            Assert.True(response.IsOK);

            FileScanData data = response.Result.Data;
            Assert.Equal("benign", data.Verdict);
            Assert.NotNull(response.Result.Parameters);
            Assert.NotNull(response.Result.RawData);

            // Poll result in raw format
            var responseDictionary = await client.PollResult(exception.RequestID);
            Assert.True(responseDictionary.IsOK);
        }
    }
}
