using PangeaCyber.Net.Exceptions;
using PangeaCyber.Net.Vault.Models;
using PangeaCyber.Net.Vault.Requests;
using PangeaCyber.Net.Vault.Results;

namespace PangeaCyber.Net.Vault
{
    /// <summary>Vault client.</summary>
    /// <remarks>Vault</remarks>
    /// <example>
    /// <code>
    /// var config = new Config("pangea_token", "pangea_domain");
    /// var builder = new VaultClient.Builder(config);
    /// var client = builder.Build();
    /// </code>
    /// </example>
    public class VaultClient : BaseClient<VaultClient.Builder>
    {
        /// <summary>Service name.</summary>
        public static string ServiceName { get; } = "vault";

        /// <summary>Create a new <see cref="VaultClient"/> using the given builder.</summary>
        /// <param name="builder">Vault client builder.</param>
        public VaultClient(Builder builder) : base(builder, ServiceName)
        {
        }

        /// <summary><see cref="VaultClient"/> builder.</summary>
        public class Builder : ClientBuilder
        {
            /// <summary>Create a new <see cref="VaultClient"/> builder.</summary>
            /// <param name="config">Configuration.</param>
            public Builder(Config config) : base(config)
            {
            }

            /// <summary>Build a <see cref="VaultClient"/>.</summary>
            public VaultClient Build()
            {
                return new VaultClient(this);
            }
        }

        /// <kind>method</kind>
        /// <summary>Change the state of a specific version of a secret or key.</summary>
        /// <remarks>Change state</remarks>
        /// <operationid>vault_post_v2_state_change</operationid>
        /// <param name="id" type="string">The item ID</param>
        /// <param name="version" type="int">The item version</param>
        /// <param name="state" type="Pangea.Net.Vault.Models.ItemVersionState">The new state of the item version</param>
        /// <returns>Response&lt;StateChangeResult&gt;</returns>
        /// <exception cref="PangeaException">Thrown if an error occurs during the operation.</exception>
        /// <exception cref="PangeaAPIException">Thrown if the API returns an error response.</exception>
        /// <example>
        /// <code>
        /// var response = await client.StateChange(
        ///     "pvi_p6g5i3gtbvqvc3u6zugab6qs6r63tqf5",
        ///     1,
        ///     ItemVersionState.Deactivated
        /// );
        /// </code>
        /// </example>
        public async Task<Response<StateChangeResult>> StateChange(string id, int version, ItemVersionState state)
        {
            return await DoPost<StateChangeResult>("/v2beta/state/change", new StateChangeRequest(id, version, state));
        }

        /// <kind>method</kind>
        /// <summary>Delete a secret, key or folder.</summary>
        /// <remarks>Delete</remarks>
        /// <operationid>vault_post_v2_delete</operationid>
        /// <param name="id" type="string">The item ID</param>
        /// <returns>Response&lt;DeleteResult&gt;</returns>
        /// <exception cref="PangeaException">Thrown if an error occurs during the operation.</exception>
        /// <exception cref="PangeaAPIException">Thrown if the API returns an error response.</exception>
        /// <example>
        /// <code>
        /// await client.Delete("pvi_p6g5i3gtbvqvc3u6zugab6qs6r63tqf5");
        /// </code>
        /// </example>
        public async Task<Response<DeleteResult>> Delete(string id)
        {
            return await DoPost<DeleteResult>("/v2beta/delete", new DeleteRequest(id));
        }

        /// <kind>method</kind>
        /// <summary>
        /// Retrieve a secret, key or folder, and any associated information.
        /// </summary>
        /// <remarks>Retrieve</remarks>
        /// <operationid>vault_post_v2_get</operationid>
        /// <param name="request" type="PangeaCyber.Net.Vault.Requests.GetRequest">The request to the '/get' endpoint.</param>
        /// <returns>The response containing the retrieved information.</returns>
        /// <exception cref="PangeaException">Thrown if an error occurs during the operation.</exception>
        /// <exception cref="PangeaAPIException">Thrown if the API returns an error response.</exception>
        /// <example>
        /// <code>
        /// var request = new GetRequest
        ///     ("pvi_p6g5i3gtbvqvc3u6zugab6qs6r63tqf5")
        ///     ;
        /// var response = await client.Get(request);
        /// </code>
        /// </example>
        public async Task<Response<GetResult>> Get(GetRequest request)
        {
            return await DoPost<GetResult>("/v2beta/get", request);
        }

