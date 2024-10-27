using BrowseNetworkFolders;
using BuckSoft.Controls.FtpBrowseDialog;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Thornton.Scheduler
{
    public partial class ScheduleTypeEditor : Form
    {
        public ScheduleTypeEditor()
        {
            InitializeComponent();
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            folderBrowserDialog1.ShowDialog();
            txtDownloadPath.Text = folderBrowserDialog1.SelectedPath;
        }

        //string newLine = "\n";
        private void btnOk_Click(object sender, EventArgs e)
        {
            bool valid = true;
            string message = string.Empty;

            if (scheduleTabs.SelectedTab == tbHTTP)
            {
                if (string.IsNullOrWhiteSpace(txtHttpLink.Text))
                {
                    valid = false;

                    message += "Please specify HTTP/S link.\n";
                }

                if (string.IsNullOrWhiteSpace(txtHttpNewName.Text))
                {
                    valid = false;

                    message += "Please specify file name.\n";
                }
            }
            else if (scheduleTabs.SelectedTab == tbFTP)
            {
                if (string.IsNullOrWhiteSpace(txtFTP_Path.Text))
                {
                    valid = false;

                    message += "Please specify FTP Path.\n";
                }

                if (string.IsNullOrWhiteSpace(txtFtpNewName.Text) && chkFTPSubdirectories.Checked)
                {
                    valid = false;

                    message += "Please specify file name.\n";
                }
            }
            else if (scheduleTabs.SelectedTab == tbNetworkFolder)
            {
                if (string.IsNullOrWhiteSpace(txtNetworkPath.Text))
                {
                    valid = false;

                    message += "Please specify Network Path.\n";
                }

                if (string.IsNullOrWhiteSpace(txtNetworkNewName.Text))
                {
                    valid = false;

                    message += "Please specify file name.\n";
                }
            }
            else if (scheduleTabs.SelectedTab == tbGdrive)
            {
                if (string.IsNullOrWhiteSpace(txtGoogleDrivePath.Text))
                {
                    valid = false;

                    message += "Please specify Google Drive link.\n";
                }

                if (string.IsNullOrWhiteSpace(txtGDriveFileNewName.Text))
                {
                    valid = false;

                    message += "Please specify file name.\n";
                }
            }
            else if (scheduleTabs.SelectedTab == tbDropbox)
            {
                if (string.IsNullOrWhiteSpace(txtDropboxPath.Text))
                {
                    valid = false;

                    message += "Please specify Dropbox link.\n";
                }

                if (string.IsNullOrWhiteSpace(txtDropboxFileNewName.Text))
                {
                    valid = false;

                    message += "Please specify file name.\n";
                }
            }
            else if (scheduleTabs.SelectedTab == tbRss)
            {
                if (string.IsNullOrWhiteSpace(txtRssPath.Text))
                {
                    valid = false;

                    message += "Please specify RSS link.\n";
                }

                if (string.IsNullOrWhiteSpace(txtRssNewFileName.Text))
                {
                    valid = false;

                    message += "Please specify file name.\n";
                }
            }

            if (valid)
            {
                this.Close();
            }
            else
            {
                MessageBox.Show(message);
            }
        }

        private void ScheduleTypeEditor_Load(object sender, EventArgs e)
        {
            folderBrowserDialog1.SelectedPath = txtDownloadPath.Text;

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void cmbFTP_LogonType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbFTP_LogonType.SelectedIndex == 0)
            {
                txtFTP_UserName.Enabled = false;
                txtFTP_Password.Enabled = false;
                txtFTP_UserName.Text = "";
                txtFTP_Password.Text = "";
            }
            else
            {
                txtFTP_UserName.Enabled = true;
                txtFTP_Password.Enabled = true;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtHttpNewName.Text))
            {
                MessageBox.Show("Please enter file name");
            }
            else if (!txtHttpNewName.Text.Contains("."))
            {
                MessageBox.Show("Please enter valid file name");
            }
            else
            {
                var builder = new MacroBuilder();
                builder.MacroText = txtRssNewFileName.Text;
                if (builder.ShowDialog() == DialogResult.OK)
                {
                    txtRssNewFileName.Text = builder.MacroText;
                }
            }
        }

        private void btnMacroHttp_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtHttpNewName.Text))
            {
                MessageBox.Show("Please enter file name");
            }
            else if (!txtHttpNewName.Text.Contains("."))
            {
                MessageBox.Show("Please enter valid file name");
            }
            else
            {
                var builder = new MacroBuilder();
                builder.MacroText = txtHttpNewName.Text;
                if (builder.ShowDialog() == DialogResult.OK)
                {
                    txtHttpNewName.Text = builder.MacroText;
                }
            }
        }

        private void btnMacroNetwork_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNetworkNewName.Text))
            {
                MessageBox.Show("Please enter file name");
            }
            else if (!txtNetworkNewName.Text.Contains("."))
            {
                MessageBox.Show("Please enter valid file name");
            }

            else
            {
                var builder = new MacroBuilder();
                builder.MacroText = txtNetworkNewName.Text;
                if (builder.ShowDialog() == DialogResult.OK)
                {
                    txtNetworkNewName.Text = builder.MacroText;
                }
            }
        }

        private void btnMacroDropbox_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtDropboxFileNewName.Text))
            {
                MessageBox.Show("Please enter file name");
            }
            else if (!txtDropboxFileNewName.Text.Contains("."))
            {
                MessageBox.Show("Please enter valid file name");
            }
            else
            {
                var builder = new MacroBuilder();
                builder.MacroText = txtDropboxFileNewName.Text;
                if (builder.ShowDialog() == DialogResult.OK)
                {
                    txtDropboxFileNewName.Text = builder.MacroText;
                }
            }
        }

        private void btnMacroGDrive_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtGDriveFileNewName.Text))
            {
                MessageBox.Show("Please enter file name");
            }
            else if (!txtGDriveFileNewName.Text.Contains("."))
            {
                MessageBox.Show("Please enter valid file name");
            }
            else
            {
                var builder = new MacroBuilder();
                builder.MacroText = txtGDriveFileNewName.Text;
                if (builder.ShowDialog() == DialogResult.OK)
                {
                    txtGDriveFileNewName.Text = builder.MacroText;
                }
            }
        }

        private void label20_Click(object sender, EventArgs e)
        {

        }

        private void chkFTPSubdirectories_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox chk = (CheckBox)sender;
            
            txtFtpNewName.Enabled = !chk.Checked;
            btnMacroFTP.Enabled = !chk.Enabled;
        }

        private void btnMacroFTP_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtFtpNewName.Text))
            {
                MessageBox.Show("Please enter file name");
            }
            else if (!txtFtpNewName.Text.Contains("."))
            {
                MessageBox.Show("Please enter valid file name");
            }

            else
            {
                var builder = new MacroBuilder();
                builder.MacroText = txtFtpNewName.Text;
                if (builder.ShowDialog() == DialogResult.OK)
                {
                    txtFtpNewName.Text = builder.MacroText;
                }
            }
        }

        private void btnBrowseFtp_Click(object sender, EventArgs e)
        {
            FtpBrowseDialog browse = new FtpBrowseDialog(txtFTP_Host.Text, "/", Convert.ToInt32(txtFTP_Port.Text), txtFTP_UserName.Text, txtFTP_Password.Text, chkFTP_IsPassive.Checked);
           

            if (browse.ShowDialog() == DialogResult.OK)
            {
                Uri uriAddress = new Uri(browse.SelectedFile);

                //Console.WriteLine("{0}", uriAddress.AbsolutePath);
                txtFTP_Path.Text = uriAddress.AbsolutePath;
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void btnBrowseNetworkFolder_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog browser = new FolderBrowserDialog();
            //frmBrowseNetwork network = new frmBrowseNetwork();
            txtNetworkPath.Text = frmBrowseNetwork.GetNetworkFolders(browser);
            btnBrowseFile_Click(sender, e);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnBrowseFile_Click(object sender, EventArgs e)
        {
            //if (string.IsNullOrWhiteSpace(txtNetworkPath.Text))
            //{
            //    MessageBox.Show("Please select network path");
            //}
            //else
            //{
            dlgSelectFile.InitialDirectory = txtNetworkPath.Text;
            if (dlgSelectFile.ShowDialog() == DialogResult.OK)
            {
                txtNetworkPath.Text = dlgSelectFile.FileName;
                //string fileName = dlgSelectFile.FileName;
                //int LastIndex = fileName.LastIndexOf(@"\");
                //int Length = fileName.Length;
                //Console.WriteLine(LastIndex);
                //Console.WriteLine();
                //txtNetworkNewName.Text = fileName.Substring(LastIndex + 1, Length - LastIndex - 1);
            }
            //}
        }

        public static string ExtractFilename(string filepath)
        {
            // If path ends with a "\", it's a path only so return String.Empty.
            if (filepath.Trim().EndsWith(@"\"))
                return String.Empty;

            // Determine where last backslash is.
            int position = filepath.LastIndexOf('\\');
            // If there is no backslash, assume that this is a filename.
            if (position == -1)
            {
                // Determine whether file exists in the current directory.
                if (File.Exists(Environment.CurrentDirectory + Path.DirectorySeparatorChar + filepath))
                    return filepath;
                else
                    return String.Empty;
            }
            else
            {
                // Determine whether file exists using filepath.
                if (File.Exists(filepath))
                    // Return filename without file path.
                    return filepath.Substring(position + 1);
                else
                    return String.Empty;
            }
        }
    }
}
