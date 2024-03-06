using PangeaCyber.Net.Exceptions;

namespace PangeaCyber.Net.Share
{
    ///
    public class ShareFileUploader : BaseClient<ShareFileUploader.Builder>
    {
        ///
        public static readonly string ServiceName = "ShareFileUploader";

        ///
        public ShareFileUploader(Builder builder) : base(builder, ServiceName)
        {
        }

        ///
        public class Builder : ClientBuilder
        {
            ///
            public Builder() : base(new Config("", ""))
            {
            }

            ///
            public ShareFileUploader Build()
            {
                return new ShareFileUploader(this);
            }
        }

        ///
        public async Task UploadFile(string url, TransferMethod transferMethod, FileData fileData)
        {
            if (transferMethod == TransferMethod.Multipart)
            {
                throw new PangeaException($"{transferMethod} not supported. Use Put() instead", null);
            }

            if (transferMethod == TransferMethod.PostURL && fileData.Details == null)
            {
                throw new PangeaException($"Should set FileParams in order to use {transferMethod} transfer method", null);
            }
            await UploadPresignedURL(url, transferMethod, fileData);
        }
    }
}
