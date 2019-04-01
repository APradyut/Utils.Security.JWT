using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utils.Security.JWT
{
	public class JWTToken
	{
		public string Token { get; set; }
		public JWTHeader Header { get; set; }
		public JWTPayload Payload { get; set; }
	}
}
