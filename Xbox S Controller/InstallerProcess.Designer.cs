namespace Xbox_S_Controller
{
    partial class InstallerProcess
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(InstallerProcess));
            pictureBox1 = new PictureBox();
            btnNext = new Button();
            btnCancel = new Button();
            panel1 = new Panel();
            cbxDontQuit = new CheckBox();
            lblTitle = new Label();
            lblDescription = new Label();
            pLicenseAgreement = new Panel();
            textBox1 = new TextBox();
            panel3 = new Panel();
            label2 = new Label();
            lblHeader = new Label();
            pictureBox2 = new PictureBox();
            label1 = new Label();
            pInstallLocation = new Panel();
            lbl_DriveSpaceAvail = new Label();
            label9 = new Label();
            groupBox1 = new GroupBox();
            btnBrowse = new Button();
            txtFolderDestination = new TextBox();
            panel5 = new Panel();
            label6 = new Label();
            label7 = new Label();
            pictureBox3 = new PictureBox();
            label8 = new Label();
            btnBack = new Button();
            label5 = new Label();
            btnInstall = new Button();
            btnFinish = new Button();
            pInstallpanel = new Panel();
            label13 = new TextBox();
            groupBox2 = new GroupBox();
            progressBar1 = new ProgressBar();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            panel1.SuspendLayout();
            pLicenseAgreement.SuspendLayout();
            panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            pInstallLocation.SuspendLayout();
            groupBox1.SuspendLayout();
            panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
            pInstallpanel.SuspendLayout();
            groupBox2.SuspendLayout();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            pictureBox1.Image = Properties.Resources.Installer_Shield_Design_2;
            pictureBox1.Location = new Point(0, 0);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(497, 313);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            pictureBox1.Click += pictureBox1_Click;
            pictureBox1.Paint += pictureBox1_Paint;
            // 
            // btnNext
            // 
            btnNext.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnNext.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnNext.FlatStyle = FlatStyle.System;
            btnNext.Location = new Point(410, 335);
            btnNext.Name = "btnNext";
            btnNext.Size = new Size(75, 23);
            btnNext.TabIndex = 3;
            btnNext.Text = "Next >";
            btnNext.UseVisualStyleBackColor = true;
            btnNext.Click += button1_Click;
            // 
            // btnCancel
            // 
            btnCancel.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnCancel.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnCancel.FlatStyle = FlatStyle.System;
            btnCancel.Location = new Point(12, 335);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(75, 23);
            btnCancel.TabIndex = 4;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click;
            // 
            // panel1
            // 
            panel1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panel1.BackColor = Color.Transparent;
            panel1.Controls.Add(cbxDontQuit);
            panel1.Controls.Add(lblTitle);
            panel1.Controls.Add(lblDescription);
            panel1.ForeColor = SystemColors.ControlText;
            panel1.Location = new Point(175, 9);
            panel1.Name = "panel1";
            panel1.Size = new Size(310, 292);
            panel1.TabIndex = 6;
            // 
            // cbxDontQuit
            // 
            cbxDontQuit.Anchor = AnchorStyles.Bottom;
            cbxDontQuit.Enabled = false;
            cbxDontQuit.Location = new Point(91, 257);
            cbxDontQuit.Name = "cbxDontQuit";
            cbxDontQuit.RightToLeft = RightToLeft.Yes;
            cbxDontQuit.Size = new Size(119, 19);
            cbxDontQuit.TabIndex = 12;
            cbxDontQuit.Text = "Restart Computer";
            cbxDontQuit.UseVisualStyleBackColor = true;
            cbxDontQuit.Visible = false;
            cbxDontQuit.CheckedChanged += cbxDontQuit_CheckedChanged;
            // 
            // lblTitle
            // 
            lblTitle.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            lblTitle.BackColor = SystemColors.Control;
            lblTitle.Font = new Font("Calibri", 13F, FontStyle.Bold, GraphicsUnit.Point);
            lblTitle.Location = new Point(3, 3);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(304, 50);
            lblTitle.TabIndex = 3;
            lblTitle.Text = "Welcome to the Xbox OG Controller Kit Installer.";
            // 
            // lblDescription
            // 
            lblDescription.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            lblDescription.BackColor = SystemColors.Control;
            lblDescription.FlatStyle = FlatStyle.System;
            lblDescription.Font = new Font("Tahoma", 9F, FontStyle.Regular, GraphicsUnit.Point);
            lblDescription.Location = new Point(3, 61);
            lblDescription.Name = "lblDescription";
            lblDescription.Size = new Size(304, 228);
            lblDescription.TabIndex = 4;
            lblDescription.Text = resources.GetString("lblDescription.Text");
            // 
            // pLicenseAgreement
            // 
            pLicenseAgreement.BorderStyle = BorderStyle.FixedSingle;
            pLicenseAgreement.Controls.Add(textBox1);
            pLicenseAgreement.Controls.Add(panel3);
            pLicenseAgreement.Controls.Add(pictureBox2);
            pLicenseAgreement.Controls.Add(label1);
            pLicenseAgreement.Location = new Point(0, 0);
            pLicenseAgreement.Name = "pLicenseAgreement";
            pLicenseAgreement.Size = new Size(497, 313);
            pLicenseAgreement.TabIndex = 7;
            // 
            // textBox1
            // 
            textBox1.Font = new Font("Tahoma", 8.25F, FontStyle.Regular, GraphicsUnit.Point);
            textBox1.Location = new Point(21, 87);
            textBox1.Multiline = true;
            textBox1.Name = "textBox1";
            textBox1.ScrollBars = ScrollBars.Both;
            textBox1.ShortcutsEnabled = false;
            textBox1.Size = new Size(452, 213);
            textBox1.TabIndex = 3;
            textBox1.Text = resources.GetString("textBox1.Text");
            // 
            // panel3
            // 
            panel3.BorderStyle = BorderStyle.FixedSingle;
            panel3.Controls.Add(label2);
            panel3.Controls.Add(lblHeader);
            panel3.Location = new Point(135, 0);
            panel3.Name = "panel3";
            panel3.Size = new Size(362, 58);
            panel3.TabIndex = 2;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(13, 22);
            label2.Name = "label2";
            label2.Size = new Size(288, 15);
            label2.TabIndex = 1;
            label2.Text = "Please review the license before installing XboxOGKit.";
            // 
            // lblHeader
            // 
            lblHeader.AutoSize = true;
            lblHeader.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            lblHeader.Location = new Point(3, 7);
            lblHeader.Name = "lblHeader";
            lblHeader.Size = new Size(118, 15);
            lblHeader.TabIndex = 0;
            lblHeader.Text = "License Information";
            // 
            // pictureBox2
            // 
            pictureBox2.BackColor = Color.Black;
            pictureBox2.BorderStyle = BorderStyle.FixedSingle;
            pictureBox2.Image = Properties.Resources.Xbox_and_Contrller;
            pictureBox2.InitialImage = Properties.Resources.Xbox_and_Contrller;
            pictureBox2.Location = new Point(0, 0);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(137, 58);
            pictureBox2.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox2.TabIndex = 1;
            pictureBox2.TabStop = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(7, 69);
            label1.Name = "label1";
            label1.Size = new Size(325, 15);
            label1.TabIndex = 0;
            label1.Text = "Press Page Down or scroll to see the rest of the GNU License.";
            // 
            // pInstallLocation
            // 
            pInstallLocation.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            pInstallLocation.AutoScroll = true;
            pInstallLocation.AutoSize = true;
            pInstallLocation.BorderStyle = BorderStyle.FixedSingle;
            pInstallLocation.Controls.Add(lbl_DriveSpaceAvail);
            pInstallLocation.Controls.Add(label9);
            pInstallLocation.Controls.Add(groupBox1);
            pInstallLocation.Controls.Add(panel5);
            pInstallLocation.Controls.Add(pictureBox3);
            pInstallLocation.Controls.Add(label8);
            pInstallLocation.Location = new Point(0, 1);
            pInstallLocation.Name = "pInstallLocation";
            pInstallLocation.Size = new Size(502, 312);
            pInstallLocation.TabIndex = 8;
            pInstallLocation.Visible = false;
            // 
            // lbl_DriveSpaceAvail
            // 
            lbl_DriveSpaceAvail.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            lbl_DriveSpaceAvail.AutoSize = true;
            lbl_DriveSpaceAvail.Location = new Point(11, 270);
            lbl_DriveSpaceAvail.Name = "lbl_DriveSpaceAvail";
            lbl_DriveSpaceAvail.Size = new Size(90, 15);
            lbl_DriveSpaceAvail.TabIndex = 6;
            lbl_DriveSpaceAvail.Text = "Space available:";
            // 
            // label9
            // 
            label9.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            label9.AutoSize = true;
            label9.Location = new Point(11, 252);
            label9.Name = "label9";
            label9.Size = new Size(133, 15);
            label9.TabIndex = 5;
            label9.Text = "Space required: 42.4 MB";
            // 
            // groupBox1
            // 
            groupBox1.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            groupBox1.Controls.Add(btnBrowse);
            groupBox1.Controls.Add(txtFolderDestination);
            groupBox1.Location = new Point(11, 181);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(470, 54);
            groupBox1.TabIndex = 4;
            groupBox1.TabStop = false;
            groupBox1.Text = "Destination Folder";
            // 
            // btnBrowse
            // 
            btnBrowse.Anchor = AnchorStyles.Right;
            btnBrowse.Location = new Point(369, 20);
            btnBrowse.Name = "btnBrowse";
            btnBrowse.Size = new Size(95, 23);
            btnBrowse.TabIndex = 9;
            btnBrowse.Text = "Browse...";
            btnBrowse.UseVisualStyleBackColor = true;
            // 
            // txtFolderDestination
            // 
            txtFolderDestination.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            txtFolderDestination.Font = new Font("Tahoma", 8.25F, FontStyle.Regular, GraphicsUnit.Point);
            txtFolderDestination.Location = new Point(6, 22);
            txtFolderDestination.Name = "txtFolderDestination";
            txtFolderDestination.ScrollBars = ScrollBars.Both;
            txtFolderDestination.ShortcutsEnabled = false;
            txtFolderDestination.Size = new Size(357, 21);
            txtFolderDestination.TabIndex = 3;
            txtFolderDestination.Text = "C:\\Program Files (x86)\\XboxOGSystem";
            txtFolderDestination.TextChanged += txtFolderDestination_TextChanged;
            // 
            // panel5
            // 
            panel5.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            panel5.BorderStyle = BorderStyle.FixedSingle;
            panel5.Controls.Add(label6);
            panel5.Controls.Add(label7);
            panel5.Location = new Point(135, 0);
            panel5.Name = "panel5";
            panel5.Size = new Size(362, 58);
            panel5.TabIndex = 2;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(13, 22);
            label6.Name = "label6";
            label6.Size = new Size(260, 15);
            label6.TabIndex = 1;
            label6.Text = "Choose the folder in which to install XboxOGkit.";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label7.Location = new Point(3, 7);
            label7.Name = "label7";
            label7.Size = new Size(133, 15);
            label7.TabIndex = 0;
            label7.Text = "Choose Install Location";
            // 
            // pictureBox3
            // 
            pictureBox3.BackColor = Color.Black;
            pictureBox3.BorderStyle = BorderStyle.FixedSingle;
            pictureBox3.Image = Properties.Resources.Xbox_and_Contrller;
            pictureBox3.InitialImage = Properties.Resources.Xbox_and_Contrller;
            pictureBox3.Location = new Point(0, 0);
            pictureBox3.Name = "pictureBox3";
            pictureBox3.Size = new Size(137, 58);
            pictureBox3.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox3.TabIndex = 1;
            pictureBox3.TabStop = false;
            // 
            // label8
            // 
            label8.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            label8.Location = new Point(11, 69);
            label8.Name = "label8";
            label8.Size = new Size(470, 109);
            label8.TabIndex = 0;
            label8.Text = "Setup will install all of the necessary files for Xb2Input in the following folder.  To install in a different folder, click Browse and select another folder.  Click Install to start the installation.";
            // 
            // btnBack
            // 
            btnBack.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnBack.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnBack.FlatStyle = FlatStyle.System;
            btnBack.Location = new Point(329, 335);
            btnBack.Name = "btnBack";
            btnBack.Size = new Size(75, 23);
            btnBack.TabIndex = 8;
            btnBack.Text = "< Back";
            btnBack.UseVisualStyleBackColor = true;
            btnBack.Visible = false;
            btnBack.Click += btnBack_Click;
            // 
            // label5
            // 
            label5.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 8F, FontStyle.Regular, GraphicsUnit.Point);
            label5.ForeColor = Color.Gray;
            label5.Location = new Point(12, 316);
            label5.Name = "label5";
            label5.Size = new Size(85, 13);
            label5.TabIndex = 9;
            label5.Text = "XboxOGKit v3.0";
            // 
            // btnInstall
            // 
            btnInstall.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnInstall.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnInstall.Location = new Point(410, 335);
            btnInstall.Name = "btnInstall";
            btnInstall.Size = new Size(75, 23);
            btnInstall.TabIndex = 10;
            btnInstall.Text = "Install";
            btnInstall.UseVisualStyleBackColor = true;
            btnInstall.Visible = false;
            btnInstall.Click += btnInstall_Click;
            // 
            // btnFinish
            // 
            btnFinish.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnFinish.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnFinish.FlatStyle = FlatStyle.System;
            btnFinish.Location = new Point(410, 335);
            btnFinish.Name = "btnFinish";
            btnFinish.Size = new Size(75, 23);
            btnFinish.TabIndex = 11;
            btnFinish.Text = "Finish";
            btnFinish.UseVisualStyleBackColor = true;
            btnFinish.Visible = false;
            btnFinish.Click += btnFinish_Click;
            // 
            // pInstallpanel
            // 
            pInstallpanel.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
            pInstallpanel.BackColor = Color.White;
            pInstallpanel.BorderStyle = BorderStyle.FixedSingle;
            pInstallpanel.Controls.Add(label13);
            pInstallpanel.Controls.Add(groupBox2);
            pInstallpanel.Location = new Point(162, 0);
            pInstallpanel.Name = "pInstallpanel";
            pInstallpanel.Size = new Size(335, 313);
            pInstallpanel.TabIndex = 12;
            pInstallpanel.Visible = false;
            // 
            // label13
            // 
            label13.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            label13.BackColor = Color.White;
            label13.Location = new Point(11, 11);
            label13.Multiline = true;
            label13.Name = "label13";
            label13.ReadOnly = true;
            label13.ScrollBars = ScrollBars.Both;
            label13.Size = new Size(311, 226);
            label13.TabIndex = 5;
            label13.Text = "Setup will install all of the necessary files for Xb2Input in the following folder:";
            label13.TextChanged += label13_TextChanged;
            // 
            // groupBox2
            // 
            groupBox2.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            groupBox2.Controls.Add(progressBar1);
            groupBox2.Location = new Point(11, 243);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(311, 54);
            groupBox2.TabIndex = 4;
            groupBox2.TabStop = false;
            groupBox2.Text = "Overall Installation Progress.";
            // 
            // progressBar1
            // 
            progressBar1.Location = new Point(6, 22);
            progressBar1.Name = "progressBar1";
            progressBar1.Size = new Size(299, 23);
            progressBar1.TabIndex = 0;
            // 
            // InstallerProcess
            // 
            AutoScaleDimensions = new SizeF(96F, 96F);
            AutoScaleMode = AutoScaleMode.Dpi;
            ClientSize = new Size(497, 370);
            Controls.Add(label5);
            Controls.Add(btnNext);
            Controls.Add(btnBack);
            Controls.Add(btnCancel);
            Controls.Add(btnFinish);
            Controls.Add(btnInstall);
            Controls.Add(panel1);
            Controls.Add(pictureBox1);
            Controls.Add(pInstallpanel);
            Controls.Add(pInstallLocation);
            Controls.Add(pLicenseAgreement);
            DoubleBuffered = true;
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MinimumSize = new Size(513, 399);
            Name = "InstallerProcess";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Xbox OG System Installer";
            Load += InstallerProcess_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            panel1.ResumeLayout(false);
            pLicenseAgreement.ResumeLayout(false);
            pLicenseAgreement.PerformLayout();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            pInstallLocation.ResumeLayout(false);
            pInstallLocation.PerformLayout();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            panel5.ResumeLayout(false);
            panel5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
            pInstallpanel.ResumeLayout(false);
            pInstallpanel.PerformLayout();
            groupBox2.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pictureBox1;
        private Button btnNext;
        private Button btnCancel;
        private Panel panel1;
        private Label lblDescription;
        private Label lblTitle;
        private Panel pLicenseAgreement;
        private Button btnBack;
        private Panel panel3;
        private PictureBox pictureBox2;
        private Label label1;
        private TextBox textBox1;
        private Label label2;
        private Label lblHeader;
        private Label label5;
        private Panel pInstallLocation;
        private GroupBox groupBox1;
        private Button btnBrowse;
        private TextBox txtFolderDestination;
        private Panel panel5;
        private Label label6;
        private Label label7;
        private PictureBox pictureBox3;
        private Label label8;
        private Button btnInstall;
        private Label lbl_DriveSpaceAvail;
        private Label label9;
        private Button btnFinish;
        private CheckBox cbxDontQuit;
        private Panel pInstallpanel;
        private GroupBox groupBox2;
        private ProgressBar progressBar1;
        private TextBox label13;
    }
}