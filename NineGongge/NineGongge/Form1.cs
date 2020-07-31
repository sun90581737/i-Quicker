using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NineGongge
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

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
    }
}
