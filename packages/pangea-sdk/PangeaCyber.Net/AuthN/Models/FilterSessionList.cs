using PangeaCyber.Net.Filters;

namespace PangeaCyber.Net.AuthN.Models
{
    ///
    public class FilterSessionList : Filter
    {

        ///
        public FilterMatch<string> ID { get; private set; }

        ///
        public FilterMatch<string> Type { get; private set; }

        ///
        public FilterMatch<string> Identity { get; private set; }

        ///
        public FilterMatch<string> Email { get; private set; }

        ///
        public FilterRange<string> CreatedAt { get; private set; }

        ///
        public FilterRange<string> Expire { get; private set; }

        ///
        public FilterEqual<List<string>> Scopes { get; private set; }

        ///
        public FilterSessionList()
        {
            ID = new FilterMatch<string>("id", this);
            Type = new FilterMatch<string>("type", this);
            Identity = new FilterMatch<string>("identity", this);
            Email = new FilterMatch<string>("email", this);
            CreatedAt = new FilterRange<string>("created_at", this);
            Expire = new FilterRange<string>("expire", this);
            Scopes = new FilterEqual<List<string>>("scopes", this);
        }
    }
}
