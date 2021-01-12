
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace NineGongge
{
    public partial class LatticeControl4 : UserControl
    {
        public LatticeControl4()
        {
            InitializeComponent();
            InitColor();
            this.Load += (s, e) => 
            {
                BestFitCells();
            };
            this.SizeChanged += (s, e) => 
            {
                BestFitCells();
            };
        }
        string IPUrl = GetValue("IPAddress");
        private void InitColor()
        {
            int i = DateTime.Now.GetHashCode();
            foreach (Control ctrl in flowLayoutPanel1.Controls)
            {
                var rand = new Random(i);
                int r = rand.Next(0, 255);
                int g = rand.Next(0, 255);
                int b = rand.Next(0, 255);
                ctrl.BackColor = Color.FromArgb(255, r, g, b);
            }
        }

        private void BestFitCells()
        {
            int m = 4;//margin
            int w = flowLayoutPanel1.Width - 4 * m;
            int y = flowLayoutPanel1.Height - 4 * m;

            int fw = w / 2;
            int fy = y / 2;
            foreach(Control ctrl in flowLayoutPanel1.Controls)
            {
                ctrl.Width = fw;
                ctrl.Height = fy;
            }
        }
        public static string GetValue(string key)
        {
            System.Configuration.Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            if (config.AppSettings.Settings[key] == null)
                return "";
            else
                return config.AppSettings.Settings[key].Value;
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            InitColor();
            timer1.Enabled = false;
        }
    }
}
