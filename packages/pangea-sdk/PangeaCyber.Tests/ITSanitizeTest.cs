using PangeaCyber.Net.Exceptions;
using PangeaCyber.Tests;

namespace PangeaCyber.Net.Sanitize.Tests
{
    [CollectionDefinition("Sanitize", DisableParallelization = true)]
    public class ITSanitizeTest
    {
        private const string TESTFILE_PATH = "./data/ds11.pdf";
        private SanitizeClient client;
        private readonly TestEnvironment environment = Helper.LoadTestEnvironment("sanitize", TestEnvironment.LVE);

        public ITSanitizeTest()
        {
            Config config = Config.FromIntegrationEnvironment(environment);
            client = new SanitizeClient.Builder(config).Build();
        }

        [SkippableFact(typeof(AcceptedRequestException), Timeout = 5 * 60 * 1000)]
        public async Task TestSanitizeAndShare()
        {
            var file = new FileStream(TESTFILE_PATH, FileMode.Open, FileAccess.Read);
            var response = await client.Sanitize(
                new SanitizeRequest()
                {
                    Content = new Content()
                    {
                        URLIntel = true,
                        URLIntelProvider = "crowdstrike",
                        DomainIntel = true,
                        DomainIntelProvider = "crowdstrike",
                        Defang = true,
                        DefangThreshold = 20,
                        RemoveAttachments = true,
                        RemoveInteractive = true,
                        Redact = true,
                    },
                    File = new SanitizeFile()
                    {
                        ScanProvider = "crowdstrike"
                    },
                    ShareOutput = new ShareOutput()
                    {
                        Enabled = true,
                        OutputFolder = "sdk_test/sanitize/"
                    },
                    RequestTransferMethod = TransferMethod.PostURL,
                    UploadedFileName = "uploaded_file",
                }, file);
            Assert.True(response.IsOK);
            Assert.Null(response.Result.DestURL);
            Assert.NotNull(response.Result.DestShareID);
            Assert.NotEmpty(response.Result.DestShareID);
            Assert.NotNull(response.Result.Data);

            Assert.NotNull(response.Result.Data.Redact);
            Assert.True(response.Result.Data.Redact.RedactionCount > 0);
            Assert.NotNull(response.Result.Data.Redact.SummaryCounts);
            Assert.NotEmpty(response.Result.Data.Redact.SummaryCounts);

            Assert.NotNull(response.Result.Data.Defang);
            Assert.True(response.Result.Data.Defang.ExternalDomainsCount > 0);
            Assert.True(response.Result.Data.Defang.ExternalURLsCount > 0);
            Assert.Equal(response.Result.Data.Defang.DefangedCount, 0);
            Assert.NotNull(response.Result.Data.Defang.DomainIntelSummary);
            Assert.NotEmpty(response.Result.Data.Defang.DomainIntelSummary);

            Assert.NotNull(response.Result.Data.CDR);
            Assert.Equal(response.Result.Data.CDR.FileAttachmentsRemoved, 0);
            Assert.Equal(response.Result.Data.CDR.InteractiveContentsRemoved, 0);

            Assert.False(response.Result.Data.MaliciousFile);
        }

