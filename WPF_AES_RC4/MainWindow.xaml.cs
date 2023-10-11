using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Windows;
using Microsoft.Win32;

namespace WPF_AES_RC4
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        public MainWindow()
        {
            InitializeComponent();
            AesOption.IsChecked = true;
        }

        private void Rc4Option_Checked(object sender, RoutedEventArgs e)
        {
            ivLabel.IsEnabled = false;
            ivText.IsEnabled = false;
        }

        private void AesOption_Checked(object sender, RoutedEventArgs e)
        {
            ivLabel.IsEnabled = true;
            ivText.IsEnabled = true;
        }

        private void EncryptButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(keyText.Text) || string.IsNullOrEmpty(filePath.Text))
                {
                    MessageBox.Show("Password or File path cannot be empty.");
                    return;
                }

                var keyDerivationFunction = new Rfc2898DeriveBytes(keyText.Text, Encoding.ASCII.GetBytes(ivText.Text));
                byte[] key = keyDerivationFunction.GetBytes(32); // для AES256
                byte[] iv = keyDerivationFunction.GetBytes(16); // для AES

                if (AesOption.IsChecked == true)
                {
                    byte[] encrypted = EncryptStringToBytes_Aes(encryptText.Text, key, iv);
                    File.WriteAllBytes(filePath.Text, encrypted);
                }
                else if (Rc4Option.IsChecked == true)
                {
                    byte[] encrypted = RC4.Encrypt(key, Encoding.UTF8.GetBytes(encryptText.Text));
                    File.WriteAllBytes(filePath.Text, encrypted);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "An Error has Occurred");
                return;
            }
            MessageBox.Show("всё записано", "инфо");
        }

        private void DecryptButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(keyText.Text) || string.IsNullOrEmpty(filePath.Text))
                {
                    MessageBox.Show("Password or File path cannot be empty.");
                    return;
                }

                byte[] cipherText = File.ReadAllBytes(filePath.Text);

                var keyDerivationFunction = new Rfc2898DeriveBytes(keyText.Text, Encoding.ASCII.GetBytes(ivText.Text));
                byte[] key = keyDerivationFunction.GetBytes(32); // для AES256
                byte[] iv = keyDerivationFunction.GetBytes(16); // для AES

                if (AesOption.IsChecked == true)
                {
                    string decrypted = DecryptStringFromBytes_Aes(cipherText, key, iv);
                    MessageBox.Show(decrypted);
                }
                else if (Rc4Option.IsChecked == true)
                {
                    string decrypted = Encoding.UTF8.GetString(RC4.Decrypt(key, cipherText));
                    MessageBox.Show(decrypted);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "An Error has Occurred");
            }
        }

        static byte[] EncryptStringToBytes_Aes(string plainText, byte[] Key, byte[] IV)
        {
            byte[] encrypted;
            using (Aes aesAlg = Aes.Create())
            {
                aesAlg.Key = Key;
                aesAlg.IV = IV;

                ICryptoTransform encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);
                using (MemoryStream msEncrypt = new MemoryStream())
                using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                {
                    using (StreamWriter swEncrypt = new StreamWriter(csEncrypt))
                    {
                        swEncrypt.Write(plainText);
                    }

                    encrypted = msEncrypt.ToArray();
                }
            }

            return encrypted;
        }

        static string DecryptStringFromBytes_Aes(byte[] cipherText, byte[] Key, byte[] IV)
        {
            string plaintext = null;
            using (Aes aesAlg = Aes.Create())
            {
                aesAlg.Key = Key;
                aesAlg.IV = IV;
                ICryptoTransform decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);
                using (MemoryStream msDecrypt = new MemoryStream(cipherText))
                {
                    using (CryptoStream csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                    {
                        using (StreamReader srDecrypt = new StreamReader(csDecrypt))
                        {
                            plaintext = srDecrypt.ReadToEnd();
                        }
                    }
                }
            }

            return plaintext;
        }


        private void savefile(object sender, RoutedEventArgs e)
        {
            var saveFileDialog = new SaveFileDialog();

            saveFileDialog.Filter = "BIN files (*.bin)|*.bin"; // Ограничить файлы только до .bin

            if (saveFileDialog.ShowDialog() == true)
            {
                filePath.Text = saveFileDialog.FileName;
            }
        }

        private void openfile(object sender, RoutedEventArgs e)
        {
            var openFileDialog = new OpenFileDialog();

            openFileDialog.Filter = "BIN files (*.bin)|*.bin"; // Ограничить файлы только до .bin

            if (openFileDialog.ShowDialog() == true)
            {
                filePath.Text = openFileDialog.FileName;
            }
        }
    }
}