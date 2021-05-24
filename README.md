# Unofficial Xenia Updater
Small program made to manage Xenia emulator and its versions.

# Features

* Compatible with master branch and both canary branches of Xenia.
* Downloads, extracts and starts Xenia in one click
* Creates a backup of the last downloaded version of Xenia (xenia_master.zip and/or xenia_canary.zip)

# Info for anyone who plans to modify this code

To add different builds of Xenia, add two new buttons, one for updating and the other for starting that build. In the click event for those buttons, use the UpdateXenia and StartXenia methods to pass required parameters to update and start respectively.

# Note for "Debug" release

There is no guarantee of stability with the debug release.

If you run into any issues, message me on Discord **[IRB] Chopper#4291**.
Try provide as much info as possible, screenshot of when the issue occurred and a screenshot of the directory the updater was in and so on.

Thanks :)
