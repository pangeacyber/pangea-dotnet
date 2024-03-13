using PangeaCyber.Net.Exceptions;

namespace PangeaCyber.Net
{
    ///
    public class FileUploader : BaseClient<FileUploader.Builder>
    {
        ///
        public static readonly string ServiceName = "FileUploader";

        ///
        public FileUploader(Builder builder) : base(builder, ServiceName)
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
            public FileUploader Build()
            {
                return new FileUploader(this);
            }
        }

        ///
        public async Task UploadFile(string url, TransferMethod transferMethod, FileData fileData)
        {
            if (transferMethod == TransferMethod.Multipart)
            {
                throw new PangeaException($"{transferMethod} not supported. Use service client instead", null);
            }

            if (transferMethod == TransferMethod.PostURL && fileData.Details == null)
            {
                throw new PangeaException($"Should set FileData in order to use {transferMethod} transfer method", null);
            }
            await UploadPresignedURL(url, transferMethod, fileData);
        }
    }
}
