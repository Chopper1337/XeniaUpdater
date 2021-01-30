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

        private void button1_Click(object sender, EventArgs e)
        {
            //string date = DateTime.Now.ToString($"dd.MM.yy_hh.mm.ss");
            //string path = Directory.GetCurrentDirectory();

            using (WebClient webClient = new WebClient())
            {
                webClient.DownloadFileAsync(new Uri("https://github.com/Chopper1337/XeniaUpdater/raw/main/bin/Debug/XeniaUpdater.exe"), $"XeniaUpdater.Latest.exe");
            }

            if (File.Exists($"XeniaUpdater.Latest.exe"))
            {
                MessageBox.Show($"Latest version downloaded, please restart!","Latest version downloaded :)");
                //Process.Start(path);

                using (FileStream strm = File.Create("UpdateDownloaded.bat"))
                using (StreamWriter sw = new StreamWriter(strm))
                    sw.WriteLine(
                        "timeout 3\n" +
                        "del XeniaUpdater.exe\n" +
                        "move XeniaUpdater.Latest.exe XeniaUpdater.exe\n" +
                        "pause");
            }            
        }
    }
}
