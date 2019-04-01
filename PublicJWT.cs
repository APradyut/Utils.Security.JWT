using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace Utils.Security.JWT
{
    public class JWT<TPayload> where TPayload: JWTPayload
    {
		internal TPayload Payload { get; set; }
		public JWTHeader Header { get; set; }
		private System.Security.Cryptography.KeyedHashAlgorithm Algorithm;

		internal JWT(JWTHeader header, KeyedHashAlgorithm algorithm)
		{
			Header = header;
			Algorithm = algorithm;
		}

		public JWTToken GetToken(TPayload payload)
		{
			if(payload == null)
			{
				throw new JWTExceptions.JWTPayloadNullExceptions("Payload is null");
			}
			this.Payload = payload;
			string payloadJson = JWTTokenHelpers.JSONSerialize(payload);
			string headerJson = JWTTokenHelpers.JSONSerialize(Header);
			string payloadEncoded = JWTTokenHelpers.GetBase64URLEncoded(payloadJson);
			string headerEncoded = JWTTokenHelpers.GetBase64URLEncoded(headerJson);
			string signature = JWTTokenHelpers.CreateSignature(headerEncoded, payloadEncoded, Algorithm);
			signature = JWTTokenHelpers.GetBase64URLEncoded(signature);
			string token = headerEncoded + "." + payloadEncoded + "." + signature;
			return new JWTToken()
			{
				Token = token,
				Header = Header,
				Payload = payload
			};
		}
		public JWTToken CheckValidToken(string token, JWTAcceptedValues values)
		{
			try
			{
				return JWTTokenHelpers.isValid<TPayload>(token, Algorithm, values);
			}
			catch
			{
				throw;
			}
		}
	}
}
