using System;
using System.Diagnostics;
using System.IO;
using System.IO.Compression;
using System.Net;
using System.Windows.Forms;

namespace XeniaUpdater
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            Process.Start("https://xenia.jp");
            this.Close();
        }

        private void label2_Click(object sender, EventArgs e)
        {
           Process.Start("https://github.com/xenia-project");
           this.Close();
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {
            Process.Start("https://github.com/Chopper1337/XeniaUpdater");
            this.Close();
        }
    }
}
