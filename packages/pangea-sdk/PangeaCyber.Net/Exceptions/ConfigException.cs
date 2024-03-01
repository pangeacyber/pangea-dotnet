using System;
namespace PangeaCyber.Net.Exceptions
{
    /// <kind>class</kind>
    /// <summary>
    /// Config
    /// </summary>
    public class ConfigException : Exception
    {
        ///
        public ConfigException(string message) : base(message)
        {
        }
    }
}
