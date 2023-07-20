namespace PangeaCyber.Net.AuthN
{
    ///
    public class SessionListRequest : CommonSessionListRequest<SessionListRequest.Builder>
    {
        private SessionListRequest(Builder builder) : base(builder)
        {
        }

        ///
        public class Builder : CommonSessionListRequest<SessionListRequest.Builder>.CommonBuilder
        {
            ///
            public Builder() {}

            ///
            public new SessionListRequest Build()
            {
                return new SessionListRequest(this);
            }
        }
    }
}
