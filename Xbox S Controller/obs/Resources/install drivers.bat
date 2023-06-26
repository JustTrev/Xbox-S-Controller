@echo off
goto start

::What this .bat does-

::Checks for administrator permissions by seeing if we can use `net session`
::then installs ScpVBus 

:start
echo Administrative permissions required. Checking permissions...
net session >nul 2>&1
if %errorLevel% neq 0 (
    echo Administrative permissions denied. Please launch as an Administrator.
    goto exit
)

cd %~dp0


cls
echo Installing WinUSB drivers for known gamepads (this might take several minutes)
echo.
echo 	Installation Percent: 0%
echo	[=-------------------------------------------------]
echo.
echo Installing Package: "Thrustmaster Controller"
wdi-simple --vid 0x044F --pid 0x0F07 --type 0 --name "Thrustmaster Controller"
echo.

cls
echo Installing WinUSB drivers for known gamepads (this might take several minutes)
echo.
echo Drivers installed: "Thrustmaster Controller"
echo.
echo 	Installation Percent: 1%
echo	[==------------------------------------------------]
echo.
echo Installing Package: "Microsoft Xbox Controller v1 (US)"
wdi-simple --vid 0x045E --pid 0x0202 --type 0 --name "Microsoft Xbox Controller v1 (US)"
echo.

cls
echo Installing WinUSB drivers for known gamepads (this might take several minutes)
echo.
echo Drivers installed: "Thrustmaster Controller"
echo Drivers installed: "Microsoft Xbox Controller v1 (US)"
echo.
echo 	Installation Percent: 2%
echo	[===-----------------------------------------------]
echo.
echo Installing Package: "Microsoft Xbox Controller S (Japan)"
wdi-simple --vid 0x045E --pid 0x0285 --type 0 --name "Microsoft Xbox Controller S (Japan)"
echo.

cls
echo Installing WinUSB drivers for known gamepads (this might take several minutes)
echo.
echo Drivers installed: "Thrustmaster Controller"
echo Drivers installed: "Microsoft Xbox Controller v1 (US)"
echo Drivers installed: "Microsoft Xbox Controller S (Japan)"
echo.
echo 	Installation Percent: 3%
echo	[====----------------------------------------------]
echo.
echo Installing Package: "Microsoft Xbox Controller S"
wdi-simple --vid 0x045E --pid 0x0287 --type 0 --name "Microsoft Xbox Controller S"
echo.

cls
echo Installing WinUSB drivers for known gamepads (this might take several minutes)
echo
echo Drivers installed: "Thrustmaster Controller"
echo Drivers installed: "Microsoft Xbox Controller v1 (US)"
echo Drivers installed: "Microsoft Xbox Controller S (Japan)"
echo Drivers installed: "Microsoft Xbox Controller S"
echo.
echo 	Installation Percent: 5%
echo	[=====---------------------------------------------]
echo.
echo Installing Package: "Microsoft Xbox Controller S v2"
wdi-simple --vid 0x045E --pid 0x0288 --type 0 --name "Microsoft Xbox Controller S v2"
echo.

cls
echo Installing WinUSB drivers for known gamepads (this might take several minutes)
echo.
echo Drivers installed: "Thrustmaster Controller"
echo Drivers installed: "Microsoft Xbox Controller v1 (US)"
echo Drivers installed: "Microsoft Xbox Controller S (Japan)"
echo Drivers installed: "Microsoft Xbox Controller S"
echo Drivers installed: "Microsoft Xbox Controller S v2" 
echo.
echo 	Installation Percent: 7%
echo	[=======-------------------------------------------]
echo.
echo Installing Package: "Microsoft Xbox Controller v2 (US)"
wdi-simple --vid 0x045E --pid 0x0289 --type 0 --name "Microsoft Xbox Controller v2 (US)"
echo.

cls
echo Installing WinUSB drivers for known gamepads (this might take several minutes)
echo.
echo Drivers installed: "Thrustmaster Controller"
echo Drivers installed: "Microsoft Xbox Controller v1 (US)"
echo Drivers installed: "Microsoft Xbox Controller S (Japan)"
echo Drivers installed: "Microsoft Xbox Controller S"
echo Drivers installed: "Microsoft Xbox Controller S v2"
echo Drivers installed: "Microsoft Xbox Controller v2 (US)" 
echo.
echo 	Installation Percent: 10%
echo	[========------------------------------------------]
echo.
echo Installing Package: "Logitech Cordless Precision"
wdi-simple --vid 0x046D --pid 0xCA84 --type 0 --name "Logitech Cordless Precision"
echo

cls
echo Installing WinUSB drivers for known gamepads (this might take several minutes)
echo.
echo Drivers installed: "Thrustmaster Controller"
echo Drivers installed: "Microsoft Xbox Controller v1 (US)"
echo Drivers installed: "Microsoft Xbox Controller S (Japan)"
echo Drivers installed: "Microsoft Xbox Controller S"
echo Drivers installed: "Microsoft Xbox Controller S v2"
echo Drivers installed: "Microsoft Xbox Controller v2 (US)"
echo Drivers installed: "Logitech Cordless Precision" 
echo.
echo 	Installation Percent: 15%
echo	[=========-----------------------------------------]
echo.
echo Installing Package: "Logitech Thunderpad"
wdi-simple --vid 0x046D --pid 0xCA88 --type 0 --name "Logitech Thunderpad"
echo.

cls
echo Installing WinUSB drivers for known gamepads (this might take several minutes)
echo.
echo Drivers installed: "Thrustmaster Controller"
echo Drivers installed: "Microsoft Xbox Controller v1 (US)"
echo Drivers installed: "Microsoft Xbox Controller S (Japan)"
echo Drivers installed: "Microsoft Xbox Controller S"
echo Drivers installed: "Microsoft Xbox Controller S v2"
echo Drivers installed: "Microsoft Xbox Controller v2 (US)"
echo Drivers installed: "Logitech Cordless Precision"
echo Drivers installed: "Logitech Thunderpad" 
echo.
echo 	Installation Percent: 19%
echo	[==========----------------------------------------]
echo.
echo Installing Package: "Mad Catz Controller (unverified)"
wdi-simple --vid 0x05FD --pid 0x1007 --type 0 --name "Mad Catz Controller (unverified)"
echo.

cls
echo Installing WinUSB drivers for known gamepads (this might take several minutes)
echo.
echo Drivers installed: "Thrustmaster Controller"
echo Drivers installed: "Microsoft Xbox Controller v1 (US)"
echo Drivers installed: "Microsoft Xbox Controller S (Japan)"
echo Drivers installed: "Microsoft Xbox Controller S"
echo Drivers installed: "Microsoft Xbox Controller S v2"
echo Drivers installed: "Microsoft Xbox Controller v2 (US)"
echo Drivers installed: "Logitech Cordless Precision"
echo Drivers installed: "Logitech Thunderpad"
echo Drivers installed: "Mad Catz Controller (unverified)" 
echo.
echo 	Installation Percent: 20%
echo	[===========---------------------------------------]
echo.
echo Installing Package: "InterAct PowerPad Pro X-box pad"
wdi-simple --vid 0x05FD --pid 0x107A --type 0 --name "InterAct PowerPad Pro X-box pad"
echo.

cls
echo Installing WinUSB drivers for known gamepads (this might take several minutes)
echo
echo Drivers installed: "Thrustmaster Controller"
echo Drivers installed: "Microsoft Xbox Controller v1 (US)"
echo Drivers installed: "Microsoft Xbox Controller S (Japan)"
echo Drivers installed: "Microsoft Xbox Controller S"
echo Drivers installed: "Microsoft Xbox Controller S v2"
echo Drivers installed: "Microsoft Xbox Controller v2 (US)"
echo Drivers installed: "Logitech Cordless Precision"
echo Drivers installed: "Logitech Thunderpad"
echo Drivers installed: "Mad Catz Controller (unverified)"
echo Drivers installed: "InterAct PowerPad Pro X-box pad" 
echo.
echo 	Installation Percent: 25%
echo	[============--------------------------------------]
echo.
echo Installing Package: "Chic Controller"
wdi-simple --vid 0x05FE --pid 0x3030 --type 0 --name "Chic Controller"
echo.

cls
echo Installing WinUSB drivers for known gamepads (this might take several minutes)
echo.
echo Drivers installed: "Thrustmaster Controller"
echo Drivers installed: "Microsoft Xbox Controller v1 (US)"
echo Drivers installed: "Microsoft Xbox Controller S (Japan)"
echo Drivers installed: "Microsoft Xbox Controller S"
echo Drivers installed: "Microsoft Xbox Controller S v2"
echo Drivers installed: "Microsoft Xbox Controller v2 (US)"
echo Drivers installed: "Logitech Cordless Precision"
echo Drivers installed: "Logitech Thunderpad"
echo Drivers installed: "Mad Catz Controller (unverified)"
echo Drivers installed: "InterAct PowerPad Pro X-box pad"
echo Drivers installed: "Chic Controller" 
echo.
echo 	Installation Percent: 27%
echo	[=============-------------------------------------]
echo.
echo Installing Package: "Chic Controller"
wdi-simple --vid 0x05FE --pid 0x3031 --type 0 --name "Chic Controller"
echo.

