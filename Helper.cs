using System;
using System.Diagnostics;
using System.IO;
using System.IO.Compression;
using System.Net;
using System.Windows.Forms;

namespace XeniaUpdater_C
{
    class Helper
    {
        string currentExecutableFullPathName = System.Diagnostics.Process.GetCurrentProcess().MainModule.FileName; //Full path of the Xenia Updater executable
        string currentExecutableName = System.Diagnostics.Process.GetCurrentProcess().MainModule.ModuleName; //The current name of the Updater. (For the case that the user renames it)
        string newExeLoc = $"C:\\Users\\{Environment.UserName}\\AppData\\Local\\Temp\\XeniaUpdater.Latest.exe"; //Full path in which you will find the newly downloaded version of the updater
        string newBatLoc = $"C:\\Users\\{Environment.UserName}\\AppData\\Local\\Temp\\UpdateDownloaded.bat"; //Full path in which you will find the generated batch file used for the self updater 

        public Helper()
        {

        }

        //Creates the folders needed for a given Xenia build
        public void CreateFolders(string folderName)
        {
            try
            {
                Directory.CreateDirectory(folderName);
                Directory.CreateDirectory($"{folderName}/LastUpdate");
            }
            catch (Exception e)
            {
                LogError(e.ToString(),"XeniaUpdaterLog.txt");
            }
        }

        //Open the folder in which the current running instance of Xenia Updater is located.
        public void OpenInstallFolder()
        {
            Process.Start(currentExecutableFullPathName.Replace(currentExecutableName, ""));
        }

        //Extracts the zip
        public void ExtractBuild(string folderName, string zipName)
        {
            //Deletes LICENSE file because it isn't needed and also causes issues for some reason
            try
            {
                File.Delete($"{folderName}/LICENSE");
                ZipFile.ExtractToDirectory($"{folderName}/{zipName}", folderName);
                File.Delete($"{folderName}/LICENSE");

            }
            catch (Exception e)
            {
                LogError(e.ToString(),"XeniaUpdaterLog.txt");
            }
        }

        //Logs the last error the program had in a file named XeniaUpdaterLog
        //This file will not infintely be written to.
        void LogError(string e, string fileName)
        {
            if (!File.Exists(fileName))
            {
                File.Create(fileName);
            }

            double length = new System.IO.FileInfo(fileName).Length;
            length = length / 1000;
            byte limit = 200;
            if(length > limit)
            {
                File.Delete(fileName);
                File.AppendAllText(fileName, $"Your previous log file exceeded {limit}KB and was deleted.\n");
            }
            File.AppendAllText(fileName, e);
        }

        //Cleanup tasks to do before download and extraction of a new version
        public void PreUpdateTask(string folderName, string zipName, string ExecutableName)
        {
            string PDBName = ExecutableName.Remove(ExecutableName.Length - 4) + ".pdb";
            try
            {
                File.Delete($"{folderName}/LastUpdate/{zipName}");
                File.Move($"{folderName}/{zipName}", $"{folderName}/LastUpdate/{zipName}");
                File.Delete($"{folderName}/{ExecutableName}");
                File.Delete($"{folderName}/LICENSE");
                File.Delete($"{folderName}/xenia.log");
                File.Delete($"{folderName}/{ExecutableName}");
                File.Delete($"{folderName}/{PDBName}");
                File.Delete($"{folderName}/{PDBName}");
            }
            catch (Exception e)
            {
                LogError(e.ToString(),"XeniaUpdaterLog.txt");
            }
        }

        //Start a process
        public void StartProcess(string ExecutableName, string ExeLocation)
        {
            try
            {
                Process.Start($"{ExeLocation}\\{ExecutableName}");
            }
            catch (Exception e)
            {
                MessageBox.Show($"\"{ExecutableName}.exe\" could not be started.\nThe file must be present and executable.", "Error");
                LogError(e.ToString(),"XeniaUpdaterLog.txt");
            }
        }

        //Updates XeniaUpdater
        public void UpdateXeniaUpdater(string branch)
        {
            //If we have an internet connection
            if (InternetAvailable() == true)
            {
                //Create instance of form 2 to pull build date from self.
                Form2 f2 = new Form2();

                //Pull latest version from github
                System.Net.WebClient wc1 = new System.Net.WebClient();
                string webData = wc1.DownloadString($"https://raw.githubusercontent.com/Chopper1337/XeniaUpdater/main/version-{branch}.txt");
                wc1.Dispose();

                //If current version is equal to version pulled from github
                if (webData.Equals(f2.buildDate))
                {
                    MessageBox.Show("You are on the latest version! :)\n\nYour build date matches that on GitHub","Better luck next time!");
                    return;
                }
                else
                {
                    //Usual update process
                    WebClient wc = new WebClient();
                    wc.DownloadFileAsync(new Uri($"https://raw.githubusercontent.com/Chopper1337/XeniaUpdater/main/bin/{branch}/XeniaUpdater.exe"), newExeLoc);
                    wc.Dispose();

                    if (File.Exists(newExeLoc))
                    {
                        using (FileStream strm = File.Create(newBatLoc))
                        using (StreamWriter sw = new StreamWriter(strm))
                        {
                            //This is supposed to look like this.
                            sw.WriteLine(
    $@"@echo off
rem File generated by {currentExecutableName} (XeniaUpdater), do not modify or delete :)
title Updating Xenia Updater
echo Killing {currentExecutableName}
taskkill /im {currentExecutableName}
timeout 1
echo Deleting {currentExecutableName}
del {currentExecutableFullPathName}
move {newExeLoc} {currentExecutableFullPathName}
echo XeniaUpdater has been updated under the name {currentExecutableName}.
echo This CMD window will not appear on next start and can be closed :)
{currentExecutableName}
del {newBatLoc}");
                        }
                        MessageBox.Show($"Latest version downloaded, please restart!", "Latest version downloaded :)");
                    }
                }
            }
            else
            {
                MessageBox.Show("Internet connection not available.");
            }

