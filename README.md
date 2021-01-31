# Unofficial Xenia Updater
Small program made to manage Xenia emulator and its versions.

# Releases

* [**Stable**](https://github.com/Chopper1337/XeniaUpdater/raw/main/bin/Release/XeniaUpdater.exe)
* [Testing](https://github.com/Chopper1337/XeniaUpdater/raw/main/bin/Debug/XeniaUpdater.exe)

# Features

* Compatible with master and canary branches of Xenia
* Downloads, extracts and starts Xenia in one click
* Creates a backup of the last downloaded version of Xenia (xenia_master.zip and/or xenia_canary.zip)
* Updating the updater itself, from the updater itself. No need to open a browser

# Info for anyone who plans to modify this code

Form1.cs contains the "Important strings":
* URLs of Xenia master and canary releases
* Executable names of master and canary
* Process names of master and canary

These can be changed by the Xenia time at any time, so they are easily modifiable for future. This does not mean these strings are only defined here though, there is a chance that I did not always refer back to these strings each time.

Updating the updater is done by downloading latest raw binary from GitHub with a different name, then generating a batch file which, on next launch of the program, will run, killing the updater and replacing the old executable with the new one by deleting the old and renaming the new to the same name. This means you don't have to make a new shortcut on your Desktop for example.

The "forceful extraction" option exists for the case the the updater does not extract the zip. We can tell the zip was not extracted when the expected Xenia binary is not present, so on this condition, we prompt the user to try the forceful extraction option which should extract the zip successfully.

This code is not written in the most efficient way, it is probably possible to divide this into a few methods which are applicable to both Xenia Master and Xenia Canary, giving the opportunity to reuse code. 

# Note for "Testing" release

There is no guarantee of stability with the testing release.

If you run into any issues, message me on Discord **[IRB] Chopper#4291**.
Try provide as much info as possible, screenshot of when the issue occurred and a screenshot of the directory the updater was in and so on.

Thanks :)