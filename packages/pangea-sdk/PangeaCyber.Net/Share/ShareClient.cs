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

        /// <summary>
        /// Delete object by ID or path. If both are supplied, the path must match that of the object represented by
        /// the ID.
        /// How to install a <see href="https://pangea.cloud/docs/sdk/csharp/#beta-releases">Beta release</see>.
        /// </summary>
        /// <remarks>Delete (Beta)</remarks>
        /// <operationid>share_post_v1beta_delete</operationid>
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
            return await DoPost<DeleteResult>("/v1beta/delete", request);
        }

        /// <summary>
        /// Create a folder, either by name or path and parent_id.
        /// How to install a <see href="https://pangea.cloud/docs/sdk/csharp/#beta-releases">Beta release</see>.
        /// </summary>
        /// <remarks>Create a folder (Beta)</remarks>
        /// <operationid>share_post_v1beta_folder_create</operationid>
        /// <exception cref="PangeaException">Thrown if an error occurs during the operation.</exception>
        /// <exception cref="PangeaAPIException">Thrown if the API returns an error response.</exception>
        /// <example>
        /// <code>
        /// var response = await client.FolderCreate(
        ///     new FolderCreateRequest
        ///     {
        ///         Path = "/path/to/new/folder"
        ///     }
        /// );
        /// </code>
        /// </example>
        public async Task<Response<FolderCreateResult>> FolderCreate(FolderCreateRequest request)
        {
            return await DoPost<FolderCreateResult>("/v1beta/folder/create", request);
        }

        /// <summary>
        /// Get object. If both ID and path are supplied, the call will fail if the target object doesn't match both
        /// properties.
        /// How to install a <see href="https://pangea.cloud/docs/sdk/csharp/#beta-releases">Beta release</see>.
        /// </summary>
        /// <remarks>Get an object (Beta)</remarks>
        /// <operationid>share_post_v1beta_folder_create</operationid>
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
            return await DoPost<GetResult>("/v1beta/get", request);
        }

        /// <summary>
        /// Get an archive file of multiple objects.
        /// How to install a <see href="https://pangea.cloud/docs/sdk/csharp/#beta-releases">Beta release</see>.
        /// </summary>
        /// <remarks>Get archive (Beta)</remarks>
        /// <operationid>share_post_v1beta_get_archive</operationid>
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
            return await DoPost<GetArchiveResult>("/v1beta/get_archive", request);
        }

        /// <summary>
        /// Update a file.
        /// How to install a <see href="https://pangea.cloud/docs/sdk/csharp/#beta-releases">Beta release</see>.
        /// </summary>
        /// <remarks>Update a file (Beta)</remarks>
        /// <operationid>share_post_v1beta_update</operationid>
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
            return await DoPost<UpdateResult>("/v1beta/update", request);
        }

        /// <summary>
        /// List or filter/search records.
        /// How to install a <see href="https://pangea.cloud/docs/sdk/csharp/#beta-releases">Beta release</see>.
        /// </summary>
        /// <remarks>List (Beta)</remarks>
        /// <operationid>share_post_v1beta_list</operationid>
        /// <exception cref="PangeaException">Thrown if an error occurs during the operation.</exception>
        /// <exception cref="PangeaAPIException">Thrown if the API returns an error response.</exception>
        /// <example>
        /// <code>
        /// var response = await client.List(new ListRequest { /* ... */ });
        /// </code>
        /// </example>
        public async Task<Response<ListResult>> List(ListRequest request)
        {
            return await DoPost<ListResult>("/v1beta/list", request);
        }

        /// <summary>
        /// Upload a file.
        /// How to install a <see href="https://pangea.cloud/docs/sdk/csharp/#beta-releases">Beta release</see>.
        /// </summary>
        /// <remarks>Upload a file (Beta)</remarks>
        /// <operationid>share_post_v1beta_put</operationid>
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
            return await DoPost<PutResult>("/v1beta/put", request, new PostConfig.Builder().WithFileData(fileData).Build());
        }

        /// <summary>
        /// Request an upload URL.
        /// How to install a <see href="https://pangea.cloud/docs/sdk/csharp/#beta-releases">Beta release</see>.
        /// </summary>
        /// <remarks>Request upload URL (Beta)</remarks>
        /// <operationid>share_post_v1beta_put 2</operationid>
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
            return await RequestPresignedURL("/v1beta/put", request);
        }

        /// <summary>
        /// Create a share link.
        /// How to install a <see href="https://pangea.cloud/docs/sdk/csharp/#beta-releases">Beta release</see>.
        /// </summary>
        /// <remarks>Create share links (Beta)</remarks>
        /// <operationid>share_post_v1beta_share_link_create</operationid>
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
            return await DoPost<ShareLinkCreateResult>("/v1beta/share/link/create", request);
        }

        /// <summary>
        /// Get a share link.
        /// How to install a <see href="https://pangea.cloud/docs/sdk/csharp/#beta-releases">Beta release</see>.
        /// </summary>
        /// <remarks>Get share link (Beta)</remarks>
        /// <operationid>share_post_v1beta_share_link_get</operationid>
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
            return await DoPost<ShareLinkGetResult>("/v1beta/share/link/get", request);
        }

        /// <summary>
        /// Look up share links by filter options.
        /// How to install a <see href="https://pangea.cloud/docs/sdk/csharp/#beta-releases">Beta release</see>.
        /// </summary>
        /// <remarks>List share links (Beta)</remarks>
        /// <operationid>share_post_v1beta_share_link_list</operationid>
        /// <exception cref="PangeaException">Thrown if an error occurs during the operation.</exception>
        /// <exception cref="PangeaAPIException">Thrown if the API returns an error response.</exception>
        /// <example>
        /// <code>
        /// var response = await client.ShareLinkList(new ShareLinkListRequest());
        /// </code>
        /// </example>
        public async Task<Response<ShareLinkListResult>> ShareLinkList(ShareLinkListRequest request)
        {
            return await DoPost<ShareLinkListResult>("/v1beta/share/link/list", request);
        }

        /// <summary>
        /// Delete share links.
        /// How to install a <see href="https://pangea.cloud/docs/sdk/csharp/#beta-releases">Beta release</see>.
        /// </summary>
        /// <remarks>Delete share links (Beta)</remarks>
        /// <operationid>share_post_v1beta_share_link_delete</operationid>
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
            return await DoPost<ShareLinkDeleteResult>("/v1beta/share/link/delete", request);
        }

        /// <summary>
        /// Send share links.
        /// How to install a <see href="https://pangea.cloud/docs/sdk/csharp/#beta-releases">Beta release</see>.
        /// </summary>
        /// <remarks>Send share links (Beta)</remarks>
        /// <operationid>share_post_v1beta_share_link_send</operationid>
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
            return await DoPost<ShareLinkSendResult>("/v1beta/share/link/send", request);
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