        /// <kind>method</kind>
        /// <summary>
        /// Retrieve a list of secrets, keys and folders.
        /// </summary>
        /// <remarks>Get Bulk</remarks>
        /// <operationid>vault_post_v2_get_bulk</operationid>
        /// <param name="request" type="PangeaCyber.Net.Vault.Requests.GetBulkRequest">The request to the '/get_bulk' endpoint.</param>
        /// <returns>The response containing the retrieved information.</returns>
        /// <exception cref="PangeaException">Thrown if an error occurs during the operation.</exception>
        /// <exception cref="PangeaAPIException">Thrown if the API returns an error response.</exception>
        /// <example>
        /// <code>
        /// TODO:
        /// </code>
        /// </example>
        public async Task<Response<GetBulkResult>> GetBulk(GetBulkRequest request)
        {
            return await DoPost<GetBulkResult>("/v2beta/get_bulk", request);
        }

        /// <kind>method</kind>
        /// <summary>
        /// Retrieve a list of secrets, keys and folders, and their associated information.
        /// </summary>
        /// <remarks>List</remarks>
        /// <operationid>vault_post_v2_list</operationid>
        /// <param name="request" type="PangeaCyber.Net.Vault.Requests.ListRequest">The request parameters to send to the '/list' endpoint.</param>
        /// <returns>The response containing the list of items and their information.</returns>
        /// <exception cref="PangeaException">Thrown if an error occurs during the operation.</exception>
        /// <exception cref="PangeaAPIException">Thrown if the API returns an error response.</exception>
        /// <example>
        /// <code>
        /// var request = new ListRequest();
        /// var response = await client.List(request);
        /// </code>
        /// </example>
        public async Task<Response<ListResult>> List(ListRequest request)
        {
            return await DoPost<ListResult>("/v2beta/list", request);
        }

        /// <kind>method</kind>
        /// <summary>
        /// Update information associated with a secret, key or folder.
        /// </summary>
        /// <remarks>Update</remarks>
        /// <operationid>vault_post_v2_update</operationid>
        /// <param name="request" type="PangeaCyber.Net.Vault.Requests.UpdateRequest">The request parameters to send to the update endpoint.</param>
        /// <returns>The response containing the updated information.</returns>
        /// <exception cref="PangeaException">Thrown if an error occurs during the operation.</exception>
        /// <exception cref="PangeaAPIException">Thrown if the API returns an error response.</exception>
        /// <example>
        /// <code>
        /// var request = new UpdateRequest
        ///     ("pvi_p6g5i3gtbvqvc3u6zugab6qs6r63tqf5")
        ///     .WithFolder("/personal")
        ///     ;
        /// var response = await client.Update(request);
        /// </code>
        /// </example>
        public async Task<Response<UpdateResult>> Update(UpdateRequest request)
        {
            return await DoPost<UpdateResult>("/v2beta/update", request);
        }

        /// <kind>method</kind>
        /// <summary>
        /// Store a secret in the vault service.
        /// </summary>
        /// <remarks>Secret store</remarks>
        /// <operationid>vault_post_v2_secret_store 1</operationid>
        /// <param name="request" type="PangeaCyber.Net.Vault.Requests.SecretStoreRequest">The request parameters to send to the '/secret/store' endpoint.</param>
        /// <returns>The response containing the stored secret information.</returns>
        /// <exception cref="PangeaException">Thrown if an error occurs during the operation.</exception>
        /// <exception cref="PangeaAPIException">Thrown if the API returns an error response.</exception>
        /// <example>
        /// <code>
        /// var request = new SecretStoreRequest
        ///     ("12sdfgs4543qv@#%$casd", "my-very-secret-secret")
        ///     ;
        /// var response = await client.SecretStore(request);
        /// </code>
        /// </example>
        public async Task<Response<SecretStoreResult>> SecretStore(SecretStoreRequest request)
        {
            return await DoPost<SecretStoreResult>("/v2beta/secret/store", request);
        }

