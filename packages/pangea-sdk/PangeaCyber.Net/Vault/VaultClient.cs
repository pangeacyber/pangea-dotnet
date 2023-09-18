using PangeaCyber.Net.Exceptions;
using PangeaCyber.Net.Vault.Models;
using PangeaCyber.Net.Vault.Requests;
using PangeaCyber.Net.Vault.Results;

namespace PangeaCyber.Net.Vault
{
    ///
    public class VaultClient : BaseClient<VaultClient.Builder>
    {
        ///
        public static string ServiceName { get; } = "vault";

        ///
        public VaultClient(Builder builder) : base(builder, ServiceName)
        {
        }

        ///
        public class Builder : BaseClient<VaultClient.Builder>.ClientBuilder
        {
            ///
            public Builder(Config config) : base(config)
            {
            }

            ///
            public VaultClient Build()
            {
                return new VaultClient(this);
            }
        }

        /// <summary>
        /// State change
        /// </summary>
        /// <param name="id">Item id to change</param>
        /// <param name="version">Item version to change</param>
        /// <param name="state">State to set to item version</param>
        /// <returns>StateChangeResponse</returns>
        /// <exception cref="PangeaException"></exception>
        /// <exception cref="PangeaAPIException"></exception>
        public async Task<Response<StateChangeResult>> StateChange(string id, int version, ItemVersionState state)
        {
            return await DoPost<StateChangeResult>("/v1/state/change", new StateChangeRequest.Builder(id, version, state).Build());
        }

        /// <summary>
        /// Delete
        /// </summary>
        /// <param name="id">Item id to delete</param>
        /// <returns>DeleteResponse</returns>
        /// <exception cref="PangeaException"></exception>
        /// <exception cref="PangeaAPIException"></exception>
        public async Task<Response<DeleteResult>> Delete(string id)
        {
            return await DoPost<DeleteResult>("/v1/delete", new DeleteRequest.Builder(id).Build());
        }

        /// <summary>
        /// Retrieve a secret or key, and any associated information.
        /// </summary>
        /// <param name="request">The request to the '/get' endpoint.</param>
        /// <returns>The response containing the retrieved information.</returns>
        /// <exception cref="PangeaException">Thrown if an error occurs during the operation.</exception>
        /// <exception cref="PangeaAPIException">Thrown if the API returns an error response.</exception>
        /// <example>
        /// <code>
        /// var getResponse = await client.Get(new GetRequest.Builder("id").Build());
        /// </code>
        /// </example>
        public async Task<Response<GetResult>> Get(GetRequest request)
        {
            return await DoPost<GetResult>("/v1/get", request);
        }

        /// <summary>
        /// Retrieve a list of secrets, keys, and folders, and their associated information.
        /// </summary>
        /// <param name="request">The request parameters to send to the 'list' endpoint.</param>
        /// <returns>The response containing the list of items and their information.</returns>
        /// <exception cref="PangeaException">Thrown if an error occurs during the operation.</exception>
        /// <exception cref="PangeaAPIException">Thrown if the API returns an error response.</exception>
        /// <example>
        /// <code>
        /// var listResponse = await client.List(new ListRequest.Builder().Build());
        /// </code>
        /// </example>
        public async Task<Response<ListResult>> List(ListRequest request)
        {
            return await DoPost<ListResult>("/v1/list", request);
        }

        /// <summary>
        /// Update information associated with a secret or key.
        /// </summary>
        /// <param name="request">The request parameters to send to the update endpoint.</param>
        /// <returns>The response containing the updated information.</returns>
        /// <exception cref="PangeaException">Thrown if an error occurs during the operation.</exception>
        /// <exception cref="PangeaAPIException">Thrown if the API returns an error response.</exception>
        /// <example>
        /// <code>
        /// UpdateResponse updateResponse = await client.Update(new UpdateRequest.Builder("id")
        ///     .WithFolder("updated")
        ///     .Build());
        /// </code>
        /// </example>
        public async Task<Response<UpdateResult>> Update(UpdateRequest request)
        {
            return await DoPost<UpdateResult>("/v1/update", request);
        }

        /// <summary>
        /// Store a secret in the vault service.
        /// </summary>
        /// <param name="request">The request parameters to send to the '/secret/store' endpoint.</param>
        /// <returns>The response containing the stored secret information.</returns>
        /// <exception cref="PangeaException">Thrown if an error occurs during the operation.</exception>
        /// <exception cref="PangeaAPIException">Thrown if the API returns an error response.</exception>
        /// <example>
        /// <code>
        /// var storeResponse = await client.SecretStore(new SecretStoreRequest.Builder("mysecret", "mysecretname")
        ///     .Build());
        /// </code>
        /// </example>
        public async Task<Response<SecretStoreResult>> SecretStore(SecretStoreRequest request)
        {
            return await DoPost<SecretStoreResult>("/v1/secret/store", request);
        }

