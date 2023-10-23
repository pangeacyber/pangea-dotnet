using PangeaCyber.Net.Exceptions;
using PangeaCyber.Net.Vault.Requests;
using PangeaCyber.Net.Vault.Models;

namespace PangeaCyber.Net.Vault.Tests
{
    public class ITVaultTest
    {
        VaultClient client;
        TestEnvironment environment = TestEnvironment.LVE;
        string time;
        Random random;
        const string actor = "CsharpSDKTest";

        public ITVaultTest()
        {
            client = new VaultClient.Builder(Config.FromIntegrationEnvironment(environment)).Build();
            time = DateTime.Now.ToString("yyyyMMdd_HHmmss");
            random = new Random();
        }

        private string GetRandomID()
        {
            return random.Next(1000000).ToString();
        }

        private string GetName([System.Runtime.CompilerServices.CallerMemberName] string callerName = "")
        {
            return $"{time}_{actor}_{callerName}_{GetRandomID()}";
        }

        private async Task EncryptingCycle(string id)
        {
            string message = "thisisamessagetoencrypt";
            string dataB64 = Utils.StringToStringB64(message);

            // Encrypt 1
            var encryptResponse1 = await client.Encrypt(new EncryptRequest.Builder(id, dataB64).Build());
            Assert.Equal(id, encryptResponse1.Result.ID);
            Assert.Equal(1, encryptResponse1.Result.Version);
            Assert.NotNull(encryptResponse1.Result.CipherText);

            // Rotate
            var rotateResponse = await client.KeyRotate(new KeyRotateRequest.Builder(id, ItemVersionState.Suspended).Build());
            Assert.Equal(2, rotateResponse.Result.Version);
            Assert.Equal(id, rotateResponse.Result.ID);

            // Encrypt 2
            var encryptResponse2 = await client.Encrypt(new EncryptRequest.Builder(id, dataB64).WithVersion(2).Build());
            Assert.Equal(id, encryptResponse1.Result.ID);
            Assert.Equal(2, encryptResponse2.Result.Version);
            Assert.NotNull(encryptResponse2.Result.CipherText);

            // Decrypt 1
            var decryptResponse1 = await client.Decrypt(new DecryptRequest.Builder(id, encryptResponse1.Result.CipherText).WithVersion(1).Build());
            Assert.Equal(dataB64, decryptResponse1.Result.PlainText);

            // Decrypt 2
            var decryptResponse2 = await client.Decrypt(new DecryptRequest.Builder(id, encryptResponse2.Result.CipherText).WithVersion(2).Build());
            Assert.Equal(dataB64, decryptResponse2.Result.PlainText);

            // Decrypt default
            var decryptResponseDefault = await client.Decrypt(new DecryptRequest.Builder(id, encryptResponse2.Result.CipherText).Build());
            Assert.Equal(dataB64, decryptResponseDefault.Result.PlainText);

            // Add failure cases. Wrong ID, wrong version, etc.

            // Suspend key
            var stateChangeResponse = await client.StateChange(id, 1, ItemVersionState.Deactivated);
            Assert.Equal(id, stateChangeResponse.Result.ID);

            // Decrypt after revoke
            var decryptResponseAfterSuspend = await client.Decrypt(new DecryptRequest.Builder(id, encryptResponse1.Result.CipherText).WithVersion(1).Build());
            Assert.Equal(dataB64, decryptResponseAfterSuspend.Result.PlainText);
        }

