using Microsoft.Win32;
using System.Diagnostics;
using System.Runtime.InteropServices;
using Xbox_S_Controller.Properties;
using IWshRuntimeLibrary;
using File = System.IO.File;

namespace Xbox_S_Controller
{
    public partial class InstallerProcess : Form
    {
        // The ExitWindowsEx function initiates a system shutdown and restart
        [DllImport("user32.dll", SetLastError = true)]
        static extern bool ExitWindowsEx(uint uFlags, uint dwReason);


        public const string AppTitle = "Xbox OG System"; // This you can have spaces in between // 
        public const string AppFinishMessage = "Your installation has completed successfully.\r\n\r\nClick Finish to exit.";
        public const string AppDescrip = $"This setup is designed to guide you through installing the {AppTitle} controller application.\r\n\r\nIt is recommended that you close 'XboxOGKit' and all other applications before starting, including Xb2XInput. This will help make it possible to update relevent files. Please follow any on screen installation wizard if necessary.\r\n\r\nA reboot may be required after installation.\r\n\r\nClick Next to continue.\r\n";





        public InstallerProcess()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        int ClickCounter = 0;


        private void button1_Click(object sender, EventArgs e)
        {

            ClickCounter++;

            if (ClickCounter >= 1)
            {
                btnBack.Visible = true;
                btnBack.Enabled = true;
            }

            brains(ClickCounter);

        }

