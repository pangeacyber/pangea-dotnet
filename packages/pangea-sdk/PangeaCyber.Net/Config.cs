using System.Text;
using PangeaCyber.Net.Exceptions;

namespace PangeaCyber.Net
{
    /// <summary>
    /// Configuration for a Pangea service client.
    /// </summary>
    public sealed class Config
    {
        #region Constants

        /// <summary>
        /// Version of the package.
        /// </summary>
        /// <value>Version of the package.</value>
        public const string Version = "3.7.0";

        #endregion Constants


        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="Config" /> class
        /// </summary>
        /// <param name="token">Pangea API token.</param>
        /// <param name="domain">Pangea API domain.</param>
        public Config(string token, string domain)
        {
            Token = token;
            Domain = domain;
            Insecure = false;
            Environment = "production";
            // 20 seconds initial connection timeout
            ConnectionTimeout = new TimeSpan(0, 0, 20);
        }

        #endregion Constructors


        #region Public Properties

        /// <summary>Pangea API token.</summary>
        public string Token { get; set; }

        /// <summary>Pangea API domain.</summary>
        public string Domain { get; set; }

        /// <exclude />
        [Obsolete("Set config ID when building service clients instead.")]
        public string ConfigID { get; set; } = default!;

        /// <summary>Pangea environment.</summary>
        /// <remarks>
        /// This is intended to facilitate SDK development and should not be touched in everyday usage.
        /// </remarks>
        public string Environment { get; set; }

        /// <summary>Whether or not to perform requests via plain HTTP, as opposed to secure HTTPS.</summary>
        public bool Insecure { get; set; }

        /// <summary>Time span to wait before a HTTP request times out.</summary>
        public TimeSpan ConnectionTimeout { get; set; }

        /// <summary>User-Agent string to append to the default one.</summary>
        public string CustomUserAgent { get; set; } = default!;

        /// <summary>Whether or not queued request retries are enabled.</summary>
        public bool QueuedRetryEnabled { get; set; } = true;

        /// <summary>Timeout for polling results after a HTTP/202 (in seconds).</summary>
        public long PollResultTimeoutSecs = 120;

        #endregion Public Properties

        #region Public Methods
        /// <summary>Constructs an API URL from the given service name and endpoint path.</summary>
        /// <param name="serviceName">Pangea service name.</param>
        /// <param name="path">API endpoint path.</param>
        /// <returns>Constructed API URL.</returns>
        public Uri GetServiceUrl(string serviceName, string path)
        {
            StringBuilder b = new();
            b.Append(!Insecure ? "https://" : "http://");

            if (!Environment.Equals("local", StringComparison.CurrentCultureIgnoreCase))
            {
                b.Append(serviceName);
                b.Append('.');
            }

            b.Append(Domain);
            b.Append(path);
            return new Uri(b.ToString());
        }
        #endregion Public Methods

        #region Static Methods

        /// <summary>Returns the given environment variable.</summary>
        /// <param name="envVarName">Environment variable name.</param>
        /// <returns>Environment variable value.</returns>
        /// <exception cref="ConfigException">Environment variable could not be found.</exception>
        public static string LoadEnvironmentVariable(string envVarName)
        {
            string value = System.Environment.GetEnvironmentVariable(envVarName) ?? string.Empty;
            if (string.IsNullOrEmpty(value))
            {
                throw new ConfigException("Need to set up " + envVarName + " environment variable");
            }
            return value;
        }

        /// <summary>Returns the Pangea domain for the given test environment.</summary>
        /// <param name="environment">Test environment.</param>
        public static string GetTestDomain(TestEnvironment environment)
        {
            string domainEnvVarName = "PANGEA_INTEGRATION_DOMAIN_" + environment.ToString();
            return LoadEnvironmentVariable(domainEnvVarName);
        }

        /// <summary>
        /// Constructs a <see cref="Config" /> for the given Pangea service, using values from environment variables.
        /// </summary>
        /// <param name="serviceName">Pangea service name.</param>
        public static Config FromEnvironment(string serviceName)
        {
            string envVarName = string.Format("PANGEA_{0}_TOKEN", serviceName.ToUpper()).Replace('-', '_');
            const string domainEnvVarName = "PANGEA_DOMAIN";

            string token = LoadEnvironmentVariable(envVarName);
            string domain = LoadEnvironmentVariable(domainEnvVarName);

            return new Config(token, domain);
        }