cls
echo Installing WinUSB drivers for known gamepads (this might take several minutes)
echo.
echo Drivers installed: "Thrustmaster Controller"
echo Drivers installed: "Microsoft Xbox Controller v1 (US)"
echo Drivers installed: "Microsoft Xbox Controller S (Japan)"
echo Drivers installed: "Microsoft Xbox Controller S"
echo Drivers installed: "Microsoft Xbox Controller S v2"
echo Drivers installed: "Microsoft Xbox Controller v2 (US)"
echo Drivers installed: "Logitech Cordless Precision"
echo Drivers installed: "Logitech Thunderpad"
echo Drivers installed: "Mad Catz Controller (unverified)"
echo Drivers installed: "InterAct PowerPad Pro X-box pad"
echo Drivers installed: "Chic Controller"
echo Drivers installed: "Chic Controller" 
echo.
echo 	Installation Percent: 33%
echo	[===============-----------------------------------]
echo.
echo Installing Package: "Logic3 Xbox GamePad"
wdi-simple --vid 0x062A --pid 0x0020 --type 0 --name "Logic3 Xbox GamePad"
echo.

cls
echo Installing WinUSB drivers for known gamepads (this might take several minutes)
echo.
echo Drivers installed: "Thrustmaster Controller"
echo Drivers installed: "Microsoft Xbox Controller v1 (US)"
echo Drivers installed: "Microsoft Xbox Controller S (Japan)"
echo Drivers installed: "Microsoft Xbox Controller S"
echo Drivers installed: "Microsoft Xbox Controller S v2"
echo Drivers installed: "Microsoft Xbox Controller v2 (US)"
echo Drivers installed: "Logitech Cordless Precision"
echo Drivers installed: "Logitech Thunderpad"
echo Drivers installed: "Mad Catz Controller (unverified)"
echo Drivers installed: "InterAct PowerPad Pro X-box pad"
echo Drivers installed: "Chic Controller"
echo Drivers installed: "Chic Controller"
echo Drivers installed: "Logic3 Xbox GamePad"  
echo.
echo 	Installation Percent: 39%
echo	[=================---------------------------------]
echo.
echo Installing Package: "Saitek Adrenalin"
wdi-simple --vid 0x06A3 --pid 0x0201 --type 0 --name "Saitek Adrenalin"
echo.

cls
echo Installing WinUSB drivers for known gamepads (this might take several minutes)
echo.
echo Drivers installed: "Thrustmaster Controller"
echo Drivers installed: "Microsoft Xbox Controller v1 (US)"
echo Drivers installed: "Microsoft Xbox Controller S (Japan)"
echo Drivers installed: "Microsoft Xbox Controller S"
echo Drivers installed: "Microsoft Xbox Controller S v2"
echo Drivers installed: "Microsoft Xbox Controller v2 (US)"
echo Drivers installed: "Logitech Cordless Precision"
echo Drivers installed: "Logitech Thunderpad"
echo Drivers installed: "Mad Catz Controller (unverified)"
echo Drivers installed: "InterAct PowerPad Pro X-box pad"
echo Drivers installed: "Chic Controller"
echo Drivers installed: "Chic Controller"
echo Drivers installed: "Logic3 Xbox GamePad" 
echo Drivers installed: "Saitek Adrenalin" 
echo.
echo 	Installation Percent: 41%
echo	[====================------------------------------]
echo.
echo Installing Package: "MadCatz 4506 Wireless Controller"
wdi-simple --vid 0x0738 --pid 0x4506 --type 0 --name "MadCatz 4506 Wireless Controller"
echo.

cls
echo Installing WinUSB drivers for known gamepads (this might take several minutes)
echo.
echo Drivers installed: "Thrustmaster Controller"
echo Drivers installed: "Microsoft Xbox Controller v1 (US)"
echo Drivers installed: "Microsoft Xbox Controller S (Japan)"
echo Drivers installed: "Microsoft Xbox Controller S"
echo Drivers installed: "Microsoft Xbox Controller S v2"
echo Drivers installed: "Microsoft Xbox Controller v2 (US)"
echo Drivers installed: "Logitech Cordless Precision"
echo Drivers installed: "Logitech Thunderpad"
echo Drivers installed: "Mad Catz Controller (unverified)"
echo Drivers installed: "InterAct PowerPad Pro X-box pad"
echo Drivers installed: "Chic Controller"
echo Drivers installed: "Chic Controller"
echo Drivers installed: "Logic3 Xbox GamePad" 
echo Drivers installed: "Saitek Adrenalin"
echo Drivers installed: "MadCatz 4506 Wireless Controller" 
echo.
echo 	Installation Percent: 44%
echo	[======================----------------------------]
echo.
echo Installing Package: "MadCatz Control Pad"
wdi-simple --vid 0x0738 --pid 0x4516 --type 0 --name "MadCatz Control Pad"
echo.

cls
echo Installing WinUSB drivers for known gamepads (this might take several minutes)
echo.
echo Drivers installed: "Thrustmaster Controller"
echo Drivers installed: "Microsoft Xbox Controller v1 (US)"
echo Drivers installed: "Microsoft Xbox Controller S (Japan)"
echo Drivers installed: "Microsoft Xbox Controller S"
echo Drivers installed: "Microsoft Xbox Controller S v2"
echo Drivers installed: "Microsoft Xbox Controller v2 (US)"
echo Drivers installed: "Logitech Cordless Precision"
echo Drivers installed: "Logitech Thunderpad"
echo Drivers installed: "Mad Catz Controller (unverified)"
echo Drivers installed: "InterAct PowerPad Pro X-box pad"
echo Drivers installed: "Chic Controller"
echo Drivers installed: "Chic Controller"
echo Drivers installed: "Logic3 Xbox GamePad" 
echo Drivers installed: "Saitek Adrenalin"
echo Drivers installed: "MadCatz 4506 Wireless Controller"
echo Drivers installed: "MadCatz Control Pad" 
echo.
echo 	Installation Percent: 45%
echo	[======================----------------------------]
echo.
echo Installing Package: "MadCatz MC2 Racing Wheel and Pedals"
wdi-simple --vid 0x0738 --pid 0x4520 --type 0 --name "MadCatz MC2 Racing Wheel and Pedals"
echo.

cls
echo Installing WinUSB drivers for known gamepads (this might take several minutes)
echo.
echo Drivers installed: "Thrustmaster Controller"
echo Drivers installed: "Microsoft Xbox Controller v1 (US)"
echo Drivers installed: "Microsoft Xbox Controller S (Japan)"
echo Drivers installed: "Microsoft Xbox Controller S"
echo Drivers installed: "Microsoft Xbox Controller S v2"
echo Drivers installed: "Microsoft Xbox Controller v2 (US)"
echo Drivers installed: "Logitech Cordless Precision"
echo Drivers installed: "Logitech Thunderpad"
echo Drivers installed: "Mad Catz Controller (unverified)"
echo Drivers installed: "InterAct PowerPad Pro X-box pad"
echo Drivers installed: "Chic Controller"
echo Drivers installed: "Chic Controller"
echo Drivers installed: "Logic3 Xbox GamePad" 
echo Drivers installed: "Saitek Adrenalin"
echo Drivers installed: "MadCatz 4506 Wireless Controller"
echo Drivers installed: "MadCatz Control Pad"
echo Drivers installed: "MadCatz MC2 Racing Wheel and Pedals" 
echo.
echo 	Installation Percent: 47%
echo	[=======================---------------------------]
echo.
echo Installing Package: "MadCatz Control Pad Pro"
wdi-simple --vid 0x0738 --pid 0x4526 --type 0 --name "MadCatz Control Pad Pro"
echo.

cls
echo Installing WinUSB drivers for known gamepads (this might take several minutes)
echo.
echo Drivers installed: "Thrustmaster Controller"
echo Drivers installed: "Microsoft Xbox Controller v1 (US)"
echo Drivers installed: "Microsoft Xbox Controller S (Japan)"
echo Drivers installed: "Microsoft Xbox Controller S"
echo Drivers installed: "Microsoft Xbox Controller S v2"
echo Drivers installed: "Microsoft Xbox Controller v2 (US)"
echo Drivers installed: "Logitech Cordless Precision"
echo Drivers installed: "Logitech Thunderpad"
echo Drivers installed: "Mad Catz Controller (unverified)"
echo Drivers installed: "InterAct PowerPad Pro X-box pad"
echo Drivers installed: "Chic Controller"
echo Drivers installed: "Chic Controller"
echo Drivers installed: "Logic3 Xbox GamePad" 
echo Drivers installed: "Saitek Adrenalin"
echo Drivers installed: "MadCatz 4506 Wireless Controller"
echo Drivers installed: "MadCatz Control Pad"
echo Drivers installed: "MadCatz MC2 Racing Wheel and Pedals"
echo Drivers installed: "MadCatz Control Pad Pro" 
echo.
echo 	Installation Percent: 50%
echo	[========================--------------------------]
echo.
echo Installing Package: "MadCatz MicroCON"
wdi-simple --vid 0x0738 --pid 0x4536 --type 0 --name "MadCatz MicroCON"
echo.

