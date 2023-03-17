
namespace PangeaCyber.Net.Audit.Utils
{
    /// <kind>class</kind>
    /// <summary>
    /// ConsistencyProof
    /// </summary>
    public class ConsistencyProofItem
    {
        ///
        public string Hash { get; private set; }

        ///
        public string MembershipProof { get; private set; }

        ///
        public ConsistencyProofItem(string hash, string MembershipProof)
        {
            this.MembershipProof = MembershipProof;
            this.Hash = hash;
        }
    }
}
