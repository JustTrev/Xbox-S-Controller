using System.Diagnostics;
using Microsoft.Win32;
using System.Threading;
using SharpDX.XInput;
using System.Runtime.InteropServices;
using PInvoke;
using Microsoft.VisualStudio.OLE.Interop;
using System.Windows.Forms;
using System.Drawing;
using System.Reflection;
using IWshRuntimeLibrary;
using File = System.IO.File;
using Mono.Cecil;

namespace XboxOGKit
{

    public partial class Form1 : Form
    {
        [DllImport("User32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern Boolean EnumDisplaySettings(
    [param: MarshalAs(UnmanagedType.LPTStr)]
    string lpszDeviceName,
    [param: MarshalAs(UnmanagedType.U4)]
    int iModeNum,
    [In, Out]
    ref DEVMODE lpDevMode);

        [StructLayout(LayoutKind.Sequential,
    CharSet = CharSet.Ansi)]
        public struct DEVMODE
        {
            // You can define the following constant
            // but OUTSIDE the structure because you know
            // that size and layout of the structure
            // is very important
            // CCHDEVICENAME = 32 = 0x50
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
            public string dmDeviceName;
            // In addition you can define the last character array
            // as following:
            //[MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
            //public Char[] dmDeviceName;

            // After the 32-bytes array
            [MarshalAs(UnmanagedType.U2)]
            public UInt16 dmSpecVersion;

            [MarshalAs(UnmanagedType.U2)]
            public UInt16 dmDriverVersion;

            [MarshalAs(UnmanagedType.U2)]
            public UInt16 dmSize;

            [MarshalAs(UnmanagedType.U2)]
            public UInt16 dmDriverExtra;

            [MarshalAs(UnmanagedType.U4)]
            public UInt32 dmFields;

            public POINTL dmPosition;

            [MarshalAs(UnmanagedType.U4)]
            public UInt32 dmDisplayOrientation;

            [MarshalAs(UnmanagedType.U4)]
            public UInt32 dmDisplayFixedOutput;

            [MarshalAs(UnmanagedType.I2)]
            public Int16 dmColor;

            [MarshalAs(UnmanagedType.I2)]
            public Int16 dmDuplex;

            [MarshalAs(UnmanagedType.I2)]
            public Int16 dmYResolution;

            [MarshalAs(UnmanagedType.I2)]
            public Int16 dmTTOption;

            [MarshalAs(UnmanagedType.I2)]
            public Int16 dmCollate;

            // CCHDEVICENAME = 32 = 0x50
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
            public string dmFormName;
            // Also can be defined as
            //[MarshalAs(UnmanagedType.ByValArray,
            //    SizeConst = 32, ArraySubType = UnmanagedType.U1)]
            //public Byte[] dmFormName;

            [MarshalAs(UnmanagedType.U2)]
            public UInt16 dmLogPixels;

            [MarshalAs(UnmanagedType.U4)]
            public UInt32 dmBitsPerPel;

            [MarshalAs(UnmanagedType.U4)]
            public UInt32 dmPelsWidth;

            [MarshalAs(UnmanagedType.U4)]
            public UInt32 dmPelsHeight;

            [MarshalAs(UnmanagedType.U4)]
            public UInt32 dmDisplayFlags;

            [MarshalAs(UnmanagedType.U4)]
            public UInt32 dmDisplayFrequency;

            [MarshalAs(UnmanagedType.U4)]
            public UInt32 dmICMMethod;

            [MarshalAs(UnmanagedType.U4)]
            public UInt32 dmICMIntent;

            [MarshalAs(UnmanagedType.U4)]
            public UInt32 dmMediaType;

            [MarshalAs(UnmanagedType.U4)]
            public UInt32 dmDitherType;

            [MarshalAs(UnmanagedType.U4)]
            public UInt32 dmReserved1;

            [MarshalAs(UnmanagedType.U4)]
            public UInt32 dmReserved2;

            [MarshalAs(UnmanagedType.U4)]
            public UInt32 dmPanningWidth;

            [MarshalAs(UnmanagedType.U4)]
            public UInt32 dmPanningHeight;
        }




        private string appInstallPath = (string)Registry.GetValue(@"HKEY_CURRENT_USER\Software\XboxOGKit", "InstallPath", null); 

        private string SavedCheckBoxItems;
        private int FavoriteView;
        private bool updateGuideMap = false;
        private bool remapButtons = false;

        string enableGuide = "false";
        string enableVibrator = "false";
        string enableControlMapping = "false";

        private string RegistryApplicationPath;

        // The notify icon
        private NotifyIcon notifyIcon1;

        // Create and check button press events //
        public bool isASelected = false;
        public bool isBSelected = false;
        public bool isXSelected = false;
        public bool isYSelected = false;
        public bool isBackSelected = false;
        public bool isStartSelected = false;
        public bool isBlackSelected = false;
        public bool isWhiteSelected = false;
        public bool isRSSelected = false;
        public bool isLSSelected = false;
        public bool isRTSelected = false;
        public bool isLTSelected = false;

        // Set limit to buttons to swap or combine with. For now lets allow swaps, then combine with a checkbox option to combine with. //
        public int totaltoSwap = 0;


        public bool isButtonchosen = false; //What button is it? 
        public string psButtonIs = ""; // Call it here !

        // Identify our buttons to use for mapping //
        public string psA = "A";
        public string psB = "B";
        public string psX = "X";
        public string psY = "Y";
        public string psBlack = "Black";
        public string psWhite = "White";
        public string psStart = "Start";
        public string psBack = "Back";
        public string psLT = "LT";
        public string psRT = "RT";
        public string psLS = "LS";
        public string psRS = "RS";
        public string psDpadUp = "DpadUp";
        public string psDpadDown = "DpadDown";
        public string psleft = "left";
        public string psRight = "Right";

        // Show Xinput feedback support //
        private string sButtonPressedResult;



        int refreshRate = 0;
        int framesPerSecond = 0;
        int milliseconds = 0;


        // Get the left trigger position
        int leftTrigger = 0;

        // Get the right trigger position
        int rightTrigger = 0;


        public int LJoystickX;
        public int LJoystickY;
        public int RJoystickX;
        public int RJoystickY;



        public string sController1Status = "No controller connected.";
        public string sController2Status = "No controller connected.";
        public string sController3Status = "No controller connected.";
        public string sController4Status = "No controller connected.";
        public bool bIsCont1Conn = false;// string sControllerStatus = "No controller connected.";
        public bool bIsCont2Conn = false;// string sControllerStatus = "No controller connected.";
        public bool bIsCont3Conn = false;// string sControllerStatus = "No controller connected.";
        public bool bIsCont4Conn = false;// string sControllerStatus = "No controller connected.";

        int panelCenterX = 0;//
        int panelCenterY = 0;//;

        // Calculate the cross position based on the thumbstick positions
        int crossX = 0;//(int)(panelCenterX + (leftThumbstickXScaled * panelCenterX));
        int crossY = 0;//(int)(panelCenterY - (leftThumbstickYScaled * panelCenterY));

        public int itxtLStickDeadZ = 0;
        public int itxtRStickDeadZ = 0;
        public byte pbLeftTrigger = 0;
        public byte pbRightTrigger = 0;

        //public object nakedRT = GamepadButtonFlags.A;
        //public object nakedLT = GamepadButtonFlags.A;




        public Form1()
        {
            InitializeComponent();
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }


        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }


        private void btnSaveCurrentLayout_Click(object sender, EventArgs e)
        {
             
            // Get the checked options
            string checkedOptions = GetCheckedOptions();
            // Display the checked options

            checkedOptions = checkedOptions.Replace("  ", " + ");
            checkedOptions = checkedOptions.Trim();

            SavedCheckBoxItems = checkedOptions;

            // write the new INI file here //

            try
            {
                // Create a string array with the lines of text
                string[] lines = { "# Xb2XInput settings file",
                    "#   Reload Xb2XInput for changes to take effect, note that INI filename should match the EXE filename of Xb2XInput!", 
                    "#   (also make sure Xb2XInput is closed before making any changes, as it may overwrite anything at any time)", 
                    "#   You can set this file as read-only if you want to prevent any of your settings from being changed.",
                    "",
                    "[Combinations]",
                    "# Button combinations for all XB2X-handled controllers", 
                    "#   Can be made up of any combination of A/B/X/Y/Start/Back/Up/Down/Left/Right/LB/RB/White/Black/LS/RS/LT/RT",
                    "#   (Seperate the buttons with a space or + character)",
                    "#   Leave a combination empty to disable it.",
                    "",
                    "# GuideButton (default LT + RT + LS + RS)", 
                    "#   Combination to emulate an X360 guide button press",
                    $"GuideButton={SavedCheckBoxItems}",
                    "",
                    "[Default]",
                    "# Default settings for newly added controllers",
                    "#   These settings will be applied to any new controllers which aren't already configured in this INI.",
                    "",
                    "# EnableVibration (default true)",
                    "#   Whether or not to enable vibration/rumble support",
                    $"EnableVibration={enableVibrator}",
                    "",
                    "# EnableGuide (default true)",
                    "#   Whether or not to allow guide button emulation via GuideButton combination above",
                    $"EnableGuide={enableGuide}",
                    "",
                    "# Deadzone*Stick (default 0)",
                    "#   Amount of deadzone to apply to each stick",
                    "#   Range: 0 - 32767",
                    $"DeadzoneLeftStick={txtLStickDeadZ.Text}",
                    $"DeadzoneRightStick={txtRStickDeadZ.Text}",
                    "",
                    "# Deadzone*Trigger (default 0)",
                    "#   Amount of deadzone to apply to each trigger",
                    "#   Range: 0 - 255",
                    $"DeadzoneLeftTrigger={txtDeadZLTrig.Text}",
                    $"DeadzoneRightTrigger={txtDeadZRTrig.Text}",
                    "",
                    "# RemapEnable (default false)",
                    "#   Whether or not the button remappings below are enabled",
                    $"RemapEnable = {enableControlMapping}",
                    "",
                    "# Remap*",
                    "#   Combinations to remap each button to.",
                    "#   Can be mapped as a single button or a combination (see Combinations section above)",
                    "#   Only buttons/clicks & triggers can be remapped atm, won't work with thumbsticks pos.",
                    $"RemapA = {psA}",
                    $"RemapB = {psB}",
                    $"RemapX = {psX}",
                    $"RemapY = {psY}",
                    $"RemapStart = {psStart}",
                    $"RemapBack = {psBack}",
                    $"RemapLS = {psLS}",
                    $"RemapRS = {psRS}",
                    $"RemapWhite = {psWhite}",
                    $"RemapBlack = {psBlack}",
                    $"RemapLT = {psLT}",
                    $"RemapRT = {psRT}",
                    $"RemapDpadUp = {psDpadUp}",
                    $"RemapDpadDown = {psDpadDown}",
                    "# 'Dpad' part of combination can be skipped if desired:",
                    $"RemapDpadLeft = {psleft}t",
                    $"RemapDpadRight = {psRight}",                
                     "",
                     "[1234567890]",
                     "# This section configures a specific controller that has the serial # 1234567890",
                    $"EnableGuide={enableGuide}",
                     "",
                     "[0738:4526]",
                     "# This section configures controllers that use the VID/PID of 0738:4526 (as not all controllers may have unique serial numbers)",
                     $"EnableGuide={enableGuide}",
                     ""
                };
                 
                // Set a variable to the Documents path.
                 string iniPath = appInstallPath + @"\Xb2XInput1_5c\"; 

                using (StreamWriter outputFile = new StreamWriter(Path.Combine(iniPath, "Xb2XInput.ini")))
                {
                    foreach (string line in lines)
                        outputFile.WriteLine(line);
                }

                if (cbxEnableGuide.Checked == true)
                {
                    enableGuide = "true";
                }
                else
                {
                    enableGuide = "false";
                }


                // Trigger and joystick deadzone //
                Properties.Settings.Default.LeftTrigDZone = txtDeadZLTrig.Text;
                Properties.Settings.Default.RightTrigDZone = txtDeadZRTrig.Text;
                Properties.Settings.Default.LStickDZone = txtLStickDeadZ.Text;
                Properties.Settings.Default.RStickDZone = txtRStickDeadZ.Text;

                // Standard pack enabled? //
                Properties.Settings.Default.EnableGuideSys = cbxEnableGuide.Checked;
                Properties.Settings.Default.EnableVibrator = cbxEnableVib.Checked;

                // Is remaping enabled? //
                Properties.Settings.Default.RemapControls = cbxRemapController.Checked;

                // Show favorite buttons //
                Properties.Settings.Default.ShowControl = FavoriteView;

                // Guide Control //
                Properties.Settings.Default.cbRTigEnable = cbRTrigger.Checked;// Properties.Settings.Default.cbRTigEnable;
                Properties.Settings.Default.cbLTrigEn = cbLTrigger.Checked;// Properties.Settings.Default.cbLTrigEn;
                Properties.Settings.Default.cbLSe = cbLStick.Checked;// Properties.Settings.Default.cbLSe;
                Properties.Settings.Default.cbLSClicke = cbLSClick.Checked;// Properties.Settings.Default.cbLSClicke;
                Properties.Settings.Default.cbBacke = cbBack.Checked;// Properties.Settings.Default.cbBacke;
                Properties.Settings.Default.cbStarte = cbStart.Checked;// Properties.Settings.Default.cbStarte;
                Properties.Settings.Default.cbYe = cbY.Checked;// Properties.Settings.Default.cbYe;
                Properties.Settings.Default.cbXe = cbX.Checked;// Properties.Settings.Default.cbXe;
                Properties.Settings.Default.cbBe = cbB.Checked;// Properties.Settings.Default.cbBe;
                Properties.Settings.Default.cbAe = cbA.Checked;// Properties.Settings.Default.cbAe;
                Properties.Settings.Default.cbBlacke = cbRBumper.Checked;// Properties.Settings.Default.cbBlacke;
                Properties.Settings.Default.cbWhitee = cbLBumper.Checked;// Properties.Settings.Default.cbWhitee;
                Properties.Settings.Default.cbRSe = chRStick.Checked;// Properties.Settings.Default.cbRSe;
                Properties.Settings.Default.cbRSClicke = cbRSClick.Checked;// Properties.Settings.Default.cbRSClicke;

                // OBSLT //   // Remapped Controls //
                // OBSLT //   Properties.Settings.Default.inputYequals = "Y";
                // OBSLT //   Properties.Settings.Default.inputXequals = "X";
                // OBSLT //   Properties.Settings.Default.inputBequals = "B";
                // OBSLT //   Properties.Settings.Default.inputAequals = "A";
                // OBSLT //   Properties.Settings.Default.inputWhiteE = "White";
                // OBSLT //   Properties.Settings.Default.inputBlackE = "Black";
                // OBSLT //   Properties.Settings.Default.inputLTequals = "LT";
                // OBSLT //   Properties.Settings.Default.inputRTequals = "RT";
                // OBSLT //   Properties.Settings.Default.inputStartequals = "Start";
                // OBSLT //   Properties.Settings.Default.inputBackE = "Back";
                // OBSLT //   Properties.Settings.Default.inputLStE = "LS";
                // OBSLT //   Properties.Settings.Default.inputRStE = "RS";


                // Remapped Controls //
                Properties.Settings.Default.inputYequals = psY;
                Properties.Settings.Default.inputXequals = psX;
                Properties.Settings.Default.inputBequals = psB;
                Properties.Settings.Default.inputAequals = psA;
                Properties.Settings.Default.inputWhiteE = psWhite;
                Properties.Settings.Default.inputBlackE = psBlack;
                Properties.Settings.Default.inputLTequals = psLT;
                Properties.Settings.Default.inputRTequals = psRT;
                Properties.Settings.Default.inputStartequals = psStart;
                Properties.Settings.Default.inputBackE = psBack;
                Properties.Settings.Default.inputLStE = psLS;
                Properties.Settings.Default.inputRStE = psRS;

                // Check our settings //
                Properties.Settings.Default.RunXb2AtStartUp = runAtStartupToolStripMenuItem.Checked;
                Properties.Settings.Default.TstBtnFdback = cbxTestBtnFdBk.Checked;

      

                // Save //
                Properties.Settings.Default.Save(); 

                // Allow to relaunch and exit. //
                btnApplyConfig.Enabled = true;
                btnApplyConfig.Visible = true;

                btnSaveCurrentLayout.Visible = false;
                //Process.Start(iniPath);
            } catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                GC.Collect();
            }

        }

        private void btnEditGuide_Click(object sender, EventArgs e)
        {
            updateGuideMap = true;
            fileToolStripMenuItem.Visible = false;
            resetToDefaultToolStripMenuItem.Visible = false;

            txtDeadZLTrig.Visible = false;
            txtDeadZRTrig.Visible = false;
            txtLStickDeadZ.Visible = false;
            txtRStickDeadZ.Visible = false;
            tbRTDeadZone.Visible = false;
            tbLTDeadZone.Visible = false;
            tbLSDz.Visible = false;
            tbRSDz.Visible = false;
            label1.Visible = false;
            label2.Visible = false;
            label3.Visible = false;
            label4.Visible = false;
            label5.Visible = false;

            cbxTestBtnFdBk.Visible= false;

            cbxRemapController.Visible = false;
            cbxEnableVib.Visible = false;
            cbxEnableGuide.Enabled = false;
            btnApplyConfig.Visible = false;

            btnClose.Enabled = false;
            btnClose.Visible = false;
            btnSaveCurrentLayout.Visible = false;
            btnRestorePrevLayout.Visible = false;
            btnSaveGuideLayout.Enabled = true;
            btnSaveGuideLayout.Visible = true;
            btnEditGuide.Visible = false;

            cbRTrigger.Enabled = true;
            cbLTrigger.Enabled = true;
            cbLStick.Enabled = false;
            cbLStick.Visible = false;
            cbLSClick.Enabled = true;
            cbBack.Enabled = true;
            cbStart.Enabled = true;
            cbY.Enabled = true;
            cbX.Enabled = true;
            cbB.Enabled = true;
            cbA.Enabled = true;
            cbRBumper.Enabled= true;
            cbLBumper.Enabled= true;
            chRStick.Enabled=false;
            chRStick.Visible=false;
            cbRSClick.Enabled=true;

            // Check our boxes for instructions //
            if (cbLTrigger.Checked == false)
            {
                cbLTrigger.Visible = true;
            }
             
            if (cbLStick.Checked == false)
            {
                cbLStick.Visible = true;
            }

            if (cbLSClick.Checked == false)
            {
                cbLSClick.Visible = true;
            }

            if (cbBack.Checked == false)
            {
                cbBack.Visible = true;
            }

            if (cbStart.Checked == false)
            {
                cbStart.Visible = true;
            }

            if (cbRTrigger.Checked == false)
            {
                cbRTrigger.Visible = true;
            }

            if (cbY.Checked == false)
            {
                cbY.Visible = true;
            }

            if (cbX.Checked == false)
            {
                cbX.Visible = true;
            }

            if (cbB.Checked == false)
            {
                cbB.Visible = true;
            }

            if (cbA.Checked == false)
            {
                cbA.Visible = true;
            }

            if (cbRBumper.Checked == false)
            {
                cbRBumper.Visible = true;
            }

            if (cbLBumper.Checked == false)
            {
                cbLBumper.Visible = true;
            }

            if (chRStick.Checked == false)
            {
                chRStick.Visible = true;
            }

            if (cbRSClick.Checked == false)
            {
                cbRSClick.Visible = true;
            }

            rbShowOG.Visible = false;
            rbx360.Visible = false;
            rbXOne.Visible = false;
        }

        private void btnSaveGuideLayout_Click(object sender, EventArgs e)
        {
            updateGuideMap = false;
            fileToolStripMenuItem.Visible = true;
            resetToDefaultToolStripMenuItem.Visible = true;

            btnEditGuide.Visible = true;

            txtDeadZLTrig.Visible = true;
            txtDeadZRTrig.Visible = true;
            txtLStickDeadZ.Visible = true;
            txtRStickDeadZ.Visible = true;
            tbRTDeadZone.Visible = true;
            tbLTDeadZone.Visible = true;
            tbLSDz.Visible = true;
            tbRSDz.Visible = true;
            label1.Visible = true;
            label2.Visible = true;
            label3.Visible = true;
            label4.Visible = true;
            label5.Visible = true;
            cbxTestBtnFdBk.Visible = true;



            rbShowOG.Visible = true;
            rbx360.Visible = true;
            rbXOne.Visible = true;


            cbxRemapController.Visible = true;
            cbxEnableVib.Visible = true;
            cbxEnableGuide.Enabled = true;

            btnSaveCurrentLayout.Visible = true;
            btnRestorePrevLayout.Visible = true; 

            btnClose.Enabled = true;
            btnClose.Visible = true;

            btnSaveGuideLayout.Enabled = false;
            btnSaveGuideLayout.Visible = false;


            cbRTrigger.Enabled = false;
            cbLTrigger.Enabled = false;
            cbLStick.Enabled = false;
            cbLStick.Visible = true;
            cbLSClick.Enabled = false;
            cbBack.Enabled = false;
            cbStart.Enabled = false;
            cbY.Enabled = false;
            cbX.Enabled = false;
            cbB.Enabled = false;
            cbA.Enabled = false;
            cbRBumper.Enabled = false;
            cbLBumper.Enabled = false;
            chRStick.Enabled = false;
            chRStick.Visible = true;
            cbRSClick.Enabled = false;

            if (cbLTrigger.Checked == false)
            {
                cbLTrigger.Visible = false;
            }

            if (cbLStick.Checked == false)
            {
                cbLStick.Visible = false;
            }

            if (cbLSClick.Checked == false)
            {
                cbLSClick.Visible = false;
            }

            if (cbBack.Checked == false)
            {
                cbBack.Visible = false;
            }

            if (cbStart.Checked == false)
            {
                cbStart.Visible = false;
            }

            if (cbRTrigger.Checked == false)
            {
                cbRTrigger.Visible = false;
            }

            if (cbY.Checked == false)
            {
                cbY.Visible = false;
            }

            if (cbX.Checked == false)
            {
                cbX.Visible = false;
            }

            if (cbB.Checked == false)
            {
                cbB.Visible = false;
            }

            if (cbA.Checked == false)
            {
                cbA.Visible = false;
            }

            if (cbRBumper.Checked == false)
            {
                cbRBumper.Visible = false;
            }

            if (cbLBumper.Checked == false)
            {
                cbLBumper.Visible = false;
            }

            if (chRStick.Checked == false)
            {
                chRStick.Visible = false;
            }

            if (cbRSClick.Checked == false)
            {
                cbRSClick.Visible = false;
            }
             
             
        }

