using System.Security.Cryptography;
using PangeaCyber.Net.Exceptions;

namespace PangeaCyber.Net.Intel
{
    ///
    public class FileIntelClient : BaseClient
    {
        private const string ServiceName = "file-intel";
        private static readonly bool SupportMultiConfig = false;

        ///
        public FileIntelClient(Builder builder)
            : base(builder, ServiceName, SupportMultiConfig)
        {
        }

        ///
        public class Builder : BaseClient.ClientBuilder
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

        ///
        public Task<Response<FileReputationResult>> Reputation(FileHashReputationRequest request)
        {
            return DoPost<FileReputationResult>("/v1/reputation", request);
        }

        ///
        public static string CalculateSHA256fromFile(string filepath)
        {
            try{
                using (var stream = File.OpenRead(filepath))
                {
                    using (var sha256 = SHA256.Create())
                    {
                        var hashBytes = sha256.ComputeHash(stream);
                        return BitConverter.ToString(hashBytes).Replace("-", string.Empty);
                    }
                }
            } catch(Exception e){
                throw new PangeaException(string.Format("Could not process file: {0}. error: {1}", filepath, e.ToString()), e);
            }
        }
    }
}
