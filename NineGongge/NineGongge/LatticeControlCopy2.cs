using Gecko;
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
    public partial class LatticeControlCopy2 : UserControl
    {
        GeckoWebBrowser geckoWebBrowser = new GeckoWebBrowser();
        public LatticeControlCopy2()
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
            //int i = DateTime.Now.GetHashCode();
            //foreach (Control ctrl in flowLayoutPanel1.Controls)
            //{
            //    var rand = new Random(i);
            //    int r = rand.Next(0, 255);
            //    int g = rand.Next(0, 255);
            //    int b = rand.Next(0, 255);
            //    ctrl.BackColor = Color.FromArgb(255, r, g, b);
            //}
            TempMethod(panel1, string.Format("{0}{1}", IPUrl, "/OperationMonitoring/BusinessOverview/Index"));
            TempMethod(panel2, string.Format("{0}{1}", IPUrl, "/AutomationLine/RunningState/Index"));
            TempMethod(panel3, string.Format("{0}{1}", IPUrl, "/AutomationLine/DataAcquisition/Index"));
            TempMethod(panel4, string.Format("{0}{1}", IPUrl, "/ProductionManage/ProductionManageHome/Index"));
            TempMethod(panel5, string.Format("{0}{1}", IPUrl, "/OperationMonitoring/EngineeringHomepage/Index"));
            TempMethod(panel6, string.Format("{0}{1}", IPUrl, "/QualityOptimization/QualityEngineering/Index"));
            TempMethod(panel7, string.Format("{0}{1}", IPUrl, "/TeamTask/CNCTeam/Index"));
            TempMethod(panel8, string.Format("{0}{1}", IPUrl, "/TeamTask/EdmTeam/Index"));
            TempMethod(panel9, string.Format("{0}{1}", IPUrl, "/TeamTask/WETeam/Index"));
        }

        private void BestFitCells()
        {
            int m = 4;//margin
            int w = flowLayoutPanel1.Width - 6 * m;
            int y = flowLayoutPanel1.Height - 6 * m;

            int fw = w / 3;
            int fy = y / 3;
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
        public void TempMethod(Panel tempPanel, string tempUrl)
        {
            string xulrunnerPath = Path.GetDirectoryName(this.GetType().Assembly.Location) + "\\xulrunner";
            Xpcom.Initialize(xulrunnerPath);
            geckoWebBrowser = new GeckoWebBrowser { Dock = DockStyle.Fill };
            this.Controls.Add(geckoWebBrowser);
            geckoWebBrowser.DocumentCompleted += geckoWebBrowser_DocumentCompleted;
            geckoWebBrowser.Navigate(string.Format("{0}{1}", IPUrl, "/FastLogin/Index?accounts=admin"));
            Thread.Sleep(1);
            geckoWebBrowser.Navigate(tempUrl);
            geckoWebBrowser.CreateWindow += GeckoWebBrowser_CreateWindow;
            tempPanel.Controls.Clear();
            tempPanel.Controls.Add(geckoWebBrowser);
        }
        private void geckoWebBrowser_DocumentCompleted(object sender, Gecko.Events.GeckoDocumentCompletedEventArgs e)
        {

            //_blank	在新窗口中打开被链接文档。
            //_self 默认。在相同的框架中打开被链接文档。
            //_parent 在父框架集中打开被链接文档。
            //_top 在整个窗口中打开被链接文档。
            //framename 在指定的框架中打开被链接文档。

            //将所有的链接的目标，指向本窗体 
            foreach (GeckoHtmlElement archor in this.geckoWebBrowser.Document.Links)
            {
                archor.SetAttribute("target", "_self");
            }
            //将所有的FORM的提交目标，指向本窗体
            foreach (GeckoHtmlElement form in this.geckoWebBrowser.Document.Forms)
            {
                form.SetAttribute("target", "_self");
            }
        }
        private void GeckoWebBrowser_CreateWindow(object sender, GeckoCreateWindowEventArgs e)
        {
            e.WebBrowser = this.geckoWebBrowser;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            InitColor();
            timer1.Enabled = false;
        }
    }
}
