using PangeaCyber.Net.Exceptions;
using System.Text;

namespace PangeaCyber.Net.Intel.Tests
{
    public class ITFileScanTest
    {
        private const string EICAR = "X5O!P%@AP[4\\PZX54(P^)7CC)7}$EICAR-STANDARD-ANTIVIRUS-TEST-FILE!$H+H*\n";
        private FileScanClient client;
        private TestEnvironment environment = TestEnvironment.DEV;

        public ITFileScanTest()
        {
            Config config = Config.FromIntegrationEnvironment(environment);
            client = new FileScanClient.Builder(config).Build();
        }

        private FileStream Eicar()
        {
            string filePath = "file.exe";

            // Convert the string to bytes
            byte[] byteArray = Encoding.UTF8.GetBytes(EICAR);

            // Create a FileStream and write the bytes to the file
            using (FileStream fileStream = new FileStream(filePath, FileMode.Create, FileAccess.Write))
            {
                fileStream.Write(byteArray, 0, byteArray.Length);
            }

            // Return the FileStream opened in read mode
            return new FileStream(filePath, FileMode.Open, FileAccess.Read);
        }

        [Fact]
        public async Task TestFileScan_Scan()
        {
            FileStream file = Eicar();
            var response = await client.Scan(new FileScanRequest.Builder().WithProvider("reversinglabs").Build(), file);
            Assert.True(response.IsOK);

            FileScanData data = response.Result.Data;
            Assert.Equal("malicious", data.Verdict);
            Assert.Null(response.Result.Parameters);
            Assert.Null(response.Result.RawData);
        }

        [Fact]
        public async Task TestFileScan_ScanAsync()
        {
            Config config = Config.FromIntegrationEnvironment(environment);
            config.QueuedRetryEnabled = false;
            client = new FileScanClient.Builder(config).Build();

            FileStream file = Eicar();
            await Assert.ThrowsAsync<AcceptedRequestException>(async () => {
                var response = await client.Scan(new FileScanRequest.Builder().WithProvider("reversinglabs").Build(), file);
            });
        }

        [Fact]
        public async Task TestFileScan_ScanAsyncPollResult()
        {
            Config config = Config.FromIntegrationEnvironment(environment);
            config.QueuedRetryEnabled = false;
            client = new FileScanClient.Builder(config).Build();

            FileStream file = Eicar();
            AcceptedRequestException exception = default!;
            try
            {
                var res = await client.Scan(new FileScanRequest.Builder().WithProvider("reversinglabs").Build(), file);
                Assert.False(true);
            }
            catch (AcceptedRequestException e)
            {
                exception = e;
            }

            // Sleep 60 seconds until result is (should) be ready
            await Task.Delay(60 * 1000);

            // Poll result, this could raise another AcceptedRequestException if result is not ready
            var response = await client.PollResult<FileScanResult>(exception.RequestID);
            Assert.True(response.IsOK);

            FileScanData data = response.Result.Data;
            Assert.Equal("malicious", data.Verdict);
            Assert.Null(response.Result.Parameters);
            Assert.Null(response.Result.RawData);

            // Poll result in raw format
            var responseDictionary = await client.PollResult(exception.RequestID);
            Assert.True(responseDictionary.IsOK);
        }
    }
}