        private async Task AsymSigningCycle(string id)
        {
            string message = "thisisamessagetosign";
            string data = Utils.StringToStringB64(message);

            // Sign 1
            var signResponse1 = await client.Sign(new SignRequest.Builder(id, data).Build());
            Assert.Equal(1, signResponse1.Result.Version);
            Assert.NotNull(signResponse1.Result.Signature);

            // Rotate
            var rotateResponse = await client.KeyRotate(new KeyRotateRequest.Builder(id, ItemVersionState.Suspended).Build());
            Assert.Equal(2, rotateResponse.Result.Version);
            Assert.NotNull(rotateResponse.Result.EncodedPublicKey);

            // Sign 2
            var signResponse2 = await client.Sign(new SignRequest.Builder(id, data).Build());
            Assert.Equal(2, signResponse2.Result.Version);
            Assert.NotNull(signResponse2.Result.Signature);

            // Verify 1
            var verifyResponse1 = await client.Verify(new VerifyRequest.Builder(id, data, signResponse1.Result.Signature).WithVersion(1).Build());
            Assert.Equal(1, verifyResponse1.Result.Version);
            Assert.True(verifyResponse1.Result.ValidSignature);

            // Verify 2
            var verifyResponse2 = await client.Verify(new VerifyRequest.Builder(id, data, signResponse2.Result.Signature).Build());
            Assert.Equal(2, verifyResponse2.Result.Version);
            Assert.True(verifyResponse2.Result.ValidSignature);

            // TODO: Add failure cases

            // Wrong signature. Use signature of version 1 and try to verify with default version (2)
            var verifyResponseBad = await client.Verify(new VerifyRequest.Builder(id, data, signResponse1.Result.Signature).Build());
            Assert.False(verifyResponseBad.Result.ValidSignature);

            // Suspend key
            var stateChangeResponse = await client.StateChange(id, 1, ItemVersionState.Deactivated);
            Assert.Equal(id, stateChangeResponse.Result.ID);

            // Verify after revoke
            var verifyResponseAfterSuspend = await client.Verify(new VerifyRequest.Builder(id, data, signResponse1.Result.Signature).WithVersion(1).Build());
            Assert.Equal(1, verifyResponseAfterSuspend.Result.Version);
            Assert.True(verifyResponseAfterSuspend.Result.ValidSignature);
        }

        private async Task JwtAsymSigningCycle(string id)
        {
            string payload = @"
                {'message': 'message to sign', 'data': 'Some extra data'}
            ";

            // Sign 1
            var signResponse1 = await client.JWTSign(id, payload);
            Assert.NotNull(signResponse1.Result.JWS);

            // Rotate
            var rotateResponse = await client.KeyRotate(new KeyRotateRequest.Builder(id, ItemVersionState.Suspended).Build());
            Assert.Equal(2, rotateResponse.Result.Version);

            // Sign 2
            var signResponse2 = await client.JWTSign(id, payload);
            Assert.NotNull(signResponse2.Result.JWS);

            // Verify 1
            var verifyResponse1 = await client.JWTVerify(new JWTVerifyRequest.Builder(signResponse1.Result.JWS).Build());
            Assert.True(verifyResponse1.Result.ValidSignature);

            // Verify 2
            var verifyResponse2 = await client.JWTVerify(new JWTVerifyRequest.Builder(signResponse2.Result.JWS).Build());
            Assert.True(verifyResponse2.Result.ValidSignature);

            // Gets default
            var getResponse = await client.JWKGet(new JWKGetRequest.Builder(id).Build());
            Assert.Single(getResponse.Result.Keys);

            // Gets all
            getResponse = await client.JWKGet(new JWKGetRequest.Builder(id).WithVersion("all").Build());
            Assert.Equal(2, getResponse.Result.Keys.Length);

            // Gets -1
            getResponse = await client.JWKGet(new JWKGetRequest.Builder(id).WithVersion("-1").Build());
            Assert.Equal(2, getResponse.Result.Keys.Length);

            // Suspend key
            var stateChangeResponse = await client.StateChange(id, 1, ItemVersionState.Deactivated);
            Assert.Equal(id, stateChangeResponse.Result.ID);

            // Verify after revoke
            var verifyResponseAfterSuspend = await client.JWTVerify(new JWTVerifyRequest.Builder(signResponse1.Result.JWS).Build());
            Assert.True(verifyResponseAfterSuspend.Result.ValidSignature);
        }

