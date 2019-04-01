using System;
using System.Runtime.Serialization;

namespace Utils.Security.JWT.JWTExceptions
{
	[Serializable]
	public class JWTIssuerIncorrectException : Exception
	{
		public JWTIssuerIncorrectException()
		{
		}

		public JWTIssuerIncorrectException(string message) : base(message)
		{
		}

		public JWTIssuerIncorrectException(string message, Exception innerException) : base(message, innerException)
		{
		}
	}
}