        [SkippableFact(typeof(AcceptedRequestException), Timeout = 5 * 60 * 1000)]
        public async Task TestSanitizeNoShare()
        {
            var file = new FileStream(TESTFILE_PATH, FileMode.Open, FileAccess.Read);
            var response = await client.Sanitize(
                new SanitizeRequest()
                {
                    Content = new Content()
                    {
                        URLIntel = true,
                        URLIntelProvider = "crowdstrike",
                        DomainIntel = true,
                        DomainIntelProvider = "crowdstrike",
                        Defang = true,
                        DefangThreshold = 20,
                        RemoveAttachments = true,
                        RemoveInteractive = true,
                        Redact = true,
                    },
                    File = new SanitizeFile()
                    {
                        ScanProvider = "crowdstrike"
                    },
                    ShareOutput = new ShareOutput()
                    {
                        Enabled = false,
                    },
                    RequestTransferMethod = TransferMethod.PostURL,
                    UploadedFileName = "uploaded_file",
                }, file);

            Assert.True(response.IsOK);
            Assert.NotNull(response.Result.DestURL);
            Assert.NotEmpty(response.Result.DestURL);
            Assert.Null(response.Result.DestShareID);
            Assert.NotNull(response.Result.Data);

            Assert.NotNull(response.Result.Data.Redact);
            Assert.True(response.Result.Data.Redact.RedactionCount > 0);
            Assert.NotNull(response.Result.Data.Redact.SummaryCounts);
            Assert.NotEmpty(response.Result.Data.Redact.SummaryCounts);

            Assert.NotNull(response.Result.Data.Defang);
            Assert.True(response.Result.Data.Defang.ExternalDomainsCount > 0);
            Assert.True(response.Result.Data.Defang.ExternalURLsCount > 0);
            Assert.Equal(response.Result.Data.Defang.DefangedCount, 0);
            Assert.NotNull(response.Result.Data.Defang.DomainIntelSummary);
            Assert.NotEmpty(response.Result.Data.Defang.DomainIntelSummary);

            Assert.NotNull(response.Result.Data.CDR);
            Assert.Equal(response.Result.Data.CDR.FileAttachmentsRemoved, 0);
            Assert.Equal(response.Result.Data.CDR.InteractiveContentsRemoved, 0);

            Assert.False(response.Result.Data.MaliciousFile);

            var attachedFile = await client.DownloadFile(response.Result.DestURL);
        }

        [SkippableFact(typeof(AcceptedRequestException), Timeout = 5 * 60 * 1000)]
        public async Task TestSanitizeMultipart()
        {
            var file = new FileStream(TESTFILE_PATH, FileMode.Open, FileAccess.Read);
            var response = await client.Sanitize(
                new SanitizeRequest()
                {
                    Content = new Content()
                    {
                        URLIntel = true,
                        URLIntelProvider = "crowdstrike",
                        DomainIntel = true,
                        DomainIntelProvider = "crowdstrike",
                        Defang = true,
                        DefangThreshold = 20,
                        RemoveAttachments = true,
                        RemoveInteractive = true,
                        Redact = true,
                    },
                    File = new SanitizeFile()
                    {
                        ScanProvider = "crowdstrike"
                    },
                    ShareOutput = new ShareOutput()
                    {
                        Enabled = true,
                        OutputFolder = "sdk_test/sanitize/"
                    },
                    RequestTransferMethod = TransferMethod.Multipart,
                    UploadedFileName = "uploaded_file",
                }, file);
            Assert.True(response.IsOK);
            Assert.Null(response.Result.DestURL);
            Assert.NotNull(response.Result.DestShareID);
            Assert.NotEmpty(response.Result.DestShareID);
            Assert.NotNull(response.Result.Data);

            Assert.NotNull(response.Result.Data.Redact);
            Assert.True(response.Result.Data.Redact.RedactionCount > 0);
            Assert.NotNull(response.Result.Data.Redact.SummaryCounts);
            Assert.NotEmpty(response.Result.Data.Redact.SummaryCounts);

            Assert.NotNull(response.Result.Data.Defang);
            Assert.True(response.Result.Data.Defang.ExternalDomainsCount > 0);
            Assert.True(response.Result.Data.Defang.ExternalURLsCount > 0);
            Assert.Equal(response.Result.Data.Defang.DefangedCount, 0);
            Assert.NotNull(response.Result.Data.Defang.DomainIntelSummary);
            Assert.NotEmpty(response.Result.Data.Defang.DomainIntelSummary);

            Assert.NotNull(response.Result.Data.CDR);
            Assert.Equal(response.Result.Data.CDR.FileAttachmentsRemoved, 0);
            Assert.Equal(response.Result.Data.CDR.InteractiveContentsRemoved, 0);

            Assert.False(response.Result.Data.MaliciousFile);
        }

