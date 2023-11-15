namespace PangeaCyber.Net.Audit
{
    ///
    public class LogConfig
    {
        ///
        public bool SignLocal { get; }

        ///
        public bool Verify { get; }

        ///
        public bool? Verbose { get; }

        ///
        private LogConfig(Builder builder)
        {
            SignLocal = builder.SignLocal ?? false;
            Verify = builder.Verify ?? false;
            Verbose = builder.Verbose ?? null;
        }

        ///
        public class Builder
        {
            ///
            public bool? SignLocal { get; set; }

            ///
            public bool? Verify { get; set; }

            ///
            public bool? Verbose { get; set; }

            ///
            public Builder()
            {
            }

            ///
            public Builder WithSignLocal(bool signLocal)
            {
                SignLocal = signLocal;
                return this;
            }

            ///
            public Builder WithVerify(bool verify)
            {
                Verify = verify;
                return this;
            }

            ///
            public Builder WithVerbose(bool verbose)
            {
                Verbose = verbose;
                return this;
            }

            ///
            public LogConfig Build()
            {
                return new LogConfig(this);
            }
        }

    }
}
