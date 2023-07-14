using Newtonsoft.Json;
using PangeaCyber.Net.Audit.arweave;
using PangeaCyber.Net.Audit.Utils;

namespace PangeaCyber.Net.Audit
{

    /// <kind>class</kind>
    /// <summary>
    /// SearchEvent
    /// </summary>
    public class SearchEvent
    {
        ///
        [JsonProperty("envelope", Required = Required.Always)]
        public Dictionary<string, object> RawEnvelope { get; private set; } = default!;

        ///
        public EventEnvelope EventEnvelope { get; set; } = default!;

        ///
        [JsonProperty("hash", Required = Required.Always)]
        public string Hash { get; private set; } = default!;

        ///
        [JsonProperty("leaf_index")]
        public int? LeafIndex { get; private set; } = default!;

        ///
        [JsonProperty("membership_proof")]
        public string MembershipProof { get; private set; } = default!;

        ///
        [JsonProperty("published")]
        public bool Published { get; private set; } = default!;

        ///
        [JsonIgnore]
        public EventVerification MembershipVerification { get; private set; } = EventVerification.NotVerified;

        ///
        [JsonIgnore]
        public EventVerification ConsistencyVerification { get; private set; } = EventVerification.NotVerified;

        ///
        [JsonIgnore]
        public EventVerification SignatureVerification { get; private set; } = EventVerification.NotVerified;

        ///
        public void VerifySignature()
        {
            if (this.EventEnvelope != null)
            {
                this.SignatureVerification = this.EventEnvelope.VerifySignature();
            }
            else
            {
                this.SignatureVerification = EventVerification.NotVerified;
            }
        }

        ///
        public void VerifyConsistency(Dictionary<int, PublishedRoot> publishedRoots)
        {
            // This should never happen.
            if (!this.Published || !this.LeafIndex.HasValue)
            {
                this.ConsistencyVerification = EventVerification.NotVerified;
                return;
            }

            if (LeafIndex.Value == 0)
            {
                this.ConsistencyVerification = EventVerification.Success;
                return;
            }

            if (LeafIndex.Value < 0)
            {
                this.ConsistencyVerification = EventVerification.Failed;
                return;
            }

            if (!publishedRoots.ContainsKey(LeafIndex.Value) || !publishedRoots.ContainsKey(LeafIndex.Value + 1))
            {
                this.ConsistencyVerification = EventVerification.NotVerified;
                return;
            }

            PublishedRoot currRoot = publishedRoots[LeafIndex.Value + 1];
            PublishedRoot prevRoot = publishedRoots[LeafIndex.Value];
            ConsistencyProof proof = Verification.DecodeConsistencyProof(currRoot.ConsistencyProof);
            
            
            this.ConsistencyVerification = Verification.VerifyConsistencyProof(currRoot.RootHash, prevRoot.RootHash, proof);
        }

        ///
        public void VerifyMembershipProof(string rootHashEnc)
        {
            if (this.MembershipProof == null)
            {
                this.MembershipVerification = EventVerification.NotVerified;
                return;
            }
            this.MembershipVerification = Verification.VerifyMembershipProof(rootHashEnc, this.Hash, this.MembershipProof);
        }
    }
}
