using System;
using System.IO;
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

            byte[] encrypted;
            using (Aes aesAlg = Aes.Create())
            {
                aesAlg.Key = key;
                aesAlg.IV = IV;
                ICryptoTransform encripror = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);
                using (MemoryStream msen = new MemoryStream())
                {
                    using (CryptoStream scen = new CryptoStream(msen, encripror, CryptoStreamMode.Write))
                    {
                        using (StreamWriter swen = new StreamWriter(scen))
                            swen.Write(plainText);
                    }

                    encrypted = msen.ToArray();
                }
            }

            return encrypted;
        }

        public string decriptorStringFromBits(byte[] cliperText, byte[] key, byte[] IV)
        {
            if (cliperText == null || cliperText.Length <= 0)
            {
                throw new ArgumentNullException("cliperText");
            }

            if (key == null || key.Length <= 0)
            {
                throw new ArgumentNullException("key");
            }

            if (IV == null || IV.Length <= 0)
            {
                throw new ArgumentNullException("key");
            }

            string plainText = null;
            using (Aes aesAlg = Aes.Create())
            {
                aesAlg.Key = key;
                aesAlg.IV = IV;
                ICryptoTransform decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);

                using (MemoryStream der = new MemoryStream(cliperText))
                {
                    using (CryptoStream cscr = new CryptoStream(der, decryptor, CryptoStreamMode.Read))
                    {
                        using (StreamReader srde = new StreamReader(cscr))
                            plainText = srde.ReadToEnd();
                    }
                }
            }

            return plainText;
        }
    }
}