            //This is needed for backward compatibility with previous versions of Xenia Updater
            if (File.Exists("XeniaUpdater.Latest.exe"))
            {
                MessageBox.Show($"Latest version downloaded, please restart!", "Latest version downloaded :)");

                using (FileStream strm = File.Create("UpdateDownloaded.bat"))
                using (StreamWriter sw = new StreamWriter(strm))
                {
                    //This is supposed to look like this.
                    sw.WriteLine(
$@"@echo off
rem File generated by {currentExecutableName} (XeniaUpdater), do not modify or delete :)
title Updating Xenia Updater
echo Killing {currentExecutableName}
taskkill /im {currentExecutableName}
timeout 1
echo Deleting {currentExecutableName}
del {currentExecutableFullPathName}
move XeniaUpdater.Latest.exe {currentExecutableFullPathName}
echo XeniaUpdater has been updated under the name {currentExecutableName}.
echo This CMD window will not appear on next start and can be closed :)
{currentExecutableName}
del UpdateDownloaded.bat");
                }
            }
        }

        //Things to do upon launch of the program
        public void StartupTasks()
        {
            //Booleans to check for the existance of the update batch file, a newly downloaded version of the updater from GitHub and a safety switch to prevent infinte cmd.exe's being started
            bool updateBatExists = File.Exists(newBatLoc);
            bool updateEXEExists = File.Exists(newExeLoc);
            bool updateBatExists_c = File.Exists("UpdateDownloaded.bat");
            bool updateEXEExists_c = File.Exists("XeniaUpdater.Latest.exe");
            bool safetySwitch = true;

            if (safetySwitch)
            {
                //If the batch file exists and the new executable exists, start the batch file
                if (updateBatExists && updateEXEExists)
                {
                    Process.Start(newBatLoc);
                    safetySwitch = false;
                }
                //Else, if the batch file does not exist but the updated executable does, delete the executable.
                //Reason behind this being that this executable is useless without the batch file.
                else if (!updateBatExists && updateEXEExists)
                {
                    File.Delete(newExeLoc);
                }
                else if (updateBatExists && !updateEXEExists)
                {
                    File.Delete(newBatLoc);
                }

                // For people using previous builds:
                //If the batch file exists and the new executable exists, start the batch file
                if (updateBatExists_c && updateEXEExists_c)
                {
                    Process.Start("UpdateDownloaded.bat");
                    safetySwitch = false;
                }
                //Else, if the batch file does not exist but the updated executable does, delete the executable.
                //Reason behind this being that this executable is useless without the batch file.
                else if (!updateBatExists_c && updateEXEExists_c)
                {
                    File.Delete("XeniaUpdater.Latest.exe");
                }
                else if (updateBatExists_c && !updateEXEExists_c)
                {
                    File.Delete("UpdateDownloaded.bat");
                }


            }

            //Delete log uploader, it isn't necessary to keep
            if (File.Exists("UploadFile.bat"))
            {
                File.Delete("UploadFile.bat");
                File.Delete("response.txt");
            }

        }

        //Bool to check for internet connection. Pings AppVeyor as you will need to connect to their servers eventually to use this application properly.
        public bool InternetAvailable()
        {
            try
            {
                using (var client = new WebClient())
                using (var stream = client.OpenRead("http://appveyor.com"))
                {
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }

        //Generates batch script to upload a file to tmp.ninja using CURL.
        public void UploadFile(string filename)
        {
            string text = $@"
            @echo off
rem File generated by {currentExecutableName} (XeniaUpdater), safe to delete :)
echo Uploading log :)
curl -i -F files[]=@{filename} https://tmp.ninja/upload.php?output=text > response.txt
cls
echo Your {filename} is uploaded here:
echo.
type response.txt | findstr http
echo.
echo Highlight the URL with your mouse and right click to copy to clipboard.
echo.
echo If there is no URL displayed above, you will need to install CURL. Download it here: https://curl.se/windows/
echo.
echo Files are hosted on https://tmp.ninja/. Neither Xenia nor Xenia Updater are associated with tmp.ninja.
echo.
echo Read more here: https://tmp.ninja/faq.html
echo.
echo You can close this window.
pause";

            if (File.Exists(filename))
            {
                using (FileStream strm = File.Create("UploadFile.bat"))
                using (StreamWriter sw = new StreamWriter(strm))
                {
                    sw.WriteLine(text);
                }
            Process.Start("UploadFile.bat");
            }
            else
            {
                MessageBox.Show($"{filename} not found");
            }
        }
    }
}
