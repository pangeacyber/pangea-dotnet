using Newtonsoft.Json;
using PangeaCyber.Net.Exceptions;

namespace PangeaCyber.Net.Management;

internal sealed class AuthorizationClient : BaseClient<AuthorizationClient.Builder>
{
    /// <summary>Service name.</summary>
    private const string ServiceName = "authorization.access";

    /// <summary>Create a new <see cref="AuthorizationClient"/> using the given builder.</summary>
    public AuthorizationClient(Builder builder)
        : base(builder, ServiceName)
    {
    }

    /// <summary><see cref="AuthorizationClient"/> builder.</summary>
    public class Builder : ClientBuilder
    {
        /// <summary>Create a new <see cref="AuthorizationClient"/> builder.</summary>
        public Builder(Config config)
            : base(config)
        {
        }

        /// <summary>Build an <see cref="AuthorizationClient"/>.</summary>
        public AuthorizationClient Build()
        {
            return new AuthorizationClient(this);
        }
    }


    public async Task<AccessClientCreateInfo> CreateClient(
        CreateClientRequest request,
        CancellationToken cancellationToken = default
    )
    {
        return await this.PostNonPangeaResponse<AccessClientCreateInfo>(
            "/v1beta/oauth/clients/register",
            request,
            cancellationToken
        );
    }

    public async Task<AccessClientListResult> ListClients(
        ListClientsRequest request,
        CancellationToken cancellationToken = default
    )
    {
        var query = JsonConvert.DeserializeObject<Dictionary<string, string>>(
            JsonConvert.SerializeObject(request)
        );
        return await this.GetNonPangeaResponse<AccessClientListResult>(
            "/v1beta/oauth/clients",
            query,
            cancellationToken
        );
    }

    public async Task<AccessClientInfo> GetClient(
        string clientId,
        CancellationToken cancellationToken = default
    )
    {
        return await this.GetNonPangeaResponse<AccessClientInfo>(
            $"/v1beta/oauth/clients/{clientId}",
            cancellationToken: cancellationToken
        );
    }

    public async Task<AccessClientInfo> UpdateClient(
        string clientId,
        UpdateClientRequest options,
        CancellationToken cancellationToken = default
    )
    {
        return await this.PostNonPangeaResponse<AccessClientInfo>(
            $"/v1beta/oauth/clients/{clientId}",
            options,
            cancellationToken
        );
    }

    public async Task DeleteClient(
        string clientId,
        CancellationToken cancellationToken = default
    )
    {
        await this.DoDelete(
            $"/v1beta/oauth/clients/{clientId}",
            cancellationToken
        );
    }

    public async Task<AccessClientSecretInfo> CreateClientSecret(
        CreateClientSecretRequest request,
        CancellationToken cancellationToken = default
    )
    {
        return await this.PostNonPangeaResponse<AccessClientSecretInfo>(
            $"/v1beta/oauth/clients/{request.ClientId}/secrets",
            request,
            cancellationToken
        );
    }

    public async Task<AccessClientSecretInfoListResult> ListClientSecretMetadata(
        ListClientSecretMetadataRequest request,
        CancellationToken cancellationToken = default
    )
    {
        return await this.PostNonPangeaResponse<AccessClientSecretInfoListResult>(
            $"/v1beta/oauth/clients/{request.Id}/secrets/metadata",
            request,
            cancellationToken
        );
    }

    public async Task RevokeClientSecret(
        string id,
        string clientSecretId,
        CancellationToken cancellationToken = default
    )
    {
        await this.DoDelete(
            $"/v1beta/oauth/clients/{id}/secrets/{clientSecretId}",
            cancellationToken
        );
    }

    public async Task<AccessClientSecretInfo> UpdateClientSecret(
        string id,
        string clientSecretId,
        UpdateClientSecretRequest options,
        CancellationToken cancellationToken = default
    )
    {
        return await this.PostNonPangeaResponse<AccessClientSecretInfo>(
            $"/v1beta/oauth/clients/{id}/secrets/{clientSecretId}",
            options,
            cancellationToken
        );
    }

    public async Task<AccessRolesListResult> ListClientRoles(
        string id,
        ListClientRolesRequest request,
        CancellationToken cancellationToken = default
    )
    {
        return await this.PostNonPangeaResponse<AccessRolesListResult>(
            $"/v1beta/oauth/clients/{id}/roles",
            request,
            cancellationToken
        );
    }

