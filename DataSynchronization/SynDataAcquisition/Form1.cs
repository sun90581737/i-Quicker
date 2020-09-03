﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SynDataAcquisition
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public static string dbnfin = GetValue("conn_nfinebase");//写入库
        public static string EnStr = DEncrypt.Decrypt(dbnfin);
        public string DeviceUrl = GetValue("Device_Url");
        public string Synminute = GetValue("Syn_minute");
        public string offlinecolour = GetValue("offline_colour");
        public string standbycolour = GetValue("standby_colour");
        public string inoperationcolour = GetValue("inoperation_colour");
        public string suspendcolour = GetValue("suspend_colour");
        public string giveanalarmcolour = GetValue("giveanalarm_colour");
        public string notreadycolour = GetValue("notready_colour");
        public string stopitcolour = GetValue("stopit_colour");
        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                #region 数据采集 --5-10分刷新一次
                int re = 0;
                DbService ds = new DbService(EnStr, "MySQL");
                string srt = string.Format(@"INSERT into nfinebase.Sys_DataAcquisition(DeviceName,DeviceRunStatus,DeviceUrl,DeviceLndicatorLight,TodayOutput,TodayJiadong,SpindleSpeed,FeedSpeed,SpindleRatio,FeedRatio,LoadRatio,CreationTime)
                    (
	                    SELECT a.device_name,b.state_name,'{0}' DeviceUrl,
	                    CASE WHEN b.state_code=0 THEN '{1}' WHEN b.state_code=1 THEN '{2}' WHEN b.state_code=2 THEN '{3}' 
	                    WHEN b.state_code=3 THEN '{4}'  WHEN b.state_code=4 THEN '{5}'  WHEN b.state_code=5 THEN '{6}' 
	                    WHEN b.state_code=6 THEN '{7}'  ELSE '' END Color,a.today_num,a.today_activation,d.spindle_speed,
	                    d.feed_speed,d.spindle_override,d.feed_override,d.spindle_load,now()
	                    FROM mes_center.r04_device_today a LEFT JOIN mes_center.r01_device_state b ON b.device_name=a.device_name
	                    LEFT JOIN (SELECT * FROM mes_center.r03_data_collect  WHERE run_time IN(SELECT MIN(t.run_time) FROM mes_center.r03_data_collect t
	                    where t.run_time IS NOT NULL AND t.run_time>DATE_ADD(NOW(), INTERVAL {8} MINUTE)   GROUP BY t.device_name)
	                    ) d ON d.device_name=a.device_name
                    )", DeviceUrl, offlinecolour, standbycolour, inoperationcolour, suspendcolour, giveanalarmcolour, notreadycolour, stopitcolour, Synminute);
                int sult = ds.InsertSql(srt, out re);
                if (sult > 0)
                {
                    int ret = ds.DeleteSql(string.Format("UPDATE nfinebase.Sys_DataAcquisition SET IsEffective=0 where id<{0}", re));
                    //频率太高
                    //LogHelper.Info(string.Format("自动化线-数据采集Sys_DataAcquisition-Insert执行成功:{0}条,Update执行成功:{1}条，时间：{2}", sult, ret, DateTime.Now.ToString()));
                }
                else
                {
                    LogHelper.Error("自动化线-数据采集Sys_DataAcquisition-执行失败");
                }
                #endregion

                #region 数据采集 --2分钟刷一次
                int re2 = 0;
                DbService ds2 = new DbService(EnStr, "MySQL");
                string srt2 = string.Format(@"INSERT INTO nfinebase.Sys_DataAcquisitionDetail(RunTime,DeviceName,SpindleSpeed,FeedSpeed,SpindleRatio,FeedRatio,LoadRatio,CreationTime)
                (
	                 SELECT run_time,device_name,spindle_speed,feed_speed,spindle_override,feed_override,spindle_load,now() FROM mes_center.r03_data_collect 
                     where run_time IS NOT NULL AND run_time>DATE_ADD(NOW(), INTERVAL {0} MINUTE)  ORDER BY run_time ASC
                )", Synminute);
                int sult2 = ds2.InsertSql(srt2, out re2);
                if (sult2 > 0)
                {
                    int ret2 = ds2.DeleteSql(string.Format("UPDATE nfinebase.Sys_DataAcquisitionDetail SET IsEffective=0 where id<{0}", re2));

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
