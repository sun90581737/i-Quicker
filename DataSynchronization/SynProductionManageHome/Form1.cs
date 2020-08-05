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

namespace SynProductionManageHome
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
                #region  在制模具进度汇总
                int re = 0;
                DbService ds = new DbService(EnStr, "MySQL");
                string srt = string.Format("");
                int sult = ds.InsertSql(srt, out re);
                if (sult > 0)
                {
                    int ret = ds.DeleteSql(string.Format(""));

                    LogHelper.Info(string.Format("生管主页-在制模具进度汇总-Insert执行成功:{0}条,Update执行成功:{1}条，时间：{2}", sult, ret, DateTime.Now.ToString()));
                }
                else
                {
                    LogHelper.Error("生管主页-在制模具进度汇总-执行失败");
                }
                #endregion

                #region  延误模具明细
                int re2 = 0;
                DbService ds2 = new DbService(EnStr, "MySQL");
                string srt2 = string.Format("");
                int sult2 = ds2.InsertSql(srt2, out re2);
                if (sult2 > 0)
                {
                    int ret2 = ds2.DeleteSql(string.Format(""));

                    LogHelper.Info(string.Format("生管主页-延误模具明细-Insert执行成功:{0}条,Update执行成功:{1}条，时间：{2}", sult2, ret2, DateTime.Now.ToString()));
                }
                else
                {
                    LogHelper.Error("生管主页-延误模具明细-执行失败");
                }
                #endregion

                #region  产能/负荷
                int re3 = 0;
                DbService ds3 = new DbService(EnStr, "MySQL");
                string srt3 = string.Format("");
                int sult3 = ds3.InsertSql(srt3, out re3);
                if (sult3 > 0)
                {
                    int ret3 = ds3.DeleteSql(string.Format(""));

                    LogHelper.Info(string.Format("生管主页-产能/负荷-Insert执行成功:{0}条,Update执行成功:{1}条，时间：{2}", sult3, ret3, DateTime.Now.ToString()));
                }
                else
                {
                    LogHelper.Error("生管主页-产能/负荷-执行失败");
                }
                #endregion

                #region  外协按期交付率
                int re4 = 0;
                DbService ds4 = new DbService(EnStr, "MySQL");
                string srt4 = string.Format("");
                int sult4 = ds4.InsertSql(srt4, out re4);
                if (sult4 > 0)
                {
                    int ret4 = ds4.DeleteSql(string.Format(""));

                    LogHelper.Info(string.Format("生管主页-外协按期交付率-Insert执行成功:{0}条,Update执行成功:{1}条，时间：{2}", sult4, ret4, DateTime.Now.ToString()));
                }
                else
                {
                    LogHelper.Error("生管主页-外协按期交付率-执行失败");
                }
                #endregion

                #region  外协单据明细
                int re5 = 0;
                DbService ds5 = new DbService(EnStr, "MySQL");
                string srt5 = string.Format("");
                int sult5 = ds5.InsertSql(srt5, out re5);
                if (sult5 > 0)
                {
                    int ret5 = ds5.DeleteSql(string.Format(""));

                    LogHelper.Info(string.Format("生管主页-外协单据明细-Insert执行成功:{0}条,Update执行成功:{1}条，时间：{2}", sult5, ret5, DateTime.Now.ToString()));
                }
                else
                {
                    LogHelper.Error("生管主页-外协单据明细-执行失败");
                }
                #endregion

                #region  物料按期交付率
                int re6 = 0;
                DbService ds6 = new DbService(EnStr, "MySQL");
                string srt6 = string.Format("");
                int sult6 = ds6.InsertSql(srt6, out re6);
                if (sult6 > 0)
                {
                    int ret6 = ds6.DeleteSql(string.Format(""));

                    LogHelper.Info(string.Format("生管主页-物料按期交付率-Insert执行成功:{0}条,Update执行成功:{1}条，时间：{2}", sult6, ret6, DateTime.Now.ToString()));
                }
                else
                {
                    LogHelper.Error("生管主页-物料按期交付率-执行失败");
                }
                #endregion

                #region  物料单据明细
                int re7 = 0;
                DbService ds7 = new DbService(EnStr, "MySQL");
                string srt7 = string.Format("");
                int sult7 = ds7.InsertSql(srt7, out re7);
                if (sult7 > 0)
                {
                    int ret7 = ds7.DeleteSql(string.Format(""));

                    LogHelper.Info(string.Format("生管主页-物料单据明细-Insert执行成功:{0}条,Update执行成功:{1}条，时间：{2}", sult7, ret7, DateTime.Now.ToString()));
                }
                else
                {
                    LogHelper.Error("生管主页-物料单据明细-执行失败");
                }
                #endregion

                #region  稼动率趋势
                int re8 = 0;
                DbService ds8 = new DbService(EnStr, "MySQL");
                string srt8 = string.Format("");
                int sult8 = ds8.InsertSql(srt8, out re8);
                if (sult8 > 0)
                {
                    int ret8 = ds8.DeleteSql(string.Format(""));

                    LogHelper.Info(string.Format("生管主页-稼动率趋势-Insert执行成功:{0}条,Update执行成功:{1}条，时间：{2}", sult8, ret8, DateTime.Now.ToString()));
                }
                else
                {
                    LogHelper.Error("生管主页-稼动率趋势-执行失败");
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
