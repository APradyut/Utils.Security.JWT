using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utils.Security.JWT
{
	public abstract class JWTPayload
	{
		public DateTime IssueTime { get; set; }
		public DateTime ExpiryTime { get; set; }
		public string Issuer { get; set; }
		public string Audience { get; set; }
		public string IpAddress { get; set; }
	}
}