        /// <kind>method</kind>
        /// <summary>
        /// Rotate a secret in the vault service.
        /// </summary>
        /// <remarks>Secret rotate</remarks>
        /// <operationid>vault_post_v2_secret_rotate 1</operationid>
        /// <param name="request" type="PangeaCyber.Net.Vault.Requests.SecretRotateRequest">The secret rotate request.</param>
        /// <returns>The response containing the rotated secret information.</returns>
        /// <exception cref="PangeaException">Thrown if an error occurs during the operation.</exception>
        /// <exception cref="PangeaAPIException">Thrown if the API returns an error response.</exception>
        /// <example>
        /// <code>
        /// var request = new SecretRotateRequest(
        ///         "pvi_p6g5i3gtbvqvc3u6zugab6qs6r63tqf5",
        ///         "12sdfgs4543qv@#%$casd")
        ///     .WithRotationState(ItemVersionState.Deactivated)
        ///     ;
        /// var response = await client.SecretRotate(request);
        /// </code>
        /// </example>
        public async Task<Response<SecretRotateResult>> SecretRotate(SecretRotateRequest request)
        {
            return await DoPost<SecretRotateResult>("/v2beta/secret/rotate", request);
        }

        /// <kind>method</kind>
        /// <summary>
        /// Generate a symmetric key.
        /// </summary>
        /// <remarks>Symmetric generate</remarks>
        /// <operationid>vault_post_v2_key_generate 2</operationid>
        /// <param name="request" type="PangeaCyber.Net.Vault.Requests.SymmetricGenerateRequest">The request parameters to send to the '/key/generate' endpoint.</param>
        /// <returns>The response containing the generated symmetric key information.</returns>
        /// <exception cref="PangeaException">Thrown if an error occurs during the operation.</exception>
        /// <exception cref="PangeaAPIException">Thrown if the API returns an error response.</exception>
        /// <example>
        /// <code>
        /// SymmetricGenerateRequest request = new SymmetricGenerateRequest
        ///     (
        ///         SymmetricAlgorithm.AES128_CFB,
        ///         KeyPurpose.Encryption,
        ///         "my-very-secret-secret")
        ///     ;
        /// var response = await client.SymmetricGenerate(request);
        /// </code>
        /// </example>
        public async Task<Response<SymmetricGenerateResult>> SymmetricGenerate(SymmetricGenerateRequest request)
        {
            return await DoPost<SymmetricGenerateResult>("/v2beta/key/generate", request);
        }

        /// <kind>method</kind>
        /// <summary>
        /// Generate an asymmetric key.
        /// </summary>
        /// <remarks>Asymmetric generate</remarks>
        /// <operationid>vault_post_v2_key_generate 1</operationid>
        /// <param name="request" type="PangeaCyber.Net.Vault.Requests.AsymmetricGenerateRequest">The request parameters to send to the '/key/generate' endpoint.</param>
        /// <returns>The response containing the generated asymmetric key information.</returns>
        /// <exception cref="PangeaException">Thrown if an error occurs during the operation.</exception>
        /// <exception cref="PangeaAPIException">Thrown if the API returns an error response.</exception>
        /// <example>
        /// <code>
        /// AsymmetricGenerateRequest request = new AsymmetricGenerateRequest
        ///     (
        ///         AsymmetricAlgorithm.ED25519,
        ///         KeyPurpose.Signing,
        ///         "my-very-secret-secret")
        ///     ;
        /// var response = await client.AsymmetricGenerate(request);
        /// </code>
        /// </example>
        public async Task<Response<AsymmetricGenerateResult>> AsymmetricGenerate(AsymmetricGenerateRequest request)
        {
            return await DoPost<AsymmetricGenerateResult>("/v2beta/key/generate", request);
        }

