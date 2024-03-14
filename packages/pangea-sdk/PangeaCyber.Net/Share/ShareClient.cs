using PangeaCyber.Net.Exceptions;
using PangeaCyber.Net.Share.Models;
using PangeaCyber.Net.Share.Requests;
using PangeaCyber.Net.Share.Results;

namespace PangeaCyber.Net.Share
{
    /// <kind>class</kind>
    /// <summary>
    /// Share Client
    /// </summary>
    public class ShareClient : BaseClient<ShareClient.Builder>
    {
        ///
        public static string ServiceName { get; } = "share";

        /// Constructor
        protected ShareClient(Builder builder) : base(builder, ServiceName)
        {
            ConfigID = builder.ConfigID ?? ConfigID;
        }

        ///
        public async Task<Response<DeleteResult>> Delete(DeleteRequest request)
        {
            return await DoPost<DeleteResult>("/v1beta/delete", request);
        }

        ///
        public async Task<Response<FolderCreateResult>> FolderCreate(FolderCreateRequest request)
        {
            return await DoPost<FolderCreateResult>("/v1beta/folder/create", request);
        }

        ///
        public async Task<Response<GetResult>> Get(GetRequest request)
        {
            return await DoPost<GetResult>("/v1beta/get", request);
        }

        ///
        public async Task<Response<GetArchiveResult>> GetArchive(GetArchiveRequest request)
        {
            return await DoPost<GetArchiveResult>("/v1beta/get_archive", request);
        }

        ///
        public async Task<Response<UpdateResult>> Update(UpdateRequest request)
        {
            return await DoPost<UpdateResult>("/v1beta/update", request);
        }

        ///
        public async Task<Response<ListResult>> List(ListRequest request)
        {
            return await DoPost<ListResult>("/v1beta/list", request);
        }

        ///
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

        ///
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

        ///
        public async Task<Response<ShareLinkCreateResult>> ShareLinkCreate(ShareLinkCreateRequest request)
        {
            return await DoPost<ShareLinkCreateResult>("/v1beta/share/link/create", request);
        }

        ///
        public async Task<Response<ShareLinkGetResult>> ShareLinkGet(ShareLinkGetRequest request)
        {
            return await DoPost<ShareLinkGetResult>("/v1beta/share/link/get", request);
        }

        ///
        public async Task<Response<ShareLinkListResult>> ShareLinkList(ShareLinkListRequest request)
        {
            return await DoPost<ShareLinkListResult>("/v1beta/share/link/list", request);
        }

        ///
        public async Task<Response<ShareLinkDeleteResult>> ShareLinkDelete(ShareLinkDeleteRequest request)
        {
            return await DoPost<ShareLinkDeleteResult>("/v1beta/share/link/delete", request);
        }

        ///
        public async Task<Response<ShareLinkSendResult>> ShareLinkSend(ShareLinkSendRequest request)
        {
            return await DoPost<ShareLinkSendResult>("/v1beta/share/link/send", request);
        }

        ///
        public class Builder : ClientBuilder
        {
            ///
            public string? ConfigID = null;

            ///
            public Builder(Config config) : base(config)
            {
            }

            ///
            public ShareClient Build()
            {
                return new ShareClient(this);
            }

        }
    }
}
