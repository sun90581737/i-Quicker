using CefSharp;
using CefSharp.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NineGongge
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            InitColor();
            this.Load += (s, j) =>
            {
                BestFitCells();
            };
            this.SizeChanged += (s, j) =>
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
            int m = 0;//margin
            int w = flowLayoutPanel1.Width - 6 * m;
            int y = flowLayoutPanel1.Height - 6 * m;

            int fw = w / 3;
            int fy = y / 3;
            foreach (Control ctrl in flowLayoutPanel1.Controls)
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
            if (!CefSharp.Cef.IsInitialized)
            {
                var setting = new CefSettings
                {
                    Locale = "zh-CN",
                    AcceptLanguageList = "zh-CN,zh;q=0.8",
                    LocalesDirPath = "CHBrowser/localeDir",
                    LogFile = "CHBrowser/LogData",
                    PersistSessionCookies = true,
                    UserAgent = "Mozilla/5.0 (Windows NT 6.1; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/55.0.2883.87 Safari/537.36",
                    UserDataPath = "CHBrowser/userData"
                };
                setting.CefCommandLineArgs.Add("disable-gpu", "1");
                CefSharpSettings.LegacyJavascriptBindingEnabled = true;
                CefSharp.Cef.Initialize(setting);
                CefSharp.Cef.EnableHighDPISupport();

            }
            CefSharp.WinForms.ChromiumWebBrowser wb2 = new CefSharp.WinForms.ChromiumWebBrowser(string.Format("{0}{1}", IPUrl, "/FastLogin/Index?accounts=admin"));
            wb2.Dock = DockStyle.Fill;
            //wb2.FrameLoadEnd += webbrowser_FrameLoadEnd;//浏览器缩放
            tempPanel.Controls.Clear();
            tempPanel.Controls.Add(wb2);

            Thread th = new Thread(() =>
            {
                Thread.Sleep(20000);
                this.Invoke((Action)delegate
                {
                    wb2.Load(tempUrl);
                });
            });
            th.Start();
        }

        const int WM_SYSCOMMAND = 0x112;
        const int SC_CLOSE = 0xF060;
        const int SC_MINIMIZE = 0xF020;
        const int SC_MAXIMIZE = 0xF030;
        const int SC_RESTORE = 61728;
        //窗体按钮的拦截函数
        protected override void WndProc(ref Message m)
        {
            if (m.Msg == WM_SYSCOMMAND)
            {
                if (m.WParam.ToInt32() == SC_RESTORE)
                {

                }
                if (m.WParam.ToInt32() == SC_MINIMIZE)  //拦截最小化按钮
                {

                }
                if (m.WParam.ToInt32() == SC_MAXIMIZE)   //拦截窗体最大化按钮
                {
                    this.FormBorderStyle = FormBorderStyle.None;     //设置窗体为无边框样式
                    this.WindowState = FormWindowState.Maximized;    //最大化窗体 
                }
                if (m.WParam.ToInt32() == SC_CLOSE)       //拦截窗体关闭按钮
                {


                }
            }
            base.WndProc(ref m);
        }

        void webbrowser_FrameLoadEnd(object sender, FrameLoadEndEventArgs e)
        {

            ChromiumWebBrowser browser = (ChromiumWebBrowser)sender;

            browser.SetZoomLevel(-3.8);

        }
    }
}
