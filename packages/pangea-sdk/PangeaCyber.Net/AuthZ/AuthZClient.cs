using PangeaCyber.Net.AuthZ.Requests;
using PangeaCyber.Net.AuthZ.Results;
using PangeaCyber.Net.Exceptions;

namespace PangeaCyber.Net.AuthZ
{
    /// <summary>AuthZ client.</summary>
    /// <remarks>AuthZ (Beta)</remarks>
    /// <example>
    /// <code>
    /// var config = new Config("pangea_token", "pangea_domain");
    /// var builder = new AuthZClient.Builder(config);
    /// var client = builder.Build();
    /// </code>
    /// </example>
    public class AuthZClient : BaseClient<AuthZClient.Builder>
    {
        /// <summary>Service name.</summary>
        public static string ServiceName { get; } = "authz";

        /// <summary>Create a new <see cref="AuthZClient"/> using the given builder.</summary>
        /// <param name="builder">AuthZ client builder.</param>
        public AuthZClient(Builder builder) : base(builder, ServiceName) { }

        /// <summary>
        /// Create tuples in the AuthZ Service. The request will fail if there is no schema or the tuples do not
        /// validate against the schema.
        /// How to install a <see href="https://pangea.cloud/docs/sdk/csharp/#beta-releases">Beta release</see>.
        /// </summary>
        /// <remarks>Create tuples. (Beta)</remarks>
        /// <operationid>authz_post_v1_tuple_create</operationid>
        /// <param name="request">The request to the '/tuple/create' endpoint.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns>Empty result.</returns>
        /// <exception cref="PangeaException">Thrown if an error occurs during the operation.</exception>
        /// <exception cref="PangeaAPIException">Thrown if the API returns an error response.</exception>
        /// <example>
        /// <code>
        /// var request = new TupleCreateRequest(
        ///     new Net.AuthZ.Models.Tuple[] {
        ///         new(
        ///             new Resource("folder") { ID = "folder1" },
        ///             "owner",
        ///             new Subject("user") { ID = "user_1" }
        ///         )
        ///     }
        /// );
        /// await client.TupleCreate(request);
        /// </code>
        /// </example>
        public async Task<Response<TupleCreateResult>> TupleCreate(TupleCreateRequest request, CancellationToken cancellationToken = default)
        {
            return await DoPost<TupleCreateResult>("/v1/tuple/create", request, cancellationToken: cancellationToken);
        }

        /// <summary>
        /// Return a paginated list of filtered tuples. The filter is given in terms of a tuple. Fill out the fields
        /// that you want to filter. If the filter is empty it will return all the tuples.
        /// How to install a <see href="https://pangea.cloud/docs/sdk/csharp/#beta-releases">Beta release</see>.
        /// </summary>
        /// <remarks>List tuples. (Beta)</remarks>
        /// <operationid>authz_post_v1_tuple_list</operationid>
        /// <param name="request">The request to the '/tuple/list' endpoint.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns>List of tuples.</returns>
        /// <exception cref="PangeaException">Thrown if an error occurs during the operation.</exception>
        /// <exception cref="PangeaAPIException">Thrown if the API returns an error response.</exception>
        /// <example>
        /// <code>
        /// var filter = new FilterTupleList();
        /// filter.SubjectType.Set("user);
        /// filter.SubjectID.Set("user_id");
        /// var request = new TupleListRequest
        /// {
        ///     Filter = filter,
        ///     Size = 10, // Optional: Set the size of the result set
        ///     Last = "token123", // Optional: Set the last token from a previous response
        ///     Order = ItemOrder.Desc, // Optional: Set the order (asc or desc)
        ///     OrderBy = TupleOrderBy.ResourceType // Optional: Set the field to order results by
        /// };
        /// var response = await client.TupleList(request);
        /// </code>
        /// </example>
        public async Task<Response<TupleListResult>> TupleList(TupleListRequest request, CancellationToken cancellationToken = default)
        {
            return await DoPost<TupleListResult>("/v1/tuple/list", request, cancellationToken: cancellationToken);
        }

