using PangeaCyber.Net.Exceptions;
using PangeaCyber.Net.Vault.Models;
using PangeaCyber.Net.Vault.Requests;
using PangeaCyber.Net.Vault.Results;

namespace PangeaCyber.Net.Vault
{
    /// <kind>class</kind>
    /// <summary>Vault Client</summary>
    public class VaultClient : BaseClient<VaultClient.Builder>
    {
        /// <summary>Service name.</summary>
        public static string ServiceName { get; } = "vault";

        /// <summary>Constructor</summary>
        /// <param name="builder">Vault client builder.</param>
        public VaultClient(Builder builder) : base(builder, ServiceName)
        {
        }

        /// <summary>Vault client builder.</summary>
        public class Builder : ClientBuilder
        {
            /// <summary>Constructor</summary>
            /// <param name="config">Configuration.</param>
            public Builder(Config config) : base(config)
            {
            }

            /// <summary>Build a new Vault client.</summary>
            public VaultClient Build()
            {
                return new VaultClient(this);
            }
        }

        /// <kind>method</kind>
        /// <summary>Change the state of a specific version of a secret or key.</summary>
        /// <remarks>Change state</remarks>
        /// <operationid>vault_post_v1_state_change</operationid>
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
            return await DoPost<StateChangeResult>("/v1/state/change", new StateChangeRequest.Builder(id, version, state).Build());
        }

