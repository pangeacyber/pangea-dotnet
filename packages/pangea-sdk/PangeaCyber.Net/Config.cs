using System.Text;
using PangeaCyber.Net.Exceptions;

namespace PangeaCyber.Net
{
    /// <kind>class</kind>
    /// <summary>
    /// Config
    /// </summary>
    public sealed class Config
    {
        #region Constants

        /// <summary>
        /// Version of the package.
        /// </summary>
        /// <value>Version of the package.</value>
        public const string Version = "3.2.0";

        #endregion Constants


        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="Config" /> class
        /// </summary>
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

        ///
        public string Token { get; set; }

        ///
        public string Domain { get; set; }

        /// @deprecated set it on Service builder instead
        public string ConfigID { get; set; } = default!;

        ///
        public string Environment { get; set; }

        ///
        public bool Insecure { get; set; } = default!;

        ///
        public TimeSpan ConnectionTimeout { get; set; } = default!;

        ///
        public string CustomUserAgent { get; set; } = default!;

        /// Enable queued request retry support
        public bool QueuedRetryEnabled { get; set; } = true;

        /// Timeout used to poll results after 202 (in secs)
        public long PollResultTimeoutSecs = 30;

        #endregion Public Properties

        #region Public Methods
        ///
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

        ///
        public static string LoadEnvironmentVariable(string envVarName)
        {
            string value = System.Environment.GetEnvironmentVariable(envVarName) ?? string.Empty;
            if (string.IsNullOrEmpty(value))
            {
                throw new ConfigException("Need to set up " + envVarName + " environment variable");
            }
            return value;
        }

        ///
        public static string GetTestDomain(TestEnvironment environment)
        {
            string domainEnvVarName = "PANGEA_INTEGRATION_DOMAIN_" + environment.ToString();
            return LoadEnvironmentVariable(domainEnvVarName);
        }

        ///
        public static Config FromEnvironment(string serviceName)
        {
            string envVarName = string.Format("PANGEA_{0}_TOKEN", serviceName.ToUpper()).Replace('-', '_');
            string domainEnvVarName = "PANGEA_DOMAIN";

            string token = LoadEnvironmentVariable(envVarName);
            string domain = LoadEnvironmentVariable(domainEnvVarName);

            var config = new Config(token, domain);
            return config;
        }

        ///
        public static Config FromIntegrationEnvironment(TestEnvironment environment)
        {
            string token = GetTestToken(environment);
            string domain = GetTestDomain(environment);
            var cfg = new Config(token, domain)
            {
                ConnectionTimeout = new TimeSpan(0, 0, 120),
                CustomUserAgent = "test"
            };
            return cfg;
        }

        ///
        public static Config FromVaultIntegrationEnvironment(TestEnvironment environment)
        {
            string token = GetVaultSignatureTestToken(environment);
            string domain = GetTestDomain(environment);
            var cfg = new Config(token, domain)
            {
                CustomUserAgent = "test",
                ConnectionTimeout = new TimeSpan(0, 0, 60)
            };
            return cfg;
        }

        ///
        public static Config FromCustomSchemaIntegrationEnvironment(TestEnvironment environment)
        {
            string token = GetCustomSchemaTestToken(environment);
            string domain = GetTestDomain(environment);
            var cfg = new Config(token, domain)
            {
                ConnectionTimeout = new TimeSpan(0, 0, 60),
                CustomUserAgent = "test"
            };
            return cfg;
        }

        ///
        public static string GetTestToken(TestEnvironment environment)
        {
            string envVarName = "PANGEA_INTEGRATION_TOKEN_" + environment.ToString();
            return LoadEnvironmentVariable(envVarName);
        }

        ///
        public static string GetVaultSignatureTestToken(TestEnvironment environment)
        {
            string envVarName = "PANGEA_INTEGRATION_VAULT_TOKEN_" + environment.ToString();
            return LoadEnvironmentVariable(envVarName);
        }

        ///
        public static string GetMultiConfigTestToken(TestEnvironment environment)
        {
            string envVarName = "PANGEA_INTEGRATION_MULTI_CONFIG_TOKEN_" + environment.ToString();
            return LoadEnvironmentVariable(envVarName);
        }

        ///
        public static string GetCustomSchemaTestToken(TestEnvironment environment)
        {
            string envVarName = "PANGEA_INTEGRATION_CUSTOM_SCHEMA_TOKEN_" + environment.ToString();
            return LoadEnvironmentVariable(envVarName);
        }

        ///
        public static string GetConfigID(TestEnvironment environment, string service, int configNumber)
        {
            string envVarName = string.Format("PANGEA_{0}_CONFIG_ID_{1}_{2}", service.ToUpper().Replace('-', '_'), configNumber, environment.ToString());
            return LoadEnvironmentVariable(envVarName);
        }
        #endregion Static Methods
    }
};
