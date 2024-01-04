using PangeaCyber.Net.Filters;

namespace PangeaCyber.Net.Store.Models
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
