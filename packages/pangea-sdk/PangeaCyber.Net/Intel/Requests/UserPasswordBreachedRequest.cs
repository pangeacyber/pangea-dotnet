using Newtonsoft.Json;

namespace PangeaCyber.Net.Intel
{
    ///
    public class UserPasswordBreachedRequest : IntelCommonRequest<UserPasswordBreachedRequest.Builder>
    {
        ///
        [JsonProperty("hash_type")]
        public HashType HashType { get; set; }

        ///
        [JsonProperty("hash_prefix")]
        public string HashPrefix { get; set; }

        ///
        public UserPasswordBreachedRequest(Builder builder) : base(builder)
        {
            HashType = builder.HashType;
            HashPrefix = builder.HashPrefix;
        }

        ///
        public class Builder : CommonBuilder
        {
            ///
            public HashType HashType { get; set; }
            ///
            public string HashPrefix { get; set; }

            ///
            public Builder(HashType hashType, string hashPrefix)
            {
                HashType = hashType;
                HashPrefix = hashPrefix;
            }

            ///
            public new UserPasswordBreachedRequest Build()
            {
                return new UserPasswordBreachedRequest(this);
            }
        }
    }
}
