using PangeaCyber.Net.Exceptions;
using PangeaCyber.Net.Share.Models;
using PangeaCyber.Net.Share.Requests;
using PangeaCyber.Net.Share.Results;
using PangeaCyber.Tests;

namespace PangeaCyber.Net.Share.Tests
{
    public class ITShareTest
    {
        private const string TESTFILE_PATH = "./data/testfile.pdf";
        private const string ZERO_BYTES_FILE_PATH = "./data/zerobytes.txt";
        private ShareClient client;
        private readonly TestEnvironment environment = Helper.LoadTestEnvironment("share", TestEnvironment.LVE);

        private string time;

        private Metadata Metadata = new Metadata();
        private Metadata AddMetadata = new Metadata();
        private Tags Tags = new Tags();
        private Tags AddTags = new Tags();

        private string FolderDelete;
        private string FolderFiles;

        public ITShareTest()
        {
            Config config = Config.FromIntegrationEnvironment(environment);
            client = new ShareClient.Builder(config).Build();
            time = DateTime.Now.ToString("yyyyMMdd_HHmmss");
            FolderDelete = "/sdk_tests/delete/" + time;
            FolderFiles = "/sdk_tests/files/" + time;
            Metadata.Add("field1", "value1");
            Metadata.Add("field2", "value2");
            AddMetadata.Add("field3", "value3");
            Tags.Add("tag1");
            Tags.Add("tag2");
            AddTags.Add("tag3");
        }

        [Fact]
        public async Task TestBuckets()
        {
            var response = await client.Buckets();
            Assert.True(response.IsOK);
            Assert.NotEmpty(response.Result.Buckets);
        }


        [Fact(Timeout = 60 * 1000)]
        public async Task TestFolder()
        {
            var respCreate = await client.FolderCreate(
                new FolderCreateRequest
                {
                    Path = FolderDelete
                }
            );

            Assert.True(respCreate.IsOK);
            Assert.NotNull(respCreate.Result.Object.ID);
            Assert.NotEqual("", respCreate.Result.Object.ID);
            Assert.NotNull(respCreate.Result.Object.Name);
            Assert.NotEqual("", respCreate.Result.Object.Name);
            Assert.NotNull(respCreate.Result.Object.CreatedAt);
            Assert.NotEqual("", respCreate.Result.Object.CreatedAt);
            Assert.NotNull(respCreate.Result.Object.UpdatedAt);
            Assert.NotEqual("", respCreate.Result.Object.UpdatedAt);

            string id = respCreate.Result.Object.ID;

            var respDelete = await client.Delete(new DeleteRequest
            {
                ID = id
            });
            Assert.True(respDelete.IsOK);
            Assert.Equal(1, respDelete.Result.Count);
        }

        [Fact]
        public async Task TestPutTransferMethodPostURL()
        {
            string name = $"{time}_file_post_url";
            var fileStream = new FileStream(TESTFILE_PATH, FileMode.Open);

            var respPut = await client.Put(
                new PutRequest
                {
                    Name = name,
                    RequestTransferMethod = TransferMethod.PostURL
                },
                fileStream
            );

            Assert.True(respPut.IsOK);
            string id = respPut.Result.Object.ID;
            Assert.NotNull(id);
            Assert.NotEmpty(id);

            var respGet = await client.Get(
                new GetRequest
                {
                    ID = id,
                    RequestTransferMethod = TransferMethod.Multipart,
                }
            );

            Assert.True(respGet.IsOK);
            Assert.Null(respGet.Result.DestURL);
            Assert.Single(respGet.AttachedFiles);
            // respGet.AttachedFiles[0].Save("./download/", respGet.AttachedFiles[0].Filename);

            respGet = await client.Get(
                new GetRequest
                {
                    ID = id,
                    RequestTransferMethod = TransferMethod.DestURL,
                }
            );

            Assert.True(respGet.IsOK);
            Assert.NotNull(respGet.Result.DestURL);
            Assert.Empty(respGet.AttachedFiles);
        }

