// Form used for testing FtpBrowseDialog control

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using BuckSoft.Controls.FtpBrowseDialog;

namespace TestApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FtpBrowseDialog ftp = new FtpBrowseDialog();
            ftp.TestMode = testmode.Checked;
            if (ftp.ShowDialog() == DialogResult.OK)
            {
                if (webfriendly.Checked == true) listBox1.Items.Add(ftp.SelectedFileUrl);
                else listBox1.Items.Add(ftp.SelectedFile);
            }
        }
    }
}