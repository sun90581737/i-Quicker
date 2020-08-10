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

namespace SynQualityEngineering
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public static string dbnfin = GetValue("conn_nfinebase");//写入库
        public static string EnStr = DEncrypt.Decrypt(dbnfin);

        public string pass_rate_days = GetValue("pass_rate_days");
        public string DY_pass_rate_days_colour = GetValue("DY_pass_rate_days_colour");
        public string XY_pass_rate_days_colour = GetValue("XY_pass_rate_days_colour");
        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                #region 班组合格率
                int re = 0;
                DbService ds = new DbService(EnStr, "MySQL");
                string srt = string.Format(@"INSERT INTO nfinebase.Sys_QualityOTeamPassRate(DeviceType,DeviceName,Number,Colour,CreationTime)
                    (
		                    SELECT dept_name,'合格率',pass_rate,CASE WHEN pass_rate>={0} THEN '{1}' ELSE '{2}' END Colour,now() FROM mes_center.e01_dept_pass_day 
		                    where acct_date >= DATE_FORMAT(DATE_SUB(NOW(), INTERVAL 30 DAY), '%Y-%m-%d') and acct_date <= CURDATE()
                    )", pass_rate_days, DY_pass_rate_days_colour, XY_pass_rate_days_colour);
                int sult = ds.InsertSql(srt, out re);
                if (sult > 0)
                {
                    int ret = ds.DeleteSql(string.Format("", re));

                    LogHelper.Info(string.Format("品质工程-班组合格率-Insert执行成功:{0}条,Update执行成功:{1}条，时间：{2}", sult, ret, DateTime.Now.ToString()));
                }
                else
                {
                    LogHelper.Error("品质工程-班组合格率-执行失败");
                }
                #endregion

                #region 班组合格率趋势
                int re2 = 0;
                DbService ds2 = new DbService(EnStr, "MySQL");
                string srt2 = string.Format(@"");
                int sult2 = ds2.InsertSql(srt2, out re2);
                if (sult2 > 0)
                {
                    int ret2 = ds2.DeleteSql(string.Format("", re2));

                    LogHelper.Info(string.Format("品质工程-班组合格率趋势-Insert执行成功:{0}条,Update执行成功:{1}条，时间：{2}", sult2, ret2, DateTime.Now.ToString()));
                }
                else
                {
                    LogHelper.Error("品质工程-班组合格率趋势-执行失败");
                }
                #endregion

                #region 异常处理结果统计
                int re3 = 0;
                DbService ds3 = new DbService(EnStr, "MySQL");
                string srt3 = string.Format(@"");
                int sult3 = ds3.InsertSql(srt3, out re3);
                if (sult3 > 0)
                {
                    int ret3 = ds3.DeleteSql(string.Format("", re3));

                    LogHelper.Info(string.Format("品质工程-异常处理结果统计-Insert执行成功:{0}条,Update执行成功:{1}条，时间：{2}", sult3, ret3, DateTime.Now.ToString()));
                }
                else
                {
                    LogHelper.Error("品质工程-异常处理结果统计-执行失败");
                }
                #endregion

                #region 异常处理单据明细
                int re4 = 0;
                DbService ds4 = new DbService(EnStr, "MySQL");
                string srt4 = string.Format(@"");
                int sult4 = ds4.InsertSql(srt4, out re4);
                if (sult4 > 0)
                {
                    int ret4 = ds4.DeleteSql(string.Format("", re4));

                    LogHelper.Info(string.Format("品质工程-异常处理单据明细-Insert执行成功:{0}条,Update执行成功:{1}条，时间：{2}", sult4, ret4, DateTime.Now.ToString()));
                }
                else
                {
                    LogHelper.Error("品质工程-异常处理单据明细-执行失败");
                }
                #endregion

                #region 部门待处理/已处理异常统计
                int re5 = 0;
                DbService ds5 = new DbService(EnStr, "MySQL");
                string srt5 = string.Format(@"");
                int sult5 = ds5.InsertSql(srt5, out re5);
                if (sult5 > 0)
                {
                    int ret5 = ds5.DeleteSql(string.Format("", re5));

                    LogHelper.Info(string.Format("品质工程-部门待处理/已处理异常统计-Insert执行成功:{0}条,Update执行成功:{1}条，时间：{2}", sult5, ret5, DateTime.Now.ToString()));
                }
                else
                {
                    LogHelper.Error("品质工程-部门待处理/已处理异常统计-执行失败");
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
