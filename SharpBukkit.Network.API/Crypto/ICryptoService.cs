namespace SharpBukkit.Network.API.Crypto;

public interface ICryptoService {
	byte[] GetRsaPublicKey();

	byte[] EncryptRsa(byte[] input);

	byte[] DecryptRsa(byte[] encrypted);
}
