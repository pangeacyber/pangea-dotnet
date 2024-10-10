using PangeaCyber.Net.Filters;

namespace PangeaCyber.Net.Share.Models
{
    ///
    public class FilterShareLinkList : Filter
    {

        ///
        public FilterMatch<string> ID { get; private set; }

        ///
        public FilterMatch<string> Target { get; private set; }

        ///
        public FilterMatch<string> LinkType { get; private set; }

        ///
        public FilterMatch<string> Link { get; private set; }

        ///
        public FilterRange<string> CreatedAt { get; private set; }

        ///
        public FilterRange<string> ExpiresAt { get; private set; }

        ///
        public FilterRange<string> LastAccessedAt { get; private set; }

        ///
        public FilterRange<int> AccessCount { get; private set; }

        ///
        public FilterRange<int> MaxAccessCount { get; private set; }

        ///
        public FilterMatch<string> Title { get; private set; }

        ///
        public FilterMatch<string> Message { get; private set; }

        ///
        public FilterMatch<string> NotifyEmail { get; private set; }

        ///
        public FilterEqual<Tags> Tags { get; private set; }

        ///
        public FilterShareLinkList()
        {
            ID = new FilterMatch<string>("id", this);
            Target = new FilterMatch<string>("target", this);
            LinkType = new FilterMatch<string>("link_type", this);
            Link = new FilterMatch<string>("link", this);
            CreatedAt = new FilterRange<string>("created_at", this);
            ExpiresAt = new FilterRange<string>("expires_at", this);
            LastAccessedAt = new FilterRange<string>("last_accessed_at", this);
            AccessCount = new FilterRange<int>("access_count", this);
            MaxAccessCount = new FilterRange<int>("max_access_count", this);
            Title = new FilterMatch<string>("title", this);
            Message = new FilterMatch<string>("message", this);
            NotifyEmail = new FilterMatch<string>("notify_email", this);
            Tags = new FilterMatch<Tags>("tags", this);
        }
    }
}