        // The GetCheckedOptions method gets a string representing the checked options
        private string GetCheckedOptions()
        {
            // Initialize the result string
            string result = "";

            // Add the checked options to the result string
            if (cbRTrigger.Checked) result += " RT ";
            if (cbLTrigger.Checked) result += " LT ";
            // if (cbLStick.Checked) result += "UNKNOWN";
            if (cbLSClick.Checked) result += " LS ";
            if (cbBack.Checked) result += " Back ";
            if (cbStart.Checked) result += " Start ";
            if (cbY.Checked) result += " Y ";
            if (cbX.Checked) result += " X ";
            if (cbB.Checked) result += " B ";
            if (cbA.Checked) result += " A ";
            if (cbRBumper.Checked) result += " Black ";
            if (cbLBumper.Checked) result += " White ";
            // if (chRStick.Checked) result += "UNKNOWN";
            if (cbRSClick.Checked) result += " RS ";             

            // Return the result
            return result;
        }
        private void CheckOG()
        {
            rbShowOG.Checked = true;
            if (rbShowOG.Checked == true)
            {
                btnBack.Visible = true;
                btnStart.Visible = true;
                btnX360Start.Visible = false;
                btnX360Back.Visible = false;
                btnXONEStart.Visible = false;
                btnXONEBack.Visible = false;
                btnRightBumper.Visible = false;
                btnLeftBumper.Visible = false;
                btnBlack.Visible = true;
                btnWhite.Visible = true;
            }

        }
        private void Checkx360()
        {
            rbx360.Checked = true;
            if (rbx360.Checked == true)
            {
                btnBack.Visible = false;
                btnStart.Visible = false;
                btnX360Start.Visible = true;
                btnX360Back.Visible = true;
                btnXONEStart.Visible = false;
                btnXONEBack.Visible = false;
                btnRightBumper.Visible = true;
                btnLeftBumper.Visible = true;
                btnBlack.Visible = false;
                btnWhite.Visible = false;
            }
        }
        private void CheckXOne()
        {
            rbXOne.Checked = true;
            if (rbXOne.Checked == true)
            {
                btnBack.Visible = false;
                btnStart.Visible = false;
                btnX360Start.Visible = false;
                btnX360Back.Visible = false;
                btnXONEStart.Visible = true;
                btnXONEBack.Visible = true;
                btnRightBumper.Visible = true;
                btnLeftBumper.Visible = true;
                btnBlack.Visible = false;
                btnWhite.Visible = false;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // set our frame rate to our timer for reverse timing on the cpu //
            //runAtStartupToolStripMenuItem.Checked = true;

            // Get the current refresh rate of the primary display
            int refreshRate = 0;
            try
            {
                // refreshRate = (int)Screen.PrimaryScreen.Bounds.Height;
                System.Management.ManagementObjectSearcher searcher = new System.Management.ManagementObjectSearcher("root\\CIMV2", "SELECT * FROM Win32_VideoController WHERE Primary='True'");
                foreach (System.Management.ManagementObject queryObj in searcher.Get())
                {
                    refreshRate = (int)(uint)queryObj["CurrentRefreshRate"];
                }

            } catch
            {
                refreshRate = 60;
            }
            

            framesPerSecond = refreshRate;
            milliseconds = (int)Math.Round(1000.0 / framesPerSecond);
            label5.Text = $"Primary Display:{refreshRate}FPS at {milliseconds.ToString()}ms.";

            // Enable double buffering for the panel  Sticks //
            // panel1.Parent= this;
            // this.Controls.Add(panel1);  
            //panel1.DoubleBuffered = true;

            timer1.Interval = milliseconds;
            timer1.Stop();
            timer1.Enabled = false;
            // Load our defaults if no save config was found //
            FavoriteView = Properties.Settings.Default.ShowControl;
            if (FavoriteView == 0 )
            {
                CheckOG(); 
            } 
            
            if (FavoriteView == 1)
            {
                Checkx360();
            }

            if (FavoriteView == 2)
            {
                CheckXOne();
            }


            // Load our saved settings if not by default //
            cbxEnableGuide.Checked = Properties.Settings.Default.EnableGuideSys;
            cbxEnableVib.Checked = Properties.Settings.Default.EnableVibrator;
            cbxRemapController.Checked = Properties.Settings.Default.RemapControls;

            cbRTrigger.Checked = Properties.Settings.Default.cbRTigEnable;
            cbLTrigger.Checked = Properties.Settings.Default.cbLTrigEn;
            cbLStick.Checked = Properties.Settings.Default.cbLSe;
            cbLSClick.Checked = Properties.Settings.Default.cbLSClicke;
            cbBack.Checked = Properties.Settings.Default.cbBacke;
            cbStart.Checked = Properties.Settings.Default.cbStarte;
            cbY.Checked = Properties.Settings.Default.cbYe;
            cbX.Checked = Properties.Settings.Default.cbXe;
            cbB.Checked = Properties.Settings.Default.cbBe;
            cbA.Checked = Properties.Settings.Default.cbAe;
            cbRBumper.Checked = Properties.Settings.Default.cbBlacke;
            cbLBumper.Checked = Properties.Settings.Default.cbWhitee;
            chRStick.Checked = Properties.Settings.Default.cbRSe;
            cbRSClick.Checked = Properties.Settings.Default.cbRSClicke;
             
            tbLTDeadZone.Value = int.Parse(Properties.Settings.Default.LeftTrigDZone);
            tbRTDeadZone.Value = int.Parse(Properties.Settings.Default.RightTrigDZone);
            tbLSDz.Value = int.Parse(Properties.Settings.Default.LStickDZone);
            tbRSDz.Value = int.Parse(Properties.Settings.Default.RStickDZone);

            // Remapped Controls //
            psY= Properties.Settings.Default.inputYequals ;//  psY;
            psX = Properties.Settings.Default.inputXequals ;//  psX;
            psB = Properties.Settings.Default.inputBequals ;//  psB;
            psA = Properties.Settings.Default.inputAequals ;//  psA;
            psWhite = Properties.Settings.Default.inputWhiteE ;//  psWhite;
            psBlack = Properties.Settings.Default.inputBlackE ;//  psBlack;
            psLT = Properties.Settings.Default.inputLTequals ;//  psLT;
            psRT = Properties.Settings.Default.inputRTequals ;//  psRT;
            psStart = Properties.Settings.Default.inputStartequals ;//  psStart;
            psBack = Properties.Settings.Default.inputBackE ;//  psBack;
            psLS = Properties.Settings.Default.inputLStE ;//  psLS;
            psRS = Properties.Settings.Default.inputRStE ;//  psRS;             

            // Check our settings //
            runAtStartupToolStripMenuItem.Checked = Properties.Settings.Default.RunXb2AtStartUp;
            cbxTestBtnFdBk.Checked = Properties.Settings.Default.TstBtnFdback;

            // Set window elements. //
            cbRTrigger.Enabled = false;// Properties.Settings.Default.cbRTigEnable;
            cbLTrigger.Enabled = false;// Properties.Settings.Default.cbLTrigEn;
            cbLStick.Enabled = false;// Properties.Settings.Default.cbLSe;
            cbLSClick.Enabled = false;// Properties.Settings.Default.cbLSClicke;
            cbBack.Enabled = false;// Properties.Settings.Default.cbBacke;
            cbStart.Enabled = false;// Properties.Settings.Default.cbStarte;
            cbY.Enabled = false;// Properties.Settings.Default.cbYe;
            cbX.Enabled = false;// Properties.Settings.Default.cbXe;
            cbB.Enabled = false;// Properties.Settings.Default.cbBe;
            cbA.Enabled = false;// Properties.Settings.Default.cbAe;
            cbRBumper.Enabled = false;// Properties.Settings.Default.cbBlacke;
            cbLBumper.Enabled = false;// Properties.Settings.Default.cbWhitee;
            chRStick.Enabled = false;// Properties.Settings.Default.cbRSe;
            cbRSClick.Enabled = false;// Properties.Settings.Default.cbRSClicke;


            if (cbLTrigger.Checked == false)
            {
                cbLTrigger.Visible = false;
            }

            if (cbLStick.Checked == false)
            {
                cbLStick.Visible = false;
            }

            if (cbLSClick.Checked == false)
            {
                cbLSClick.Visible = false;
            }

            if (cbBack.Checked == false)
            {
                cbBack.Visible = false;
            }

            if (cbStart.Checked == false)
            {
                cbStart.Visible = false;
            }

            if (cbRTrigger.Checked == false)
            {
                cbRTrigger.Visible = false;
            }

            if (cbY.Checked == false)
            {
                cbY.Visible = false;
            }

            if (cbX.Checked == false)
            {
                cbX.Visible = false;
            }

            if (cbB.Checked == false)
            {
                cbB.Visible = false;
            }

            if (cbA.Checked == false)
            {
                cbA.Visible = false;
            }

            if (cbRBumper.Checked == false)
            {
                cbRBumper.Visible = false;
            }

            if (cbLBumper.Checked == false)
            {
                cbLBumper.Visible = false;
            }

            if (chRStick.Checked == false)
            {
                chRStick.Visible = false;
            }

            if (cbRSClick.Checked == false)
            {
                cbRSClick.Visible = false;
            }
            btnSaveCurrentLayout.Visible = false;
        }

        // Highlight our options //
        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            if (cbxRemapController.Checked == true)
            {
                enableControlMapping = "true";
                remapButtons = true;

                // Highlight all available buttons for mapping //
                btnGPB.BackColor = Color.Transparent;
                btnGPA.BackColor = Color.Transparent;
                btnGPX.BackColor = Color.Transparent;
                btnGPY.BackColor = Color.Transparent;
                btnA.BackColor = Color.Yellow;
                btnB.BackColor = Color.Yellow;
                btnX.BackColor = Color.Yellow;
                btnY.BackColor = Color.Yellow;
                btnLTrigger.BackColor = Color.Yellow;
                btnRTrigger.BackColor = Color.Yellow;
                btnBack.BackColor = Color.Yellow;
                btnX360Back.BackColor = Color.Yellow;
                btnXONEBack.BackColor = Color.Yellow;
                btnStart.BackColor = Color.Yellow;
                btnX360Start.BackColor = Color.Yellow;
                btnXONEStart.BackColor = Color.Yellow;
                btnLSClick.BackColor = Color.Yellow;
                btnRSClick.BackColor = Color.Yellow;
                btnBlack.BackColor = Color.Yellow;
                btnWhite.BackColor = Color.Yellow;
                btnRightBumper.BackColor = Color.Yellow;
                btnLeftBumper.BackColor = Color.Yellow;


                btnGPY.Visible= true;
                btnGPX.Visible= true;
                btnGPB.Visible= true;
                btnGPA.Visible= true;



                btnGPB.BackgroundImage = Properties.Resources.Button_B;
                btnGPA.BackgroundImage = Properties.Resources.Button_A;
                btnGPX.BackgroundImage = Properties.Resources.Button_X;
                btnGPY.BackgroundImage = Properties.Resources.Button_Y;

            }
            else
            {
                enableControlMapping = "false";
                remapButtons = false;

                // Highlight all available buttons for mapping //
                btnGPB.BackColor = Color.Transparent;
                btnGPA.BackColor = Color.Transparent;
                btnGPX.BackColor = Color.Transparent;
                btnGPY.BackColor = Color.Transparent;
                btnA.BackColor = Color.Transparent;
                btnB.BackColor = Color.Transparent;
                btnX.BackColor = Color.Transparent;
                btnY.BackColor = Color.Transparent;
                btnLTrigger.BackColor = Color.Transparent;
                btnRTrigger.BackColor = Color.Transparent;
                btnBack.BackColor = Color.Transparent;
                btnX360Back.BackColor = Color.Transparent;
                btnXONEBack.BackColor = Color.Transparent;
                btnStart.BackColor = Color.Transparent;
                btnX360Start.BackColor = Color.Transparent;
                btnXONEStart.BackColor = Color.Transparent;
                btnLSClick.BackColor = Color.Transparent;
                btnRSClick.BackColor = Color.Transparent;
                btnBlack.BackColor = Color.Transparent;
                btnWhite.BackColor = Color.Transparent;
                btnRightBumper.BackColor = Color.Transparent;
                btnLeftBumper.BackColor = Color.Transparent;



                // btnGPY.Visible = false;
                // btnGPX.Visible = false;
                // btnGPB.Visible = false;
                // btnGPA.Visible = false;


                btnGPB.BackgroundImage = null;
                btnGPA.BackgroundImage = null;
                btnGPX.BackgroundImage = null;
                btnGPY.BackgroundImage = null;

            }
        }

        private void tbRTDeadZone_ValueChanged(object sender, EventArgs e)
        {
            txtDeadZRTrig.Text = tbRTDeadZone.Value.ToString(); 
        }

        private void tbLTDeadZone_ValueChanged(object sender, EventArgs e)
        {
            txtDeadZLTrig.Text = tbLTDeadZone.Value.ToString();
        }

        private void tbRSDz_ValueChanged(object sender, EventArgs e)
        {
            txtRStickDeadZ.Text = tbRSDz.Value.ToString();

        }

        private void tbLSDz_ValueChanged(object sender, EventArgs e)
        {
            txtLStickDeadZ.Text = tbLSDz.Value.ToString();
        }