        [Fact]
        public async Task TestPutZeroBytesTransferMethodPostURL()
        {
            string name = $"{time}_file_zero_bytes_post_url";
            var fileStream = new FileStream(ZERO_BYTES_FILE_PATH, FileMode.Open);

            var respPut = await client.Put(
                new PutRequest
                {
                    Name = name,
                    RequestTransferMethod = TransferMethod.PostURL
                },
                fileStream
            );

            Assert.True(respPut.IsOK);
            string id = respPut.Result.Object.ID;
            Assert.NotNull(id);
            Assert.NotEmpty(id);

            var respGet = await client.Get(
                new GetRequest
                {
                    ID = id,
                    RequestTransferMethod = TransferMethod.Multipart,
                }
            );

            Assert.True(respGet.IsOK);
            Assert.Null(respGet.Result.DestURL);
            Assert.Single(respGet.AttachedFiles);
            // respGet.AttachedFiles[0].Save("./download/", respGet.AttachedFiles[0].Filename);

            respGet = await client.Get(
                new GetRequest
                {
                    ID = id,
                    RequestTransferMethod = TransferMethod.DestURL,
                }
            );

            Assert.True(respGet.IsOK);
            Assert.NotNull(respGet.Result.DestURL);    // No URL because empty file
            Assert.Empty(respGet.AttachedFiles);
        }

        [Fact]
        public async Task TestPutTransferMethodMultipart()
        {
            string name = $"{time}_file_multipart";
            var fileStream = new FileStream(TESTFILE_PATH, FileMode.Open);

            var respPut = await client.Put(
                new PutRequest
                {
                    Name = name,
                    RequestTransferMethod = TransferMethod.Multipart
                },
                fileStream
            );

            Assert.True(respPut.IsOK);
            string id = respPut.Result.Object.ID;
            Assert.NotNull(id);
            Assert.NotEmpty(id);

            var respGet = await client.Get(
                new GetRequest
                {
                    ID = id,
                    RequestTransferMethod = TransferMethod.Multipart,
                }
            );

            Assert.True(respGet.IsOK);
            Assert.Null(respGet.Result.DestURL);
            Assert.Single(respGet.AttachedFiles);
            // respGet.AttachedFiles[0].Save("./download/", respGet.AttachedFiles[0].Filename);

            respGet = await client.Get(
                new GetRequest
                {
                    ID = id,
                    RequestTransferMethod = TransferMethod.DestURL,
                }
            );

            Assert.True(respGet.IsOK);
            Assert.NotNull(respGet.Result.DestURL);
            Assert.Empty(respGet.AttachedFiles);
        }

        [Fact]
        public async Task TestPutZeroByteTransferMethodMultipart()
        {
            string name = $"{time}_file_zero_bytes_multipart";
            var fileStream = new FileStream(ZERO_BYTES_FILE_PATH, FileMode.Open);

            var respPut = await client.Put(
                new PutRequest
                {
                    Name = name,
                    RequestTransferMethod = TransferMethod.Multipart
                },
                fileStream
            );

            Assert.True(respPut.IsOK);
            string id = respPut.Result.Object.ID;
            Assert.NotNull(id);
            Assert.NotEmpty(id);

            var respGet = await client.Get(
                new GetRequest
                {
                    ID = id,
                    RequestTransferMethod = TransferMethod.Multipart,
                }
            );

            Assert.True(respGet.IsOK);
            Assert.Null(respGet.Result.DestURL);
            Assert.Single(respGet.AttachedFiles);
            // respGet.AttachedFiles[0].Save("./download/", respGet.AttachedFiles[0].Filename);

            respGet = await client.Get(
                new GetRequest
                {
                    ID = id,
                    RequestTransferMethod = TransferMethod.DestURL,
                }
            );

            Assert.True(respGet.IsOK);
            Assert.NotNull(respGet.Result.DestURL);
            Assert.Empty(respGet.AttachedFiles);
        }


        [Fact]
        public async Task TestFileScanSplitUploadPost()
        {
            string name = $"{time}_file_split_post_url";
            var fileStream = new FileStream(TESTFILE_PATH, FileMode.Open);

            var fileParams = Utils.GetUploadFileParams(fileStream);

            var acceptedResponse = await client.RequestUploadURL(
                new PutRequest
                {
                    Name = name,
                    RequestTransferMethod = TransferMethod.PostURL,
                    SHA256 = fileParams.SHA256,
                    CRC32c = fileParams.CRC32C,
                    Size = fileParams.Size
                }
            );

            string url = acceptedResponse.Result.PostURL ?? "";
            var details = acceptedResponse.Result.PostFormData;

            FileData fileData = new FileData(fileStream, "file", details);

            FileUploader fileUploader = new FileUploader.Builder().Build();
            await fileUploader.UploadFile(url, TransferMethod.PostURL, fileData);

            int maxRetry = 12;
            for (int retry = 0; retry < maxRetry; retry++)
            {
                try
                {
                    // Sleep 10 seconds until result is (should) be ready
                    await Task.Delay(10 * 1000);

                    // Poll result, this could raise another AcceptedRequestException if result is not ready
                    var response = await client.PollResult<PutResult>(acceptedResponse.RequestId);
                    Assert.True(response.IsOK);
                    break;
                }
                catch (PangeaAPIException)
                {
                    Assert.True(retry < maxRetry - 1);
                }
            }
        }

