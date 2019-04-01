using System;
using System.Runtime.Serialization;

namespace Utils.Security.JWT.JWTExceptions
{
	[Serializable]
	public class JWTExpiredException : Exception
	{
		public JWTExpiredException()
		{
		}

		public JWTExpiredException(string message) : base(message)
		{
		}

		public JWTExpiredException(string message, Exception innerException) : base(message, innerException)
		{
		}
	}
}