cls
echo Installing WinUSB drivers for known gamepads (this might take several minutes)
echo.
echo Drivers installed: "Thrustmaster Controller"
echo Drivers installed: "Microsoft Xbox Controller v1 (US)"
echo Drivers installed: "Microsoft Xbox Controller S (Japan)"
echo Drivers installed: "Microsoft Xbox Controller S"
echo Drivers installed: "Microsoft Xbox Controller S v2"
echo Drivers installed: "Microsoft Xbox Controller v2 (US)"
echo Drivers installed: "Logitech Cordless Precision"
echo Drivers installed: "Logitech Thunderpad"
echo Drivers installed: "Mad Catz Controller (unverified)"
echo Drivers installed: "InterAct PowerPad Pro X-box pad"
echo Drivers installed: "Chic Controller"
echo Drivers installed: "Chic Controller"
echo Drivers installed: "Logic3 Xbox GamePad" 
echo Drivers installed: "Saitek Adrenalin"
echo Drivers installed: "MadCatz 4506 Wireless Controller"
echo Drivers installed: "MadCatz Control Pad"
echo Drivers installed: "MadCatz MC2 Racing Wheel and Pedals"
echo Drivers installed: "MadCatz Control Pad Pro"
echo Drivers installed: "MadCatz MicroCON" 
echo.
echo 	Installation Percent: 50%
echo	[========================--------------------------]
echo.
echo Installing Package: "MadCatz Lynx Wireless Controller"
wdi-simple --vid 0x0738 --pid 0x4556 --type 0 --name "MadCatz Lynx Wireless Controller"
echo.

cls
echo Installing WinUSB drivers for known gamepads (this might take several minutes)
echo.
echo Drivers installed: "Thrustmaster Controller"
echo Drivers installed: "Microsoft Xbox Controller v1 (US)"
echo Drivers installed: "Microsoft Xbox Controller S (Japan)"
echo Drivers installed: "Microsoft Xbox Controller S"
echo Drivers installed: "Microsoft Xbox Controller S v2"
echo Drivers installed: "Microsoft Xbox Controller v2 (US)"
echo Drivers installed: "Logitech Cordless Precision"
echo Drivers installed: "Logitech Thunderpad"
echo Drivers installed: "Mad Catz Controller (unverified)"
echo Drivers installed: "InterAct PowerPad Pro X-box pad"
echo Drivers installed: "Chic Controller"
echo Drivers installed: "Chic Controller"
echo Drivers installed: "Logic3 Xbox GamePad" 
echo Drivers installed: "Saitek Adrenalin"
echo Drivers installed: "MadCatz 4506 Wireless Controller"
echo Drivers installed: "MadCatz Control Pad"
echo Drivers installed: "MadCatz MC2 Racing Wheel and Pedals"
echo Drivers installed: "MadCatz Control Pad Pro"
echo Drivers installed: "MadCatz MicroCON"
echo Drivers installed: "MadCatz Lynx Wireless Controller" 
echo.
echo 	Installation Percent: 52%
echo	[=========================-------------------------]
echo.
echo Installing Package: "MadCatz MicroCon Wireless Controller"
wdi-simple --vid 0x0738 --pid 0x4586 --type 0 --name "MadCatz MicroCon Wireless Controller"
echo.

cls
echo Installing WinUSB drivers for known gamepads (this might take several minutes)
echo.
echo Drivers installed: "Thrustmaster Controller"
echo Drivers installed: "Microsoft Xbox Controller v1 (US)"
echo Drivers installed: "Microsoft Xbox Controller S (Japan)"
echo Drivers installed: "Microsoft Xbox Controller S"
echo Drivers installed: "Microsoft Xbox Controller S v2"
echo Drivers installed: "Microsoft Xbox Controller v2 (US)"
echo Drivers installed: "Logitech Cordless Precision"
echo Drivers installed: "Logitech Thunderpad"
echo Drivers installed: "Mad Catz Controller (unverified)"
echo Drivers installed: "InterAct PowerPad Pro X-box pad"
echo Drivers installed: "Chic Controller"
echo Drivers installed: "Chic Controller"
echo Drivers installed: "Logic3 Xbox GamePad" 
echo Drivers installed: "Saitek Adrenalin"
echo Drivers installed: "MadCatz 4506 Wireless Controller"
echo Drivers installed: "MadCatz Control Pad"
echo Drivers installed: "MadCatz MC2 Racing Wheel and Pedals"
echo Drivers installed: "MadCatz Control Pad Pro"
echo Drivers installed: "MadCatz MicroCON"
echo Drivers installed: "MadCatz Lynx Wireless Controller"
echo Drivers installed: "MadCatz MicroCon Wireless Controller" 
echo.
echo 	Installation Percent: 54%
echo	[==========================------------------------]
echo.
echo Installing Package: "MadCatz Blaster"
wdi-simple --vid 0x0738 --pid 0x4588 --type 0 --name "MadCatz Blaster"
echo.

cls
echo Installing WinUSB drivers for known gamepads (this might take several minutes)
echo.
echo Drivers installed: "Thrustmaster Controller"
echo Drivers installed: "Microsoft Xbox Controller v1 (US)"
echo Drivers installed: "Microsoft Xbox Controller S (Japan)"
echo Drivers installed: "Microsoft Xbox Controller S"
echo Drivers installed: "Microsoft Xbox Controller S v2"
echo Drivers installed: "Microsoft Xbox Controller v2 (US)"
echo Drivers installed: "Logitech Cordless Precision"
echo Drivers installed: "Logitech Thunderpad"
echo Drivers installed: "Mad Catz Controller (unverified)"
echo Drivers installed: "InterAct PowerPad Pro X-box pad"
echo Drivers installed: "Chic Controller"
echo Drivers installed: "Chic Controller"
echo Drivers installed: "Logic3 Xbox GamePad" 
echo Drivers installed: "Saitek Adrenalin"
echo Drivers installed: "MadCatz 4506 Wireless Controller"
echo Drivers installed: "MadCatz Control Pad"
echo Drivers installed: "MadCatz MC2 Racing Wheel and Pedals"
echo Drivers installed: "MadCatz Control Pad Pro"
echo Drivers installed: "MadCatz MicroCON"
echo Drivers installed: "MadCatz Lynx Wireless Controller"
echo Drivers installed: "MadCatz MicroCon Wireless Controller"
echo Drivers installed: "MadCatz Blaster" 
echo.
echo 	Installation Percent: 55%
echo	[============================----------------------]
echo.
echo Installing Package: "Intec wireless"
wdi-simple --vid 0x0C12 --pid 0x0005 --type 0 --name "Intec wireless"
echo.

cls
echo Installing WinUSB drivers for known gamepads (this might take several minutes)
echo.
echo Drivers installed: "Thrustmaster Controller"
echo Drivers installed: "Microsoft Xbox Controller v1 (US)"
echo Drivers installed: "Microsoft Xbox Controller S (Japan)"
echo Drivers installed: "Microsoft Xbox Controller S"
echo Drivers installed: "Microsoft Xbox Controller S v2"
echo Drivers installed: "Microsoft Xbox Controller v2 (US)"
echo Drivers installed: "Logitech Cordless Precision"
echo Drivers installed: "Logitech Thunderpad"
echo Drivers installed: "Mad Catz Controller (unverified)"
echo Drivers installed: "InterAct PowerPad Pro X-box pad"
echo Drivers installed: "Chic Controller"
echo Drivers installed: "Chic Controller"
echo Drivers installed: "Logic3 Xbox GamePad" 
echo Drivers installed: "Saitek Adrenalin"
echo Drivers installed: "MadCatz 4506 Wireless Controller"
echo Drivers installed: "MadCatz Control Pad"
echo Drivers installed: "MadCatz MC2 Racing Wheel and Pedals"
echo Drivers installed: "MadCatz Control Pad Pro"
echo Drivers installed: "MadCatz MicroCON"
echo Drivers installed: "MadCatz Lynx Wireless Controller"
echo Drivers installed: "MadCatz MicroCon Wireless Controller"
echo Drivers installed: "MadCatz Blaster"
echo Drivers installed: "Intec wireless" 
echo.
echo 	Installation Percent: 57%
echo	[==============================--------------------]
echo.
echo Installing Package: "Nyko Xbox Controller"
wdi-simple --vid 0x0C12 --pid 0x8801 --type 0 --name "Nyko Xbox Controller"
echo.

