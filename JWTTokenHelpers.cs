using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace Utils.Security.JWT
{
	public class JWTTokenHelpers
	{
		internal static string JSONSerialize(dynamic payload)
		{
			return Newtonsoft.Json.JsonConvert.SerializeObject(payload);
		}

		internal static string GetBase64URLEncoded(string raw)
		{
			string output = Convert.ToBase64String(Encoding.UTF8.GetBytes(raw));

			output = output.Split('=')[0];
			output = output.Replace('+', '-');
			output = output.Replace('/', '-');

			return output;
		}

		internal static JWTToken isValid<TPayload>(string token, KeyedHashAlgorithm algorithm, JWTAcceptedValues values) where TPayload : JWTPayload
		{
			List<string> tokenParts = new List<string>();
			try
			{
				tokenParts = token.Split('.').ToList();
			}
			catch
			{
				throw new JWTExceptions.JWTSplitException("Token split exception");
			}

			if(tokenParts.Count != 3)
			{
				throw new JWTExceptions.JWTSplitException("Token doesnot have 3 parts");
			}

			string currentSignature = "";
			try
			{
				currentSignature = JWTTokenHelpers.CreateSignature(tokenParts[0], tokenParts[1], algorithm);
				currentSignature = GetBase64URLEncoded(currentSignature);
				string oldSignature = tokenParts[2];
				if(oldSignature == null || !oldSignature.Equals(currentSignature))
				{
					throw new JWTExceptions.JWTSignatureException("Signature invalid");
				}
			}
			catch
			{
				throw new JWTExceptions.JWTSignatureException("Signature invalid");
			}

			try
			{
				for(int i = 0; i < 2; i++)
				{
					tokenParts[i] = GetBase64URLDecoded(tokenParts[i]);
				}
			}
			catch
			{
				throw new JWTExceptions.JWTDecodingExceptions("Token parts are not decodable");
			}

			JWTHeader header = new JWTHeader();
			TPayload payload;
			try
			{
				header = JSONDesialize<JWTHeader>(tokenParts[0]);
				payload = JSONDesialize<TPayload>(tokenParts[1]);
			}
			catch
			{
				throw new JWTExceptions.JWTDeserializeException("Data not parsable");
			}

			if(payload != null)
			{
				if(payload.ExpiryTime.Subtract(DateTime.Now) > values.ExpiryDuration)
				{
					throw new JWTExceptions.JWTExpiredException("JWT expired");
				}
				else if(payload.IpAddress == null || !payload.IpAddress.Equals(values.IpAddress))
				{
					throw new JWTExceptions.JWTIpAddressException("IP Address mismatch");
				}
				else if(payload.Audience == null || !payload.Audience.Equals(values.Audience))
				{
					throw new JWTExceptions.JWTIncorrectAudienceException("Audience incorrect");
				}
				else if(payload.Issuer == null || !payload.Issuer.Equals(values.Issuer))
				{
					throw new JWTExceptions.JWTIssuerIncorrectException("Issuer mismatch");
				}
				else
				{
					return new JWTToken()
					{
						Header = header,
						Payload = payload,
						Token = token
					};
				}
			}
			else
			{
				throw new JWTExceptions.JWTPayloadEmptyException("Payload null");
			}
		}

		private static T JSONDesialize<T>(string v)
		{
			return Newtonsoft.Json.JsonConvert.DeserializeObject<T>(v);
		}

		private static string GetBase64URLDecoded(string v)
		{
			string output = v;

			output = output.Replace('-', '+');
			output = output.Replace('_', '/');

			switch(output.Length % 4)
			{
				case 0:
					break;
				case 2:
					output += "==";
					break;
				case 3:
					output += "=";
					break;
				default:
					throw new ArgumentOutOfRangeException(nameof(v), "Illegal base64url string");
			}

			byte[] converted = Convert.FromBase64String(output);

			return Encoding.UTF8.GetString(converted);
		}

		internal static string CreateSignature(string headerEncoded, string payloadEncoded, KeyedHashAlgorithm algorithm)
		{
			string data = headerEncoded + "." + payloadEncoded;
			byte[] encrypted = algorithm.ComputeHash(Encoding.UTF8.GetBytes(data));
			return Encoding.UTF8.GetString(encrypted);
		}
	}
}
