
using System;
namespace PangeaCyber.Net.Exceptions
{
    /// <kind>class</kind>
    /// <summary>
    /// ServiceNotEnabledException
    /// </summary>
    public class ServiceNotEnabledException : PangeaAPIException
    {
        ///
        public ServiceNotEnabledException(string serviceName, Response<PangeaErrors> response) : base(String.Format("{0} is not enabled. Go to console.pangea.cloud/service/{1} to enable", serviceName, serviceName), response)
        {
        }
    }
}

