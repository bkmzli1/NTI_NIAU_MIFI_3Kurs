using System.IO;
using System.Text;
using System.Windows.Forms;

namespace RC4
{
    public partial class F2 : Form
    {
        private byte[] key, result;
        private string NamF;

        public F2()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, System.EventArgs e)
        {
        }

        private void button1_Click(object sender, System.EventArgs e)
        {
            key = Encoding.ASCII.GetBytes(textBox1.Text);
            RC4 encoder = new RC4(key);
            string textS = richTextBox1.Text;
            byte[] textB = Encoding.GetEncoding(1251).GetBytes(textS);
            result = encoder.Encod(textB);
            SaveFileDialog sd = new SaveFileDialog();
            sd.Filter = "Шифртекст|*.dat";
            if (sd.ShowDialog() == DialogResult.OK)
            {
                NamF = sd.FileName;
                FileStream fileStream = new FileStream(NamF,FileMode.Create);
                for (int i = 0; i < result.Length; i++)
                {
                    fileStream.WriteByte(result[i]);
                }
                fileStream.Close();
                Close();
            }
            
        }
    }
}