        public void brains(int delta)
        {

            //  var abc;

            switch (delta)
            {
                case 1: // Step 1 Agree TOS //
                    lblTitle.Text = "";
                    lblDescription.Text = "";

                    panel1.Visible = false;
                    panel1.Enabled = false;
                    pictureBox1.Enabled = false;
                    pictureBox1.Visible = false;

                    pLicenseAgreement.Visible = true;
                    pLicenseAgreement.Enabled = true;
                    pInstallLocation.Visible = false;
                    pInstallLocation.Enabled = false;

                    btnInstall.Visible = false;
                    btnInstall.Enabled = false;
                    pInstallpanel.Visible = false;

                    btnNext.Visible = true;
                    btnNext.Enabled = true;

                    cbxDontQuit.Enabled = false;
                    cbxDontQuit.Visible = false;
                    break;

                case 2:  // Choose Location  //
                    panel1.Visible = false;
                    panel1.Enabled = false;
                    pictureBox1.Enabled = false;
                    pictureBox1.Visible = false;

                    pLicenseAgreement.Visible = false;
                    pLicenseAgreement.Enabled = false;
                    pInstallLocation.Visible = true;
                    pInstallLocation.Enabled = true;

                    btnBack.Visible = true;
                    btnBack.Enabled = true;
                    pInstallpanel.Visible = false;

                    btnInstall.Visible = true;
                    btnInstall.Enabled = true;

                    btnNext.Visible = false;
                    btnNext.Enabled = false;
                    // pInstallLocation.BringToFront();

                    cbxDontQuit.Enabled = false;
                    cbxDontQuit.Visible = false;
                    break;

                case 3:  // Run Installers //
                    // Show page contents. //
                    panel1.Visible = false;
                    panel1.Enabled = false;
                    pictureBox1.Enabled = true;
                    pictureBox1.Visible = true;
                    pictureBox1.BringToFront();// = true;

                    pictureBox1.Visible = true;

                    pLicenseAgreement.Visible = false;
                    pLicenseAgreement.Enabled = false;
                    pInstallLocation.Visible = false;
                    pInstallLocation.Enabled = false;
                    btnInstall.Visible = false;
                    btnInstall.Enabled = false;

                    btnFinish.Visible = false;
                    btnFinish.Enabled = false;

                    // Process registry habits
                    pInstallpanel.Visible = true;
                    pInstallpanel.BringToFront();// = true; 

                    btnNext.Visible = false;
                    btnNext.Enabled = false;

                    cbxDontQuit.Enabled = false;
                    cbxDontQuit.Visible = false;

                    try
                    {
                        // Write a value to the registry
                        Registry.SetValue(@"HKEY_CURRENT_USER\Software\XboxOGKit", "InstallPath", txtFolderDestination.Text);

                        // The source and destination directories  

                        // Get the file names in the source directory
                        Refresh();

                        if (!Directory.Exists(txtFolderDestination.Text + @"\Xb2XInput1_5c"))
                        {
                            Directory.CreateDirectory(txtFolderDestination.Text + @"\Xb2XInput1_5c");
                        }
                        label13.Text += $"{Environment.NewLine}  Creating directory: {txtFolderDestination.Text}\\Xb2XInput1_5c";
                        label13.Text += $"{Environment.NewLine}  Creating directory: {txtFolderDestination.Text}\\Drivers";
                        label13.Text += $"{Environment.NewLine}  ";
                        Refresh();

                        if (!Directory.Exists(txtFolderDestination.Text + @"\runtimes\win\lib\net6.0"))
                        {
                            Directory.CreateDirectory(txtFolderDestination.Text + @"\runtimes\win\lib\net6.0");
                            label13.Text += $"{Environment.NewLine}  Creating Directory: {txtFolderDestination.Text}\\XboxOGKit.runtimeconfig.json";

                        }


                        if (!File.Exists(txtFolderDestination.Text + @"\runtimes\win\lib\net6.0\System.Management.dll"))
                        {
                            File.WriteAllBytes(txtFolderDestination.Text + @"\runtimes\win\lib\net6.0\System.Management.dll", Resources.Xb2XInput1);

                        }



                        if (!File.Exists(txtFolderDestination.Text + @"\DeltaCompressionDotNet.MsDelta.dll"))
                        {
                            File.WriteAllBytes(txtFolderDestination.Text + @"\DeltaCompressionDotNet.MsDelta.dll", Resources.DeltaCompressionDotNet_MsDelta);
                        }

                        if (!File.Exists(txtFolderDestination.Text + @"\DeltaCompressionDotNet.PatchApi.dll"))
                        {
                            File.WriteAllBytes(txtFolderDestination.Text + @"\DeltaCompressionDotNet.PatchApi.dll", Resources.DeltaCompressionDotNet_PatchApi);
                        }

                        if (!File.Exists(txtFolderDestination.Text + @"\Microsoft.VisualStudio.Interop.dll"))
                        {
                            File.WriteAllBytes(txtFolderDestination.Text + @"\Microsoft.VisualStudio.Interop.dll", Resources.Microsoft_VisualStudio_Interop);
                        }

                        if (!File.Exists(txtFolderDestination.Text + @"\Microsoft.VisualStudio.OLE.Interop"))
                        {
                            File.WriteAllBytes(txtFolderDestination.Text + @"\DeltaCompressionDotNet.OLE.dll", Resources.Microsoft_VisualStudio_OLE_Interop);
                        }

                        if (!File.Exists(txtFolderDestination.Text + @"\Mono.Cecil.dll"))
                        {
                            File.WriteAllBytes(txtFolderDestination.Text + @"\Mono.Cecil.dll", Resources.Mono_Cecil);
                        }

                        if (!File.Exists(txtFolderDestination.Text + @"\Mono.Cecil.Mdb.dll"))
                        {
                            File.WriteAllBytes(txtFolderDestination.Text + @"\Mono.Cecil.Mdb.dll", Resources.Mono_Cecil_Mdb);
                        }

                        if (!File.Exists(txtFolderDestination.Text + @"\Mono.Cecil.Pdb.dll"))
                        {
                            File.WriteAllBytes(txtFolderDestination.Text + @"\Mono.Cecil.Pdb.dll", Resources.Mono_Cecil_Pdb);
                        }

                        if (!File.Exists(txtFolderDestination.Text + @"\Mono.Cecil.Rocks.dll"))
                        {
                            File.WriteAllBytes(txtFolderDestination.Text + @"\Mono.Cecil.Rocks.dll", Resources.Mono_Cecil_Rocks);
                        }




                        if (!File.Exists(txtFolderDestination.Text + @"\OpenTK.Compute.dll"))
                        {
                            File.WriteAllBytes(txtFolderDestination.Text + @"\OpenTK.Compute.dll", Resources.OpenTK_Compute);
                        }
                        if (!File.Exists(txtFolderDestination.Text + @"\OpenTK.Core.dll"))
                        {
                            File.WriteAllBytes(txtFolderDestination.Text + @"\OpenTK.Core.dll", Resources.OpenTK_Core);
                        }
                        if (!File.Exists(txtFolderDestination.Text + @"\OpenTK.Graphics.dll"))
                        {
                            File.WriteAllBytes(txtFolderDestination.Text + @"\OpenTK.Graphics.dll", Resources.OpenTK_Graphics);
                        }
                        if (!File.Exists(txtFolderDestination.Text + @"\OpenTK.Input.dll"))
                        {
                            File.WriteAllBytes(txtFolderDestination.Text + @"\OpenTK.Input.dll", Resources.OpenTK_Input);
                        }
                        if (!File.Exists(txtFolderDestination.Text + @"\OpenTK.Mathematics.dll"))
                        {
                            File.WriteAllBytes(txtFolderDestination.Text + @"\OpenTK.Mathematics.dll", Resources.OpenTK_Mathematics);
                        }
                        if (!File.Exists(txtFolderDestination.Text + @"\OpenTK.OpenAL.dll"))
                        {
                            File.WriteAllBytes(txtFolderDestination.Text + @"\OpenTK.OpenAL.dll", Resources.OpenTK_OpenAL);
                        }
                        if (!File.Exists(txtFolderDestination.Text + @"\OpenTK.Windowing.Common.dll"))
                        {
                            File.WriteAllBytes(txtFolderDestination.Text + @"\OpenTK.Windowing.Common.dll", Resources.OpenTK_Windowing_Common);
                        }
                        if (!File.Exists(txtFolderDestination.Text + @"\OpenTK.Windowing.Desktop.dll"))
                        {
                            File.WriteAllBytes(txtFolderDestination.Text + @"\OpenTK.Windowing.Desktop.dll", Resources.OpenTK_Windowing_Desktop);
                        }
                        if (!File.Exists(txtFolderDestination.Text + @"\OpenTK.Windowing.GraphicsLibraryFramework.dll"))
                        {
                            File.WriteAllBytes(txtFolderDestination.Text + @"\OpenTK.Windowing.GraphicsLibraryFramework.dll", Resources.OpenTK_Windowing_GraphicsLibraryFramework);
                        }



                        if (!File.Exists(txtFolderDestination.Text + @"\PInvoke.Windows.Core.dll"))
                        {
                            File.WriteAllBytes(txtFolderDestination.Text + @"\PInvoke.Windows.Core.dll", Resources.PInvoke_Windows_Core);
                        }



                        if (!File.Exists(txtFolderDestination.Text + @"\SharpCompress.dll"))
                        {
                            File.WriteAllBytes(txtFolderDestination.Text + @"\SharpCompress.dll", Resources.SharpCompress);
                        }



                        if (!File.Exists(txtFolderDestination.Text + @"\SharpDX.dll"))
                        {
                            File.WriteAllBytes(txtFolderDestination.Text + @"\SharpDX.dll", Resources.SharpDX);
                        }

                        if (!File.Exists(txtFolderDestination.Text + @"\SharpDX.RawInput.dll"))
                        {
                            File.WriteAllBytes(txtFolderDestination.Text + @"\SharpDX.RawInput.dll", Resources.SharpDX_RawInput);
                        }

                        if (!File.Exists(txtFolderDestination.Text + @"\SharpDX.XInput.dll"))
                        {
                            File.WriteAllBytes(txtFolderDestination.Text + @"\SharpDX.XInput.dll", Resources.SharpDX_XInput);
                        }

                        if (!File.Exists(txtFolderDestination.Text + @"\System.CodeDom.dll"))
                        {
                            File.WriteAllBytes(txtFolderDestination.Text + @"\System.CodeDom.dll", Resources.System_CodeDom);
                        }

                        if (!File.Exists(txtFolderDestination.Text + @"\System.Management.dll"))
                        {
                            File.WriteAllBytes(txtFolderDestination.Text + @"\System.Management.dll", Resources.System_Management);
                        }






                        if (!Directory.Exists(txtFolderDestination.Text + @"\Drivers"))
                        {
                            Directory.CreateDirectory(txtFolderDestination.Text + @"\Drivers");
                        }





                        Refresh();

                        if (!File.Exists(txtFolderDestination.Text + @"\Xb2XInput1_5c\Xb2XInput.exe"))
                        {
                            File.WriteAllBytes(txtFolderDestination.Text + @"\Xb2XInput1_5c\Xb2XInput.exe", Resources.Xb2XInput1);

                        }
                        Refresh();

                        if (!File.Exists(txtFolderDestination.Text + @"\Drivers\install drivers.bat"))
                        {
                            File.WriteAllText(txtFolderDestination.Text + @"\Drivers\install drivers.bat", Resources.install_drivers);

                        }

                        label13.Text += $"{Environment.NewLine}  Copying file: {txtFolderDestination.Text}\\Drivers\\install drivers.bat";

                        if (!File.Exists(txtFolderDestination.Text + @"\Xb2XInput1_5c\README.md"))
                        {
                            File.WriteAllBytes(txtFolderDestination.Text + @"\Xb2XInput1_5c\README.md", Resources.Xb2XInput1);

                        }

                        label13.Text += $"{Environment.NewLine}  Copying file: {txtFolderDestination.Text}\\Xb2XInput1_5c\\README.md";
                        Refresh();

                        if (!File.Exists(txtFolderDestination.Text + @"\Xb2XInput1_5c\libusb-1.0.dll"))
                        {
                            File.WriteAllBytes(txtFolderDestination.Text + @"\Xb2XInput1_5c\libusb-1.0.dll", Resources.Xb2XInput1);

                        }
                        label13.Text += $"{Environment.NewLine}  Copying file: {txtFolderDestination.Text}\\Xb2XInput1_5c\\libusb-1.0.dll";

                        Refresh();


                        progressBar1.Value = 5;


                        if (!File.Exists(txtFolderDestination.Text + @"\XboxOGKit.dll"))
                        {
                            File.WriteAllBytes(txtFolderDestination.Text + @"\XboxOGKit.dll", Resources.XboxOGKit);

                        }

                        label13.Text += $"{Environment.NewLine}  Copying file: {txtFolderDestination.Text}\\XboxOGKit.dll";

                        Refresh();

                        if (!File.Exists(txtFolderDestination.Text + @"\XboxOGKit.deps.json"))
                        {
                            File.WriteAllBytes(txtFolderDestination.Text + @"\XboxOGKit.deps.json", Resources.XboxOGKit_deps);

                        }

                        label13.Text += $"{Environment.NewLine}  Copying file: {txtFolderDestination.Text}\\XboxOGKit.deps.json";


                        Refresh();

                        if (!File.Exists(txtFolderDestination.Text + @"\XboxOGKit.dll.config"))
                        {
                            File.WriteAllText(txtFolderDestination.Text + @"\XboxOGKit.dll.config", Resources.XboxOGKit_dll);

                        }

                        label13.Text += $"{Environment.NewLine}  Copying file: {txtFolderDestination.Text}\\XboxOGKit.dll.config";

                        Refresh();

                        if (!File.Exists(txtFolderDestination.Text + @"\XboxOGKit.runtimeconfig.json"))
                        {
                            File.WriteAllBytes(txtFolderDestination.Text + @"\XboxOGKit.runtimeconfig.json", Resources.XboxOGKit_runtimeconfig);

                        }

                        label13.Text += $"{Environment.NewLine}  Copying file: {txtFolderDestination.Text}\\XboxOGKit.runtimeconfig.json";

                        Refresh();

                        if (!File.Exists(txtFolderDestination.Text + @"\XboxOGKit.exe"))
                        {
                            File.WriteAllBytes(txtFolderDestination.Text + @"\XboxOGKit.exe", Resources.XboxOGKit1);

                        }

                        label13.Text += $"{Environment.NewLine}  Copying file: {txtFolderDestination.Text}\\XboxOGKit.exe";

                        Refresh();

                        if (!File.Exists(txtFolderDestination.Text + @"\XboxOGKit.pdb"))
                        {
                            File.WriteAllBytes(txtFolderDestination.Text + @"\XboxOGKit.pdb", Resources.XboxOGKit2);

                        }

                        label13.Text += $"{Environment.NewLine}  Copying file: {txtFolderDestination.Text}\\XboxOGKit.pdb";


                        Refresh();


                        if (!File.Exists(txtFolderDestination.Text + @"\Drivers\wdi-simple.exe"))
                        {
                            File.WriteAllBytes(txtFolderDestination.Text + @"\Drivers\wdi-simple.exe", Resources.wdi_simple);

                        }

                        label13.Text += $"{Environment.NewLine}  Copying file: {txtFolderDestination.Text}\\Drivers\\wdi-simple.exe";


                        Refresh();


                        if (!File.Exists(txtFolderDestination.Text + @"\Drivers\ViGEmBus_1.21.442_x64_x86_arm64.exe"))
                        {
                            File.WriteAllBytes(txtFolderDestination.Text + @"\Drivers\ViGEmBus_1.21.442_x64_x86_arm64.exe", Resources.ViGEmBus_1_21_442_x64_x86_arm64);

                        }

                        label13.Text += $"{Environment.NewLine}  Copying file: {txtFolderDestination.Text}\\Drivers\\ViGEmBus_1.21.442_x64_x86_arm64.exe";
                        label13.Text += $"{Environment.NewLine}  Finished successffuly.  Running task.";


                        Refresh();
                        progressBar1.Value = 60;


                        Thread.Sleep(2000);

                        // Show page contents. // 
                        pictureBox1.Enabled = true;
                        pictureBox1.Visible = true;
                        pictureBox1.BringToFront();// = true;

                        // Process registry habits
                        pInstallpanel.Visible = true;
                        pInstallpanel.BringToFront();// = true; 
                        Refresh();
                        label13.ScrollToCaret();

                        label13.Text += $"{Environment.NewLine} Installing ViGEmBus v1.21.442";

                        ProcessStartInfo ViGEmBus_1 = new ProcessStartInfo();

                        ViGEmBus_1.WorkingDirectory = txtFolderDestination.Text + @"\Drivers\";
                        ViGEmBus_1.FileName = @"ViGEmBus_1.21.442_x64_x86_arm64.exe";
                        ViGEmBus_1.UseShellExecute = true;


                        using (Process myProcess = Process.Start(ViGEmBus_1))
                        {
                            // Display physical memory usage 5 times at intervals of 2 seconds.
                            while (!myProcess.HasExited)
                            {
                                // Discard cached information about the process.
                                myProcess.Refresh();

                                Thread.Sleep(1000);
                            }
                        }
                        progressBar1.Value = 90;
                        label13.Text += $"{Environment.NewLine} Done.";
                        label13.Text += $"{Environment.NewLine} Installing analog GamePad drivers to xInput for Windows.";

                        Refresh();

                        ProcessStartInfo installDriversBat = new ProcessStartInfo();

                        installDriversBat.WorkingDirectory = txtFolderDestination.Text + @"\Drivers\";
                        installDriversBat.FileName = @"install drivers.bat";
                        installDriversBat.Arguments = "/verb /runAs";
                        installDriversBat.UseShellExecute = true;


                        using (Process myProcess = Process.Start(installDriversBat))
                        {
                            // Display physical memory usage 5 times at intervals of 2 seconds.
                            while (!myProcess.HasExited)
                            {
                                // Discard cached information about the process.
                                myProcess.Refresh();

                                Thread.Sleep(1000);
                            }
                        }

                        progressBar1.Value = 100;
                        label13.Text += $"{Environment.NewLine} Completed.";


                        ClickCounter++;

                        if (ClickCounter >= 1)
                        {
                            btnBack.Visible = false;
                            btnBack.Enabled = false;
                        }

                        brains(ClickCounter);

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);

                        label13.Text += $"{Environment.NewLine}  Finished with an error. Aborting.";

                    }


                    break;

                case 4:  // Install Complete //

                    lblTitle.Text = $"The {AppTitle} Installer.";
                    lblDescription.Text = AppFinishMessage;

                    // Open Page //
                    pictureBox1.Enabled = true;
                    pictureBox1.Visible = true;
                    pictureBox1.BringToFront();// = true;


                    // Show page contents. //
                    panel1.Visible = true;
                    panel1.Enabled = true;
                    panel1.BringToFront();


                    pLicenseAgreement.Visible = true;
                    pLicenseAgreement.Enabled = true;
                    pInstallLocation.Visible = false;
                    pInstallLocation.Enabled = false;

                    btnInstall.Visible = false;
                    btnInstall.Enabled = false;

                    groupBox2.Visible = false;
                    btnFinish.Visible = true;
                    btnFinish.Enabled = true;

                    cbxDontQuit.Enabled = true;
                    cbxDontQuit.Visible = true;



                    cbxDontQuit.BringToFront();//  = false; 


                    try
                    {

                        // The path to the target executable
                        string targetPath = txtFolderDestination.Text + @"\XboxOGKit.exe";

                        // The path to the start menu
                        string startMenuFolder = Environment.GetFolderPath(Environment.SpecialFolder.StartMenu);
                        string startUpMenuFolder = Environment.GetFolderPath(Environment.SpecialFolder.Startup);
                        string desktopFolder = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

                        // Create the shortcut link
                        WshShell shell = new WshShell();
                        IWshShortcut shortcut = (IWshShortcut)shell.CreateShortcut(Path.Combine(startMenuFolder, "XboxOGKit.lnk"));
                        IWshShortcut shortcut1 = (IWshShortcut)shell.CreateShortcut(Path.Combine(startUpMenuFolder, "XboxOGKit.lnk"));
                        IWshShortcut shortcut2 = (IWshShortcut)shell.CreateShortcut(Path.Combine(desktopFolder, "XboxOGKit.lnk"));
                        shortcut.TargetPath = targetPath;
                        shortcut1.TargetPath = targetPath;
                        shortcut2.TargetPath = targetPath;
                        shortcut.Save();
                        shortcut1.Save();
                        shortcut2.Save();
                    }
                    catch
                    {

                    }


                    break;

                case 5: // Setup Failed //
                    lblTitle.Text = $"The {AppTitle} Installer Has been aborted by the user.";
                    lblDescription.Text = AppFinishMessage;

                    // Show page contents. //
                    panel1.Visible = true;
                    panel1.Enabled = true;
                    pictureBox1.Enabled = true;
                    pictureBox1.Visible = true;

                    pLicenseAgreement.Visible = true;
                    pLicenseAgreement.Enabled = true;
                    pInstallLocation.Visible = false;
                    pInstallLocation.Enabled = false;

                    btnInstall.Visible = false;
                    btnInstall.Enabled = false;

                    btnFinish.Visible = true;
                    btnFinish.Enabled = true;

                    cbxDontQuit.Enabled = true;
                    cbxDontQuit.Visible = true;
                    break;

                case 7: // already installed //

                    break;

                case 0: // Start //
                    // assign our pages //
                    lblTitle.Text = $"Welcome to the {AppTitle} Installer.";
                    lblDescription.Text = AppDescrip;


                    panel1.Visible = true;
                    panel1.Enabled = true;
                    panel1.BringToFront(); // = false;
                    pictureBox1.Enabled = true;
                    pictureBox1.Visible = true;

                    pLicenseAgreement.Visible = false;
                    pLicenseAgreement.Enabled = false;
                    pInstallLocation.Visible = false;
                    pInstallLocation.Enabled = false;
                    btnBack.Visible = false;
                    btnBack.Enabled = false;
                    btnFinish.Enabled = false;
                    btnFinish.Visible = false;

                    cbxDontQuit.Enabled = false;
                    cbxDontQuit.Visible = false;
                    break;
            }
        }

