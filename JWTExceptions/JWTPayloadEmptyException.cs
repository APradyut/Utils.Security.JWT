using System;
using System.Runtime.Serialization;

namespace Utils.Security.JWT.JWTExceptions
{
	[Serializable]
	public class JWTPayloadEmptyException : Exception
	{
		public JWTPayloadEmptyException()
		{
		}

		public JWTPayloadEmptyException(string message) : base(message)
		{
		}

		public JWTPayloadEmptyException(string message, Exception innerException) : base(message, innerException)
		{
		}
	}
}