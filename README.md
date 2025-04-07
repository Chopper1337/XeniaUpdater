# Unofficial Xenia Updater
Small program made to manage the Xenia Xbox 360 emulator and its versions.

# Releases

* [**Stable**](https://github.com/Chopper1337/XeniaUpdater/raw/main/bin/Release/XeniaUpdater.exe)
* [Debug](https://github.com/Chopper1337/XeniaUpdater/raw/main/bin/Debug/XeniaUpdater.exe)

Expect the debug version to have the latest features implemented in an ugly way :) (See note for more info on debug release).

# Features

* Compatible with master and canary branches of Xenia.
* Downloads and extracts latest builds of Xenia in one click.
* Creates a backup of the last downloaded version of Xenia.

# Developers

## Some advice before proceeding

I highly recommend that you use [XeniaUpdater2](https://github.com/Chopper1337/XeniaUpdater2) or [XeniaLauncher-CLI](https://github.com/Chopper1337/XeniaLauncher-CLI) to make changes. They should be significantly easier to work with.

## Adding other builds of Xenia

1. Add two new buttons (Update and Launch)
2. Create click events for these buttons
3. Use the `UpdateXenia` and `StartXenia` functions in the click event functions
4. Add your newly created buttons to the `ToggleButtons` functions

Examples:

```
// Update Xenia Master button click event
private void button1_Click(object sender, System.EventArgs e) {
    // URL to download the latest build ZIP
    string url = "https://github.com/xenia-project/release-builds-windows/releases/latest/download/xenia_master.zip";
    // Update the build providing the folder name, url, ZIP name and executable name
    UpdateXenia("XeniaMaster", url, "xenia_master.zip", "xenia.exe");
}

// Start Xenia Master button click event
private void button2_Click(object sender, System.EventArgs e) {
    // Start the build providing the folder name and executable name (excluding extension)
    StartXenia("XeniaMaster", "xenia");
}

```

```
// Enables or disabled all buttons in the application
void ToggleButtons(bool enabled) {
    masterUpdateBTN.Enabled = enabled;
    masterStartBTN.Enabled = enabled;
    canaryUpdateBTN.Enabled = enabled;
    canaryStartBTN.Enabled = enabled;
    // Add your buttons here

    updateBTN.Enabled = enabled;
}
```

# Note for "Debug" release

There is no guarantee of stability with the debug release.


If you run into any issues, create an issue through GitHub.
Try provide as much info as possible, screenshot of when the issue occurred and a screenshot of the directory the updater was in and so on.

A log file should be generated with the last error the program had, provide this if possible.

Thanks :)