        /// <kind>method</kind>
        /// <summary>
        /// Import an asymmetric key.
        /// </summary>
        /// <remarks>Asymmetric store</remarks>
        /// <operationid>vault_post_v2_key_store 1</operationid>
        /// <param name="request" type="PangeaCyber.Net.Vault.Requests.AsymmetricStoreRequest">The request parameters to send to the '/key/store' endpoint.</param>
        /// <returns>The response containing the stored asymmetric key information.</returns>
        /// <exception cref="PangeaException">Thrown if an error occurs during the operation.</exception>
        /// <exception cref="PangeaAPIException">Thrown if the API returns an error response.</exception>
        /// <example>
        /// <code>
        /// AsymmetricStoreRequest request = new AsymmetricStoreRequest
        ///     (
        ///         "encoded private key",
        ///         "-----BEGIN PUBLIC KEY-----\nMCowBQYDK2VwAyEA8s5JopbEPGBylPBcMK+L5PqHMqPJW/5KYPgBHzZGncc=\n-----END PUBLIC KEY-----",
        ///         AsymmetricAlgorithm.RSA4096_OAEP_SHA256,
        ///         KeyPurpose.Signing,
        ///         "my-very-secret-secret")
        ///     ;
        /// var response = await client.AsymmetricStore(request);
        /// </code>
        /// </example>
        public async Task<Response<AsymmetricStoreResult>> AsymmetricStore(AsymmetricStoreRequest request)
        {
            return await DoPost<AsymmetricStoreResult>("/v2beta/key/store", request);
        }

        /// <kind>method</kind>
        /// <summary>
        /// Import a symmetric key.
        /// </summary>
        /// <remarks>Symmetric store</remarks>
        /// <operationid>vault_post_v2_key_store 2</operationid>
        /// <param name="request" type="PangeaCyber.Net.Vault.Requests.SymmetricStoreRequest">The request parameters to send to the '/key/store' endpoint.</param>
        /// <returns>The response containing the stored symmetric key information.</returns>
        /// <exception cref="PangeaException">Thrown if an error occurs during the operation.</exception>
        /// <exception cref="PangeaAPIException">Thrown if the API returns an error response.</exception>
        /// <example>
        /// <code>
        /// SymmetricStoreRequest request = new SymmetricStoreRequest
        ///     (
        ///         "lJkk0gCLux+Q+rPNqLPEYw==",
        ///         SymmetricAlgorithm.AES128_CFB,
        ///         KeyPurpose.Encryption,
        ///         "my-very-secret-secret")
        ///     ;
        /// var response = await client.SymmetricStore(request);
        /// </code>
        /// </example>
        public async Task<Response<SymmetricStoreResult>> SymmetricStore(SymmetricStoreRequest request)
        {
            return await DoPost<SymmetricStoreResult>("/v2beta/key/store", request);
        }

        /// <kind>method</kind>
        /// <summary>
        /// Manually rotate a symmetric or asymmetric key.
        /// </summary>
        /// <remarks>Rotate</remarks>
        /// <operationid>vault_post_v2_key_rotate</operationid>
        /// <param name="request" type="PangeaCyber.Net.Vault.Requests.KeyRotateRequest">The request parameters to send to the '/key/rotate' endpoint.</param>
        /// <returns>The response containing the rotated key information.</returns>
        /// <exception cref="PangeaException">Thrown if an error occurs during the operation.</exception>
        /// <exception cref="PangeaAPIException">Thrown if the API returns an error response.</exception>
        /// <example>
        /// <code>
        /// KeyRotateRequest request = new KeyRotateRequest
        ///     (
        ///         "pvi_p6g5i3gtbvqvc3u6zugab6qs6r63tqf5",
        ///         ItemVersionState.Deactivated)
        ///     .WithEncodedSymmetricKey("lJkk0gCLux+Q+rPNqLPEYw==")
        ///     ;
        /// var response = await client.KeyRotate(request);
        /// </code>
        /// </example>
        public async Task<Response<KeyRotateResult>> KeyRotate(KeyRotateRequest request)
        {
            return await DoPost<KeyRotateResult>("/v2beta/key/rotate", request);
        }

