using System;
using System.Runtime.Serialization;

namespace Utils.Security.JWT.JWTExceptions
{
	[Serializable]
	public class JWTDeserializeException : Exception
	{
		public JWTDeserializeException()
		{
		}

		public JWTDeserializeException(string message) : base(message)
		{
		}

		public JWTDeserializeException(string message, Exception innerException) : base(message, innerException)
		{
		}
	}
}