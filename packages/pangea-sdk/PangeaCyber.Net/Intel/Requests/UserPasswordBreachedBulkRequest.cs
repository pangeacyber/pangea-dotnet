using Newtonsoft.Json;

namespace PangeaCyber.Net.Intel
{
    ///
    public class UserPasswordBreachedBulkRequest : IntelCommonRequest<UserPasswordBreachedBulkRequest.Builder>
    {
        ///
        [JsonProperty("hash_type")]
        public HashType HashType { get; set; }

        ///
        [JsonProperty("hash_prefixes")]
        public string[] HashPrefixes { get; set; }

        ///
        public UserPasswordBreachedBulkRequest(Builder builder) : base(builder)
        {
            HashType = builder.HashType;
            HashPrefixes = builder.HashPrefixes;
        }

        ///
        public class Builder : CommonBuilder
        {
            ///
            public HashType HashType { get; set; }
            ///

            public string[] HashPrefixes { get; set; }
            ///
            public Builder(HashType hashType, string[] hashPrefixes)
            {
                HashType = hashType;
                HashPrefixes = hashPrefixes;
            }

            ///
            public new UserPasswordBreachedBulkRequest Build()
            {
                return new UserPasswordBreachedBulkRequest(this);
            }
        }
    }
}
