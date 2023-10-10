using System;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace AES
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            string password = "Some password";
            string salt = "Some salt";

            using (var keyDerivationFunction = new Rfc2898DeriveBytes(password, Encoding.ASCII.GetBytes(salt)))
            {
                using (var aes = new AesManaged())
                {
                    aes.Key = keyDerivationFunction.GetBytes(aes.KeySize / 8);
                    aes.IV = keyDerivationFunction.GetBytes(aes.BlockSize / 8);

                    Console.WriteLine("AES Key: " + BitConverter.ToString(aes.Key).Replace("-", ""));
                    Console.WriteLine("AES IV: " + BitConverter.ToString(aes.IV).Replace("-", ""));
                    AesS aesS = new AesS();
                    string s = "123";
                     Console.WriteLine("text: " +s);
                    byte[] bytes = aesS.Encript_AES(s, aes.Key, aes.IV);
                    
                    Console.WriteLine("out: " + aesS.decriptorStringFromBits(bytes, aes.Key, aes.IV));
                }
            }
          
            
        }
    }
}