    public async Task GrantClientAccess(
        string id,
        GrantClientAccessRequest request,
        CancellationToken cancellationToken = default
    )
    {
        await this.PostNonPangeaResponse<object>(
            $"/v1beta/oauth/clients/{id}/grant",
            request,
            cancellationToken
        );
    }

    public async Task RevokeClientAccess(
        string id,
        RevokeClientAccessRequest request,
        CancellationToken cancellationToken = default
    )
    {
        await this.PostNonPangeaResponse<object>(
            $"/v1beta/oauth/clients/{id}/revoke",
            request,
            cancellationToken
        );
    }

    private async Task<T> GetNonPangeaResponse<T>(
        string path,
        IReadOnlyDictionary<string, string>? query = null,
        CancellationToken cancellationToken = default
    )
    {
        var response = await this.DoGet(
            path,
            query,
            cancellationToken
        );
        return JsonConvert.DeserializeObject<T>(await response.Content.ReadAsStringAsync(), JsonSerializeSettings)
            ?? throw new PangeaException("Failed to deserialize response", null);
    }

    private async Task<T> PostNonPangeaResponse<T>(
        string path,
        BaseRequest request,
        CancellationToken cancellationToken = default
    )
    {
        var response = await this.SimplePost(
            path,
            request,
            cancellationToken: cancellationToken
        );
        return JsonConvert.DeserializeObject<T>(await response.Content.ReadAsStringAsync(), JsonSerializeSettings)
            ?? throw new PangeaException("Failed to deserialize response", null);
    }
}

internal sealed class ConsoleClient : BaseClient<AuthorizationClient.Builder>
{
    /// <summary>Service name.</summary>
    private const string ServiceName = "api.console";

    /// <summary>Create a new <see cref="ConsoleClient"/> using the given builder.</summary>
    public ConsoleClient(Builder builder)
        : base(builder, ServiceName)
    {
    }

    /// <summary><see cref="ConsoleClient"/> builder.</summary>
    public class Builder : ClientBuilder
    {
        /// <summary>Create a new <see cref="ConsoleClient"/> builder.</summary>
        public Builder(Config config)
            : base(config)
        {
        }

        /// <summary>Build an <see cref="ConsoleClient"/>.</summary>
        public ConsoleClient Build()
        {
            return new ConsoleClient(this);
        }
    }

    public async Task<Response<Organization>> GetOrg(
        string id,
        CancellationToken cancellationToken = default
    )
    {
        return await this.DoPost<Organization>(
            "/v1beta/platform/org/get",
            new GetOrgRequest { Id = id },
            cancellationToken: cancellationToken
        );
    }

    public async Task<Response<Organization>> UpdateOrg(
        string id,
        string name,
        CancellationToken cancellationToken = default
    )
    {
        return await this.DoPost<Organization>(
            "/v1beta/platform/org/update",
            new UpdateOrgRequest { Id = id, Name = name },
            cancellationToken: cancellationToken
        );
    }

    public async Task<Response<Project>> GetProject(
        string id,
        CancellationToken cancellationToken = default
    )
    {
        return await this.DoPost<Project>(
            "/v1beta/platform/project/get",
            new GetProjectRequest { Id = id },
            cancellationToken: cancellationToken
        );
    }

    public async Task<Response<ListProjectsResult>> ListProjects(
        ListProjectsRequest request,
        CancellationToken cancellationToken = default
    )
    {
        return await this.DoPost<ListProjectsResult>(
            "/v1beta/platform/project/list",
            request,
            cancellationToken: cancellationToken
        );
    }

    public async Task<Response<Project>> CreateProject(
        CreateProjectRequest request,
        CancellationToken cancellationToken = default
    )
    {
        return await this.DoPost<Project>(
            "/v1beta/platform/project/create",
            request,
            cancellationToken: cancellationToken
        );
    }

    public async Task<Response<Project>> UpdateProject(
        string id,
        string name,
        CancellationToken cancellationToken = default
    )
    {
        return await this.DoPost<Project>(
            "/v1beta/platform/project/update",
            new UpdateProjectRequest { Id = id, Name = name },
            cancellationToken: cancellationToken
        );
    }

    public async Task<Response<Project>> DeleteProject(
        string id,
        CancellationToken cancellationToken = default
    )
    {
        return await this.DoPost<Project>(
            "/v1beta/platform/project/delete",
            new DeleteProjectRequest { Id = id },
            cancellationToken: cancellationToken
        );
    }
}

public sealed class ManagementClient
{
    private readonly AuthorizationClient authorizationClient;
    private readonly ConsoleClient consoleClient;

