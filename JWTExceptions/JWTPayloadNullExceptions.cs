using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utils.Security.JWT.JWTExceptions
{
	public class JWTPayloadNullExceptions : Exception
	{
		public JWTPayloadNullExceptions(string message) : base(message)
		{
		}
	}
}
