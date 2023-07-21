namespace PangeaCyber.Net.AuthN.Clients
{
    ///
    public class FlowEnroll : AuthNBaseClient
    {
        ///
        public FlowEnrollMFA MFA { get; private set; }

        ///
        public FlowEnroll(AuthNClient.Builder builder) : base(builder)
        {
            MFA = new FlowEnrollMFA(builder);
        }

    }
}