        private async Task JwtSymSigningCycle(string id)
        {
            string payload = @"
                {'message': 'message to sign', 'data': 'Some extra data'}
            ";

            // Sign 1
            var signResponse1 = await client.JWTSign(id, payload);
            Assert.NotNull(signResponse1.Result.JWS);

            // Rotate
            var rotateResponse = await client.KeyRotate(new KeyRotateRequest.Builder(id, ItemVersionState.Suspended).Build());
            Assert.Equal(2, rotateResponse.Result.Version);

            // Sign 2
            var signResponse2 = await client.JWTSign(id, payload);
            Assert.NotNull(signResponse2.Result.JWS);

            // Verify 1
            var verifyResponse1 = await client.JWTVerify(new JWTVerifyRequest.Builder(signResponse1.Result.JWS).Build());
            Assert.True(verifyResponse1.Result.ValidSignature);

            // Verify 2
            var verifyResponse2 = await client.JWTVerify(new JWTVerifyRequest.Builder(signResponse2.Result.JWS).Build());
            Assert.True(verifyResponse2.Result.ValidSignature);

            // Suspend key
            var stateChangeResponse = await client.StateChange(id, 1, ItemVersionState.Deactivated);
            Assert.Equal(id, stateChangeResponse.Result.ID);

            // Verify after revoke
            var verifyResponseAfterSuspend = await client.JWTVerify(new JWTVerifyRequest.Builder(signResponse1.Result.JWS).Build());
            Assert.True(verifyResponseAfterSuspend.Result.ValidSignature);
        }

        [Fact]
        public async Task TestAESEncryptingLifeCycle()
        {
            string name = GetName();
            try
            {
                var generateRequest = new SymmetricGenerateRequest.Builder(
                    SymmetricAlgorithm.AES128_CFB,
                    KeyPurpose.Encryption,
                    name
                ).Build();

                var generateResp = await client.SymmetricGenerate(generateRequest);
                Assert.NotNull(generateResp.Result.ID);
                Assert.Equal(1, generateResp.Result.Version);
                await EncryptingCycle(generateResp.Result.ID);
            }
            catch (PangeaAPIException e)
            {
                Console.WriteLine(e.ToString());
                Assert.True(false);
            }
        }

        [Fact]
        public async Task TestEd25519SigningLifeCycle()
        {
            string name = GetName();
            try
            {
                var generateRequest = new AsymmetricGenerateRequest.Builder(
                    AsymmetricAlgorithm.ED25519,
                    KeyPurpose.Signing,
                    name
                ).Build();

                // Generate
                var generateResp = await client.AsymmetricGenerate(generateRequest);
                Assert.NotNull(generateResp.Result.EncodedPublicKey);
                Assert.NotNull(generateResp.Result.ID);
                Assert.Equal(1, generateResp.Result.Version);
                await AsymSigningCycle(generateResp.Result.ID);
            }
            catch (PangeaAPIException e)
            {
                Console.WriteLine(e.ToString());
                Assert.True(false);
            }
        }

        [Fact]
        public async Task TestJWTAsymES256SigningLifeCycle()
        {
            KeyPurpose purpose = KeyPurpose.JWT;
            AsymmetricAlgorithm algorithm = AsymmetricAlgorithm.ES256;
            string name = GetName();
            try
            {
                var generateRequest = new AsymmetricGenerateRequest.Builder(algorithm, purpose, name)
                    .Build();

                // Generate
                var generateResp = await client.AsymmetricGenerate(generateRequest);
                Assert.NotNull(generateResp.Result.EncodedPublicKey);
                Assert.NotNull(generateResp.Result.ID);
                Assert.Equal(1, generateResp.Result.Version);
                await JwtAsymSigningCycle(generateResp.Result.ID);
            }
            catch (PangeaAPIException e)
            {
                Console.WriteLine(e.ToString());
                Assert.True(false);
            }
        }

