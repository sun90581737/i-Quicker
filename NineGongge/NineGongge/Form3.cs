using CefSharp;
using CefSharp.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NineGongge
{
    public partial class Form3 : Form
    {
        private readonly ChromiumWebBrowser browser;
        public Form3()
        {
            InitializeComponent();

            this.FormBorderStyle = FormBorderStyle.None;     //设置窗体为无边框样式
            this.WindowState = FormWindowState.Maximized;    //最大化窗体 

            try
            {
                browser = new ChromiumWebBrowser("http://192.168.2.199:8081")
                {
                    Dock = DockStyle.Fill,//填充方式
                };
                panel1.Controls.Add(browser);
            }
            catch (Exception e)
            {

                throw;
            }

        }
        
        private void Form3_Load(object sender, EventArgs e)
        {
            
            //CefSharp.Cef.Initialize();
            //CefSharp.WinForms.ChromiumWebBrowser wb2 = new CefSharp.WinForms.ChromiumWebBrowser("www.baidu.com");//http://192.168.2.199:8081/FastLogin/Index?accounts=admin
            //wb2.Dock = DockStyle.Fill;
            //panel1.Controls.Add(wb2);

            //Thread th = new Thread(() =>

            //{
            //    Thread.Sleep(5000);
            //    this.Invoke((Action)delegate
            //    {
            //        wb2.Load("http://192.168.2.199:8081/OperationMonitoring/BusinessOverview/Index");
            //    });
            //});
            //th.Start();
        }
    }
}