        /// <kind>method</kind>
        /// <summary>
        /// Encrypt a message using a key.
        /// </summary>
        /// <remarks>Encrypt</remarks>
        /// <operationid>vault_post_v2_key_encrypt</operationid>
        /// <param name="request" type="PangeaCyber.Net.Vault.Requests.EncryptRequest">The request parameters to send to the '/key/encrypt' endpoint.</param>
        /// <returns>The response containing the encrypted message.</returns>
        /// <exception cref="PangeaException">Thrown if an error occurs during the operation.</exception>
        /// <exception cref="PangeaAPIException">Thrown if the API returns an error response.</exception>
        /// <example>
        /// <code>
        /// EncryptRequest request = new EncryptRequest
        ///     (
        ///         "pvi_p6g5i3gtbvqvc3u6zugab6qs6r63tqf5",
        ///         "lJkk0gCLux+Q+rPNqLPEYw==")
        ///     .WithVersion(2)
        ///     ;
        /// var response = await client.Encrypt(request);
        /// </code>
        /// </example>
        public async Task<Response<EncryptResult>> Encrypt(EncryptRequest request)
        {
            return await DoPost<EncryptResult>("/v2beta/encrypt", request);
        }

        /// <kind>method</kind>
        /// <summary>
        /// Decrypt a message using a key.
        /// </summary>
        /// <remarks>Decrypt</remarks>
        /// <operationid>vault_post_v2_key_decrypt</operationid>
        /// <param name="request" type="PangeaCyber.Net.Vault.Requests.DecryptRequest">The request parameters to send to the '/key/decrypt' endpoint.</param>
        /// <returns>The response containing the decrypted message.</returns>
        /// <exception cref="PangeaException">Thrown if an error occurs during the operation.</exception>
        /// <exception cref="PangeaAPIException">Thrown if the API returns an error response.</exception>
        /// <example>
        /// <code>
        /// DecryptRequest request = new DecryptRequest
        ///     (
        ///         "pvi_p6g5i3gtbvqvc3u6zugab6qs6r63tqf5",
        ///         "lJkk0gCLux+Q+rPNqLPEYw==")
        ///     .WithVersion(2)
        ///     ;
        /// var response = await client.Decrypt(request);
        /// </code>
        /// </example>
        public async Task<Response<DecryptResult>> Decrypt(DecryptRequest request)
        {
            return await DoPost<DecryptResult>("/v2beta/decrypt", request);
        }

        /// <kind>method</kind>
        /// <summary>
        /// Sign a message using a key.
        /// </summary>
        /// <remarks>Sign</remarks>
        /// <operationid>vault_post_v2_key_sign</operationid>
        /// <param name="request" type="PangeaCyber.Net.Vault.Requests.SignRequest">The request parameters to send to the '/key/sign' endpoint.</param>
        /// <returns>The response containing the signed message.</returns>
        /// <exception cref="PangeaException">Thrown if an error occurs during the operation.</exception>
        /// <exception cref="PangeaAPIException">Thrown if the API returns an error response.</exception>
        /// <example>
        /// <code>
        /// SignRequest request = new SignRequest
        ///     (
        ///         "pvi_p6g5i3gtbvqvc3u6zugab6qs6r63tqf5",
        ///         "lJkk0gCLux+Q+rPNqLPEYw==")
        ///     ;
        /// var response = await client.Sign(request);
        /// </code>
        /// </example>
        public async Task<Response<SignResult>> Sign(SignRequest request)
        {
            return await DoPost<SignResult>("/v2beta/sign", request);
        }

