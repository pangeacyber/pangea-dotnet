using System.IO;
using System.Threading.Tasks;
using PangeaCyber.Net;
using PangeaCyber.Net.Exceptions;
using PangeaCyber.Net.FileScan;
using Xunit;

namespace PangeaCyber.Tests.Integration
{
    [CollectionDefinition("File Scan", DisableParallelization = true)]
    public class ITFileScanTest
    {
        private const string TESTFILE_PATH = "./data/testfile.pdf";
        private FileScanClient client;
        private readonly TestEnvironment environment = Helper.LoadTestEnvironment("file-scan", TestEnvironment.LVE);

        public ITFileScanTest()
        {
            Config config = Config.FromIntegrationEnvironment(environment);
            client = new FileScanClient.Builder(config).Build();
        }

        [SkippableFact(typeof(AcceptedRequestException), Timeout = 5 * 60 * 1000)]
        public async Task TestFileScan_Scan_crowdstrike()
        {
            var file = new FileStream(TESTFILE_PATH, FileMode.Open, FileAccess.Read);
            var response = await client.Scan(new FileScanRequest.Builder().WithProvider("crowdstrike").WithRaw(true).WithVerbose(true).Build(), file);
            Assert.True(response.IsOK);

            FileScanData data = response.Result.Data;
            Assert.Equal("benign", data.Verdict);
            Assert.NotNull(response.Result.Parameters);
            Assert.NotNull(response.Result.RawData);
        }

        [SkippableFact(typeof(AcceptedRequestException), Timeout = 5 * 60 * 1000)]
        public async Task TestFileScan_Scan_multipart()
        {
            var file = new FileStream(TESTFILE_PATH, FileMode.Open, FileAccess.Read);
            var response = await client.Scan(new FileScanRequest.Builder().WithTransferMethod(TransferMethod.Multipart).WithRaw(true).WithVerbose(true).Build(), file);
            Assert.True(response.IsOK);

            FileScanData data = response.Result.Data;
            Assert.Equal("benign", data.Verdict);
            Assert.NotNull(response.Result.Parameters);
            Assert.NotNull(response.Result.RawData);
        }

        [SkippableFact(typeof(AcceptedRequestException), Timeout = 5 * 60 * 1000)]
        public async Task TestFileScan_ScanAsync_crowdstrike()
        {
            Config config = Config.FromIntegrationEnvironment(environment);
            config.QueuedRetryEnabled = false;
            client = new FileScanClient.Builder(config).Build();

            var file = new FileStream(TESTFILE_PATH, FileMode.Open, FileAccess.Read);
            await Assert.ThrowsAsync<AcceptedRequestException>(async () =>
            {
                var response = await client.Scan(new FileScanRequest.Builder().WithProvider("crowdstrike").Build(), file);
            });
        }

        [SkippableFact(typeof(AcceptedRequestException), Timeout = 5 * 60 * 1000)]
        public async Task TestFileScan_ScanAsyncPollResult_crowdstrike()
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

            int maxRetry = 12;
            for (int retry = 0; retry < maxRetry; retry++)
            {
                try
                {
                    // Sleep 10 seconds until result is (should) be ready
                    await Task.Delay(10 * 1000);

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
                    break;
                }
                catch (AcceptedRequestException)
                {
                    // No-op.
                }
            }
        }

        [SkippableFact(typeof(AcceptedRequestException), Timeout = 5 * 60 * 1000)]
        public async Task TestFileScan_Scan_reversinglabs()
        {
            var file = new FileStream(TESTFILE_PATH, FileMode.Open, FileAccess.Read);
            var response = await client.Scan(new FileScanRequest.Builder().WithProvider("reversinglabs").WithRaw(true).WithVerbose(true).Build(), file);
            Assert.True(response.IsOK);

            FileScanData data = response.Result.Data;
            Assert.Equal("benign", data.Verdict);
            Assert.NotNull(response.Result.Parameters);
            Assert.NotNull(response.Result.RawData);
        }

        [SkippableFact(typeof(AcceptedRequestException), Timeout = 5 * 60 * 1000)]
        public async Task TestFileScan_ScanAsync_reversinglabs()
        {
            Config config = Config.FromIntegrationEnvironment(environment);
            config.QueuedRetryEnabled = false;
            client = new FileScanClient.Builder(config).Build();

            var file = new FileStream(TESTFILE_PATH, FileMode.Open, FileAccess.Read);
            await Assert.ThrowsAsync<AcceptedRequestException>(async () =>
            {
                var response = await client.Scan(new FileScanRequest.Builder().WithProvider("reversinglabs").Build(), file);
            });
        }

