using Newtonsoft.Json;

namespace PangeaCyber.Net.Intel
{
    ///
    public class FileHashReputationRequest : IntelCommonRequest<FileHashReputationRequest.Builder>
    {
        ///
        [JsonProperty("hash")]
        public string Hash { get; }

        ///
        [JsonProperty("hash_type")]
        public string HashType { get; }

        ///
        protected FileHashReputationRequest(Builder builder) : base(builder)
        {
            Hash = builder.Hash;
            HashType = builder.HashType;
        }

        ///
        public class Builder : CommonBuilder
        {
            ///
            public string Hash { get; private set; }
            ///
            public string HashType { get; private set; }

            ///
            public Builder(string hash, string hashType)
            {
                this.Hash = hash;
                this.HashType = hashType;
            }

            ///
            public new FileHashReputationRequest Build()
            {
                return new FileHashReputationRequest(this);
            }
        }
    }
}