        /// <kind>method</kind>
        /// <summary>
        /// Sign a JSON Web Token (JWT) using a key.
        /// </summary>
        /// <remarks>JWT Sign</remarks>
        /// <operationid>vault_post_v2_key_sign_jwt</operationid>
        /// <param name="id" type="string">The key ID to sign the payload.</param>
        /// <param name="payload" type="string">The JWT payload (in JSON).</param>
        /// <returns>The response containing the signed JWT.</returns>
        /// <exception cref="PangeaException">Thrown if an error occurs during the operation.</exception>
        /// <exception cref="PangeaAPIException">Thrown if the API returns an error response.</exception>
        /// <example>
        /// <code>
        /// string payload = "{\"sub\": \"1234567890\",\"name\": \"John Doe\",\"admin\": true}";
        /// var response = await client
        ///     .JWTSign("pvi_p6g5i3gtbvqvc3u6zugab6qs6r63tqf5", payload);
        /// </code>
        /// </example>
        public async Task<Response<JWTSignResult>> JWTSign(string id, string payload)
        {
            return await DoPost<JWTSignResult>("/v2beta/jwt/sign", new JWTSignRequest(id, payload));
        }

        /// <kind>method</kind>
        /// <summary>
        /// Verify a signature using a key.
        /// </summary>
        /// <remarks>Verify</remarks>
        /// <operationid>vault_post_v2_key_verify</operationid>
        /// <param name="request" type="PangeaCyber.Net.Vault.Requests.VerifyRequest">The request containing the key ID, message, and signature to verify.</param>
        /// <returns>The response indicating whether the signature is valid or not.</returns>
        /// <exception cref="PangeaException">Thrown if an error occurs during the operation.</exception>
        /// <exception cref="PangeaAPIException">Thrown if the API returns an error response.</exception>
        /// <example>
        /// <code>
        /// var request = new VerifyRequest
        ///     (
        ///         "pvi_p6g5i3gtbvqvc3u6zugab6qs6r63tqf5",
        ///         "data2verify",
        ///         "signature")
        ///     ;
        /// var response = await client.Verify(request);
        /// </code>
        /// </example>
        public async Task<Response<VerifyResult>> Verify(VerifyRequest request)
        {
            return await DoPost<VerifyResult>("/v2beta/verify", request);
        }

        /// <kind>method</kind>
        /// <summary>
        /// Verify the signature of a JSON Web Token (JWT).
        /// </summary>
        /// <remarks>JWT Verify</remarks>
        /// <operationid>vault_post_v2_key_verify_jwt</operationid>
        /// <param name="request" type="PangeaCyber.Net.Vault.Requests.JWTVerifyRequest">The request containing the JWT signature to verify.</param>
        /// <returns>The response containing the verification result.</returns>
        /// <exception cref="PangeaException">Thrown if an error occurs during the operation.</exception>
        /// <exception cref="PangeaAPIException">Thrown if the API returns an error response.</exception>
        /// <example>
        /// <code>
        /// var request = new JWTVerifyRequest
        ///     ("ewogICJhbGciO...")
        ///     ;
        /// var verifyResponse = await client.JWTVerify(request);
        /// </code>
        /// </example>
        public async Task<Response<JWTVerifyResult>> JWTVerify(JWTVerifyRequest request)
        {
            return await DoPost<JWTVerifyResult>("/v2beta/jwt/verify", request);
        }