        [SkippableFact(typeof(AcceptedRequestException), Timeout = 5 * 60 * 1000)]
        public async Task TestSanitizeAllDefaults()
        {
            var file = new FileStream(TESTFILE_PATH, FileMode.Open, FileAccess.Read);
            var response = await client.Sanitize(
                new SanitizeRequest()
                {
                    RequestTransferMethod = TransferMethod.PostURL,
                    UploadedFileName = "uploaded_file",
                }, file);
            Assert.True(response.IsOK);
            Assert.NotNull(response.Result.DestURL);
            Assert.NotEmpty(response.Result.DestURL);
            Assert.Null(response.Result.DestShareID);
            Assert.NotNull(response.Result.Data);

            Assert.Null(response.Result.Data.Redact);

            Assert.NotNull(response.Result.Data.Defang);
            Assert.True(response.Result.Data.Defang.ExternalDomainsCount > 0);
            Assert.True(response.Result.Data.Defang.ExternalURLsCount > 0);
            Assert.Equal(response.Result.Data.Defang.DefangedCount, 0);
            Assert.NotNull(response.Result.Data.Defang.DomainIntelSummary);
            Assert.NotEmpty(response.Result.Data.Defang.DomainIntelSummary);

            Assert.NotNull(response.Result.Data.CDR);
            Assert.Equal(response.Result.Data.CDR.FileAttachmentsRemoved, 0);
            Assert.Equal(response.Result.Data.CDR.InteractiveContentsRemoved, 0);

            Assert.False(response.Result.Data.MaliciousFile);

            var attachedFile = await client.DownloadFile(response.Result.DestURL);
        }

        [SkippableFact(Timeout = 5 * 60 * 1000)]
        public async Task TestSanitize_AsyncPollResult()
        {
            Config config = Config.FromIntegrationEnvironment(environment);
            config.QueuedRetryEnabled = false;
            client = new SanitizeClient.Builder(config).Build();

            var file = new FileStream(TESTFILE_PATH, FileMode.Open, FileAccess.Read);
            AcceptedRequestException exception = default!;
            try
            {
                var response = await client.Sanitize(
                    new SanitizeRequest()
                    {
                        Content = new Content()
                        {
                            URLIntel = true,
                            URLIntelProvider = "crowdstrike",
                            DomainIntel = true,
                            DomainIntelProvider = "crowdstrike",
                            Defang = true,
                            DefangThreshold = 20,
                            RemoveAttachments = true,
                            RemoveInteractive = true,
                            Redact = true,
                        },
                        File = new SanitizeFile()
                        {
                            ScanProvider = "crowdstrike"
                        },
                        ShareOutput = new ShareOutput()
                        {
                            Enabled = true,
                            OutputFolder = "sdk_test/sanitize/"
                        },
                        RequestTransferMethod = TransferMethod.PostURL,
                        UploadedFileName = "uploaded_file",
                    }, file);

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
                    var response = await client.PollResult<SanitizeResult>(exception.RequestID);

                    Assert.True(response.IsOK);
                    Assert.Null(response.Result.DestURL);
                    Assert.NotNull(response.Result.DestShareID);
                    Assert.NotEmpty(response.Result.DestShareID);
                    Assert.NotNull(response.Result.Data);

                    Assert.NotNull(response.Result.Data.Redact);
                    Assert.True(response.Result.Data.Redact.RedactionCount > 0);
                    Assert.NotNull(response.Result.Data.Redact.SummaryCounts);
                    Assert.NotEmpty(response.Result.Data.Redact.SummaryCounts);

                    Assert.NotNull(response.Result.Data.Defang);
                    Assert.True(response.Result.Data.Defang.ExternalDomainsCount > 0);
                    Assert.True(response.Result.Data.Defang.ExternalURLsCount > 0);
                    Assert.Equal(response.Result.Data.Defang.DefangedCount, 0);
                    Assert.NotNull(response.Result.Data.Defang.DomainIntelSummary);
                    Assert.NotEmpty(response.Result.Data.Defang.DomainIntelSummary);

                    Assert.NotNull(response.Result.Data.CDR);
                    Assert.Equal(response.Result.Data.CDR.FileAttachmentsRemoved, 0);
                    Assert.Equal(response.Result.Data.CDR.InteractiveContentsRemoved, 0);

                    Assert.False(response.Result.Data.MaliciousFile);

                    // Poll result in raw format
                    var responseDictionary = await client.PollResult(exception.RequestID);
                    Assert.True(responseDictionary.IsOK);
                    return;
                }
                catch (AcceptedRequestException)
                {
                    // No-op.
                }
            }

