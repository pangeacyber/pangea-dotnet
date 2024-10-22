using PangeaCyber.Net.Exceptions;
using PangeaCyber.Net.Share.Models;
using PangeaCyber.Net.Share.Requests;
using PangeaCyber.Net.Share.Results;

namespace PangeaCyber.Net.Share
{
    /// <summary>Secure Share client.</summary>
    /// <remarks>Secure Share</remarks>
    /// <example>
    /// <code>
    /// var config = new Config("pangea_token", "pangea_domain");
    /// var builder = new ShareClient.Builder(config);
    /// var client = builder.Build();
    /// </code>
    /// </example>
    public class ShareClient : BaseClient<ShareClient.Builder>
    {
        /// <summary>Service name.</summary>
        public static string ServiceName { get; } = "share";

        /// <summary>Create a new <see cref="ShareClient"/> using the given builder.</summary>
        /// <param name="builder">Secure Share client builder.</param>
        protected ShareClient(Builder builder) : base(builder, ServiceName)
        {
            ConfigID = builder.ConfigID ?? ConfigID;
        }

        /// <summary>Get information on the accessible buckets.</summary>
        /// <remarks>Buckets</remarks>
        /// <operationid>share_post_v1_buckets</operationid>
        /// <exception cref="PangeaException">Thrown if an error occurs during the operation.</exception>
        /// <exception cref="PangeaAPIException">Thrown if the API returns an error response.</exception>
        /// <example>
        /// <code>
        /// var response = await client.Buckets();
        /// </code>
        /// </example>
        public async Task<Response<BucketsResult>> Buckets()
        {
            return await DoPost<BucketsResult>("/v1/buckets", new BaseRequest());
        }

        /// <summary>
        /// Delete object by ID.
        /// </summary>
        /// <remarks>Delete</remarks>
        /// <operationid>share_post_v1_delete</operationid>
        /// <exception cref="PangeaException">Thrown if an error occurs during the operation.</exception>
        /// <exception cref="PangeaAPIException">Thrown if the API returns an error response.</exception>
        /// <example>
        /// <code>
        /// var response = await client.Delete(new DeleteRequest
        /// {
        ///     ID = "abc"
        /// });
        /// </code>
        /// </example>
        public async Task<Response<DeleteResult>> Delete(DeleteRequest request)
        {
            return await DoPost<DeleteResult>("/v1/delete", request);
        }

        /// <summary>
        /// Create a folder, either by name or path and parent_id.
        /// </summary>
        /// <remarks>Create a folder</remarks>
        /// <operationid>share_post_v1_folder_create</operationid>
        /// <exception cref="PangeaException">Thrown if an error occurs during the operation.</exception>
        /// <exception cref="PangeaAPIException">Thrown if the API returns an error response.</exception>
        /// <example>
        /// <code>
        /// var response = await client.FolderCreate(
        ///     new FolderCreateRequest
        ///     {
        ///         Folder = "/path/to/new/folder"
        ///     }
        /// );
        /// </code>
        /// </example>
        public async Task<Response<FolderCreateResult>> FolderCreate(FolderCreateRequest request)
        {
            return await DoPost<FolderCreateResult>("/v1/folder/create", request);
        }

        /// <summary>
        /// Get object.
        /// </summary>
        /// <remarks>Get an object</remarks>
        /// <operationid>share_post_v1_folder_create</operationid>
        /// <exception cref="PangeaException">Thrown if an error occurs during the operation.</exception>
        /// <exception cref="PangeaAPIException">Thrown if the API returns an error response.</exception>
        /// <example>
        /// <code>
        /// var response = await client.Get(
        ///     new GetRequest
        ///     {
        ///         ID = "pos_[...]",
        ///         RequestTransferMethod = TransferMethod.DestURL,
        ///     }
        /// );
        /// </code>
        /// </example>
        public async Task<Response<GetResult>> Get(GetRequest request)
        {
            return await DoPost<GetResult>("/v1/get", request);
        }

        /// <summary>
        /// Get an archive file of multiple objects.
        /// </summary>
        /// <remarks>Get archive</remarks>
        /// <operationid>share_post_v1_get_archive</operationid>
        /// <exception cref="PangeaException">Thrown if an error occurs during the operation.</exception>
        /// <exception cref="PangeaAPIException">Thrown if the API returns an error response.</exception>
        /// <example>
        /// <code>
        /// var response = await client.GetArchive(
        ///     new GetArchiveRequest
        ///     {
        ///         IDs = new List&lt;string&gt; { "pos_[...]" },
        ///         Format = ArchiveFormat.Tar,
        ///         RequestTransferMethod = TransferMethod.DestURL,
        ///     }
        /// );
        /// </code>
        /// </example>
        public async Task<Response<GetArchiveResult>> GetArchive(GetArchiveRequest request)
        {
            return await DoPost<GetArchiveResult>("/v1/get_archive", request);
        }

