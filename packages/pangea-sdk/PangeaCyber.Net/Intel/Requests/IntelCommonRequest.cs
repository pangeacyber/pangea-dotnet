using Newtonsoft.Json;

namespace PangeaCyber.Net.Intel
{
    ///
    public class IntelCommonRequest<TBuilder> : BaseRequest where TBuilder : IntelCommonRequest<TBuilder>.CommonBuilder
    {
        ///
        [JsonProperty("provider")]
        public string? Provider { get; set; }

        ///
        [JsonProperty("verbose")]
        public bool? Verbose { get; set; }

        ///
        [JsonProperty("raw")]
        public bool? Raw { get; set; }

        ///
        protected IntelCommonRequest(TBuilder builder)
        {
            Provider = builder.Provider;
            Verbose = builder.Verbose;
            Raw = builder.Raw;
        }

        ///
        public class CommonBuilder
        {

            ///
            public string? Provider { get; private set; }

            ///
            public bool? Verbose { get; private set; }

            ///
            public bool? Raw { get; private set; }

            private TBuilder Self()
            {
                return (TBuilder)this;
            }

            ///
            public CommonBuilder() { }

            ///
            public IntelCommonRequest<TBuilder> Build()
            {
                return new IntelCommonRequest<TBuilder>((TBuilder)this);
            }

            ///
            public TBuilder WithProvider(string provider)
            {
                Provider = provider;
                return Self();
            }

            ///
            public TBuilder WithVerbose(bool? verbose)
            {
                Verbose = verbose;
                return Self();
            }

            ///
            public TBuilder WithRaw(bool? raw)
            {
                Raw = raw;
                return Self();
            }
        }
    }
}
