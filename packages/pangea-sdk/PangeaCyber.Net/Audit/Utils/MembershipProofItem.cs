
namespace PangeaCyber.Net.Audit.Utils
{
    /// <kind>class</kind>
    /// <summary>
    /// MembershipProofItem
    /// </summary>
    public class MembershipProofItem
    {
        ///
        public string Side { get; private set; }

        ///
        public byte[] Hash { get; private set; }

        ///
        public MembershipProofItem(string side, byte[] hash)
        {
            this.Side = side;
            this.Hash = hash;
        }
    }
}
