using System.Text;
using Newtonsoft.Json;

namespace PangeaCyber.Net.Audit.Utils
{
    /// <kind>class</kind>
    /// <summary>
    /// Verification
    /// </summary>
    public class Verification
    {

        ///
        public static EventVerification VerifyMembershipProof(string rootHashEnc, string nodeHashEnc, string MembershipProof)
        {
            if (MembershipProof == null || rootHashEnc == null || nodeHashEnc == null)
            {
                return EventVerification.NotVerified;
            }

            if (MembershipProof.Length == 0)
            {
                return rootHashEnc.Equals(nodeHashEnc) ? EventVerification.Success : EventVerification.Failed;
            }

            byte[] rootHash = Hash.Decode(rootHashEnc);
            byte[] nodeHash = Hash.Decode(nodeHashEnc);
            MembershipProof proof = Verification.DecodeMembershipProof(MembershipProof);

            foreach (MembershipProofItem item in proof)
            {
                try
                {
                    nodeHash = item.Side.Equals("left") ? Hash.GetHash(item.Hash, nodeHash) : Hash.GetHash(nodeHash, item.Hash);
                }
                catch (Exception)
                {
                    return EventVerification.Failed;
                }
            }
            return nodeHash.SequenceEqual(rootHash) ? EventVerification.Success : EventVerification.Failed;
        }

        ///
        public static MembershipProof DecodeMembershipProof(string memProof)
        {
            MembershipProof proof = new MembershipProof();
            string[] items = memProof.Split(',');
            foreach (string item in items)
            {
                string[] parts = item.Split(':');
                if (parts.Length >= 2)
                { // This should never happen, but just in case
                    string side = parts[0].Equals("l") ? "left" : "right";
                    MembershipProofItem proofItem = new MembershipProofItem(side, Hash.Decode(parts[1]));
                    proof.AddLast(proofItem);
                }
            }
            return proof;
        }

        ///
        public static ConsistencyProof DecodeConsistencyProof(string[] ConsistencyProof)
        {
            ConsistencyProof proof = new ConsistencyProof();
            foreach (string item in ConsistencyProof)
            {
                string[] parts = item.Split(new char[] { ',' }, 2);
                if (parts.Length >= 2)
                {
                    string[] hashParts = parts[0].Split(':');
                    if (hashParts.Length >= 2)
                    {
                        string hash = hashParts[1];
                        proof.AddLast(new ConsistencyProofItem(hash, parts[1]));
                    }
                }
            }

            return proof;
        }

        ///
        public static EventVerification VerifyConsistencyProof(string currRootHashEnc, string prevRootHashEnc, ConsistencyProof proof)
        {
            if (proof == null || proof.Count == 0)
            {
                return EventVerification.Failed;
            }

            byte[] prevRootHash = Hash.Decode(prevRootHashEnc);
            byte[] rootHash = Hash.Decode(proof.First().Hash ?? default!);

            int idx = 0;
            foreach (ConsistencyProofItem item in proof)
            {
                if (idx > 0)
                {
                    try
                    {
                        rootHash = Hash.GetHash(Hash.Decode(item.Hash), rootHash);
                    }
                    catch (Exception)
                    {
                        return EventVerification.Failed;
                    }
                }
                idx++;
            }

            if (!rootHash.SequenceEqual(prevRootHash))
            {
                return EventVerification.Failed;
            }

            foreach (ConsistencyProofItem item in proof)
            {
                if (Verification.VerifyMembershipProof(currRootHashEnc, item.Hash, item.MembershipProof) != EventVerification.Success)
                {
                    return EventVerification.Failed;
                }
            }

            return EventVerification.Success;
        }
    }
}
