using System;
using System.IO;
using System.IO.Compression;
using System.Windows.Forms;


namespace XeniaUpdater
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                File.Delete("LICENSE");
                ZipFile.ExtractToDirectory($"xenia_master.zip", ".");
            }
            catch (Exception)
            {
            }

            MessageBox.Show("An attempt to forcefully extract xenia_master.zip was made", "Done");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                File.Delete("LICENSE");
                ZipFile.ExtractToDirectory($"xenia_canary.zip", ".");
            }
            catch (Exception)
            {
            }

            MessageBox.Show("An attempt to forcefully extract xenia_canary.zip was made", "Done");
        }
    }
}
