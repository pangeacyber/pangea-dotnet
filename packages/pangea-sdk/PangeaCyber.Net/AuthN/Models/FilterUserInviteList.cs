namespace PangeaCyber.Net.AuthN.Models
{
    ///
    public class FilterUserInviteList : Filter
    {
        ///
        public FilterMatch<string> Callback { get; private set; }

        ///
        public FilterMatch<string> Email { get; private set; }

        ///
        public FilterMatch<string> ID { get; private set; }

        ///
        public FilterMatch<string> InviteOrg { get; private set; }

        ///
        public FilterMatch<string> Inviter { get; private set; }

        ///
        public FilterMatch<string> State { get; private set; }

        ///
        public FilterEqual<bool> Signup { get; private set; }

        ///
        public FilterEqual<bool> RequireMfa { get; private set; }

        ///
        public FilterRange<string> Expire { get; private set; }

        ///
        public FilterRange<string> CreatedAt { get; private set; }

        ///
        public FilterUserInviteList()
        {
            Callback = new FilterMatch<string>("callback", this);
            Email = new FilterMatch<string>("email", this);
            ID = new FilterMatch<string>("id", this);
            InviteOrg = new FilterMatch<string>("invite_org", this);
            Inviter = new FilterMatch<string>("inviter", this);
            State = new FilterMatch<string>("state", this);
            Signup = new FilterEqual<bool>("signup", this);
            RequireMfa = new FilterEqual<bool>("require_mfa", this);
            Expire = new FilterRange<string>("expire", this);
            CreatedAt = new FilterRange<string>("created_at", this);
        }
    }
}
