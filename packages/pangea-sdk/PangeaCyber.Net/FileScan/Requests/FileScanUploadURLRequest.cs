using PangeaCyber.Net;
using PangeaCyber.Net.FileScan.Models;

namespace Cloud.PangeaCyber.Pangea.FileScan.Requests
{
    ///
    public class FileScanUploadURLRequest
    {
        ///
        public string? Provider { get; private set; }
        ///
        public bool? Verbose { get; private set; }
        ///
        public bool? Raw { get; private set; }
        ///
        public TransferMethod TransferMethod { get; private set; }
        ///
        public FileParams? FileParams { get; private set; }

        ///
        protected FileScanUploadURLRequest(Builder builder)
        {
            Provider = builder.Provider;
            Verbose = builder.Verbose;
            Raw = builder.Raw;
            TransferMethod = builder.TransferMethod;
            FileParams = builder.FileParams;
        }

        ///
        public class Builder
        {
            ///
            public string? Provider { get; private set; }
            ///
            public bool? Verbose { get; private set; }
            ///
            public bool? Raw { get; private set; }
            ///
            public TransferMethod TransferMethod { get; private set; } = TransferMethod.PostURL;
            ///
            public FileParams? FileParams { get; private set; }

            ///
            public FileScanUploadURLRequest Build()
            {
                return new FileScanUploadURLRequest(this);
            }

            ///
            public Builder WithProvider(string provider)
            {
                Provider = provider;
                return this;
            }

            ///
            public Builder WithVerbose(bool? verbose)
            {
                Verbose = verbose;
                return this;
            }

            ///
            public Builder WithRaw(bool? raw)
            {
                Raw = raw;
                return this;
            }

            ///
            public Builder WithTransferMethod(TransferMethod transferMethod)
            {
                TransferMethod = transferMethod;
                return this;
            }

            ///
            public Builder WithFileParams(FileParams fileParams)
            {
                FileParams = fileParams;
                return this;
            }
        }
    }

}
