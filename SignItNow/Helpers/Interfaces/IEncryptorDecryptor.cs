namespace SignItNow.Helpers.Interfaces
{
	public interface IEncryptorDecryptor
	{
		public string Encrypt(string text);
		public string Decrypt(string text);
	}
}