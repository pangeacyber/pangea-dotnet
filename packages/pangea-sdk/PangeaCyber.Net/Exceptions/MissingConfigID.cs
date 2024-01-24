using System;

namespace PangeaCyber.Net.Exceptions
{
    /// <kind>class</kind>
    /// <summary>
    /// MissingConfigID
    /// </summary>
    public class MissingConfigID : PangeaAPIException
    {
        ///
        public MissingConfigID(string serviceName, Response<PangeaErrors> response) : base(String.Format("\"Token did not contain a config scope for service {0}. Create a new token or provide a config ID explicitly in the service base\"", serviceName), response)
        {
        }
    }
}
