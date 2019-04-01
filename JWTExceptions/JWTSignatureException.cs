using System;
using System.Runtime.Serialization;

namespace Utils.Security.JWT.JWTExceptions
{
	[Serializable]
	public class JWTSignatureException : Exception
	{
		public JWTSignatureException()
		{
		}

		public JWTSignatureException(string message) : base(message)
		{
		}

		public JWTSignatureException(string message, Exception innerException) : base(message, innerException)
		{
		}
	}
}