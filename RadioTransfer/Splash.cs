using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Thornton.Scheduler.Service
{
    public partial class Splash : Form
    {
        private int i = 0;
        public Splash()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            i++;
            if (i == 100)
                this.Close();
        }

        public bool IsTrial { set {
                if (value==false)
                {
                    lblIsTrial.Text = "";
                }
            } }
    }
}