            // Skip if result was not ready in time.
            Skip.If(true, $"Result of request '{exception.RequestID}' was not ready in time.");
        }

        [SkippableFact(Timeout = 5 * 60 * 1000)]
        public async Task TestSanitize_SplitUpload_Post()
        {
            var file = new FileStream(TESTFILE_PATH, FileMode.Open, FileAccess.Read);
            var fileParams = Utils.GetUploadFileParams(file);

            var urlResponse = await client.RequestUploadURL(
                new SanitizeRequest()
                {
                    Content = new Content()
                    {
                        URLIntel = true,
                        URLIntelProvider = "crowdstrike",
                        DomainIntel = true,
                        DomainIntelProvider = "crowdstrike",
                        Defang = true,
                        DefangThreshold = 20,
                        RemoveAttachments = true,
                        RemoveInteractive = true,
                        Redact = true,
                    },
                    File = new SanitizeFile()
                    {
                        ScanProvider = "crowdstrike"
                    },
                    ShareOutput = new ShareOutput()
                    {
                        Enabled = true,
                        OutputFolder = "sdk_test/sanitize/"
                    },
                    RequestTransferMethod = TransferMethod.PostURL,
                    UploadedFileName = "uploaded_file",
                    CRC32c = fileParams.CRC32C,
                    SHA256 = fileParams.SHA256,
                    Size = fileParams.Size,
                });

            Assert.NotNull(urlResponse.Result.PostURL);
            Assert.NotEmpty(urlResponse.Result.PostFormData);
            Assert.Null(urlResponse.Result.PutURL);

            var fileData = new FileData(file, "file", urlResponse.Result.PostFormData);
            string url = urlResponse.Result.PostURL;

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
                    var response = await client.PollResult<SanitizeResult>(urlResponse.RequestId);

                    Assert.True(response.IsOK);
                    Assert.Null(response.Result.DestURL);
                    Assert.NotNull(response.Result.DestShareID);
                    Assert.NotEmpty(response.Result.DestShareID);
                    Assert.NotNull(response.Result.Data);

                    Assert.NotNull(response.Result.Data.Redact);
                    Assert.True(response.Result.Data.Redact.RedactionCount > 0);
                    Assert.NotNull(response.Result.Data.Redact.SummaryCounts);
                    Assert.NotEmpty(response.Result.Data.Redact.SummaryCounts);

                    Assert.NotNull(response.Result.Data.Defang);
                    Assert.True(response.Result.Data.Defang.ExternalDomainsCount > 0);
                    Assert.True(response.Result.Data.Defang.ExternalURLsCount > 0);
                    Assert.Equal(response.Result.Data.Defang.DefangedCount, 0);
                    Assert.NotNull(response.Result.Data.Defang.DomainIntelSummary);
                    Assert.NotEmpty(response.Result.Data.Defang.DomainIntelSummary);

                    Assert.NotNull(response.Result.Data.CDR);
                    Assert.Equal(response.Result.Data.CDR.FileAttachmentsRemoved, 0);
                    Assert.Equal(response.Result.Data.CDR.InteractiveContentsRemoved, 0);

                    Assert.False(response.Result.Data.MaliciousFile);

                    // Poll result in raw format
                    var responseDictionary = await client.PollResult(urlResponse.RequestId);
                    Assert.True(responseDictionary.IsOK);
                    return;
                }
                catch (AcceptedRequestException)
                {
                    // No-op.
                }
            }

            // Skip if result was not ready in time.
            Skip.If(true, $"Result of request '{urlResponse.RequestId}' was not ready in time.");
        }

        [SkippableFact(Timeout = 5 * 60 * 1000)]
        public async Task TestSanitize_SplitUpload_Put()
        {
            var file = new FileStream(TESTFILE_PATH, FileMode.Open, FileAccess.Read);

            var urlResponse = await client.RequestUploadURL(
                new SanitizeRequest()
                {
                    Content = new Content()
                    {
                        URLIntel = true,
                        URLIntelProvider = "crowdstrike",
                        DomainIntel = true,
                        DomainIntelProvider = "crowdstrike",
                        Defang = true,
                        DefangThreshold = 20,
                        RemoveAttachments = true,
                        RemoveInteractive = true,
                        Redact = true,
                    },
                    File = new SanitizeFile()
                    {
                        ScanProvider = "crowdstrike"
                    },
                    ShareOutput = new ShareOutput()
                    {
                        Enabled = true,
                        OutputFolder = "sdk_test/sanitize/"
                    },
                    RequestTransferMethod = TransferMethod.PutURL,
                    UploadedFileName = "uploaded_file",
                });


            Assert.Null(urlResponse.Result.PostURL);
            Assert.Empty(urlResponse.Result.PostFormData);
            Assert.NotNull(urlResponse.Result.PutURL);

            var fileData = new FileData(file, "file");
            string url = urlResponse.Result.PutURL;

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
                    var response = await client.PollResult<SanitizeResult>(urlResponse.RequestId);

                    Assert.True(response.IsOK);
                    Assert.Null(response.Result.DestURL);
                    Assert.NotNull(response.Result.DestShareID);
                    Assert.NotEmpty(response.Result.DestShareID);
                    Assert.NotNull(response.Result.Data);

                    Assert.NotNull(response.Result.Data.Redact);
                    Assert.True(response.Result.Data.Redact.RedactionCount > 0);
                    Assert.NotNull(response.Result.Data.Redact.SummaryCounts);
                    Assert.NotEmpty(response.Result.Data.Redact.SummaryCounts);

                    Assert.NotNull(response.Result.Data.Defang);
                    Assert.True(response.Result.Data.Defang.ExternalDomainsCount > 0);
                    Assert.True(response.Result.Data.Defang.ExternalURLsCount > 0);
                    Assert.Equal(response.Result.Data.Defang.DefangedCount, 0);
                    Assert.NotNull(response.Result.Data.Defang.DomainIntelSummary);
                    Assert.NotEmpty(response.Result.Data.Defang.DomainIntelSummary);

                    Assert.NotNull(response.Result.Data.CDR);
                    Assert.Equal(response.Result.Data.CDR.FileAttachmentsRemoved, 0);
                    Assert.Equal(response.Result.Data.CDR.InteractiveContentsRemoved, 0);

                    Assert.False(response.Result.Data.MaliciousFile);

                    // Poll result in raw format
                    var responseDictionary = await client.PollResult(urlResponse.RequestId);
                    Assert.True(responseDictionary.IsOK);
                    return;
                }
                catch (AcceptedRequestException)
                {
                    // No-op.
                }
            }

            // Skip if result was not ready in time.
            Skip.If(true, $"Result of request '{urlResponse.RequestId}' was not ready in time.");
        }
    }
}
