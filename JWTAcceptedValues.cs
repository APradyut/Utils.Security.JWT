using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utils.Security.JWT
{
	public class JWTAcceptedValues
	{
		public TimeSpan ExpiryDuration { get; set; }
		public string IpAddress { get; set; }
		public string Audience { get; set; }
		public string Issuer { get; set; }
		public JWTAcceptedValues(TimeSpan expiryDuration, string ipAddress, string audience, string issuer)
		{
			ExpiryDuration = expiryDuration;
			IpAddress = ipAddress;
			Audience = audience;
			Issuer = issuer;
		}
	}
}