        [SkippableFact(typeof(AcceptedRequestException), Timeout = 5 * 60 * 1000)]
        public async Task TestFileScan_ScanAsyncPollResult_reversinglabs()
        {
            Config config = Config.FromIntegrationEnvironment(environment);
            config.QueuedRetryEnabled = false;
            client = new FileScanClient.Builder(config).Build();

            var file = new FileStream(TESTFILE_PATH, FileMode.Open, FileAccess.Read);
            AcceptedRequestException exception = default!;
            try
            {
                var res = await client.Scan(new FileScanRequest.Builder().WithProvider("reversinglabs").WithVerbose(true).WithRaw(true).Build(), file);
                Assert.False(true);
            }
            catch (AcceptedRequestException e)
            {
                exception = e;
            }

            int maxRetry = 24;
            for (int retry = 0; retry < maxRetry; retry++)
            {
                try
                {
                    // Sleep 10 seconds until result is (should) be ready
                    await Task.Delay(10 * 1000);

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
                    break;
                }
                catch (AcceptedRequestException)
                {
                    // No-op.
                }
            }
        }

        [SkippableFact(typeof(AcceptedRequestException), Timeout = 5 * 60 * 1000)]
        public async Task TestFileScan_SplitUpload_Post()
        {
            var file = new FileStream(TESTFILE_PATH, FileMode.Open, FileAccess.Read);
            var fileParams = Utils.GetUploadFileParams(file);

            var urlResponse = await client.RequestUploadURL(new FileScanUploadURLRequest.Builder().WithProvider("reversinglabs").WithVerbose(true).WithRaw(true).WithTransferMethod(TransferMethod.PostURL).WithFileParams(fileParams).Build());

            var fileData = new FileData(file, "file", urlResponse.Result.PostFormData);
            string url = urlResponse.Result.PostURL ?? "undefined url";    // This case should never happen

            var uploader = new FileUploader.Builder().Build();
            await uploader.UploadFile(url, TransferMethod.PostURL, fileData);

            int maxRetry = 24;
            for (int retry = 0; retry < maxRetry; retry++)
            {
                try
                {
                    // Sleep 10 seconds until result is (should) be ready
                    await Task.Delay(10 * 1000);

                    // Poll result, this could raise another AcceptedRequestException if result is not ready
                    var response = await client.PollResult<FileScanResult>(urlResponse.RequestId);
                    Assert.True(response.IsOK);

                    FileScanData data = response.Result.Data;
                    Assert.Equal("benign", data.Verdict);
                    Assert.NotNull(response.Result.Parameters);
                    Assert.NotNull(response.Result.RawData);

                    // Poll result in raw format
                    var responseDictionary = await client.PollResult(urlResponse.RequestId);
                    Assert.True(responseDictionary.IsOK);
                    break;
                }
                catch (AcceptedRequestException)
                {
                    // No-op
                }
            }
        }

        [SkippableFact(typeof(AcceptedRequestException), Timeout = 5 * 60 * 1000)]
        public async Task TestFileScan_SplitUpload_Put()
        {
            var file = new FileStream(TESTFILE_PATH, FileMode.Open, FileAccess.Read);
            var urlResponse = await client.RequestUploadURL(new FileScanUploadURLRequest.Builder().WithProvider("reversinglabs").WithVerbose(true).WithRaw(true).WithTransferMethod(TransferMethod.PutURL).Build());

            var fileData = new FileData(file, "file");
            string url = urlResponse.Result.PutURL ?? "undefined url";    // This case should never happen

            var uploader = new FileUploader.Builder().Build();
            await uploader.UploadFile(url, TransferMethod.PutURL, fileData);

            int maxRetry = 24;
            for (int retry = 0; retry < maxRetry; retry++)
            {
                try
                {
                    // Sleep 10 seconds until result is (should) be ready
                    await Task.Delay(10 * 1000);

                    // Poll result, this could raise another AcceptedRequestException if result is not ready
                    var response = await client.PollResult<FileScanResult>(urlResponse.RequestId);
                    Assert.True(response.IsOK);

                    FileScanData data = response.Result.Data;
                    Assert.Equal("benign", data.Verdict);
                    Assert.NotNull(response.Result.Parameters);
                    Assert.NotNull(response.Result.RawData);

                    // Poll result in raw format
                    var responseDictionary = await client.PollResult(urlResponse.RequestId);
                    Assert.True(responseDictionary.IsOK);
                    break;
                }
                catch (AcceptedRequestException)
                {
                    // No-op.
                }
            }
        }
    }
}