        /// <summary>
        /// Constructs a <see cref="Config" /> for the given test environment, using values from environment variables.
        /// </summary>
        /// <param name="environment">Test environment</param>
        public static Config FromIntegrationEnvironment(TestEnvironment environment)
        {
            string token = GetTestToken(environment);
            string domain = GetTestDomain(environment);
            return new Config(token, domain)
            {
                ConnectionTimeout = new TimeSpan(0, 0, 120),
                CustomUserAgent = "test"
            };
        }

        /// <summary>
        /// Constructs a <see cref="Config" /> for the given test environment, using values from environment variables,
        /// intended for Vault integration tests specifically.
        /// </summary>
        /// <param name="environment">Test environment</param>
        public static Config FromVaultIntegrationEnvironment(TestEnvironment environment)
        {
            string token = GetVaultSignatureTestToken(environment);
            string domain = GetTestDomain(environment);
            return new Config(token, domain)
            {
                CustomUserAgent = "test",
                ConnectionTimeout = new TimeSpan(0, 0, 60)
            };
        }

        /// <summary>
        /// Constructs a <see cref="Config" /> for the given test environment, using values from environment variables,
        /// intended for custom schema integration tests specifically.
        /// </summary>
        /// <param name="environment">Test environment</param>
        public static Config FromCustomSchemaIntegrationEnvironment(TestEnvironment environment)
        {
            string token = GetCustomSchemaTestToken(environment);
            string domain = GetTestDomain(environment);
            return new Config(token, domain)
            {
                ConnectionTimeout = new TimeSpan(0, 0, 60),
                CustomUserAgent = "test"
            };
        }

        /// <summary>
        /// Returns a Pangea API token for the given test environment.
        /// </summary>
        /// <param name="environment">Test environment</param>
        public static string GetTestToken(TestEnvironment environment)
        {
            string envVarName = "PANGEA_INTEGRATION_TOKEN_" + environment.ToString();
            return LoadEnvironmentVariable(envVarName);
        }

        /// <summary>
        /// Returns a Pangea API token for the given test environment, intended for Vault integration tests
        /// specifically.
        /// </summary>
        /// <param name="environment">Test environment</param>
        public static string GetVaultSignatureTestToken(TestEnvironment environment)
        {
            string envVarName = "PANGEA_INTEGRATION_VAULT_TOKEN_" + environment.ToString();
            return LoadEnvironmentVariable(envVarName);
        }

        /// <summary>
        /// Returns a Pangea API token for the given test environment, intended for multi-config integration tests
        /// specifically.
        /// </summary>
        /// <param name="environment">Test environment</param>
        public static string GetMultiConfigTestToken(TestEnvironment environment)
        {
            string envVarName = "PANGEA_INTEGRATION_MULTI_CONFIG_TOKEN_" + environment.ToString();
            return LoadEnvironmentVariable(envVarName);
        }

        /// <summary>
        /// Returns a Pangea API token for the given test environment, intended for custom schema integration tests
        /// specifically.
        /// </summary>
        /// <param name="environment">Test environment</param>
        public static string GetCustomSchemaTestToken(TestEnvironment environment)
        {
            string envVarName = "PANGEA_INTEGRATION_CUSTOM_SCHEMA_TOKEN_" + environment.ToString();
            return LoadEnvironmentVariable(envVarName);
        }

        /// <summary>
        /// Returns a Pangea config ID for the given test environment and service.
        /// </summary>
        /// <param name="environment">Test environment.</param>
        /// <param name="service">Pangea service name.</param>
        /// <param name="configNumber">Config ID number.</param>
        public static string GetConfigID(TestEnvironment environment, string service, int configNumber)
        {
            string envVarName = string.Format("PANGEA_{0}_CONFIG_ID_{1}_{2}", service.ToUpper().Replace('-', '_'), configNumber, environment.ToString());
            return LoadEnvironmentVariable(envVarName);
        }
        #endregion Static Methods
    }
};
