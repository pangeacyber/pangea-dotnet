using PangeaCyber.Net.AuthN.Requests;
using PangeaCyber.Net.AuthN.Results;

namespace PangeaCyber.Net.AuthN.Clients
{
    ///
    public class Agreements : AuthNBaseClient
    {
        ///
        public Agreements(AuthNClient.Builder builder) : base(builder) { }

        /// <kind>method</kind>
        /// <summary>Create an agreement.</summary>
        /// <remarks>Create an agreement</remarks>
        /// <operationid>authn_post_v2_agreements_create</operationid>
        /// <param name="request" type="PangeaCyber.Net.AuthN.Requests.AgreementCreateRequest">AgreementCreateRequest</param>
        /// <returns>Response&lt;AgreementCreateResult&gt;</returns>
        /// <example>
        /// <code>
        /// var request = new AgreementCreateRequest.Builder(
        ///     AgreementType.eula,
        ///     "EULA_V1",
        ///     "You agree to behave yourself while logged in.")
        ///     .Build();
        /// var response = await client.Agreements.Create(request);
        /// </code>
        /// </example>
        public async Task<Response<AgreementCreateResult>> Create(AgreementCreateRequest request)
        {
            return await DoPost<AgreementCreateResult>("/v2/agreements/create", request);
        }

        /// <kind>method</kind>
        /// <summary>Delete an agreement.</summary>
        /// <remarks>Delete an agreement</remarks>
        /// <operationid>authn_post_v2_agreements_delete</operationid>
        /// <param name="request" type="PangeaCyber.Net.AuthN.Requests.AgreementDeleteRequest">AgreementDeleteRequest</param>
        /// <returns>Response&lt;AgreementDeleteResult&gt;</returns>
        /// <example>
        /// <code>
        /// </code>
        /// </example>
        public async Task<Response<AgreementDeleteResult>> Delete(AgreementDeleteRequest request)
        {
            return await DoPost<AgreementDeleteResult>("/v2/agreements/delete", request);
        }

        /// <kind>method</kind>
        /// <summary>Update agreement.</summary>
        /// <remarks>Update agreement</remarks>
        /// <operationid>authn_post_v2_agreements_update</operationid>
        /// <param name="request" type="PangeaCyber.Net.AuthN.Requests.AgreementUpdateRequest">AgreementUpdateRequest</param>
        /// <returns>Response&lt;AgreementUpdateResult&gt;</returns>
        /// <example>
        /// <code>
        /// </code>
        /// </example>
        public async Task<Response<AgreementUpdateResult>> Update(AgreementUpdateRequest request)
        {
            return await DoPost<AgreementUpdateResult>("/v2/agreements/update", request);
        }

        /// <kind>method</kind>
        /// <summary>List agreements.</summary>
        /// <remarks>List agreements</remarks>
        /// <operationid>authn_post_v2_agreements_list</operationid>
        /// <param name="request" type="PangeaCyber.Net.AuthN.Requests.AgreementListRequest">AgreementListRequest</param>
        /// <returns>Response&lt;AgreementListResult&gt;</returns>
        /// <example>
        /// <code>
        /// </code>
        /// </example>
        public async Task<Response<AgreementListResult>> List(AgreementListRequest request)
        {
            return await DoPost<AgreementListResult>("/v2/agreements/list", request);
        }

    }
}
