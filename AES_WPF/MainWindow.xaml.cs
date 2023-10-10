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
        private bool encoder = true;

        public MainWindow()
        {
            InitializeComponent();
        }


        private void coding_menu(object sender, RoutedEventArgs e)
        {
            encoder = true;
            CodEncodButtonText.Content = "Закодирывать";
        }

        private void encoding_menu(object sender, RoutedEventArgs e)
        {
            encoder = false;
            CodEncodButtonText.Content = "Декодирывать";
        }

        private void CodEncodButton(object sender, RoutedEventArgs e)
        {
            if (!encoder)
            {
                multiLineText.Text = MyAes.encode_open_file(iv.Text, key.Text);
            }
            else
            {
                MyAes.decodr_save_file(iv.Text, key.Text, multiLineText.Text);
            }
        }
    }
}