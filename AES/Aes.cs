using System;
using System.Security.Cryptography;

namespace AES
{
    public class AesS

    {
        public byte[] Encript_AES(string plainText, byte[] key, byte[] IV)
        {
            if (plainText == null || plainText.Length <= 0)
            {
                throw new ArgumentNullException("plainText");
            }

            if (key == null || key.Length <= 0)
            {
                throw new ArgumentNullException("key");
            }

            if (IV == null || IV.Length <= 0)
            {
                throw new ArgumentNullException("key");
            }

            byte encrypted;
            using (Aes aesAlg = Aes.Create())
            {
                aesAlg.Key = key;
                aesAlg.IV = IV;
                ICryptoTransform encripror = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);
            }

            return new byte[] { };
        }
    }
}