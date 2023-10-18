using PangeaCyber.Net.AuthN.Requests;
using PangeaCyber.Net.AuthN.Results;

namespace PangeaCyber.Net.AuthN.Clients
{
    ///
    public class Agreements : AuthNBaseClient
    {
        ///
        public Agreements(AuthNClient.Builder builder) : base(builder) { }

        // TODO: Docs
        ///
        public async Task<Response<AgreementCreateResult>> Create(AgreementCreateRequest request)
        {
            return await DoPost<AgreementCreateResult>("/v2/agreements/create", request);
        }

        // TODO: Docs
        ///
        public async Task<Response<AgreementDeleteResult>> Delete(AgreementDeleteRequest request)
        {
            return await DoPost<AgreementDeleteResult>("/v2/agreements/delete", request);
        }

        // TODO: Docs
        ///
        public async Task<Response<AgreementUpdateResult>> Update(AgreementUpdateRequest request)
        {
            return await DoPost<AgreementUpdateResult>("/v2/agreements/update", request);
        }

        // TODO: Docs
        ///
        public async Task<Response<AgreementListResult>> List(AgreementListRequest request)
        {
            return await DoPost<AgreementListResult>("/v2/agreements/list", request);
        }

    }
}
