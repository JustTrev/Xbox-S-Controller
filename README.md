# Xbox-S-Controller
The Xbox OG Kit 



### **Xbox OG Kit**  
is a frontend user interface for Xb2Input with included requirements to support Xb2Input.

The "Xbox OG Kit Installer" found inside the Zip File located in the assets below, will unpack all of Xb2Input requirements and install them for you with a progress and output tracker.

### **XboxOG Kit Installer** 
![image](https://user-images.githubusercontent.com/3674483/210187627-2dd9da28-2b58-4bd0-a7bc-4e5552a333cb.png)
![image](https://user-images.githubusercontent.com/3674483/210187765-ccc7a658-bf9d-4b70-8d0f-e10988877857.png)
![image](https://user-images.githubusercontent.com/3674483/210187660-be033f11-4cd5-496f-a80e-e0ea6adefe4b.png) 
![image](https://user-images.githubusercontent.com/3674483/210187902-0106b8a1-419a-4919-bb3b-42920e78fb85.png)

### **XboxOG Kit**!
![image](https://user-images.githubusercontent.com/3674483/210905317-0e64ca40-4fc7-4a8d-9db3-bb4ea9821860.png)


-----
Current Release Notes:
 
Notes:

• The installer will create a new registry key item for installation for future support to Xbox OG Kit and potentially the Xb2Input project (TBD). 

• The setup will install all the necessary files and run them without much human intervention.

• The Installer places shortcuts in the Start Menu after installing, so finding the Xbox OG Kit should be easy. 

• You can launch Xb2Input from the Settings dropdown menu within the Xbox OG Kit.

• Saving controller layout and clicking Apply, will close and restart Xb2Input if it is not already running.

• You can edit the guide button mappings in order to use the guide menu. 

• You can enable or disable the controller vibration.

• The Triggers and Stick Dead Zones can be fully adjusted.

• Xbox Memory Units are detected in Windows and can be used as stroage. (USB 1.0 Devices)

• See different button icons if games were designed with either the Xbox 360 or Xbox One controllers in mind. (wish all game devs added all the button icons and detected any controller precisely, including analog controllers somehow).

 

To-Do:

• Fix installer to restart PC when checkbox is checked at the final stage of installation. (This is supposed to be working but it isn't. Manual restarts will be necessary after the installer has finished.)

• Swap buttons with Remap Controller enabled.

• Run analog Driver Installer batch script in background to update the installer progressbar.

• Open Xb2Input when launching Xbox OG Kit, if it is not already running. (This does not work in the beta release)

• Add Windows startup support. (This works natively within Xb2Input at this time).   

• Detect controller and button presses from within Xbox OG Kit.

• Look into installing ViGEmBus silently or without human intervention completely.

• Update the background controller image to show the right connected controller, based on it's serial number. (such as racing wheel, or madcatz wireless controllers, etc.)

• Remove the guide button checkboxes and info key when "Enable Guide?" is disabled. (unchecked)

• Detect the Xbox Communicator and it's serial number for full headset support and Xbox Original style voice changer. (might need to make a sound device driver for this to happen much like the controllers).

• Add an Uninstaller for Xbox OG Kit to remove all of it's contents.

 

Known Bugs:

• Other controller accessories such as the headset communicator, might cause Xb2Input from being able to detect your controller. (Work around - Disconnect controller and remove accessories before reconnecting your controller into your PC. Let Xb2Input detect your controller first before plugging in any accessory into the controller.)

• Windows 11 wont start the toolbar services (i.e No clock, speakers or anything) if a controller is plugged in upon after a reboot after logging in. Current work around is reboot and disconnect your controller until after login. (This issue is Not present in Windows 10 at this time .) 

-----


**All Credits belong to:**
https://github.com/ViGEm/ViGEmBus/releases
https://github.com/emoose/Xb2XInput

**Download Zip file below:** _Other assets are Xb2InputV1.5c_
