﻿using System;
using System.Net;
using System.Windows.Forms;

namespace XeniaUpdater_C
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            //Create form
            InitializeComponent();

            Helper h = new Helper();
            h.StartupTasks();
        }

        //Takes the parameters needed to update any branch of Xenia given the correct parameters
        public void UpdateXenia(string folderName, string url, string zipFullName, string exeName)
        {
            Helper h = new Helper();
            h.CreateFolders(folderName);
            h.PreUpdateTask(folderName, zipFullName, exeName);
            if (h.InternetAvailable() == true)
            {
                DownloadFile(url, zipFullName, folderName);
            }
            else
            {
                MessageBox.Show("Could not ping AppVeyor");
            }
        }


        //Start Xenia given a folder and executable name
        public void StartXenia(string folderName, string exeName)
        {
            Helper h = new Helper();
            h.StartProcess(exeName, folderName, true);
        }


        //Downloads a file from a URL to a path with the file name you specify
        public void DownloadFile(string downloadURL, string fileName, string folderName)
        {
            ToggleButtons(false);
            using (WebClient wc = new WebClient())
            {
                //Download from URL to location
                wc.DownloadFileAsync(new Uri(downloadURL), $"{folderName}/{fileName}");

                //For each change in progrress, output progress to the wc_DownloadProgressChanged method
                wc.DownloadProgressChanged += new DownloadProgressChangedEventHandler(wc_DownloadProgressChanged);

                // For each update in the downloads progress, do this
                void wc_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
                {
                    progressBar1.Value = e.ProgressPercentage;
                    percentageLBL.Text = $"{progressBar1.Value.ToString()}%";

                    if (progressBar1.Value == 100)
                    {
                        wc.Dispose();
                        ToggleButtons(true);
                        Helper h = new Helper();
                        h.ExtractBuild(folderName, fileName);
                    }
                }
                wc.Dispose();

            }
        }

        void ToggleButtons(bool enabled)
        {
            masterUpdateBTN.Enabled = enabled;
            masterStartBTN.Enabled = enabled;
            canaryUpdateBTN.Enabled = enabled;
            canaryStartBTN.Enabled = enabled;
            canaryExUpdateBTN.Enabled = enabled;
            canaryExStartBTN.Enabled = enabled;
            updateBTN.Enabled = enabled;
        }

        private void button1_Click(object sender, System.EventArgs e)
        {
            string url = "https://ci.appveyor.com/api/projects/benvanik/xenia/artifacts/xenia_master.zip?branch=master&job=Configuration%3A%20Release&pr=false";
            UpdateXenia("XeniaMaster", url, "xenia_master.zip", "xenia.exe");
        }

        private void button2_Click(object sender, System.EventArgs e)
        {
            StartXenia("XeniaMaster", "xenia");
        }

        private void button4_Click(object sender, System.EventArgs e)
        {
            string url = "https://github.com/xenia-canary/xenia-canary/releases/latest/download/xenia_canary.zip";
            UpdateXenia("XeniaCanary", url, "xenia_canary.zip", "xenia_canary.exe");
        }

        private void button3_Click(object sender, System.EventArgs e)
        {
            StartXenia("XeniaCanary", "xenia_canary");
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            string url = "https://ci.appveyor.com/api/projects/chris-hawley/xenia-canary/artifacts/xenia_canary.zip?branch=canary_experimental&job=Configuration:%20Release&pr=false";
            UpdateXenia("XeniaCanaryEx", url, "xenia_canary.zip", "xenia_canary.exe");
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            StartXenia("XeniaCanaryEx", "xenia_canary");
        }

        private void infoBTN_Click(object sender, EventArgs e)
        {
            Form2 f2 = new Form2();
            f2.ShowDialog();
        }

        private void updateBTN_Click(object sender, EventArgs e)
        {
            Helper h = new Helper();
            h.UpdateXeniaUpdater("Debug");
        }

        private void button1_Click_2(object sender, EventArgs e)
        {
            Helper h = new Helper();
            h.OpenInstallFolder();
        }

        private void button2_Click_2(object sender, EventArgs e)
        {
            Helper h = new Helper();
            h.UploadFile("xenia.log");
        }
    }
}
