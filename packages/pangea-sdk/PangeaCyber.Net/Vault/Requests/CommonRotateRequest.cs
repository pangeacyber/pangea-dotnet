using Newtonsoft.Json;

namespace PangeaCyber.Net.Vault
{
    ///
    public class CommonRotateRequest<TBuilder> : BaseRequest where TBuilder : CommonRotateRequest<TBuilder>.CommonBuilder
    {
        ///
        [JsonProperty("id")]
        public string ID { get; set; }

        ///
        [JsonProperty("rotation_state")]
        public ItemVersionState? RotationState { get; set; }

        ///
        [JsonProperty("rotation_frequency")]
        public string? RotationFrequency { get; set; }

        ///
        protected CommonRotateRequest(CommonBuilder builder)
        {
            ID = builder.ID;
            RotationState = builder.RotationState;
            RotationFrequency = builder.RotationFrequency;
        }

        ///
        public abstract class CommonBuilder
        {
            ///
            public string ID { get; protected set; }
            ///
            public ItemVersionState? RotationState { get; protected set; }
            ///
            public string? RotationFrequency { get; protected set; }

            ///
            protected CommonBuilder(string id)
            {
                ID = id;
            }

            ///
            public CommonRotateRequest<TBuilder> Build()
            {
                return new CommonRotateRequest<TBuilder>((TBuilder)this);
            }

            ///
            public TBuilder WithRotationState(ItemVersionState rotationState)
            {
                RotationState = rotationState;
                return (TBuilder)this;
            }

            ///
            public TBuilder WithRotationFrequency(string rotationFrequency)
            {
                RotationFrequency = rotationFrequency;
                return (TBuilder)this;
            }
        }
    }
}