        private void btnApplyConfig_Click(object sender, EventArgs e)
        {
            btnApplyConfig.Enabled = false;
            btnApplyConfig.Visible = false;

            // Relaunch Xb2Input if running other 
            try
            {

                Process[] processlist = Process.GetProcesses();
                foreach (Process theprocess in processlist)
                {
                    // Console.WriteLine("Process: {0} ID: {1}", theprocess.ProcessName, theprocess.Id);

                    if (theprocess.ProcessName.Contains("Xb2XInput"))
                    {
                        theprocess.Kill();

                    }
                     
                } 
                // Wait for 1 second

              //  ProcessStartInfo processStartInfo = new ProcessStartInfo();
              //  processStartInfo.UseShellExecute = true;
              //  processStartInfo.WorkingDirectory = appInstallPath;
              //  processStartInfo.FileName = appInstallPath + @"\Xb2XInput1_5c\Xb2XInput.exe";
              //  Process.Start(processStartInfo);

                // Create a new process
                Process process = new Process();

                // Set the process start info
                process.StartInfo.FileName = appInstallPath + @"\Xb2XInput1_5c\Xb2XInput.exe";

                process.StartInfo.Verb = "runas"; // Launch the process as an administrator

                // Start the process
                process.Start();

                 
                System.Threading.Thread.Sleep(500);


            }
            catch (Exception ex)
            {
                MessageBox.Show($"Something went wrong and threw this error instead: {ex.Message + Environment.NewLine}Please check your files be reinstalling the application and try again.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            Close();
        }

        private void cbxEnableGuide_CheckedChanged(object sender, EventArgs e)
        {
            if (cbxEnableGuide.Checked == true)
            {
                HideGuidePanel.Visible = false;

                enableGuide = "true";
                btnEditGuide.Visible = true;

                // Check our boxes for instructions //
                if (cbLTrigger.Checked == true)
                {
                    cbLTrigger.Visible = true;
                }

                if (cbLStick.Checked == true)
                {
                    cbLStick.Visible = true;
                }

                if (cbLSClick.Checked == true)
                {
                    cbLSClick.Visible = true;
                }

                if (cbBack.Checked == true)
                {
                    cbBack.Visible = true;
                }

                if (cbStart.Checked == true)
                {
                    cbStart.Visible = true;
                }

                if (cbRTrigger.Checked == true)
                {
                    cbRTrigger.Visible = true;
                }

                if (cbY.Checked == true)
                {
                    cbY.Visible = true;
                }

                if (cbX.Checked == true)
                {
                    cbX.Visible = true;
                }

                if (cbB.Checked == true)
                {
                    cbB.Visible = true;
                }

                if (cbA.Checked == true)
                {
                    cbA.Visible = true;
                }

                if (cbRBumper.Checked == true)
                {
                    cbRBumper.Visible = true;
                }

                if (cbLBumper.Checked == true)
                {
                    cbLBumper.Visible = true;
                }

                if (chRStick.Checked == true)
                {
                    chRStick.Visible = true;
                }

                if (cbRSClick.Checked == true)
                {
                    cbRSClick.Visible = true;

                }
            } else
            {
                HideGuidePanel.Visible = true;
                enableGuide = "false";
                btnEditGuide.Visible = false;

                 

                // Check our boxes for instructions //
                if (cbLTrigger.Checked == true)
                {
                    cbLTrigger.Visible = false;
                }

                if (cbLStick.Checked == true)
                {
                    cbLStick.Visible = false;
                }

                if (cbLSClick.Checked == true)
                {
                    cbLSClick.Visible = false;
                }

                if (cbBack.Checked == true)
                {
                    cbBack.Visible = false;
                }

                if (cbStart.Checked == true)
                {
                    cbStart.Visible = false;
                }

                if (cbRTrigger.Checked == true)
                {
                    cbRTrigger.Visible = false;
                }

                if (cbY.Checked == true)
                {
                    cbY.Visible = false;
                }

                if (cbX.Checked == true)
                {
                    cbX.Visible = false;
                }

                if (cbB.Checked == true)
                {
                    cbB.Visible = false;
                }

                if (cbA.Checked == true)
                {
                    cbA.Visible = false;
                }

                if (cbRBumper.Checked == true)
                {
                    cbRBumper.Visible = false;
                }

                if (cbLBumper.Checked == true)
                {
                    cbLBumper.Visible = false;
                }

                if (chRStick.Checked == true)
                {
                    chRStick.Visible = false;
                }

                if (cbRSClick.Checked == true)
                {
                    cbRSClick.Visible = false;
                }

            }
        }

        private void cbxEnableVib_CheckedChanged(object sender, EventArgs e)
        {
            if (cbxEnableVib.Checked == true)
            {
                enableVibrator = "true";

            }
            else
            {
                enableVibrator = "false";
            }

            btnSaveCurrentLayout.Visible = true;

        }

        private void rbShowOG_CheckedChanged(object sender, EventArgs e)
        {
            if (rbShowOG.Checked == true)
            {
                btnBack.Visible = true;
                btnStart.Visible = true;
                btnX360Start.Visible = false;
                btnX360Back.Visible = false;
                btnXONEStart.Visible = false;
                btnXONEBack.Visible = false;
                btnRightBumper.Visible = false;
                btnLeftBumper.Visible = false;
                btnBlack.Visible = true;
                btnWhite.Visible = true;
                FavoriteView = 0; 
            }

            btnSaveCurrentLayout.Visible = true;

        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (rbx360.Checked == true)
            {
                btnBack.Visible = false;
                btnStart.Visible = false;
                btnX360Start.Visible = true;
                btnX360Back.Visible = true;
                btnXONEStart.Visible = false;
                btnXONEBack.Visible = false;
                btnRightBumper.Visible = true;
                btnLeftBumper.Visible = true;
                btnBlack.Visible = false;
                btnWhite.Visible = false;
                FavoriteView = 1; 
            }

            btnSaveCurrentLayout.Visible = true;

        }

        private void rbXOne_CheckedChanged(object sender, EventArgs e)
        {
            if (rbXOne.Checked == true)
            {
                btnBack.Visible = false;
                btnStart.Visible = false;
                btnX360Start.Visible = false;
                btnX360Back.Visible = false;
                btnXONEStart.Visible = true;
                btnXONEBack.Visible = true;
                btnRightBumper.Visible = true;
                btnLeftBumper.Visible = true;
                btnBlack.Visible = false;
                btnWhite.Visible = false;
                FavoriteView = 2; 
            }

            btnSaveCurrentLayout.Visible = true;

        }

        private void txtDeadZRTrig_TextChanged(object sender, EventArgs e)
        { 
            // Get the value from the textbox
            int value = int.Parse(txtDeadZRTrig.Text);

            // Set the trackbar value
            tbRTDeadZone.Value = value;

            // Show the user that they are able to save everything they do to the program. So nothing breaks!!! //
            btnSaveCurrentLayout.Visible = true;

        }

        private void txtDeadZLTrig_TextChanged(object sender, EventArgs e)
        {
            // Get the value from the textbox
            int value = int.Parse(txtDeadZRTrig.Text);

            // Set the trackbar value
            tbRTDeadZone.Value = value;

            // Show the user that they are able to save everything they do to the program. So nothing breaks!!! //
            btnSaveCurrentLayout.Visible = true;
        }

        private void txtRStickDeadZ_TextChanged(object sender, EventArgs e)
        {
            // Get the value from the textbox
            int value = int.Parse(txtDeadZRTrig.Text);

            // Set the trackbar value
            tbRTDeadZone.Value = value;


            // Show the user that they are able to save everything they do to the program. So nothing breaks!!! //
            btnSaveCurrentLayout.Visible = true;
        }

        private void txtLStickDeadZ_TextChanged(object sender, EventArgs e)
        {
            // Get the value from the textbox
            int value = int.Parse(txtDeadZRTrig.Text);

            // Set the trackbar value
            tbRTDeadZone.Value = value;


            // Show the user that they are able to save everything they do to the program. So nothing breaks!!! //
            btnSaveCurrentLayout.Visible = true;
        }

        private void btnRestorePrevLayout_Click(object sender, EventArgs e)
        {
            rbShowOG.Checked = true;

            FavoriteView = 0;             

            cbxEnableGuide.Checked = true;
            cbxEnableVib.Checked = true;
            cbxRemapController.Checked = false;

            cbRTrigger.Checked = true;//  Properties.Settings.Default.cbRTigEnable;
            cbLTrigger.Checked = true;// Properties.Settings.Default.cbLTrigEn;
            cbLStick.Checked = false;// Properties.Settings.Default.cbLSe;
            cbLSClick.Checked = true;// Properties.Settings.Default.cbLSClicke;
            chRStick.Checked = false;// Properties.Settings.Default.cbRSe;
            cbRSClick.Checked = true;// Properties.Settings.Default.cbRSClicke;
            cbBack.Checked = false;// Properties.Settings.Default.cbBacke;
            cbStart.Checked = false;// Properties.Settings.Default.cbStarte;
            cbY.Checked = false;// Properties.Settings.Default.cbYe;
            cbX.Checked = false;// Properties.Settings.Default.cbXe;
            cbB.Checked = false;// Properties.Settings.Default.cbBe;
            cbA.Checked = false;// Properties.Settings.Default.cbAe;
            cbRBumper.Checked = false;// Properties.Settings.Default.cbBlacke;
            cbLBumper.Checked = false;// Properties.Settings.Default.cbWhitee;

            cbRTrigger.Visible = true;//  Properties.Settings.Default.cbRTigEnable;
            cbLTrigger.Visible = true;// Properties.Settings.Default.cbLTrigEn;
            cbLStick.Visible = true;// Properties.Settings.Default.cbLSe;
            cbLSClick.Visible = true;// Properties.Settings.Default.cbLSClicke;
            chRStick.Visible = true;// Properties.Settings.Default.cbRSe;
            cbRSClick.Visible = true;// Properties.Settings.Default.cbRSClicke;
            cbBack.Visible = true;// Properties.Settings.Default.cbBacke;
            cbStart.Visible = true;// Properties.Settings.Default.cbStarte;
            cbY.Visible = true;// Properties.Settings.Default.cbYe;
            cbX.Visible = true;// Properties.Settings.Default.cbXe;
            cbB.Visible = true;// Properties.Settings.Default.cbBe;
            cbA.Visible = true;// Properties.Settings.Default.cbAe;
            cbRBumper.Visible = true;// Properties.Settings.Default.cbBlacke;
            cbLBumper.Visible = true;// Properties.Settings.Default.cbWhitee;


            tbLTDeadZone.Value = 0;//  int.Parse(Properties.Settings.Default.LeftTrigDZone);
            tbRTDeadZone.Value = 0;// int.Parse(Properties.Settings.Default.RightTrigDZone);
            tbLSDz.Value = 0;// int.Parse(Properties.Settings.Default.LStickDZone);
            tbRSDz.Value = 0;// int.Parse(Properties.Settings.Default.RStickDZone);



            if (cbLTrigger.Checked == false)
            {
                cbLTrigger.Visible = false;
            }

            if (cbLStick.Checked == false)
            {
                cbLStick.Visible = false;
            }

            if (cbLSClick.Checked == false)
            {
                cbLSClick.Visible = false;
            }

            if (cbBack.Checked == false)
            {
                cbBack.Visible = false;
            }

            if (cbStart.Checked == false)
            {
                cbStart.Visible = false;
            }

            if (cbRTrigger.Checked == false)
            {
                cbRTrigger.Visible = false;
            }

            if (cbY.Checked == false)
            {
                cbY.Visible = false;
            }

            if (cbX.Checked == false)
            {
                cbX.Visible = false;
            }

            if (cbB.Checked == false)
            {
                cbB.Visible = false;
            }

            if (cbA.Checked == false)
            {
                cbA.Visible = false;
            }

            if (cbRBumper.Checked == false)
            {
                cbRBumper.Visible = false;
            }

            if (cbLBumper.Checked == false)
            {
                cbLBumper.Visible = false;
            }

            if (chRStick.Checked == false)
            {
                chRStick.Visible = false;
            }

            if (cbRSClick.Checked == false)
            {
                cbRSClick.Visible = false;
            }



            // Show the user that they are able to save everything they do to the program. So nothing breaks!!! //
            btnSaveCurrentLayout.Visible = true;
        }

        private void resetToDefaultToolStripMenuItem_Click(object sender, EventArgs e)
        {

            rbShowOG.Checked = true;

            FavoriteView = 0;

            cbxEnableGuide.Checked = true;
            cbxEnableVib.Checked = true;
            cbxRemapController.Checked = false;

            cbRTrigger.Checked = true;//  Properties.Settings.Default.cbRTigEnable;
            cbLTrigger.Checked = true;// Properties.Settings.Default.cbLTrigEn;
            cbLStick.Checked = false;// Properties.Settings.Default.cbLSe;
            cbLSClick.Checked = true;// Properties.Settings.Default.cbLSClicke;
            chRStick.Checked = false;// Properties.Settings.Default.cbRSe;
            cbRSClick.Checked = true;// Properties.Settings.Default.cbRSClicke;
            cbBack.Checked = false;// Properties.Settings.Default.cbBacke;
            cbStart.Checked = false;// Properties.Settings.Default.cbStarte;
            cbY.Checked = false;// Properties.Settings.Default.cbYe;
            cbX.Checked = false;// Properties.Settings.Default.cbXe;
            cbB.Checked = false;// Properties.Settings.Default.cbBe;
            cbA.Checked = false;// Properties.Settings.Default.cbAe;
            cbRBumper.Checked = false;// Properties.Settings.Default.cbBlacke;
            cbLBumper.Checked = false;// Properties.Settings.Default.cbWhitee;

            cbRTrigger.Visible = true;//  Properties.Settings.Default.cbRTigEnable;
            cbLTrigger.Visible = true;// Properties.Settings.Default.cbLTrigEn;
            cbLStick.Visible = true;// Properties.Settings.Default.cbLSe;
            cbLSClick.Visible = true;// Properties.Settings.Default.cbLSClicke;
            chRStick.Visible = true;// Properties.Settings.Default.cbRSe;
            cbRSClick.Visible = true;// Properties.Settings.Default.cbRSClicke;
            cbBack.Visible = true;// Properties.Settings.Default.cbBacke;
            cbStart.Visible = true;// Properties.Settings.Default.cbStarte;
            cbY.Visible = true;// Properties.Settings.Default.cbYe;
            cbX.Visible = true;// Properties.Settings.Default.cbXe;
            cbB.Visible = true;// Properties.Settings.Default.cbBe;
            cbA.Visible = true;// Properties.Settings.Default.cbAe;
            cbRBumper.Visible = true;// Properties.Settings.Default.cbBlacke;
            cbLBumper.Visible = true;// Properties.Settings.Default.cbWhitee;


            tbLTDeadZone.Value = 0;//  int.Parse(Properties.Settings.Default.LeftTrigDZone);
            tbRTDeadZone.Value = 0;// int.Parse(Properties.Settings.Default.RightTrigDZone);
            tbLSDz.Value = 0;// int.Parse(Properties.Settings.Default.LStickDZone);
            tbRSDz.Value = 0;// int.Parse(Properties.Settings.Default.RStickDZone);



            if (cbLTrigger.Checked == false)
            {
                cbLTrigger.Visible = false;
            }

            if (cbLStick.Checked == false)
            {
                cbLStick.Visible = false;
            }

            if (cbLSClick.Checked == false)
            {
                cbLSClick.Visible = false;
            }

            if (cbBack.Checked == false)
            {
                cbBack.Visible = false;
            }

            if (cbStart.Checked == false)
            {
                cbStart.Visible = false;
            }

            if (cbRTrigger.Checked == false)
            {
                cbRTrigger.Visible = false;
            }

            if (cbY.Checked == false)
            {
                cbY.Visible = false;
            }

            if (cbX.Checked == false)
            {
                cbX.Visible = false;
            }

            if (cbB.Checked == false)
            {
                cbB.Visible = false;
            }

            if (cbA.Checked == false)
            {
                cbA.Visible = false;
            }

            if (cbRBumper.Checked == false)
            {
                cbRBumper.Visible = false;
            }

            if (cbLBumper.Checked == false)
            {
                cbLBumper.Visible = false;
            }

            if (chRStick.Checked == false)
            {
                chRStick.Visible = false;
            }

            if (cbRSClick.Checked == false)
            {
                cbRSClick.Visible = false;
            }



            // Show the user that they are able to save everything they do to the program. So nothing breaks!!! //
            btnSaveCurrentLayout.Visible = true;
        }

        private void saveApplyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Show a dialog to save the file inards as a JSON to remember later. //


            // Get the checked options
            string checkedOptions = GetCheckedOptions();
            // Display the checked options

            checkedOptions = checkedOptions.Replace("  ", " + ");
            checkedOptions = checkedOptions.Trim();

            SavedCheckBoxItems = checkedOptions;

            // write the new INI file here //

            try
            {
                // Create a string array with the lines of text
                string[] lines = { "# Xb2XInput settings file",
                    "#   Reload Xb2XInput for changes to take effect, note that INI filename should match the EXE filename of Xb2XInput!",
                    "#   (also make sure Xb2XInput is closed before making any changes, as it may overwrite anything at any time)",
                    "#   You can set this file as read-only if you want to prevent any of your settings from being changed.",
                    "",
                    "[Combinations]",
                    "# Button combinations for all XB2X-handled controllers",
                    "#   Can be made up of any combination of A/B/X/Y/Start/Back/Up/Down/Left/Right/LB/RB/White/Black/LS/RS/LT/RT",
                    "#   (Seperate the buttons with a space or + character)",
                    "#   Leave a combination empty to disable it.",
                    "",
                    "# GuideButton (default LT + RT + LS + RS)",
                    "#   Combination to emulate an X360 guide button press",
                    $"GuideButton={SavedCheckBoxItems}",
                    "",
                    "[Default]",
                    "# Default settings for newly added controllers",
                    "#   These settings will be applied to any new controllers which aren't already configured in this INI.",
                    "",
                    "# EnableVibration (default true)",
                    "#   Whether or not to enable vibration/rumble support",
                    $"EnableVibration={enableVibrator}",
                    "",
                    "# EnableGuide (default true)",
                    "#   Whether or not to allow guide button emulation via GuideButton combination above",
                    $"EnableGuide={enableGuide}",
                    "",
                    "# Deadzone*Stick (default 0)",
                    "#   Amount of deadzone to apply to each stick",
                    "#   Range: 0 - 32767",
                    $"DeadzoneLeftStick={txtLStickDeadZ.Text}",
                    $"DeadzoneRightStick={txtRStickDeadZ.Text}",
                    "",
                    "# Deadzone*Trigger (default 0)",
                    "#   Amount of deadzone to apply to each trigger",
                    "#   Range: 0 - 255",
                    $"DeadzoneLeftTrigger={txtDeadZLTrig.Text}",
                    $"DeadzoneRightTrigger={txtDeadZRTrig.Text}",
                    "",
                    "# RemapEnable (default false)",
                    "#   Whether or not the button remappings below are enabled",
                    $"RemapEnable = {enableControlMapping}",
                    "",
                    "# Remap*",
                    "#   Combinations to remap each button to.",
                    "#   Can be mapped as a single button or a combination (see Combinations section above)",
                    "#   Only buttons/clicks & triggers can be remapped atm, won't work with thumbsticks pos.",
                    $"RemapA = {psA}",
                    $"RemapB = {psB}",
                    $"RemapX = {psX}",
                    $"RemapY = {psY}",
                    $"RemapStart = {psStart}",
                    $"RemapBack = {psBack}",
                    $"RemapLS = {psLS}",
                    $"RemapRS = {psRS}",
                    $"RemapWhite = {psWhite}",
                    $"RemapBlack = {psBlack}",
                    $"RemapLT = {psLT}",
                    $"RemapRT = {psRT}",
                    $"RemapDpadUp = {psDpadUp}",
                    $"RemapDpadDown = {psDpadDown}",
                    "# 'Dpad' part of combination can be skipped if desired:",
                    $"RemapDpadLeft = {psleft}t",
                    $"RemapDpadRight = {psRight}",
                     "",
                     "[1234567890]",
                     "# This section configures a specific controller that has the serial # 1234567890",
                    $"EnableGuide={enableGuide}",
                     "",
                     "[0738:4526]",
                     "# This section configures controllers that use the VID/PID of 0738:4526 (as not all controllers may have unique serial numbers)",
                     $"EnableGuide={enableGuide}",
                     ""
                };

                // Set a variable to the Documents path.
                string iniPath = appInstallPath + @"\Xb2XInput1_5c\";

                using (StreamWriter outputFile = new StreamWriter(Path.Combine(iniPath, "Xb2XInput.ini")))
                {
                    foreach (string line in lines)
                        outputFile.WriteLine(line);
                }

                if (cbxEnableGuide.Checked == true)
                {
                    enableGuide = "true";
                }
                else
                {
                    enableGuide = "false";
                }


                // Trigger and joystick deadzone //
                Properties.Settings.Default.LeftTrigDZone = txtDeadZLTrig.Text;
                Properties.Settings.Default.RightTrigDZone = txtDeadZRTrig.Text;
                Properties.Settings.Default.LStickDZone = txtLStickDeadZ.Text;
                Properties.Settings.Default.RStickDZone = txtRStickDeadZ.Text;

                // Standard pack enabled? //
                Properties.Settings.Default.EnableGuideSys = cbxEnableGuide.Checked;
                Properties.Settings.Default.EnableVibrator = cbxEnableVib.Checked;

                // Is remaping enabled? //
                Properties.Settings.Default.RemapControls = cbxRemapController.Checked;

                // Show favorite buttons //
                Properties.Settings.Default.ShowControl = FavoriteView;

                // Guide Control //
                Properties.Settings.Default.cbRTigEnable = cbRTrigger.Checked;// Properties.Settings.Default.cbRTigEnable;
                Properties.Settings.Default.cbLTrigEn = cbLTrigger.Checked;// Properties.Settings.Default.cbLTrigEn;
                Properties.Settings.Default.cbLSe = cbLStick.Checked;// Properties.Settings.Default.cbLSe;
                Properties.Settings.Default.cbLSClicke = cbLSClick.Checked;// Properties.Settings.Default.cbLSClicke;
                Properties.Settings.Default.cbBacke = cbBack.Checked;// Properties.Settings.Default.cbBacke;
                Properties.Settings.Default.cbStarte = cbStart.Checked;// Properties.Settings.Default.cbStarte;
                Properties.Settings.Default.cbYe = cbY.Checked;// Properties.Settings.Default.cbYe;
                Properties.Settings.Default.cbXe = cbX.Checked;// Properties.Settings.Default.cbXe;
                Properties.Settings.Default.cbBe = cbB.Checked;// Properties.Settings.Default.cbBe;
                Properties.Settings.Default.cbAe = cbA.Checked;// Properties.Settings.Default.cbAe;
                Properties.Settings.Default.cbBlacke = cbRBumper.Checked;// Properties.Settings.Default.cbBlacke;
                Properties.Settings.Default.cbWhitee = cbLBumper.Checked;// Properties.Settings.Default.cbWhitee;
                Properties.Settings.Default.cbRSe = chRStick.Checked;// Properties.Settings.Default.cbRSe;
                Properties.Settings.Default.cbRSClicke = cbRSClick.Checked;// Properties.Settings.Default.cbRSClicke;

                // OBSLT //   // Remapped Controls //
                // OBSLT //   Properties.Settings.Default.inputYequals = "Y";
                // OBSLT //   Properties.Settings.Default.inputXequals = "X";
                // OBSLT //   Properties.Settings.Default.inputBequals = "B";
                // OBSLT //   Properties.Settings.Default.inputAequals = "A";
                // OBSLT //   Properties.Settings.Default.inputWhiteE = "White";
                // OBSLT //   Properties.Settings.Default.inputBlackE = "Black";
                // OBSLT //   Properties.Settings.Default.inputLTequals = "LT";
                // OBSLT //   Properties.Settings.Default.inputRTequals = "RT";
                // OBSLT //   Properties.Settings.Default.inputStartequals = "Start";
                // OBSLT //   Properties.Settings.Default.inputBackE = "Back";
                // OBSLT //   Properties.Settings.Default.inputLStE = "LS";
                // OBSLT //   Properties.Settings.Default.inputRStE = "RS";


                // Remapped Controls //
                Properties.Settings.Default.inputYequals = psY;
                Properties.Settings.Default.inputXequals = psX;
                Properties.Settings.Default.inputBequals = psB;
                Properties.Settings.Default.inputAequals = psA;
                Properties.Settings.Default.inputWhiteE = psWhite;
                Properties.Settings.Default.inputBlackE = psBlack;
                Properties.Settings.Default.inputLTequals = psLT;
                Properties.Settings.Default.inputRTequals = psRT;
                Properties.Settings.Default.inputStartequals = psStart;
                Properties.Settings.Default.inputBackE = psBack;
                Properties.Settings.Default.inputLStE = psLS;
                Properties.Settings.Default.inputRStE = psRS;



                // Save //
                Properties.Settings.Default.Save();

                // Allow to relaunch and exit. //
                btnApplyConfig.Enabled = true;
                btnApplyConfig.Visible = true;
                //Process.Start(iniPath);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                GC.Collect();
            }

            btnApplyConfig.Enabled = false;
            btnApplyConfig.Visible = false;

            // Relaunch Xb2Input if running other 
            try
            {

                Process[] processlist = Process.GetProcesses();
                foreach (Process theprocess in processlist)
                {
                    // Console.WriteLine("Process: {0} ID: {1}", theprocess.ProcessName, theprocess.Id);

                    if (theprocess.ProcessName.Contains("Xb2XInput"))
                    {
                       // theprocess.Kill();
                    }

                }
                // Wait for 1 second
                System.Threading.Thread.Sleep(500);

                ProcessStartInfo processStartInfo = new ProcessStartInfo();
                processStartInfo.UseShellExecute = true;
                processStartInfo.WorkingDirectory = appInstallPath;
                processStartInfo.FileName = appInstallPath + @"\Xb2XInput1_5c\Xb2XInput.exe";
                Process.Start(processStartInfo);

                Process[] processlists = Process.GetProcesses();
                foreach (Process theprocess in processlists)
                {
                    // Console.WriteLine("Process: {0} ID: {1}", theprocess.ProcessName, theprocess.Id);
                    if (theprocess.ProcessName.Contains("Xb2XInput"))
                    {
                        Close();
                    }

                }


            }
            catch
            {

            }


        }

        //
        // Button Configurations //
        // 
        // Left Trigger //
        //
        private void button12_Click(object sender, EventArgs e)
        {
            if (updateGuideMap == true)
            {
                if (!cbLTrigger.Checked)
                {
                    cbLTrigger.Checked = true;
                } else
                {
                    cbLTrigger.Checked = false;
                }
            }
        }
        //
        // Left stick click //
        //
        private void btnLStick_Click(object sender, EventArgs e)
        {
            // NO            
        }
        //
        // Left Trigger //
        //
        private void btnLSClick_Click(object sender, EventArgs e)
        {
            if (updateGuideMap == true)
            {
                if (!cbLSClick.Checked)
                {
                    cbLSClick.Checked = true;
                }
                else
                {
                    cbLSClick.Checked = false;
                }
            }
        }
        //
        // Back Button //
        //
        private void btnBack_Click(object sender, EventArgs e)
        {
            if (updateGuideMap == true)
            {
                if (!cbBack.Checked)
                {
                    cbBack.Checked = true;
                }
                else
                {
                    cbBack.Checked = false;
                }
            }
        }
        //
        //  //
        //
        private void btnXONEBack_Click(object sender, EventArgs e)
        {
            if (updateGuideMap == true)
            {
                if (!cbBack.Checked)
                {
                    cbBack.Checked = true;
                }
                else
                {
                    cbBack.Checked = false;
                }
            }
        }
        //
        //  //
        //
        private void btnX360Back_Click(object sender, EventArgs e)
        {
            if (updateGuideMap == true)
            {
                if (!cbBack.Checked)
                {
                    cbBack.Checked = true;
                }
                else
                {
                    cbBack.Checked = false;
                }
            }
        }
        //
        // //
        //
        private void btnStart_Click(object sender, EventArgs e)
        {
            if (updateGuideMap == true)
            {
                if (!cbStart.Checked)
                {
                    cbStart.Checked = true;
                }
                else
                {
                    cbStart.Checked = false;
                }
            }
        }
        //
        //  //
        //
        private void btnXONEStart_Click(object sender, EventArgs e)
        {
            if (updateGuideMap == true)
            {
                if (!cbStart.Checked)
                {
                    cbStart.Checked = true;
                }
                else
                {
                    cbStart.Checked = false;
                }
            }
        }
        //
        // //
        //
        private void btnX360Start_Click(object sender, EventArgs e)
        {
            if (updateGuideMap == true)
            {
                if (!cbStart.Checked)
                {
                    cbStart.Checked = true;
                }
                else
                {
                    cbStart.Checked = false;
                }
            }
        }
        //
        //  //
        //
        private void btnRTrigger_Click(object sender, EventArgs e)
        {
            if (updateGuideMap == true)
            {
                if (!cbRTrigger.Checked)
                {
                    cbRTrigger.Checked = true;
                }
                else
                {
                    cbRTrigger.Checked = false;
                }
            }
        }
        //
        //  //
        //
        private void btnY_Click(object sender, EventArgs e)
        {
            if (updateGuideMap == true)
            {
                if (!cbY.Checked)
                {
                    cbY.Checked = true;
                }
                else
                {
                    cbY.Checked = false;
                }
            }
        }
        //
        // //
        //
        private void button4_Click(object sender, EventArgs e)
        {
            if (updateGuideMap == true)
            {
                if (!cbX.Checked)
                {
                    cbX.Checked = true;
                }
                else
                {
                    cbX.Checked = false;
                }
            }
        }
        //
        // //
        //
        private void btnB_Click(object sender, EventArgs e)
        {
            if (updateGuideMap == true)
            {
                if (!cbB.Checked)
                {
                    cbB.Checked = true;
                }
                else
                {
                    cbB.Checked = false;
                }
            }

            // Make sure remappibng is enabled first before we do anything with the button. //
            if (remapButtons == true)
            {
                if (totaltoSwap <= 2)
                {
                    if (isASelected == false)
                    {
                        btnA.BackColor = Color.LimeGreen;
                        // cbxRemapController.Enabled = true;
                        isASelected = true;
                        totaltoSwap++;
                    }
                    else
                    {
                        btnA.BackColor = Color.Yellow;
                        // cbxRemapController.Enabled = false;
                        isASelected = false;
                        totaltoSwap--;

                    }
                }
            }
        }
        //
        //  Button A  //

        //
        private void button6_Click(object sender, EventArgs e)
        {
            if (updateGuideMap == true)
            {
                if (!cbA.Checked)
                {
                    cbA.Checked = true;
                }
                else
                {
                    cbA.Checked = false;
                }
            }


            // Make sure remappibng is enabled first before we do anything with the button. //
            if (remapButtons == true)
            {
                if (isASelected == false)
                {
                    if (isButtonchosen == true)
                    {
                        if (isASelected == false)
                        {
                            isASelected = true;
                            isButtonchosen = true;

                            btnA.BackColor = Color.Yellow; 

                            CallSwapMethod(psButtonIs, psA);
                        }
                    }
                    else
                    {
                        // No button was chosen so we are fthe first step

                        btnA.BackColor = Color.Blue; 

                        // Make our button become the first selected. //
                        psButtonIs = psA;
                        isASelected = true;
                        isButtonchosen = true;
                    }

                }
            }

            
        }


        public void CallSwapMethod(string s, string t)
        {

            MessageBox.Show($"{s} will swap with {t}");

            // If it was A instead //

           switch (s)
           {
                case "A":
                    if ("A" == psA)
                    {  
                        if ("Black" == t)
                        {
                            if ("Black" == psBlack)
                            {
                                btnRightBumper.BackgroundImage = Properties.Resources.Button_A;
                                btnBlack.BackgroundImage = Properties.Resources.Button_A;
                                //Control the UI elements here //
                                btnA.BackgroundImage = Properties.Resources.RBumper; // Change to a black button icon here // 

                                // If for bumpers heres the results //
                                btnRightBumper.BackColor = Color.Yellow;
                                btnBlack.BackColor = Color.Yellow;
                                btnA.BackColor = Color.Yellow;

                                // Process the backend //
                                psA = t;
                                psBlack = s;
                            }

                        }
                    } 

                    break;
                case "B":
                    if (s != t)
                    {
                        if (isBSelected == true)
                        {

                            if (isBlackSelected == true)
                            {
                                //Control the UI elements here //
                                btnA.BackgroundImage = Properties.Resources.RBumper; // Change to a black button icon here // 
                                                                                     // If for bumpers heres the results //
                                btnRightBumper.BackgroundImage = Properties.Resources.Button_A;
                                btnBlack.BackgroundImage = Properties.Resources.Button_A;
                                // Process the backend //
                                psA = t;
                                psBlack = s;
                            }

                            if (isBSelected == true)
                            {
                                //Control the UI elements here //
                                btnA.BackgroundImage = Properties.Resources.Button_B; // Change to a black button icon here // 
                                btnB.BackgroundImage = Properties.Resources.Button_A; // Change to a black button icon here //  
                                // Process the backend //
                                psA = t;
                                psB = s;
                            }

                            if (isBSelected == true)
                            {
                                //Control the UI elements here //
                                btnA.BackgroundImage = Properties.Resources.Button_X; // Change to a black button icon here // 
                                btnX.BackgroundImage = Properties.Resources.Button_A; // Change to a black button icon here //  
                                // Process the backend //
                                psA = t;
                                psX = s;
                            }

                            if (isBSelected == true)
                            {
                                //Control the UI elements here //
                                //Control the UI elements here //
                                btnA.BackgroundImage = Properties.Resources.Button_Y; // Change to a black button icon here // 
                                btnY.BackgroundImage = Properties.Resources.Button_A; // Change to a black button icon here //  
                                // Process the backend //
                                psA = t;
                                psY = s;
                            }

                            if (isBSelected == true)
                            {
                                //Control the UI elements here //
                                btnA.BackgroundImage = Properties.Resources.LTrigger; // Change to a black button icon here // 
                                btnLTrigger.BackgroundImage = Properties.Resources.Button_A; // Change to a black button icon here //  
                                // Process the backend //
                                psA = t;
                                psLT = s;
                            }

                            if (isRTSelected == true)
                            {
                                //Control the UI elements here //
                                btnA.BackgroundImage = Properties.Resources.RTrigger; // Change to a black button icon here // 
                                btnRTrigger.BackgroundImage = Properties.Resources.Button_A; // Change to a black button icon here //  
                                // Process the backend //
                                psA = t;
                                psRT = s;
                            }

                            if (isLSSelected == true)
                            {
                                //Control the UI elements here //
                                btnA.BackgroundImage = Properties.Resources.LStickClick; // Change to a black button icon here // 
                                btnLeftBumper.BackgroundImage = Properties.Resources.Button_A; // Change to a black button icon here //  
                                // Process the backend //
                                psA = t;
                                psLS = s;
                            }

                            if (isRSSelected == true)
                            {
                                //Control the UI elements here //
                                btnA.BackgroundImage = Properties.Resources.RStickClick; // Change to a black button icon here // 
                                btnRightBumper.BackgroundImage = Properties.Resources.Button_A; // Change to a black button icon here //  
                                // Process the backend //
                                psA = t;
                                psRS = s;
                            }

                            if (isWhiteSelected == true)
                            {
                                //Control the UI elements here //
                                btnA.BackgroundImage = Properties.Resources.LBumper; // Change to a black button icon here // 
                                                                                     // If for bumpers heres the results //
                                btnLeftBumper.BackgroundImage = Properties.Resources.Button_A;
                                btnWhite.BackgroundImage = Properties.Resources.Button_A;
                                // Process the backend //
                                psA = t;
                                psWhite = s;
                            }
                            if (isBackSelected == true)
                            {
                                //Control the UI elements here //
                                btnA.BackgroundImage = Properties.Resources.Button_Back_XONE; // Change to a black button icon here // 
                                btnBack.BackgroundImage = Properties.Resources.Button_A; // Change to a black button icon here //  
                                btnX360Start.BackgroundImage = Properties.Resources.Button_A; // Change to a black button icon here //  
                                btnXONEStart.BackgroundImage = Properties.Resources.Button_A; // Change to a black button icon here //  
                                // Process the backend //
                                psA = t;
                                psBack = s;
                            }

                            if (isStartSelected == true)
                            {
                                //Control the UI elements here //
                                btnA.BackgroundImage = Properties.Resources.Button_Start_XONE; // Change to a black button icon here // 
                                btnStart.BackgroundImage = Properties.Resources.Button_A; // Change to a black button icon here //  
                                btnX360Start.BackgroundImage = Properties.Resources.Button_A; // Change to a black button icon here //  
                                btnXONEStart.BackgroundImage = Properties.Resources.Button_A; // Change to a black button icon here //  
                                // Process the backend //


                                psA = t;
                                psStart = s;
                            }

                        }
                    }
                    break;
                case "X":
                    if (s != t)
                    {
                        if (isXSelected == true)
                        {

                            if (isBlackSelected == true)
                            {
                                //Control the UI elements here //
                                btnA.BackgroundImage = Properties.Resources.RBumper; // Change to a black button icon here // 
                                                                                     // If for bumpers heres the results //
                                btnRightBumper.BackgroundImage = Properties.Resources.Button_A;
                                btnBlack.BackgroundImage = Properties.Resources.Button_A;
                                // Process the backend //
                                psA = t;
                                psBlack = s;
                            }

                            if (isBSelected == true)
                            {
                                //Control the UI elements here //
                                btnA.BackgroundImage = Properties.Resources.Button_B; // Change to a black button icon here // 
                                btnB.BackgroundImage = Properties.Resources.Button_A; // Change to a black button icon here //  
                                // Process the backend //
                                psA = t;
                                psB = s;
                            }

                            if (isBSelected == true)
                            {
                                //Control the UI elements here //
                                btnA.BackgroundImage = Properties.Resources.Button_X; // Change to a black button icon here // 
                                btnX.BackgroundImage = Properties.Resources.Button_A; // Change to a black button icon here //  
                                // Process the backend //
                                psA = t;
                                psX = s;
                            }

                            if (isBSelected == true)
                            {
                                //Control the UI elements here //
                                //Control the UI elements here //
                                btnA.BackgroundImage = Properties.Resources.Button_Y; // Change to a black button icon here // 
                                btnY.BackgroundImage = Properties.Resources.Button_A; // Change to a black button icon here //  
                                // Process the backend //
                                psA = t;
                                psY = s;
                            }

                            if (isBSelected == true)
                            {
                                //Control the UI elements here //
                                btnA.BackgroundImage = Properties.Resources.LTrigger; // Change to a black button icon here // 
                                btnLTrigger.BackgroundImage = Properties.Resources.Button_A; // Change to a black button icon here //  
                                // Process the backend //
                                psA = t;
                                psLT = s;
                            }

                            if (isRTSelected == true)
                            {
                                //Control the UI elements here //
                                btnA.BackgroundImage = Properties.Resources.RTrigger; // Change to a black button icon here // 
                                btnRTrigger.BackgroundImage = Properties.Resources.Button_A; // Change to a black button icon here //  
                                // Process the backend //
                                psA = t;
                                psRT = s;
                            }

                            if (isLSSelected == true)
                            {
                                //Control the UI elements here //
                                btnA.BackgroundImage = Properties.Resources.LStickClick; // Change to a black button icon here // 
                                btnLeftBumper.BackgroundImage = Properties.Resources.Button_A; // Change to a black button icon here //  
                                // Process the backend //
                                psA = t;
                                psLS = s;
                            }

                            if (isRSSelected == true)
                            {
                                //Control the UI elements here //
                                btnA.BackgroundImage = Properties.Resources.RStickClick; // Change to a black button icon here // 
                                btnRightBumper.BackgroundImage = Properties.Resources.Button_A; // Change to a black button icon here //  
                                // Process the backend //
                                psA = t;
                                psRS = s;
                            }

                            if (isWhiteSelected == true)
                            {
                                //Control the UI elements here //
                                btnA.BackgroundImage = Properties.Resources.LBumper; // Change to a black button icon here // 
                                                                                     // If for bumpers heres the results //
                                btnLeftBumper.BackgroundImage = Properties.Resources.Button_A;
                                btnWhite.BackgroundImage = Properties.Resources.Button_A;
                                // Process the backend //
                                psA = t;
                                psWhite = s;
                            }
                            if (isBackSelected == true)
                            {
                                //Control the UI elements here //
                                btnA.BackgroundImage = Properties.Resources.Button_Back_XONE; // Change to a black button icon here // 
                                btnBack.BackgroundImage = Properties.Resources.Button_A; // Change to a black button icon here //  
                                btnX360Start.BackgroundImage = Properties.Resources.Button_A; // Change to a black button icon here //  
                                btnXONEStart.BackgroundImage = Properties.Resources.Button_A; // Change to a black button icon here //  
                                // Process the backend //
                                psA = t;
                                psBack = s;
                            }

                            if (isStartSelected == true)
                            {
                                //Control the UI elements here //
                                btnA.BackgroundImage = Properties.Resources.Button_Start_XONE; // Change to a black button icon here // 
                                btnStart.BackgroundImage = Properties.Resources.Button_A; // Change to a black button icon here //  
                                btnX360Start.BackgroundImage = Properties.Resources.Button_A; // Change to a black button icon here //  
                                btnXONEStart.BackgroundImage = Properties.Resources.Button_A; // Change to a black button icon here //  
                                // Process the backend //


                                psA = t;
                                psStart = s;
                            }

                        }
                    }
                    break;
                case "Y":
                    if (s != t)
                    {
                        if (isYSelected == true)
                        {

                            if (isBlackSelected == true)
                            {
                                //Control the UI elements here //
                                btnA.BackgroundImage = Properties.Resources.RBumper; // Change to a black button icon here // 
                                                                                     // If for bumpers heres the results //
                                btnRightBumper.BackgroundImage = Properties.Resources.Button_A;
                                btnBlack.BackgroundImage = Properties.Resources.Button_A;
                                // Process the backend //
                                psA = t;
                                psBlack = s;
                            }

                            if (isBSelected == true)
                            {
                                //Control the UI elements here //
                                btnA.BackgroundImage = Properties.Resources.Button_B; // Change to a black button icon here // 
                                btnB.BackgroundImage = Properties.Resources.Button_A; // Change to a black button icon here //  
                                // Process the backend //
                                psA = t;
                                psB = s;
                            }

                            if (isBSelected == true)
                            {
                                //Control the UI elements here //
                                btnA.BackgroundImage = Properties.Resources.Button_X; // Change to a black button icon here // 
                                btnX.BackgroundImage = Properties.Resources.Button_A; // Change to a black button icon here //  
                                // Process the backend //
                                psA = t;
                                psX = s;
                            }

                            if (isBSelected == true)
                            {
                                //Control the UI elements here //
                                //Control the UI elements here //
                                btnA.BackgroundImage = Properties.Resources.Button_Y; // Change to a black button icon here // 
                                btnY.BackgroundImage = Properties.Resources.Button_A; // Change to a black button icon here //  
                                // Process the backend //
                                psA = t;
                                psY = s;
                            }

                            if (isBSelected == true)
                            {
                                //Control the UI elements here //
                                btnA.BackgroundImage = Properties.Resources.LTrigger; // Change to a black button icon here // 
                                btnLTrigger.BackgroundImage = Properties.Resources.Button_A; // Change to a black button icon here //  
                                // Process the backend //
                                psA = t;
                                psLT = s;
                            }

                            if (isRTSelected == true)
                            {
                                //Control the UI elements here //
                                btnA.BackgroundImage = Properties.Resources.RTrigger; // Change to a black button icon here // 
                                btnRTrigger.BackgroundImage = Properties.Resources.Button_A; // Change to a black button icon here //  
                                // Process the backend //
                                psA = t;
                                psRT = s;
                            }

                            if (isLSSelected == true)
                            {
                                //Control the UI elements here //
                                btnA.BackgroundImage = Properties.Resources.LStickClick; // Change to a black button icon here // 
                                btnLeftBumper.BackgroundImage = Properties.Resources.Button_A; // Change to a black button icon here //  
                                // Process the backend //
                                psA = t;
                                psLS = s;
                            }

                            if (isRSSelected == true)
                            {
                                //Control the UI elements here //
                                btnA.BackgroundImage = Properties.Resources.RStickClick; // Change to a black button icon here // 
                                btnRightBumper.BackgroundImage = Properties.Resources.Button_A; // Change to a black button icon here //  
                                // Process the backend //
                                psA = t;
                                psRS = s;
                            }

                            if (isWhiteSelected == true)
                            {
                                //Control the UI elements here //
                                btnA.BackgroundImage = Properties.Resources.LBumper; // Change to a black button icon here // 
                                                                                     // If for bumpers heres the results //
                                btnLeftBumper.BackgroundImage = Properties.Resources.Button_A;
                                btnWhite.BackgroundImage = Properties.Resources.Button_A;
                                // Process the backend //
                                psA = t;
                                psWhite = s;
                            }
                            if (isBackSelected == true)
                            {
                                //Control the UI elements here //
                                btnA.BackgroundImage = Properties.Resources.Button_Back_XONE; // Change to a black button icon here // 
                                btnBack.BackgroundImage = Properties.Resources.Button_A; // Change to a black button icon here //  
                                btnX360Start.BackgroundImage = Properties.Resources.Button_A; // Change to a black button icon here //  
                                btnXONEStart.BackgroundImage = Properties.Resources.Button_A; // Change to a black button icon here //  
                                // Process the backend //
                                psA = t;
                                psBack = s;
                            }

                            if (isStartSelected == true)
                            {
                                //Control the UI elements here //
                                btnA.BackgroundImage = Properties.Resources.Button_Start_XONE; // Change to a black button icon here // 
                                btnStart.BackgroundImage = Properties.Resources.Button_A; // Change to a black button icon here //  
                                btnX360Start.BackgroundImage = Properties.Resources.Button_A; // Change to a black button icon here //  
                                btnXONEStart.BackgroundImage = Properties.Resources.Button_A; // Change to a black button icon here //  
                                // Process the backend //


                                psA = t;
                                psStart = s;
                            }

                        }
                    }

                    break; 
                case "LT":
                    if (s != t)
                    {
                        if (isLTSelected == true)
                        {

                            if (isBlackSelected == true)
                            {
                                //Control the UI elements here //
                                btnA.BackgroundImage = Properties.Resources.RBumper; // Change to a black button icon here // 
                                                                                     // If for bumpers heres the results //
                                btnRightBumper.BackgroundImage = Properties.Resources.Button_A;
                                btnBlack.BackgroundImage = Properties.Resources.Button_A;
                                // Process the backend //
                                psA = t;
                                psBlack = s;
                            }

                            if (isBSelected == true)
                            {
                                //Control the UI elements here //
                                btnA.BackgroundImage = Properties.Resources.Button_B; // Change to a black button icon here // 
                                btnB.BackgroundImage = Properties.Resources.Button_A; // Change to a black button icon here //  
                                // Process the backend //
                                psA = t;
                                psB = s;
                            }

                            if (isBSelected == true)
                            {
                                //Control the UI elements here //
                                btnA.BackgroundImage = Properties.Resources.Button_X; // Change to a black button icon here // 
                                btnX.BackgroundImage = Properties.Resources.Button_A; // Change to a black button icon here //  
                                // Process the backend //
                                psA = t;
                                psX = s;
                            }

                            if (isBSelected == true)
                            {
                                //Control the UI elements here //
                                //Control the UI elements here //
                                btnA.BackgroundImage = Properties.Resources.Button_Y; // Change to a black button icon here // 
                                btnY.BackgroundImage = Properties.Resources.Button_A; // Change to a black button icon here //  
                                // Process the backend //
                                psA = t;
                                psY = s;
                            }

                            if (isBSelected == true)
                            {
                                //Control the UI elements here //
                                btnA.BackgroundImage = Properties.Resources.LTrigger; // Change to a black button icon here // 
                                btnLTrigger.BackgroundImage = Properties.Resources.Button_A; // Change to a black button icon here //  
                                // Process the backend //
                                psA = t;
                                psLT = s;
                            }

                            if (isRTSelected == true)
                            {
                                //Control the UI elements here //
                                btnA.BackgroundImage = Properties.Resources.RTrigger; // Change to a black button icon here // 
                                btnRTrigger.BackgroundImage = Properties.Resources.Button_A; // Change to a black button icon here //  
                                // Process the backend //
                                psA = t;
                                psRT = s;
                            }

                            if (isLSSelected == true)
                            {
                                //Control the UI elements here //
                                btnA.BackgroundImage = Properties.Resources.LStickClick; // Change to a black button icon here // 
                                btnLeftBumper.BackgroundImage = Properties.Resources.Button_A; // Change to a black button icon here //  
                                // Process the backend //
                                psA = t;
                                psLS = s;
                            }

                            if (isRSSelected == true)
                            {
                                //Control the UI elements here //
                                btnA.BackgroundImage = Properties.Resources.RStickClick; // Change to a black button icon here // 
                                btnRightBumper.BackgroundImage = Properties.Resources.Button_A; // Change to a black button icon here //  
                                // Process the backend //
                                psA = t;
                                psRS = s;
                            }

                            if (isWhiteSelected == true)
                            {
                                //Control the UI elements here //
                                btnA.BackgroundImage = Properties.Resources.LBumper; // Change to a black button icon here // 
                                                                                     // If for bumpers heres the results //
                                btnLeftBumper.BackgroundImage = Properties.Resources.Button_A;
                                btnWhite.BackgroundImage = Properties.Resources.Button_A;
                                // Process the backend //
                                psA = t;
                                psWhite = s;
                            }
                            if (isBackSelected == true)
                            {
                                //Control the UI elements here //
                                btnA.BackgroundImage = Properties.Resources.Button_Back_XONE; // Change to a black button icon here // 
                                btnBack.BackgroundImage = Properties.Resources.Button_A; // Change to a black button icon here //  
                                btnX360Start.BackgroundImage = Properties.Resources.Button_A; // Change to a black button icon here //  
                                btnXONEStart.BackgroundImage = Properties.Resources.Button_A; // Change to a black button icon here //  
                                // Process the backend //
                                psA = t;
                                psBack = s;
                            }

                            if (isStartSelected == true)
                            {
                                //Control the UI elements here //
                                btnA.BackgroundImage = Properties.Resources.Button_Start_XONE; // Change to a black button icon here // 
                                btnStart.BackgroundImage = Properties.Resources.Button_A; // Change to a black button icon here //  
                                btnX360Start.BackgroundImage = Properties.Resources.Button_A; // Change to a black button icon here //  
                                btnXONEStart.BackgroundImage = Properties.Resources.Button_A; // Change to a black button icon here //  
                                // Process the backend //


                                psA = t;
                                psStart = s;
                            }

                        }
                    }
                    break;
                case "RT":
                    if (s != t)
                    {
                        if (isRTSelected == true)
                        {

                            if (isBlackSelected == true)
                            {
                                //Control the UI elements here //
                                btnA.BackgroundImage = Properties.Resources.RBumper; // Change to a black button icon here // 
                                                                                     // If for bumpers heres the results //
                                btnRightBumper.BackgroundImage = Properties.Resources.Button_A;
                                btnBlack.BackgroundImage = Properties.Resources.Button_A;
                                // Process the backend //
                                psA = t;
                                psBlack = s;
                            }

                            if (isBSelected == true)
                            {
                                //Control the UI elements here //
                                btnA.BackgroundImage = Properties.Resources.Button_B; // Change to a black button icon here // 
                                btnB.BackgroundImage = Properties.Resources.Button_A; // Change to a black button icon here //  
                                // Process the backend //
                                psA = t;
                                psB = s;
                            }

                            if (isBSelected == true)
                            {
                                //Control the UI elements here //
                                btnA.BackgroundImage = Properties.Resources.Button_X; // Change to a black button icon here // 
                                btnX.BackgroundImage = Properties.Resources.Button_A; // Change to a black button icon here //  
                                // Process the backend //
                                psA = t;
                                psX = s;
                            }

                            if (isBSelected == true)
                            {
                                //Control the UI elements here //
                                //Control the UI elements here //
                                btnA.BackgroundImage = Properties.Resources.Button_Y; // Change to a black button icon here // 
                                btnY.BackgroundImage = Properties.Resources.Button_A; // Change to a black button icon here //  
                                // Process the backend //
                                psA = t;
                                psY = s;
                            }

                            if (isBSelected == true)
                            {
                                //Control the UI elements here //
                                btnA.BackgroundImage = Properties.Resources.LTrigger; // Change to a black button icon here // 
                                btnLTrigger.BackgroundImage = Properties.Resources.Button_A; // Change to a black button icon here //  
                                // Process the backend //
                                psA = t;
                                psLT = s;
                            }

                            if (isRTSelected == true)
                            {
                                //Control the UI elements here //
                                btnA.BackgroundImage = Properties.Resources.RTrigger; // Change to a black button icon here // 
                                btnRTrigger.BackgroundImage = Properties.Resources.Button_A; // Change to a black button icon here //  
                                // Process the backend //
                                psA = t;
                                psRT = s;
                            }

                            if (isLSSelected == true)
                            {
                                //Control the UI elements here //
                                btnA.BackgroundImage = Properties.Resources.LStickClick; // Change to a black button icon here // 
                                btnLeftBumper.BackgroundImage = Properties.Resources.Button_A; // Change to a black button icon here //  
                                // Process the backend //
                                psA = t;
                                psLS = s;
                            }

                            if (isRSSelected == true)
                            {
                                //Control the UI elements here //
                                btnA.BackgroundImage = Properties.Resources.RStickClick; // Change to a black button icon here // 
                                btnRightBumper.BackgroundImage = Properties.Resources.Button_A; // Change to a black button icon here //  
                                // Process the backend //
                                psA = t;
                                psRS = s;
                            }

                            if (isWhiteSelected == true)
                            {
                                //Control the UI elements here //
                                btnA.BackgroundImage = Properties.Resources.LBumper; // Change to a black button icon here // 
                                                                                     // If for bumpers heres the results //
                                btnLeftBumper.BackgroundImage = Properties.Resources.Button_A;
                                btnWhite.BackgroundImage = Properties.Resources.Button_A;
                                // Process the backend //
                                psA = t;
                                psWhite = s;
                            }
                            if (isBackSelected == true)
                            {
                                //Control the UI elements here //
                                btnA.BackgroundImage = Properties.Resources.Button_Back_XONE; // Change to a black button icon here // 
                                btnBack.BackgroundImage = Properties.Resources.Button_A; // Change to a black button icon here //  
                                btnX360Start.BackgroundImage = Properties.Resources.Button_A; // Change to a black button icon here //  
                                btnXONEStart.BackgroundImage = Properties.Resources.Button_A; // Change to a black button icon here //  
                                // Process the backend //
                                psA = t;
                                psBack = s;
                            }

                            if (isStartSelected == true)
                            {
                                //Control the UI elements here //
                                btnA.BackgroundImage = Properties.Resources.Button_Start_XONE; // Change to a black button icon here // 
                                btnStart.BackgroundImage = Properties.Resources.Button_A; // Change to a black button icon here //  
                                btnX360Start.BackgroundImage = Properties.Resources.Button_A; // Change to a black button icon here //  
                                btnXONEStart.BackgroundImage = Properties.Resources.Button_A; // Change to a black button icon here //  
                                // Process the backend //


                                psA = t;
                                psStart = s;
                            }

                        }
                    }
                    break;
                case "Black": //Means s = Black
                    if ("Black" == psBlack)
                    {
                        if ("A" == t)
                        {
                            if ("A" == psA)
                            {
                                btnRightBumper.BackgroundImage = Properties.Resources.RBumper;
                                btnBlack.BackgroundImage = Properties.Resources.RBumper;
                                //Control the UI elements here //
                                btnA.BackgroundImage = Properties.Resources.Button_A; // Change to a black button icon here // 

                                // If for bumpers heres the results //
                                btnRightBumper.BackColor = Color.Yellow;
                                btnBlack.BackColor = Color.Yellow;
                                btnA.BackColor = Color.Yellow;

                                // Process the backend //
                                psA = s;
                                psBlack = t;
                            }
                        }
                    }


                    break;
                case "White":
                    if (s != t)
                    {
                        if (isWhiteSelected == true)
                        {

                            if (isBlackSelected == true)
                            {
                                //Control the UI elements here //
                                btnA.BackgroundImage = Properties.Resources.RBumper; // Change to a black button icon here // 
                                                                                     // If for bumpers heres the results //
                                btnRightBumper.BackgroundImage = Properties.Resources.Button_A;
                                btnBlack.BackgroundImage = Properties.Resources.Button_A;
                                // Process the backend //
                                psA = t;
                                psBlack = s;
                            }

                            if (isBSelected == true)
                            {
                                //Control the UI elements here //
                                btnA.BackgroundImage = Properties.Resources.Button_B; // Change to a black button icon here // 
                                btnB.BackgroundImage = Properties.Resources.Button_A; // Change to a black button icon here //  
                                // Process the backend //
                                psA = t;
                                psB = s;
                            }

                            if (isBSelected == true)
                            {
                                //Control the UI elements here //
                                btnA.BackgroundImage = Properties.Resources.Button_X; // Change to a black button icon here // 
                                btnX.BackgroundImage = Properties.Resources.Button_A; // Change to a black button icon here //  
                                // Process the backend //
                                psA = t;
                                psX = s;
                            }

                            if (isBSelected == true)
                            {
                                //Control the UI elements here //
                                //Control the UI elements here //
                                btnA.BackgroundImage = Properties.Resources.Button_Y; // Change to a black button icon here // 
                                btnY.BackgroundImage = Properties.Resources.Button_A; // Change to a black button icon here //  
                                // Process the backend //
                                psA = t;
                                psY = s;
                            }

                            if (isBSelected == true)
                            {
                                //Control the UI elements here //
                                btnA.BackgroundImage = Properties.Resources.LTrigger; // Change to a black button icon here // 
                                btnLTrigger.BackgroundImage = Properties.Resources.Button_A; // Change to a black button icon here //  
                                // Process the backend //
                                psA = t;
                                psLT = s;
                            }

                            if (isRTSelected == true)
                            {
                                //Control the UI elements here //
                                btnA.BackgroundImage = Properties.Resources.RTrigger; // Change to a black button icon here // 
                                btnRTrigger.BackgroundImage = Properties.Resources.Button_A; // Change to a black button icon here //  
                                // Process the backend //
                                psA = t;
                                psRT = s;
                            }

                            if (isLSSelected == true)
                            {
                                //Control the UI elements here //
                                btnA.BackgroundImage = Properties.Resources.LStickClick; // Change to a black button icon here // 
                                btnLeftBumper.BackgroundImage = Properties.Resources.Button_A; // Change to a black button icon here //  
                                // Process the backend //
                                psA = t;
                                psLS = s;
                            }

                            if (isRSSelected == true)
                            {
                                //Control the UI elements here //
                                btnA.BackgroundImage = Properties.Resources.RStickClick; // Change to a black button icon here // 
                                btnRightBumper.BackgroundImage = Properties.Resources.Button_A; // Change to a black button icon here //  
                                // Process the backend //
                                psA = t;
                                psRS = s;
                            }

                            if (isWhiteSelected == true)
                            {
                                //Control the UI elements here //
                                btnA.BackgroundImage = Properties.Resources.LBumper; // Change to a black button icon here // 
                                                                                     // If for bumpers heres the results //
                                btnLeftBumper.BackgroundImage = Properties.Resources.Button_A;
                                btnWhite.BackgroundImage = Properties.Resources.Button_A;
                                // Process the backend //
                                psA = t;
                                psWhite = s;
                            }
                            if (isBackSelected == true)
                            {
                                //Control the UI elements here //
                                btnA.BackgroundImage = Properties.Resources.Button_Back_XONE; // Change to a black button icon here // 
                                btnBack.BackgroundImage = Properties.Resources.Button_A; // Change to a black button icon here //  
                                btnX360Start.BackgroundImage = Properties.Resources.Button_A; // Change to a black button icon here //  
                                btnXONEStart.BackgroundImage = Properties.Resources.Button_A; // Change to a black button icon here //  
                                // Process the backend //
                                psA = t;
                                psBack = s;
                            }

                            if (isStartSelected == true)
                            {
                                //Control the UI elements here //
                                btnA.BackgroundImage = Properties.Resources.Button_Start_XONE; // Change to a black button icon here // 
                                btnStart.BackgroundImage = Properties.Resources.Button_A; // Change to a black button icon here //  
                                btnX360Start.BackgroundImage = Properties.Resources.Button_A; // Change to a black button icon here //  
                                btnXONEStart.BackgroundImage = Properties.Resources.Button_A; // Change to a black button icon here //  
                                // Process the backend //


                                psA = t;
                                psStart = s;
                            }

                        }
                    }
                    break;
                case "RS":
                    if (s != t)
                    {
                        if (isRSSelected == true)
                        {

                            if (isBlackSelected == true)
                            {
                                //Control the UI elements here //
                                btnA.BackgroundImage = Properties.Resources.RBumper; // Change to a black button icon here // 
                                                                                     // If for bumpers heres the results //
                                btnRightBumper.BackgroundImage = Properties.Resources.Button_A;
                                btnBlack.BackgroundImage = Properties.Resources.Button_A;
                                // Process the backend //
                                psA = t;
                                psBlack = s;
                            }

                            if (isBSelected == true)
                            {
                                //Control the UI elements here //
                                btnA.BackgroundImage = Properties.Resources.Button_B; // Change to a black button icon here // 
                                btnB.BackgroundImage = Properties.Resources.Button_A; // Change to a black button icon here //  
                                // Process the backend //
                                psA = t;
                                psB = s;
                            }

                            if (isBSelected == true)
                            {
                                //Control the UI elements here //
                                btnA.BackgroundImage = Properties.Resources.Button_X; // Change to a black button icon here // 
                                btnX.BackgroundImage = Properties.Resources.Button_A; // Change to a black button icon here //  
                                // Process the backend //
                                psA = t;
                                psX = s;
                            }

                            if (isBSelected == true)
                            {
                                //Control the UI elements here //
                                //Control the UI elements here //
                                btnA.BackgroundImage = Properties.Resources.Button_Y; // Change to a black button icon here // 
                                btnY.BackgroundImage = Properties.Resources.Button_A; // Change to a black button icon here //  
                                // Process the backend //
                                psA = t;
                                psY = s;
                            }

                            if (isBSelected == true)
                            {
                                //Control the UI elements here //
                                btnA.BackgroundImage = Properties.Resources.LTrigger; // Change to a black button icon here // 
                                btnLTrigger.BackgroundImage = Properties.Resources.Button_A; // Change to a black button icon here //  
                                // Process the backend //
                                psA = t;
                                psLT = s;
                            }

                            if (isRTSelected == true)
                            {
                                //Control the UI elements here //
                                btnA.BackgroundImage = Properties.Resources.RTrigger; // Change to a black button icon here // 
                                btnRTrigger.BackgroundImage = Properties.Resources.Button_A; // Change to a black button icon here //  
                                // Process the backend //
                                psA = t;
                                psRT = s;
                            }

                            if (isLSSelected == true)
                            {
                                //Control the UI elements here //
                                btnA.BackgroundImage = Properties.Resources.LStickClick; // Change to a black button icon here // 
                                btnLeftBumper.BackgroundImage = Properties.Resources.Button_A; // Change to a black button icon here //  
                                // Process the backend //
                                psA = t;
                                psLS = s;
                            }

                            if (isRSSelected == true)
                            {
                                //Control the UI elements here //
                                btnA.BackgroundImage = Properties.Resources.RStickClick; // Change to a black button icon here // 
                                btnRightBumper.BackgroundImage = Properties.Resources.Button_A; // Change to a black button icon here //  
                                // Process the backend //
                                psA = t;
                                psRS = s;
                            }

                            if (isWhiteSelected == true)
                            {
                                //Control the UI elements here //
                                btnA.BackgroundImage = Properties.Resources.LBumper; // Change to a black button icon here // 
                                                                                     // If for bumpers heres the results //
                                btnLeftBumper.BackgroundImage = Properties.Resources.Button_A;
                                btnWhite.BackgroundImage = Properties.Resources.Button_A;
                                // Process the backend //
                                psA = t;
                                psWhite = s;
                            }
                            if (isBackSelected == true)
                            {
                                //Control the UI elements here //
                                btnA.BackgroundImage = Properties.Resources.Button_Back_XONE; // Change to a black button icon here // 
                                btnBack.BackgroundImage = Properties.Resources.Button_A; // Change to a black button icon here //  
                                btnX360Start.BackgroundImage = Properties.Resources.Button_A; // Change to a black button icon here //  
                                btnXONEStart.BackgroundImage = Properties.Resources.Button_A; // Change to a black button icon here //  
                                // Process the backend //
                                psA = t;
                                psBack = s;
                            }

                            if (isStartSelected == true)
                            {
                                //Control the UI elements here //
                                btnA.BackgroundImage = Properties.Resources.Button_Start_XONE; // Change to a black button icon here // 
                                btnStart.BackgroundImage = Properties.Resources.Button_A; // Change to a black button icon here //  
                                btnX360Start.BackgroundImage = Properties.Resources.Button_A; // Change to a black button icon here //  
                                btnXONEStart.BackgroundImage = Properties.Resources.Button_A; // Change to a black button icon here //  
                                // Process the backend //


                                psA = t;
                                psStart = s;
                            }

                        }
                    }
                    break;
                case "LS":
                    if (s != t)
                    {
                        if (isLSSelected == true)
                        {

                            if (isBlackSelected == true)
                            {
                                //Control the UI elements here //
                                btnA.BackgroundImage = Properties.Resources.RBumper; // Change to a black button icon here // 
                                                                                     // If for bumpers heres the results //
                                btnRightBumper.BackgroundImage = Properties.Resources.Button_A;
                                btnBlack.BackgroundImage = Properties.Resources.Button_A;
                                // Process the backend //
                                psA = t;
                                psBlack = s;
                            }

                            if (isBSelected == true)
                            {
                                //Control the UI elements here //
                                btnA.BackgroundImage = Properties.Resources.Button_B; // Change to a black button icon here // 
                                btnB.BackgroundImage = Properties.Resources.Button_A; // Change to a black button icon here //  
                                // Process the backend //
                                psA = t;
                                psB = s;
                            }

                            if (isBSelected == true)
                            {
                                //Control the UI elements here //
                                btnA.BackgroundImage = Properties.Resources.Button_X; // Change to a black button icon here // 
                                btnX.BackgroundImage = Properties.Resources.Button_A; // Change to a black button icon here //  
                                // Process the backend //
                                psA = t;
                                psX = s;
                            }

                            if (isBSelected == true)
                            {
                                //Control the UI elements here //
                                //Control the UI elements here //
                                btnA.BackgroundImage = Properties.Resources.Button_Y; // Change to a black button icon here // 
                                btnY.BackgroundImage = Properties.Resources.Button_A; // Change to a black button icon here //  
                                // Process the backend //
                                psA = t;
                                psY = s;
                            }

                            if (isBSelected == true)
                            {
                                //Control the UI elements here //
                                btnA.BackgroundImage = Properties.Resources.LTrigger; // Change to a black button icon here // 
                                btnLTrigger.BackgroundImage = Properties.Resources.Button_A; // Change to a black button icon here //  
                                // Process the backend //
                                psA = t;
                                psLT = s;
                            }

                            if (isRTSelected == true)
                            {
                                //Control the UI elements here //
                                btnA.BackgroundImage = Properties.Resources.RTrigger; // Change to a black button icon here // 
                                btnRTrigger.BackgroundImage = Properties.Resources.Button_A; // Change to a black button icon here //  
                                // Process the backend //
                                psA = t;
                                psRT = s;
                            }

                            if (isLSSelected == true)
                            {
                                //Control the UI elements here //
                                btnA.BackgroundImage = Properties.Resources.LStickClick; // Change to a black button icon here // 
                                btnLeftBumper.BackgroundImage = Properties.Resources.Button_A; // Change to a black button icon here //  
                                // Process the backend //
                                psA = t;
                                psLS = s;
                            }

                            if (isRSSelected == true)
                            {
                                //Control the UI elements here //
                                btnA.BackgroundImage = Properties.Resources.RStickClick; // Change to a black button icon here // 
                                btnRightBumper.BackgroundImage = Properties.Resources.Button_A; // Change to a black button icon here //  
                                // Process the backend //
                                psA = t;
                                psRS = s;
                            }

                            if (isWhiteSelected == true)
                            {
                                //Control the UI elements here //
                                btnA.BackgroundImage = Properties.Resources.LBumper; // Change to a black button icon here // 
                                                                                     // If for bumpers heres the results //
                                btnLeftBumper.BackgroundImage = Properties.Resources.Button_A;
                                btnWhite.BackgroundImage = Properties.Resources.Button_A;
                                // Process the backend //
                                psA = t;
                                psWhite = s;
                            }
                            if (isBackSelected == true)
                            {
                                //Control the UI elements here //
                                btnA.BackgroundImage = Properties.Resources.Button_Back_XONE; // Change to a black button icon here // 
                                btnBack.BackgroundImage = Properties.Resources.Button_A; // Change to a black button icon here //  
                                btnX360Start.BackgroundImage = Properties.Resources.Button_A; // Change to a black button icon here //  
                                btnXONEStart.BackgroundImage = Properties.Resources.Button_A; // Change to a black button icon here //  
                                // Process the backend //
                                psA = t;
                                psBack = s;
                            }

                            if (isStartSelected == true)
                            {
                                //Control the UI elements here //
                                btnA.BackgroundImage = Properties.Resources.Button_Start_XONE; // Change to a black button icon here // 
                                btnStart.BackgroundImage = Properties.Resources.Button_A; // Change to a black button icon here //  
                                btnX360Start.BackgroundImage = Properties.Resources.Button_A; // Change to a black button icon here //  
                                btnXONEStart.BackgroundImage = Properties.Resources.Button_A; // Change to a black button icon here //  
                                // Process the backend //


                                psA = t;
                                psStart = s;
                            }

                        }
                    }
                    break;
                     
            }



            // Create and check button press events //
            isASelected = false;
            isBSelected = false;
            isXSelected = false;
            isYSelected = false;
            isBackSelected = false;
            isStartSelected = false;
            isBlackSelected = false;
            isWhiteSelected = false;
            isRSSelected = false;
            isLSSelected = false;
            isRTSelected = false;
            isLTSelected = false;


            totaltoSwap = 0;
            isButtonchosen = false;





            // Show the user that they are able to save everything they do to the program. So nothing breaks!!! //
            btnSaveCurrentLayout.Visible = true;
        }


        //
        //  //
        //
        private void btnBlack_Click(object sender, EventArgs e)
        {
            if (updateGuideMap == true)
            {
                if (!cbRBumper.Checked)
                {
                    cbRBumper.Checked = true;
                }
                else
                {
                    cbRBumper.Checked = false;
                }
            }



            // Make sure remappibng is enabled first before we do anything with the button. //
            if (remapButtons == true)
            {
                if (isBlackSelected == false)
                {
                    if (isButtonchosen == true)
                    {
                        if (isBlackSelected == false)
                        {
                            isBlackSelected = true;
                            isButtonchosen = true;

                            btnRightBumper.BackColor = Color.Yellow;
                            btnBlack.BackColor = Color.Yellow;

                            CallSwapMethod(psButtonIs, psBlack);
                        }
                    }
                    else
                    {
                        // No button was chosen so we are fthe first step

                        btnRightBumper.BackColor = Color.Blue;
                        btnBlack.BackColor = Color.Blue;

                        // Make our button become the first selected. //
                        psButtonIs = psBlack;
                        isBlackSelected = true;
                        isButtonchosen = true;
                    }

                }
            }


        }
        //
        // //
        //
        private void btnRightBumper_Click(object sender, EventArgs e)
        {
            if (updateGuideMap == true)
            {
                if (!cbRBumper.Checked)
                {
                    cbRBumper.Checked = true;
                }
                else
                {
                    cbRBumper.Checked = false;
                }
            }


            // Make sure remappibng is enabled first before we do anything with the button. //
            if (remapButtons == true)
            {
                if (isBlackSelected == false)
                {
                    if (isButtonchosen == true)
                    {
                        if (isBlackSelected == false)
                        { 
                            isBlackSelected = true;
                            isButtonchosen = true; 

                            btnRightBumper.BackColor = Color.Yellow;
                            btnBlack.BackColor = Color.Yellow;
                    
                            CallSwapMethod(psButtonIs, psBlack);
                        }
                    } else
                    {
                        // No button was chosen so we are fthe first step

                        btnRightBumper.BackColor = Color.Blue;
                        btnBlack.BackColor = Color.Blue;

                        // Make our button become the first selected. //
                        psButtonIs = psBlack;
                        isBlackSelected = true;
                        isButtonchosen = true;
                    }

                } 
            }

        }
        //
        //  //
        //
        private void btnWhite_Click(object sender, EventArgs e)
        {
            if (updateGuideMap == true)
            {
                if (!cbLBumper.Checked)
                {
                    cbLBumper.Checked = true;
                }
                else
                {
                    cbLBumper.Checked = false;
                }
            }
        }
        //
        //  //
        //
        private void btnLeftBumper_Click(object sender, EventArgs e)
        {
            if (updateGuideMap == true)
            {
                if (!cbLBumper.Checked)
                {
                    cbLBumper.Checked = true;
                }
                else
                {
                    cbLBumper.Checked = false;
                }
            }
        }
        //
        //  //
        //
        private void btnRSClick_Click(object sender, EventArgs e)
        {
            if (updateGuideMap == true)
            {
                if (!cbRSClick.Checked)
                {
                    cbRSClick.Checked = true;
                }
                else
                {
                    cbRSClick.Checked = false;
                }
            }
        }
        //
        // //
        //
        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutBox1 aboutBox1 = new AboutBox1();
            aboutBox1.ShowDialog();
        }
         