cls
echo Installing WinUSB drivers for known gamepads (this might take several minutes)
echo.
echo Drivers installed: "Thrustmaster Controller"
echo Drivers installed: "Microsoft Xbox Controller v1 (US)"
echo Drivers installed: "Microsoft Xbox Controller S (Japan)"
echo Drivers installed: "Microsoft Xbox Controller S"
echo Drivers installed: "Microsoft Xbox Controller S v2"
echo Drivers installed: "Microsoft Xbox Controller v2 (US)"
echo Drivers installed: "Logitech Cordless Precision"
echo Drivers installed: "Logitech Thunderpad"
echo Drivers installed: "Mad Catz Controller (unverified)"
echo Drivers installed: "InterAct PowerPad Pro X-box pad"
echo Drivers installed: "Chic Controller"
echo Drivers installed: "Chic Controller"
echo Drivers installed: "Logic3 Xbox GamePad" 
echo Drivers installed: "Saitek Adrenalin"
echo Drivers installed: "MadCatz 4506 Wireless Controller"
echo Drivers installed: "MadCatz Control Pad"
echo Drivers installed: "MadCatz MC2 Racing Wheel and Pedals"
echo Drivers installed: "MadCatz Control Pad Pro"
echo Drivers installed: "MadCatz MicroCON"
echo Drivers installed: "MadCatz Lynx Wireless Controller"
echo Drivers installed: "MadCatz MicroCon Wireless Controller"
echo Drivers installed: "MadCatz Blaster"
echo Drivers installed: "Intec wireless"
echo Drivers installed: "Nyko Xbox Controller"  
echo.
echo 	Installation Percent: 60%
echo	[===============================-------------------]
echo.
echo Installing Package: "Zeroplus Xbox Controller"
wdi-simple --vid 0x0C12 --pid 0x8802 --type 0 --name "Zeroplus Xbox Controller"
echo.

cls
echo Installing WinUSB drivers for known gamepads (this might take several minutes)
echo.
echo Drivers installed: "Thrustmaster Controller"
echo Drivers installed: "Microsoft Xbox Controller v1 (US)"
echo Drivers installed: "Microsoft Xbox Controller S (Japan)"
echo Drivers installed: "Microsoft Xbox Controller S"
echo Drivers installed: "Microsoft Xbox Controller S v2"
echo Drivers installed: "Microsoft Xbox Controller v2 (US)"
echo Drivers installed: "Logitech Cordless Precision"
echo Drivers installed: "Logitech Thunderpad"
echo Drivers installed: "Mad Catz Controller (unverified)"
echo Drivers installed: "InterAct PowerPad Pro X-box pad"
echo Drivers installed: "Chic Controller"
echo Drivers installed: "Chic Controller"
echo Drivers installed: "Logic3 Xbox GamePad" 
echo Drivers installed: "Saitek Adrenalin"
echo Drivers installed: "MadCatz 4506 Wireless Controller"
echo Drivers installed: "MadCatz Control Pad"
echo Drivers installed: "MadCatz MC2 Racing Wheel and Pedals"
echo Drivers installed: "MadCatz Control Pad Pro"
echo Drivers installed: "MadCatz MicroCON"
echo Drivers installed: "MadCatz Lynx Wireless Controller"
echo Drivers installed: "MadCatz MicroCon Wireless Controller"
echo Drivers installed: "MadCatz Blaster"
echo Drivers installed: "Intec wireless"
echo Drivers installed: "Nyko Xbox Controller"
echo Drivers installed: "Zeroplus Xbox Controller" 
echo.
echo 	Installation Percent: 61%
echo	[===============================-------------------]
echo.
echo Installing Package: "Pelican Eclipse PL-2023"
wdi-simple --vid 0x0C12 --pid 0x880A --type 0 --name "Pelican Eclipse PL-2023"
echo.

cls
echo Installing WinUSB drivers for known gamepads (this might take several minutes)
echo.
echo Drivers installed: "Thrustmaster Controller"
echo Drivers installed: "Microsoft Xbox Controller v1 (US)"
echo Drivers installed: "Microsoft Xbox Controller S (Japan)"
echo Drivers installed: "Microsoft Xbox Controller S"
echo Drivers installed: "Microsoft Xbox Controller S v2"
echo Drivers installed: "Microsoft Xbox Controller v2 (US)"
echo Drivers installed: "Logitech Cordless Precision"
echo Drivers installed: "Logitech Thunderpad"
echo Drivers installed: "Mad Catz Controller (unverified)"
echo Drivers installed: "InterAct PowerPad Pro X-box pad"
echo Drivers installed: "Chic Controller"
echo Drivers installed: "Chic Controller"
echo Drivers installed: "Logic3 Xbox GamePad" 
echo Drivers installed: "Saitek Adrenalin"
echo Drivers installed: "MadCatz 4506 Wireless Controller"
echo Drivers installed: "MadCatz Control Pad"
echo Drivers installed: "MadCatz MC2 Racing Wheel and Pedals"
echo Drivers installed: "MadCatz Control Pad Pro"
echo Drivers installed: "MadCatz MicroCON"
echo Drivers installed: "MadCatz Lynx Wireless Controller"
echo Drivers installed: "MadCatz MicroCon Wireless Controller"
echo Drivers installed: "MadCatz Blaster"
echo Drivers installed: "Intec wireless"
echo Drivers installed: "Nyko Xbox Controller"
echo Drivers installed: "Zeroplus Xbox Controller"
echo Drivers installed: "Pelican Eclipse PL-2023" 
echo.
echo 	Installation Percent: 64%
echo	[================================------------------]
echo.
echo Installing Package: "Zeroplus Xbox Controller"
wdi-simple --vid 0x0C12 --pid 0x8810 --type 0 --name "Zeroplus Xbox Controller"
echo.

cls
echo Installing WinUSB drivers for known gamepads (this might take several minutes)
echo.
echo Drivers installed: "Thrustmaster Controller"
echo Drivers installed: "Microsoft Xbox Controller v1 (US)"
echo Drivers installed: "Microsoft Xbox Controller S (Japan)"
echo Drivers installed: "Microsoft Xbox Controller S"
echo Drivers installed: "Microsoft Xbox Controller S v2"
echo Drivers installed: "Microsoft Xbox Controller v2 (US)"
echo Drivers installed: "Logitech Cordless Precision"
echo Drivers installed: "Logitech Thunderpad"
echo Drivers installed: "Mad Catz Controller (unverified)"
echo Drivers installed: "InterAct PowerPad Pro X-box pad"
echo Drivers installed: "Chic Controller"
echo Drivers installed: "Chic Controller"
echo Drivers installed: "Logic3 Xbox GamePad" 
echo Drivers installed: "Saitek Adrenalin"
echo Drivers installed: "MadCatz 4506 Wireless Controller"
echo Drivers installed: "MadCatz Control Pad"
echo Drivers installed: "MadCatz MC2 Racing Wheel and Pedals"
echo Drivers installed: "MadCatz Control Pad Pro"
echo Drivers installed: "MadCatz MicroCON"
echo Drivers installed: "MadCatz Lynx Wireless Controller"
echo Drivers installed: "MadCatz MicroCon Wireless Controller"
echo Drivers installed: "MadCatz Blaster"
echo Drivers installed: "Intec wireless"
echo Drivers installed: "Nyko Xbox Controller"
echo Drivers installed: "Zeroplus Xbox Controller"
echo Drivers installed: "Pelican Eclipse PL-2023"
echo Drivers installed: "Zeroplus Xbox Controller" 
echo.
echo 	Installation Percent: 67%
echo	[==================================----------------]
echo.
echo Installing Package: "HAMA VibraX - "FAULTY HARDWARE""
wdi-simple --vid 0x0C12 --pid 0x9902 --type 0 --name "HAMA VibraX - "FAULTY HARDWARE""
echo.

cls
echo Installing WinUSB drivers for known gamepads (this might take several minutes)
echo.
echo Drivers installed: "Thrustmaster Controller"
echo Drivers installed: "Microsoft Xbox Controller v1 (US)"
echo Drivers installed: "Microsoft Xbox Controller S (Japan)"
echo Drivers installed: "Microsoft Xbox Controller S"
echo Drivers installed: "Microsoft Xbox Controller S v2"
echo Drivers installed: "Microsoft Xbox Controller v2 (US)"
echo Drivers installed: "Logitech Cordless Precision"
echo Drivers installed: "Logitech Thunderpad"
echo Drivers installed: "Mad Catz Controller (unverified)"
echo Drivers installed: "InterAct PowerPad Pro X-box pad"
echo Drivers installed: "Chic Controller"
echo Drivers installed: "Chic Controller"
echo Drivers installed: "Logic3 Xbox GamePad" 
echo Drivers installed: "Saitek Adrenalin"
echo Drivers installed: "MadCatz 4506 Wireless Controller"
echo Drivers installed: "MadCatz Control Pad"
echo Drivers installed: "MadCatz MC2 Racing Wheel and Pedals"
echo Drivers installed: "MadCatz Control Pad Pro"
echo Drivers installed: "MadCatz MicroCON"
echo Drivers installed: "MadCatz Lynx Wireless Controller"
echo Drivers installed: "MadCatz MicroCon Wireless Controller"
echo Drivers installed: "MadCatz Blaster"
echo Drivers installed: "Intec wireless"
echo Drivers installed: "Nyko Xbox Controller"
echo Drivers installed: "Zeroplus Xbox Controller"
echo Drivers installed: "Pelican Eclipse PL-2023"
echo Drivers installed: "Zeroplus Xbox Controller"
echo Drivers installed: "HAMA VibraX - "FAULTY HARDWARE"" 
echo.
echo 	Installation Percent: 68%
echo	[===================================---------------]
echo.
echo Installing Package: "Radica Gamester Controller"
wdi-simple --vid 0x0E4C --pid 0x1097 --type 0 --name "Radica Gamester Controller"
echo.

