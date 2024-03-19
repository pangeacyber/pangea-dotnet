using PangeaCyber.Net.AuthZ.Requests;
using PangeaCyber.Net.AuthZ.Results;
using PangeaCyber.Net.Exceptions;

namespace PangeaCyber.Net.AuthZ
{
    /// <kind>class</kind>
    /// <summary>
    /// AuthZ Client
    /// </summary>
    public class AuthZClient : BaseClient<AuthZClient.Builder>
    {
        ///
        public static string ServiceName { get; } = "authz";

        /// Constructor
        public AuthZClient(Builder builder) : base(builder, ServiceName) { }

        /// <kind>method</kind>
        /// <summary>
        /// Create tuples in the AuthZ Service.
        /// </summary>
        /// <remarks>Create tuples.</remarks>
        /// <operationid>authz_post_v1beta_tuple_create</operationid>
        /// <param name="request" type="PangeaCyber.Net.AuthZ.Requests.TupleCreateRequest">The request to the '/tuple/create' endpoint.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns>Response&lt;TupleCreateResult&gt;</returns>
        /// <exception cref="PangeaException">Thrown if an error occurs during the operation.</exception>
        /// <exception cref="PangeaAPIException">Thrown if the API returns an error response.</exception>
        /// <example>
        /// <code>
        /// var request = new TupleCreateRequest
        /// {
        ///     new Net.AuthZ.Models.Tuple[] { tuple1, tuple2, tuple3, tuple4 }
        /// };
        /// var response = await client.TupleCreate(request);
        /// </code>
        /// </example>
        public async Task<Response<TupleCreateResult>> TupleCreate(TupleCreateRequest request, CancellationToken cancellationToken = default)
        {
            return await DoPost<TupleCreateResult>("/v1beta/tuple/create", request, cancellationToken: cancellationToken);
        }

        /// <kind>method</kind>
        /// <summary>
        /// Return a paginated list of filtered tuples.
        /// </summary>
        /// <remarks>List tuples.</remarks>
        /// <operationid>authz_post_v1beta_tuple_list</operationid>
        /// <param name="request" type="PangeaCyber.Net.AuthZ.Requests.TupleListRequest">The request to the '/tuple/list' endpoint.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns>Response&lt;TupleListResult&gt;</returns>
        /// <exception cref="PangeaException">Thrown if an error occurs during the operation.</exception>
        /// <exception cref="PangeaAPIException">Thrown if the API returns an error response.</exception>
        /// <example>
        /// <code>
        /// filter = new FilterTupleList();
        /// filter.SubjectNamespace.Set("user);
        /// filter.SubjectID.Set("user_id");
        /// var request = new TupleListRequest
        /// {
        ///     Filter = filter,
        ///     Size = 10, // Optional: Set the size of the result set
        ///     Last = "token123", // Optional: Set the last token from a previous response
        ///     Order = ItemOrder.Desc, // Optional: Set the order (asc or desc)
        ///     OrderBy = TupleOrderBy.ResourceNamespace // Optional: Set the field to order results by
        /// };
        /// var response = await client.TupleList(request);
        /// </code>
        /// </example>
        public async Task<Response<TupleListResult>> TupleList(TupleListRequest request, CancellationToken cancellationToken = default)
        {
            return await DoPost<TupleListResult>("/v1beta/tuple/list", request, cancellationToken: cancellationToken);
        }

        /// <kind>method</kind>
        /// <summary>
        /// Delete tuples in the AuthZ Service.
        /// </summary>
        /// <remarks>Delete tuples.</remarks>
        /// <operationid>authz_post_v1beta_tuple_delete</operationid>
        /// <param name="request" type="PangeaCyber.Net.AuthZ.Requests.TupleDeleteRequest">The request to the '/tuple/delete' endpoint.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns>Response&lt;TupleDeleteResult&gt;</returns>
        /// <exception cref="PangeaException">Thrown if an error occurs during the operation.</exception>
        /// <exception cref="PangeaAPIException">Thrown if the API returns an error response.</exception>
        /// <example>
        /// <code>
        /// var request = new TupleDeleteRequest
        /// {
        ///     new Net.AuthZ.Models.Tuple[] { tuple1 }
        /// };
        /// var response = await client.TupleDelete(request);
        /// </code>
        /// </example>
        public async Task<Response<TupleDeleteResult>> TupleDelete(TupleDeleteRequest request, CancellationToken cancellationToken = default)
        {
            return await DoPost<TupleDeleteResult>("/v1beta/tuple/delete", request, cancellationToken: cancellationToken);
        }

