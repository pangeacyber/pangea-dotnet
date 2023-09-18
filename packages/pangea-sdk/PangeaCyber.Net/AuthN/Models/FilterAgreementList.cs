using PangeaCyber.Net.Filters;

namespace PangeaCyber.Net.AuthN.Models
{
    ///
    public class FilterAgreementList : Filter
    {
        ///
        public FilterEqual<bool> Active { get; private set; }

        ///
        public FilterRange<string> CreatedAt { get; private set; }

        ///
        public FilterRange<string> PublishedAt { get; private set; }

        ///
        public FilterMatch<string> Type { get; private set; }

        ///
        public FilterMatch<string> ID { get; private set; }

        ///
        public FilterMatch<string> Name { get; private set; }

        ///
        public FilterMatch<string> Text { get; private set; }

        ///
        public FilterAgreementList()
        {
            Active = new FilterEqual<bool>("active", this);
            CreatedAt = new FilterRange<string>("created_at", this);
            PublishedAt = new FilterRange<string>("published_at", this);
            Type = new FilterMatch<string>("type", this);
            ID = new FilterMatch<string>("id", this);
            Name = new FilterMatch<string>("name", this);
            Text = new FilterMatch<string>("text", this);
        }
    }

}
