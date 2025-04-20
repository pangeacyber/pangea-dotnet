using PangeaCyber.Net.Exceptions;

namespace PangeaCyber.Net.Sanitize
{
    /// <summary>Sanitize client.</summary>
    /// <remarks>Sanitize</remarks>
    /// <example>
    /// <code>
    /// var config = new Config("pangea_token");
    /// var builder = new SanitizeClient.Builder(config);
    /// var client = builder.Build();
    /// </code>
    /// </example>
    public class SanitizeClient : BaseClient<SanitizeClient.Builder>
    {
        /// <summary>Service name.</summary>
        public static readonly string ServiceName = "sanitize";

        /// <summary>Create a new <see cref="SanitizeClient"/> using the given builder.</summary>
        /// <param name="builder">Sanitize client builder.</param>
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

        /// <summary>
        /// Apply file sanitization actions according to specified rules.
        /// </summary>
        /// <remarks>Sanitize</remarks>
        /// <operationid>sanitize_post_v1_sanitize</operationid>
        /// <param name="request">Request parameters.</param>
        /// <param name="file">File to sanitize.</param>
        /// <returns>The sanitized file and information on the sanitization that was performed.</returns>
        /// <exception cref="PangeaException">Thrown if an error occurs during the operation.</exception>
        /// <exception cref="PangeaAPIException">Thrown if the API returns an error response.</exception>
        /// <example>
        /// <code>
        /// var file = new FileStream("/path/to/file.txt", FileMode.Open, FileAccess.Read);
        /// var response = await client.Sanitize(
        ///     new SanitizeRequest()
        ///     {
        ///         RequestTransferMethod = TransferMethod.PostURL,
        ///         UploadedFileName = "uploaded_file",
        ///     },
        ///     file
        /// );
        /// </code>
        /// </example>
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
            return await DoPost<SanitizeResult>("/v1/sanitize", request, new PostConfig.Builder().WithFileData(fileData).Build());
        }

        /// <summary>
        /// Apply file sanitization actions according to specified rules via a presigned URL.
        /// </summary>
        /// <remarks>Sanitize via presigned URL</remarks>
        /// <operationid>sanitize_post_v1_sanitize 2</operationid>
        /// <param name="request">Request parameters.</param>
        /// <returns>A presigned URL.</returns>
        /// <exception cref="PangeaException">Thrown if an error occurs during the operation.</exception>
        /// <exception cref="PangeaAPIException">Thrown if the API returns an error response.</exception>
        /// <example>
        /// <code>
        /// var presignedUrl = await client.RequestUploadURL(
        ///     new SanitizeRequest()
        ///     {
        ///         RequestTransferMethod = TransferMethod.PutURL,
        ///         UploadedFileName = "uploaded_file",
        ///     }
        /// );
        ///
        /// // Upload file to `presignedUrl.Result.PutURL`.
        ///
        /// // Poll for Sanitize's result.
        /// var response = await client.PollResult&lt;SanitizeResult&gt;(presignedUrl.RequestId);
        /// </code>
        /// </example>
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

            return await RequestPresignedURL("/v1/sanitize", request);
        }
    }
}