    public ManagementClient(Config config)
    {
        this.authorizationClient = new AuthorizationClient.Builder(config).Build();
        this.consoleClient = new ConsoleClient.Builder(config).Build();
    }

    /// <summary>Retrieve an organization</summary>
    /// <remarks>Retrieve an organization</remarks>
    /// <operationid>api.console_post_v1beta_platform_org_get</operationid>
    /// <param name="id">An Organization Pangea ID</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    public async Task<Response<Organization>> GetOrg(
        string id,
        CancellationToken cancellationToken = default
    )
    {
        return await this.consoleClient.GetOrg(
            id,
            cancellationToken: cancellationToken
        );
    }

    /// <summary>Update an organization</summary>
    /// <remarks>Update an organization</remarks>
    /// <operationid>api.console_post_v1beta_platform_org_update</operationid>
    /// <param name="id">An Organization Pangea ID</param>
    /// <param name="name">The name of the organization</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    public async Task<Response<Organization>> UpdateOrg(
        string id,
        string name,
        CancellationToken cancellationToken = default
    )
    {
        return await this.consoleClient.UpdateOrg(
            id,
            name,
            cancellationToken: cancellationToken
        );
    }

    /// <summary>Retrieve a project</summary>
    /// <remarks>Retrieve a project</remarks>
    /// <operationid>api.console_post_v1beta_platform_project_get</operationid>
    /// <param name="id">A Project Pangea ID</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    public async Task<Response<Project>> GetProject(
        string id,
        CancellationToken cancellationToken = default
    )
    {
        return await this.consoleClient.GetProject(
            id,
            cancellationToken: cancellationToken
        );
    }

    /// <summary>List projects</summary>
    /// <remarks>List projects</remarks>
    /// <operationid>api.console_post_v1beta_platform_project_list</operationid>
    /// <param name="request">The request parameters</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    public async Task<Response<ListProjectsResult>> ListProjects(
        ListProjectsRequest request,
        CancellationToken cancellationToken = default
    )
    {
        return await this.consoleClient.ListProjects(
            request,
            cancellationToken: cancellationToken
        );
    }

    /// <summary>Create a project</summary>
    /// <remarks>Create a project</remarks>
    /// <operationid>api.console_post_v1beta_platform_project_create</operationid>
    /// <param name="request">The request parameters</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    public async Task<Response<Project>> CreateProject(
        CreateProjectRequest request,
        CancellationToken cancellationToken = default
    )
    {
        return await this.consoleClient.CreateProject(
            request,
            cancellationToken: cancellationToken
        );
    }

    /// <summary>Update a project</summary>
    /// <remarks>Update a project</remarks>
    /// <operationid>api.console_post_v1beta_platform_project_update</operationid>
    /// <param name="id">A Project Pangea ID</param>
    /// <param name="name">The name of the project</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    public async Task<Response<Project>> UpdateProject(
        string id,
        string name,
        CancellationToken cancellationToken = default
    )
    {
        return await this.consoleClient.UpdateProject(
            id,
            name,
            cancellationToken: cancellationToken
        );
    }

    /// <summary>Delete a project</summary>
    /// <remarks>Delete a project</remarks>
    /// <operationid>api.console_post_v1beta_platform_project_delete</operationid>
    /// <param name="id">A Project Pangea ID</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    public async Task<Response<Project>> DeleteProject(
        string id,
        CancellationToken cancellationToken = default
    )
    {
        return await this.consoleClient.DeleteProject(
            id,
            cancellationToken: cancellationToken
        );
    }

    /// <summary>Create a client</summary>
    /// <remarks>Create a client</remarks>
    /// <operationid>createPlatformClient</operationid>
    /// <param name="request">Request parameters</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    public async Task<AccessClientCreateInfo> CreateClient(
        CreateClientRequest request,
        CancellationToken cancellationToken = default
    )
    {
        return await this.authorizationClient.CreateClient(request, cancellationToken);
    }

    /// <summary>List platform clients</summary>
    /// <remarks>List platform clients</remarks>
    /// <operationid>listPlatformClients</operationid>
    /// <param name="request">Request parameters</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    public async Task<AccessClientListResult> ListClients(
        ListClientsRequest request,
        CancellationToken cancellationToken = default
    )
    {
        return await this.authorizationClient.ListClients(request, cancellationToken);
    }

    /// <summary>Get a platform client</summary>
    /// <remarks>Get a platform client</remarks>
    /// <operationid>getPlatformClient</operationid>
    /// <param name="clientId">A Client Pangea ID</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    public async Task<AccessClientInfo> GetClient(
        string clientId,
        CancellationToken cancellationToken = default
    )
    {
        return await this.authorizationClient.GetClient(clientId, cancellationToken);
    }

    /// <summary>Update a platform client</summary>
    /// <remarks>Update a platform client</remarks>
    /// <operationid>updatePlatformClient</operationid>
    /// <param name="clientId">A Client Pangea ID</param>
    /// <param name="options">Request parameters</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    public async Task<AccessClientInfo> UpdateClient(
        string clientId,
        UpdateClientRequest options,
        CancellationToken cancellationToken = default
    )
    {
        return await this.authorizationClient.UpdateClient(clientId, options, cancellationToken);
    }

    /// <summary>Delete a platform client</summary>
    /// <remarks>Delete a platform client</remarks>
    /// <operationid>deletePlatformClient</operationid>
    /// <param name="clientId">A Client Pangea ID</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    public async Task DeleteClient(
        string clientId,
        CancellationToken cancellationToken = default
    )
    {
        await this.authorizationClient.DeleteClient(clientId, cancellationToken);
    }

    /// <summary>Create client secret</summary>
    /// <remarks>Create client secret</remarks>
    /// <operationid>createClientSecret</operationid>
    /// <param name="request">Request parameters</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    public async Task<AccessClientSecretInfo> CreateClientSecret(
        CreateClientSecretRequest request,
        CancellationToken cancellationToken = default
    )
    {
        return await this.authorizationClient.CreateClientSecret(request, cancellationToken);
    }

    /// <summary>List client secret metadata</summary>
    /// <remarks>List client secret metadata</remarks>
    /// <operationid>listClientSecretMetadata</operationid>
    /// <param name="request">Request parameters</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    public async Task<AccessClientSecretInfoListResult> ListClientSecretMetadata(
        ListClientSecretMetadataRequest request,
        CancellationToken cancellationToken = default
    )
    {
        return await this.authorizationClient.ListClientSecretMetadata(request, cancellationToken);
    }

    /// <summary>Revoke client secret</summary>
    /// <remarks>Revoke client secret</remarks>
    /// <operationid>revokeClientSecret</operationid>
    /// <param name="id">Client ID</param>
    /// <param name="clientSecretId">Client secret ID to revoke</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    public async Task RevokeClientSecret(
        string id,
        string clientSecretId,
        CancellationToken cancellationToken = default
    )
    {
        await this.authorizationClient.RevokeClientSecret(id, clientSecretId, cancellationToken);
    }

    /// <summary>Update client secret</summary>
    /// <remarks>Update client secret</remarks>
    /// <operationid>updateClientSecret</operationid>
    /// <param name="id">Client ID</param>
    /// <param name="clientSecretId">Client secret ID to update</param>
    /// <param name="options">Request parameters</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    public async Task<AccessClientSecretInfo> UpdateClientSecret(
        string id,
        string clientSecretId,
        UpdateClientSecretRequest options,
        CancellationToken cancellationToken = default
    )
    {
        return await this.authorizationClient.UpdateClientSecret(id, clientSecretId, options, cancellationToken);
    }

    /// <summary>List client roles</summary>
    /// <remarks>List client roles</remarks>
    /// <operationid>listClientRoles</operationid>
    /// <param name="id">Client ID</param>
    /// <param name="request">Request parameters</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    public async Task<AccessRolesListResult> ListClientRoles(
        string id,
        ListClientRolesRequest request,
        CancellationToken cancellationToken = default
    )
    {
        return await this.authorizationClient.ListClientRoles(id, request, cancellationToken);
    }

    /// <summary>Grant client access</summary>
    /// <remarks>Grant client access</remarks>
    /// <operationid>grantClientRoles</operationid>
    /// <param name="id">Client ID</param>
    /// <param name="request">Request parameters</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    public async Task GrantClientAccess(
        string id,
        GrantClientAccessRequest request,
        CancellationToken cancellationToken = default
    )
    {
        await this.authorizationClient.GrantClientAccess(id, request, cancellationToken);
    }

    /// <summary>Revoke client access</summary>
    /// <remarks>Revoke client access</remarks>
    /// <operationid>revokeClientRoles</operationid>
    /// <param name="id">Client ID</param>
    /// <param name="request">Request parameters</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    public async Task RevokeClientAccess(
        string id,
        RevokeClientAccessRequest request,
        CancellationToken cancellationToken = default
    )
    {
        await this.authorizationClient.RevokeClientAccess(id, request, cancellationToken);
    }
}
