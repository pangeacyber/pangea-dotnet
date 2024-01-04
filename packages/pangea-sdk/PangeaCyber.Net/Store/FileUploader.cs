using PangeaCyber.Net.Exceptions;

namespace PangeaCyber.Net.Store
{
    /// <kind>class</kind>
    /// <summary>
    /// FileScan Client
    /// </summary>
    public class StoreFileUploader : BaseClient<StoreFileUploader.Builder>
    {
        ///
        public static readonly string ServiceName = "StoreFileUploader";

        ///
        public StoreFileUploader(Builder builder) : base(builder, ServiceName)
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
            public StoreFileUploader Build()
            {
                return new StoreFileUploader(this);
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