        /// <kind>method</kind>
        /// <summary>
        /// Check if a subject has permission to perform an action on the resource.
        /// </summary>
        /// <remarks>Perform a check request.</remarks>
        /// <operationid>authz_post_v1beta_check</operationid>
        /// <param name="request" type="PangeaCyber.Net.AuthZ.Requests.CheckRequest">The request to the '/check' endpoint.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns>Response&lt;CheckResult&gt;</returns>
        /// <exception cref="PangeaException">Thrown if an error occurs during the operation.</exception>
        /// <exception cref="PangeaAPIException">Thrown if the API returns an error response.</exception>
        /// <example>
        /// <code>
        /// var request = new CheckRequest
        /// {
        ///     Resource = new Resource
        ///     {
        ///         // Provide Resource details here
        ///     },
        ///     Action = "action_here",
        ///     Subject = new Subject
        ///     {
        ///         // Provide Subject details here
        ///     },
        ///     Debug = true, // Optional: Set to true for detailed analysis
        ///     Attributes = new Dictionary&lt;string, object&gt;
        ///     {
        ///         // Provide additional attributes here
        ///     }
        /// };
        /// var response = await client.Check(request);
        /// </code>
        /// </example>
        public async Task<Response<CheckResult>> Check(CheckRequest request, CancellationToken cancellationToken = default)
        {
            return await DoPost<CheckResult>("/v1beta/check", request, cancellationToken: cancellationToken);
        }

        /// <kind>method</kind>
        /// <summary>
        /// Given a namespace, action, and subject, list all the resources in the namespace
        /// that the subject has the action with.
        /// </summary>
        /// <remarks>List resources.</remarks>
        /// <operationid>authz_post_v1beta_list-resources</operationid>
        /// <param name="request" type="PangeaCyber.Net.AuthZ.Requests.ListResourcesRequest">The request to the '/list-resources' endpoint.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns>Response&lt;ListResourcesResult&gt;</returns>
        /// <exception cref="PangeaException">Thrown if an error occurs during the operation.</exception>
        /// <exception cref="PangeaAPIException">Thrown if the API returns an error response.</exception>
        /// <example>
        /// <code>
        /// var request = new ListResourcesRequest
        /// {
        ///     Namespace = "namespace_here",
        ///     Action = "action_here",
        ///     Subject = new Subject
        ///     {
        ///         // Provide Subject details here
        ///     }
        /// };
        /// var response = await client.ListResources(request);
        /// </code>
        /// </example>
        public async Task<Response<ListResourcesResult>> ListResources(ListResourcesRequest request, CancellationToken cancellationToken = default)
        {
            return await DoPost<ListResourcesResult>("/v1beta/list-resources", request, cancellationToken: cancellationToken);
        }

        /// <kind>method</kind>
        /// <summary>
        /// Given a resource and an action, return the list of subjects who have the given action to the given resource.
        /// </summary>
        /// <remarks>List subjects.</remarks>
        /// <operationid>authz_post_v1beta_list-subjects</operationid>
        /// <param name="request" type="PangeaCyber.Net.AuthZ.Requests.ListSubjectsRequest">The request to the '/list-subjects' endpoint.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns>Response&lt;ListSubjectsResult&gt;</returns>
        /// <exception cref="PangeaException">Thrown if an error occurs during the operation.</exception>
        /// <exception cref="PangeaAPIException">Thrown if the API returns an error response.</exception>
        /// <example>
        /// <code>
        /// var request = new ListSubjectsRequest
        /// {
        ///     Resource = new Resource
        ///     {
        ///         // Provide Resource details here
        ///     },
        ///     Action = "action_here"
        /// };
        /// var response = await client.ListSubjects(request);
        /// </code>
        /// </example>
        public async Task<Response<ListSubjectsResult>> ListSubjects(ListSubjectsRequest request, CancellationToken cancellationToken = default)
        {
            return await DoPost<ListSubjectsResult>("/v1beta/list-subjects", request, cancellationToken: cancellationToken);
        }

        ///
        public class Builder : ClientBuilder
        {
            ///
            public Builder(Config config) : base(config)
            {
            }

            ///
            public AuthZClient Build()
            {
                return new AuthZClient(this);
            }
        }
    }
}
