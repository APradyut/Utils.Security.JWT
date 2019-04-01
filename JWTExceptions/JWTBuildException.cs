using System;
using System.Runtime.Serialization;

namespace Utils.Security.JWT.JWTExceptions
{
	[Serializable]
	internal class JWTBuildException : Exception
	{
		public JWTBuildException()
		{
		}

		public JWTBuildException(string message) : base(message)
		{
		}

		public JWTBuildException(string message, Exception innerException) : base(message, innerException)
		{
		}
	}
}