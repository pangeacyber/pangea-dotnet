using PangeaCyber.Net.Filters;

namespace PangeaCyber.Net.Store.Models
{
    ///
    public class FilterShareLinkList : Filter
    {

        ///
        public FilterMatch<string> ID { get; private set; }

        ///
        public FilterMatch<string> StoragePoolID { get; private set; }

        ///
        public FilterMatch<string> Target { get; private set; }

        ///
        public FilterMatch<string> LinkType { get; private set; }

        ///
        public FilterMatch<string> Link { get; private set; }

        ///
        public FilterRange<string> CreatedAt { get; private set; }

        ///
        public FilterRange<string> ExpireAt { get; private set; }

        ///
        public FilterRange<string> LastAccessedAt { get; private set; }

        ///
        public FilterRange<int> AccessCount { get; private set; }

        ///
        public FilterRange<int> MaxAccessCount { get; private set; }

        ///
        public FilterShareLinkList()
        {
            ID = new FilterMatch<string>("id", this);
            StoragePoolID = new FilterMatch<string>("storage_pool_id", this);
            Target = new FilterMatch<string>("target", this);
            LinkType = new FilterMatch<string>("link_type", this);
            Link = new FilterMatch<string>("link", this);
            CreatedAt = new FilterRange<string>("created_at", this);
            ExpireAt = new FilterRange<string>("expire_at", this);
            LastAccessedAt = new FilterRange<string>("last_accessed_at", this);
            AccessCount = new FilterRange<int>("access_count", this);
            MaxAccessCount = new FilterRange<int>("max_access_count", this);
        }
    }
}