        /// <summary>
        /// Store a Pangea Token in the vault service.
        /// </summary>
        /// <param name="request">The request parameters to send to the '/secret/store' endpoint.</param>
        /// <returns>The response containing the stored token information.</returns>
        /// <exception cref="PangeaException">Thrown if an error occurs during the operation.</exception>
        /// <exception cref="PangeaAPIException">Thrown if the API returns an error response.</exception>
        /// <example>
        /// <code>
        /// var storeResponse = await client.PangeaTokenStore(new PangeaTokenStoreRequest.Builder("mytoken", "mytokenname")
        ///     .Build());
        /// </code>
        /// </example>
        public async Task<Response<SecretStoreResult>> PangeaTokenStore(PangeaTokenStoreRequest request)
        {
            return await DoPost<SecretStoreResult>("/v1/secret/store", request);
        }

        /// <summary>
        /// Rotate a secret in the vault service.
        /// </summary>
        /// <param name="request">The secret rotate request.</param>
        /// <returns>The response containing the rotated secret information.</returns>
        /// <exception cref="PangeaException">Thrown if an error occurs during the operation.</exception>
        /// <exception cref="PangeaAPIException">Thrown if the API returns an error response.</exception>
        /// <example>
        /// <code>
        /// var rotateResponse = await client.SecretRotate(new SecretRotateRequest.Builder("secretid", "mynewsecret")
        ///     .WithRotationState(ItemVersionState.Suspended)
        ///     .Build());
        /// </code>
        /// </example>
        public async Task<Response<SecretRotateResult>> SecretRotate(SecretRotateRequest request)
        {
            return await DoPost<SecretRotateResult>("/v1/secret/rotate", request);
        }

        /// <summary>
        /// Rotate a Pangea Token in the vault service.
        /// </summary>
        /// <param name="request">The Pangea token rotate request.</param>
        /// <returns>The response containing the rotated token information.</returns>
        /// <exception cref="PangeaException">Thrown if an error occurs during the operation.</exception>
        /// <exception cref="PangeaAPIException">Thrown if the API returns an error response.</exception>
        /// <example>
        /// <code>
        /// var rotateResponse = await client.PangeaTokenRotate(new PangeaTokenRotateRequest.Builder("tokenid", "3m")
        ///     .Build());
        /// </code>
        /// </example>
        public async Task<Response<SecretRotateResult>> PangeaTokenRotate(PangeaTokenRotateRequest request)
        {
            return await DoPost<SecretRotateResult>("/v1/secret/rotate", request);
        }

        /// <summary>
        /// Generate a symmetric key.
        /// </summary>
        /// <param name="request">The request parameters to send to the '/key/generate' endpoint.</param>
        /// <returns>The response containing the generated symmetric key information.</returns>
        /// <exception cref="PangeaException">Thrown if an error occurs during the operation.</exception>
        /// <exception cref="PangeaAPIException">Thrown if the API returns an error response.</exception>
        /// <example>
        /// <code>
        /// SymmetricGenerateRequest generateRequest = new SymmetricGenerateRequest.Builder(SymmetricAlgorithm.AES, KeyPurpose.Encryption, "keyname")
        ///     .Build();
        /// var generateResponse = await client.SymmetricGenerate(generateRequest);
        /// </code>
        /// </example>
        public async Task<Response<SymmetricGenerateResult>> SymmetricGenerate(SymmetricGenerateRequest request)
        {
            return await DoPost<SymmetricGenerateResult>("/v1/key/generate", request);
        }

        /// <summary>
        /// Generate an asymmetric key.
        /// </summary>
        /// <param name="request">The request parameters to send to the '/key/generate' endpoint.</param>
        /// <returns>The response containing the generated asymmetric key information.</returns>
        /// <exception cref="PangeaException">Thrown if an error occurs during the operation.</exception>
        /// <exception cref="PangeaAPIException">Thrown if the API returns an error response.</exception>
        /// <example>
        /// <code>
        /// AsymmetricGenerateRequest generateRequest = new AsymmetricGenerateRequest.Builder(AsymmetricAlgorithm.ED25519, KeyPurpose.Signing, "keyname")
        ///     .Build();
        /// var generateResponse = await client.AsymmetricGenerate(generateRequest);
        /// </code>
        /// </example>
        public async Task<Response<AsymmetricGenerateResult>> AsymmetricGenerate(AsymmetricGenerateRequest request)
        {
            return await DoPost<AsymmetricGenerateResult>("/v1/key/generate", request);
        }

