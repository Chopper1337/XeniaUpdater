# Unofficial Xenia Updater
Small program made to manage the Xenia Xbox 360 emulator and its versions.

# Releases

* [**Stable**](https://github.com/Chopper1337/XeniaUpdater/raw/main/bin/Release/XeniaUpdater.exe)
* [Debug](https://github.com/Chopper1337/XeniaUpdater/raw/main/bin/Debug/XeniaUpdater.exe)

Expect the debug version to have the latest features implemented in an ugly way :) (See note for more info on debug release).

# Features

* Compatible with master branch and both canary branches of Xenia (PR and Experimental).
* Downloads and extracts latest builds of Xenia in one click.
* Creates a backup of the last downloaded version of Xenia.

# Info for anyone who plans to modify this code

To add different builds of Xenia, add two new buttons, one for updating and the other for launching that build. In the click event for those buttons, use the UpdateXenia and StartXenia methods to pass required parameters to update and start respectively.

Add your two new buttons to the ToggleButtons method.

# Note for "Debug" release

There is no guarantee of stability with the debug release.


If you run into any issues, create an issue through GitHub.
Try provide as much info as possible, screenshot of when the issue occurred and a screenshot of the directory the updater was in and so on.

A log file should be generated with the last error the program had, provide this if possible.

Thanks :)
