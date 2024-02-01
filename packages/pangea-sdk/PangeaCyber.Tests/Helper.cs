using PangeaCyber.Net;

namespace PangeaCyber.Tests
{
    public class Helper
    {
        public static TestEnvironment LoadTestEnvironment(string serviceName, TestEnvironment def)
        {
            serviceName = serviceName.Replace("-", "_").ToUpper();
            string envVarName = $"SERVICE_{serviceName}_ENV";
            string? value = Environment.GetEnvironmentVariable(envVarName);

            if (string.IsNullOrEmpty(value))
            {
                Console.WriteLine($"{envVarName} is not set. Return default test environment value: {def}");
                return def;
            }
            else if (value.Equals("DEV", StringComparison.OrdinalIgnoreCase))
            {
                return TestEnvironment.DEV;
            }
            else if (value.Equals("STG", StringComparison.OrdinalIgnoreCase))
            {
                return TestEnvironment.STG;
            }
            else if (value.Equals("LVE", StringComparison.OrdinalIgnoreCase))
            {
                return TestEnvironment.LVE;
            }
            else
            {
                throw new Exception($"{envVarName} has an invalid value: {value}");
            }
        }
    }
}