        /// <summary>
        /// Import an asymmetric key.
        /// </summary>
        /// <param name="request">The request parameters to send to the '/key/store' endpoint.</param>
        /// <returns>The response containing the stored asymmetric key information.</returns>
        /// <exception cref="PangeaException">Thrown if an error occurs during the operation.</exception>
        /// <exception cref="PangeaAPIException">Thrown if the API returns an error response.</exception>
        /// <example>
        /// <code>
        /// AsymmetricStoreRequest storeRequest = new AsymmetricStoreRequest.Builder("encodedprivatekey", "encodedpublickey", AsymmetricAlgorithm.ED25519, KeyPurpose.Signing, "keyname")
        ///     .Build();
        /// var storeResponse = await client.AsymmetricStore(storeRequest);
        /// </code>
        /// </example>
        public async Task<Response<AsymmetricStoreResult>> AsymmetricStore(AsymmetricStoreRequest request)
        {
            return await DoPost<AsymmetricStoreResult>("/v1/key/store", request);
        }

        /// <summary>
        /// Import a symmetric key.
        /// </summary>
        /// <param name="request">The request parameters to send to the '/key/store' endpoint.</param>
        /// <returns>The response containing the stored symmetric key information.</returns>
        /// <exception cref="PangeaException">Thrown if an error occurs during the operation.</exception>
        /// <exception cref="PangeaAPIException">Thrown if the API returns an error response.</exception>
        /// <example>
        /// <code>
        /// SymmetricStoreRequest storeRequest = new SymmetricStoreRequest.Builder("encodedkey", SymmetricAlgorithm.AES, KeyPurpose.Encryption, "keyname")
        ///     .Build();
        /// var storeResponse = await client.SymmetricStore(storeRequest);
        /// </code>
        /// </example>
        public async Task<Response<SymmetricStoreResult>> SymmetricStore(SymmetricStoreRequest request)
        {
            return await DoPost<SymmetricStoreResult>("/v1/key/store", request);
        }

        /// <summary>
        /// Manually rotate a symmetric or asymmetric key.
        /// </summary>
        /// <param name="request">The request parameters to send to the '/key/rotate' endpoint.</param>
        /// <returns>The response containing the rotated key information.</returns>
        /// <exception cref="PangeaException">Thrown if an error occurs during the operation.</exception>
        /// <exception cref="PangeaAPIException">Thrown if the API returns an error response.</exception>
        /// <example>
        /// <code>
        /// KeyRotateRequest rotateRequest = new KeyRotateRequest.Builder("keyid", ItemVersionState.Suspended)
        ///     .Build();
        /// var rotateResponse = await client.KeyRotate(rotateRequest);
        /// </code>
        /// </example>
        public async Task<Response<KeyRotateResult>> KeyRotate(KeyRotateRequest request)
        {
            return await DoPost<KeyRotateResult>("/v1/key/rotate", request);
        }

        /// <summary>
        /// Encrypt a message using a key.
        /// </summary>
        /// <param name="request">The request parameters to send to the '/key/encrypt' endpoint.</param>
        /// <returns>The response containing the encrypted message.</returns>
        /// <exception cref="PangeaException">Thrown if an error occurs during the operation.</exception>
        /// <exception cref="PangeaAPIException">Thrown if the API returns an error response.</exception>
        /// <example>
        /// <code>
        /// EncryptRequest encryptRequest = new EncryptRequest.Builder("keyid", "base64message")
        ///     .WithVersion(2)
        ///     .Build();
        /// var encryptResponse = await client.Encrypt(encryptRequest);
        /// </code>
        /// </example>
        public async Task<Response<EncryptResult>> Encrypt(EncryptRequest request)
        {
            return await DoPost<EncryptResult>("/v1/key/encrypt", request);
        }

        /// <summary>
        /// Decrypt a message using a key.
        /// </summary>
        /// <param name="request">The request parameters to send to the '/key/decrypt' endpoint.</param>
        /// <returns>The response containing the decrypted message.</returns>
        /// <exception cref="PangeaException">Thrown if an error occurs during the operation.</exception>
        /// <exception cref="PangeaAPIException">Thrown if the API returns an error response.</exception>
        /// <example>
        /// <code>
        /// DecryptRequest decryptRequest = new DecryptRequest.Builder("keyid", "validciphertext")
        ///     .WithVersion(2)
        ///     .Build();
        /// var decryptResponse = await client.Decrypt(decryptRequest);
        /// </code>
        /// </example>
        public async Task<Response<DecryptResult>> Decrypt(DecryptRequest request)
        {
            return await DoPost<DecryptResult>("/v1/key/decrypt", request);
        }

