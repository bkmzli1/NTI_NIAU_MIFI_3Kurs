using System;
using System.IO;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using Microsoft.Win32;

namespace AES_WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        public MainWindow()
        {
            InitializeComponent();
        }


        private void open_file(object sender, RoutedEventArgs e)
        {
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
                            byte[] data = reader.ReadBytes((int)stream.Length);
                            string text = Encoding.Default.GetString(data);
                            multiLineText.Text = text;
                        }
                    }
                }
                catch (Exception ex)
                {
                    // Обрабатывайте ошибки здесь. Например:
                    MessageBox.Show("Error reading file: " + ex.Message, "Error", MessageBoxButton.OK,
                        MessageBoxImage.Error);
                }
            }
        }

        private void save_file(object sender, RoutedEventArgs e)
        {
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
                            byte[] data =
                                System.Text.Encoding.Default
                                    .GetBytes(multiLineText.Text); // преобразование текста в байты
                            writer.Write(data);
                        }
                    }
                }
                catch (Exception ex)
                {
                    // Обрабатывайте ошибки здесь. Например:
                    MessageBox.Show("Error saving file: " + ex.Message, "Error", MessageBoxButton.OK,
                        MessageBoxImage.Error);
                }
            }
        }

        private void coding_menu(object sender, RoutedEventArgs e)
        {
            CodEncod.
        }

        private void encoding_menu(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}