        private void InstallerProcess_Load(object sender, EventArgs e)
        {

            // Set up the installer //
            brains(ClickCounter);

            checkMakup();


        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            if (ClickCounter != 0)
            {
                ClickCounter--;
                brains(ClickCounter);
            }
        }
        private static string FormatBytes(long bytes)
        {
            string[] Suffix = { "B", "KB", "MB", "GB", "TB" };
            int i;
            double dblSByte = bytes;
            for (i = 0; i < Suffix.Length && bytes >= 1024; i++, bytes /= 1024)
            {
                dblSByte = bytes / 1024.0;
            }

            return String.Format("{0:0.##} {1}", dblSByte, Suffix[i]);
        }

        public void checkMakup()
        {
            try
            {
                // List available drive letters //
                string[] driveList = { @"A:\", @"B:\", @"C:\", @"D:\", @"E:\", @"F:\", @"G:\", @"H:\", @"I:\", @"J:\", @"K:\", @"L:\", @"M:\", @"N:\", @"O:\", @"P:\", @"Q:\", @"R:\", @"S:\", @"T:\", @"U:\", @"V:\", @"W:\", @"X:\", @"Y:\", @"Z:\", @"a:\", @"b:\", @"c:\", @"d:\", @"e:\", @"f:\", @"g:\", @"h:\", @"i:\", @"j:\", @"k:\", @"l:\", @"m:\", @"n:\", @"o:\", @"p:\", @"q:\", @"r:\", @"s:\", @"t:\", @"u:\", @"v:\", @"w:\", @"x:\", @"y:\", @"z:\" };

                // Scan for drives and store the choosen path in memory //
                foreach (DriveInfo drive in DriveInfo.GetDrives())
                {
                    // Skip to next loop cycle when drive is not ready
                    if (!drive.IsReady)
                        continue;

                    // Calculate the drive space //
                    foreach (string driveName in driveList)
                    {
                        // Drive Detection in text //
                        if (txtFolderDestination.Text.Contains(driveName))
                        {
                            if (drive.Name == driveName)
                            {
                                lbl_DriveSpaceAvail.Text = $"Space available: {FormatBytes((drive.AvailableFreeSpace))}";
                            }
                        }
                    }
                }
            }
            catch
            {
                // Do nothing.
            }
            finally
            {
                // Clean up our garbage after each use.s
                GC.Collect();
            }
        }

        private void txtFolderDestination_TextChanged(object sender, EventArgs e)
        {
            checkMakup();

            // Prevent next step if destination is blank. //
            if (txtFolderDestination.Text == "")
            {
                btnNext.Enabled = false;
            }
            else
            {
                btnNext.Enabled = true;
            }
        }

        private void btnInstall_Click(object sender, EventArgs e)
        {
            ClickCounter++;

            if (ClickCounter >= 1)
            {
                btnBack.Visible = false;
                btnBack.Enabled = false;
            }
            // Show page contents. //
            panel1.Visible = false;
            panel1.Enabled = false;
            pictureBox1.Enabled = true;
            pictureBox1.Visible = true;
            pictureBox1.BringToFront();// = true;

            pictureBox1.Visible = true;

            pLicenseAgreement.Visible = false;
            pLicenseAgreement.Enabled = false;
            pInstallLocation.Visible = false;
            pInstallLocation.Enabled = false;
            btnInstall.Visible = false;
            btnInstall.Enabled = false;

            btnFinish.Visible = false;
            btnFinish.Enabled = false;

            // Process registry habits
            pInstallpanel.Visible = true;
            pInstallpanel.BringToFront();// = true; 

            btnNext.Visible = false;
            btnNext.Enabled = false;

            cbxDontQuit.Enabled = false;
            cbxDontQuit.Visible = false;

            Thread.Sleep(1000);

            brains(ClickCounter);



        }

        private void btnFinish_Click(object sender, EventArgs e)
        {
            try
            {
                if (cbxDontQuit.Checked == true)
                {
                    // Force restart Windows 
                    Process process = new Process();

                    // Set the process start info
                    process.StartInfo.FileName = @"C:\Windows\System32\cmd.exe";
                    process.StartInfo.Arguments = "/c shutdown -r -t 0"; // Restart Windows immediately

                    // Start the process
                    process.Start();

                    Close();

                }
            }
            catch
            {
                Close();
            }
        }

        private void label13_TextChanged(object sender, EventArgs e)
        {
            label13.SelectionStart = label13.TextLength;
            label13.ScrollToCaret();
        }

        public bool ccbxDontQuit;
        private void cbxDontQuit_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            // // Get the location of each label relative to the PictureBox control
            // Point label1Location = panel1.PointToScreen(lblTitle.Location);
            // Point label2Location = panel1.PointToScreen(lblDescription.Location);
            // label1Location = pictureBox1.PointToClient(label1Location);
            // label2Location = pictureBox1.PointToClient(label2Location);
            //
            // // Calculate the location of each label relative to the image in the PictureBox control
            // int label1ImageX = label1Location.X - panel1.Location.X;
            // int label1ImageY = label1Location.Y - panel1.Location.Y;
            // int label2ImageX = label2Location.X - panel1.Location.X;
            // int label2ImageY = label2Location.Y - panel1.Location.Y;
            //
            // // Get the color of the pixel at the calculated location in the image of the PictureBox control for each label
            // Bitmap bmp = (Bitmap)pictureBox1.Image;
            // Color label1PixelColor = bmp.GetPixel(label1ImageX, label1ImageY);
            // Color label2PixelColor = bmp.GetPixel(label2ImageX, label2ImageY);
            //
            // // Calculate the brightness of each color
            // double label1Brightness = label1PixelColor.R * 0.299 + label1PixelColor.G * 0.587 + label1PixelColor.B * 0.114;
            // double label2Brightness = label2PixelColor.R * 0.299 + label2PixelColor.G * 0.587 + label2PixelColor.B * 0.114;
            //
            // // Set the foreground color of each label based on the brightness
            // if (label1Brightness > 128)
            // {
            //     lblTitle.ForeColor = Color.Black;
            // }
            // else
            // {
            //     lblTitle.ForeColor = Color.White;
            // }
            //
            // if (label2Brightness > 128)
            // {
            //     lblDescription.ForeColor = Color.Black;
            // }
            // else
            // {
            //     lblDescription.ForeColor = Color.White;
            // }
            //// lblTitle.BackColor= Color.Transparent;
            //// lblDescription.BackColor= Color.Transparent;



        }

        private void btnSwitchToBeta_Click(object sender, EventArgs e)
        {
            NewInstaller frmNewInstaller = new NewInstaller();
            frmNewInstaller.ShowDialog();
        }
    }
}
