using Newtonsoft.Json;

namespace PangeaCyber.Net.Vault.Requests
{
    ///
    public class PangeaTokenRotateRequest : CommonRotateRequest<PangeaTokenRotateRequest.Builder>
    {
        ///
        [JsonProperty("rotation_grace_period")]
        public string? RotationGracePeriod { get; private set; }

        ///
        protected PangeaTokenRotateRequest(Builder builder) : base(builder)
        {
            RotationGracePeriod = builder.RotationGracePeriod;
        }

        ///
        public class Builder : CommonRotateRequest<PangeaTokenRotateRequest.Builder>.CommonBuilder
        {
            ///
            public string? RotationGracePeriod { get; private set; }

            ///
            public Builder(string id, string rotationGracePeriod) : base(id)
            {
                RotationGracePeriod = rotationGracePeriod;
            }

            ///
            public new PangeaTokenRotateRequest Build()
            {
                return new PangeaTokenRotateRequest(this);
            }
        }
    }
}