        /// <summary>
        /// Sign a message using a key.
        /// </summary>
        /// <param name="request">The request parameters to send to the '/key/sign' endpoint.</param>
        /// <returns>The response containing the signed message.</returns>
        /// <exception cref="PangeaException">Thrown if an error occurs during the operation.</exception>
        /// <exception cref="PangeaAPIException">Thrown if the API returns an error response.</exception>
        /// <example>
        /// <code>
        /// SignRequest signRequest = new SignRequest.Builder("keyid", "base64data2sign").Build();
        /// var signResponse = await client.Sign(signRequest);
        /// </code>
        /// </example>
        public async Task<Response<SignResult>> Sign(SignRequest request)
        {
            return await DoPost<SignResult>("/v1/key/sign", request);
        }

        /// <summary>
        /// Sign a JSON Web Token (JWT) using a key.
        /// </summary>
        /// <param name="id">The key ID to sign the payload.</param>
        /// <param name="payload">The payload to sign.</param>
        /// <returns>The response containing the signed JWT.</returns>
        /// <exception cref="PangeaException">Thrown if an error occurs during the operation.</exception>
        /// <exception cref="PangeaAPIException">Thrown if the API returns an error response.</exception>
        /// <example>
        /// <code>
        /// string payload = "{\"message\": \"message to sign\", \"data\": \"Some extra data\"}";
        /// var jwtSignResponse = await client.JwtSign("keyid", payload);
        /// </code>
        /// </example>
        public async Task<Response<JWTSignResult>> JWTSign(string id, string payload)
        {
            return await DoPost<JWTSignResult>("/v1/key/sign/jwt", new JWTSignRequest.Builder(id, payload).Build());
        }

        /// <summary>
        /// Verify a signature using a key.
        /// </summary>
        /// <param name="request">The request containing the key ID, message, and signature to verify.</param>
        /// <returns>The response indicating whether the signature is valid or not.</returns>
        /// <exception cref="PangeaException">Thrown if an error occurs during the operation.</exception>
        /// <exception cref="PangeaAPIException">Thrown if the API returns an error response.</exception>
        /// <example>
        /// <code>
        /// var request = new VerifyRequest.Builder("keyid", "data2verify", "signature").Build();
        /// var verifyResponse = await client.Verify(request);
        /// </code>
        /// </example>
        public async Task<Response<VerifyResult>> Verify(VerifyRequest request)
        {
            return await DoPost<VerifyResult>("/v1/key/verify", request);
        }

        /// <summary>
        /// Verify the signature of a JSON Web Token (JWT).
        /// </summary>
        /// <param name="request">The request containing the JWT signature to verify.</param>
        /// <returns>The response containing the verification result.</returns>
        /// <exception cref="PangeaException">Thrown if an error occurs during the operation.</exception>
        /// <exception cref="PangeaAPIException">Thrown if the API returns an error response.</exception>
        /// <example>
        /// <code>
        /// var request = new JWTVerifyRequest.Builder(jws).Build();
        /// var verifyResponse = await client.JWTVerify(request);
        /// </code>
        /// </example>
        public async Task<Response<JWTVerifyResult>> JWTVerify(JWTVerifyRequest request)
        {
            return await DoPost<JWTVerifyResult>("/v1/key/verify/jwt", request);
        }


        /// <summary>
        /// Retrieve a key in JWK format.
        /// </summary>
        /// <param name="request">The request containing the item ID and version to retrieve.</param>
        /// <returns>The response containing the JWK key.</returns>
        /// <exception cref="PangeaException">Thrown if an error occurs during the operation.</exception>
        /// <exception cref="PangeaAPIException">Thrown if the API returns an error response.</exception>
        /// <example>
        /// <code>
        /// var request = new JWKGetRequest.Builder("jwkid").WithVersion(2).Builder();
        /// var getResponse = await client.JWKGet(request);
        /// </code>
        /// </example>
        public async Task<Response<JWKGetResult>> JWKGet(JWKGetRequest request)
        {
            return await DoPost<JWKGetResult>("/v1/get/jwk", request);
        }

        /// <summary>
        /// Creates a folder.
        /// </summary>
        /// <param name="request">The request parameters to send to the '/folder/create' endpoint.</param>
        /// <returns>The response containing the created folder information.</returns>
        /// <exception cref="PangeaException">Thrown if an error occurs during the operation.</exception>
        /// <exception cref="PangeaAPIException">Thrown if the API returns an error response.</exception>
        /// <example>
        /// <code>
        /// var request = new FolderCreateRequest.Builder("folder_name", "parent/folder/name").Build();
        /// var createResponse = await client.FolderCreate(request);
        /// </code>
        /// </example>
        public async Task<Response<FolderCreateResult>> FolderCreate(FolderCreateRequest request)
        {
            return await DoPost<FolderCreateResult>("/v1/folder/create", request);
        }

    }
}