        /// <summary>Update a file.</summary>
        /// <remarks>Update a file</remarks>
        /// <operationid>share_post_v1_update</operationid>
        /// <exception cref="PangeaException">Thrown if an error occurs during the operation.</exception>
        /// <exception cref="PangeaAPIException">Thrown if the API returns an error response.</exception>
        /// <example>
        /// <code>
        /// var metadata = new Metadata() {
        ///     { "key", "value" }
        /// };
        /// var response = await client.Update(
        ///     new UpdateRequest
        ///     {
        ///         ID = "pos_[...]",
        ///         Metadata = metadata
        ///     }
        /// );
        /// </code>
        /// </example>
        public async Task<Response<UpdateResult>> Update(UpdateRequest request)
        {
            return await DoPost<UpdateResult>("/v1/update", request);
        }

        /// <summary>List or filter/search records.</summary>
        /// <remarks>List</remarks>
        /// <operationid>share_post_v1_list</operationid>
        /// <exception cref="PangeaException">Thrown if an error occurs during the operation.</exception>
        /// <exception cref="PangeaAPIException">Thrown if the API returns an error response.</exception>
        /// <example>
        /// <code>
        /// var response = await client.List(new ListRequest { /* ... */ });
        /// </code>
        /// </example>
        public async Task<Response<ListResult>> List(ListRequest request)
        {
            return await DoPost<ListResult>("/v1/list", request);
        }

        /// <summary>Upload a file.</summary>
        /// <remarks>Upload a file</remarks>
        /// <operationid>share_post_v1_put</operationid>
        /// <exception cref="PangeaException">Thrown if an error occurs during the operation.</exception>
        /// <exception cref="PangeaAPIException">Thrown if the API returns an error response.</exception>
        /// <example>
        /// <code>
        /// var response = await client.Put(
        ///     new PutRequest
        ///     {
        ///         Name = "foobar",
        ///         RequestTransferMethod = TransferMethod.Multipart
        ///     },
        ///     fileStream
        /// );
        /// </code>
        /// </example>
        public async Task<Response<PutResult>> Put(PutRequest request, FileStream file)
        {
            string name = "upload";
            if (request.TransferMethod == TransferMethod.PostURL)
            {
                var fileParams = Utils.GetUploadFileParams(file);
                request.CRC32c ??= fileParams.CRC32C;
                request.SHA256 ??= fileParams.SHA256;
                request.Size ??= fileParams.Size;
                name = "file";
            }
            else if (Utils.GetFileSize(file) == 0)
            {
                request.Size = 0;
            }

            var fileData = new FileData(file, name);
            return await DoPost<PutResult>("/v1/put", request, new PostConfig.Builder().WithFileData(fileData).Build());
        }

        /// <summary>Request an upload URL.</summary>
        /// <remarks>Request upload URL</remarks>
        /// <operationid>share_post_v1_put 2</operationid>
        /// <exception cref="PangeaException">Thrown if an error occurs during the operation.</exception>
        /// <exception cref="PangeaAPIException">Thrown if the API returns an error response.</exception>
        /// <example>
        /// <code>
        /// var response = await client.RequestUploadURL(
        ///     new PutRequest
        ///     {
        ///         Name = "foobar",
        ///         RequestTransferMethod = TransferMethod.PutURL,
        ///     }
        /// );
        /// </code>
        /// </example>
        public async Task<Response<AcceptedResult>> RequestUploadURL(PutRequest request)
        {
            TransferMethod? tm = request.TransferMethod;

            if (tm == TransferMethod.Multipart)
            {
                throw new PangeaException($"{tm} not supported. Use Put() instead", null);
            }

            // TODO: Check additional params
            return await RequestPresignedURL("/v1/put", request);
        }

