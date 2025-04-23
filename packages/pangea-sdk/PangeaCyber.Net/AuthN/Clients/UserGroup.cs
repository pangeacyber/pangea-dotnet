using PangeaCyber.Net.AuthN.Models;
using PangeaCyber.Net.AuthN.Requests;

namespace PangeaCyber.Net.AuthN.Clients;

/// <summary>UserGroup</summary>
public sealed class UserGroup : AuthNBaseClient
{
    /// <summary>Constructor.</summary>
    public UserGroup(AuthNClient.Builder builder) : base(builder) { }

    /// <summary>Assign groups to a user</summary>
    /// <remarks>Add a list of groups to a specified user</remarks>
    /// <operationid>authn_post_v2_user_group_assign</operationid>
    /// <example>
    /// <code>
    /// var request = new AssignUserGroupRequest {
    ///     Id = "My User ID",
    ///     GroupIds = new List&lt;string&gt; { "My Group ID" }
    /// };
    ///
    /// var response = await client.UserGroup.Assign(request);
    /// </code>
    /// </example>
    public async Task<Response<object>> Assign(
        AssignUserGroupRequest request,
        CancellationToken cancellationToken = default
    )
    {
        return await DoPost<object>("/v2/user/group/assign", request, cancellationToken: cancellationToken);
    }

    /// <summary>Remove a group assigned to a user</summary>
    /// <remarks>Remove a group assigned to a user</remarks>
    /// <operationid>authn_post_v2_user_group_remove</operationid>
    /// <example>
    /// <code>
    /// var request = new RemoveUserGroupRequest {
    ///     Id = "My User ID",
    ///     GroupId = "My Group ID"
    /// };
    ///
    /// var response = await client.UserGroup.Remove(request);
    /// </code>
    /// </example>
    public async Task<Response<object>> Remove(
        RemoveUserGroupRequest request,
        CancellationToken cancellationToken = default
    )
    {
        return await DoPost<object>("/v2/user/group/remove", request, cancellationToken: cancellationToken);
    }

    /// <summary>List of groups assigned to a user</summary>
    /// <remarks>Return a list of ids for groups assigned to a user</remarks>
    /// <operationid>authn_post_v2_user_group_list</operationid>
    /// <example>
    /// <code>
    /// var request = new ListUserGroupsRequest {
    ///     Id = "My User ID"
    /// };
    ///
    /// var response = await client.UserGroup.List(request);
    /// </code>
    /// </example>
    public async Task<Response<GroupList>> List(
        ListUserGroupsRequest request,
        CancellationToken cancellationToken = default
    )
    {
        return await DoPost<GroupList>("/v2/user/group/list", request, cancellationToken: cancellationToken);
    }
}
