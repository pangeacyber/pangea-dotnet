using PangeaCyber.Net.Exceptions;

namespace PangeaCyber.Net
{
    ///
    public class AttachedFile
    {

        ///
        public AttachedFile(string filename, string contentType, byte[] fileContent)
        {
            Filename = filename;
            ContentType = contentType;
            FileContent = fileContent;
        }

        ///
        public string Filename { get; protected set; }

        ///
        public string ContentType { get; protected set; } = default!;

        ///
        public byte[] FileContent { get; protected set; }

        ///
        public void Save(string folder, string name)
        {
            folder ??= "./";
            name ??= (Filename ?? "defaultFilename");

            string path = Path.Combine(folder, name);

            if (!Directory.Exists(path))
            {
                try
                {
                    Directory.CreateDirectory(path);
                }
                catch (IOException e)
                {
                    throw new PangeaException("Failed to create file path", e);
                }
            }

            this.Save(Path.Combine(folder, name));
        }

        ///
        public void Save(string filePath)
        {
            try
            {
                File.WriteAllBytes(filePath, this.FileContent);
            }
            catch (IOException e)
            {
                throw new PangeaException("Failed to write file", e);
            }
        }
    }
}