        /// <kind>method</kind>
        /// <summary>
        /// Retrieve a key in JWK format.
        /// </summary>
        /// <remarks>JWT Retrieve</remarks>
        /// <operationid>vault_post_v2_get_jwt</operationid>
        /// <param name="request" type="PangeaCyber.Net.Vault.Requests.JWKGetRequest">The request containing the item ID and version to retrieve.</param>
        /// <returns>The response containing the JWK key.</returns>
        /// <exception cref="PangeaException">Thrown if an error occurs during the operation.</exception>
        /// <exception cref="PangeaAPIException">Thrown if the API returns an error response.</exception>
        /// <example>
        /// <code>
        /// var request = new JWKGetRequest
        ///     ("jwkid")
        ///     .WithVersion("2")
        ///     ;
        /// var response = await client.JWKGet(request)
        /// </code>
        /// </example>
        public async Task<Response<JWKGetResult>> JWKGet(JWKGetRequest request)
        {
            return await DoPost<JWKGetResult>("/v2beta/jwk/get", request);
        }

        /// <kind>method</kind>
        /// <summary>
        /// Creates a folder.
        /// </summary>
        /// <remarks>Create</remarks>
        /// <operationid>vault_post_v2_folder_create</operationid>
        /// <param name="request" type="PangeaCyber.Net.Vault.Requests.FolderCreateRequest">The request parameters to send to the '/folder/create' endpoint.</param>
        /// <returns>The response containing the created folder information.</returns>
        /// <exception cref="PangeaException">Thrown if an error occurs during the operation.</exception>
        /// <exception cref="PangeaAPIException">Thrown if the API returns an error response.</exception>
        /// <example>
        /// <code>
        /// var request = new FolderCreateRequest
        ///     (
        ///         "folder_name",
        ///         "parent/folder/name")
        ///     ;
        /// var response = await client.FolderCreate(request);
        /// </code>
        /// </example>
        public async Task<Response<FolderCreateResult>> FolderCreate(FolderCreateRequest request)
        {
            return await DoPost<FolderCreateResult>("/v2beta/folder/create", request);
        }

        /// <kind>method</kind>
        /// <summary>Encrypt parts of a JSON object.</summary>
        /// <remarks>Encrypt structured</remarks>
        /// <operationid>vault_post_v2_key_encrypt_structured</operationid>
        /// <typeparam name="T">Structured data type.</typeparam>
        /// <param name="request">Request parameters.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns>Encrypted result.</returns>
        /// <exception cref="PangeaException">Thrown if an error occurs during the operation.</exception>
        /// <exception cref="PangeaAPIException">Thrown if the API returns an error response.</exception>
        /// <example>
        /// <code>
        /// var data = new SomeModel { Name = "...", Occupation = "..." };
        /// var request = new EncryptStructuredRequest&lt;SomeModel&gt;(encryptionKeyId, data, "$.name");
        /// var response = await client.EncryptStructured(request);
        /// </code>
        /// </example>
        public async Task<Response<EncryptStructuredResult<T>>> EncryptStructured<T>(
            EncryptStructuredRequest<T> request,
            CancellationToken cancellationToken = default
        )
        {
            return await DoPost<EncryptStructuredResult<T>>(
                "/v2beta/encrypt_structured",
                request,
                cancellationToken: cancellationToken
            );
        }

        /// <kind>method</kind>
        /// <summary>Decrypt parts of a JSON object.</summary>
        /// <remarks>Decrypt structured</remarks>
        /// <operationid>vault_post_v2_key_decrypt_structured</operationid>
        /// <typeparam name="T">Structured data type.</typeparam>
        /// <param name="request">Request parameters.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns>Decrypted result.</returns>
        /// <exception cref="PangeaException">Thrown if an error occurs during the operation.</exception>
        /// <exception cref="PangeaAPIException">Thrown if the API returns an error response.</exception>
        /// <example>
        /// <code>
        /// var data = new SomeModel { Name = "...", Occupation = "..." };
        /// var request = new EncryptStructuredRequest&lt;SomeModel&gt;(encryptionKeyId, data, "$.name");
        /// var response = await client.DecryptStructured(request);
        /// </code>
        /// </example>
        public async Task<Response<EncryptStructuredResult<T>>> DecryptStructured<T>(
            EncryptStructuredRequest<T> request,
            CancellationToken cancellationToken = default
        )
        {
            return await DoPost<EncryptStructuredResult<T>>(
                "/v2beta/decrypt_structured",
                request,
                cancellationToken: cancellationToken
            );
        }

