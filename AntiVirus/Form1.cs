using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AntiVirus
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        AntiVirus_Utils Scanner = new AntiVirus_Utils();
        private void bunifuButton1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();

            if (openFileDialog.ShowDialog() == DialogResult.Cancel)
                return;
            string filename = openFileDialog.FileName;
            Task.Factory.StartNew(() =>
            {
                byte[] hsh = Scanner.GetFileBytes(filename);
                string gg = Scanner.GetBytesText(hsh);
                string password = Regex.Match(gg, "хъяГйпъялЮ(.*)Гяяяя2(.*)яяяяя").Groups[2].Value;
                string p2 = Regex.Replace(password, "[^0-9]+", string.Empty);
                label1.Invoke((MethodInvoker)(() => label1.Text = "Password: " + p2));
            });
        }
    }
}
