using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RC4
{
    public partial class FMain : Form
    {
        public FMain()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void шифроватьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            F2 f2 = new F2();
            f2.ShowDialog();
        }

        private void дешифроватьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            F3 f3 = new F3();
            f3.ShowDialog();
        }
    }
}