cls
echo Installing WinUSB drivers for known gamepads (this might take several minutes)
echo.
echo Drivers installed: "Thrustmaster Controller"
echo Drivers installed: "Microsoft Xbox Controller v1 (US)"
echo Drivers installed: "Microsoft Xbox Controller S (Japan)"
echo Drivers installed: "Microsoft Xbox Controller S"
echo Drivers installed: "Microsoft Xbox Controller S v2"
echo Drivers installed: "Microsoft Xbox Controller v2 (US)"
echo Drivers installed: "Logitech Cordless Precision"
echo Drivers installed: "Logitech Thunderpad"
echo Drivers installed: "Mad Catz Controller (unverified)"
echo Drivers installed: "InterAct PowerPad Pro X-box pad"
echo Drivers installed: "Chic Controller"
echo Drivers installed: "Chic Controller"
echo Drivers installed: "Logic3 Xbox GamePad" 
echo Drivers installed: "Saitek Adrenalin"
echo Drivers installed: "MadCatz 4506 Wireless Controller"
echo Drivers installed: "MadCatz Control Pad"
echo Drivers installed: "MadCatz MC2 Racing Wheel and Pedals"
echo Drivers installed: "MadCatz Control Pad Pro"
echo Drivers installed: "MadCatz MicroCON"
echo Drivers installed: "MadCatz Lynx Wireless Controller"
echo Drivers installed: "MadCatz MicroCon Wireless Controller"
echo Drivers installed: "MadCatz Blaster"
echo Drivers installed: "Intec wireless"
echo Drivers installed: "Nyko Xbox Controller"
echo Drivers installed: "Zeroplus Xbox Controller"
echo Drivers installed: "Pelican Eclipse PL-2023"
echo Drivers installed: "Zeroplus Xbox Controller"
echo Drivers installed: "HAMA VibraX - "FAULTY HARDWARE""
echo Drivers installed: "Radica Gamester Controller" 
echo.
echo 	Installation Percent: 69%
echo	[====================================--------------]
echo.
echo Installing Package: "Radica Games Jtech Controller"
wdi-simple --vid 0x0E4C --pid 0x2390 --type 0 --name "Radica Games Jtech Controller"
echo.

cls
echo Installing WinUSB drivers for known gamepads (this might take several minutes)
echo.
echo Drivers installed: "Thrustmaster Controller"
echo Drivers installed: "Microsoft Xbox Controller v1 (US)"
echo Drivers installed: "Microsoft Xbox Controller S (Japan)"
echo Drivers installed: "Microsoft Xbox Controller S"
echo Drivers installed: "Microsoft Xbox Controller S v2"
echo Drivers installed: "Microsoft Xbox Controller v2 (US)"
echo Drivers installed: "Logitech Cordless Precision"
echo Drivers installed: "Logitech Thunderpad"
echo Drivers installed: "Mad Catz Controller (unverified)"
echo Drivers installed: "InterAct PowerPad Pro X-box pad"
echo Drivers installed: "Chic Controller"
echo Drivers installed: "Chic Controller"
echo Drivers installed: "Logic3 Xbox GamePad" 
echo Drivers installed: "Saitek Adrenalin"
echo Drivers installed: "MadCatz 4506 Wireless Controller"
echo Drivers installed: "MadCatz Control Pad"
echo Drivers installed: "MadCatz MC2 Racing Wheel and Pedals"
echo Drivers installed: "MadCatz Control Pad Pro"
echo Drivers installed: "MadCatz MicroCON"
echo Drivers installed: "MadCatz Lynx Wireless Controller"
echo Drivers installed: "MadCatz MicroCon Wireless Controller"
echo Drivers installed: "MadCatz Blaster"
echo Drivers installed: "Intec wireless"
echo Drivers installed: "Nyko Xbox Controller"
echo Drivers installed: "Zeroplus Xbox Controller"
echo Drivers installed: "Pelican Eclipse PL-2023"
echo Drivers installed: "Zeroplus Xbox Controller"
echo Drivers installed: "HAMA VibraX - "FAULTY HARDWARE""
echo Drivers installed: "Radica Gamester Controller"
echo Drivers installed: "Radica Games Jtech Controller" 
echo.
echo 	Installation Percent: 70%
echo	[=====================================-------------]
echo.
echo Installing Package: "Radica Gamester"
wdi-simple --vid 0x0E4C --pid 0x3240 --type 0 --name "Radica Gamester"
echo.

cls
echo Installing WinUSB drivers for known gamepads (this might take several minutes)
echo.
echo Drivers installed: "Thrustmaster Controller"
echo Drivers installed: "Microsoft Xbox Controller v1 (US)"
echo Drivers installed: "Microsoft Xbox Controller S (Japan)"
echo Drivers installed: "Microsoft Xbox Controller S"
echo Drivers installed: "Microsoft Xbox Controller S v2"
echo Drivers installed: "Microsoft Xbox Controller v2 (US)"
echo Drivers installed: "Logitech Cordless Precision"
echo Drivers installed: "Logitech Thunderpad"
echo Drivers installed: "Mad Catz Controller (unverified)"
echo Drivers installed: "InterAct PowerPad Pro X-box pad"
echo Drivers installed: "Chic Controller"
echo Drivers installed: "Chic Controller"
echo Drivers installed: "Logic3 Xbox GamePad" 
echo Drivers installed: "Saitek Adrenalin"
echo Drivers installed: "MadCatz 4506 Wireless Controller"
echo Drivers installed: "MadCatz Control Pad"
echo Drivers installed: "MadCatz MC2 Racing Wheel and Pedals"
echo Drivers installed: "MadCatz Control Pad Pro"
echo Drivers installed: "MadCatz MicroCON"
echo Drivers installed: "MadCatz Lynx Wireless Controller"
echo Drivers installed: "MadCatz MicroCon Wireless Controller"
echo Drivers installed: "MadCatz Blaster"
echo Drivers installed: "Intec wireless"
echo Drivers installed: "Nyko Xbox Controller"
echo Drivers installed: "Zeroplus Xbox Controller"
echo Drivers installed: "Pelican Eclipse PL-2023"
echo Drivers installed: "Zeroplus Xbox Controller"
echo Drivers installed: "HAMA VibraX - "FAULTY HARDWARE""
echo Drivers installed: "Radica Gamester Controller"
echo Drivers installed: "Radica Games Jtech Controller"
echo Drivers installed: "Radica Gamester" 
echo.
echo 	Installation Percent: 71%
echo	[=====================================-------------]
echo.
echo Installing Package: "Radica Gamester"
wdi-simple --vid 0x0E4C --pid 0x3510 --type 0 --name "Radica Gamester"
echo.

cls
echo Installing WinUSB drivers for known gamepads (this might take several minutes)
echo.
echo Drivers installed: "Thrustmaster Controller"
echo Drivers installed: "Microsoft Xbox Controller v1 (US)"
echo Drivers installed: "Microsoft Xbox Controller S (Japan)"
echo Drivers installed: "Microsoft Xbox Controller S"
echo Drivers installed: "Microsoft Xbox Controller S v2"
echo Drivers installed: "Microsoft Xbox Controller v2 (US)"
echo Drivers installed: "Logitech Cordless Precision"
echo Drivers installed: "Logitech Thunderpad"
echo Drivers installed: "Mad Catz Controller (unverified)"
echo Drivers installed: "InterAct PowerPad Pro X-box pad"
echo Drivers installed: "Chic Controller"
echo Drivers installed: "Chic Controller"
echo Drivers installed: "Logic3 Xbox GamePad" 
echo Drivers installed: "Saitek Adrenalin"
echo Drivers installed: "MadCatz 4506 Wireless Controller"
echo Drivers installed: "MadCatz Control Pad"
echo Drivers installed: "MadCatz MC2 Racing Wheel and Pedals"
echo Drivers installed: "MadCatz Control Pad Pro"
echo Drivers installed: "MadCatz MicroCON"
echo Drivers installed: "MadCatz Lynx Wireless Controller"
echo Drivers installed: "MadCatz MicroCon Wireless Controller"
echo Drivers installed: "MadCatz Blaster"
echo Drivers installed: "Intec wireless"
echo Drivers installed: "Nyko Xbox Controller"
echo Drivers installed: "Zeroplus Xbox Controller"
echo Drivers installed: "Pelican Eclipse PL-2023"
echo Drivers installed: "Zeroplus Xbox Controller"
echo Drivers installed: "HAMA VibraX - "FAULTY HARDWARE""
echo Drivers installed: "Radica Gamester Controller"
echo Drivers installed: "Radica Games Jtech Controller"
echo Drivers installed: "Radica Gamester"
echo Drivers installed: "Radica Gamester" 
echo.
echo 	Installation Percent: 73%
echo	[======================================------------]
echo.
echo Installing Package: "Logic3 Freebird wireless Controller"
wdi-simple --vid 0x0E6F --pid 0x0003 --type 0 --name "Logic3 Freebird wireless Controller"
echo.

