using Newtonsoft.Json;

namespace PangeaCyber.Net
{
    ///
    public class FileData
    {
        ///
        public FileStream File { get; set; }

        ///
        public string Name { get; set; }

        ///
        public Dictionary<string, string>? Details { get; set; } = null;

        ///
        public FileData(FileStream file, string name)
        {
            File = file;
            Name = name;
            Details = null;
        }

        ///
        public FileData(FileStream file, string name, Dictionary<string, string> details)
        {
            File = file;
            Name = name;
            Details = details;
        }

    }
}
