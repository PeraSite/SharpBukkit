using System.Security.Cryptography;

namespace SharpBukkit.Net.Crypto;

public class CryptoService {
	private readonly RSACryptoServiceProvider _rsa;
	private readonly byte[] _rsaPublicKey;

	public CryptoService() {
		_rsa = new RSACryptoServiceProvider();
		var publicKey = _rsa.ExportParameters(false);
		_rsaPublicKey = AsnKeyBuilder.PublicKeyToX509(publicKey).GetBytes();
	}

	public byte[] GetRsaPublicKey() {
		return _rsaPublicKey;
	}

	public byte[] EncryptRsa(byte[] input) {
		return _rsa.Encrypt(input, false);
	}

	public byte[] DecryptRsa(byte[] encrypted) {
		return _rsa.Decrypt(encrypted, false);
	}
}
