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

            //The URL to download the latest release of Xenia
            const string zipUrl = "https://ci.appveyor.com/api/projects/benvanik/xenia/artifacts/xenia_master.zip?branch=master&job=Configuration%3A%20Release&pr=false";

            //Using a web client, do the following
            using (WebClient webClient = new WebClient())
            {
                //Delete the old zip
                File.Delete("xenia_master_old.zip");

                //Try rename current version to old and delete current version
                try
                {
                    File.Move("xenia_master.zip", "xenia_master_old.zip");
                    File.Delete("xenia.pdb");
                    File.Delete("LICENSE");
                    File.Delete("xenia.log");
                    File.Delete("xenia.exe");
                    File.Delete("xenia_old.exe");
                }
                catch (Exception)
                {
                }

                //Download the file xenia_master.zip from the url supplied in the string zipUrl
                webClient.DownloadFileAsync(new Uri(zipUrl), "xenia_master.zip");
                
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
                    ZipFile.ExtractToDirectory("xenia_master.zip", ".");
                }
                catch (Exception)
                {
                }

                //Once all is done, start Xenia.
                Process.Start("xenia.exe");

                //Exit
                this.Close();
            }
        }
    }
}