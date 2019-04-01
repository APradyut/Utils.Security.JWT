using System;
using System.Runtime.Serialization;

namespace Utils.Security.JWT.JWTExceptions
{
	[Serializable]
	public class JWTDecodingExceptions : Exception
	{
		public JWTDecodingExceptions()
		{
		}

		public JWTDecodingExceptions(string message) : base(message)
		{
		}

		public JWTDecodingExceptions(string message, Exception innerException) : base(message, innerException)
		{
		}
	}
}