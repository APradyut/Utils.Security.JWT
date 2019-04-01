using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Utils.Security.JWT.Builder
{
	public class JWTBuilder : IJWTBuilder
	{
		private JWTHeader JWTHeader = null;
		private KeyedHashAlgorithm algorithm = null;
		public JWT<TPayload> Build<TPayload>() where TPayload : JWTPayload
		{
			if(JWTHeader == null)
			{
				throw new JWTExceptions.JWTBuildException("Header cannot be null");
			}
			if(algorithm == null)
			{
				throw new JWTExceptions.JWTBuildException("Algorithm cannot be null");
			}
			return new JWT<TPayload>(JWTHeader, algorithm);
		}

		public IJWTBuilder WithHeader(JWTHeader header)
		{
			JWTHeader = header;
			return this;
		}

		public IJWTBuilder WithAlgorithm(KeyedHashAlgorithm algorithm)
		{
			this.algorithm = algorithm;
			return this;
		}
	}
}
