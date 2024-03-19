using PangeaCyber.Net.Exceptions;

namespace PangeaCyber.Net.Sanitize
{

    ///
    public class SanitizeClient : BaseClient<SanitizeClient.Builder>
    {
        ///
        public static readonly string ServiceName = "sanitize";

        /// <summary>Create a new <see cref="SanitizeClient"/> using the given builder.</summary>
        public SanitizeClient(Builder builder) : base(builder, ServiceName)
        {
        }

        /// <summary><see cref="SanitizeClient"/> builder.</summary>
        public class Builder : ClientBuilder
        {
            /// <summary>Create a new <see cref="SanitizeClient"/> builder.</summary>
            public Builder(Config config) : base(config)
            {
            }

            /// <summary>Build a <see cref="SanitizeClient"/>.</summary>
            public SanitizeClient Build()
            {
                return new SanitizeClient(this);
            }
        }

        ///
        public async Task<Response<SanitizeResult>> Sanitize(SanitizeRequest request, FileStream file)
        {
            string name = "upload";
            if (request.TransferMethod == TransferMethod.PostURL)
            {
                var fileParams = Utils.GetUploadFileParams(file);
                request.SHA256 = fileParams.SHA256;
                request.CRC32c = fileParams.CRC32C;
                request.Size = fileParams.Size;
                name = "file";
            }

            var fileData = new FileData(file, name);
            return await DoPost<SanitizeResult>("/v1beta/sanitize", request, new PostConfig.Builder().WithFileData(fileData).Build());
        }

        ///
        public async Task<Response<AcceptedResult>> RequestUploadURL(SanitizeRequest request)
        {
            TransferMethod? tm = request.TransferMethod;

            if (tm == TransferMethod.Multipart)
            {
                throw new PangeaException($"{tm} not supported. Use Sanitize() instead", null);
            }

            if (tm == TransferMethod.PostURL && (request.SHA256 == null || request.CRC32c == null || request.Size == null))
            {
                throw new PangeaException($"Should set SHA256, CRC32c and Size in order to use {tm} transfer method", null);
            }

            return await RequestPresignedURL("/v1beta/sanitize", request);
        }
    }
}
