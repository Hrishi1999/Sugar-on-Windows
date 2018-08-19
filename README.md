# Sugar on Windows

###### An alpha version of Sugar on Windows (basic functionality)

![Alt Text](https://github.com/Hrishi1999/Sugar-on-Windows/blob/master/Images/SOW.gif?raw=true)

## Setup

* First you need to install a X Server for Windows. You can use VcXsrv: https://sourceforge.net/projects/vcxsrv/ (Make sure you associate all the ".xlaunch" files with it during setup)
* To test, you can run /bin/x64/release/Sugar on Windows.exe
* You will need to launch as administrator if you haven't enabled "Windows Subsystem for Linux" already. If you haven't, just click on the Enable button and wait for sometime. Restart your PC after a few minutes.
* Steps to install sucrose 
  * Open Powershell or Command Prompt and type in the the following commands :
  * ``` bash -c -i 'sudo apt-get install sucrose' ```
  * ``` bash -c -i 'echo 'export DISPLAY=:0.0' >> ~/.bashrc' ```
  * ``` bash -c -i 'echo 'export LIBGL_ALWAYS_INDIRECT=1' >> ~/.bashrc' ```
  * And finally, ``` bash -c -i 'source ~/.bashrc' ```

* Then, create a batch file (which could also work as a shortcut to launch without app). 
* Click on "Start Sugar", if nothing goes wrong, a windows will open and you can use Sugar on Windows

## Requirments

* Windows 10 x64
Fall Creators Update
* .NET Framework 4.6.x
* WSL installed
