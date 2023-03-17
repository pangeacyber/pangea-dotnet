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
        public const string Version = "1.0.0";

        #endregion Constants


        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="Configuration" /> class
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
        public string Environment { get; set; }

        ///
        public bool Insecure { get; set; } = default!;

        ///        
        public TimeSpan ConnectionTimeout { get; set; } = default!;

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
        ///
        public static Config FromEnvironment(string serviceName)
        {
            string tokenEnvVarName = String.Format("PANGEA_{0}_TOKEN", serviceName.ToUpper()).Replace('-', '_');

            string token = System.Environment.GetEnvironmentVariable(tokenEnvVarName) ?? string.Empty;
            if (String.IsNullOrEmpty(token))
            {
                throw new ConfigException("Need to set up " + tokenEnvVarName + " environment variable");
            }

            string domain = System.Environment.GetEnvironmentVariable("PANGEA_DOMAIN") ?? string.Empty;
            if (String.IsNullOrEmpty(domain))
            {
                throw new ConfigException("Need to set up PANGEA_DOMAIN environment variable");
            }

            Config config = new Config(token, domain);
            return config;
        }

        ///
        public static Config FromIntegrationEnvironment(TestEnvironment environment)
        {
            string tokenEnvVarName = "PANGEA_INTEGRATION_TOKEN_" + environment.ToString();
            string token = System.Environment.GetEnvironmentVariable(tokenEnvVarName) ?? string.Empty;
            if (String.IsNullOrEmpty(token))
            {
                throw new ConfigException("Need to set up " + tokenEnvVarName + " environment variable");
            }

            string domainEnvVarName = "PANGEA_INTEGRATION_DOMAIN_" + environment.ToString();
            string domain = System.Environment.GetEnvironmentVariable(domainEnvVarName) ?? string.Empty;
            if (String.IsNullOrEmpty(domain))
            {
                throw new ConfigException("Need to set up " + domainEnvVarName + " environment variable");
            }

            Config config = new Config(token, domain);
            return config;
        }
        #endregion Static Methods
    }
};