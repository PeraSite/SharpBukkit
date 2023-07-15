namespace SharpBukkit.Network.API.Crypto;

public interface ICryptoService {
	byte[] GetRsaPublicKey();

	void InitializeAesKey(byte[] key);

	byte[] EncryptRsa(byte[] input);

	byte[] DecryptRsa(byte[] encrypted);
}