        [Fact]
        public async Task TestJWTSymHS256SigningLifeCycle()
        {
            KeyPurpose purpose = KeyPurpose.JWT;
            SymmetricAlgorithm algorithm = SymmetricAlgorithm.HS256;
            string name = GetName();
            try
            {
                var generateRequest = new SymmetricGenerateRequest.Builder(algorithm, purpose, name)
                    .Build();

                // Generate
                var generateResp = await client.SymmetricGenerate(generateRequest);
                Assert.NotNull(generateResp.Result.ID);
                Assert.Equal(1, generateResp.Result.Version);
                await JwtSymSigningCycle(generateResp.Result.ID);
            }
            catch (PangeaAPIException e)
            {
                Console.WriteLine(e.ToString());
                Assert.True(false);
            }
        }

        [Fact]
        public async Task TestSecretLifeCycle()
        {
            string secretV1 = "mysecret";
            string secretV2 = "mynewsecret";
            string name = GetName();
            try
            {
                var storeResponse = await client.SecretStore(new SecretStoreRequest.Builder(secretV1, name).Build());
                Assert.Equal(secretV1, storeResponse.Result.Secret);
                Assert.Equal(1, storeResponse.Result.Version);
                Assert.NotNull(storeResponse.Result.ID);

                var rotateResponse = await client.SecretRotate(
                    new SecretRotateRequest.Builder(storeResponse.Result.ID, secretV2)
                        .WithRotationState(ItemVersionState.Suspended)
                        .Build()
                );

                Assert.Equal(secretV2, rotateResponse.Result.Secret);
                Assert.Equal(2, rotateResponse.Result.Version);
                Assert.Equal(storeResponse.Result.ID, rotateResponse.Result.ID);

                var getResponse = await client.Get(new GetRequest.Builder(storeResponse.Result.ID).Build());
                Assert.Equal(secretV2, getResponse.Result.CurrentVersion?.Secret);

                var stateChangeResponse = await client.StateChange(
                    storeResponse.Result.ID,
                    1,
                    ItemVersionState.Deactivated
                );
                Assert.Equal(storeResponse.Result.ID, stateChangeResponse.Result.ID);
                Assert.Equal("deactivated", stateChangeResponse.Result.State);

                var getReponse2 = await client.Get(new GetRequest.Builder(storeResponse.Result.ID).Build());
                Assert.NotNull(getReponse2.Result.CurrentVersion?.Secret);
            }
            catch (PangeaAPIException e)
            {
                Console.WriteLine(e.ToString());
                Assert.True(false);
            }

        }

        [Fact]
        public async Task TestFolders()
        {
            string FOLDER_PARENT = $"test_parent_folder_{this.time}";
            string FOLDER_NAME = "test_folder_name";
            string FOLDER_NAME_NEW = "test_folder_name_new";

            try
            {
                // Create parent
                var createParentResp = await client.FolderCreate(
                    new FolderCreateRequest.Builder(FOLDER_PARENT, "/").Build()
                );
                string parentID = createParentResp.Result.ID;
                Assert.NotNull(parentID);

                // Create folder
                var createFolderResp = await client.FolderCreate(
                    new FolderCreateRequest.Builder(FOLDER_NAME, FOLDER_PARENT).Build()
                );
                string folderID = createFolderResp.Result.ID;
                Assert.NotNull(folderID);

                // Update name
                var updateResp = await client.Update(
                    new UpdateRequest.Builder(folderID).WithName(FOLDER_NAME_NEW).Build()
                );
                Assert.Equal(folderID, updateResp.Result.ID);

                // List
                var filter = new Dictionary<string, string>()
                {
                    { "folder", FOLDER_PARENT }
                };

                var listResp = await client.List(new ListRequest.Builder().WithFilter(filter).Build());
                Assert.Equal(1, listResp.Result.Count);
                Assert.Equal(folderID, listResp.Result.Items[0].ID);
                Assert.Equal(FOLDER_NAME_NEW, listResp.Result.Items[0].Name);

                // Delete folder
                var deleteFolderResp = await client.Delete(folderID);
                Assert.Equal(folderID, deleteFolderResp.Result.ID);

                // Delete folder
                var deleteParentResp = await client.Delete(parentID);
                Assert.Equal(parentID, deleteParentResp.Result.ID);
            }
            catch (PangeaAPIException e)
            {
                Console.WriteLine(e.ToString());
                Assert.True(false);
            }
        }

    }
}