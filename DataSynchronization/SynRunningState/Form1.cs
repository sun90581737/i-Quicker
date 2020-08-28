using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SynRunningState
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public static string dbnfin = GetValue("conn_nfinebase");//写入库
        public static string EnStr = DEncrypt.Decrypt(dbnfin);
        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                #region 运行状态
                int re = 0;
                DbService ds = new DbService(EnStr, "MySQL");
                string srt = string.Format(@"");
                int sult = ds.InsertSql(srt, out re);
                if (sult > 0)
                {
                    int ret = ds.DeleteSql(string.Format("", re));

                    LogHelper.Info(string.Format("运行状态-Insert执行成功:{0}条,Update执行成功:{1}条，时间：{2}", sult, ret, DateTime.Now.ToString()));
                }
                else
                {
                    LogHelper.Error("运行状态-执行失败");
                }
                #endregion
            }
            catch (Exception ex)
            {
                LogHelper.Error(ex.Message);
            }
            finally
            {
                this.Close();
            }
        }
        // 根据Key取Value值
        public static string GetValue(string key)
        {
            return ConfigurationManager.AppSettings[key].ToString().Trim();
        }
    }
}

