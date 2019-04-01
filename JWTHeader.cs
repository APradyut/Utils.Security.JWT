using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utils.Security.JWT
{
	public class JWTHeader
	{
		public string alg { get; set; }
		public string typ { get; set; }
	}
}
