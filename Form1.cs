using System;
using System.Diagnostics;
using System.IO;
using System.IO.Compression;
using System.Net;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace XeniaUpdater
{
    public partial class Form1 : Form
    {
        //Important strings
        const string masterURL = "https://ci.appveyor.com/api/projects/benvanik/xenia/artifacts/xenia_master.zip?branch=master&job=Configuration%3A%20Release&pr=false";
        const string canaryURL = "https://ci.appveyor.com/api/projects/chris-hawley/xenia-canary/artifacts/xenia_canary.zip?branch=canary_new&job=Configuration:%20Release&pr=false";
        const string masterEXE = "xenia.exe";
        const string canaryEXE = "xenia_canary.exe";
        const string masterProc = "xenia";
        const string canaryProc = "xenia_canary";

        void buttonsOff()
        {
            button1.Enabled = false;
            button2.Enabled = false;
            button3.Enabled = false;
            button4.Enabled = false;
            button5.Enabled = false;
            button6.Enabled = false;
        }

        void buttonsOn()
        {
            button1.Enabled = true;
            button2.Enabled = true;
            button3.Enabled = true;
            button4.Enabled = true;
            button5.Enabled = true;
            button6.Enabled = true;
        }

        public Form1()
        {
            //Go go go!
            InitializeComponent();
            bool updateBatExists = File.Exists("UpdateDownloaded.bat");
            bool updateEXEExists = File.Exists("XeniaUpdater.Latest.exe");

            if (updateBatExists)
            {
                Process.Start("UpdateDownloaded.bat");
                this.Close();
            }
            else if(!updateBatExists && updateEXEExists)
            {
                File.Delete("XeniaUpdater.Latest.exe");
            }
        }

        //Method which accepts a URL and branch in string form.
        public void downloadUpdate(string zipUrl, string branch)
        {
            buttonsOff();
            //Using a web client, do the following
            using (WebClient webClient = new WebClient())
            {
                //Deletes any existing "old" zip of the branch you are going to download
                try
                {
                    File.Delete($"xenia_{branch}_old.zip");
                }
                catch (Exception)
                {

                }


                /* Creates a backup of your last downloaded version
                 * Then starts a cleanup to remove uneeded files
                 * Removes executables according to the branch you'll be updating
                 */
                try
                {
                    File.Move($"xenia_{branch}.zip", $"xenia_{branch}_old.zip");

                    File.Delete("LICENSE");
                    File.Delete("xenia.log");
                    if (branch == "master")
                    {
                        File.Delete(masterEXE);
                        File.Delete("xenia_old.exe");
                        File.Delete("xenia.pdb");
                    }
                    else
                    {
                        File.Delete(canaryEXE);
                        File.Delete("xenia_canary_old.exe");
                        File.Delete("xenia_canary.pdb");
                    }
                }
                catch (Exception)
                {
                }

                //Using the web client, download from the given URL, the xenia zip, named according to selected branch
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
                    finalizeAsync();

                    //Add one to the int to prevent the finalize method being called over and over
                    percentInt++;
                }
            }

            //Extracts the zip to the current directory
            //In try/catch to surpress potential errors
            void tryExtractZip(string branch1)
            {
                branch = branch1;
                try
                {
                    ZipFile.ExtractToDirectory($"xenia_{branch}.zip", ".");
                }
                catch (Exception)
                {
                }
            }

            //Finalize
            async Task finalizeAsync()
            {
                //If you're downloading master branch, kill all currently running "xenia" processes
                if (branch == "master")
                {
                    //For each process with the name of the master branch
                    foreach (var process in Process.GetProcessesByName(masterProc))
                    {
                        //Kill process
                        process.Kill();
                    }
                }
                //Else you're downloading the canary branch, so kill all currently running "xenia_canary" processes
                else
                {
                    //For each process with the name of the canary brancc
                    foreach (var process in Process.GetProcessesByName(canaryProc))
                    {
                        //Kill process
                        process.Kill();
                    }
                }

                //Try extraction
                tryExtractZip(branch);

                //If branch is master, check the EXE has extracted and start it
                if (branch == "master")
                {
                    if (File.Exists(masterEXE))
                    {
                        Process.Start(masterEXE);
                        if (!keepOpenBx.Checked)
                        {
                            this.Close();
                        }
                        
                    }
                    else
                    //If the EXE is not yet extracted
                    {
                        buttonsOn();
                        MessageBox.Show("You may want to click the F button to force zip extraction", "Unusual happenings...");
                    }

                }
                //Else branch is canary, check the EXE has extracted and start it
                else
                {
                    if (File.Exists(canaryEXE))
                    {
                        Process.Start(canaryEXE);
                        if (!keepOpenBx.Checked)
                        {
                            this.Close();
                        }
                    }
                    //If it isn't extracted
                    else
                    {
                        buttonsOn();
                        MessageBox.Show("You may want to click the F button to force zip extraction", "Unusual happenings...");
                    }

                }
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Starts updating for master branch using variable declared at start of program
            downloadUpdate(masterURL, "master");
        }

        //Tries to start master xenia executable, if fail, show error
        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                Process.Start(masterEXE);
                if (!keepOpenBx.Checked)
                        {
                            this.Close();
                        }
            }
            catch (Exception)
            {
                MessageBox.Show("Something isn't right, could not start xenia.exe :(", "Error");
            }
        }

        //Tries to start canary xenia executable, if fail, show error
        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                Process.Start(canaryEXE);
                if (!keepOpenBx.Checked)
                {
                    this.Close();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Something isn't right, could not start xenia-canary.exe :(", "Error");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //Starts updating for canary branch using variable declared at start of program
            downloadUpdate(canaryURL, "canary");
        }

        //Info button, shows form2
        private void button5_Click(object sender, EventArgs e)
        {
            Form2 f2 = new Form2();
            f2.ShowDialog(); // Shows Form2
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Form3 f3 = new Form3();
            f3.ShowDialog(); // Shows Form3
        }
    }
}