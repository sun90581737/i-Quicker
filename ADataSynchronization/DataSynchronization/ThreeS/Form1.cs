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

namespace ThreeS
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public static string dbnfin = GetValue("conn_nfinebase");//写入库
        public static string EnStr = DEncrypt.Decrypt(dbnfin);
        public string Synminute = GetValue("Syn_minute");
        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                #region 数据采集 --2分钟刷一次
                int re2 = 0;
                DbService ds2 = new DbService(EnStr, "MySQL");
                string srt2 = string.Format(@"INSERT INTO test_nfinebase.Sys_DataAcquisitionDetail(RunTime,DeviceName,SpindleSpeed,FeedSpeed,SpindleRatio,FeedRatio,LoadRatio,CreationTime)
                (
	                 SELECT run_time,device_name,spindle_speed,feed_speed,spindle_override,feed_override,spindle_load,now() FROM test_mes_center.r03_data_collect 
                     where run_time IS NOT NULL AND run_time>DATE_ADD(NOW(), INTERVAL {0} MINUTE)  ORDER BY run_time ASC
                )", Synminute);
                int sult2 = ds2.InsertSql(srt2, out re2);
                if (sult2 > 0)
                {
                    int ret2 = ds2.DeleteSql(string.Format("DELETE from test_nfinebase.Sys_DataAcquisitionDetail where id<{0}", re2));

                    //LogHelper.Info(string.Format("自动化线-数据采集Sys_DataAcquisitionDetail-Insert执行成功:{0}条,Update执行成功:{1}条，时间：{2}", sult2, ret2, DateTime.Now.ToString()));
                }
                else
                {
                    LogHelper.Error("自动化线-数据采集Sys_DataAcquisitionDetail-执行失败");
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
