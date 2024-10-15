using Newtonsoft.Json;

namespace PangeaCyber.Net.Vault.Results
{
    /// <summary>Result of a key export.</summary>
    public sealed class ExportResult
    {
        /// <summary>The ID of the key to use.</summary>
        [JsonProperty("id")]
        public string ID { get; set; } = default!;

        /// <summary>The item version. Defaults to the current version.</summary>
        [JsonProperty("version")]
        public int Version { get; set; } = default!;

        /// <summary>The type of the key.</summary>
        [JsonProperty("type")]
        public string Type { get; set; } = default!;

        /// <summary>True if the item is enabled.</summary>
        [JsonProperty("enabled")]
        public bool Enabled { get; set; } = default!;

        /// <summary>The algorithm of the key.</summary>
        [JsonProperty("algorithm")]
        public string Algorithm { get; set; } = default!;

        /// <summary>The public key (in PEM format).</summary>
        [JsonProperty("public_key")]
        public string PublicKey { get; set; } = default!;

        /// <summary>The private key (in PEM format).</summary>
        [JsonProperty("private_key")]
        public string PrivateKey { get; set; } = default!;

        /// <summary>The key material.</summary>
        [JsonProperty("key")]
        public string Key { get; set; } = default!;

        /// <summary>
        /// Encryption format of the exported key(s). It could be none if returned in plain text, asymmetric if it is encrypted just with the public key sent in asymmetric_public_key, or kem if it was encrypted using KEM protocol.
        /// </summary>
        [JsonProperty("encryption_type")]
        public string EncryptionType { get; set; } = default!;

        /// <summary>The algorithm of the public key used to encrypt exported material.</summary>
        [JsonProperty("asymmetric_algorithm")]
        public string AsymmetricAlgorithm { get; set; } = default!;

        /// <summary>The algorithm of the symmetric key used to encrypt exported material.</summary>
        [JsonProperty("symmetric_algorithm")]
        public string SymmetricAlgorithm { get; set; } = default!;

        /// <summary>Key derivation function used to derivate the symmetric key when `encryption_type` is `kem`.</summary>
        [JsonProperty("kdf")]
        public string KDF { get; set; } = default!;

        /// <summary>Hash algorithm used to derivate the symmetric key when `encryption_type` is `kem`.</summary>
        [JsonProperty("hash_algorithm")]
        public string HashAlgorithm { get; set; } = default!;

        /// <summary>Salt used to derivate the symmetric key when `encryption_type` is `kem`, encrypted with the public key provided in `asymmetric_key`.</summary>
        [JsonProperty("encrypted_salt")]
        public string EncryptedSalt { get; set; } = default!;

        /// <summary>Iteration count used to derivate the symmetric key when `encryption_type` is `kem`.</summary>
        [JsonProperty("iteration_count")]
        public int IterationCount { get; set; } = default!;

        /// <summary>Constructor.</summary>
        public ExportResult()
        {
        }
    }
}
