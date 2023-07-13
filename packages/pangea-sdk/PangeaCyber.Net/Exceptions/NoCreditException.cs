
using System;
namespace PangeaCyber.Net.Exceptions
{
	/// <kind>class</kind>
    /// <summary>
    /// NoCreditException
    /// </summary>
	public class NoCreditException : PangeaAPIException
    {
		///
		public NoCreditException(string message, Response<PangeaErrors> response): base(message, response)
		{
		}
	}
}

