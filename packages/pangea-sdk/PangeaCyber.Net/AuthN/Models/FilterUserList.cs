using PangeaCyber.Net.Filters;

namespace PangeaCyber.Net.AuthN.Models
{
    ///
    public class FilterUserList : Filter
    {
        ///
        public FilterEqual<bool> Disabled { get; private set; }

        ///
        public FilterEqual<bool> RequireMfa { get; private set; }

        ///
        public FilterEqual<bool> Verified { get; private set; }

        ///
        public FilterEqual<List<string>> Scopes { get; private set; }

        ///
        public FilterMatch<string> EulaId { get; private set; }

        ///
        public FilterMatch<string> Email { get; private set; }

        ///
        public FilterMatch<string> ID { get; private set; }

        ///
        public FilterMatch<string> LastLoginIp { get; private set; }

        ///
        public FilterMatch<string> LastLoginCity { get; private set; }

        ///
        public FilterMatch<string> LastLoginCountry { get; private set; }

        ///
        public FilterRange<string> CreatedAt { get; private set; }

        ///
        public FilterRange<string> LastLoginAt { get; private set; }

        ///
        public FilterRange<int> LoginCount { get; private set; }

        ///
        public FilterUserList()
        {
            Disabled = new FilterEqual<bool>("disabled", this);
            RequireMfa = new FilterEqual<bool>("require_mfa", this);
            Verified = new FilterEqual<bool>("verified", this);
            Scopes = new FilterEqual<List<string>>("scopes", this);

            EulaId = new FilterMatch<string>("eula_id", this);
            Email = new FilterMatch<string>("email", this);
            ID = new FilterMatch<string>("id", this);
            LastLoginIp = new FilterMatch<string>("last_login_ip", this);
            LastLoginCity = new FilterMatch<string>("last_login_city", this);
            LastLoginCountry = new FilterMatch<string>("last_login_country", this);

            CreatedAt = new FilterRange<string>("created_at", this);
            LastLoginAt = new FilterRange<string>("last_login_at", this);
            LoginCount = new FilterRange<int>("login_count", this);
        }
    }
}
