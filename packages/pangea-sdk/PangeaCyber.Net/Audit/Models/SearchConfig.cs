namespace PangeaCyber.Net.Audit
{
    ///
    public class SearchConfig
    {
        ///
        public bool VerifyConsistency { get; }

        ///
        public bool VerifyEvents { get; }

        ///
        private SearchConfig(Builder builder)
        {
            VerifyConsistency = builder.VerifyConsistency;
            VerifyEvents = builder.VerifyEvents;
        }

        ///
        public class Builder
        {
            ///
            public bool VerifyConsistency { get; set; }

            ///
            public bool VerifyEvents { get; set; }

            ///
            public Builder()
            {
                VerifyConsistency = false;
                VerifyEvents = true;
            }

            ///
            public Builder WithVerifyConsistency(bool verifyConsistency)
            {
                VerifyConsistency = verifyConsistency;
                return this;
            }

            ///
            public Builder WithVerifyEvents(bool verifyEvents)
            {
                VerifyEvents = verifyEvents;
                return this;
            }

            ///
            public SearchConfig Build()
            {
                return new SearchConfig(this);
            }
        }

    }
}