        /// <summary>Create a share link.</summary>
        /// <remarks>Create share links</remarks>
        /// <operationid>share_post_v1_share_link_create</operationid>
        /// <exception cref="PangeaException">Thrown if an error occurs during the operation.</exception>
        /// <exception cref="PangeaAPIException">Thrown if the API returns an error response.</exception>
        /// <example>
        /// <code>
        /// var authenticators = new List&lt;Authenticator&gt;
        ///     {
        ///         new Authenticator(AuthenticatorType.Password, "somepassword")
        ///     };
        ///
        /// var linkList = new List&lt;ShareLinkCreateItem&gt;
        ///     {
        ///         new ShareLinkCreateItem {
        ///             Targets = new List&lt;string&gt; { folderID },
        ///             LinkType = LinkType.Editor,
        ///             MaxAccessCount = 3,
        ///             Authenticators = authenticators,
        ///         }
        ///     };
        ///
        /// var response = await client.ShareLinkCreate(
        ///     new ShareLinkCreateRequest
        ///     {
        ///         Links = linkList
        ///     }
        /// );
        /// </code>
        /// </example>
        public async Task<Response<ShareLinkCreateResult>> ShareLinkCreate(ShareLinkCreateRequest request)
        {
            return await DoPost<ShareLinkCreateResult>("/v1/share/link/create", request);
        }

        /// <summary>Get a share link.</summary>
        /// <remarks>Get share link</remarks>
        /// <operationid>share_post_v1_share_link_get</operationid>
        /// <exception cref="PangeaException">Thrown if an error occurs during the operation.</exception>
        /// <exception cref="PangeaAPIException">Thrown if the API returns an error response.</exception>
        /// <example>
        /// <code>
        /// var response = await client.ShareLinkGet(
        ///     new ShareLinkGetRequest
        ///     {
        ///         ID = "psl_[...]"
        ///     }
        /// );
        /// </code>
        /// </example>
        public async Task<Response<ShareLinkGetResult>> ShareLinkGet(ShareLinkGetRequest request)
        {
            return await DoPost<ShareLinkGetResult>("/v1/share/link/get", request);
        }

        /// <summary>Look up share links by filter options.</summary>
        /// <remarks>List share links</remarks>
        /// <operationid>share_post_v1_share_link_list</operationid>
        /// <exception cref="PangeaException">Thrown if an error occurs during the operation.</exception>
        /// <exception cref="PangeaAPIException">Thrown if the API returns an error response.</exception>
        /// <example>
        /// <code>
        /// var response = await client.ShareLinkList(new ShareLinkListRequest());
        /// </code>
        /// </example>
        public async Task<Response<ShareLinkListResult>> ShareLinkList(ShareLinkListRequest request)
        {
            return await DoPost<ShareLinkListResult>("/v1/share/link/list", request);
        }

        /// <summary>Delete share links.</summary>
        /// <remarks>Delete share links</remarks>
        /// <operationid>share_post_v1_share_link_delete</operationid>
        /// <exception cref="PangeaException">Thrown if an error occurs during the operation.</exception>
        /// <exception cref="PangeaAPIException">Thrown if the API returns an error response.</exception>
        /// <example>
        /// <code>
        /// var response = await client.ShareLinkDelete(
        ///     new ShareLinkDeleteRequest
        ///     {
        ///         IDs = new List&lt;string&gt; { "psl_[...]" },
        ///     }
        /// );
        /// </code>
        /// </example>
        public async Task<Response<ShareLinkDeleteResult>> ShareLinkDelete(ShareLinkDeleteRequest request)
        {
            return await DoPost<ShareLinkDeleteResult>("/v1/share/link/delete", request);
        }

        /// <summary>Send share links.</summary>
        /// <remarks>Send share links</remarks>
        /// <operationid>share_post_v1_share_link_send</operationid>
        /// <exception cref="PangeaException">Thrown if an error occurs during the operation.</exception>
        /// <exception cref="PangeaAPIException">Thrown if the API returns an error response.</exception>
        /// <example>
        /// <code>
        /// var response = await ShareLinkSend(
        ///     new ShareLinkSendRequest(
        ///         new List&lt;ShareLinkSendItem&gt; { new("psl_[...]", "alice@example.org") },
        ///         "bob@example.org"
        ///     )
        /// );
        /// </code>
        /// </example>
        public async Task<Response<ShareLinkSendResult>> ShareLinkSend(ShareLinkSendRequest request)
        {
            return await DoPost<ShareLinkSendResult>("/v1/share/link/send", request);
        }

        /// <summary><see cref="ShareClient"/> builder.</summary>
        public class Builder : ClientBuilder
        {
            /// <summary>Configuration ID.</summary>
            public string? ConfigID;

            /// <summary>Create a new <see cref="ShareClient"/> builder.</summary>
            /// <param name="config">Configuration.</param>
            public Builder(Config config) : base(config)
            {
            }

            /// <summary>Build a <see cref="ShareClient"/>.</summary>
            public ShareClient Build()
            {
                return new ShareClient(this);
            }
        }
    }
}
