using Newtonsoft.Json;

namespace PangeaCyber.Net.Intel
{
    ///
    public class FileHashReputationBulkRequest : IntelCommonRequest<FileHashReputationBulkRequest.Builder>
    {
        ///
        [JsonProperty("hashes")]
        public string[] Hashes { get; }

        ///
        [JsonProperty("hash_type")]
        public string HashType { get; }

        ///
        protected FileHashReputationBulkRequest(Builder builder) : base(builder)
        {
            Hashes = builder.Hashes;
            HashType = builder.HashType;
        }

        ///
        public class Builder : CommonBuilder
        {
            ///
            public string[] Hashes { get; private set; }
            ///
            public string HashType { get; private set; }

            ///
            public Builder(string[] hashes, string hashType)
            {
                this.Hashes = hashes;
                this.HashType = hashType;
            }

            ///
            public new FileHashReputationBulkRequest Build()
            {
                return new FileHashReputationBulkRequest(this);
            }
        }
    }
}