cls
echo Installing WinUSB drivers for known gamepads (this might take several minutes)
echo.
echo Drivers installed: "Thrustmaster Controller"
echo Drivers installed: "Microsoft Xbox Controller v1 (US)"
echo Drivers installed: "Microsoft Xbox Controller S (Japan)"
echo Drivers installed: "Microsoft Xbox Controller S"
echo Drivers installed: "Microsoft Xbox Controller S v2"
echo Drivers installed: "Microsoft Xbox Controller v2 (US)"
echo Drivers installed: "Logitech Cordless Precision"
echo Drivers installed: "Logitech Thunderpad"
echo Drivers installed: "Mad Catz Controller (unverified)"
echo Drivers installed: "InterAct PowerPad Pro X-box pad"
echo Drivers installed: "Chic Controller"
echo Drivers installed: "Chic Controller"
echo Drivers installed: "Logic3 Xbox GamePad" 
echo Drivers installed: "Saitek Adrenalin"
echo Drivers installed: "MadCatz 4506 Wireless Controller"
echo Drivers installed: "MadCatz Control Pad"
echo Drivers installed: "MadCatz MC2 Racing Wheel and Pedals"
echo Drivers installed: "MadCatz Control Pad Pro"
echo Drivers installed: "MadCatz MicroCON"
echo Drivers installed: "MadCatz Lynx Wireless Controller"
echo Drivers installed: "MadCatz MicroCon Wireless Controller"
echo Drivers installed: "MadCatz Blaster"
echo Drivers installed: "Intec wireless"
echo Drivers installed: "Nyko Xbox Controller"
echo Drivers installed: "Zeroplus Xbox Controller"
echo Drivers installed: "Pelican Eclipse PL-2023"
echo Drivers installed: "Zeroplus Xbox Controller"
echo Drivers installed: "HAMA VibraX - "FAULTY HARDWARE""
echo Drivers installed: "Radica Gamester Controller"
echo Drivers installed: "Radica Games Jtech Controller"
echo Drivers installed: "Radica Gamester"
echo Drivers installed: "Radica Gamester"
echo Drivers installed: "Logic3 Freebird wireless Controller" 
echo.
echo 	Installation Percent: 75%
echo	[=======================================-----------]
echo.
echo Installing Package: "Eclipse wireless Controller"
wdi-simple --vid 0x0E6F --pid 0x0005 --type 0 --name "Eclipse wireless Controller"
echo.

cls
echo Installing WinUSB drivers for known gamepads (this might take several minutes)
echo.
echo Drivers installed: "Thrustmaster Controller"
echo Drivers installed: "Microsoft Xbox Controller v1 (US)"
echo Drivers installed: "Microsoft Xbox Controller S (Japan)"
echo Drivers installed: "Microsoft Xbox Controller S"
echo Drivers installed: "Microsoft Xbox Controller S v2"
echo Drivers installed: "Microsoft Xbox Controller v2 (US)"
echo Drivers installed: "Logitech Cordless Precision"
echo Drivers installed: "Logitech Thunderpad"
echo Drivers installed: "Mad Catz Controller (unverified)"
echo Drivers installed: "InterAct PowerPad Pro X-box pad"
echo Drivers installed: "Chic Controller"
echo Drivers installed: "Chic Controller"
echo Drivers installed: "Logic3 Xbox GamePad" 
echo Drivers installed: "Saitek Adrenalin"
echo Drivers installed: "MadCatz 4506 Wireless Controller"
echo Drivers installed: "MadCatz Control Pad"
echo Drivers installed: "MadCatz MC2 Racing Wheel and Pedals"
echo Drivers installed: "MadCatz Control Pad Pro"
echo Drivers installed: "MadCatz MicroCON"
echo Drivers installed: "MadCatz Lynx Wireless Controller"
echo Drivers installed: "MadCatz MicroCon Wireless Controller"
echo Drivers installed: "MadCatz Blaster"
echo Drivers installed: "Intec wireless"
echo Drivers installed: "Nyko Xbox Controller"
echo Drivers installed: "Zeroplus Xbox Controller"
echo Drivers installed: "Pelican Eclipse PL-2023"
echo Drivers installed: "Zeroplus Xbox Controller"
echo Drivers installed: "HAMA VibraX - "FAULTY HARDWARE""
echo Drivers installed: "Radica Gamester Controller"
echo Drivers installed: "Radica Games Jtech Controller"
echo Drivers installed: "Radica Gamester"
echo Drivers installed: "Radica Gamester"
echo Drivers installed: "Logic3 Freebird wireless Controller" 
echo Drivers installed: "Eclipse wireless Controller" 
echo.
echo 	Installation Percent: 78%
echo	[========================================----------]
echo.
echo Installing Package: "Edge wireless Controller"
wdi-simple --vid 0x0E6F --pid 0x0006 --type 0 --name "Edge wireless Controller"
echo.

cls
echo Installing WinUSB drivers for known gamepads (this might take several minutes)
echo.
echo Drivers installed: "Thrustmaster Controller"
echo Drivers installed: "Microsoft Xbox Controller v1 (US)"
echo Drivers installed: "Microsoft Xbox Controller S (Japan)"
echo Drivers installed: "Microsoft Xbox Controller S"
echo Drivers installed: "Microsoft Xbox Controller S v2"
echo Drivers installed: "Microsoft Xbox Controller v2 (US)"
echo Drivers installed: "Logitech Cordless Precision"
echo Drivers installed: "Logitech Thunderpad"
echo Drivers installed: "Mad Catz Controller (unverified)"
echo Drivers installed: "InterAct PowerPad Pro X-box pad"
echo Drivers installed: "Chic Controller"
echo Drivers installed: "Chic Controller"
echo Drivers installed: "Logic3 Xbox GamePad" 
echo Drivers installed: "Saitek Adrenalin"
echo Drivers installed: "MadCatz 4506 Wireless Controller"
echo Drivers installed: "MadCatz Control Pad"
echo Drivers installed: "MadCatz MC2 Racing Wheel and Pedals"
echo Drivers installed: "MadCatz Control Pad Pro"
echo Drivers installed: "MadCatz MicroCON"
echo Drivers installed: "MadCatz Lynx Wireless Controller"
echo Drivers installed: "MadCatz MicroCon Wireless Controller"
echo Drivers installed: "MadCatz Blaster"
echo Drivers installed: "Intec wireless"
echo Drivers installed: "Nyko Xbox Controller"
echo Drivers installed: "Zeroplus Xbox Controller"
echo Drivers installed: "Pelican Eclipse PL-2023"
echo Drivers installed: "Zeroplus Xbox Controller"
echo Drivers installed: "HAMA VibraX - "FAULTY HARDWARE""
echo Drivers installed: "Radica Gamester Controller"
echo Drivers installed: "Radica Games Jtech Controller"
echo Drivers installed: "Radica Gamester"
echo Drivers installed: "Radica Gamester"
echo Drivers installed: "Logic3 Freebird wireless Controller" 
echo Drivers installed: "Eclipse wireless Controller"
echo Drivers installed: "Edge wireless Controller" 
echo.
echo 	Installation Percent: 82%
echo	[==========================================--------]
echo.
echo Installing Package: "After Glow Pro Controller"
wdi-simple --vid 0x0E6F --pid 0x0008 --type 0 --name "After Glow Pro Controller"
echo.