        /// <summary>
        /// Delete tuples in the AuthZ Service.
        /// How to install a <see href="https://pangea.cloud/docs/sdk/csharp/#beta-releases">Beta release</see>.
        /// </summary>
        /// <remarks>Delete tuples. (Beta)</remarks>
        /// <operationid>authz_post_v1_tuple_delete</operationid>
        /// <param name="request">The request to the '/tuple/delete' endpoint.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns>Empty result.</returns>
        /// <exception cref="PangeaException">Thrown if an error occurs during the operation.</exception>
        /// <exception cref="PangeaAPIException">Thrown if the API returns an error response.</exception>
        /// <example>
        /// <code>
        /// var request = new TupleDeleteRequest(
        ///     new Net.AuthZ.Models.Tuple[] {
        ///         new(
        ///             new Resource("folder") { ID = "folder1" },
        ///             "owner",
        ///             new Subject("user") { ID = "user_1" }
        ///         )
        ///     }
        /// );
        /// await client.TupleDelete(request);
        /// </code>
        /// </example>
        public async Task<Response<TupleDeleteResult>> TupleDelete(TupleDeleteRequest request, CancellationToken cancellationToken = default)
        {
            return await DoPost<TupleDeleteResult>("/v1/tuple/delete", request, cancellationToken: cancellationToken);
        }

        /// <summary>
        /// Check if a subject has permission to perform an action on the resource.
        /// How to install a <see href="https://pangea.cloud/docs/sdk/csharp/#beta-releases">Beta release</see>.
        /// </summary>
        /// <remarks>Perform a check request. (Beta)</remarks>
        /// <operationid>authz_post_v1_check</operationid>
        /// <param name="request">The request to the '/check' endpoint.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns>Result of the authorization check.</returns>
        /// <exception cref="PangeaException">Thrown if an error occurs during the operation.</exception>
        /// <exception cref="PangeaAPIException">Thrown if the API returns an error response.</exception>
        /// <example>
        /// <code>
        /// var response = await client.Check(new CheckRequest(
        ///     new Resource("folder") { ID = "folder1" },
        ///     "editor",
        ///     new Subject("user") { ID = "user_1" }
        /// ));
        /// </code>
        /// </example>
        public async Task<Response<CheckResult>> Check(CheckRequest request, CancellationToken cancellationToken = default)
        {
            return await DoPost<CheckResult>("/v1/check", request, cancellationToken: cancellationToken);
        }

        /// <summary>
        /// Given a type, action, and subject, list all the resources of the type that the subject has access
        /// to the action with.
        /// How to install a <see href="https://pangea.cloud/docs/sdk/csharp/#beta-releases">Beta release</see>.
        /// </summary>
        /// <remarks>List resources. (Beta)</remarks>
        /// <operationid>authz_post_v1_list-resources</operationid>
        /// <param name="request">The request to the '/list-resources' endpoint.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns>List of resources.</returns>
        /// <exception cref="PangeaException">Thrown if an error occurs during the operation.</exception>
        /// <exception cref="PangeaAPIException">Thrown if the API returns an error response.</exception>
        /// <example>
        /// <code>
        /// var response = await client.ListResources(new ListResourcesRequest(
        ///     "folder",
        ///     "update",
        ///     new Subject("user") { ID = "user_1" }
        /// ));
        /// </code>
        /// </example>
        public async Task<Response<ListResourcesResult>> ListResources(ListResourcesRequest request, CancellationToken cancellationToken = default)
        {
            return await DoPost<ListResourcesResult>("/v1/list-resources", request, cancellationToken: cancellationToken);
        }

        /// <summary>
        /// Given a resource and an action, return the list of subjects who have access to the action for the given
        /// resource.
        /// How to install a <see href="https://pangea.cloud/docs/sdk/csharp/#beta-releases">Beta release</see>.
        /// </summary>
        /// <remarks>List subjects. (Beta)</remarks>
        /// <operationid>authz_post_v1_list-subjects</operationid>
        /// <param name="request">The request to the '/list-subjects' endpoint.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns>List of subjects.</returns>
        /// <exception cref="PangeaException">Thrown if an error occurs during the operation.</exception>
        /// <exception cref="PangeaAPIException">Thrown if the API returns an error response.</exception>
        /// <example>
        /// <code>
        /// var response = await client.ListSubjects(new ListSubjectsRequest(
        ///     new Resource("folder") { ID = "folder_1" },
        ///     "update"
        /// ));
        /// </code>
        /// </example>
        public async Task<Response<ListSubjectsResult>> ListSubjects(ListSubjectsRequest request, CancellationToken cancellationToken = default)
        {
            return await DoPost<ListSubjectsResult>("/v1/list-subjects", request, cancellationToken: cancellationToken);
        }

        /// <summary><see cref="AuthZClient"/> builder.</summary>
        public class Builder : ClientBuilder
        {
            /// <summary>Create a new <see cref="AuthZClient"/> builder.</summary>
            public Builder(Config config) : base(config)
            {
            }

            /// <summary>Build a <see cref="AuthZClient"/>.</summary>
            public AuthZClient Build()
            {
                return new AuthZClient(this);
            }
        }
    }
}