        // FIXME: Uncomment when testing on stg/live
        [Fact]
        public async Task TestFileScanSplitUploadPut()
        {
            string name = $"{time}_file_split_post_url";
            var fileStream = new FileStream(TESTFILE_PATH, FileMode.Open);

            var acceptedResponse = await client.RequestUploadURL(
                new PutRequest
                {
                    Name = name,
                    RequestTransferMethod = TransferMethod.PutURL,
                }
            );

            string url = acceptedResponse.Result.PutURL ?? "";

            FileData fileData = new FileData(fileStream, "file");

            FileUploader fileUploader = new FileUploader.Builder().Build();
            await fileUploader.UploadFile(url, TransferMethod.PutURL, fileData);

            int maxRetry = 12;
            for (int retry = 0; retry < maxRetry; retry++)
            {
                try
                {
                    // Sleep 10 seconds until result is (should) be ready
                    await Task.Delay(10 * 1000);

                    // Poll result, this could raise another AcceptedRequestException if result is not ready
                    var response = await client.PollResult<PutResult>(acceptedResponse.RequestId);
                    Assert.True(response.IsOK);
                    break;
                }
                catch (PangeaAPIException)
                {
                    Assert.True(retry < maxRetry - 1, "Failed to poll result");
                }
            }
        }

