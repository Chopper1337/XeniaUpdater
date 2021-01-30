using System;
using System.Diagnostics;
using System.IO;
using System.IO.Compression;
using System.Net;
using System.Windows.Forms;

namespace XeniaUpdater
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            //Go go go!
            InitializeComponent();
        }

        public void downloadUpdate(string zipUrl, string branch)
        {
            //Using a web client, do the following
            using (WebClient webClient = new WebClient())
            {
                //Delete the old zip
                try
                {
                    File.Delete($"xenia_{branch}_old.zip");
                }
                catch (Exception)
                {

                }


                //Try rename current version to old and delete current version
                try
                {
                    File.Move($"xenia_{branch}.zip", $"xenia_{branch}_old.zip");
                    
                    File.Delete("LICENSE");
                    File.Delete("xenia.log");
                    if (branch == "master")
                    {
                        File.Delete("xenia.exe");
                        File.Delete("xenia_old.exe");
                        File.Delete("xenia.pdb");
                    }
                    else
                    {
                        File.Delete("xenia_canary.exe");
                        File.Delete("xenia_canary_old.exe");
                        File.Delete("xenia_canary.pdb");
                    }
                }
                catch (Exception)
                {
                }

                //Download the file xenia_master.zip from the url supplied in the string zipUrl
                webClient.DownloadFileAsync(new Uri(zipUrl), $"xenia_{branch}.zip");

                //For each change in progrress, output progress to the wc_DownloadProgressChanged method
                webClient.DownloadProgressChanged += new DownloadProgressChangedEventHandler(wc_DownloadProgressChanged);

                //Clear the web client
                webClient.Dispose();
            }

            // For each update in the downloads progress, do this
            void wc_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
            {
                //Value of the progress bar is equal to the percentage of progress of the download
                progressBar1.Value = e.ProgressPercentage;

                //The percentage string is equal to the value of the progress bar
                string percentage = Convert.ToString(progressBar1.Value);

                //Show the percentage
                label1.Text = $"{percentage}%";

                //Integer to represent the downloads progress
                //This isn't visible to the user
                int percentInt = int.Parse(percentage);

                //If the download progress is 100%, do the finalize method
                if (percentInt == 100)
                {
                    finalize();

                    //Add one to the int to prevent the finalize method being called over and over
                    percentInt++;
                }
            }

            //Finalize
            void finalize()
            {
                if (branch == "master")
                {
                    //For each process with the name "xenia"
                    foreach (var process in Process.GetProcessesByName("xenia"))
                    {
                        //Kill process
                        process.Kill();
                    }
                }
                else
                {
                    //For each process with the name "xenia"
                    foreach (var process in Process.GetProcessesByName("xenia-canary"))
                    {
                        //Kill process
                        process.Kill();
                    }
                }
                    //For each process with the name "xenia"
                    foreach (var process in Process.GetProcessesByName("xenia"))
                {
                    //Kill process
                    process.Kill();
                }

                //Extracts the zip to the current directory
                //In try/catch to surpress potential errors
                try
                {
                    ZipFile.ExtractToDirectory($"xenia_{branch}.zip", ".");
                }
                catch (Exception)
                {
                }

                if(branch == "master")
                {
                    //Once all is done, start Xenia.
                    Process.Start("xenia.exe");
                }
                else
                {
                    //Once all is done, start Xenia.
                    Process.Start("xenia-canary.exe");
                }
                

                //Exit
                this.Close();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            downloadUpdate("https://ci.appveyor.com/api/projects/benvanik/xenia/artifacts/xenia_master.zip?branch=master&job=Configuration%3A%20Release&pr=false", "master");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                //Start Xenia.exe
                Process.Start("xenia.exe");
                //Exit
                this.Close();
            }
            catch (Exception)
            {
                MessageBox.Show("Something isn't right, could not start xenia.exe :(", "Error");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                //Start Xenia.exe
                Process.Start("xenia-canary.exe");
                //Exit
                this.Close();
            }
            catch (Exception)
            {
                MessageBox.Show("Something isn't right, could not start xenia_canary.exe :(", "Error");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            downloadUpdate("https://ci.appveyor.com/api/projects/chris-hawley/xenia-canary/artifacts/xenia_canary.zip?branch=canary_new&job=Configuration:%20Release&pr=false", "canary");
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Form2 f2 = new Form2();
            f2.ShowDialog(); // Shows Form2
        }
    }
}