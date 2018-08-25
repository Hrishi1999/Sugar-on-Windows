# Sugar on Windows

###### An alpha version of Sugar on Windows (basic functionality)

![Alt Text](https://github.com/Hrishi1999/Sugar-on-Windows/blob/master/Images/SOW.gif?raw=true)

## Setup

* First you need to install a X Server for Windows. You can use VcXsrv or Xming: https://sourceforge.net/projects/vcxsrv/ (Make sure you associate all the ".xlaunch" files with it during setup)
* To test, you can run Application/Sugar on Windows.exe  or  /bin/x64/release/Sugar on Windows.exe
* You will need to launch the program as administrator if you haven't enabled "Windows Subsystem for Linux" already. If you haven't, just click on the Enable button and wait for sometime. Restart your PC after a few minutes.
* Go to Windows Store and install a Linux distribution (Ubuntu preferred)
* Now launch the Linux distribution and initialize it.
* Click on Install Sucrose button, enter your password. 
* Then, create a batch file (which could also work as a shortcut to launch without app). 
* Click on "Start Sugar", if nothing goes wrong, a windows will open and you can use Sugar on Windows (it might take a few starts sometimes, it will be fixed)

Note : If you are trying to run Sugar with the batch (.bat) file you created, you will need to start a VcXrsv or Xming instance.

## Requirments

* Windows 10 x64 Fall Creators Update
* .NET Framework 4.6.x
* WSL installed
* Xming or VcXrsv
## Known Issues

* ##### Browse fails to start
* ##### Solution : Install ```sudo apt-get install gir1.2-webkit2-4.0```


