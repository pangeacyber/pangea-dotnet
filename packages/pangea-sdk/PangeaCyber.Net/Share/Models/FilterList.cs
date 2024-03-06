using PangeaCyber.Net.Filters;

namespace PangeaCyber.Net.Share.Models
{
    ///
    public class FilterList : Filter
    {

        ///
        public FilterMatch<string> Folder { get; private set; }

        ///
        public FilterList()
        {
            Folder = new FilterMatch<string>("folder", this);
        }
    }
}
