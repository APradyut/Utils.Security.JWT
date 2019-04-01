using System.Security.Cryptography;
using System.Text;

namespace Utils.Security.JWT.Builder
{
	public interface IJWTBuilder
	{
		JWT<TPayload> Build<TPayload>() where TPayload : JWTPayload;
		IJWTBuilder WithHeader(JWTHeader header);
		IJWTBuilder WithAlgorithm(KeyedHashAlgorithm algorithm);
	}
}