        private void LaunchXb2Input_Click(object sender, EventArgs e)
        {
            // Relaunch Xb2Input if running other 
            try
            {

                Process[] processlist = Process.GetProcesses();
                foreach (Process theprocess in processlist)
                {
                    // Console.WriteLine("Process: {0} ID: {1}", theprocess.ProcessName, theprocess.Id);

                    if (theprocess.ProcessName.Contains("Xb2XInput"))
                    {
                        theprocess.Kill();

                    }

                }
                // Wait for 1 second

                // Create a new process
                Process process = new Process();

                // Set the process start info
                process.StartInfo.FileName = appInstallPath + @"\Xb2XInput1_5c\Xb2XInput.exe";

                process.StartInfo.Verb = "runas"; // Launch the process as an administrator

                // Start the process
                process.Start();


                System.Threading.Thread.Sleep(500);


            }
            catch (Exception ex)
            {
                MessageBox.Show($"Something went wrong and threw this error instead: {ex.Message + Environment.NewLine}Please check your files be reinstalling the application and try again.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnGuideButton_Click(object sender, EventArgs e)
        {

             


        }

        private void runAtStartupToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // if (runAtStartupToolStripMenuItem.Checked == false)
            // {
            //     runAtStartupToolStripMenuItem.Checked = true;
            // }
            // else
            // {
            //     runAtStartupToolStripMenuItem.Checked = false;
            // 
            // }
        }

        private void runAtStartupToolStripMenuItem_CheckedChanged(object sender, EventArgs e)
        {
            if (runAtStartupToolStripMenuItem.Checked == true)
            {
                // Write a value to the registry
                var bait = Registry.GetValue(@"HKEY_CURRENT_USER\Software\XboxOGKit", "InstallPath", null);
                // The path to the target executable
                string hook = bait.ToString() + @"\Xb2XInput1_5c\Xb2XInput.exe"; 
                try
                {

                    // The path to the target executable
                    string targetPath = hook; 

                    // The path to the start menu
                    string startMenuFolder = Environment.GetFolderPath(Environment.SpecialFolder.Startup);
                    //MessageBox.Show(startMenuFolder);


                    // Create the shortcut link
                    WshShell shell = new WshShell();
                    IWshShortcut shortcut = (IWshShortcut)shell.CreateShortcut(Path.Combine(startMenuFolder, "Xb2XInput.lnk"));
                    shortcut.TargetPath = targetPath;
                    shortcut.Save();
                     
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {

                }

            }
            else
            {
                // remove shortcut // 
                try
                {
                     
                    string startMenuFolder = Environment.GetFolderPath(Environment.SpecialFolder.Startup); 
                    File.Delete(startMenuFolder + @"\Xb2XInput.lnk");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);    
                } finally
                {

                }

            }

            // The path to the start menu
            //string startMenuFolder = Environment.GetFolderPath(Environment.SpecialFolder.StartMenu);

            // Create the shortcut link
            // WshShell shell = new WshShell();
            // IWshShortcut shortcut = (IWshShortcut)shell.CreateShortcut(Path.Combine(startMenuFolder, "XboxOGKit.lnk"));
            // shortcut.TargetPath = targetPath;
            // shortcut.Save();




            // Show the user that they are able to save everything they do to the program. So nothing breaks!!! //
            btnSaveCurrentLayout.Visible = true;
        }


        private void cbxTestBtnFdBk_CheckedChanged(object sender, EventArgs e)
        {
            if(cbxTestBtnFdBk.Checked == true)
            {

                // Highlight all available buttons for mapping //

                
                     




                if (!bgwProcessWhileLoopXinput.IsBusy)
                {
                    bgwProcessWhileLoopXinput.RunWorkerAsync(); //.DoWork();
                } else
                {
                    bgwProcessWhileLoopXinput.RunWorkerAsync(); //.DoWork();

                }
                 

            }
            else
            {
                // if (!bgwProcessWhileLoopXinput.IsBusy)
                // {
                //     //bgwProcessWhileLoopXinput.CancelAsync(); //.DoWork();
                // } else
                // { 
                //         bgwProcessWhileLoopXinput.RunWorkerAsync(); //.DoWork();                   
                // }

                // Get the current refresh rate of the primary display
                int refreshRate = 0;
                try
                {
                    // refreshRate = (int)Screen.PrimaryScreen.Bounds.Height;
                    System.Management.ManagementObjectSearcher searcher = new System.Management.ManagementObjectSearcher("root\\CIMV2", "SELECT * FROM Win32_VideoController WHERE Primary='True'");
                    foreach (System.Management.ManagementObject queryObj in searcher.Get())
                    {
                        refreshRate = (int)(uint)queryObj["CurrentRefreshRate"];
                    }

                }
                catch
                {
                    refreshRate = 60;
                }


                framesPerSecond = refreshRate;
                milliseconds = (int)Math.Round(1000.0 / framesPerSecond);
                label5.Text = $"Primary Display:{refreshRate}FPS at {milliseconds.ToString()}ms.";


                timer1.Interval = milliseconds;
                timer1.Stop();
                timer1.Enabled = false;
            }





            // Show the user that they are able to save everything they do to the program. So nothing breaks!!! //
            btnSaveCurrentLayout.Visible = true;
        }



        private void bgwProcessWhileLoopXinput_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            if (enableVibrator == "true")
            {

                while (cbxTestBtnFdBk.Checked == true)
                {

                    // Refresh();
                    var controller = new Controller(UserIndex.One);
                    var controller2 = new Controller(UserIndex.Two);
                    var controller3 = new Controller(UserIndex.Three);
                    var controller4 = new Controller(UserIndex.Four);


                    // Player 1 //
                    if (controller.IsConnected)
                    {
                        State state = controller.GetState();
                        string buttons = "";




                        controller.SetVibration(new Vibration
                        {
                            LeftMotorSpeed = 0,
                            RightMotorSpeed = 0
                        });


                        // Default states //
                        btnA.BackColor = Color.Transparent;
                        btnB.BackColor = Color.Transparent;
                        btnY.BackColor = Color.Transparent;
                        btnX.BackColor = Color.Transparent;
                        btnLeftBumper.BackColor = Color.Transparent;
                        btnRightBumper.BackColor = Color.Transparent;
                        btnLSClick.BackColor = Color.Transparent;
                        btnRSClick.BackColor = Color.Transparent;
                        btnBlack.BackColor = Color.Transparent;
                        btnWhite.BackColor = Color.Transparent;
                        btnLTrigger.BackColor = Color.Transparent;
                        btnRTrigger.BackColor = Color.Transparent;
                        btnStart.BackColor = Color.Transparent;
                        btnX360Start.BackColor = Color.Transparent;
                        btnXONEStart.BackColor = Color.Transparent;
                        btnXONEBack.BackColor = Color.Transparent;
                        btnX360Back.BackColor = Color.Transparent;
                        btnBack.BackColor = Color.Transparent;
                        btnDUp.BackColor = Color.Transparent;
                        btnDDown.BackColor = Color.Transparent;
                        btnDLeft.BackColor = Color.Transparent;
                        btnDRight.BackColor = Color.Transparent;
                        pbLeftTrigger = 0;
                        pbRightTrigger = 0;
                        btnLTrigger.BackColor = Color.Transparent;
                        btnRTrigger.BackColor = Color.Transparent;
                        btnGPX.BackColor = Color.Transparent;
                        btnGPA.BackColor = Color.Transparent;
                        btnGPB.BackColor = Color.Transparent;
                        btnGPY.BackColor = Color.Transparent;


                        // Start our checks from here // 


                        Gamepad gamepad = controller.GetState().Gamepad;


                        LJoystickX = gamepad.LeftThumbX;
                        LJoystickY = gamepad.LeftThumbY;



                        bgwProcessWhileLoopXinput.ReportProgress(LJoystickX, LJoystickY);



                        RJoystickX = gamepad.RightThumbX;
                        RJoystickY = gamepad.RightThumbY;

                        bgwProcessWhileLoopXinput.ReportProgress(RJoystickX, RJoystickY);
                        // Set the rumble of the gamepad using the motor speeds


                        // Get the left trigger position
                        leftTrigger = gamepad.LeftTrigger;
                        // Get the right trigger position
                        rightTrigger = gamepad.RightTrigger;

                        // Set the rumble of the gamepad using the motor speeds

                        bgwProcessWhileLoopXinput.ReportProgress(leftTrigger, rightTrigger);


                        // Get the gamepad object from the controller's current state 
                        // Get the left and right thumbstick positions 

                        short leftThumbstickX = gamepad.LeftThumbX;
                        short leftThumbstickY = gamepad.LeftThumbY;
                        short rightThumbstickX = gamepad.RightThumbX;
                        short rightThumbstickY = gamepad.RightThumbY;

                        // Reduce the movement by adjusting by the deadzone. //
                        string convertStickRatio = txtLStickDeadZ.Text;
                        short numL = short.Parse(convertStickRatio);
                        string convertStickRatio2 = txtRStickDeadZ.Text;
                        short numR = short.Parse(convertStickRatio2);

                        // Scale the thumbstick positions from values between -32768 and 32767 to values between -1 and 1
                        float leftThumbstickXScaled = leftThumbstickX / (32768.0f - numL);
                        float leftThumbstickYScaled = leftThumbstickY / (32768.0f - numL);
                        float rightThumbstickXScaled = rightThumbstickX / (32768.0f - numR);
                        float rightThumbstickYScaled = rightThumbstickY / (32768.0f - numR);


                        int iCrossSize = 3;
                        // Create a bitmap for the graph picture box
                        Bitmap bitmap = new Bitmap(pictureBox1.Width, pictureBox1.Height);


                        // Create the graphics object for the Left Thumbstick //
                        // This helps update in memory instead //
                        using (Graphics g = Graphics.FromImage(bitmap))
                        {
                            // Set the color of the cross
                            Pen pen = new Pen(Color.LimeGreen, iCrossSize);

                            // Calculate the center point of the picture box
                            int pictureBoxCenterX = pictureBox1.Width / 2;
                            int pictureBoxCenterY = pictureBox1.Height / 2;

                            // Calculate the cross position based on the thumbstick positions
                            int crossX = (int)(pictureBoxCenterX + (leftThumbstickXScaled * pictureBoxCenterX));
                            int crossY = (int)(pictureBoxCenterY - (leftThumbstickYScaled * pictureBoxCenterY));

                            // Calculate the dot position based on the thumbstick positions
                            int dotX = (int)(pictureBoxCenterX + (leftThumbstickXScaled * pictureBoxCenterX));
                            int dotY = (int)(pictureBoxCenterY - (leftThumbstickYScaled * pictureBoxCenterY));

                            // Draw the horizontal and vertical lines of the cross
                            g.DrawLine(pen, crossX - 10, crossY, crossX + 10, crossY);
                            g.DrawLine(pen, crossX, crossY - 10, crossX, crossY + 10);
                        }

                        // Create a bitmap for the graph picture box //
                        // This helps update in memory instead //
                        Bitmap bitmap2 = new Bitmap(pictureBox2.Width, pictureBox2.Height);

                        // Create the graphics object for the Right Thumbstick //
                        using (Graphics x = Graphics.FromImage(bitmap2))
                        {
                            // Set the color of the cross
                            Pen pen = new Pen(Color.LimeGreen, iCrossSize);

                            // Calculate the center point of the picture box
                            int pictureBoxCenterX = pictureBox2.Width / 2;
                            int pictureBoxCenterY = pictureBox2.Height / 2;

                            // Calculate the cross position based on the thumbstick positions
                            int crossX = (int)(pictureBoxCenterX + (rightThumbstickXScaled * pictureBoxCenterX));
                            int crossY = (int)(pictureBoxCenterY - (rightThumbstickYScaled * pictureBoxCenterY));

                            // Calculate the dot position based on the thumbstick positions
                            int dotX = (int)(pictureBoxCenterX + (rightThumbstickXScaled * pictureBoxCenterX));
                            int dotY = (int)(pictureBoxCenterY - (rightThumbstickYScaled * pictureBoxCenterY));

                            // Draw the horizontal and vertical lines of the cross
                            x.DrawLine(pen, crossX - 10, crossY, crossX + 10, crossY);
                            x.DrawLine(pen, crossX, crossY - 10, crossX, crossY + 10);

                            // // Draw the dot
                            // x.FillEllipse(null, dotX - 10, dotY - 10, 20, 20);
                            // x.DrawEllipse(pen, dotX - 10, dotY - 10, 20, 20);
                        }

                        // Show the updated information by setting the image each time based on the fps //
                        // Set the image of the picture box to the bitmap
                        pictureBox1.Image = bitmap;

                        // Set the image of the picture box to the bitmap
                        pictureBox2.Image = bitmap2;


                        if (cbxEnableVib.Checked == true)
                        {
                            enableVibrator = "true";

                             
                            // Set the back color of the button based on the left thumbstick positions
                            // Color color = Color.FromArgb(leftThumbstickXScaledE, leftThumbstickYScaledE, 0);
                            // button1.BackColor = color;


                            // 
                            //  // Set the rumble of the gamepad using the motor speeds
                            //  controller.SetVibration(new Vibration
                            //  {
                            //      LeftMotorSpeed = (ushort)(short)(LJoystickX),
                            //      RightMotorSpeed = (ushort)(short)(LJoystickY) //32767
                            //  });


                            // Vibrate our controller based on Trigger position //
                            pbLeftTrigger = state.Gamepad.LeftTrigger;
                            pbRightTrigger = state.Gamepad.RightTrigger;

                            controller.SetVibration(new Vibration
                            {
                                LeftMotorSpeed = (ushort)(short)(pbLeftTrigger * 257),
                                RightMotorSpeed = (ushort)(short)(pbRightTrigger * 257)
                            });


                        }
                        else
                        {
                            enableVibrator = "false";


                            controller.SetVibration(new Vibration
                            {
                                LeftMotorSpeed = 0,
                                RightMotorSpeed = 0
                            });


                        }



                        int iLT = 255 - leftTrigger;
                        int iRT = 255 - rightTrigger;

                        // Set the back color of the button based on the left trigger pressure
                        Color colorLT = Color.FromArgb(leftTrigger, iLT, 0);
                        btnLTrigger.BackColor = colorLT;

                        // Set the back color of the button based on the left trigger pressure
                        Color colorRT = Color.FromArgb(rightTrigger, iRT, 0);
                        btnRTrigger.BackColor = colorRT;




                        if (state.Gamepad.Buttons.HasFlag(GamepadButtonFlags.A))
                        {
                            if (remapButtons == true)
                            {


                                buttons += "A ";
                                btnA.Invoke((MethodInvoker)delegate
                                {
                                    btnA.BackColor = Color.LimeGreen;
                                     

                                });

                                btnGPA.Invoke((MethodInvoker)delegate
                                {
                                    btnGPA.BackColor = Color.LimeGreen;



                                });

                            } else
                            {

                                buttons += "A ";
                                btnA.Invoke((MethodInvoker)delegate
                                { 
                                    btnA.BackColor = Color.LimeGreen;

                                     

                                });

                                 
                                btnGPA.Invoke((MethodInvoker)delegate
                                {
                                    btnGPA.BackColor = Color.Transparent;



                                });
                            }



                            if (cbxEnableVib.Checked == true)
                            {
                                enableVibrator = "true";
                                controller.SetVibration(new Vibration
                                {
                                    LeftMotorSpeed = 65535,
                                    RightMotorSpeed = 65535
                                });
                            }
                            else
                            {
                                enableVibrator = "false";
                            }

                        }
                        if (state.Gamepad.Buttons.HasFlag(GamepadButtonFlags.B))
                        { 

                            if (remapButtons == true)
                            {


                                buttons += "B ";
                                btnB.Invoke((MethodInvoker)delegate
                                {
                                    btnB.BackColor = Color.LimeGreen;

                                     
                                });

                                btnGPB.Invoke((MethodInvoker)delegate
                                {
                                    btnGPB.BackColor = Color.LimeGreen;



                                });
                            }
                            else
                            {

                                buttons += "B ";
                                btnB.Invoke((MethodInvoker)delegate
                                {
                                    btnB.BackColor = Color.LimeGreen;

                                     
                                    

                                });

                                btnGPB.Invoke((MethodInvoker)delegate
                                {
                                    btnGPB.BackColor = Color.Transparent;



                                });

                            }

                            if (cbxEnableVib.Checked == true)
                            {
                                enableVibrator = "true";
                                controller.SetVibration(new Vibration
                                {
                                    LeftMotorSpeed = 65535,
                                    RightMotorSpeed = 65535
                                });
                            }
                            else
                            {
                                enableVibrator = "false";
                            }
                        }
                        if (state.Gamepad.Buttons.HasFlag(GamepadButtonFlags.X))
                        {
                            buttons += "X ";
                            btnX.BackColor = Color.LimeGreen;

                            if (remapButtons == true)
                            {


                                buttons += "X ";
                                btnX.Invoke((MethodInvoker)delegate
                                {
                                    btnX.BackColor = Color.LimeGreen;

                                    

                                });


                                btnGPX.Invoke((MethodInvoker)delegate
                                {
                                    btnGPX.BackColor = Color.LimeGreen;



                                });

                            }
                            else
                            {

                                buttons += "X ";
                                btnX.Invoke((MethodInvoker)delegate
                                {
                                    btnX.BackColor = Color.LimeGreen;

                                     

                                });


                                btnGPX.Invoke((MethodInvoker)delegate
                                {
                                    btnGPX.BackColor = Color.Transparent;



                                });

                            }

                            if (cbxEnableVib.Checked == true)
                            {
                                enableVibrator = "true";
                                controller.SetVibration(new Vibration
                                {
                                    LeftMotorSpeed = 65535,
                                    RightMotorSpeed = 65535
                                });
                            }
                            else
                            {
                                enableVibrator = "false";
                            }
                        }
                        if (state.Gamepad.Buttons.HasFlag(GamepadButtonFlags.Y))
                        {
                            buttons += "Y ";
                            btnY.BackColor = Color.LimeGreen;

                            if (remapButtons == true)
                            {


                                buttons += "Y ";
                                btnY.Invoke((MethodInvoker)delegate
                                {
                                    btnY.BackColor = Color.LimeGreen;

                                     
                                     

                                });

                                btnGPY.Invoke((MethodInvoker)delegate
                                {
                                    btnGPY.BackColor = Color.LimeGreen;



                                });

                            }
                            else
                            {

                                buttons += "Y ";
                                btnY.Invoke((MethodInvoker)delegate
                                {
                                    btnY.BackColor = Color.LimeGreen;
                                     

                                });


                                btnGPY.Invoke((MethodInvoker)delegate
                                {
                                    btnGPY.BackColor = Color.Transparent;



                                });

                            }


                            if (cbxEnableVib.Checked == true)
                            {
                                enableVibrator = "true";
                                controller.SetVibration(new Vibration
                                {
                                    LeftMotorSpeed = 65535,
                                    RightMotorSpeed = 65535
                                });
                            }
                            else
                            {
                                enableVibrator = "false";
                            }
                        }
                        if (state.Gamepad.Buttons.HasFlag(GamepadButtonFlags.Start))
                        {
                            buttons += "Start ";
                            btnStart.BackColor = Color.LimeGreen;
                            btnX360Start.BackColor = Color.LimeGreen;
                            btnXONEStart.BackColor = Color.LimeGreen;
                            if (cbxEnableVib.Checked == true)
                            {
                                enableVibrator = "true";
                                controller.SetVibration(new Vibration
                                {
                                    LeftMotorSpeed = 65535,
                                    RightMotorSpeed = 65535
                                });
                            }
                            else
                            {
                                enableVibrator = "false";
                            }
                        }
                        if (state.Gamepad.Buttons.HasFlag(GamepadButtonFlags.Back))
                        {
                            buttons += "Back ";

                            btnXONEBack.BackColor = Color.LimeGreen;
                            btnX360Back.BackColor = Color.LimeGreen;
                            btnBack.BackColor = Color.LimeGreen;
                            if (cbxEnableVib.Checked == true)
                            {
                                enableVibrator = "true";
                                controller.SetVibration(new Vibration
                                {
                                    LeftMotorSpeed = 65535,
                                    RightMotorSpeed = 65535
                                });
                            }
                            else
                            {
                                enableVibrator = "false";
                            }
                        }
                        if (state.Gamepad.Buttons.HasFlag(GamepadButtonFlags.LeftShoulder))
                        {
                            buttons += "Left Shoulder ";
                            btnLeftBumper.BackColor = Color.LimeGreen;
                            btnWhite.BackColor = Color.LimeGreen;
                            if (cbxEnableVib.Checked == true)
                            {
                                enableVibrator = "true";
                                controller.SetVibration(new Vibration
                                {
                                    LeftMotorSpeed = 65535,
                                    RightMotorSpeed = 65535
                                });
                            }
                            else
                            {
                                enableVibrator = "false";
                            }
                        }
                        if (state.Gamepad.Buttons.HasFlag(GamepadButtonFlags.RightShoulder))
                        {
                            buttons += "Right Shoulder ";
                            btnRightBumper.BackColor = Color.LimeGreen;
                            btnBlack.BackColor = Color.LimeGreen;
                            if (cbxEnableVib.Checked == true)
                            {
                                enableVibrator = "true";
                                controller.SetVibration(new Vibration
                                {
                                    LeftMotorSpeed = 65535,
                                    RightMotorSpeed = 65535
                                });
                            }
                            else
                            {
                                enableVibrator = "false";
                            }

                        }
                        if (state.Gamepad.Buttons.HasFlag(GamepadButtonFlags.LeftThumb))
                        {
                            buttons += "Left Thumb ";
                            btnLSClick.BackColor = Color.LimeGreen;
                            if (cbxEnableVib.Checked == true)
                            {
                                enableVibrator = "true";
                                controller.SetVibration(new Vibration
                                {
                                    LeftMotorSpeed = 65535,
                                    RightMotorSpeed = 65535
                                });
                            }
                            else
                            {
                                enableVibrator = "false";
                            }

                        }
                        if (state.Gamepad.Buttons.HasFlag(GamepadButtonFlags.RightThumb))
                        {
                            buttons += "Right Thumb ";
                            btnRSClick.BackColor = Color.LimeGreen;
                            if (cbxEnableVib.Checked == true)
                            {
                                enableVibrator = "true";
                                controller.SetVibration(new Vibration
                                {
                                    LeftMotorSpeed = 65535,
                                    RightMotorSpeed = 65535
                                });
                            }
                            else
                            {
                                enableVibrator = "false";
                            }

                        }
                        if (state.Gamepad.Buttons.HasFlag(GamepadButtonFlags.DPadUp))
                        {
                            buttons += "DPadUp ";
                            btnDUp.BackColor = Color.LimeGreen;
                            //btnWhite.BackColor = Color.LimeGreen;
                            if (cbxEnableVib.Checked == true)
                            {
                                enableVibrator = "true";
                                controller.SetVibration(new Vibration
                                {
                                    LeftMotorSpeed = 65535,
                                    RightMotorSpeed = 65535
                                });
                            }
                            else
                            {
                                enableVibrator = "false";
                            }
                        }
                        if (state.Gamepad.Buttons.HasFlag(GamepadButtonFlags.DPadDown))
                        {
                            buttons += "DPadDown ";
                            btnDDown.BackColor = Color.LimeGreen;
                            // btnBlack.BackColor = Color.LimeGreen;
                            if (cbxEnableVib.Checked == true)
                            {
                                enableVibrator = "true";
                                controller.SetVibration(new Vibration
                                {
                                    LeftMotorSpeed = 65535,
                                    RightMotorSpeed = 65535
                                });
                            }
                            else
                            {
                                enableVibrator = "false";
                            }

                        }
                        if (state.Gamepad.Buttons.HasFlag(GamepadButtonFlags.DPadLeft))
                        {
                            buttons += "DPadLeft ";
                            btnDLeft.BackColor = Color.LimeGreen;
                            if (cbxEnableVib.Checked == true)
                            {
                                enableVibrator = "true";
                                controller.SetVibration(new Vibration
                                {
                                    LeftMotorSpeed = 65535,
                                    RightMotorSpeed = 65535
                                });
                            }
                            else
                            {
                                enableVibrator = "false";
                            }

                        }
                        if (state.Gamepad.Buttons.HasFlag(GamepadButtonFlags.DPadRight))
                        {
                            buttons += "DPadRight ";
                            btnDRight.BackColor = Color.LimeGreen;
                            if (cbxEnableVib.Checked == true)
                            {
                                enableVibrator = "true";
                                controller.SetVibration(new Vibration
                                {
                                    LeftMotorSpeed = 65535,
                                    RightMotorSpeed = 65535
                                });
                            }
                            else
                            {
                                enableVibrator = "false";
                            }

                        }





                        ///     label1.Lo 



                    }

                    // Player 2 //// Player 1 //
                    if (controller2.IsConnected)
                    {
                        State state = controller2.GetState();
                        string buttons = "";



                        controller2.SetVibration(new Vibration
                        {
                            LeftMotorSpeed = 0,
                            RightMotorSpeed = 0
                        });


                        // Default states //
                        btnA.BackColor = Color.Transparent;
                        btnB.BackColor = Color.Transparent;
                        btnY.BackColor = Color.Transparent;
                        btnX.BackColor = Color.Transparent;
                        btnLeftBumper.BackColor = Color.Transparent;
                        btnRightBumper.BackColor = Color.Transparent;
                        btnLSClick.BackColor = Color.Transparent;
                        btnRSClick.BackColor = Color.Transparent;
                        btnBlack.BackColor = Color.Transparent;
                        btnWhite.BackColor = Color.Transparent;
                        btnLTrigger.BackColor = Color.Transparent;
                        btnRTrigger.BackColor = Color.Transparent;
                        btnStart.BackColor = Color.Transparent;
                        btnX360Start.BackColor = Color.Transparent;
                        btnXONEStart.BackColor = Color.Transparent;
                        btnXONEBack.BackColor = Color.Transparent;
                        btnX360Back.BackColor = Color.Transparent;
                        btnBack.BackColor = Color.Transparent;
                        btnDUp.BackColor = Color.Transparent;
                        btnDDown.BackColor = Color.Transparent;
                        btnDLeft.BackColor = Color.Transparent;
                        btnDRight.BackColor = Color.Transparent;


                        // Start our checks from here // 


                        Gamepad gamepad = controller2.GetState().Gamepad;


                        LJoystickX = gamepad.LeftThumbX;
                        LJoystickY = gamepad.LeftThumbY;



                        bgwProcessWhileLoopXinput.ReportProgress(LJoystickX, LJoystickY);



                        RJoystickX = gamepad.RightThumbX;
                        RJoystickY = gamepad.RightThumbY;

                        bgwProcessWhileLoopXinput.ReportProgress(RJoystickX, RJoystickY);
                        // Set the rumble of the gamepad using the motor speeds


                        // Get the left trigger position
                        leftTrigger = gamepad.LeftTrigger;
                        // Get the right trigger position
                        rightTrigger = gamepad.RightTrigger;

                        // Set the rumble of the gamepad using the motor speeds

                        bgwProcessWhileLoopXinput.ReportProgress(leftTrigger, rightTrigger);




                        if (cbxEnableVib.Checked == true)
                        {
                            enableVibrator = "true";


                            controller2.SetVibration(new Vibration
                            {
                                LeftMotorSpeed = (ushort)(short)(RJoystickX),
                                RightMotorSpeed = (ushort)(short)(RJoystickY) //32767
                            });


                            // Set the rumble of the gamepad using the motor speeds
                            controller2.SetVibration(new Vibration
                            {
                                LeftMotorSpeed = (ushort)(short)(LJoystickX),
                                RightMotorSpeed = (ushort)(short)(LJoystickY) //32767
                            });

                            controller2.SetVibration(new Vibration
                            {
                                LeftMotorSpeed = (ushort)(short)(leftTrigger * 257),
                                RightMotorSpeed = (ushort)(short)(rightTrigger * 257)
                            });

                        }
                        else
                        {
                            enableVibrator = "false";
                        }



                        if (state.Gamepad.Buttons.HasFlag(GamepadButtonFlags.A))
                        {
                            buttons += "A ";
                            btnA.Invoke((MethodInvoker)delegate
                            {
                                btnA.BackColor = Color.LimeGreen;

                            });

                            if (cbxEnableVib.Checked == true)
                            {
                                enableVibrator = "true";
                                controller2.SetVibration(new Vibration
                                {
                                    LeftMotorSpeed = 65535,
                                    RightMotorSpeed = 65535
                                });
                            }
                            else
                            {
                                enableVibrator = "false";
                            }

                        }
                        if (state.Gamepad.Buttons.HasFlag(GamepadButtonFlags.B))
                        {
                            buttons += "B ";
                            btnB.BackColor = Color.LimeGreen;

                            if (cbxEnableVib.Checked == true)
                            {
                                enableVibrator = "true";
                                controller2.SetVibration(new Vibration
                                {
                                    LeftMotorSpeed = 65535,
                                    RightMotorSpeed = 65535
                                });
                            }
                            else
                            {
                                enableVibrator = "false";
                            }
                        }
                        if (state.Gamepad.Buttons.HasFlag(GamepadButtonFlags.X))
                        {
                            buttons += "X ";
                            btnX.BackColor = Color.LimeGreen;
                            if (cbxEnableVib.Checked == true)
                            {
                                enableVibrator = "true";
                                controller2.SetVibration(new Vibration
                                {
                                    LeftMotorSpeed = 65535,
                                    RightMotorSpeed = 65535
                                });
                            }
                            else
                            {
                                enableVibrator = "false";
                            }
                        }
                        if (state.Gamepad.Buttons.HasFlag(GamepadButtonFlags.Y))
                        {
                            buttons += "Y ";
                            btnY.BackColor = Color.LimeGreen;
                            if (cbxEnableVib.Checked == true)
                            {
                                enableVibrator = "true";
                                controller2.SetVibration(new Vibration
                                {
                                    LeftMotorSpeed = 65535,
                                    RightMotorSpeed = 65535
                                });
                            }
                            else
                            {
                                enableVibrator = "false";
                            }
                        }
                        if (state.Gamepad.Buttons.HasFlag(GamepadButtonFlags.Start))
                        {
                            buttons += "Start ";
                            btnStart.BackColor = Color.LimeGreen;
                            btnX360Start.BackColor = Color.LimeGreen;
                            btnXONEStart.BackColor = Color.LimeGreen;
                            if (cbxEnableVib.Checked == true)
                            {
                                enableVibrator = "true";
                                controller2.SetVibration(new Vibration
                                {
                                    LeftMotorSpeed = 65535,
                                    RightMotorSpeed = 65535
                                });
                            }
                            else
                            {
                                enableVibrator = "false";
                            }
                        }
                        if (state.Gamepad.Buttons.HasFlag(GamepadButtonFlags.Back))
                        {
                            buttons += "Back ";

                            btnXONEBack.BackColor = Color.LimeGreen;
                            btnX360Back.BackColor = Color.LimeGreen;
                            btnBack.BackColor = Color.LimeGreen;
                            if (cbxEnableVib.Checked == true)
                            {
                                enableVibrator = "true";
                                controller2.SetVibration(new Vibration
                                {
                                    LeftMotorSpeed = 65535,
                                    RightMotorSpeed = 65535
                                });
                            }
                            else
                            {
                                enableVibrator = "false";
                            }
                        }
                        if (state.Gamepad.Buttons.HasFlag(GamepadButtonFlags.LeftShoulder))
                        {
                            buttons += "Left Shoulder ";
                            btnLeftBumper.BackColor = Color.LimeGreen;
                            btnWhite.BackColor = Color.LimeGreen;
                            if (cbxEnableVib.Checked == true)
                            {
                                enableVibrator = "true";
                                controller2.SetVibration(new Vibration
                                {
                                    LeftMotorSpeed = 65535,
                                    RightMotorSpeed = 65535
                                });
                            }
                            else
                            {
                                enableVibrator = "false";
                            }
                        }
                        if (state.Gamepad.Buttons.HasFlag(GamepadButtonFlags.RightShoulder))
                        {
                            buttons += "Right Shoulder ";
                            btnRightBumper.BackColor = Color.LimeGreen;
                            btnBlack.BackColor = Color.LimeGreen;
                            if (cbxEnableVib.Checked == true)
                            {
                                enableVibrator = "true";
                                controller2.SetVibration(new Vibration
                                {
                                    LeftMotorSpeed = 65535,
                                    RightMotorSpeed = 65535
                                });
                            }
                            else
                            {
                                enableVibrator = "false";
                            }

                        }
                        if (state.Gamepad.Buttons.HasFlag(GamepadButtonFlags.LeftThumb))
                        {
                            buttons += "Left Thumb ";
                            btnLSClick.BackColor = Color.LimeGreen;
                            if (cbxEnableVib.Checked == true)
                            {
                                enableVibrator = "true";
                                controller2.SetVibration(new Vibration
                                {
                                    LeftMotorSpeed = 65535,
                                    RightMotorSpeed = 65535
                                });
                            }
                            else
                            {
                                enableVibrator = "false";
                            }

                        }
                        if (state.Gamepad.Buttons.HasFlag(GamepadButtonFlags.RightThumb))
                        {
                            buttons += "Right Thumb ";
                            btnRSClick.BackColor = Color.LimeGreen;
                            if (cbxEnableVib.Checked == true)
                            {
                                enableVibrator = "true";
                                controller2.SetVibration(new Vibration
                                {
                                    LeftMotorSpeed = 65535,
                                    RightMotorSpeed = 65535
                                });
                            }
                            else
                            {
                                enableVibrator = "false";
                            }

                        }
                        if (state.Gamepad.Buttons.HasFlag(GamepadButtonFlags.DPadUp))
                        {
                            buttons += "DPadUp ";
                            btnDUp.BackColor = Color.LimeGreen;
                            //btnWhite.BackColor = Color.LimeGreen;
                            if (cbxEnableVib.Checked == true)
                            {
                                enableVibrator = "true";
                                controller2.SetVibration(new Vibration
                                {
                                    LeftMotorSpeed = 65535,
                                    RightMotorSpeed = 65535
                                });
                            }
                            else
                            {
                                enableVibrator = "false";
                            }
                        }
                        if (state.Gamepad.Buttons.HasFlag(GamepadButtonFlags.DPadDown))
                        {
                            buttons += "DPadDown ";
                            btnDDown.BackColor = Color.LimeGreen;
                            // btnBlack.BackColor = Color.LimeGreen;
                            if (cbxEnableVib.Checked == true)
                            {
                                enableVibrator = "true";
                                controller2.SetVibration(new Vibration
                                {
                                    LeftMotorSpeed = 65535,
                                    RightMotorSpeed = 65535
                                });
                            }
                            else
                            {
                                enableVibrator = "false";
                            }

                        }
                        if (state.Gamepad.Buttons.HasFlag(GamepadButtonFlags.DPadLeft))
                        {
                            buttons += "DPadLeft ";
                            btnDLeft.BackColor = Color.LimeGreen;
                            if (cbxEnableVib.Checked == true)
                            {
                                enableVibrator = "true";
                                controller2.SetVibration(new Vibration
                                {
                                    LeftMotorSpeed = 65535,
                                    RightMotorSpeed = 65535
                                });
                            }
                            else
                            {
                                enableVibrator = "false";
                            }

                        }
                        if (state.Gamepad.Buttons.HasFlag(GamepadButtonFlags.DPadRight))
                        {
                            buttons += "DPadRight ";
                            btnDRight.BackColor = Color.LimeGreen;
                            if (cbxEnableVib.Checked == true)
                            {
                                enableVibrator = "true";
                                controller2.SetVibration(new Vibration
                                {
                                    LeftMotorSpeed = 65535,
                                    RightMotorSpeed = 65535
                                });
                            }
                            else
                            {
                                enableVibrator = "false";
                            }

                        }

                    }



                    // Player 3 //// Player 1 //
                    if (controller3.IsConnected)
                    {
                        State state = controller3.GetState();
                        string buttons = "";



                        controller3.SetVibration(new Vibration
                        {
                            LeftMotorSpeed = 0,
                            RightMotorSpeed = 0
                        });


                        // Default states //
                        btnA.BackColor = Color.Transparent;
                        btnB.BackColor = Color.Transparent;
                        btnY.BackColor = Color.Transparent;
                        btnX.BackColor = Color.Transparent;
                        btnLeftBumper.BackColor = Color.Transparent;
                        btnRightBumper.BackColor = Color.Transparent;
                        btnLSClick.BackColor = Color.Transparent;
                        btnRSClick.BackColor = Color.Transparent;
                        btnBlack.BackColor = Color.Transparent;
                        btnWhite.BackColor = Color.Transparent;
                        btnLTrigger.BackColor = Color.Transparent;
                        btnRTrigger.BackColor = Color.Transparent;
                        btnStart.BackColor = Color.Transparent;
                        btnX360Start.BackColor = Color.Transparent;
                        btnXONEStart.BackColor = Color.Transparent;
                        btnXONEBack.BackColor = Color.Transparent;
                        btnX360Back.BackColor = Color.Transparent;
                        btnBack.BackColor = Color.Transparent;
                        btnDUp.BackColor = Color.Transparent;
                        btnDDown.BackColor = Color.Transparent;
                        btnDLeft.BackColor = Color.Transparent;
                        btnDRight.BackColor = Color.Transparent;


                        // Start our checks from here // 


                        Gamepad gamepad = controller3.GetState().Gamepad;


                        LJoystickX = gamepad.LeftThumbX;
                        LJoystickY = gamepad.LeftThumbY;



                        bgwProcessWhileLoopXinput.ReportProgress(LJoystickX, LJoystickY);



                        RJoystickX = gamepad.RightThumbX;
                        RJoystickY = gamepad.RightThumbY;

                        bgwProcessWhileLoopXinput.ReportProgress(RJoystickX, RJoystickY);
                        // Set the rumble of the gamepad using the motor speeds


                        // Get the left trigger position
                        leftTrigger = gamepad.LeftTrigger;
                        // Get the right trigger position
                        rightTrigger = gamepad.RightTrigger;

                        // Set the rumble of the gamepad using the motor speeds

                        bgwProcessWhileLoopXinput.ReportProgress(leftTrigger, rightTrigger);




                        if (cbxEnableVib.Checked == true)
                        {
                            enableVibrator = "true";


                            controller3.SetVibration(new Vibration
                            {
                                LeftMotorSpeed = (ushort)(short)(RJoystickX),
                                RightMotorSpeed = (ushort)(short)(RJoystickY) //32767
                            });


                            // Set the rumble of the gamepad using the motor speeds
                            controller3.SetVibration(new Vibration
                            {
                                LeftMotorSpeed = (ushort)(short)(LJoystickX),
                                RightMotorSpeed = (ushort)(short)(LJoystickY) //32767
                            });

                            controller3.SetVibration(new Vibration
                            {
                                LeftMotorSpeed = (ushort)(short)(leftTrigger * 257),
                                RightMotorSpeed = (ushort)(short)(rightTrigger * 257)
                            });

                        }
                        else
                        {
                            enableVibrator = "false";
                        }



                        if (state.Gamepad.Buttons.HasFlag(GamepadButtonFlags.A))
                        {
                            buttons += "A ";
                            btnA.Invoke((MethodInvoker)delegate
                            {
                                btnA.BackColor = Color.LimeGreen;

                            });

                            if (cbxEnableVib.Checked == true)
                            {
                                enableVibrator = "true";
                                controller3.SetVibration(new Vibration
                                {
                                    LeftMotorSpeed = 65535,
                                    RightMotorSpeed = 65535
                                });
                            }
                            else
                            {
                                enableVibrator = "false";
                            }

                        }
                        if (state.Gamepad.Buttons.HasFlag(GamepadButtonFlags.B))
                        {
                            buttons += "B ";
                            btnB.BackColor = Color.LimeGreen;

                            if (cbxEnableVib.Checked == true)
                            {
                                enableVibrator = "true";
                                controller3.SetVibration(new Vibration
                                {
                                    LeftMotorSpeed = 65535,
                                    RightMotorSpeed = 65535
                                });
                            }
                            else
                            {
                                enableVibrator = "false";
                            }
                        }
                        if (state.Gamepad.Buttons.HasFlag(GamepadButtonFlags.X))
                        {
                            buttons += "X ";
                            btnX.BackColor = Color.LimeGreen;
                            if (cbxEnableVib.Checked == true)
                            {
                                enableVibrator = "true";
                                controller3.SetVibration(new Vibration
                                {
                                    LeftMotorSpeed = 65535,
                                    RightMotorSpeed = 65535
                                });
                            }
                            else
                            {
                                enableVibrator = "false";
                            }
                        }
                        if (state.Gamepad.Buttons.HasFlag(GamepadButtonFlags.Y))
                        {
                            buttons += "Y ";
                            btnY.BackColor = Color.LimeGreen;
                            if (cbxEnableVib.Checked == true)
                            {
                                enableVibrator = "true";
                                controller3.SetVibration(new Vibration
                                {
                                    LeftMotorSpeed = 65535,
                                    RightMotorSpeed = 65535
                                });
                            }
                            else
                            {
                                enableVibrator = "false";
                            }
                        }
                        if (state.Gamepad.Buttons.HasFlag(GamepadButtonFlags.Start))
                        {
                            buttons += "Start ";
                            btnStart.BackColor = Color.LimeGreen;
                            btnX360Start.BackColor = Color.LimeGreen;
                            btnXONEStart.BackColor = Color.LimeGreen;
                            if (cbxEnableVib.Checked == true)
                            {
                                enableVibrator = "true";
                                controller3.SetVibration(new Vibration
                                {
                                    LeftMotorSpeed = 65535,
                                    RightMotorSpeed = 65535
                                });
                            }
                            else
                            {
                                enableVibrator = "false";
                            }
                        }
                        if (state.Gamepad.Buttons.HasFlag(GamepadButtonFlags.Back))
                        {
                            buttons += "Back ";

                            btnXONEBack.BackColor = Color.LimeGreen;
                            btnX360Back.BackColor = Color.LimeGreen;
                            btnBack.BackColor = Color.LimeGreen;
                            if (cbxEnableVib.Checked == true)
                            {
                                enableVibrator = "true";
                                controller3.SetVibration(new Vibration
                                {
                                    LeftMotorSpeed = 65535,
                                    RightMotorSpeed = 65535
                                });
                            }
                            else
                            {
                                enableVibrator = "false";
                            }
                        }
                        if (state.Gamepad.Buttons.HasFlag(GamepadButtonFlags.LeftShoulder))
                        {
                            buttons += "Left Shoulder ";
                            btnLeftBumper.BackColor = Color.LimeGreen;
                            btnWhite.BackColor = Color.LimeGreen;
                            if (cbxEnableVib.Checked == true)
                            {
                                enableVibrator = "true";
                                controller3.SetVibration(new Vibration
                                {
                                    LeftMotorSpeed = 65535,
                                    RightMotorSpeed = 65535
                                });
                            }
                            else
                            {
                                enableVibrator = "false";
                            }
                        }
                        if (state.Gamepad.Buttons.HasFlag(GamepadButtonFlags.RightShoulder))
                        {
                            buttons += "Right Shoulder ";
                            btnRightBumper.BackColor = Color.LimeGreen;
                            btnBlack.BackColor = Color.LimeGreen;
                            if (cbxEnableVib.Checked == true)
                            {
                                enableVibrator = "true";
                                controller3.SetVibration(new Vibration
                                {
                                    LeftMotorSpeed = 65535,
                                    RightMotorSpeed = 65535
                                });
                            }
                            else
                            {
                                enableVibrator = "false";
                            }

                        }
                        if (state.Gamepad.Buttons.HasFlag(GamepadButtonFlags.LeftThumb))
                        {
                            buttons += "Left Thumb ";
                            btnLSClick.BackColor = Color.LimeGreen;
                            if (cbxEnableVib.Checked == true)
                            {
                                enableVibrator = "true";
                                controller3.SetVibration(new Vibration
                                {
                                    LeftMotorSpeed = 65535,
                                    RightMotorSpeed = 65535
                                });
                            }
                            else
                            {
                                enableVibrator = "false";
                            }

                        }
                        if (state.Gamepad.Buttons.HasFlag(GamepadButtonFlags.RightThumb))
                        {
                            buttons += "Right Thumb ";
                            btnRSClick.BackColor = Color.LimeGreen;
                            if (cbxEnableVib.Checked == true)
                            {
                                enableVibrator = "true";
                                controller3.SetVibration(new Vibration
                                {
                                    LeftMotorSpeed = 65535,
                                    RightMotorSpeed = 65535
                                });
                            }
                            else
                            {
                                enableVibrator = "false";
                            }

                        }
                        if (state.Gamepad.Buttons.HasFlag(GamepadButtonFlags.DPadUp))
                        {
                            buttons += "DPadUp ";
                            btnDUp.BackColor = Color.LimeGreen;
                            //btnWhite.BackColor = Color.LimeGreen;
                            if (cbxEnableVib.Checked == true)
                            {
                                enableVibrator = "true";
                                controller3.SetVibration(new Vibration
                                {
                                    LeftMotorSpeed = 65535,
                                    RightMotorSpeed = 65535
                                });
                            }
                            else
                            {
                                enableVibrator = "false";
                            }
                        }
                        if (state.Gamepad.Buttons.HasFlag(GamepadButtonFlags.DPadDown))
                        {
                            buttons += "DPadDown ";
                            btnDDown.BackColor = Color.LimeGreen;
                            // btnBlack.BackColor = Color.LimeGreen;
                            if (cbxEnableVib.Checked == true)
                            {
                                enableVibrator = "true";
                                controller3.SetVibration(new Vibration
                                {
                                    LeftMotorSpeed = 65535,
                                    RightMotorSpeed = 65535
                                });
                            }
                            else
                            {
                                enableVibrator = "false";
                            }

                        }
                        if (state.Gamepad.Buttons.HasFlag(GamepadButtonFlags.DPadLeft))
                        {
                            buttons += "DPadLeft ";
                            btnDLeft.BackColor = Color.LimeGreen;
                            if (cbxEnableVib.Checked == true)
                            {
                                enableVibrator = "true";
                                controller3.SetVibration(new Vibration
                                {
                                    LeftMotorSpeed = 65535,
                                    RightMotorSpeed = 65535
                                });
                            }
                            else
                            {
                                enableVibrator = "false";
                            }

                        }
                        if (state.Gamepad.Buttons.HasFlag(GamepadButtonFlags.DPadRight))
                        {
                            buttons += "DPadRight ";
                            btnDRight.BackColor = Color.LimeGreen;
                            if (cbxEnableVib.Checked == true)
                            {
                                enableVibrator = "true";
                                controller3.SetVibration(new Vibration
                                {
                                    LeftMotorSpeed = 65535,
                                    RightMotorSpeed = 65535
                                });
                            }
                            else
                            {
                                enableVibrator = "false";
                            }

                        }

                    }



                    // Player 4 //// Player 1 //
                    if (controller4.IsConnected)
                    {
                        State state = controller4.GetState();
                        string buttons = "";



                        controller4.SetVibration(new Vibration
                        {
                            LeftMotorSpeed = 0,
                            RightMotorSpeed = 0
                        });


                        // Default states //
                        btnA.BackColor = Color.Transparent;
                        btnB.BackColor = Color.Transparent;
                        btnY.BackColor = Color.Transparent;
                        btnX.BackColor = Color.Transparent;
                        btnLeftBumper.BackColor = Color.Transparent;
                        btnRightBumper.BackColor = Color.Transparent;
                        btnLSClick.BackColor = Color.Transparent;
                        btnRSClick.BackColor = Color.Transparent;
                        btnBlack.BackColor = Color.Transparent;
                        btnWhite.BackColor = Color.Transparent;
                        btnLTrigger.BackColor = Color.Transparent;
                        btnRTrigger.BackColor = Color.Transparent;
                        btnStart.BackColor = Color.Transparent;
                        btnX360Start.BackColor = Color.Transparent;
                        btnXONEStart.BackColor = Color.Transparent;
                        btnXONEBack.BackColor = Color.Transparent;
                        btnX360Back.BackColor = Color.Transparent;
                        btnBack.BackColor = Color.Transparent;
                        btnDUp.BackColor = Color.Transparent;
                        btnDDown.BackColor = Color.Transparent;
                        btnDLeft.BackColor = Color.Transparent;
                        btnDRight.BackColor = Color.Transparent;


                        // Start our checks from here // 


                        Gamepad gamepad = controller4.GetState().Gamepad;


                        LJoystickX = gamepad.LeftThumbX;
                        LJoystickY = gamepad.LeftThumbY;



                        bgwProcessWhileLoopXinput.ReportProgress(LJoystickX, LJoystickY);



                        RJoystickX = gamepad.RightThumbX;
                        RJoystickY = gamepad.RightThumbY;

                        bgwProcessWhileLoopXinput.ReportProgress(RJoystickX, RJoystickY);
                        // Set the rumble of the gamepad using the motor speeds


                        // Get the left trigger position
                        leftTrigger = gamepad.LeftTrigger;
                        // Get the right trigger position
                        rightTrigger = gamepad.RightTrigger;

                        // Set the rumble of the gamepad using the motor speeds

                        bgwProcessWhileLoopXinput.ReportProgress(leftTrigger, rightTrigger);




                        if (cbxEnableVib.Checked == true)
                        {
                            enableVibrator = "true";


                            controller4.SetVibration(new Vibration
                            {
                                LeftMotorSpeed = (ushort)(short)(RJoystickX),
                                RightMotorSpeed = (ushort)(short)(RJoystickY) //32767
                            });


                            // Set the rumble of the gamepad using the motor speeds
                            controller4.SetVibration(new Vibration
                            {
                                LeftMotorSpeed = (ushort)(short)(LJoystickX),
                                RightMotorSpeed = (ushort)(short)(LJoystickY) //32767
                            });

                            controller4.SetVibration(new Vibration
                            {
                                LeftMotorSpeed = (ushort)(short)(leftTrigger * 257),
                                RightMotorSpeed = (ushort)(short)(rightTrigger * 257)
                            });

                        }
                        else
                        {
                            enableVibrator = "false";
                        }



                        if (state.Gamepad.Buttons.HasFlag(GamepadButtonFlags.A))
                        {
                            buttons += "A ";
                            btnA.Invoke((MethodInvoker)delegate
                            {
                                btnA.BackColor = Color.LimeGreen;

                            });

                            if (cbxEnableVib.Checked == true)
                            {
                                enableVibrator = "true";
                                controller4.SetVibration(new Vibration
                                {
                                    LeftMotorSpeed = 65535,
                                    RightMotorSpeed = 65535
                                });
                            }
                            else
                            {
                                enableVibrator = "false";
                            }

                        }
                        if (state.Gamepad.Buttons.HasFlag(GamepadButtonFlags.B))
                        {
                            buttons += "B ";
                            btnB.BackColor = Color.LimeGreen;

                            if (cbxEnableVib.Checked == true)
                            {
                                enableVibrator = "true";
                                controller4.SetVibration(new Vibration
                                {
                                    LeftMotorSpeed = 65535,
                                    RightMotorSpeed = 65535
                                });
                            }
                            else
                            {
                                enableVibrator = "false";
                            }
                        }
                        if (state.Gamepad.Buttons.HasFlag(GamepadButtonFlags.X))
                        {
                            buttons += "X ";
                            btnX.BackColor = Color.LimeGreen;
                            if (cbxEnableVib.Checked == true)
                            {
                                enableVibrator = "true";
                                controller4.SetVibration(new Vibration
                                {
                                    LeftMotorSpeed = 65535,
                                    RightMotorSpeed = 65535
                                });
                            }
                            else
                            {
                                enableVibrator = "false";
                            }
                        }
                        if (state.Gamepad.Buttons.HasFlag(GamepadButtonFlags.Y))
                        {
                            buttons += "Y ";
                            btnY.BackColor = Color.LimeGreen;
                            if (cbxEnableVib.Checked == true)
                            {
                                enableVibrator = "true";
                                controller4.SetVibration(new Vibration
                                {
                                    LeftMotorSpeed = 65535,
                                    RightMotorSpeed = 65535
                                });
                            }
                            else
                            {
                                enableVibrator = "false";
                            }
                        }
                        if (state.Gamepad.Buttons.HasFlag(GamepadButtonFlags.Start))
                        {
                            buttons += "Start ";
                            btnStart.BackColor = Color.LimeGreen;
                            btnX360Start.BackColor = Color.LimeGreen;
                            btnXONEStart.BackColor = Color.LimeGreen;
                            if (cbxEnableVib.Checked == true)
                            {
                                enableVibrator = "true";
                                controller4.SetVibration(new Vibration
                                {
                                    LeftMotorSpeed = 65535,
                                    RightMotorSpeed = 65535
                                });
                            }
                            else
                            {
                                enableVibrator = "false";
                            }
                        }
                        if (state.Gamepad.Buttons.HasFlag(GamepadButtonFlags.Back))
                        {
                            buttons += "Back ";

                            btnXONEBack.BackColor = Color.LimeGreen;
                            btnX360Back.BackColor = Color.LimeGreen;
                            btnBack.BackColor = Color.LimeGreen;
                            if (cbxEnableVib.Checked == true)
                            {
                                enableVibrator = "true";
                                controller4.SetVibration(new Vibration
                                {
                                    LeftMotorSpeed = 65535,
                                    RightMotorSpeed = 65535
                                });
                            }
                            else
                            {
                                enableVibrator = "false";
                            }
                        }
                        if (state.Gamepad.Buttons.HasFlag(GamepadButtonFlags.LeftShoulder))
                        {
                            buttons += "Left Shoulder ";
                            btnLeftBumper.BackColor = Color.LimeGreen;
                            btnWhite.BackColor = Color.LimeGreen;
                            if (cbxEnableVib.Checked == true)
                            {
                                enableVibrator = "true";
                                controller4.SetVibration(new Vibration
                                {
                                    LeftMotorSpeed = 65535,
                                    RightMotorSpeed = 65535
                                });
                            }
                            else
                            {
                                enableVibrator = "false";
                            }
                        }
                        if (state.Gamepad.Buttons.HasFlag(GamepadButtonFlags.RightShoulder))
                        {
                            buttons += "Right Shoulder ";
                            btnRightBumper.BackColor = Color.LimeGreen;
                            btnBlack.BackColor = Color.LimeGreen;
                            if (cbxEnableVib.Checked == true)
                            {
                                enableVibrator = "true";
                                controller4.SetVibration(new Vibration
                                {
                                    LeftMotorSpeed = 65535,
                                    RightMotorSpeed = 65535
                                });
                            }
                            else
                            {
                                enableVibrator = "false";
                            }

                        }
                        if (state.Gamepad.Buttons.HasFlag(GamepadButtonFlags.LeftThumb))
                        {
                            buttons += "Left Thumb ";
                            btnLSClick.BackColor = Color.LimeGreen;
                            if (cbxEnableVib.Checked == true)
                            {
                                enableVibrator = "true";
                                controller4.SetVibration(new Vibration
                                {
                                    LeftMotorSpeed = 65535,
                                    RightMotorSpeed = 65535
                                });
                            }
                            else
                            {
                                enableVibrator = "false";
                            }

                        }
                        if (state.Gamepad.Buttons.HasFlag(GamepadButtonFlags.RightThumb))
                        {
                            buttons += "Right Thumb ";
                            btnRSClick.BackColor = Color.LimeGreen;
                            if (cbxEnableVib.Checked == true)
                            {
                                enableVibrator = "true";
                                controller4.SetVibration(new Vibration
                                {
                                    LeftMotorSpeed = 65535,
                                    RightMotorSpeed = 65535
                                });
                            }
                            else
                            {
                                enableVibrator = "false";
                            }

                        }
                        if (state.Gamepad.Buttons.HasFlag(GamepadButtonFlags.DPadUp))
                        {
                            buttons += "DPadUp ";
                            btnDUp.BackColor = Color.LimeGreen;
                            //btnWhite.BackColor = Color.LimeGreen;
                            if (cbxEnableVib.Checked == true)
                            {
                                enableVibrator = "true";
                                controller4.SetVibration(new Vibration
                                {
                                    LeftMotorSpeed = 65535,
                                    RightMotorSpeed = 65535
                                });
                            }
                            else
                            {
                                enableVibrator = "false";
                            }
                        }
                        if (state.Gamepad.Buttons.HasFlag(GamepadButtonFlags.DPadDown))
                        {
                            buttons += "DPadDown ";
                            btnDDown.BackColor = Color.LimeGreen;
                            // btnBlack.BackColor = Color.LimeGreen;
                            if (cbxEnableVib.Checked == true)
                            {
                                enableVibrator = "true";
                                controller4.SetVibration(new Vibration
                                {
                                    LeftMotorSpeed = 65535,
                                    RightMotorSpeed = 65535
                                });
                            }
                            else
                            {
                                enableVibrator = "false";
                            }

                        }
                        if (state.Gamepad.Buttons.HasFlag(GamepadButtonFlags.DPadLeft))
                        {
                            buttons += "DPadLeft ";
                            btnDLeft.BackColor = Color.LimeGreen;
                            if (cbxEnableVib.Checked == true)
                            {
                                enableVibrator = "true";
                                controller4.SetVibration(new Vibration
                                {
                                    LeftMotorSpeed = 65535,
                                    RightMotorSpeed = 65535
                                });
                            }
                            else
                            {
                                enableVibrator = "false";
                            }

                        }
                        if (state.Gamepad.Buttons.HasFlag(GamepadButtonFlags.DPadRight))
                        {
                            buttons += "DPadRight ";
                            btnDRight.BackColor = Color.LimeGreen;
                            if (cbxEnableVib.Checked == true)
                            {
                                enableVibrator = "true";
                                controller4.SetVibration(new Vibration
                                {
                                    LeftMotorSpeed = 65535,
                                    RightMotorSpeed = 65535
                                });
                            }
                            else
                            {
                                enableVibrator = "false";
                            }

                        }

                    }







                    Thread.Sleep(milliseconds);



                }

            }
            else
            {


                while (cbxTestBtnFdBk.Checked == true)
                {

                    // Refresh();
                    var controller = new Controller(UserIndex.One);
                    var controller2 = new Controller(UserIndex.Two);
                    var controller3 = new Controller(UserIndex.Three);
                    var controller4 = new Controller(UserIndex.Four);


                    // Player 1 //
                    if (controller.IsConnected)
                    {
                        State state = controller.GetState();
                        string buttons = "";




                        controller.SetVibration(new Vibration
                        {
                            LeftMotorSpeed = 0,
                            RightMotorSpeed = 0
                        });


                        // Default states //
                        btnA.BackColor = Color.Transparent;
                        btnB.BackColor = Color.Transparent;
                        btnY.BackColor = Color.Transparent;
                        btnX.BackColor = Color.Transparent;
                        btnLeftBumper.BackColor = Color.Transparent;
                        btnRightBumper.BackColor = Color.Transparent;
                        btnLSClick.BackColor = Color.Transparent;
                        btnRSClick.BackColor = Color.Transparent;
                        btnBlack.BackColor = Color.Transparent;
                        btnWhite.BackColor = Color.Transparent;
                        btnLTrigger.BackColor = Color.Transparent;
                        btnRTrigger.BackColor = Color.Transparent;
                        btnStart.BackColor = Color.Transparent;
                        btnX360Start.BackColor = Color.Transparent;
                        btnXONEStart.BackColor = Color.Transparent;
                        btnXONEBack.BackColor = Color.Transparent;
                        btnX360Back.BackColor = Color.Transparent;
                        btnBack.BackColor = Color.Transparent;
                        btnDUp.BackColor = Color.Transparent;
                        btnDDown.BackColor = Color.Transparent;
                        btnDLeft.BackColor = Color.Transparent;
                        btnDRight.BackColor = Color.Transparent;
                        pbLeftTrigger = 0;
                        pbRightTrigger = 0;
                        btnLTrigger.BackColor = Color.Transparent;
                        btnRTrigger.BackColor = Color.Transparent;


                        // Start our checks from here // 


                        Gamepad gamepad = controller.GetState().Gamepad;


                        LJoystickX = gamepad.LeftThumbX;
                        LJoystickY = gamepad.LeftThumbY;



                        bgwProcessWhileLoopXinput.ReportProgress(LJoystickX, LJoystickY);



                        RJoystickX = gamepad.RightThumbX;
                        RJoystickY = gamepad.RightThumbY;

                        bgwProcessWhileLoopXinput.ReportProgress(RJoystickX, RJoystickY);
                        // Set the rumble of the gamepad using the motor speeds


                        // Get the left trigger position
                        leftTrigger = gamepad.LeftTrigger;
                        // Get the right trigger position
                        rightTrigger = gamepad.RightTrigger;

                        // Set the rumble of the gamepad using the motor speeds

                        bgwProcessWhileLoopXinput.ReportProgress(leftTrigger, rightTrigger);


                        // Get the gamepad object from the controller's current state 
                        // Get the left and right thumbstick positions 

                        short leftThumbstickX = gamepad.LeftThumbX;
                        short leftThumbstickY = gamepad.LeftThumbY;
                        short rightThumbstickX = gamepad.RightThumbX;
                        short rightThumbstickY = gamepad.RightThumbY;

                        // Reduce the movement by adjusting by the deadzone. //
                        string convertStickRatio = txtLStickDeadZ.Text;
                        short numL = short.Parse(convertStickRatio);
                        string convertStickRatio2 = txtRStickDeadZ.Text;
                        short numR = short.Parse(convertStickRatio2);

                        // Scale the thumbstick positions from values between -32768 and 32767 to values between -1 and 1
                        float leftThumbstickXScaled = leftThumbstickX / (32768.0f - numL);
                        float leftThumbstickYScaled = leftThumbstickY / (32768.0f - numL);
                        float rightThumbstickXScaled = rightThumbstickX / (32768.0f - numR);
                        float rightThumbstickYScaled = rightThumbstickY / (32768.0f - numR);


                        int iCrossSize = 3;
                        // Create a bitmap for the graph picture box
                        Bitmap bitmap = new Bitmap(pictureBox1.Width, pictureBox1.Height);


                        // Create the graphics object for the Left Thumbstick //
                        // This helps update in memory instead //
                        using (Graphics g = Graphics.FromImage(bitmap))
                        {
                            // Set the color of the cross
                            Pen pen = new Pen(Color.LimeGreen, iCrossSize);

                            // Calculate the center point of the picture box
                            int pictureBoxCenterX = pictureBox1.Width / 2;
                            int pictureBoxCenterY = pictureBox1.Height / 2;

                            // Calculate the cross position based on the thumbstick positions
                            int crossX = (int)(pictureBoxCenterX + (leftThumbstickXScaled * pictureBoxCenterX));
                            int crossY = (int)(pictureBoxCenterY - (leftThumbstickYScaled * pictureBoxCenterY));

                            // Calculate the dot position based on the thumbstick positions
                            int dotX = (int)(pictureBoxCenterX + (leftThumbstickXScaled * pictureBoxCenterX));
                            int dotY = (int)(pictureBoxCenterY - (leftThumbstickYScaled * pictureBoxCenterY));

                            // Draw the horizontal and vertical lines of the cross
                            g.DrawLine(pen, crossX - 10, crossY, crossX + 10, crossY);
                            g.DrawLine(pen, crossX, crossY - 10, crossX, crossY + 10);
                        }

                        // Create a bitmap for the graph picture box //
                        // This helps update in memory instead //
                        Bitmap bitmap2 = new Bitmap(pictureBox2.Width, pictureBox2.Height);

                        // Create the graphics object for the Right Thumbstick //
                        using (Graphics x = Graphics.FromImage(bitmap2))
                        {
                            // Set the color of the cross
                            Pen pen = new Pen(Color.LimeGreen, iCrossSize);

                            // Calculate the center point of the picture box
                            int pictureBoxCenterX = pictureBox2.Width / 2;
                            int pictureBoxCenterY = pictureBox2.Height / 2;

                            // Calculate the cross position based on the thumbstick positions
                            int crossX = (int)(pictureBoxCenterX + (rightThumbstickXScaled * pictureBoxCenterX));
                            int crossY = (int)(pictureBoxCenterY - (rightThumbstickYScaled * pictureBoxCenterY));

                            // Calculate the dot position based on the thumbstick positions
                            int dotX = (int)(pictureBoxCenterX + (rightThumbstickXScaled * pictureBoxCenterX));
                            int dotY = (int)(pictureBoxCenterY - (rightThumbstickYScaled * pictureBoxCenterY));

                            // Draw the horizontal and vertical lines of the cross
                            x.DrawLine(pen, crossX - 10, crossY, crossX + 10, crossY);
                            x.DrawLine(pen, crossX, crossY - 10, crossX, crossY + 10);

                            // // Draw the dot
                            // x.FillEllipse(null, dotX - 10, dotY - 10, 20, 20);
                            // x.DrawEllipse(pen, dotX - 10, dotY - 10, 20, 20);
                        }

                        // Show the updated information by setting the image each time based on the fps //
                        // Set the image of the picture box to the bitmap
                        pictureBox1.Image = bitmap;

                        // Set the image of the picture box to the bitmap
                        pictureBox2.Image = bitmap2;


                        if (cbxEnableVib.Checked == true)
                        {
                            enableVibrator = "true";

                            // Vibrate the Joysticks based on position data //


                            short leftThumbstickXE = state.Gamepad.LeftThumbX;
                            short leftThumbstickYE = state.Gamepad.LeftThumbY;

                            // Scale the thumbstick positions from values between -32768 and 32767 to values between 0 and 255
                            byte leftThumbstickXScaledE = (byte)((byte)(leftThumbstickXE + 32768) / 2);
                            byte leftThumbstickYScaledE = (byte)((byte)(leftThumbstickYE + 32768) / 2);

                            // Set the back color of the button based on the left thumbstick positions
                            // Color color = Color.FromArgb(leftThumbstickXScaledE, leftThumbstickYScaledE, 0);
                            // button1.BackColor = color;

                            // Set vibration based on color range //
                            controller.SetVibration(new Vibration
                            {
                                LeftMotorSpeed = (ushort)(short)(leftThumbstickXScaledE),
                                RightMotorSpeed = (ushort)(short)(leftThumbstickYScaledE) //32767
                            });



                            // 
                            //  // Set the rumble of the gamepad using the motor speeds
                            //  controller.SetVibration(new Vibration
                            //  {
                            //      LeftMotorSpeed = (ushort)(short)(LJoystickX),
                            //      RightMotorSpeed = (ushort)(short)(LJoystickY) //32767
                            //  });


                            // Vibrate our controller based on Trigger position //
                            pbLeftTrigger = state.Gamepad.LeftTrigger;
                            pbRightTrigger = state.Gamepad.RightTrigger;

                            controller.SetVibration(new Vibration
                            {
                                LeftMotorSpeed = (ushort)(short)(pbLeftTrigger * 257),
                                RightMotorSpeed = (ushort)(short)(pbRightTrigger * 257)
                            });


                        }
                        else
                        {
                            enableVibrator = "false";


                            controller.SetVibration(new Vibration
                            {
                                LeftMotorSpeed = 0,
                                RightMotorSpeed = 0
                            });


                        }


                        // Swap colors by subtracting //
                        int iLT = 255 - leftTrigger;
                        int iRT = 255 - rightTrigger;

                        // Set the back color of the button based on the left trigger pressure
                        Color colorLT = Color.FromArgb(leftTrigger, iLT, 0);
                        btnLTrigger.BackColor = colorLT;

                        // Set the back color of the button based on the left trigger pressure
                        Color colorRT = Color.FromArgb(rightTrigger, iRT, 0);
                        btnRTrigger.BackColor = colorRT;


                        if (state.Gamepad.Buttons.HasFlag(GamepadButtonFlags.A))
                        {
                            buttons += "A ";
                            btnA.Invoke((MethodInvoker)delegate
                            {
                                btnA.BackColor = Color.LimeGreen;

                            });

                            if (cbxEnableVib.Checked == true)
                            {
                                enableVibrator = "true";
                                controller.SetVibration(new Vibration
                                {
                                    LeftMotorSpeed = 65535,
                                    RightMotorSpeed = 65535
                                });
                            }
                            else
                            {
                                enableVibrator = "false";
                            }

                        }
                        if (state.Gamepad.Buttons.HasFlag(GamepadButtonFlags.B))
                        {
                            buttons += "B ";
                            btnB.BackColor = Color.LimeGreen;

                            if (cbxEnableVib.Checked == true)
                            {
                                enableVibrator = "true";
                                controller.SetVibration(new Vibration
                                {
                                    LeftMotorSpeed = 65535,
                                    RightMotorSpeed = 65535
                                });
                            }
                            else
                            {
                                enableVibrator = "false";
                            }
                        }
                        if (state.Gamepad.Buttons.HasFlag(GamepadButtonFlags.X))
                        {
                            buttons += "X ";
                            btnX.BackColor = Color.LimeGreen;
                            if (cbxEnableVib.Checked == true)
                            {
                                enableVibrator = "true";
                                controller.SetVibration(new Vibration
                                {
                                    LeftMotorSpeed = 65535,
                                    RightMotorSpeed = 65535
                                });
                            }
                            else
                            {
                                enableVibrator = "false";
                            }
                        }
                        if (state.Gamepad.Buttons.HasFlag(GamepadButtonFlags.Y))
                        {
                            buttons += "Y ";
                            btnY.BackColor = Color.LimeGreen;
                            if (cbxEnableVib.Checked == true)
                            {
                                enableVibrator = "true";
                                controller.SetVibration(new Vibration
                                {
                                    LeftMotorSpeed = 65535,
                                    RightMotorSpeed = 65535
                                });
                            }
                            else
                            {
                                enableVibrator = "false";
                            }
                        }
                        if (state.Gamepad.Buttons.HasFlag(GamepadButtonFlags.Start))
                        {
                            buttons += "Start ";
                            btnStart.BackColor = Color.LimeGreen;
                            btnX360Start.BackColor = Color.LimeGreen;
                            btnXONEStart.BackColor = Color.LimeGreen;
                            if (cbxEnableVib.Checked == true)
                            {
                                enableVibrator = "true";
                                controller.SetVibration(new Vibration
                                {
                                    LeftMotorSpeed = 65535,
                                    RightMotorSpeed = 65535
                                });
                            }
                            else
                            {
                                enableVibrator = "false";
                            }
                        }
                        if (state.Gamepad.Buttons.HasFlag(GamepadButtonFlags.Back))
                        {
                            buttons += "Back ";

                            btnXONEBack.BackColor = Color.LimeGreen;
                            btnX360Back.BackColor = Color.LimeGreen;
                            btnBack.BackColor = Color.LimeGreen;
                            if (cbxEnableVib.Checked == true)
                            {
                                enableVibrator = "true";
                                controller.SetVibration(new Vibration
                                {
                                    LeftMotorSpeed = 65535,
                                    RightMotorSpeed = 65535
                                });
                            }
                            else
                            {
                                enableVibrator = "false";
                            }
                        }
                        if (state.Gamepad.Buttons.HasFlag(GamepadButtonFlags.LeftShoulder))
                        {
                            buttons += "Left Shoulder ";
                            btnLeftBumper.BackColor = Color.LimeGreen;
                            btnWhite.BackColor = Color.LimeGreen;
                            if (cbxEnableVib.Checked == true)
                            {
                                enableVibrator = "true";
                                controller.SetVibration(new Vibration
                                {
                                    LeftMotorSpeed = 65535,
                                    RightMotorSpeed = 65535
                                });
                            }
                            else
                            {
                                enableVibrator = "false";
                            }
                        }
                        if (state.Gamepad.Buttons.HasFlag(GamepadButtonFlags.RightShoulder))
                        {
                            buttons += "Right Shoulder ";
                            btnRightBumper.BackColor = Color.LimeGreen;
                            btnBlack.BackColor = Color.LimeGreen;
                            if (cbxEnableVib.Checked == true)
                            {
                                enableVibrator = "true";
                                controller.SetVibration(new Vibration
                                {
                                    LeftMotorSpeed = 65535,
                                    RightMotorSpeed = 65535
                                });
                            }
                            else
                            {
                                enableVibrator = "false";
                            }

                        }
                        if (state.Gamepad.Buttons.HasFlag(GamepadButtonFlags.LeftThumb))
                        {
                            buttons += "Left Thumb ";
                            btnLSClick.BackColor = Color.LimeGreen;
                            if (cbxEnableVib.Checked == true)
                            {
                                enableVibrator = "true";
                                controller.SetVibration(new Vibration
                                {
                                    LeftMotorSpeed = 65535,
                                    RightMotorSpeed = 65535
                                });
                            }
                            else
                            {
                                enableVibrator = "false";
                            }

                        }
                        if (state.Gamepad.Buttons.HasFlag(GamepadButtonFlags.RightThumb))
                        {
                            buttons += "Right Thumb ";
                            btnRSClick.BackColor = Color.LimeGreen;
                            if (cbxEnableVib.Checked == true)
                            {
                                enableVibrator = "true";
                                controller.SetVibration(new Vibration
                                {
                                    LeftMotorSpeed = 65535,
                                    RightMotorSpeed = 65535
                                });
                            }
                            else
                            {
                                enableVibrator = "false";
                            }

                        }
                        if (state.Gamepad.Buttons.HasFlag(GamepadButtonFlags.DPadUp))
                        {
                            buttons += "DPadUp ";
                            btnDUp.BackColor = Color.LimeGreen;
                            //btnWhite.BackColor = Color.LimeGreen;
                            if (cbxEnableVib.Checked == true)
                            {
                                enableVibrator = "true";
                                controller.SetVibration(new Vibration
                                {
                                    LeftMotorSpeed = 65535,
                                    RightMotorSpeed = 65535
                                });
                            }
                            else
                            {
                                enableVibrator = "false";
                            }
                        }
                        if (state.Gamepad.Buttons.HasFlag(GamepadButtonFlags.DPadDown))
                        {
                            buttons += "DPadDown ";
                            btnDDown.BackColor = Color.LimeGreen;
                            // btnBlack.BackColor = Color.LimeGreen;
                            if (cbxEnableVib.Checked == true)
                            {
                                enableVibrator = "true";
                                controller.SetVibration(new Vibration
                                {
                                    LeftMotorSpeed = 65535,
                                    RightMotorSpeed = 65535
                                });
                            }
                            else
                            {
                                enableVibrator = "false";
                            }

                        }
                        if (state.Gamepad.Buttons.HasFlag(GamepadButtonFlags.DPadLeft))
                        {
                            buttons += "DPadLeft ";
                            btnDLeft.BackColor = Color.LimeGreen;
                            if (cbxEnableVib.Checked == true)
                            {
                                enableVibrator = "true";
                                controller.SetVibration(new Vibration
                                {
                                    LeftMotorSpeed = 65535,
                                    RightMotorSpeed = 65535
                                });
                            }
                            else
                            {
                                enableVibrator = "false";
                            }

                        }
                        if (state.Gamepad.Buttons.HasFlag(GamepadButtonFlags.DPadRight))
                        {
                            buttons += "DPadRight ";
                            btnDRight.BackColor = Color.LimeGreen;
                            if (cbxEnableVib.Checked == true)
                            {
                                enableVibrator = "true";
                                controller.SetVibration(new Vibration
                                {
                                    LeftMotorSpeed = 65535,
                                    RightMotorSpeed = 65535
                                });
                            }
                            else
                            {
                                enableVibrator = "false";
                            }

                        }





                        ///     label1.Lo 



                    }

                    // Player 2 //// Player 1 //
                    if (controller2.IsConnected)
                    {
                        State state = controller2.GetState();
                        string buttons = "";



                        controller2.SetVibration(new Vibration
                        {
                            LeftMotorSpeed = 0,
                            RightMotorSpeed = 0
                        });


                        // Default states //
                        btnA.BackColor = Color.Transparent;
                        btnB.BackColor = Color.Transparent;
                        btnY.BackColor = Color.Transparent;
                        btnX.BackColor = Color.Transparent;
                        btnLeftBumper.BackColor = Color.Transparent;
                        btnRightBumper.BackColor = Color.Transparent;
                        btnLSClick.BackColor = Color.Transparent;
                        btnRSClick.BackColor = Color.Transparent;
                        btnBlack.BackColor = Color.Transparent;
                        btnWhite.BackColor = Color.Transparent;
                        btnLTrigger.BackColor = Color.Transparent;
                        btnRTrigger.BackColor = Color.Transparent;
                        btnStart.BackColor = Color.Transparent;
                        btnX360Start.BackColor = Color.Transparent;
                        btnXONEStart.BackColor = Color.Transparent;
                        btnXONEBack.BackColor = Color.Transparent;
                        btnX360Back.BackColor = Color.Transparent;
                        btnBack.BackColor = Color.Transparent;
                        btnDUp.BackColor = Color.Transparent;
                        btnDDown.BackColor = Color.Transparent;
                        btnDLeft.BackColor = Color.Transparent;
                        btnDRight.BackColor = Color.Transparent;


                        // Start our checks from here // 


                        Gamepad gamepad = controller2.GetState().Gamepad;


                        LJoystickX = gamepad.LeftThumbX;
                        LJoystickY = gamepad.LeftThumbY;



                        bgwProcessWhileLoopXinput.ReportProgress(LJoystickX, LJoystickY);



                        RJoystickX = gamepad.RightThumbX;
                        RJoystickY = gamepad.RightThumbY;

                        bgwProcessWhileLoopXinput.ReportProgress(RJoystickX, RJoystickY);
                        // Set the rumble of the gamepad using the motor speeds


                        // Get the left trigger position
                        leftTrigger = gamepad.LeftTrigger;
                        // Get the right trigger position
                        rightTrigger = gamepad.RightTrigger;

                        // Set the rumble of the gamepad using the motor speeds

                        bgwProcessWhileLoopXinput.ReportProgress(leftTrigger, rightTrigger);




                        if (cbxEnableVib.Checked == true)
                        {
                            enableVibrator = "true";


                            controller2.SetVibration(new Vibration
                            {
                                LeftMotorSpeed = (ushort)(short)(RJoystickX),
                                RightMotorSpeed = (ushort)(short)(RJoystickY) //32767
                            });


                            // Set the rumble of the gamepad using the motor speeds
                            controller2.SetVibration(new Vibration
                            {
                                LeftMotorSpeed = (ushort)(short)(LJoystickX),
                                RightMotorSpeed = (ushort)(short)(LJoystickY) //32767
                            });

                            controller2.SetVibration(new Vibration
                            {
                                LeftMotorSpeed = (ushort)(short)(leftTrigger * 257),
                                RightMotorSpeed = (ushort)(short)(rightTrigger * 257)
                            });

                        }
                        else
                        {
                            enableVibrator = "false";
                        }



                        if (state.Gamepad.Buttons.HasFlag(GamepadButtonFlags.A))
                        {
                            buttons += "A ";
                            btnA.Invoke((MethodInvoker)delegate
                            {
                                btnA.BackColor = Color.LimeGreen;

                            });

                            if (cbxEnableVib.Checked == true)
                            {
                                enableVibrator = "true";
                                controller2.SetVibration(new Vibration
                                {
                                    LeftMotorSpeed = 65535,
                                    RightMotorSpeed = 65535
                                });
                            }
                            else
                            {
                                enableVibrator = "false";
                            }

                        }
                        if (state.Gamepad.Buttons.HasFlag(GamepadButtonFlags.B))
                        {
                            buttons += "B ";
                            btnB.BackColor = Color.LimeGreen;

                            if (cbxEnableVib.Checked == true)
                            {
                                enableVibrator = "true";
                                controller2.SetVibration(new Vibration
                                {
                                    LeftMotorSpeed = 65535,
                                    RightMotorSpeed = 65535
                                });
                            }
                            else
                            {
                                enableVibrator = "false";
                            }
                        }
                        if (state.Gamepad.Buttons.HasFlag(GamepadButtonFlags.X))
                        {
                            buttons += "X ";
                            btnX.BackColor = Color.LimeGreen;
                            if (cbxEnableVib.Checked == true)
                            {
                                enableVibrator = "true";
                                controller2.SetVibration(new Vibration
                                {
                                    LeftMotorSpeed = 65535,
                                    RightMotorSpeed = 65535
                                });
                            }
                            else
                            {
                                enableVibrator = "false";
                            }
                        }
                        if (state.Gamepad.Buttons.HasFlag(GamepadButtonFlags.Y))
                        {
                            buttons += "Y ";
                            btnY.BackColor = Color.LimeGreen;
                            if (cbxEnableVib.Checked == true)
                            {
                                enableVibrator = "true";
                                controller2.SetVibration(new Vibration
                                {
                                    LeftMotorSpeed = 65535,
                                    RightMotorSpeed = 65535
                                });
                            }
                            else
                            {
                                enableVibrator = "false";
                            }
                        }
                        if (state.Gamepad.Buttons.HasFlag(GamepadButtonFlags.Start))
                        {
                            buttons += "Start ";
                            btnStart.BackColor = Color.LimeGreen;
                            btnX360Start.BackColor = Color.LimeGreen;
                            btnXONEStart.BackColor = Color.LimeGreen;
                            if (cbxEnableVib.Checked == true)
                            {
                                enableVibrator = "true";
                                controller2.SetVibration(new Vibration
                                {
                                    LeftMotorSpeed = 65535,
                                    RightMotorSpeed = 65535
                                });
                            }
                            else
                            {
                                enableVibrator = "false";
                            }
                        }
                        if (state.Gamepad.Buttons.HasFlag(GamepadButtonFlags.Back))
                        {
                            buttons += "Back ";

                            btnXONEBack.BackColor = Color.LimeGreen;
                            btnX360Back.BackColor = Color.LimeGreen;
                            btnBack.BackColor = Color.LimeGreen;
                            if (cbxEnableVib.Checked == true)
                            {
                                enableVibrator = "true";
                                controller2.SetVibration(new Vibration
                                {
                                    LeftMotorSpeed = 65535,
                                    RightMotorSpeed = 65535
                                });
                            }
                            else
                            {
                                enableVibrator = "false";
                            }
                        }
                        if (state.Gamepad.Buttons.HasFlag(GamepadButtonFlags.LeftShoulder))
                        {
                            buttons += "Left Shoulder ";
                            btnLeftBumper.BackColor = Color.LimeGreen;
                            btnWhite.BackColor = Color.LimeGreen;
                            if (cbxEnableVib.Checked == true)
                            {
                                enableVibrator = "true";
                                controller2.SetVibration(new Vibration
                                {
                                    LeftMotorSpeed = 65535,
                                    RightMotorSpeed = 65535
                                });
                            }
                            else
                            {
                                enableVibrator = "false";
                            }
                        }
                        if (state.Gamepad.Buttons.HasFlag(GamepadButtonFlags.RightShoulder))
                        {
                            buttons += "Right Shoulder ";
                            btnRightBumper.BackColor = Color.LimeGreen;
                            btnBlack.BackColor = Color.LimeGreen;
                            if (cbxEnableVib.Checked == true)
                            {
                                enableVibrator = "true";
                                controller2.SetVibration(new Vibration
                                {
                                    LeftMotorSpeed = 65535,
                                    RightMotorSpeed = 65535
                                });
                            }
                            else
                            {
                                enableVibrator = "false";
                            }

                        }
                        if (state.Gamepad.Buttons.HasFlag(GamepadButtonFlags.LeftThumb))
                        {
                            buttons += "Left Thumb ";
                            btnLSClick.BackColor = Color.LimeGreen;
                            if (cbxEnableVib.Checked == true)
                            {
                                enableVibrator = "true";
                                controller2.SetVibration(new Vibration
                                {
                                    LeftMotorSpeed = 65535,
                                    RightMotorSpeed = 65535
                                });
                            }
                            else
                            {
                                enableVibrator = "false";
                            }

                        }
                        if (state.Gamepad.Buttons.HasFlag(GamepadButtonFlags.RightThumb))
                        {
                            buttons += "Right Thumb ";
                            btnRSClick.BackColor = Color.LimeGreen;
                            if (cbxEnableVib.Checked == true)
                            {
                                enableVibrator = "true";
                                controller2.SetVibration(new Vibration
                                {
                                    LeftMotorSpeed = 65535,
                                    RightMotorSpeed = 65535
                                });
                            }
                            else
                            {
                                enableVibrator = "false";
                            }

                        }
                        if (state.Gamepad.Buttons.HasFlag(GamepadButtonFlags.DPadUp))
                        {
                            buttons += "DPadUp ";
                            btnDUp.BackColor = Color.LimeGreen;
                            //btnWhite.BackColor = Color.LimeGreen;
                            if (cbxEnableVib.Checked == true)
                            {
                                enableVibrator = "true";
                                controller2.SetVibration(new Vibration
                                {
                                    LeftMotorSpeed = 65535,
                                    RightMotorSpeed = 65535
                                });
                            }
                            else
                            {
                                enableVibrator = "false";
                            }
                        }
                        if (state.Gamepad.Buttons.HasFlag(GamepadButtonFlags.DPadDown))
                        {
                            buttons += "DPadDown ";
                            btnDDown.BackColor = Color.LimeGreen;
                            // btnBlack.BackColor = Color.LimeGreen;
                            if (cbxEnableVib.Checked == true)
                            {
                                enableVibrator = "true";
                                controller2.SetVibration(new Vibration
                                {
                                    LeftMotorSpeed = 65535,
                                    RightMotorSpeed = 65535
                                });
                            }
                            else
                            {
                                enableVibrator = "false";
                            }

                        }
                        if (state.Gamepad.Buttons.HasFlag(GamepadButtonFlags.DPadLeft))
                        {
                            buttons += "DPadLeft ";
                            btnDLeft.BackColor = Color.LimeGreen;
                            if (cbxEnableVib.Checked == true)
                            {
                                enableVibrator = "true";
                                controller2.SetVibration(new Vibration
                                {
                                    LeftMotorSpeed = 65535,
                                    RightMotorSpeed = 65535
                                });
                            }
                            else
                            {
                                enableVibrator = "false";
                            }

                        }
                        if (state.Gamepad.Buttons.HasFlag(GamepadButtonFlags.DPadRight))
                        {
                            buttons += "DPadRight ";
                            btnDRight.BackColor = Color.LimeGreen;
                            if (cbxEnableVib.Checked == true)
                            {
                                enableVibrator = "true";
                                controller2.SetVibration(new Vibration
                                {
                                    LeftMotorSpeed = 65535,
                                    RightMotorSpeed = 65535
                                });
                            }
                            else
                            {
                                enableVibrator = "false";
                            }

                        }

                    }



                    // Player 3 //// Player 1 //
                    if (controller3.IsConnected)
                    {
                        State state = controller3.GetState();
                        string buttons = "";



                        controller3.SetVibration(new Vibration
                        {
                            LeftMotorSpeed = 0,
                            RightMotorSpeed = 0
                        });


                        // Default states //
                        btnA.BackColor = Color.Transparent;
                        btnB.BackColor = Color.Transparent;
                        btnY.BackColor = Color.Transparent;
                        btnX.BackColor = Color.Transparent;
                        btnLeftBumper.BackColor = Color.Transparent;
                        btnRightBumper.BackColor = Color.Transparent;
                        btnLSClick.BackColor = Color.Transparent;
                        btnRSClick.BackColor = Color.Transparent;
                        btnBlack.BackColor = Color.Transparent;
                        btnWhite.BackColor = Color.Transparent;
                        btnLTrigger.BackColor = Color.Transparent;
                        btnRTrigger.BackColor = Color.Transparent;
                        btnStart.BackColor = Color.Transparent;
                        btnX360Start.BackColor = Color.Transparent;
                        btnXONEStart.BackColor = Color.Transparent;
                        btnXONEBack.BackColor = Color.Transparent;
                        btnX360Back.BackColor = Color.Transparent;
                        btnBack.BackColor = Color.Transparent;
                        btnDUp.BackColor = Color.Transparent;
                        btnDDown.BackColor = Color.Transparent;
                        btnDLeft.BackColor = Color.Transparent;
                        btnDRight.BackColor = Color.Transparent;


                        // Start our checks from here // 


                        Gamepad gamepad = controller3.GetState().Gamepad;


                        LJoystickX = gamepad.LeftThumbX;
                        LJoystickY = gamepad.LeftThumbY;



                        bgwProcessWhileLoopXinput.ReportProgress(LJoystickX, LJoystickY);



                        RJoystickX = gamepad.RightThumbX;
                        RJoystickY = gamepad.RightThumbY;

                        bgwProcessWhileLoopXinput.ReportProgress(RJoystickX, RJoystickY);
                        // Set the rumble of the gamepad using the motor speeds


                        // Get the left trigger position
                        leftTrigger = gamepad.LeftTrigger;
                        // Get the right trigger position
                        rightTrigger = gamepad.RightTrigger;

                        // Set the rumble of the gamepad using the motor speeds

                        bgwProcessWhileLoopXinput.ReportProgress(leftTrigger, rightTrigger);




                        if (cbxEnableVib.Checked == true)
                        {
                            enableVibrator = "true";


                            controller3.SetVibration(new Vibration
                            {
                                LeftMotorSpeed = (ushort)(short)(RJoystickX),
                                RightMotorSpeed = (ushort)(short)(RJoystickY) //32767
                            });


                            // Set the rumble of the gamepad using the motor speeds
                            controller3.SetVibration(new Vibration
                            {
                                LeftMotorSpeed = (ushort)(short)(LJoystickX),
                                RightMotorSpeed = (ushort)(short)(LJoystickY) //32767
                            });

                            controller3.SetVibration(new Vibration
                            {
                                LeftMotorSpeed = (ushort)(short)(leftTrigger * 257),
                                RightMotorSpeed = (ushort)(short)(rightTrigger * 257)
                            });

                        }
                        else
                        {
                            enableVibrator = "false";
                        }



                        if (state.Gamepad.Buttons.HasFlag(GamepadButtonFlags.A))
                        {
                            buttons += "A ";
                            btnA.Invoke((MethodInvoker)delegate
                            {
                                btnA.BackColor = Color.LimeGreen;

                            });

                            if (cbxEnableVib.Checked == true)
                            {
                                enableVibrator = "true";
                                controller3.SetVibration(new Vibration
                                {
                                    LeftMotorSpeed = 65535,
                                    RightMotorSpeed = 65535
                                });
                            }
                            else
                            {
                                enableVibrator = "false";
                            }

                        }
                        if (state.Gamepad.Buttons.HasFlag(GamepadButtonFlags.B))
                        {
                            buttons += "B ";
                            btnB.BackColor = Color.LimeGreen;

                            if (cbxEnableVib.Checked == true)
                            {
                                enableVibrator = "true";
                                controller3.SetVibration(new Vibration
                                {
                                    LeftMotorSpeed = 65535,
                                    RightMotorSpeed = 65535
                                });
                            }
                            else
                            {
                                enableVibrator = "false";
                            }
                        }
                        if (state.Gamepad.Buttons.HasFlag(GamepadButtonFlags.X))
                        {
                            buttons += "X ";
                            btnX.BackColor = Color.LimeGreen;
                            if (cbxEnableVib.Checked == true)
                            {
                                enableVibrator = "true";
                                controller3.SetVibration(new Vibration
                                {
                                    LeftMotorSpeed = 65535,
                                    RightMotorSpeed = 65535
                                });
                            }
                            else
                            {
                                enableVibrator = "false";
                            }
                        }
                        if (state.Gamepad.Buttons.HasFlag(GamepadButtonFlags.Y))
                        {
                            buttons += "Y ";
                            btnY.BackColor = Color.LimeGreen;
                            if (cbxEnableVib.Checked == true)
                            {
                                enableVibrator = "true";
                                controller3.SetVibration(new Vibration
                                {
                                    LeftMotorSpeed = 65535,
                                    RightMotorSpeed = 65535
                                });
                            }
                            else
                            {
                                enableVibrator = "false";
                            }
                        }
                        if (state.Gamepad.Buttons.HasFlag(GamepadButtonFlags.Start))
                        {
                            buttons += "Start ";
                            btnStart.BackColor = Color.LimeGreen;
                            btnX360Start.BackColor = Color.LimeGreen;
                            btnXONEStart.BackColor = Color.LimeGreen;
                            if (cbxEnableVib.Checked == true)
                            {
                                enableVibrator = "true";
                                controller3.SetVibration(new Vibration
                                {
                                    LeftMotorSpeed = 65535,
                                    RightMotorSpeed = 65535
                                });
                            }
                            else
                            {
                                enableVibrator = "false";
                            }
                        }
                        if (state.Gamepad.Buttons.HasFlag(GamepadButtonFlags.Back))
                        {
                            buttons += "Back ";

                            btnXONEBack.BackColor = Color.LimeGreen;
                            btnX360Back.BackColor = Color.LimeGreen;
                            btnBack.BackColor = Color.LimeGreen;
                            if (cbxEnableVib.Checked == true)
                            {
                                enableVibrator = "true";
                                controller3.SetVibration(new Vibration
                                {
                                    LeftMotorSpeed = 65535,
                                    RightMotorSpeed = 65535
                                });
                            }
                            else
                            {
                                enableVibrator = "false";
                            }
                        }
                        if (state.Gamepad.Buttons.HasFlag(GamepadButtonFlags.LeftShoulder))
                        {
                            buttons += "Left Shoulder ";
                            btnLeftBumper.BackColor = Color.LimeGreen;
                            btnWhite.BackColor = Color.LimeGreen;
                            if (cbxEnableVib.Checked == true)
                            {
                                enableVibrator = "true";
                                controller3.SetVibration(new Vibration
                                {
                                    LeftMotorSpeed = 65535,
                                    RightMotorSpeed = 65535
                                });
                            }
                            else
                            {
                                enableVibrator = "false";
                            }
                        }
                        if (state.Gamepad.Buttons.HasFlag(GamepadButtonFlags.RightShoulder))
                        {
                            buttons += "Right Shoulder ";
                            btnRightBumper.BackColor = Color.LimeGreen;
                            btnBlack.BackColor = Color.LimeGreen;
                            if (cbxEnableVib.Checked == true)
                            {
                                enableVibrator = "true";
                                controller3.SetVibration(new Vibration
                                {
                                    LeftMotorSpeed = 65535,
                                    RightMotorSpeed = 65535
                                });
                            }
                            else
                            {
                                enableVibrator = "false";
                            }

                        }
                        if (state.Gamepad.Buttons.HasFlag(GamepadButtonFlags.LeftThumb))
                        {
                            buttons += "Left Thumb ";
                            btnLSClick.BackColor = Color.LimeGreen;
                            if (cbxEnableVib.Checked == true)
                            {
                                enableVibrator = "true";
                                controller3.SetVibration(new Vibration
                                {
                                    LeftMotorSpeed = 65535,
                                    RightMotorSpeed = 65535
                                });
                            }
                            else
                            {
                                enableVibrator = "false";
                            }

                        }
                        if (state.Gamepad.Buttons.HasFlag(GamepadButtonFlags.RightThumb))
                        {
                            buttons += "Right Thumb ";
                            btnRSClick.BackColor = Color.LimeGreen;
                            if (cbxEnableVib.Checked == true)
                            {
                                enableVibrator = "true";
                                controller3.SetVibration(new Vibration
                                {
                                    LeftMotorSpeed = 65535,
                                    RightMotorSpeed = 65535
                                });
                            }
                            else
                            {
                                enableVibrator = "false";
                            }

                        }
                        if (state.Gamepad.Buttons.HasFlag(GamepadButtonFlags.DPadUp))
                        {
                            buttons += "DPadUp ";
                            btnDUp.BackColor = Color.LimeGreen;
                            //btnWhite.BackColor = Color.LimeGreen;
                            if (cbxEnableVib.Checked == true)
                            {
                                enableVibrator = "true";
                                controller3.SetVibration(new Vibration
                                {
                                    LeftMotorSpeed = 65535,
                                    RightMotorSpeed = 65535
                                });
                            }
                            else
                            {
                                enableVibrator = "false";
                            }
                        }
                        if (state.Gamepad.Buttons.HasFlag(GamepadButtonFlags.DPadDown))
                        {
                            buttons += "DPadDown ";
                            btnDDown.BackColor = Color.LimeGreen;
                            // btnBlack.BackColor = Color.LimeGreen;
                            if (cbxEnableVib.Checked == true)
                            {
                                enableVibrator = "true";
                                controller3.SetVibration(new Vibration
                                {
                                    LeftMotorSpeed = 65535,
                                    RightMotorSpeed = 65535
                                });
                            }
                            else
                            {
                                enableVibrator = "false";
                            }

                        }
                        if (state.Gamepad.Buttons.HasFlag(GamepadButtonFlags.DPadLeft))
                        {
                            buttons += "DPadLeft ";
                            btnDLeft.BackColor = Color.LimeGreen;
                            if (cbxEnableVib.Checked == true)
                            {
                                enableVibrator = "true";
                                controller3.SetVibration(new Vibration
                                {
                                    LeftMotorSpeed = 65535,
                                    RightMotorSpeed = 65535
                                });
                            }
                            else
                            {
                                enableVibrator = "false";
                            }

                        }
                        if (state.Gamepad.Buttons.HasFlag(GamepadButtonFlags.DPadRight))
                        {
                            buttons += "DPadRight ";
                            btnDRight.BackColor = Color.LimeGreen;
                            if (cbxEnableVib.Checked == true)
                            {
                                enableVibrator = "true";
                                controller3.SetVibration(new Vibration
                                {
                                    LeftMotorSpeed = 65535,
                                    RightMotorSpeed = 65535
                                });
                            }
                            else
                            {
                                enableVibrator = "false";
                            }

                        }

                    }



                    // Player 4 //// Player 1 //
                    if (controller4.IsConnected)
                    {
                        State state = controller4.GetState();
                        string buttons = "";



                        controller4.SetVibration(new Vibration
                        {
                            LeftMotorSpeed = 0,
                            RightMotorSpeed = 0
                        });


                        // Default states //
                        btnA.BackColor = Color.Transparent;
                        btnB.BackColor = Color.Transparent;
                        btnY.BackColor = Color.Transparent;
                        btnX.BackColor = Color.Transparent;
                        btnLeftBumper.BackColor = Color.Transparent;
                        btnRightBumper.BackColor = Color.Transparent;
                        btnLSClick.BackColor = Color.Transparent;
                        btnRSClick.BackColor = Color.Transparent;
                        btnBlack.BackColor = Color.Transparent;
                        btnWhite.BackColor = Color.Transparent;
                        btnLTrigger.BackColor = Color.Transparent;
                        btnRTrigger.BackColor = Color.Transparent;
                        btnStart.BackColor = Color.Transparent;
                        btnX360Start.BackColor = Color.Transparent;
                        btnXONEStart.BackColor = Color.Transparent;
                        btnXONEBack.BackColor = Color.Transparent;
                        btnX360Back.BackColor = Color.Transparent;
                        btnBack.BackColor = Color.Transparent;
                        btnDUp.BackColor = Color.Transparent;
                        btnDDown.BackColor = Color.Transparent;
                        btnDLeft.BackColor = Color.Transparent;
                        btnDRight.BackColor = Color.Transparent;


                        // Start our checks from here // 


                        Gamepad gamepad = controller4.GetState().Gamepad;


                        LJoystickX = gamepad.LeftThumbX;
                        LJoystickY = gamepad.LeftThumbY;



                        bgwProcessWhileLoopXinput.ReportProgress(LJoystickX, LJoystickY);



                        RJoystickX = gamepad.RightThumbX;
                        RJoystickY = gamepad.RightThumbY;

                        bgwProcessWhileLoopXinput.ReportProgress(RJoystickX, RJoystickY);
                        // Set the rumble of the gamepad using the motor speeds


                        // Get the left trigger position
                        leftTrigger = gamepad.LeftTrigger;
                        // Get the right trigger position
                        rightTrigger = gamepad.RightTrigger;

                        // Set the rumble of the gamepad using the motor speeds

                        bgwProcessWhileLoopXinput.ReportProgress(leftTrigger, rightTrigger);




                        if (cbxEnableVib.Checked == true)
                        {
                            enableVibrator = "true";


                            controller4.SetVibration(new Vibration
                            {
                                LeftMotorSpeed = (ushort)(short)(RJoystickX),
                                RightMotorSpeed = (ushort)(short)(RJoystickY) //32767
                            });


                            // Set the rumble of the gamepad using the motor speeds
                            controller4.SetVibration(new Vibration
                            {
                                LeftMotorSpeed = (ushort)(short)(LJoystickX),
                                RightMotorSpeed = (ushort)(short)(LJoystickY) //32767
                            });

                            controller4.SetVibration(new Vibration
                            {
                                LeftMotorSpeed = (ushort)(short)(leftTrigger * 257),
                                RightMotorSpeed = (ushort)(short)(rightTrigger * 257)
                            });

                        }
                        else
                        {
                            enableVibrator = "false";
                        }



                        if (state.Gamepad.Buttons.HasFlag(GamepadButtonFlags.A))
                        {
                            buttons += "A ";
                            btnA.Invoke((MethodInvoker)delegate
                            {
                                btnA.BackColor = Color.LimeGreen;

                            });

                            if (cbxEnableVib.Checked == true)
                            {
                                enableVibrator = "true";
                                controller4.SetVibration(new Vibration
                                {
                                    LeftMotorSpeed = 65535,
                                    RightMotorSpeed = 65535
                                });
                            }
                            else
                            {
                                enableVibrator = "false";
                            }

                        }
                        if (state.Gamepad.Buttons.HasFlag(GamepadButtonFlags.B))
                        {
                            buttons += "B ";
                            btnB.BackColor = Color.LimeGreen;

                            if (cbxEnableVib.Checked == true)
                            {
                                enableVibrator = "true";
                                controller4.SetVibration(new Vibration
                                {
                                    LeftMotorSpeed = 65535,
                                    RightMotorSpeed = 65535
                                });
                            }
                            else
                            {
                                enableVibrator = "false";
                            }
                        }
                        if (state.Gamepad.Buttons.HasFlag(GamepadButtonFlags.X))
                        {
                            buttons += "X ";
                            btnX.BackColor = Color.LimeGreen;
                            if (cbxEnableVib.Checked == true)
                            {
                                enableVibrator = "true";
                                controller4.SetVibration(new Vibration
                                {
                                    LeftMotorSpeed = 65535,
                                    RightMotorSpeed = 65535
                                });
                            }
                            else
                            {
                                enableVibrator = "false";
                            }
                        }
                        if (state.Gamepad.Buttons.HasFlag(GamepadButtonFlags.Y))
                        {
                            buttons += "Y ";
                            btnY.BackColor = Color.LimeGreen;
                            if (cbxEnableVib.Checked == true)
                            {
                                enableVibrator = "true";
                                controller4.SetVibration(new Vibration
                                {
                                    LeftMotorSpeed = 65535,
                                    RightMotorSpeed = 65535
                                });
                            }
                            else
                            {
                                enableVibrator = "false";
                            }
                        }
                        if (state.Gamepad.Buttons.HasFlag(GamepadButtonFlags.Start))
                        {
                            buttons += "Start ";
                            btnStart.BackColor = Color.LimeGreen;
                            btnX360Start.BackColor = Color.LimeGreen;
                            btnXONEStart.BackColor = Color.LimeGreen;
                            if (cbxEnableVib.Checked == true)
                            {
                                enableVibrator = "true";
                                controller4.SetVibration(new Vibration
                                {
                                    LeftMotorSpeed = 65535,
                                    RightMotorSpeed = 65535
                                });
                            }
                            else
                            {
                                enableVibrator = "false";
                            }
                        }
                        if (state.Gamepad.Buttons.HasFlag(GamepadButtonFlags.Back))
                        {
                            buttons += "Back ";

                            btnXONEBack.BackColor = Color.LimeGreen;
                            btnX360Back.BackColor = Color.LimeGreen;
                            btnBack.BackColor = Color.LimeGreen;
                            if (cbxEnableVib.Checked == true)
                            {
                                enableVibrator = "true";
                                controller4.SetVibration(new Vibration
                                {
                                    LeftMotorSpeed = 65535,
                                    RightMotorSpeed = 65535
                                });
                            }
                            else
                            {
                                enableVibrator = "false";
                            }
                        }
                        if (state.Gamepad.Buttons.HasFlag(GamepadButtonFlags.LeftShoulder))
                        {
                            buttons += "Left Shoulder ";
                            btnLeftBumper.BackColor = Color.LimeGreen;
                            btnWhite.BackColor = Color.LimeGreen;
                            if (cbxEnableVib.Checked == true)
                            {
                                enableVibrator = "true";
                                controller4.SetVibration(new Vibration
                                {
                                    LeftMotorSpeed = 65535,
                                    RightMotorSpeed = 65535
                                });
                            }
                            else
                            {
                                enableVibrator = "false";
                            }
                        }
                        if (state.Gamepad.Buttons.HasFlag(GamepadButtonFlags.RightShoulder))
                        {
                            buttons += "Right Shoulder ";
                            btnRightBumper.BackColor = Color.LimeGreen;
                            btnBlack.BackColor = Color.LimeGreen;
                            if (cbxEnableVib.Checked == true)
                            {
                                enableVibrator = "true";
                                controller4.SetVibration(new Vibration
                                {
                                    LeftMotorSpeed = 65535,
                                    RightMotorSpeed = 65535
                                });
                            }
                            else
                            {
                                enableVibrator = "false";
                            }

                        }
                        if (state.Gamepad.Buttons.HasFlag(GamepadButtonFlags.LeftThumb))
                        {
                            buttons += "Left Thumb ";
                            btnLSClick.BackColor = Color.LimeGreen;
                            if (cbxEnableVib.Checked == true)
                            {
                                enableVibrator = "true";
                                controller4.SetVibration(new Vibration
                                {
                                    LeftMotorSpeed = 65535,
                                    RightMotorSpeed = 65535
                                });
                            }
                            else
                            {
                                enableVibrator = "false";
                            }

                        }
                        if (state.Gamepad.Buttons.HasFlag(GamepadButtonFlags.RightThumb))
                        {
                            buttons += "Right Thumb ";
                            btnRSClick.BackColor = Color.LimeGreen;
                            if (cbxEnableVib.Checked == true)
                            {
                                enableVibrator = "true";
                                controller4.SetVibration(new Vibration
                                {
                                    LeftMotorSpeed = 65535,
                                    RightMotorSpeed = 65535
                                });
                            }
                            else
                            {
                                enableVibrator = "false";
                            }

                        }
                        if (state.Gamepad.Buttons.HasFlag(GamepadButtonFlags.DPadUp))
                        {
                            buttons += "DPadUp ";
                            btnDUp.BackColor = Color.LimeGreen;
                            //btnWhite.BackColor = Color.LimeGreen;
                            if (cbxEnableVib.Checked == true)
                            {
                                enableVibrator = "true";
                                controller4.SetVibration(new Vibration
                                {
                                    LeftMotorSpeed = 65535,
                                    RightMotorSpeed = 65535
                                });
                            }
                            else
                            {
                                enableVibrator = "false";
                            }
                        }
                        if (state.Gamepad.Buttons.HasFlag(GamepadButtonFlags.DPadDown))
                        {
                            buttons += "DPadDown ";
                            btnDDown.BackColor = Color.LimeGreen;
                            // btnBlack.BackColor = Color.LimeGreen;
                            if (cbxEnableVib.Checked == true)
                            {
                                enableVibrator = "true";
                                controller4.SetVibration(new Vibration
                                {
                                    LeftMotorSpeed = 65535,
                                    RightMotorSpeed = 65535
                                });
                            }
                            else
                            {
                                enableVibrator = "false";
                            }

                        }
                        if (state.Gamepad.Buttons.HasFlag(GamepadButtonFlags.DPadLeft))
                        {
                            buttons += "DPadLeft ";
                            btnDLeft.BackColor = Color.LimeGreen;
                            if (cbxEnableVib.Checked == true)
                            {
                                enableVibrator = "true";
                                controller4.SetVibration(new Vibration
                                {
                                    LeftMotorSpeed = 65535,
                                    RightMotorSpeed = 65535
                                });
                            }
                            else
                            {
                                enableVibrator = "false";
                            }

                        }
                        if (state.Gamepad.Buttons.HasFlag(GamepadButtonFlags.DPadRight))
                        {
                            buttons += "DPadRight ";
                            btnDRight.BackColor = Color.LimeGreen;
                            if (cbxEnableVib.Checked == true)
                            {
                                enableVibrator = "true";
                                controller4.SetVibration(new Vibration
                                {
                                    LeftMotorSpeed = 65535,
                                    RightMotorSpeed = 65535
                                });
                            }
                            else
                            {
                                enableVibrator = "false";
                            }

                        }

                    }







                    Thread.Sleep(milliseconds);



                }



            }

            //Console.WriteLine({gpBtnPress} "A button pressed");


        }

        private void timer1_Tick(object sender, EventArgs e)
        {

        }

        private void bgwProcessWhileLoopXinput_ProgressChanged(object sender, System.ComponentModel.ProgressChangedEventArgs e)
        {
            // Set the text of the label to the trigger positions
            label5.Text = $"Left trigger: {leftTrigger} + Right trigger: {rightTrigger + Environment.NewLine}" +
                $"Left ThumbX: {LJoystickX} + Left ThumbY: {LJoystickY + Environment.NewLine}" +
                $"Right ThumbX: {RJoystickX} + Right ThumbY: {RJoystickY}";

            // Refresh();
            var controller = new Controller(UserIndex.One);
            var controller2 = new Controller(UserIndex.Two);
            var controller3 = new Controller(UserIndex.Three);
            var controller4 = new Controller(UserIndex.Four);


            // Player 1 //
            if (controller.IsConnected)
            {
                State state = controller.GetState();
                string buttons = "";



                controller.SetVibration(new Vibration
                {
                    LeftMotorSpeed = 0,
                    RightMotorSpeed = 0
                });

            }
        }

        private void bgwProcessWhileLoopXinput_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {

            btnLTrigger.BackColor = Color.Transparent;
            btnRTrigger.BackColor = Color.Transparent;
        }

        private void cbLBumper_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
     
}
