using PangeaCyber.Net.AuthN.Models;
using PangeaCyber.Net.AuthN.Requests;

namespace PangeaCyber.Net.AuthN.Clients;

/// <summary>Group</summary>
public sealed class Group : AuthNBaseClient
{
    /// <summary>Constructor.</summary>
    public Group(AuthNClient.Builder builder) : base(builder) { }

    /// <summary>Create a new group</summary>
    /// <remarks>Create a new group</remarks>
    /// <operationid>authn_post_v2_group_create</operationid>
    /// <example>
    /// <code>
    /// var request = new CreateGroupRequest {
    ///     Name = "My Group",
    ///     Description = "My Group Description",
    ///     Type = "My Group Type"
    /// };
    ///
    /// var response = await client.Group.Create(request);
    /// </code>
    /// </example>
    public async Task<Response<GroupInfo>> Create(
        CreateGroupRequest request,
        CancellationToken cancellationToken = default
    )
    {
        return await DoPost<GroupInfo>("/v2/group/create", request, cancellationToken: cancellationToken);
    }

    /// <summary>Delete a group</summary>
    /// <remarks>Delete a group</remarks>
    /// <operationid>authn_post_v2_group_delete</operationid>
    /// <example>
    /// <code>
    /// var request = new DeleteGroupRequest {
    ///     Id = "My Group ID"
    /// };
    ///
    /// var response = await client.Group.Delete(request);
    /// </code>
    /// </example>
    public async Task<Response<GroupInfo>> Delete(
        DeleteGroupRequest request,
        CancellationToken cancellationToken = default
    )
    {
        return await DoPost<GroupInfo>("/v2/group/delete", request, cancellationToken: cancellationToken);
    }

    /// <summary>Get group information</summary>
    /// <remarks>Look up a group by ID and return its information</remarks>
    /// <operationid>authn_post_v2_group_get</operationid>
    /// <example>
    /// <code>
    /// var request = new GetGroupRequest {
    ///     Id = "My Group ID"
    /// };
    ///
    /// var response = await client.Group.Get(request);
    /// </code>
    /// </example>
    public async Task<Response<GroupInfo>> Get(
        GetGroupRequest request,
        CancellationToken cancellationToken = default
    )
    {
        return await DoPost<GroupInfo>("/v2/group/get", request, cancellationToken: cancellationToken);
    }

    /// <summary>List groups</summary>
    /// <remarks>List groups</remarks>
    /// <operationid>authn_post_v2_group_list</operationid>
    /// <example>
    /// <code>
    /// var request = new ListGroupsRequest {
    ///     Filter = new GroupsFilter {
    ///         Name = "My Group"
    ///     }
    /// };
    ///
    /// var response = await client.Group.List(request);
    /// </code>
    /// </example>
    public async Task<Response<GroupInfo>> List(
        ListGroupsRequest request,
        CancellationToken cancellationToken = default
    )
    {
        return await DoPost<GroupInfo>("/v2/group/list", request, cancellationToken: cancellationToken);
    }

    /// <summary>Update group information</summary>
    /// <remarks>Update group information</remarks>
    /// <operationid>authn_post_v2_group_update</operationid>
    /// <example>
    /// <code>
    /// var request = new UpdateGroupRequest {
    ///     Id = "My Group ID",
    ///     Name = "My Group",
    ///     Description = "My Group Description",
    ///     Type = "My Group Type"
    /// };
    ///
    /// var response = await client.Group.Update(request);
    /// </code>
    /// </example>
    public async Task<Response<GroupInfo>> Update(
        UpdateGroupRequest request,
        CancellationToken cancellationToken = default
    )
    {
        return await DoPost<GroupInfo>("/v2/group/update", request, cancellationToken: cancellationToken);
    }

    /// <summary>List of users assigned to a group</summary>
    /// <remarks>Return a list of ids for users assigned to a group</remarks>
    /// <operationid>authn_post_v2_group_user_list</operationid>
    /// <example>
    /// <code>
    /// var request = new ListGroupUsersRequest {
    ///     Id = "My Group ID"
    /// };
    ///
    /// var response = await client.Group.ListUsers(request);
    /// </code>
    /// </example>
    public async Task<Response<GroupInfo>> ListUsers(
        ListGroupUsersRequest request,
        CancellationToken cancellationToken = default
    )
    {
        return await DoPost<GroupInfo>("/v2/group/user/list", request, cancellationToken: cancellationToken);
    }
}