        [Fact]
        public async Task TestLifeCycle()
        {
            // Create a folder
            var respCreate = await client.FolderCreate(
                new FolderCreateRequest
                {
                    Path = FolderFiles
                }
            );

            Assert.True(respCreate.IsOK);
            string folderID = respCreate.Result.Object.ID;

            // Upload a file with path as a unique param
            string path = $"{FolderFiles}/{time}_file_multipart_1";
            var fileStream = new FileStream(TESTFILE_PATH, FileMode.Open);

            var respPutPath = await client.Put(
                new PutRequest
                {
                    Path = path,
                    RequestTransferMethod = TransferMethod.Multipart,
                },
                fileStream
            );

            Assert.True(respPutPath.IsOK);
            Assert.Equal(folderID, respPutPath.Result.Object.ParentID);
            Assert.Null(respPutPath.Result.Object.Metadata);
            Assert.Null(respPutPath.Result.Object.Tags);
            Assert.Null(respPutPath.Result.Object.MD5);
            Assert.Null(respPutPath.Result.Object.SHA512);
            Assert.NotNull(respPutPath.Result.Object.SHA256);

            // Upload a file with parent id and name
            fileStream = new FileStream(TESTFILE_PATH, FileMode.Open);

            string name = $"{time}_file_multipart_2";
            var respPutID = await client.Put(
                new PutRequest
                {
                    Name = name,
                    ParentId = folderID,
                    RequestTransferMethod = TransferMethod.Multipart,
                    Metadata = Metadata,
                    Tags = Tags
                },
                fileStream
            );

            Assert.True(respPutID.IsOK);
            Assert.Equal(folderID, respPutID.Result.Object.ParentID);
            Assert.Equal(Metadata, respPutID.Result.Object.Metadata);
            Assert.Equal(Tags, respPutID.Result.Object.Tags);
            Assert.Null(respPutID.Result.Object.MD5);
            Assert.Null(respPutID.Result.Object.SHA512);
            Assert.NotNull(respPutID.Result.Object.SHA256);


            // Update file. Full metadata and tags
            var respUpdate = await client.Update(
                new UpdateRequest
                {
                    ID = respPutPath.Result.Object.ID,
                    Metadata = Metadata,
                    Tags = Tags,
                }
            );

            Assert.True(respUpdate.IsOK);
            Assert.Equal(Metadata, respUpdate.Result.Object.Metadata);
            Assert.Equal(Tags, respUpdate.Result.Object.Tags);

            // Update file. Add metadata and tags
            var respUpdateAdd = await client.Update(
                new UpdateRequest
                {
                    ID = respPutPath.Result.Object.ID,
                    AddMetadata = AddMetadata,
                    AddTags = AddTags,
                }
            );

            Assert.True(respUpdateAdd.IsOK);
            var metadataFinal = Metadata.Concat(AddMetadata).ToDictionary(pair => pair.Key, pair => pair.Value);
            var tagsFinal = new Tags();
            tagsFinal.AddRange(Tags);
            tagsFinal.AddRange(AddTags);

            Assert.Equal(metadataFinal, respUpdateAdd.Result.Object.Metadata);
            Assert.Equal(tagsFinal, respUpdateAdd.Result.Object.Tags);

            // Get archive multipart
            var respGetArchive = await client.GetArchive(
                new GetArchiveRequest
                {
                    IDs = new List<string> { folderID },
                    Format = ArchiveFormat.Tar,
                    RequestTransferMethod = TransferMethod.Multipart,
                }
            );

            // Asserts and save attached files
            Assert.True(respGetArchive.IsOK);
            Assert.Single(respGetArchive.AttachedFiles);
            Assert.Null(respGetArchive.Result.DestUrl);

            foreach (AttachedFile attachedFile in respGetArchive.AttachedFiles)
            {
                Assert.Equal("application/octet-stream", attachedFile.ContentType);
                // FIXME: Can not save, permission denied
                // attachedFile.Save("../../../../", "archive.tar");
            }

            // Get archive URL
            var respGetArchiveURL = await client.GetArchive(
                new GetArchiveRequest
                {
                    IDs = new List<string> { folderID },
                    Format = ArchiveFormat.Tar,
                    RequestTransferMethod = TransferMethod.DestURL,
                }
            );

            // Asserts
            Assert.True(respGetArchiveURL.IsOK);
            Assert.Empty(respGetArchiveURL.AttachedFiles);
            Assert.NotNull(respGetArchiveURL.Result.DestUrl);

            // Download file
            string url = respGetArchiveURL.Result.DestUrl;
            AttachedFile downloadedFile = await client.DownloadFile(url);
            Assert.NotNull(downloadedFile);
            Assert.NotEmpty(downloadedFile.Filename);
            Assert.NotEmpty(downloadedFile.ContentType);
            Assert.NotEmpty(downloadedFile.FileContent);

            // Create share link
            var authenticators = new List<Authenticator>
            {
                new Authenticator(AuthenticatorType.Password, "somepassword")
            };

            var linkList = new List<ShareLinkCreateItem>
            {
                new ShareLinkCreateItem {
                    Targets = new List<string> { folderID },
                    LinkType = LinkType.Editor,
                    MaxAccessCount = 3,
                    Authenticators = authenticators,
                }
            };

            var respCreateLink = await client.ShareLinkCreate(
                new ShareLinkCreateRequest
                {
                    Links = linkList
                }
            );

            // Asserts for creating share link
            Assert.True(respCreateLink.IsOK);
            List<ShareLinkItem> links = respCreateLink.Result.ShareLinkObjects;
            Assert.Single(links);

            ShareLinkItem link = links[0];
            Assert.Equal(0, link.AccessCount);
            Assert.Equal(3, link.MaxAccessCount);
            Assert.Single(link.Authenticators);
            Assert.Equal(AuthenticatorType.Password, link.Authenticators[0].AuthType);
            Assert.NotNull(link.Link);
            Assert.NotNull(link.ID);
            Assert.Single(link.Targets);

            // Get share link
            var respGetLink = await client.ShareLinkGet(
                new ShareLinkGetRequest
                {
                    ID = link.ID
                }
            );

            // Asserts for getting share link
            Assert.True(respGetLink.IsOK);
            Assert.Equal(link.Link, respGetLink.Result.ShareLinkObject.Link);
            Assert.Equal(0, respGetLink.Result.ShareLinkObject.AccessCount);
            Assert.Equal(3, respGetLink.Result.ShareLinkObject.MaxAccessCount);
            Assert.Equal(link.ExpiresAt, respGetLink.Result.ShareLinkObject.ExpiresAt);
            Assert.Equal(link.CreatedAt, respGetLink.Result.ShareLinkObject.CreatedAt);

            // List share link
            var respListLink = await client.ShareLinkList(new ShareLinkListRequest());

            // Asserts for listing share links
            Assert.True(respListLink.IsOK);
            Assert.True(respListLink.Result.Count > 0);
            Assert.True(respListLink.Result.ShareLinkObjects.Count > 0);

            // Delete share link
            var respDeleteLink = await client.ShareLinkDelete(
                new ShareLinkDeleteRequest
                {
                    IDs = new List<string> { link.ID },
                }
            );

            // Asserts for deleting share link
            Assert.True(respDeleteLink.IsOK);
            Assert.Single(respDeleteLink.Result.ShareLinkObjects);

            // List files in folder
            FilterList filterList = new FilterList();
            filterList.Folder.Set(FolderFiles);
            var respList = await client.List(new ListRequest
            {
                Filter = filterList
            });

            // Asserts for listing files in folder
            Assert.True(respList.IsOK);
            Assert.Equal(2, respList.Result.Count);
            Assert.Equal(2, respList.Result.Objects.Count);

        }

    }
}
