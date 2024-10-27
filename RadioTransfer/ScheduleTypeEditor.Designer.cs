namespace Thornton.Scheduler
{
    partial class ScheduleTypeEditor
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ScheduleTypeEditor));
            this.scheduleTabs = new System.Windows.Forms.TabControl();
            this.tbHTTP = new System.Windows.Forms.TabPage();
            this.btnMacroHttp = new System.Windows.Forms.Button();
            this.txtHttpNewName = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtHttpLink = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tbFTP = new System.Windows.Forms.TabPage();
            this.chkFTP_IsPassive = new System.Windows.Forms.CheckBox();
            this.btnBrowseFtp = new System.Windows.Forms.Button();
            this.label11 = new System.Windows.Forms.Label();
            this.txtFtpNewName = new System.Windows.Forms.TextBox();
            this.btnMacroFTP = new System.Windows.Forms.Button();
            this.chkFTPSubdirectories = new System.Windows.Forms.CheckBox();
            this.txtFTP_Path = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtFTP_Password = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtFTP_UserName = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.cmbFTP_LogonType = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtFTP_Port = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cmbFTP_Protocol = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtFTP_Host = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tbNetworkFolder = new System.Windows.Forms.TabPage();
            this.btnBrowseNetworkFolder = new System.Windows.Forms.Button();
            this.btnMacroNetwork = new System.Windows.Forms.Button();
            this.txtNetworkNewName = new System.Windows.Forms.TextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.txtNetworkPath = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.tbDropbox = new System.Windows.Forms.TabPage();
            this.btnMacroDropbox = new System.Windows.Forms.Button();
            this.label17 = new System.Windows.Forms.Label();
            this.txtDropboxFileNewName = new System.Windows.Forms.TextBox();
            this.txtDropboxPath = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.tbGdrive = new System.Windows.Forms.TabPage();
            this.btnMacroGDrive = new System.Windows.Forms.Button();
            this.txtGDriveFileNewName = new System.Windows.Forms.TextBox();
            this.label20 = new System.Windows.Forms.Label();
            this.txtGoogleDrivePath = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.tbRss = new System.Windows.Forms.TabPage();
            this.btnMacroRss = new System.Windows.Forms.Button();
            this.txtRssNewFileName = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.txtRssPath = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.btnBrowse = new System.Windows.Forms.Button();
            this.txtDownloadPath = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnOk = new System.Windows.Forms.Button();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.folderBrowserNetwork = new System.Windows.Forms.FolderBrowserDialog();
            this.btnCancel = new System.Windows.Forms.Button();
            this.dlgSelectFile = new System.Windows.Forms.OpenFileDialog();
            this.scheduleTabs.SuspendLayout();
            this.tbHTTP.SuspendLayout();
            this.tbFTP.SuspendLayout();
            this.tbNetworkFolder.SuspendLayout();
            this.tbDropbox.SuspendLayout();
            this.tbGdrive.SuspendLayout();
            this.tbRss.SuspendLayout();
            this.SuspendLayout();
            // 
            // scheduleTabs
            // 
            this.scheduleTabs.Controls.Add(this.tbHTTP);
            this.scheduleTabs.Controls.Add(this.tbFTP);
            this.scheduleTabs.Controls.Add(this.tbNetworkFolder);
            this.scheduleTabs.Controls.Add(this.tbDropbox);
            this.scheduleTabs.Controls.Add(this.tbGdrive);
            this.scheduleTabs.Controls.Add(this.tbRss);
            this.scheduleTabs.Location = new System.Drawing.Point(16, 15);
            this.scheduleTabs.Margin = new System.Windows.Forms.Padding(4);
            this.scheduleTabs.Name = "scheduleTabs";
            this.scheduleTabs.SelectedIndex = 0;
            this.scheduleTabs.Size = new System.Drawing.Size(688, 302);
            this.scheduleTabs.TabIndex = 0;
            // 
            // tbHTTP
            // 
            this.tbHTTP.Controls.Add(this.btnMacroHttp);
            this.tbHTTP.Controls.Add(this.txtHttpNewName);
            this.tbHTTP.Controls.Add(this.label9);
            this.tbHTTP.Controls.Add(this.txtHttpLink);
            this.tbHTTP.Controls.Add(this.label2);
            this.tbHTTP.Location = new System.Drawing.Point(4, 25);
            this.tbHTTP.Margin = new System.Windows.Forms.Padding(4);
            this.tbHTTP.Name = "tbHTTP";
            this.tbHTTP.Padding = new System.Windows.Forms.Padding(4);
            this.tbHTTP.Size = new System.Drawing.Size(680, 273);
            this.tbHTTP.TabIndex = 0;
            this.tbHTTP.Text = "HTTP/HTTPS";
            this.tbHTTP.UseVisualStyleBackColor = true;
            // 
            // btnMacroHttp
            // 
            this.btnMacroHttp.AutoSize = true;
            this.btnMacroHttp.Location = new System.Drawing.Point(571, 57);
            this.btnMacroHttp.Name = "btnMacroHttp";
            this.btnMacroHttp.Size = new System.Drawing.Size(81, 27);
            this.btnMacroHttp.TabIndex = 7;
            this.btnMacroHttp.Text = "Macro";
            this.btnMacroHttp.UseVisualStyleBackColor = true;
            this.btnMacroHttp.Click += new System.EventHandler(this.btnMacroHttp_Click);
            // 
            // txtHttpNewName
            // 
            this.txtHttpNewName.Location = new System.Drawing.Point(127, 59);
            this.txtHttpNewName.Margin = new System.Windows.Forms.Padding(4);
            this.txtHttpNewName.Name = "txtHttpNewName";
            this.txtHttpNewName.Size = new System.Drawing.Size(436, 22);
            this.txtHttpNewName.TabIndex = 6;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(37, 62);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(80, 17);
            this.label9.TabIndex = 5;
            this.label9.Text = "New Name:";
            // 
            // txtHttpLink
            // 
            this.txtHttpLink.Location = new System.Drawing.Point(127, 15);
            this.txtHttpLink.Margin = new System.Windows.Forms.Padding(4);
            this.txtHttpLink.Name = "txtHttpLink";
            this.txtHttpLink.Size = new System.Drawing.Size(525, 22);
            this.txtHttpLink.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(19, 18);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(98, 17);
            this.label2.TabIndex = 3;
            this.label2.Text = "HTTP(S) Link:";
            // 
            // tbFTP
            // 
            this.tbFTP.Controls.Add(this.chkFTP_IsPassive);
            this.tbFTP.Controls.Add(this.btnBrowseFtp);
            this.tbFTP.Controls.Add(this.label11);
            this.tbFTP.Controls.Add(this.txtFtpNewName);
            this.tbFTP.Controls.Add(this.btnMacroFTP);
            this.tbFTP.Controls.Add(this.chkFTPSubdirectories);
            this.tbFTP.Controls.Add(this.txtFTP_Path);
            this.tbFTP.Controls.Add(this.label10);
            this.tbFTP.Controls.Add(this.txtFTP_Password);
            this.tbFTP.Controls.Add(this.label7);
            this.tbFTP.Controls.Add(this.txtFTP_UserName);
            this.tbFTP.Controls.Add(this.label8);
            this.tbFTP.Controls.Add(this.cmbFTP_LogonType);
            this.tbFTP.Controls.Add(this.label6);
            this.tbFTP.Controls.Add(this.txtFTP_Port);
            this.tbFTP.Controls.Add(this.label5);
            this.tbFTP.Controls.Add(this.cmbFTP_Protocol);
            this.tbFTP.Controls.Add(this.label4);
            this.tbFTP.Controls.Add(this.txtFTP_Host);
            this.tbFTP.Controls.Add(this.label3);
            this.tbFTP.Location = new System.Drawing.Point(4, 25);
            this.tbFTP.Margin = new System.Windows.Forms.Padding(4);
            this.tbFTP.Name = "tbFTP";
            this.tbFTP.Padding = new System.Windows.Forms.Padding(4);
            this.tbFTP.Size = new System.Drawing.Size(680, 273);
            this.tbFTP.TabIndex = 1;
            this.tbFTP.Text = "FTP/SFTP";
            this.tbFTP.UseVisualStyleBackColor = true;
            // 
            // chkFTP_IsPassive
            // 
            this.chkFTP_IsPassive.AutoSize = true;
            this.chkFTP_IsPassive.Location = new System.Drawing.Point(545, 108);
            this.chkFTP_IsPassive.Name = "chkFTP_IsPassive";
            this.chkFTP_IsPassive.Size = new System.Drawing.Size(87, 21);
            this.chkFTP_IsPassive.TabIndex = 25;
            this.chkFTP_IsPassive.Text = "Passive?";
            this.chkFTP_IsPassive.UseVisualStyleBackColor = true;
            this.chkFTP_IsPassive.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // btnBrowseFtp
            // 
            this.btnBrowseFtp.AutoSize = true;
            this.btnBrowseFtp.Location = new System.Drawing.Point(562, 145);
            this.btnBrowseFtp.Name = "btnBrowseFtp";
            this.btnBrowseFtp.Size = new System.Drawing.Size(81, 27);
            this.btnBrowseFtp.TabIndex = 24;
            this.btnBrowseFtp.Text = "&Browse";
            this.btnBrowseFtp.UseVisualStyleBackColor = true;
            this.btnBrowseFtp.Click += new System.EventHandler(this.btnBrowseFtp_Click);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(24, 224);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(80, 17);
            this.label11.TabIndex = 23;
            this.label11.Text = "New Name:";
            // 
            // txtFtpNewName
            // 
            this.txtFtpNewName.Location = new System.Drawing.Point(113, 221);
            this.txtFtpNewName.Name = "txtFtpNewName";
            this.txtFtpNewName.Size = new System.Drawing.Size(443, 22);
            this.txtFtpNewName.TabIndex = 22;
            // 
            // btnMacroFTP
            // 
            this.btnMacroFTP.AutoSize = true;
            this.btnMacroFTP.Location = new System.Drawing.Point(562, 219);
            this.btnMacroFTP.Name = "btnMacroFTP";
            this.btnMacroFTP.Size = new System.Drawing.Size(81, 27);
            this.btnMacroFTP.TabIndex = 21;
            this.btnMacroFTP.Text = "&Macro";
            this.btnMacroFTP.UseVisualStyleBackColor = true;
            this.btnMacroFTP.Click += new System.EventHandler(this.btnMacroFTP_Click);
            // 
            // chkFTPSubdirectories
            // 
            this.chkFTPSubdirectories.AutoSize = true;
            this.chkFTPSubdirectories.Location = new System.Drawing.Point(113, 184);
            this.chkFTPSubdirectories.Margin = new System.Windows.Forms.Padding(4);
            this.chkFTPSubdirectories.Name = "chkFTPSubdirectories";
            this.chkFTPSubdirectories.Size = new System.Drawing.Size(109, 21);
            this.chkFTPSubdirectories.TabIndex = 19;
            this.chkFTPSubdirectories.Text = "Is Directory?";
            this.chkFTPSubdirectories.UseVisualStyleBackColor = true;
            this.chkFTPSubdirectories.CheckedChanged += new System.EventHandler(this.chkFTPSubdirectories_CheckedChanged);
            // 
            // txtFTP_Path
            // 
            this.txtFTP_Path.Location = new System.Drawing.Point(113, 147);
            this.txtFTP_Path.Margin = new System.Windows.Forms.Padding(4);
            this.txtFTP_Path.Name = "txtFTP_Path";
            this.txtFTP_Path.Size = new System.Drawing.Size(443, 22);
            this.txtFTP_Path.TabIndex = 18;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(17, 151);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(87, 17);
            this.label10.TabIndex = 17;
            this.label10.Text = "Server Path:";
            // 
            // txtFTP_Password
            // 
            this.txtFTP_Password.Location = new System.Drawing.Point(355, 107);
            this.txtFTP_Password.Margin = new System.Windows.Forms.Padding(4);
            this.txtFTP_Password.Name = "txtFTP_Password";
            this.txtFTP_Password.Size = new System.Drawing.Size(160, 22);
            this.txtFTP_Password.TabIndex = 16;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(280, 109);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(73, 17);
            this.label7.TabIndex = 15;
            this.label7.Text = "Password:";
            // 
            // txtFTP_UserName
            // 
            this.txtFTP_UserName.Location = new System.Drawing.Point(112, 106);
            this.txtFTP_UserName.Margin = new System.Windows.Forms.Padding(4);
            this.txtFTP_UserName.Name = "txtFTP_UserName";
            this.txtFTP_UserName.Size = new System.Drawing.Size(160, 22);
            this.txtFTP_UserName.TabIndex = 14;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(22, 110);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(83, 17);
            this.label8.TabIndex = 13;
            this.label8.Text = "User Name:";
            // 
            // cmbFTP_LogonType
            // 
            this.cmbFTP_LogonType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFTP_LogonType.FormattingEnabled = true;
            this.cmbFTP_LogonType.Items.AddRange(new object[] {
            "Anonymous",
            "Normal"});
            this.cmbFTP_LogonType.Location = new System.Drawing.Point(396, 59);
            this.cmbFTP_LogonType.Margin = new System.Windows.Forms.Padding(4);
            this.cmbFTP_LogonType.Name = "cmbFTP_LogonType";
            this.cmbFTP_LogonType.Size = new System.Drawing.Size(160, 24);
            this.cmbFTP_LogonType.TabIndex = 12;
            this.cmbFTP_LogonType.SelectedIndexChanged += new System.EventHandler(this.cmbFTP_LogonType_SelectedIndexChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(291, 62);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(88, 17);
            this.label6.TabIndex = 11;
            this.label6.Text = "Logon Type:";
            // 
            // txtFTP_Port
            // 
            this.txtFTP_Port.Location = new System.Drawing.Point(524, 18);
            this.txtFTP_Port.Margin = new System.Windows.Forms.Padding(4);
            this.txtFTP_Port.Name = "txtFTP_Port";
            this.txtFTP_Port.Size = new System.Drawing.Size(132, 22);
            this.txtFTP_Port.TabIndex = 10;
            this.txtFTP_Port.Text = "21";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(477, 22);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(38, 17);
            this.label5.TabIndex = 9;
            this.label5.Text = "Port:";
            // 
            // cmbFTP_Protocol
            // 
            this.cmbFTP_Protocol.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFTP_Protocol.FormattingEnabled = true;
            this.cmbFTP_Protocol.Items.AddRange(new object[] {
            "FTP",
            "SFTP"});
            this.cmbFTP_Protocol.Location = new System.Drawing.Point(113, 58);
            this.cmbFTP_Protocol.Margin = new System.Windows.Forms.Padding(4);
            this.cmbFTP_Protocol.Name = "cmbFTP_Protocol";
            this.cmbFTP_Protocol.Size = new System.Drawing.Size(160, 24);
            this.cmbFTP_Protocol.TabIndex = 8;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(40, 62);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(64, 17);
            this.label4.TabIndex = 7;
            this.label4.Text = "Protocol:";
            // 
            // txtFTP_Host
            // 
            this.txtFTP_Host.Location = new System.Drawing.Point(113, 18);
            this.txtFTP_Host.Margin = new System.Windows.Forms.Padding(4);
            this.txtFTP_Host.Name = "txtFTP_Host";
            this.txtFTP_Host.Size = new System.Drawing.Size(355, 22);
            this.txtFTP_Host.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(63, 22);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 17);
            this.label3.TabIndex = 5;
            this.label3.Text = "Host:";
            // 
            // tbNetworkFolder
            // 
            this.tbNetworkFolder.Controls.Add(this.btnBrowseNetworkFolder);
            this.tbNetworkFolder.Controls.Add(this.btnMacroNetwork);
            this.tbNetworkFolder.Controls.Add(this.txtNetworkNewName);
            this.tbNetworkFolder.Controls.Add(this.label18);
            this.tbNetworkFolder.Controls.Add(this.txtNetworkPath);
            this.tbNetworkFolder.Controls.Add(this.label12);
            this.tbNetworkFolder.Location = new System.Drawing.Point(4, 25);
            this.tbNetworkFolder.Margin = new System.Windows.Forms.Padding(4);
            this.tbNetworkFolder.Name = "tbNetworkFolder";
            this.tbNetworkFolder.Size = new System.Drawing.Size(680, 273);
            this.tbNetworkFolder.TabIndex = 2;
            this.tbNetworkFolder.Text = "Network Folder";
            this.tbNetworkFolder.UseVisualStyleBackColor = true;
            // 
            // btnBrowseNetworkFolder
            // 
            this.btnBrowseNetworkFolder.AutoSize = true;
            this.btnBrowseNetworkFolder.Location = new System.Drawing.Point(572, 21);
            this.btnBrowseNetworkFolder.Name = "btnBrowseNetworkFolder";
            this.btnBrowseNetworkFolder.Size = new System.Drawing.Size(80, 27);
            this.btnBrowseNetworkFolder.TabIndex = 12;
            this.btnBrowseNetworkFolder.Text = "Browse";
            this.btnBrowseNetworkFolder.UseVisualStyleBackColor = true;
            this.btnBrowseNetworkFolder.Click += new System.EventHandler(this.btnBrowseNetworkFolder_Click);
            // 
            // btnMacroNetwork
            // 
            this.btnMacroNetwork.AutoSize = true;
            this.btnMacroNetwork.Location = new System.Drawing.Point(571, 64);
            this.btnMacroNetwork.Name = "btnMacroNetwork";
            this.btnMacroNetwork.Size = new System.Drawing.Size(81, 27);
            this.btnMacroNetwork.TabIndex = 7;
            this.btnMacroNetwork.Text = "Macro";
            this.btnMacroNetwork.UseVisualStyleBackColor = true;
            this.btnMacroNetwork.Click += new System.EventHandler(this.btnMacroNetwork_Click);
            // 
            // txtNetworkNewName
            // 
            this.txtNetworkNewName.Location = new System.Drawing.Point(127, 66);
            this.txtNetworkNewName.Margin = new System.Windows.Forms.Padding(4);
            this.txtNetworkNewName.Name = "txtNetworkNewName";
            this.txtNetworkNewName.Size = new System.Drawing.Size(436, 22);
            this.txtNetworkNewName.TabIndex = 6;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(35, 69);
            this.label18.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(80, 17);
            this.label18.TabIndex = 5;
            this.label18.Text = "New Name:";
            // 
            // txtNetworkPath
            // 
            this.txtNetworkPath.Location = new System.Drawing.Point(127, 23);
            this.txtNetworkPath.Margin = new System.Windows.Forms.Padding(4);
            this.txtNetworkPath.Name = "txtNetworkPath";
            this.txtNetworkPath.Size = new System.Drawing.Size(436, 22);
            this.txtNetworkPath.TabIndex = 11;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(19, 27);
            this.label12.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(96, 17);
            this.label12.TabIndex = 10;
            this.label12.Text = "Network Path:";
            // 
            // tbDropbox
            // 
            this.tbDropbox.Controls.Add(this.btnMacroDropbox);
            this.tbDropbox.Controls.Add(this.label17);
            this.tbDropbox.Controls.Add(this.txtDropboxFileNewName);
            this.tbDropbox.Controls.Add(this.txtDropboxPath);
            this.tbDropbox.Controls.Add(this.label15);
            this.tbDropbox.Location = new System.Drawing.Point(4, 25);
            this.tbDropbox.Margin = new System.Windows.Forms.Padding(4);
            this.tbDropbox.Name = "tbDropbox";
            this.tbDropbox.Size = new System.Drawing.Size(680, 273);
            this.tbDropbox.TabIndex = 3;
            this.tbDropbox.Text = "Dropbox";
            this.tbDropbox.UseVisualStyleBackColor = true;
            // 
            // btnMacroDropbox
            // 
            this.btnMacroDropbox.AutoSize = true;
            this.btnMacroDropbox.Location = new System.Drawing.Point(579, 72);
            this.btnMacroDropbox.Name = "btnMacroDropbox";
            this.btnMacroDropbox.Size = new System.Drawing.Size(81, 27);
            this.btnMacroDropbox.TabIndex = 7;
            this.btnMacroDropbox.Text = "Macro";
            this.btnMacroDropbox.UseVisualStyleBackColor = true;
            this.btnMacroDropbox.Click += new System.EventHandler(this.btnMacroDropbox_Click);
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(51, 78);
            this.label17.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(75, 17);
            this.label17.TabIndex = 18;
            this.label17.Text = "File Name:";
            // 
            // txtDropboxFileNewName
            // 
            this.txtDropboxFileNewName.Location = new System.Drawing.Point(135, 74);
            this.txtDropboxFileNewName.Margin = new System.Windows.Forms.Padding(4);
            this.txtDropboxFileNewName.Name = "txtDropboxFileNewName";
            this.txtDropboxFileNewName.Size = new System.Drawing.Size(437, 22);
            this.txtDropboxFileNewName.TabIndex = 19;
            // 
            // txtDropboxPath
            // 
            this.txtDropboxPath.Location = new System.Drawing.Point(135, 26);
            this.txtDropboxPath.Margin = new System.Windows.Forms.Padding(4);
            this.txtDropboxPath.Name = "txtDropboxPath";
            this.txtDropboxPath.Size = new System.Drawing.Size(525, 22);
            this.txtDropboxPath.TabIndex = 13;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(29, 30);
            this.label15.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(95, 17);
            this.label15.TabIndex = 12;
            this.label15.Text = "Dropbox Link:";
            // 
            // tbGdrive
            // 
            this.tbGdrive.Controls.Add(this.btnMacroGDrive);
            this.tbGdrive.Controls.Add(this.txtGDriveFileNewName);
            this.tbGdrive.Controls.Add(this.label20);
            this.tbGdrive.Controls.Add(this.txtGoogleDrivePath);
            this.tbGdrive.Controls.Add(this.label16);
            this.tbGdrive.Location = new System.Drawing.Point(4, 25);
            this.tbGdrive.Margin = new System.Windows.Forms.Padding(4);
            this.tbGdrive.Name = "tbGdrive";
            this.tbGdrive.Size = new System.Drawing.Size(680, 273);
            this.tbGdrive.TabIndex = 4;
            this.tbGdrive.Text = "Google Drive";
            this.tbGdrive.UseVisualStyleBackColor = true;
            // 
            // btnMacroGDrive
            // 
            this.btnMacroGDrive.AutoSize = true;
            this.btnMacroGDrive.Location = new System.Drawing.Point(573, 63);
            this.btnMacroGDrive.Name = "btnMacroGDrive";
            this.btnMacroGDrive.Size = new System.Drawing.Size(81, 27);
            this.btnMacroGDrive.TabIndex = 7;
            this.btnMacroGDrive.Text = "Macro";
            this.btnMacroGDrive.UseVisualStyleBackColor = true;
            this.btnMacroGDrive.Click += new System.EventHandler(this.btnMacroGDrive_Click);
            // 
            // txtGDriveFileNewName
            // 
            this.txtGDriveFileNewName.Location = new System.Drawing.Point(167, 65);
            this.txtGDriveFileNewName.Margin = new System.Windows.Forms.Padding(4);
            this.txtGDriveFileNewName.Name = "txtGDriveFileNewName";
            this.txtGDriveFileNewName.Size = new System.Drawing.Size(396, 22);
            this.txtGDriveFileNewName.TabIndex = 17;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(77, 68);
            this.label20.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(80, 17);
            this.label20.TabIndex = 5;
            this.label20.Text = "New Name:";
            this.label20.Click += new System.EventHandler(this.label20_Click);
            // 
            // txtGoogleDrivePath
            // 
            this.txtGoogleDrivePath.Location = new System.Drawing.Point(167, 22);
            this.txtGoogleDrivePath.Margin = new System.Windows.Forms.Padding(4);
            this.txtGoogleDrivePath.Name = "txtGoogleDrivePath";
            this.txtGoogleDrivePath.Size = new System.Drawing.Size(487, 22);
            this.txtGoogleDrivePath.TabIndex = 15;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(32, 26);
            this.label16.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(125, 17);
            this.label16.TabIndex = 14;
            this.label16.Text = "Google Drive Link:";
            // 
            // tbRss
            // 
            this.tbRss.Controls.Add(this.btnMacroRss);
            this.tbRss.Controls.Add(this.txtRssNewFileName);
            this.tbRss.Controls.Add(this.label13);
            this.tbRss.Controls.Add(this.txtRssPath);
            this.tbRss.Controls.Add(this.label14);
            this.tbRss.Location = new System.Drawing.Point(4, 25);
            this.tbRss.Margin = new System.Windows.Forms.Padding(4);
            this.tbRss.Name = "tbRss";
            this.tbRss.Size = new System.Drawing.Size(680, 273);
            this.tbRss.TabIndex = 5;
            this.tbRss.Text = "RSS";
            this.tbRss.UseVisualStyleBackColor = true;
            // 
            // btnMacroRss
            // 
            this.btnMacroRss.AutoSize = true;
            this.btnMacroRss.Location = new System.Drawing.Point(576, 70);
            this.btnMacroRss.Name = "btnMacroRss";
            this.btnMacroRss.Size = new System.Drawing.Size(81, 27);
            this.btnMacroRss.TabIndex = 8;
            this.btnMacroRss.Text = "Macro";
            this.btnMacroRss.UseVisualStyleBackColor = true;
            this.btnMacroRss.Click += new System.EventHandler(this.button4_Click);
            // 
            // txtRssNewFileName
            // 
            this.txtRssNewFileName.Location = new System.Drawing.Point(132, 72);
            this.txtRssNewFileName.Margin = new System.Windows.Forms.Padding(4);
            this.txtRssNewFileName.Name = "txtRssNewFileName";
            this.txtRssNewFileName.Size = new System.Drawing.Size(437, 22);
            this.txtRssNewFileName.TabIndex = 6;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(41, 75);
            this.label13.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(80, 17);
            this.label13.TabIndex = 5;
            this.label13.Text = "New Name:";
            // 
            // txtRssPath
            // 
            this.txtRssPath.Location = new System.Drawing.Point(132, 26);
            this.txtRssPath.Margin = new System.Windows.Forms.Padding(4);
            this.txtRssPath.Name = "txtRssPath";
            this.txtRssPath.Size = new System.Drawing.Size(525, 22);
            this.txtRssPath.TabIndex = 15;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(51, 30);
            this.label14.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(70, 17);
            this.label14.TabIndex = 14;
            this.label14.Text = "RSS Link:";
            // 
            // btnBrowse
            // 
            this.btnBrowse.Location = new System.Drawing.Point(592, 330);
            this.btnBrowse.Margin = new System.Windows.Forms.Padding(4);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(108, 28);
            this.btnBrowse.TabIndex = 2;
            this.btnBrowse.Text = "Browse";
            this.btnBrowse.UseVisualStyleBackColor = true;
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // txtDownloadPath
            // 
            this.txtDownloadPath.Location = new System.Drawing.Point(135, 332);
            this.txtDownloadPath.Margin = new System.Windows.Forms.Padding(4);
            this.txtDownloadPath.Name = "txtDownloadPath";
            this.txtDownloadPath.ReadOnly = true;
            this.txtDownloadPath.Size = new System.Drawing.Size(448, 22);
            this.txtDownloadPath.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(37, 336);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Output Path:";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // btnOk
            // 
            this.btnOk.AutoSize = true;
            this.btnOk.Location = new System.Drawing.Point(522, 375);
            this.btnOk.Margin = new System.Windows.Forms.Padding(4);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(84, 28);
            this.btnOk.TabIndex = 1;
            this.btnOk.Text = "Ok";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.AutoSize = true;
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(625, 376);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 27);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // dlgSelectFile
            // 
            this.dlgSelectFile.ShowReadOnly = true;
            this.dlgSelectFile.Title = "Select File";
            // 
            // ScheduleTypeEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(720, 417);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.scheduleTabs);
            this.Controls.Add(this.btnBrowse);
            this.Controls.Add(this.txtDownloadPath);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ScheduleTypeEditor";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Schedule Type Configuration";
            this.Load += new System.EventHandler(this.ScheduleTypeEditor_Load);
            this.scheduleTabs.ResumeLayout(false);
            this.tbHTTP.ResumeLayout(false);
            this.tbHTTP.PerformLayout();
            this.tbFTP.ResumeLayout(false);
            this.tbFTP.PerformLayout();
            this.tbNetworkFolder.ResumeLayout(false);
            this.tbNetworkFolder.PerformLayout();
            this.tbDropbox.ResumeLayout(false);
            this.tbDropbox.PerformLayout();
            this.tbGdrive.ResumeLayout(false);
            this.tbGdrive.PerformLayout();
            this.tbRss.ResumeLayout(false);
            this.tbRss.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnBrowse;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnOk;
        public System.Windows.Forms.TextBox txtDownloadPath;
        public System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.Label label2;
        public System.Windows.Forms.TextBox txtHttpLink;
        public System.Windows.Forms.TextBox txtFTP_Host;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label7;
        public System.Windows.Forms.TextBox txtFTP_UserName;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label9;
        public System.Windows.Forms.TextBox txtHttpNewName;
        public System.Windows.Forms.ComboBox cmbFTP_Protocol;
        public System.Windows.Forms.TextBox txtFTP_Port;
        public System.Windows.Forms.TextBox txtFTP_Password;
        public System.Windows.Forms.ComboBox cmbFTP_LogonType;
        public System.Windows.Forms.TabPage tbHTTP;
        public System.Windows.Forms.TabPage tbFTP;
        public System.Windows.Forms.TabControl scheduleTabs;
        public System.Windows.Forms.TextBox txtFTP_Path;
        private System.Windows.Forms.Label label10;
        public System.Windows.Forms.CheckBox chkFTPSubdirectories;
        public System.Windows.Forms.TextBox txtNetworkPath;
        private System.Windows.Forms.Label label12;
        public System.Windows.Forms.TextBox txtDropboxPath;
        private System.Windows.Forms.Label label15;
        public System.Windows.Forms.TextBox txtGoogleDrivePath;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label13;
        public System.Windows.Forms.TextBox txtRssNewFileName;
        public System.Windows.Forms.TextBox txtRssPath;
        private System.Windows.Forms.Label label14;
        public System.Windows.Forms.TabPage tbNetworkFolder;
        public System.Windows.Forms.TabPage tbDropbox;
        public System.Windows.Forms.TabPage tbGdrive;
        public System.Windows.Forms.TabPage tbRss;
        private System.Windows.Forms.Label label17;
        public System.Windows.Forms.TextBox txtDropboxFileNewName;
        public System.Windows.Forms.TextBox txtGDriveFileNewName;
        private System.Windows.Forms.Button btnMacroHttp;
        private System.Windows.Forms.Button btnMacroNetwork;
        private System.Windows.Forms.Label label18;
        public System.Windows.Forms.TextBox txtNetworkNewName;
        private System.Windows.Forms.Button btnMacroDropbox;
        private System.Windows.Forms.Button btnMacroGDrive;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Button btnMacroRss;
        private System.Windows.Forms.Button btnBrowseNetworkFolder;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button btnBrowseFtp;
        public System.Windows.Forms.Button btnMacroFTP;
        public System.Windows.Forms.TextBox txtFtpNewName;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserNetwork;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.OpenFileDialog dlgSelectFile;
        public System.Windows.Forms.CheckBox chkFTP_IsPassive;
    }
}