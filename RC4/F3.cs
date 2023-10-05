using System.IO;
using System.Text;
using System.Windows.Forms;

namespace RC4
{
    public partial class F3 : Form
    {
        private byte[] key;
        private string NamF;

        public F3()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, System.EventArgs e)
        {
            key = Encoding.ASCII.GetBytes(textBox1.Text);
            OpenFileDialog openFileDialog = new OpenFileDialog();

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                NamF = openFileDialog.FileName;
                FileStream fileStream = new FileStream(NamF, FileMode.Open, FileAccess.Read);
                RC4 decoder = new RC4(key);
                fileStream.Seek(0, SeekOrigin.Begin);
                byte[] result = new byte[fileStream.Length];
                fileStream.Read(result, 0, result.Length);
                byte[] decB = decoder.Encod(result);
                richTextBox1.Text = Encoding.GetEncoding(1251).GetString(decB);
            }
        }
    }
}