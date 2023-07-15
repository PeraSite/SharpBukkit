using System.Security.Cryptography;
using SharpBukkit.Network.API.Crypto;
using SharpMC.Util.Encryption;

namespace SharpBukkit.Network.Crypto;

public class CryptoService : ICryptoService {
	private readonly RSACryptoServiceProvider _rsa;

	public CryptoService() {
		_rsa = new RSACryptoServiceProvider();
	}

	public byte[] GetRsaPublicKey() {
		var publicKey = _rsa.ExportParameters(false);
		return AsnKeyBuilder.PublicKeyToX509(publicKey).GetBytes();
	}

	public void InitializeAesKey(byte[] key) { }

	public byte[] EncryptRsa(byte[] input) {
		return _rsa.Encrypt(input, false);
	}

	public byte[] DecryptRsa(byte[] encrypted) {
		return _rsa.Decrypt(encrypted, false);
	}
}
