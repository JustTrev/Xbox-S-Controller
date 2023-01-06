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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnNext = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblDescription = new System.Windows.Forms.Label();
            this.cbxDontQuit = new System.Windows.Forms.CheckBox();
            this.pLicenseAgreement = new System.Windows.Forms.Panel();
            this.label10 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.lblHeader = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.pInstallLocation = new System.Windows.Forms.Panel();
            this.lbl_DriveSpaceAvail = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnBrowse = new System.Windows.Forms.Button();
            this.txtFolderDestination = new System.Windows.Forms.TextBox();
            this.panel5 = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.label8 = new System.Windows.Forms.Label();
            this.btnBack = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.btnInstall = new System.Windows.Forms.Button();
            this.btnFinish = new System.Windows.Forms.Button();
            this.pInstallpanel = new System.Windows.Forms.Panel();
            this.label13 = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel1.SuspendLayout();
            this.pLicenseAgreement.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.pInstallLocation.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            this.pInstallpanel.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.pictureBox1.Image = global::Xbox_S_Controller.Properties.Resources.Dash_plus_Controller_Installer_Shield_Design;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.MaximumSize = new System.Drawing.Size(497, 313);
            this.pictureBox1.MinimumSize = new System.Drawing.Size(497, 313);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(497, 313);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // btnNext
            // 
            this.btnNext.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNext.Location = new System.Drawing.Point(410, 335);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(75, 23);
            this.btnNext.TabIndex = 3;
            this.btnNext.Text = "Next >";
            this.btnNext.UseVisualStyleBackColor = true;
            this.btnNext.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.Location = new System.Drawing.Point(12, 335);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 4;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.lblTitle);
            this.panel1.Controls.Add(this.lblDescription);
            this.panel1.Location = new System.Drawing.Point(175, 9);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(310, 292);
            this.panel1.TabIndex = 6;
            // 
            // lblTitle
            // 
            this.lblTitle.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTitle.BackColor = System.Drawing.Color.White;
            this.lblTitle.Font = new System.Drawing.Font("Calibri", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblTitle.Location = new System.Drawing.Point(3, 3);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(304, 50);
            this.lblTitle.TabIndex = 3;
            this.lblTitle.Text = "Welcome to the Xbox OG Kit Installer.";
            // 
            // lblDescription
            // 
            this.lblDescription.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblDescription.BackColor = System.Drawing.Color.White;
            this.lblDescription.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblDescription.Location = new System.Drawing.Point(3, 61);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(304, 228);
            this.lblDescription.TabIndex = 4;
            this.lblDescription.Text = resources.GetString("lblDescription.Text");
            // 
            // cbxDontQuit
            // 
            this.cbxDontQuit.AutoSize = true;
            this.cbxDontQuit.Checked = true;
            this.cbxDontQuit.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbxDontQuit.Enabled = false;
            this.cbxDontQuit.Location = new System.Drawing.Point(204, 338);
            this.cbxDontQuit.Name = "cbxDontQuit";
            this.cbxDontQuit.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.cbxDontQuit.Size = new System.Drawing.Size(119, 19);
            this.cbxDontQuit.TabIndex = 12;
            this.cbxDontQuit.Text = "Restart Computer";
            this.cbxDontQuit.UseVisualStyleBackColor = true;
            this.cbxDontQuit.Visible = false;
            this.cbxDontQuit.CheckedChanged += new System.EventHandler(this.cbxDontQuit_CheckedChanged);
            // 
            // pLicenseAgreement
            // 
            this.pLicenseAgreement.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pLicenseAgreement.Controls.Add(this.label10);
            this.pLicenseAgreement.Controls.Add(this.textBox2);
            this.pLicenseAgreement.Controls.Add(this.textBox1);
            this.pLicenseAgreement.Controls.Add(this.panel3);
            this.pLicenseAgreement.Controls.Add(this.pictureBox2);
            this.pLicenseAgreement.Controls.Add(this.label1);
            this.pLicenseAgreement.Location = new System.Drawing.Point(0, 0);
            this.pLicenseAgreement.Name = "pLicenseAgreement";
            this.pLicenseAgreement.Size = new System.Drawing.Size(497, 313);
            this.pLicenseAgreement.TabIndex = 7;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(7, 182);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(420, 15);
            this.label10.TabIndex = 5;
            this.label10.Text = "Press Page Down or scroll to see the rest of Xbox OG Kit Terms and Conditions.";
            // 
            // textBox2
            // 
            this.textBox2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.textBox2.Location = new System.Drawing.Point(21, 204);
            this.textBox2.Multiline = true;
            this.textBox2.Name = "textBox2";
            this.textBox2.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBox2.ShortcutsEnabled = false;
            this.textBox2.Size = new System.Drawing.Size(452, 93);
            this.textBox2.TabIndex = 4;
            this.textBox2.Text = resources.GetString("textBox2.Text");
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.textBox1.Location = new System.Drawing.Point(21, 87);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBox1.ShortcutsEnabled = false;
            this.textBox1.Size = new System.Drawing.Size(452, 89);
            this.textBox1.TabIndex = 3;
            this.textBox1.Text = resources.GetString("textBox1.Text");
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.label2);
            this.panel3.Controls.Add(this.lblHeader);
            this.panel3.Location = new System.Drawing.Point(135, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(362, 58);
            this.panel3.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(294, 15);
            this.label2.TabIndex = 1;
            this.label2.Text = "Please review the license before installing Xbox OG Kit.";
            // 
            // lblHeader
            // 
            this.lblHeader.AutoSize = true;
            this.lblHeader.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblHeader.Location = new System.Drawing.Point(3, 7);
            this.lblHeader.Name = "lblHeader";
            this.lblHeader.Size = new System.Drawing.Size(118, 15);
            this.lblHeader.TabIndex = 0;
            this.lblHeader.Text = "License Information";
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.Black;
            this.pictureBox2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox2.Image = global::Xbox_S_Controller.Properties.Resources.Xbox_and_Contrller;
            this.pictureBox2.InitialImage = global::Xbox_S_Controller.Properties.Resources.Xbox_and_Contrller;
            this.pictureBox2.Location = new System.Drawing.Point(0, 0);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(137, 58);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 1;
            this.pictureBox2.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 69);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(325, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Press Page Down or scroll to see the rest of the GNU License.";
            // 
            // pInstallLocation
            // 
            this.pInstallLocation.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pInstallLocation.Controls.Add(this.lbl_DriveSpaceAvail);
            this.pInstallLocation.Controls.Add(this.label9);
            this.pInstallLocation.Controls.Add(this.groupBox1);
            this.pInstallLocation.Controls.Add(this.panel5);
            this.pInstallLocation.Controls.Add(this.pictureBox3);
            this.pInstallLocation.Controls.Add(this.label8);
            this.pInstallLocation.Location = new System.Drawing.Point(0, 1);
            this.pInstallLocation.Name = "pInstallLocation";
            this.pInstallLocation.Size = new System.Drawing.Size(497, 312);
            this.pInstallLocation.TabIndex = 8;
            this.pInstallLocation.Visible = false;
            // 
            // lbl_DriveSpaceAvail
            // 
            this.lbl_DriveSpaceAvail.AutoSize = true;
            this.lbl_DriveSpaceAvail.Location = new System.Drawing.Point(11, 270);
            this.lbl_DriveSpaceAvail.Name = "lbl_DriveSpaceAvail";
            this.lbl_DriveSpaceAvail.Size = new System.Drawing.Size(90, 15);
            this.lbl_DriveSpaceAvail.TabIndex = 6;
            this.lbl_DriveSpaceAvail.Text = "Space available:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(11, 252);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(133, 15);
            this.label9.TabIndex = 5;
            this.label9.Text = "Space required: 42.4 MB";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnBrowse);
            this.groupBox1.Controls.Add(this.txtFolderDestination);
            this.groupBox1.Location = new System.Drawing.Point(11, 181);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(470, 54);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Destination Folder";
            // 
            // btnBrowse
            // 
            this.btnBrowse.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBrowse.Location = new System.Drawing.Point(369, 20);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(95, 23);
            this.btnBrowse.TabIndex = 9;
            this.btnBrowse.Text = "Browse...";
            this.btnBrowse.UseVisualStyleBackColor = true;
            // 
            // txtFolderDestination
            // 
            this.txtFolderDestination.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtFolderDestination.Location = new System.Drawing.Point(6, 22);
            this.txtFolderDestination.Name = "txtFolderDestination";
            this.txtFolderDestination.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtFolderDestination.ShortcutsEnabled = false;
            this.txtFolderDestination.Size = new System.Drawing.Size(357, 21);
            this.txtFolderDestination.TabIndex = 3;
            this.txtFolderDestination.Text = "C:\\Program Files (x86)\\XboxOGSystem";
            this.txtFolderDestination.TextChanged += new System.EventHandler(this.txtFolderDestination_TextChanged);
            // 
            // panel5
            // 
            this.panel5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel5.Controls.Add(this.label6);
            this.panel5.Controls.Add(this.label7);
            this.panel5.Location = new System.Drawing.Point(135, 0);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(362, 58);
            this.panel5.TabIndex = 2;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(13, 22);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(281, 15);
            this.label6.TabIndex = 1;
            this.label6.Text = "Choose the folder in which to install Xb2Input v1.5c.";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label7.Location = new System.Drawing.Point(3, 7);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(133, 15);
            this.label7.TabIndex = 0;
            this.label7.Text = "Choose Install Location";
            // 
            // pictureBox3
            // 
            this.pictureBox3.BackColor = System.Drawing.Color.Black;
            this.pictureBox3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox3.Image = global::Xbox_S_Controller.Properties.Resources.Xbox_and_Contrller;
            this.pictureBox3.InitialImage = global::Xbox_S_Controller.Properties.Resources.Xbox_and_Contrller;
            this.pictureBox3.Location = new System.Drawing.Point(0, 0);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(137, 58);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox3.TabIndex = 1;
            this.pictureBox3.TabStop = false;
            // 
            // label8
            // 
            this.label8.Location = new System.Drawing.Point(11, 69);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(470, 109);
            this.label8.TabIndex = 0;
            this.label8.Text = "Setup will install all of the necessary files for Xb2Input in the following folde" +
    "r.  To install in a different folder, click Browse and select another folder.  C" +
    "lick Install to start the installation.";
            // 
            // btnBack
            // 
            this.btnBack.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBack.Location = new System.Drawing.Point(329, 335);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(75, 23);
            this.btnBack.TabIndex = 8;
            this.btnBack.Text = "< Back";
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Visible = false;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label5.ForeColor = System.Drawing.Color.Gray;
            this.label5.Location = new System.Drawing.Point(12, 316);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(95, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "XBOX OG KIT v2.0";
            // 
            // btnInstall
            // 
            this.btnInstall.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnInstall.Location = new System.Drawing.Point(410, 335);
            this.btnInstall.Name = "btnInstall";
            this.btnInstall.Size = new System.Drawing.Size(75, 23);
            this.btnInstall.TabIndex = 10;
            this.btnInstall.Text = "Install";
            this.btnInstall.UseVisualStyleBackColor = true;
            this.btnInstall.Visible = false;
            this.btnInstall.Click += new System.EventHandler(this.btnInstall_Click);
            // 
            // btnFinish
            // 
            this.btnFinish.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnFinish.Location = new System.Drawing.Point(410, 335);
            this.btnFinish.Name = "btnFinish";
            this.btnFinish.Size = new System.Drawing.Size(75, 23);
            this.btnFinish.TabIndex = 11;
            this.btnFinish.Text = "Finish";
            this.btnFinish.UseVisualStyleBackColor = true;
            this.btnFinish.Visible = false;
            this.btnFinish.Click += new System.EventHandler(this.btnFinish_Click);
            // 
            // pInstallpanel
            // 
            this.pInstallpanel.BackColor = System.Drawing.Color.White;
            this.pInstallpanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pInstallpanel.Controls.Add(this.label13);
            this.pInstallpanel.Controls.Add(this.groupBox2);
            this.pInstallpanel.Location = new System.Drawing.Point(162, 0);
            this.pInstallpanel.Name = "pInstallpanel";
            this.pInstallpanel.Size = new System.Drawing.Size(335, 313);
            this.pInstallpanel.TabIndex = 12;
            this.pInstallpanel.Visible = false;
            // 
            // label13
            // 
            this.label13.BackColor = System.Drawing.Color.White;
            this.label13.Location = new System.Drawing.Point(11, 11);
            this.label13.Multiline = true;
            this.label13.Name = "label13";
            this.label13.ReadOnly = true;
            this.label13.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.label13.Size = new System.Drawing.Size(311, 226);
            this.label13.TabIndex = 5;
            this.label13.Text = "Setup will install all of the necessary files for Xb2Input in the following folde" +
    "r:";
            this.label13.TextChanged += new System.EventHandler(this.label13_TextChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.progressBar1);
            this.groupBox2.Location = new System.Drawing.Point(11, 243);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(311, 54);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Install progress.";
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(6, 22);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(299, 23);
            this.progressBar1.TabIndex = 0;
            // 
            // InstallerProcess
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(497, 370);
            this.Controls.Add(this.cbxDontQuit);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnInstall);
            this.Controls.Add(this.btnNext);
            this.Controls.Add(this.btnFinish);
            this.Controls.Add(this.pInstallpanel);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.pInstallLocation);
            this.Controls.Add(this.pLicenseAgreement);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimumSize = new System.Drawing.Size(513, 399);
            this.Name = "InstallerProcess";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Xbox OG Kit Installer";
            this.Load += new System.EventHandler(this.InstallerProcess_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.pLicenseAgreement.ResumeLayout(false);
            this.pLicenseAgreement.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.pInstallLocation.ResumeLayout(false);
            this.pInstallLocation.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            this.pInstallpanel.ResumeLayout(false);
            this.pInstallpanel.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

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
        private Label label10;
        private TextBox textBox2;
        private Button btnFinish;
        private CheckBox cbxDontQuit;
        private Panel pInstallpanel;
        private GroupBox groupBox2;
        private ProgressBar progressBar1;
        private TextBox label13;
    }
}