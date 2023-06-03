using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using SignItNow.Helpers.Interfaces;

namespace SignItNow.Helpers
{
    public class EncryptorDecryptor: IEncryptorDecryptor
    {
        private static readonly byte[] key = Encoding.UTF8.GetBytes("3s6v9y$B&E(H+MbQ");
        private static readonly byte[] iv = Encoding.UTF8.GetBytes("z%C*F-JaNdRgUkXn");

        public string Encrypt(string plainText)
        {
            using (Aes aesAlg = Aes.Create())
            {
                aesAlg.Key = key;
                aesAlg.IV = iv;

                ICryptoTransform encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);

                using (MemoryStream memoryStream = new MemoryStream())
                {
                    using (CryptoStream cryptoStream = new CryptoStream(memoryStream, encryptor, CryptoStreamMode.Write))
                    {
                        using (StreamWriter writer = new StreamWriter(cryptoStream))
                        {
                            writer.Write(plainText);
                        }
                    }

                    byte[] encryptedData = memoryStream.ToArray();
                    return Convert.ToBase64String(encryptedData);
                }
            }
        }

        public string Decrypt(string encryptedText)
        {
	        if (string.IsNullOrEmpty(encryptedText))
	        {
		        return "";
	        }

            byte[] encryptedData = Convert.FromBase64String(encryptedText);

            using (Aes aesAlg = Aes.Create())
            {
                aesAlg.Key = key;
                aesAlg.IV = iv;

                ICryptoTransform decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);

                using (MemoryStream memoryStream = new MemoryStream(encryptedData))
                {
                    using (CryptoStream cryptoStream = new CryptoStream(memoryStream, decryptor, CryptoStreamMode.Read))
                    {
                        using (StreamReader reader = new StreamReader(cryptoStream))
                        {
                            return reader.ReadToEnd();
                        }
                    }
                }
            }
        }
    }
}