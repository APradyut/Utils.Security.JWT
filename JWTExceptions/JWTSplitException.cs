using System;
using System.Runtime.Serialization;

namespace Utils.Security.JWT.JWTExceptions
{
	[Serializable]
	public class JWTSplitException : Exception
	{
		public JWTSplitException()
		{
		}

		public JWTSplitException(string message) : base(message)
		{
		}

		public JWTSplitException(string message, Exception innerException) : base(message, innerException)
		{
		}
	}
}