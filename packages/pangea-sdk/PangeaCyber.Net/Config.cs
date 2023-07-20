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
        public const string Version = "2.0.0";

        #endregion Constants


        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="Config" /> class
        /// </summary>
        public Config(string token, string domain)
        {
            this.Token = token;
            this.Domain = domain;
            this.Insecure = false;
            this.Environment = "production";
            // 20 seconds initial connection timeout
            this.ConnectionTimeout = new TimeSpan(0, 0, 20);
        }

        #endregion Constructors


        #region Public Properties

        ///        
        public string Token { get; set; }

        ///        
        public string Domain { get; set; }

        ///
        public string ConfigID {get; set;} = default!;

        ///        
        public string Environment { get; set; }

        ///
        public bool Insecure { get; set; } = default!;

        ///        
        public TimeSpan ConnectionTimeout { get; set; } = default!;

        ///
        public string CustomUserAgent {get; set; } = default!;

        #endregion Public Properties

        #region Public Methods
        ///
        public Uri GetServiceUrl(string serviceName, string path)
        {
            StringBuilder b = new StringBuilder();
            b.Append(!this.Insecure ? "https://" : "http://");

            if (!this.Environment.Equals("local", StringComparison.CurrentCultureIgnoreCase))
            {
                b.Append(serviceName);
                b.Append('.');
            }

            b.Append(this.Domain);
            b.Append(path);
            return new Uri(b.ToString());
        }
        #endregion Public Methods

        #region Static Methods

        private static string LoadEnvironmentVariable(string envVarName){
            string value = System.Environment.GetEnvironmentVariable(envVarName) ?? string.Empty;
            if (String.IsNullOrEmpty(value))
            {
                throw new ConfigException("Need to set up " + envVarName + " environment variable");
            }
            return value;
        }

        ///
        public static string GetTestDomain(TestEnvironment environment){
            string domainEnvVarName = "PANGEA_INTEGRATION_DOMAIN_" + environment.ToString();
            return LoadEnvironmentVariable(domainEnvVarName);
        }

        ///
        public static Config FromEnvironment(string serviceName)
        {
            string envVarName = String.Format("PANGEA_{0}_TOKEN", serviceName.ToUpper()).Replace('-', '_');
            string domainEnvVarName = "PANGEA_DOMAIN";

            string token = LoadEnvironmentVariable(envVarName);
            string domain = LoadEnvironmentVariable(domainEnvVarName);

            Config config = new Config(token, domain);
            return config;
        }

        ///
        public static Config FromIntegrationEnvironment(TestEnvironment environment)
        {
            string token = GetTestToken(environment);
            string domain = GetTestDomain(environment);
            var cfg = new Config(token, domain);
            cfg.ConnectionTimeout = new TimeSpan(0, 0, 60);
            cfg.CustomUserAgent = "test";
            return cfg;
        }

        ///
        public static Config FromVaultIntegrationEnvironment(TestEnvironment environment)
        {
            string token = GetVaultSignatureTestToken(environment);
            string domain = GetTestDomain(environment);
            var cfg = new Config(token, domain);
            cfg.CustomUserAgent = "test";
            cfg.ConnectionTimeout = new TimeSpan(0, 0, 60);
            return cfg;
        }

        ///
        public static Config FromCustomSchemaIntegrationEnvironment(TestEnvironment environment)
        {
            string token = GetCustomSchemaTestToken(environment);
            string domain = GetTestDomain(environment);
            var cfg = new Config(token, domain);
            cfg.ConnectionTimeout = new TimeSpan(0, 0, 60);
            cfg.CustomUserAgent = "test";
            return cfg;
        }

        ///
        public static string GetTestToken(TestEnvironment environment){
            string envVarName = "PANGEA_INTEGRATION_TOKEN_" + environment.ToString();
            return LoadEnvironmentVariable(envVarName);
        }

        ///
        public static string GetVaultSignatureTestToken(TestEnvironment environment){
            string envVarName = "PANGEA_INTEGRATION_VAULT_TOKEN_" + environment.ToString();
            return LoadEnvironmentVariable(envVarName);
        }

        ///
        public static string GetMultiConfigTestToken(TestEnvironment environment){
            string envVarName = "PANGEA_INTEGRATION_MULTI_CONFIG_TOKEN_" + environment.ToString();
            return LoadEnvironmentVariable(envVarName);
        }

        ///
        public static string GetCustomSchemaTestToken(TestEnvironment environment){
            string envVarName = "PANGEA_INTEGRATION_CUSTOM_SCHEMA_TOKEN_" + environment.ToString();
            return LoadEnvironmentVariable(envVarName);
        }

        ///
        public static string GetConfigID(TestEnvironment environment, string service, int configNumber){
            string envVarName = String.Format("PANGEA_{0}_CONFIG_ID_{1}_{2}", service.ToUpper().Replace('-', '_'), configNumber, environment.ToString());
            return LoadEnvironmentVariable(envVarName);
        }
        #endregion Static Methods
    }
};