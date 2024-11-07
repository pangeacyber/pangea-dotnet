using PangeaCyber.Net.Exceptions;

namespace PangeaCyber.Net.FileScan
{
    /// <kind>class</kind>
    /// <summary>
    /// FileScan Client
    /// </summary>
    [Obsolete("Use PangeaCyber.Net.FileUploader instead.")]
    public class FileUploader : BaseClient<FileUploader.Builder>
    {
        ///
        public static readonly string ServiceName = "FileScanFileUploader";

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
                throw new PangeaException($"{transferMethod} not supported. Use Scan() instead", null);
            }

            if (transferMethod == TransferMethod.PostURL && fileData.Details == null)
            {
                throw new PangeaException($"Should set FileParams in order to use {transferMethod} transfer method", null);
            }
            await UploadPresignedURL(url, transferMethod, fileData);
        }
    }
}