cls
echo Installing WinUSB drivers for known gamepads (this might take several minutes)
echo.
echo Drivers installed: "Thrustmaster Controller"
echo Drivers installed: "Microsoft Xbox Controller v1 (US)"
echo Drivers installed: "Microsoft Xbox Controller S (Japan)"
echo Drivers installed: "Microsoft Xbox Controller S"
echo Drivers installed: "Microsoft Xbox Controller S v2"
echo Drivers installed: "Microsoft Xbox Controller v2 (US)"
echo Drivers installed: "Logitech Cordless Precision"
echo Drivers installed: "Logitech Thunderpad"
echo Drivers installed: "Mad Catz Controller (unverified)"
echo Drivers installed: "InterAct PowerPad Pro X-box pad"
echo Drivers installed: "Chic Controller"
echo Drivers installed: "Chic Controller"
echo Drivers installed: "Logic3 Xbox GamePad" 
echo Drivers installed: "Saitek Adrenalin"
echo Drivers installed: "MadCatz 4506 Wireless Controller"
echo Drivers installed: "MadCatz Control Pad"
echo Drivers installed: "MadCatz MC2 Racing Wheel and Pedals"
echo Drivers installed: "MadCatz Control Pad Pro"
echo Drivers installed: "MadCatz MicroCON"
echo Drivers installed: "MadCatz Lynx Wireless Controller"
echo Drivers installed: "MadCatz MicroCon Wireless Controller"
echo Drivers installed: "MadCatz Blaster"
echo Drivers installed: "Intec wireless"
echo Drivers installed: "Nyko Xbox Controller"
echo Drivers installed: "Zeroplus Xbox Controller"
echo Drivers installed: "Pelican Eclipse PL-2023"
echo Drivers installed: "Zeroplus Xbox Controller"
echo Drivers installed: "HAMA VibraX - "FAULTY HARDWARE""
echo Drivers installed: "Radica Gamester Controller"
echo Drivers installed: "Radica Games Jtech Controller"
echo Drivers installed: "Radica Gamester"
echo Drivers installed: "Radica Gamester"
echo Drivers installed: "Logic3 Freebird wireless Controller" 
echo Drivers installed: "Eclipse wireless Controller"
echo Drivers installed: "Edge wireless Controller"
echo Drivers installed: "After Glow Pro Controller" 
echo.
echo 	Installation Percent: 85%
echo	[==========================================--------]
echo.
echo Installing Package: "Philips Recoil"
wdi-simple --vid 0x0F30 --pid 0x010B --type 0 --name "Philips Recoil"
echo.

cls
echo Installing WinUSB drivers for known gamepads (this might take several minutes)
echo.
echo Drivers installed: "Thrustmaster Controller"
echo Drivers installed: "Microsoft Xbox Controller v1 (US)"
echo Drivers installed: "Microsoft Xbox Controller S (Japan)"
echo Drivers installed: "Microsoft Xbox Controller S"
echo Drivers installed: "Microsoft Xbox Controller S v2"
echo Drivers installed: "Microsoft Xbox Controller v2 (US)"
echo Drivers installed: "Logitech Cordless Precision"
echo Drivers installed: "Logitech Thunderpad"
echo Drivers installed: "Mad Catz Controller (unverified)"
echo Drivers installed: "InterAct PowerPad Pro X-box pad"
echo Drivers installed: "Chic Controller"
echo Drivers installed: "Chic Controller"
echo Drivers installed: "Logic3 Xbox GamePad" 
echo Drivers installed: "Saitek Adrenalin"
echo Drivers installed: "MadCatz 4506 Wireless Controller"
echo Drivers installed: "MadCatz Control Pad"
echo Drivers installed: "MadCatz MC2 Racing Wheel and Pedals"
echo Drivers installed: "MadCatz Control Pad Pro"
echo Drivers installed: "MadCatz MicroCON"
echo Drivers installed: "MadCatz Lynx Wireless Controller"
echo Drivers installed: "MadCatz MicroCon Wireless Controller"
echo Drivers installed: "MadCatz Blaster"
echo Drivers installed: "Intec wireless"
echo Drivers installed: "Nyko Xbox Controller"
echo Drivers installed: "Zeroplus Xbox Controller"
echo Drivers installed: "Pelican Eclipse PL-2023"
echo Drivers installed: "Zeroplus Xbox Controller"
echo Drivers installed: "HAMA VibraX - "FAULTY HARDWARE""
echo Drivers installed: "Radica Gamester Controller"
echo Drivers installed: "Radica Games Jtech Controller"
echo Drivers installed: "Radica Gamester"
echo Drivers installed: "Radica Gamester"
echo Drivers installed: "Logic3 Freebird wireless Controller" 
echo Drivers installed: "Eclipse wireless Controller"
echo Drivers installed: "Edge wireless Controller"
echo Drivers installed: "After Glow Pro Controller"
echo Drivers installed: "Philips Recoil" 
echo.
echo 	Installation Percent: 87%
echo	[============================================------]
echo.
echo Installing Package: "Joytech Advanced Controller"
wdi-simple --vid 0x0F30 --pid 0x0202 --type 0 --name "Joytech Advanced Controller"
echo.

cls
echo Installing WinUSB drivers for known gamepads (this might take several minutes)
echo.
echo Drivers installed: "Thrustmaster Controller"
echo Drivers installed: "Microsoft Xbox Controller v1 (US)"
echo Drivers installed: "Microsoft Xbox Controller S (Japan)"
echo Drivers installed: "Microsoft Xbox Controller S"
echo Drivers installed: "Microsoft Xbox Controller S v2"
echo Drivers installed: "Microsoft Xbox Controller v2 (US)"
echo Drivers installed: "Logitech Cordless Precision"
echo Drivers installed: "Logitech Thunderpad"
echo Drivers installed: "Mad Catz Controller (unverified)"
echo Drivers installed: "InterAct PowerPad Pro X-box pad"
echo Drivers installed: "Chic Controller"
echo Drivers installed: "Chic Controller"
echo Drivers installed: "Logic3 Xbox GamePad" 
echo Drivers installed: "Saitek Adrenalin"
echo Drivers installed: "MadCatz 4506 Wireless Controller"
echo Drivers installed: "MadCatz Control Pad"
echo Drivers installed: "MadCatz MC2 Racing Wheel and Pedals"
echo Drivers installed: "MadCatz Control Pad Pro"
echo Drivers installed: "MadCatz MicroCON"
echo Drivers installed: "MadCatz Lynx Wireless Controller"
echo Drivers installed: "MadCatz MicroCon Wireless Controller"
echo Drivers installed: "MadCatz Blaster"
echo Drivers installed: "Intec wireless"
echo Drivers installed: "Nyko Xbox Controller"
echo Drivers installed: "Zeroplus Xbox Controller"
echo Drivers installed: "Pelican Eclipse PL-2023"
echo Drivers installed: "Zeroplus Xbox Controller"
echo Drivers installed: "HAMA VibraX - "FAULTY HARDWARE""
echo Drivers installed: "Radica Gamester Controller"
echo Drivers installed: "Radica Games Jtech Controller"
echo Drivers installed: "Radica Gamester"
echo Drivers installed: "Radica Gamester"
echo Drivers installed: "Logic3 Freebird wireless Controller" 
echo Drivers installed: "Eclipse wireless Controller"
echo Drivers installed: "Edge wireless Controller"
echo Drivers installed: "After Glow Pro Controller"
echo Drivers installed: "Philips Recoil"
echo Drivers installed: "Joytech Advanced Controller" 
echo.
echo 	Installation Percent: 89%
echo	[=============================================-----]
echo.
echo Installing Package: "BigBen XBMiniPad Controller"
wdi-simple --vid 0x0F30 --pid 0x8888 --type 0 --name "BigBen XBMiniPad Controller"
echo.

cls
echo Installing WinUSB drivers for known gamepads (this might take several minutes)
echo.
echo Drivers installed: "Thrustmaster Controller"
echo Drivers installed: "Microsoft Xbox Controller v1 (US)"
echo Drivers installed: "Microsoft Xbox Controller S (Japan)"
echo Drivers installed: "Microsoft Xbox Controller S"
echo Drivers installed: "Microsoft Xbox Controller S v2"
echo Drivers installed: "Microsoft Xbox Controller v2 (US)"
echo Drivers installed: "Logitech Cordless Precision"
echo Drivers installed: "Logitech Thunderpad"
echo Drivers installed: "Mad Catz Controller (unverified)"
echo Drivers installed: "InterAct PowerPad Pro X-box pad"
echo Drivers installed: "Chic Controller"
echo Drivers installed: "Chic Controller"
echo Drivers installed: "Logic3 Xbox GamePad" 
echo Drivers installed: "Saitek Adrenalin"
echo Drivers installed: "MadCatz 4506 Wireless Controller"
echo Drivers installed: "MadCatz Control Pad"
echo Drivers installed: "MadCatz MC2 Racing Wheel and Pedals"
echo Drivers installed: "MadCatz Control Pad Pro"
echo Drivers installed: "MadCatz MicroCON"
echo Drivers installed: "MadCatz Lynx Wireless Controller"
echo Drivers installed: "MadCatz MicroCon Wireless Controller"
echo Drivers installed: "MadCatz Blaster"
echo Drivers installed: "Intec wireless"
echo Drivers installed: "Nyko Xbox Controller"
echo Drivers installed: "Zeroplus Xbox Controller"
echo Drivers installed: "Pelican Eclipse PL-2023"
echo Drivers installed: "Zeroplus Xbox Controller"
echo Drivers installed: "HAMA VibraX - "FAULTY HARDWARE""
echo Drivers installed: "Radica Gamester Controller"
echo Drivers installed: "Radica Games Jtech Controller"
echo Drivers installed: "Radica Gamester"
echo Drivers installed: "Radica Gamester"
echo Drivers installed: "Logic3 Freebird wireless Controller" 
echo Drivers installed: "Eclipse wireless Controller"
echo Drivers installed: "Edge wireless Controller"
echo Drivers installed: "After Glow Pro Controller"
echo Drivers installed: "Philips Recoil"
echo Drivers installed: "Joytech Advanced Controller"
echo Drivers installed: "BigBen XBMiniPad Controller" 
echo.
echo 	Installation Percent: 90%
echo	[==============================================----]
echo.
echo Installing Package: "Joytech Wireless Advanced Controller"
wdi-simple --vid 0x102C --pid 0xFF0C --type 0 --name "Joytech Wireless Advanced Controller"
echo.

