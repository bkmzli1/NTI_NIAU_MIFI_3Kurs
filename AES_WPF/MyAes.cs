using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Windows;
using Microsoft.Win32;

namespace AES_WPF
{
    public class MyAes

    {
        protected byte[] Encript_AES(string plainText, byte[] key, byte[] IV)
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

        public static string encode_open_file(string iv, string key)
        {
            if (iv == null | iv.Length <= 0)
            {
                MessageBox.Show("Введите iv позязя", "ВНИМАНИЕ", MessageBoxButton.OK, MessageBoxImage.Warning);
                return null;
            }

            if (key == null | key.Length <= 0)
            {
                MessageBox.Show("Введите key позязя", "ВНИМАНИЕ", MessageBoxButton.OK, MessageBoxImage.Warning);
                return null;
            }

            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Binary files (*.bin)|*.bin"; // Фильтр для бинарных файлов
            if (openFileDialog.ShowDialog() == true)
            {
                try
                {
                    using (Stream stream = openFileDialog.OpenFile())
                    {
                        using (BinaryReader reader = new BinaryReader(stream))
                        {
                            using (var keyDerivationFunction = new Rfc2898DeriveBytes(key, Encoding.ASCII.GetBytes(iv)))
                            {
                                using (var aes = new AesManaged())
                                {
                                    aes.Key = keyDerivationFunction.GetBytes(aes.KeySize / 8);
                                    aes.IV = keyDerivationFunction.GetBytes(aes.BlockSize / 8);

                                    byte[] bytes = reader.ReadBytes((int)stream.Length);
                                    MyAes aesS = new MyAes();
                                    return aesS.decriptorStringFromBits(bytes, aes.Key, aes.IV);
                                }
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    // Обрабатывайте ошибки здесь. Например:
                    MessageBox.Show("Ошибочка: " + ex.Message, "Error", MessageBoxButton.OK,
                        MessageBoxImage.Error);
                }
            }

            return null;
        }

        public static bool decodr_save_file(string iv, string key, string text)
        {
            if (iv == null | iv.Length <= 0)
            {
                MessageBox.Show("Введите iv позязя", "ВНИМАНИЕ", MessageBoxButton.OK, MessageBoxImage.Warning);
                return false;
            }

            if (key == null | key.Length <= 0)
            {
                MessageBox.Show("Введите key позязя", "ВНИМАНИЕ", MessageBoxButton.OK, MessageBoxImage.Warning);
                return false;
            }

            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Binary files (*.bin)|*.bin"; // Фильтр для бинарных файлов

            if (saveFileDialog.ShowDialog() == true)
            {
                try
                {
                    using (Stream stream = saveFileDialog.OpenFile())
                    {
                        using (BinaryWriter writer = new BinaryWriter(stream))
                        {
                            try
                            {
                                using (var keyDerivationFunction =
                                       new Rfc2898DeriveBytes(key, Encoding.ASCII.GetBytes(iv)))
                                {
                                    using (var aes = new AesManaged())
                                    {
                                        aes.Key = keyDerivationFunction.GetBytes(aes.KeySize / 8);
                                        aes.IV = keyDerivationFunction.GetBytes(aes.BlockSize / 8);
                                        MyAes aesS = new MyAes();
                                        byte[] data = aesS.Encript_AES(text, aes.Key, aes.IV);
                                        writer.Write(data);
                                        MessageBox.Show(
                                            "Данные успешно зашифрованы и сохранены в: " + saveFileDialog.FileName,
                                            "Информация", MessageBoxButton.OK, MessageBoxImage.Information);
                                    }
                                }
                            }
                            catch (ArgumentException aex)
                            {
                                MessageBox.Show("Ошибочка: веденны некоректные значения для kay или iv.Пожалуйста проверьте что текст больше 8 бит(щитайте сами разрабу лень)", "Error", MessageBoxButton.OK,
                                    MessageBoxImage.Error);
                            }

                            return true;
                        }
                    }
                }

                catch (Exception ex)
                {
                    // Обрабатывайте ошибки здесь. Например:
                    MessageBox.Show("Ошибочка: " + ex.Message, "Error", MessageBoxButton.OK,
                        MessageBoxImage.Error);
                }
            }

            return false;
        }

        protected string decriptorStringFromBits(byte[] cliperText, byte[] key, byte[] IV)
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