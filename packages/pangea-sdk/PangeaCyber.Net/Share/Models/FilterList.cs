using PangeaCyber.Net.Filters;

namespace PangeaCyber.Net.Share.Models
{
    ///
    public class FilterList : Filter
    {
        ///
        public FilterEqual<string> Folder { get; }

        ///
        public FilterRange<string> CreatedAt { get; }

        ///
        public FilterMatch<string> ID { get; }

        ///
        public FilterMatch<string> Name { get; }

        ///
        public FilterMatch<string> ParentID { get; }

        ///
        public FilterRange<int> Size { get; }

        ///
        public FilterEqual<Tags> Tags { get; }

        ///
        public FilterMatch<string> Type { get; }

        ///
        public FilterRange<string> UpdatedAt { get; }

        ///
        public FilterList()
        {
            Folder = new FilterEqual<string>("folder", this);
            CreatedAt = new FilterRange<string>("created_at", this);
            ID = new FilterMatch<string>("id", this);
            Name = new FilterMatch<string>("name", this);
            ParentID = new FilterMatch<string>("parent_id", this);
            Size = new FilterRange<int>("size", this);
            Tags = new FilterEqual<Tags>("tags", this);
            Type = new FilterMatch<string>("type", this);
            UpdatedAt = new FilterRange<string>("updated_at", this);
        }
    }
}