cls
echo Installing WinUSB drivers for known gamepads (this might take several minutes)
echo.
echo Drivers installed: "Thrustmaster Controller"
echo Drivers installed: "Microsoft Xbox Controller v1 (US)"
echo Drivers installed: "Microsoft Xbox Controller S (Japan)"
echo Drivers installed: "Microsoft Xbox Controller S"
echo Drivers installed: "Microsoft Xbox Controller S v2"
echo Drivers installed: "Microsoft Xbox Controller v2 (US)"
echo Drivers installed: "Logitech Cordless Precision"
echo Drivers installed: "Logitech Thunderpad"
echo Drivers installed: "Mad Catz Controller (unverified)"
echo Drivers installed: "InterAct PowerPad Pro X-box pad"
echo Drivers installed: "Chic Controller"
echo Drivers installed: "Chic Controller"
echo Drivers installed: "Logic3 Xbox GamePad" 
echo Drivers installed: "Saitek Adrenalin"
echo Drivers installed: "MadCatz 4506 Wireless Controller"
echo Drivers installed: "MadCatz Control Pad"
echo Drivers installed: "MadCatz MC2 Racing Wheel and Pedals"
echo Drivers installed: "MadCatz Control Pad Pro"
echo Drivers installed: "MadCatz MicroCON"
echo Drivers installed: "MadCatz Lynx Wireless Controller"
echo Drivers installed: "MadCatz MicroCon Wireless Controller"
echo Drivers installed: "MadCatz Blaster"
echo Drivers installed: "Intec wireless"
echo Drivers installed: "Nyko Xbox Controller"
echo Drivers installed: "Zeroplus Xbox Controller"
echo Drivers installed: "Pelican Eclipse PL-2023"
echo Drivers installed: "Zeroplus Xbox Controller"
echo Drivers installed: "HAMA VibraX - "FAULTY HARDWARE""
echo Drivers installed: "Radica Gamester Controller"
echo Drivers installed: "Radica Games Jtech Controller"
echo Drivers installed: "Radica Gamester"
echo Drivers installed: "Radica Gamester"
echo Drivers installed: "Logic3 Freebird wireless Controller" 
echo Drivers installed: "Eclipse wireless Controller"
echo Drivers installed: "Edge wireless Controller"
echo Drivers installed: "After Glow Pro Controller"
echo Drivers installed: "Philips Recoil"
echo Drivers installed: "Joytech Advanced Controller"
echo Drivers installed: "BigBen XBMiniPad Controller"
echo Drivers installed: "Joytech Wireless Advanced Controller" 
echo.
echo 	Installation Percent: 97%
echo	[================================================--]
echo.
echo Installing Package: "MadCatz LumiCON"
wdi-simple --vid 0x0738 --pid 0x4522 --type 0 --name "MadCatz LumiCON"
echo.

cls
echo Installing WinUSB drivers for known gamepads (this might take several minutes)
echo.
echo Drivers installed: "Thrustmaster Controller"
echo Drivers installed: "Microsoft Xbox Controller v1 (US)"
echo Drivers installed: "Microsoft Xbox Controller S (Japan)"
echo Drivers installed: "Microsoft Xbox Controller S"
echo Drivers installed: "Microsoft Xbox Controller S v2"
echo Drivers installed: "Microsoft Xbox Controller v2 (US)"
echo Drivers installed: "Logitech Cordless Precision"
echo Drivers installed: "Logitech Thunderpad"
echo Drivers installed: "Mad Catz Controller (unverified)"
echo Drivers installed: "InterAct PowerPad Pro X-box pad"
echo Drivers installed: "Chic Controller"
echo Drivers installed: "Chic Controller"
echo Drivers installed: "Logic3 Xbox GamePad" 
echo Drivers installed: "Saitek Adrenalin"
echo Drivers installed: "MadCatz 4506 Wireless Controller"
echo Drivers installed: "MadCatz Control Pad"
echo Drivers installed: "MadCatz MC2 Racing Wheel and Pedals"
echo Drivers installed: "MadCatz Control Pad Pro"
echo Drivers installed: "MadCatz MicroCON"
echo Drivers installed: "MadCatz Lynx Wireless Controller"
echo Drivers installed: "MadCatz MicroCon Wireless Controller"
echo Drivers installed: "MadCatz Blaster"
echo Drivers installed: "Intec wireless"
echo Drivers installed: "Nyko Xbox Controller"
echo Drivers installed: "Zeroplus Xbox Controller"
echo Drivers installed: "Pelican Eclipse PL-2023"
echo Drivers installed: "Zeroplus Xbox Controller"
echo Drivers installed: "HAMA VibraX - "FAULTY HARDWARE""
echo Drivers installed: "Radica Gamester Controller"
echo Drivers installed: "Radica Games Jtech Controller"
echo Drivers installed: "Radica Gamester"
echo Drivers installed: "Radica Gamester"
echo Drivers installed: "Logic3 Freebird wireless Controller" 
echo Drivers installed: "Eclipse wireless Controller"
echo Drivers installed: "Edge wireless Controller"
echo Drivers installed: "After Glow Pro Controller"
echo Drivers installed: "Philips Recoil"
echo Drivers installed: "Joytech Advanced Controller"
echo Drivers installed: "BigBen XBMiniPad Controller"
echo Drivers installed: "Joytech Wireless Advanced Controller"
echo Drivers installed: "MadCatz LumiCON" 
echo.
echo 	Installation Percent: 99%
echo	[================================================-]
echo.
echo Installing Package: "PowerWave Xbox Controller" 
wdi-simple --vid 0xFFFF --pid 0xFFFF --type 0 --name "PowerWave Xbox Controller" 
echo.

cls
echo Installing WinUSB gamepad drivers are now successfully registered to the Windows DLL support list.
echo.
echo Drivers installed: "Thrustmaster Controller"
echo Drivers installed: "Microsoft Xbox Controller v1 (US)"
echo Drivers installed: "Microsoft Xbox Controller S (Japan)"
echo Drivers installed: "Microsoft Xbox Controller S"
echo Drivers installed: "Microsoft Xbox Controller S v2"
echo Drivers installed: "Microsoft Xbox Controller v2 (US)"
echo Drivers installed: "Logitech Cordless Precision"
echo Drivers installed: "Logitech Thunderpad"
echo Drivers installed: "Mad Catz Controller (unverified)"
echo Drivers installed: "InterAct PowerPad Pro X-box pad"
echo Drivers installed: "Chic Controller"
echo Drivers installed: "Chic Controller"
echo Drivers installed: "Logic3 Xbox GamePad" 
echo Drivers installed: "Saitek Adrenalin"
echo Drivers installed: "MadCatz 4506 Wireless Controller"
echo Drivers installed: "MadCatz Control Pad"
echo Drivers installed: "MadCatz MC2 Racing Wheel and Pedals"
echo Drivers installed: "MadCatz Control Pad Pro"
echo Drivers installed: "MadCatz MicroCON"
echo Drivers installed: "MadCatz Lynx Wireless Controller"
echo Drivers installed: "MadCatz MicroCon Wireless Controller"
echo Drivers installed: "MadCatz Blaster"
echo Drivers installed: "Intec wireless"
echo Drivers installed: "Nyko Xbox Controller"
echo Drivers installed: "Zeroplus Xbox Controller"
echo Drivers installed: "Pelican Eclipse PL-2023"
echo Drivers installed: "Zeroplus Xbox Controller"
echo Drivers installed: "HAMA VibraX - "FAULTY HARDWARE""
echo Drivers installed: "Radica Gamester Controller"
echo Drivers installed: "Radica Games Jtech Controller"
echo Drivers installed: "Radica Gamester"
echo Drivers installed: "Radica Gamester"
echo Drivers installed: "Logic3 Freebird wireless Controller" 
echo Drivers installed: "Eclipse wireless Controller"
echo Drivers installed: "Edge wireless Controller"
echo Drivers installed: "After Glow Pro Controller"
echo Drivers installed: "Philips Recoil"
echo Drivers installed: "Joytech Advanced Controller"
echo Drivers installed: "BigBen XBMiniPad Controller"
echo Drivers installed: "Joytech Wireless Advanced Controller"
echo Drivers installed: "MadCatz LumiCON"
echo Drivers installed: "PowerWave Xbox Controller" 
echo.
echo 	Installation Percent: 100%
echo	[==================================================]
echo.
echo Finsihing up...
timeout /T 4 /NOBREAK > nul
 
:exit

