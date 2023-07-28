namespace PangeaCyber.Net.Intel
{
    ///
    public class FileScanRequest : IntelCommonRequest<FileScanRequest.Builder>
    {

        ///
        protected FileScanRequest(Builder builder)
            : base(builder)
        {
        }

        ///
        public class Builder : IntelCommonRequest<FileScanRequest.Builder>.CommonBuilder
        {
            ///
            public Builder() { }

            ///
            public new FileScanRequest Build()
            {
                return new FileScanRequest(this);
            }
        }
    }
}