        /// <summary>Encrypt using a format-preserving algorithm (FPE).</summary>
        /// <remarks>Encrypt transform</remarks>
        /// <operationid>vault_post_v2_key_encrypt_transform</operationid>
        /// <param name="request">Request parameters.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns>Encrypted result.</returns>
        /// <exception cref="PangeaException">Thrown if an error occurs during the operation.</exception>
        /// <exception cref="PangeaAPIException">Thrown if the API returns an error response.</exception>
        /// <example>
        /// <code>
        /// var request = new EncryptTransformRequest
        /// {
        ///     ID = "pvi_[...]",
        ///     PlainText = "123-4567-8901",
        ///     Tweak = "MTIzMTIzMT==",
        ///     Alphabet = TransformAlphabet.ALPHANUMERIC
        /// };
        /// var encrypted = await client.EncryptTransform(request);
        /// </code>
        /// </example>
        public async Task<Response<EncryptTransformResult>> EncryptTransform(
            EncryptTransformRequest request,
            CancellationToken cancellationToken = default
        )
        {
            return await DoPost<EncryptTransformResult>(
                "/v2beta/encrypt_transform",
                request,
                cancellationToken: cancellationToken
            );
        }

        /// <summary>Decrypt using a format-preserving algorithm (FPE).</summary>
        /// <remarks>Decrypt transform</remarks>
        /// <operationid>vault_post_v2_key_decrypt_transform</operationid>
        /// <param name="request">Request parameters.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns>Decrypted result.</returns>
        /// <exception cref="PangeaException">Thrown if an error occurs during the operation.</exception>
        /// <exception cref="PangeaAPIException">Thrown if the API returns an error response.</exception>
        /// <example>
        /// <code>
        /// var request = new DecryptTransformRequest
        /// {
        ///     ID = "pvi_[...]",
        ///     CipherText = "123-4567-8901",
        ///     Tweak = "MTIzMTIzMT==",
        ///     Alphabet = TransformAlphabet.ALPHANUMERIC
        /// };
        /// var decrypted = await client.DecryptTransform(decryptRequest);
        /// </code>
        /// </example>
        public async Task<Response<DecryptTransformResult>> DecryptTransform(
            DecryptTransformRequest request,
            CancellationToken cancellationToken = default
        )
        {
            return await DoPost<DecryptTransformResult>(
                "/v2beta/decrypt_transform",
                request,
                cancellationToken: cancellationToken
            );
        }

        /// <summary>Export a symmetric or asymmetric key.</summary>
        /// <remarks>Export</remarks>
        /// <operationid>vault_post_v2_export</operationid>
        /// <param name="request">Request parameters.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns>Exported result.</returns>
        /// <exception cref="PangeaException">Thrown if an error occurs during the operation.</exception>
        /// <exception cref="PangeaAPIException">Thrown if the API returns an error response.</exception>
        /// <example>
        /// <code>
        /// // Generate an exportable key.
        /// var generateRequest = new AsymmetricGenerateRequest(
        ///     AsymmetricAlgorithm.RSA4096_PSS_SHA512,
        ///     KeyPurpose.Encryption,
        ///     "a-name-for-the-key"
        /// ).WithExportable(true);
        /// var generated = await client.AsymmetricGenerate(generateRequest);
        /// var key = generated.Result.ID;
        ///
        /// // Then it can be exported whenever needed.
        /// var exported = await client.Export(new ExportRequest(id: key));
        /// </code>
        /// </example>
        public async Task<Response<ExportResult>> Export(
            ExportRequest request,
            CancellationToken cancellationToken = default
        )
        {
            return await DoPost<ExportResult>(
                "/v2beta/export",
                request,
                cancellationToken: cancellationToken
            );
        }
    }
}