        /// <kind>method</kind>
        /// <summary>Delete a secret, key or folder.</summary>
        /// <remarks>Delete</remarks>
        /// <operationid>vault_post_v1_delete</operationid>
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
            return await DoPost<DeleteResult>("/v1/delete", new DeleteRequest.Builder(id).Build());
        }

        /// <kind>method</kind>
        /// <summary>
        /// Retrieve a secret, key or folder, and any associated information.
        /// </summary>
        /// <remarks>Retrieve</remarks>
        /// <operationid>vault_post_v1_get</operationid>
        /// <param name="request" type="PangeaCyber.Net.Vault.Requests.GetRequest">The request to the '/get' endpoint.</param>
        /// <returns>The response containing the retrieved information.</returns>
        /// <exception cref="PangeaException">Thrown if an error occurs during the operation.</exception>
        /// <exception cref="PangeaAPIException">Thrown if the API returns an error response.</exception>
        /// <example>
        /// <code>
        /// var request = new GetRequest
        ///     .Builder("pvi_p6g5i3gtbvqvc3u6zugab6qs6r63tqf5")
        ///     .Build();
        /// var response = await client.Get(request);
        /// </code>
        /// </example>
        public async Task<Response<GetResult>> Get(GetRequest request)
        {
            return await DoPost<GetResult>("/v1/get", request);
        }

        /// <kind>method</kind>
        /// <summary>
        /// Retrieve a list of secrets, keys and folders, and their associated information.
        /// </summary>
        /// <remarks>List</remarks>
        /// <operationid>vault_post_v1_list</operationid>
        /// <param name="request" type="PangeaCyber.Net.Vault.Requests.ListRequest">The request parameters to send to the '/list' endpoint.</param>
        /// <returns>The response containing the list of items and their information.</returns>
        /// <exception cref="PangeaException">Thrown if an error occurs during the operation.</exception>
        /// <exception cref="PangeaAPIException">Thrown if the API returns an error response.</exception>
        /// <example>
        /// <code>
        /// var request = new ListRequest.Builder().Build();
        /// var response = await client.List(request);
        /// </code>
        /// </example>
        public async Task<Response<ListResult>> List(ListRequest request)
        {
            return await DoPost<ListResult>("/v1/list", request);
        }

        /// <kind>method</kind>
        /// <summary>
        /// Update information associated with a secret, key or folder.
        /// </summary>
        /// <remarks>Update</remarks>
        /// <operationid>vault_post_v1_update</operationid>
        /// <param name="request" type="PangeaCyber.Net.Vault.Requests.UpdateRequest">The request parameters to send to the update endpoint.</param>
        /// <returns>The response containing the updated information.</returns>
        /// <exception cref="PangeaException">Thrown if an error occurs during the operation.</exception>
        /// <exception cref="PangeaAPIException">Thrown if the API returns an error response.</exception>
        /// <example>
        /// <code>
        /// var request = new UpdateRequest
        ///     .Builder("pvi_p6g5i3gtbvqvc3u6zugab6qs6r63tqf5")
        ///     .WithFolder("/personal")
        ///     .Build();
        /// var response = await client.Update(request);
        /// </code>
        /// </example>
        public async Task<Response<UpdateResult>> Update(UpdateRequest request)
        {
            return await DoPost<UpdateResult>("/v1/update", request);
        }

        /// <kind>method</kind>
        /// <summary>
        /// Store a secret in the vault service.
        /// </summary>
        /// <remarks>Secret store</remarks>
        /// <operationid>vault_post_v1_secret_store 1</operationid>
        /// <param name="request" type="PangeaCyber.Net.Vault.Requests.SecretStoreRequest">The request parameters to send to the '/secret/store' endpoint.</param>
        /// <returns>The response containing the stored secret information.</returns>
        /// <exception cref="PangeaException">Thrown if an error occurs during the operation.</exception>
        /// <exception cref="PangeaAPIException">Thrown if the API returns an error response.</exception>
        /// <example>
        /// <code>
        /// var request = new SecretStoreRequest
        ///     .Builder("12sdfgs4543qv@#%$casd", "my-very-secret-secret")
        ///     .Build();
        /// var response = await client.SecretStore(request);
        /// </code>
        /// </example>
        public async Task<Response<SecretStoreResult>> SecretStore(SecretStoreRequest request)
        {
            return await DoPost<SecretStoreResult>("/v1/secret/store", request);
        }

        /// <kind>method</kind>
        /// <summary>
        /// Store a Pangea Token in the vault service.
        /// </summary>
        /// <remarks>Pangea token store</remarks>
        /// <operationid>vault_post_v1_secret_store 2</operationid>
        /// <param name="request" type="PangeaCyber.Net.Vault.Requests.PangeaTokenStoreRequest">The request parameters to send to the '/secret/store' endpoint.</param>
        /// <returns>The response containing the stored token information.</returns>
        /// <exception cref="PangeaException">Thrown if an error occurs during the operation.</exception>
        /// <exception cref="PangeaAPIException">Thrown if the API returns an error response.</exception>
        /// <example>
        /// <code>
        /// var request = new PangeaTokenStoreRequest
        ///     .Builder("ptv_x6fdiizbon6j3bsdvnpmwxsz2aan7fqd", "my-very-secret-secret")
        ///     .Build();
        /// var response = await client.PangeaTokenStore(request);
        /// </code>
        /// </example>
        public async Task<Response<SecretStoreResult>> PangeaTokenStore(PangeaTokenStoreRequest request)
        {
            return await DoPost<SecretStoreResult>("/v1/secret/store", request);
        }

        /// <kind>method</kind>
        /// <summary>
        /// Rotate a secret in the vault service.
        /// </summary>
        /// <remarks>Secret rotate</remarks>
        /// <operationid>vault_post_v1_secret_rotate 1</operationid>
        /// <param name="request" type="PangeaCyber.Net.Vault.Requests.SecretRotateRequest">The secret rotate request.</param>
        /// <returns>The response containing the rotated secret information.</returns>
        /// <exception cref="PangeaException">Thrown if an error occurs during the operation.</exception>
        /// <exception cref="PangeaAPIException">Thrown if the API returns an error response.</exception>
        /// <example>
        /// <code>
        /// var request = new SecretRotateRequest.Builder(
        ///         "pvi_p6g5i3gtbvqvc3u6zugab6qs6r63tqf5",
        ///         "12sdfgs4543qv@#%$casd")
        ///     .WithRotationState(ItemVersionState.Deactivated)
        ///     .Build();
        /// var response = await client.SecretRotate(request);
        /// </code>
        /// </example>
        public async Task<Response<SecretRotateResult>> SecretRotate(SecretRotateRequest request)
        {
            return await DoPost<SecretRotateResult>("/v1/secret/rotate", request);
        }

        /// <kind>method</kind>
        /// <summary>
        /// Rotate a Pangea Token in the vault service.
        /// </summary>
        /// <remarks>Token rotate</remarks>
        /// <operationid>vault_post_v1_secret_rotate 2</operationid>
        /// <param name="request" type="PangeaCyber.Net.Vault.Requests.PangeaTokenRotateRequest">The Pangea token rotate request.</param>
        /// <returns>The response containing the rotated token information.</returns>
        /// <exception cref="PangeaException">Thrown if an error occurs during the operation.</exception>
        /// <exception cref="PangeaAPIException">Thrown if the API returns an error response.</exception>
        /// <example>
        /// <code>
        /// var request = new PangeaTokenRotateRequest
        ///     .Builder("pvi_p6g5i3gtbvqvc3u6zugab6qs6r63tqf5", "3m")
        ///     .Build();
        /// var response = await client.PangeaTokenRotate(request);
        /// </code>
        /// </example>
        public async Task<Response<SecretRotateResult>> PangeaTokenRotate(PangeaTokenRotateRequest request)
        {
            return await DoPost<SecretRotateResult>("/v1/secret/rotate", request);
        }

        /// <kind>method</kind>
        /// <summary>
        /// Generate a symmetric key.
        /// </summary>
        /// <remarks>Symmetric generate</remarks>
        /// <operationid>vault_post_v1_key_generate 2</operationid>
        /// <param name="request" type="PangeaCyber.Net.Vault.Requests.SymmetricGenerateRequest">The request parameters to send to the '/key/generate' endpoint.</param>
        /// <returns>The response containing the generated symmetric key information.</returns>
        /// <exception cref="PangeaException">Thrown if an error occurs during the operation.</exception>
        /// <exception cref="PangeaAPIException">Thrown if the API returns an error response.</exception>
        /// <example>
        /// <code>
        /// SymmetricGenerateRequest request = new SymmetricGenerateRequest
        ///     .Builder(
        ///         SymmetricAlgorithm.AES128_CFB,
        ///         KeyPurpose.Encryption,
        ///         "my-very-secret-secret")
        ///     .Build();
        /// var response = await client.SymmetricGenerate(request);
        /// </code>
        /// </example>
        public async Task<Response<SymmetricGenerateResult>> SymmetricGenerate(SymmetricGenerateRequest request)
        {
            return await DoPost<SymmetricGenerateResult>("/v1/key/generate", request);
        }

        /// <kind>method</kind>
        /// <summary>
        /// Generate an asymmetric key.
        /// </summary>
        /// <remarks>Asymmetric generate</remarks>
        /// <operationid>vault_post_v1_key_generate 1</operationid>
        /// <param name="request" type="PangeaCyber.Net.Vault.Requests.AsymmetricGenerateRequest">The request parameters to send to the '/key/generate' endpoint.</param>
        /// <returns>The response containing the generated asymmetric key information.</returns>
        /// <exception cref="PangeaException">Thrown if an error occurs during the operation.</exception>
        /// <exception cref="PangeaAPIException">Thrown if the API returns an error response.</exception>
        /// <example>
        /// <code>
        /// AsymmetricGenerateRequest request = new AsymmetricGenerateRequest
        ///     .Builder(
        ///         AsymmetricAlgorithm.ED25519,
        ///         KeyPurpose.Signing,
        ///         "my-very-secret-secret")
        ///     .Build();
        /// var response = await client.AsymmetricGenerate(request);
        /// </code>
        /// </example>
        public async Task<Response<AsymmetricGenerateResult>> AsymmetricGenerate(AsymmetricGenerateRequest request)
        {
            return await DoPost<AsymmetricGenerateResult>("/v1/key/generate", request);
        }

        /// <kind>method</kind>
        /// <summary>
        /// Import an asymmetric key.
        /// </summary>
        /// <remarks>Asymmetric store</remarks>
        /// <operationid>vault_post_v1_key_store 1</operationid>
        /// <param name="request" type="PangeaCyber.Net.Vault.Requests.AsymmetricStoreRequest">The request parameters to send to the '/key/store' endpoint.</param>
        /// <returns>The response containing the stored asymmetric key information.</returns>
        /// <exception cref="PangeaException">Thrown if an error occurs during the operation.</exception>
        /// <exception cref="PangeaAPIException">Thrown if the API returns an error response.</exception>
        /// <example>
        /// <code>
        /// AsymmetricStoreRequest request = new AsymmetricStoreRequest
        ///     .Builder(
        ///         "encoded private key",
        ///         "-----BEGIN PUBLIC KEY-----\nMCowBQYDK2VwAyEA8s5JopbEPGBylPBcMK+L5PqHMqPJW/5KYPgBHzZGncc=\n-----END PUBLIC KEY-----",
        ///         AsymmetricAlgorithm.RSA4096_OAEP_SHA256,
        ///         KeyPurpose.Signing,
        ///         "my-very-secret-secret")
        ///     .Build();
        /// var response = await client.AsymmetricStore(request);
        /// </code>
        /// </example>
        public async Task<Response<AsymmetricStoreResult>> AsymmetricStore(AsymmetricStoreRequest request)
        {
            return await DoPost<AsymmetricStoreResult>("/v1/key/store", request);
        }

        /// <kind>method</kind>
        /// <summary>
        /// Import a symmetric key.
        /// </summary>
        /// <remarks>Symmetric store</remarks>
        /// <operationid>vault_post_v1_key_store 2</operationid>
        /// <param name="request" type="PangeaCyber.Net.Vault.Requests.SymmetricStoreRequest">The request parameters to send to the '/key/store' endpoint.</param>
        /// <returns>The response containing the stored symmetric key information.</returns>
        /// <exception cref="PangeaException">Thrown if an error occurs during the operation.</exception>
        /// <exception cref="PangeaAPIException">Thrown if the API returns an error response.</exception>
        /// <example>
        /// <code>
        /// SymmetricStoreRequest request = new SymmetricStoreRequest
        ///     .Builder(
        ///         "lJkk0gCLux+Q+rPNqLPEYw==",
        ///         SymmetricAlgorithm.AES128_CFB,
        ///         KeyPurpose.Encryption,
        ///         "my-very-secret-secret")
        ///     .Build();
        /// var response = await client.SymmetricStore(request);
        /// </code>
        /// </example>
        public async Task<Response<SymmetricStoreResult>> SymmetricStore(SymmetricStoreRequest request)
        {
            return await DoPost<SymmetricStoreResult>("/v1/key/store", request);
        }

        /// <kind>method</kind>
        /// <summary>
        /// Manually rotate a symmetric or asymmetric key.
        /// </summary>
        /// <remarks>Rotate</remarks>
        /// <operationid>vault_post_v1_key_rotate</operationid>
        /// <param name="request" type="PangeaCyber.Net.Vault.Requests.KeyRotateRequest">The request parameters to send to the '/key/rotate' endpoint.</param>
        /// <returns>The response containing the rotated key information.</returns>
        /// <exception cref="PangeaException">Thrown if an error occurs during the operation.</exception>
        /// <exception cref="PangeaAPIException">Thrown if the API returns an error response.</exception>
        /// <example>
        /// <code>
        /// KeyRotateRequest request = new KeyRotateRequest
        ///     .Builder(
        ///         "pvi_p6g5i3gtbvqvc3u6zugab6qs6r63tqf5",
        ///         ItemVersionState.Deactivated)
        ///     .WithEncodedSymmetricKey("lJkk0gCLux+Q+rPNqLPEYw==")
        ///     .Build();
        /// var response = await client.KeyRotate(request);
        /// </code>
        /// </example>
        public async Task<Response<KeyRotateResult>> KeyRotate(KeyRotateRequest request)
        {
            return await DoPost<KeyRotateResult>("/v1/key/rotate", request);
        }

        /// <kind>method</kind>
        /// <summary>
        /// Encrypt a message using a key.
        /// </summary>
        /// <remarks>Encrypt</remarks>
        /// <operationid>vault_post_v1_key_encrypt</operationid>
        /// <param name="request" type="PangeaCyber.Net.Vault.Requests.EncryptRequest">The request parameters to send to the '/key/encrypt' endpoint.</param>
        /// <returns>The response containing the encrypted message.</returns>
        /// <exception cref="PangeaException">Thrown if an error occurs during the operation.</exception>
        /// <exception cref="PangeaAPIException">Thrown if the API returns an error response.</exception>
        /// <example>
        /// <code>
        /// EncryptRequest request = new EncryptRequest
        ///     .Builder(
        ///         "pvi_p6g5i3gtbvqvc3u6zugab6qs6r63tqf5",
        ///         "lJkk0gCLux+Q+rPNqLPEYw==")
        ///     .WithVersion(2)
        ///     .Build();
        /// var response = await client.Encrypt(request);
        /// </code>
        /// </example>
        public async Task<Response<EncryptResult>> Encrypt(EncryptRequest request)
        {
            return await DoPost<EncryptResult>("/v1/key/encrypt", request);
        }

        /// <kind>method</kind>
        /// <summary>
        /// Decrypt a message using a key.
        /// </summary>
        /// <remarks>Decrypt</remarks>
        /// <operationid>vault_post_v1_key_decrypt</operationid>
        /// <param name="request" type="PangeaCyber.Net.Vault.Requests.DecryptRequest">The request parameters to send to the '/key/decrypt' endpoint.</param>
        /// <returns>The response containing the decrypted message.</returns>
        /// <exception cref="PangeaException">Thrown if an error occurs during the operation.</exception>
        /// <exception cref="PangeaAPIException">Thrown if the API returns an error response.</exception>
        /// <example>
        /// <code>
        /// DecryptRequest request = new DecryptRequest
        ///     .Builder(
        ///         "pvi_p6g5i3gtbvqvc3u6zugab6qs6r63tqf5",
        ///         "lJkk0gCLux+Q+rPNqLPEYw==")
        ///     .WithVersion(2)
        ///     .Build();
        /// var response = await client.Decrypt(request);
        /// </code>
        /// </example>
        public async Task<Response<DecryptResult>> Decrypt(DecryptRequest request)
        {
            return await DoPost<DecryptResult>("/v1/key/decrypt", request);
        }

        /// <kind>method</kind>
        /// <summary>
        /// Sign a message using a key.
        /// </summary>
        /// <remarks>Sign</remarks>
        /// <operationid>vault_post_v1_key_sign</operationid>
        /// <param name="request" type="PangeaCyber.Net.Vault.Requests.SignRequest">The request parameters to send to the '/key/sign' endpoint.</param>
        /// <returns>The response containing the signed message.</returns>
        /// <exception cref="PangeaException">Thrown if an error occurs during the operation.</exception>
        /// <exception cref="PangeaAPIException">Thrown if the API returns an error response.</exception>
        /// <example>
        /// <code>
        /// SignRequest request = new SignRequest
        ///     .Builder(
        ///         "pvi_p6g5i3gtbvqvc3u6zugab6qs6r63tqf5",
        ///         "lJkk0gCLux+Q+rPNqLPEYw==")
        ///     .Build();
        /// var response = await client.Sign(request);
        /// </code>
        /// </example>
        public async Task<Response<SignResult>> Sign(SignRequest request)
        {
            return await DoPost<SignResult>("/v1/key/sign", request);
        }

        /// <kind>method</kind>
        /// <summary>
        /// Sign a JSON Web Token (JWT) using a key.
        /// </summary>
        /// <remarks>JWT Sign</remarks>
        /// <operationid>vault_post_v1_key_sign_jwt</operationid>
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
            return await DoPost<JWTSignResult>("/v1/key/sign/jwt", new JWTSignRequest.Builder(id, payload).Build());
        }

        /// <kind>method</kind>
        /// <summary>
        /// Verify a signature using a key.
        /// </summary>
        /// <remarks>Verify</remarks>
        /// <operationid>vault_post_v1_key_verify</operationid>
        /// <param name="request" type="PangeaCyber.Net.Vault.Requests.VerifyRequest">The request containing the key ID, message, and signature to verify.</param>
        /// <returns>The response indicating whether the signature is valid or not.</returns>
        /// <exception cref="PangeaException">Thrown if an error occurs during the operation.</exception>
        /// <exception cref="PangeaAPIException">Thrown if the API returns an error response.</exception>
        /// <example>
        /// <code>
        /// var request = new VerifyRequest
        ///     .Builder(
        ///         "pvi_p6g5i3gtbvqvc3u6zugab6qs6r63tqf5",
        ///         "data2verify",
        ///         "signature")
        ///     .Build();
        /// var response = await client.Verify(request);
        /// </code>
        /// </example>
        public async Task<Response<VerifyResult>> Verify(VerifyRequest request)
        {
            return await DoPost<VerifyResult>("/v1/key/verify", request);
        }

        /// <kind>method</kind>
        /// <summary>
        /// Verify the signature of a JSON Web Token (JWT).
        /// </summary>
        /// <remarks>JWT Verify</remarks>
        /// <operationid>vault_post_v1_key_verify_jwt</operationid>
        /// <param name="request" type="PangeaCyber.Net.Vault.Requests.JWTVerifyRequest">The request containing the JWT signature to verify.</param>
        /// <returns>The response containing the verification result.</returns>
        /// <exception cref="PangeaException">Thrown if an error occurs during the operation.</exception>
        /// <exception cref="PangeaAPIException">Thrown if the API returns an error response.</exception>
        /// <example>
        /// <code>
        /// var request = new JWTVerifyRequest
        ///     .Builder("ewogICJhbGciO...")
        ///     .Build();
        /// var verifyResponse = await client.JWTVerify(request);
        /// </code>
        /// </example>
        public async Task<Response<JWTVerifyResult>> JWTVerify(JWTVerifyRequest request)
        {
            return await DoPost<JWTVerifyResult>("/v1/key/verify/jwt", request);
        }

        /// <kind>method</kind>
        /// <summary>
        /// Retrieve a key in JWK format.
        /// </summary>
        /// <remarks>JWT Retrieve</remarks>
        /// <operationid>vault_post_v1_get_jwt</operationid>
        /// <param name="request" type="PangeaCyber.Net.Vault.Requests.JWKGetRequest">The request containing the item ID and version to retrieve.</param>
        /// <returns>The response containing the JWK key.</returns>
        /// <exception cref="PangeaException">Thrown if an error occurs during the operation.</exception>
        /// <exception cref="PangeaAPIException">Thrown if the API returns an error response.</exception>
        /// <example>
        /// <code>
        /// var request = new JWKGetRequest
        ///     .Builder("jwkid")
        ///     .WithVersion("2")
        ///     .Build();
        /// var response = await client.JWKGet(request)
        /// </code>
        /// </example>
        public async Task<Response<JWKGetResult>> JWKGet(JWKGetRequest request)
        {
            return await DoPost<JWKGetResult>("/v1/get/jwk", request);
        }

        /// <kind>method</kind>
        /// <summary>
        /// Creates a folder.
        /// </summary>
        /// <remarks>Create</remarks>
        /// <operationid>vault_post_v1_folder_create</operationid>
        /// <param name="request" type="PangeaCyber.Net.Vault.Requests.FolderCreateRequest">The request parameters to send to the '/folder/create' endpoint.</param>
        /// <returns>The response containing the created folder information.</returns>
        /// <exception cref="PangeaException">Thrown if an error occurs during the operation.</exception>
        /// <exception cref="PangeaAPIException">Thrown if the API returns an error response.</exception>
        /// <example>
        /// <code>
        /// var request = new FolderCreateRequest
        ///     .Builder(
        ///         "folder_name",
        ///         "parent/folder/name")
        ///     .Build();
        /// var response = await client.FolderCreate(request);
        /// </code>
        /// </example>
        public async Task<Response<FolderCreateResult>> FolderCreate(FolderCreateRequest request)
        {
            return await DoPost<FolderCreateResult>("/v1/folder/create", request);
        }

        /// <kind>method</kind>
        /// <summary>Encrypt parts of a JSON object.</summary>
        /// <remarks>Encrypt structured</remarks>
        /// <operationid>vault_post_v1_key_encrypt_structured</operationid>
        /// <typeparam name="T">Structured data type.</typeparam>
        /// <param name="request" type="EncryptStructuredRequest&lt;T&gt;">Request parameters.</param>
        /// <param name="cancellationToken" type="CancellationToken">Cancellation token.</param>
        /// <returns type="Response&lt;EncryptStructuredResult&lt;T&gt;&gt;">Encrypted result.</returns>
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
                "/v1/key/encrypt/structured",
                request,
                cancellationToken: cancellationToken
            );
        }

        /// <kind>method</kind>
        /// <summary>Decrypt parts of a JSON object.</summary>
        /// <remarks>Decrypt structured</remarks>
        /// <operationid>vault_post_v1_key_decrypt_structured</operationid>
        /// <typeparam name="T">Structured data type.</typeparam>
        /// <param name="request" type="EncryptStructuredRequest&lt;T&gt;">Request parameters.</param>
        /// <param name="cancellationToken" type="CancellationToken">Cancellation token.</param>
        /// <returns type="Response&lt;EncryptStructuredResult&lt;T&gt;&gt;">Decrypted result.</returns>
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
                "/v1/key/decrypt/structured",
                request,
                cancellationToken: cancellationToken
            );
        }
    }
}
