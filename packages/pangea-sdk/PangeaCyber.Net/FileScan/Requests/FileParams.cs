namespace PangeaCyber.Net.FileScan.Models
{
    ///
    public class FileParams
    {
        ///
        public int Size { get; private set; }

        ///
        public string SHA256 { get; private set; }

        ///
        public string CRC32C { get; private set; }

        ///
        public FileParams(int size, string sha256, string crc32c)
        {
            Size = size;
            SHA256 = sha256;
            CRC32C = crc32c;
        }
    }
}
