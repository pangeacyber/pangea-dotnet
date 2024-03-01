using System.Security.Cryptography;
using PangeaCyber.Net.Exceptions;

namespace PangeaCyber.Net.Intel
{
    /// <summary>File Intel client.</summary>
    /// <remarks>File Intel</remarks>
    /// <example>
    /// <code>
    /// var config = new Config("pangea_token", "pangea_domain");
    /// var builder = new FileIntelClient.Builder(config);
    /// var client = builder.Build();
    /// </code>
    /// </example>
    public class FileIntelClient : BaseClient<FileIntelClient.Builder>
    {
        ///
        public static string ServiceName { get; } = "file-intel";

        /// <summary>Create a new <see cref="FileIntelClient"/> using the given builder.</summary>
        public FileIntelClient(Builder builder)
            : base(builder, ServiceName)
        {
        }

        /// <summary><see cref="FileIntelClient"/> builder.</summary>
        public class Builder : ClientBuilder
        {
            /// <summary>Create a new <see cref="FileIntelClient"/> builder.</summary>
            public Builder(Config config)
                : base(config)
            {
            }

            /// <summary>Build a <see cref="FileIntelClient"/>.</summary>
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
        /// <summary>Retrieve reputation scores for a list of file hashes, from a provider, including an optional detailed report.</summary>
        /// <remarks>Reputation V2</remarks>
        /// <operationid>file_intel_post_v2_reputation</operationid>
        /// <param name="request" type="PangeaCyber.Net.Intel.FileHashReputationBulkRequest">FileHashReputationBulkRequest with the hash file list to be looked up</param>
        /// <returns>Response&lt;FileReputationBulkResult&gt;</returns>
        /// <example>
        /// <code>
        /// string[] hashes = new string[1] {"142b638c6a60b60c7f9928da4fb85a5a8e1422a9ffdc9ee49e17e56ccca9cf6e"};
        /// var request = new FileHashReputationBulkRequest.Builder(hashes, "sha256")
        ///     .WithProvider("reversinglabs")
        ///     .WithVerbose(false)
        ///     .WithRaw(false)
        ///     .Build();
        /// var response = await client.ReputationBulk(request);
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
