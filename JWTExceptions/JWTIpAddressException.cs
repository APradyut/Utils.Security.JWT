using System;
using System.Runtime.Serialization;

namespace Utils.Security.JWT.JWTExceptions
{
	[Serializable]
	public class JWTIpAddressException : Exception
	{
		public JWTIpAddressException()
		{
		}

		public JWTIpAddressException(string message) : base(message)
		{
		}

		public JWTIpAddressException(string message, Exception innerException) : base(message, innerException)
		{
		}
	}
}