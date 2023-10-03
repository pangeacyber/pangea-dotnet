using System.Security.Cryptography;
using PangeaCyber.Net.Exceptions;

namespace PangeaCyber.Net.Intel
{
    /// <kind>class</kind>
    /// <summary>
    /// FileIntel Client
    /// </summary>
    public class FileIntelClient : BaseClient<FileIntelClient.Builder>
    {
        ///
        public static string ServiceName { get; } = "file-intel";

        /// Constructor
        public FileIntelClient(Builder builder)
            : base(builder, ServiceName)
        {
        }

        ///
        public class Builder : ClientBuilder
        {
            ///
            public Builder(Config config)
                : base(config)
            {
            }

            ///
            public FileIntelClient Build()
            {
                return new FileIntelClient(this);
            }
        }

        /// <kind>method</kind>
        /// <summary>Retrieve a reputation score for a file hash from a provider, including an optional detailed report.</summary>
        /// <remarks>Reputation</remarks>
        /// <operationid>file_intel_post_v1_reputation</operationid>
        /// <param name="request" type="PangeaCyber.Net.Intel.FileHashReputationRequest">FileHashReputationRequest with the hash of the file to be looked up</param>
        /// <returns>Response&lt;FileReputationResult&gt;</returns>
        /// <example>
        /// <code>
        /// var request = new FileHashReputationRequest.Builder(
        ///     "142b638c6a60b60c7f9928da4fb85a5a8e1422a9ffdc9ee49e17e56ccca9cf6e",
        ///     "sha256")
        ///     .WithProvider("reversinglabs")
        ///     .WithVerbose(false)
        ///     .WithRaw(false)
        ///     .Build();
        /// var response = await client.Reputation(request);
        /// </code>
        /// </example>
        public Task<Response<FileReputationResult>> Reputation(FileHashReputationRequest request)
        {
            return DoPost<FileReputationResult>("/v1/reputation", request);
        }

        /// <kind>method</kind>
        /// <summary>Retrieve a reputation score for a file hash list from a provider, including an optional detailed report.</summary>
        /// <remarks>Reputation</remarks>
        /// <operationid>FIXME:</operationid>
        /// <param name="request" type="PangeaCyber.Net.Intel.FileHashReputationBulkRequest">FileHashReputationBulkRequest with the hash file list to be looked up</param>
        /// <returns>Response&lt;FileReputationBulkResult&gt;</returns>
        /// <example>
        /// <code>
        /// FIXME:
        /// </code>
        /// </example>
        public Task<Response<FileReputationBulkResult>> ReputationBulk(FileHashReputationBulkRequest request)
        {
            return DoPost<FileReputationBulkResult>("/v2/reputation", request);
        }

        ///
        public static string CalculateSHA256fromFile(string filepath)
        {
            try
            {
                using (var stream = File.OpenRead(filepath))
                {
                    using (var sha256 = SHA256.Create())
                    {
                        var hashBytes = sha256.ComputeHash(stream);
                        return BitConverter.ToString(hashBytes).Replace("-", string.Empty);
                    }
                }
            }
            catch (Exception e)
            {
                throw new PangeaException(string.Format("Could not process file: {0}. error: {1}", filepath, e.ToString()), e);
            }
        }
    }
}
