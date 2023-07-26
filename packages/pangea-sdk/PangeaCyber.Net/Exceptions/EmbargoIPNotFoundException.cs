
using System;
namespace PangeaCyber.Net.Exceptions
{
    /// <kind>class</kind>
    /// <summary>
    /// EmbargoIPNotFoundException
    /// </summary>
    public class EmbargoIPNotFoundException : PangeaAPIException
    {
        ///
        public EmbargoIPNotFoundException(string message, Response<PangeaErrors> response) : base(message, response)
        {
        }
    }
}
