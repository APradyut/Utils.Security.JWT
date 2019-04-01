using System;
using System.Runtime.Serialization;

namespace Utils.Security.JWT.JWTExceptions
{
	[Serializable]
	public class JWTIncorrectAudienceException : Exception
	{
		public JWTIncorrectAudienceException()
		{
		}

		public JWTIncorrectAudienceException(string message) : base(message)
		{
		}

		public JWTIncorrectAudienceException(string message, Exception innerException) : base(message, innerException)
		{
		}
	}
}