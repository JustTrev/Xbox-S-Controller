# Xbox-S-Controller
The Xbox OG Kit 

NEWS*: 3.0 COMING SOON!!!


### **Xbox OG Kit**  
is a frontend user interface for Xb2Input with included requirements to support Xb2Input.

The "Xbox OG Kit Installer" found inside the Zip File located in the assets below, will unpack all of Xb2Input requirements and install them for you with a progress and output tracker.

### **XboxOG Kit Installer**  
![image](https://user-images.githubusercontent.com/3674483/227811549-a97ff5d4-13f4-45f2-8b72-e56cc7a741a9.png)

![image](https://user-images.githubusercontent.com/3674483/210905484-945ad335-cf8e-4447-b369-3ebf63f652b3.png)

![image](https://user-images.githubusercontent.com/3674483/210187765-ccc7a658-bf9d-4b70-8d0f-e10988877857.png)


### **XboxOG Kit**!
![image](https://user-images.githubusercontent.com/3674483/210905317-0e64ca40-4fc7-4a8d-9db3-bb4ea9821860.png)


-----
Current Release Notes: 2.0
 
**Notes:  Added**

• Detect controller and button presses from within Xbox OG Kit.
• The installer will create a new registry key item for installation for future support to Xbox OG Kit and potentially the Xb2Input project (TBD) and uninstallation process.

• The setup will install all the necessary files and run them without much human intervention.

• The Installer places shortcuts in the Start Menu after installing, so finding the Xbox OG Kit should be easy. (Now auto launches Xb2Input by default at Startup)

• The settings drop down has been rearranged to properly configure other applications needs.

• Background now uses the latest dashboard theme. (Soon to use a realtime 3D background with sound!).

• You can edit the guide button mappings in order to use the guide menu.

• You can enable or disable the controller vibration.

• The Triggers and Stick Dead Zones can be tested.

• Installer now has an Icon for easier support.

• Added to Windows startup support.(you can find this in the Settings>Xb2Input dropdown.


**Fixed:**

• Fix installer to restart PC when checkbox is checked at the final stage of installation. (This is supposed to be working but it isn't. Manual restarts will be necessary after the installer has finished.)
• Open Xb2Input when launching Xbox OG Kit, if it is not already running.  (Working)

• Remove the guide button checkboxes and info key when "Enable Guide?" is disabled. (Working)


• Windows 11 wont start the toolbar services (i.e No clock, speakers or anything) if a controller is plugged in upon after a reboot after logging in. Current work around is reboot and disconnect your controller until after login. (This seems to have gone away. Clear to proceed!!!)

**To-Do:**

• Swap buttons with Remap Controller enabled.

• Run analog Driver Installer batch script in background to update the installer progressbar.

• Look into installing ViGEmBus silently or without human intervention completely.

• Update the background controller image to show the right connected controller, based on it's serial number. (such as racing wheel, or madcatz wireless controllers, etc.)

• Detect the Xbox Communicator and it's serial number for full headset support and Xbox Original style voice changer. (might need to make a sound device driver for this to happen much like the controllers).

• Add an Uninstaller for Xbox OG Kit to remove all of it's contents.

**Known Bugs:**

• Other controller accessories such as the headset communicator, might cause Xb2Input from being able to detect your controller. (Work around - Disconnect controller and remove accessories before reconnecting your controller into your PC. Let Xb2Input detect your controller first before plugging in any accessory into the controller.)
 
 
 
**Download Zip file below:** _Other assets are Xb2InputV1.5c_


------

**Past Release:**
Notes: v1.0

