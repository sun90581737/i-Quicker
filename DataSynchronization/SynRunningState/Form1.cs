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
        public string offlinecolour = GetValue("offline_colour");
        public string standbycolour = GetValue("standby_colour");
        public string inoperationcolour = GetValue("inoperation_colour");
        public string suspendcolour = GetValue("suspend_colour");
        public string giveanalarmcolour = GetValue("giveanalarm_colour");
        public string notreadycolour = GetValue("notready_colour");
        public string stopitcolour = GetValue("stopit_colour");

        public string NotStartedcolour = GetValue("NotStarted_colour");
        public string Conductcolour = GetValue("Conduct_colour");
        public string Completedcolour = GetValue("Completed_colour");
        public string Abnormalcolour = GetValue("Abnormal_colour");
        public string Stopcolour = GetValue("Stop_colour");
        public string Cancelcolour = GetValue("Cancel_colour");
        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                #region 运行状态
                int re = 0;
                DbService ds = new DbService(EnStr, "MySQL");
                string srt = string.Format(@"INSERT INTO nfinebase.Sys_RunningState(Picture_Tip,Picture_Url,Describe1,Describe2,Describe3,Describe4,Describe5,Describe6,Describe7,Describe8,CreationTime,DescribeColor1,DescribeColor2,DescribeColor3,DescribeColor4,DescribeColor5,DescribeColor6,DescribeColor7,DescribeColor8)
                (
		                SELECT '测试显示' Picture_Tip,'/Content/img/product/runningstate/01.png' Picture_Url,
		                MAX(CASE WHEN device_name  = 'CNC1发那科' THEN  CONCAT(device_name ,'<br>',state_name) END) AS Describe1,
		                MAX(CASE WHEN device_name  = 'CNC2发那科' THEN  CONCAT(device_name ,'<br>',state_name) END) AS Describe2,
		                MAX(CASE WHEN device_name  = 'CNC3发那科' THEN  CONCAT(device_name ,'<br>',state_name) END) AS Describe3,
		                MAX(CASE WHEN device_name  = 'CMM2海克斯康' THEN  CONCAT(device_name ,'<br>',state_name) END) AS Describe4,
		                MAX(CASE WHEN device_name  = 'Robot' THEN  CONCAT(device_name ,'<br>',state_name) END) AS Describe5,
		                MAX(CASE WHEN device_name  = '清洗机' THEN  CONCAT(device_name ,'<br>',state_name) END) AS Describe6,
		                (SELECT group_concat((state_num)SEPARATOR ';') FROM mes_center.r02_shelf_state  WHERE shelf_name='料架A') AS Describe7,
		                (SELECT group_concat((state_num)SEPARATOR ';') FROM mes_center.r02_shelf_state  WHERE shelf_name='料架B') AS Describe8,now(),
                        MAX(CASE WHEN device_name  = 'CNC1发那科' AND state_code=0 THEN '{0}'  WHEN device_name  = 'CNC1发那科' AND state_code=1 THEN '{1}'                         WHEN device_name  = 'CNC1发那科' AND state_code=2 THEN '{2}' WHEN device_name  = 'CNC1发那科' AND state_code=3 THEN '{3}'
                        WHEN device_name  = 'CNC1发那科' AND state_code=4 THEN '{4}' WHEN device_name  = 'CNC1发那科' AND state_code=5 THEN '{5}'
                        WHEN device_name  = 'CNC1发那科' AND state_code=6 THEN '{6}' END) AS DescribeColor1,
                        MAX(CASE WHEN device_name  = 'CNC2发那科' AND state_code=0 THEN '{0}'  WHEN device_name  = 'CNC2发那科' AND state_code=1 THEN '{1}' 
                        WHEN device_name  = 'CNC2发那科' AND state_code=2 THEN '{2}' WHEN device_name  = 'CNC2发那科' AND state_code=3 THEN '{3}'
                        WHEN device_name  = 'CNC2发那科' AND state_code=4 THEN '{4}' WHEN device_name  = 'CNC2发那科' AND state_code=5 THEN '{5}'
                        WHEN device_name  = 'CNC2发那科' AND state_code=6 THEN '{6}' END) AS DescribeColor2,
                        MAX(CASE WHEN device_name  = 'CNC2发那科' AND state_code=0 THEN '{0}'  WHEN device_name  = 'CNC2发那科' AND state_code=1 THEN '{1}' 
                        WHEN device_name  = 'CNC3发那科' AND state_code=2 THEN '{2}' WHEN device_name  = 'CNC2发那科' AND state_code=3 THEN '{3}'
                        WHEN device_name  = 'CNC3发那科' AND state_code=4 THEN '{4}' WHEN device_name  = 'CNC2发那科' AND state_code=5 THEN '{5}'
                        WHEN device_name  = 'CNC3发那科' AND state_code=6 THEN '{6}' END) AS DescribeColor3,
                        MAX(CASE WHEN device_name  = 'CMM2海克斯康' AND state_code=0 THEN '{0}'  WHEN device_name  = 'CMM2海克斯康' AND state_code=1 THEN '{1}' 
                        WHEN device_name  = 'CMM2海克斯康' AND state_code=2 THEN '{2}' WHEN device_name  = 'CMM2海克斯康' AND state_code=3 THEN '{3}'
                        WHEN device_name  = 'CMM2海克斯康' AND state_code=4 THEN '{4}' WHEN device_name  = 'CMM2海克斯康' AND state_code=5 THEN '{5}'
                        WHEN device_name  = 'CMM2海克斯康' AND state_code=6 THEN '{6}' END) AS DescribeColor4,
                        MAX(CASE WHEN device_name  = 'Robot' AND state_code=0 THEN '{0}'  WHEN device_name  = 'Robot' AND state_code=1 THEN '{1}' 
                        WHEN device_name  = 'Robot' AND state_code=2 THEN '{2}' WHEN device_name  = 'Robot' AND state_code=3 THEN '{3}'
                        WHEN device_name  = 'Robot' AND state_code=4 THEN '{4}' WHEN device_name  = 'Robot' AND state_code=5 THEN '{5}'
                        WHEN device_name  = 'Robot' AND state_code=6 THEN '{6}' END) AS DescribeColor5,
                        MAX(CASE WHEN device_name  = '清洗机' AND state_code=0 THEN '{0}'  WHEN device_name  = '清洗机' AND state_code=1 THEN '{1}' 
                        WHEN device_name  = '清洗机' AND state_code=2 THEN '{2}' WHEN device_name  = '清洗机' AND state_code=3 THEN '{3}'
                        WHEN device_name  = '清洗机' AND state_code=4 THEN '{4}' WHEN device_name  = '清洗机' AND state_code=5 THEN '{5}'
                        WHEN device_name  = '清洗机' AND state_code=6 THEN '{6}' END) AS DescribeColor6,'{7}','{8}'
		                FROM mes_center.r01_device_state
                )", offlinecolour, standbycolour, inoperationcolour, suspendcolour, giveanalarmcolour, notreadycolour, stopitcolour, NotStartedcolour + ';' + Conductcolour + ';' + Completedcolour + ';' + Abnormalcolour + ';' + Stopcolour + ';' + Cancelcolour, NotStartedcolour + ';' + Conductcolour + ';' + Completedcolour + ';' + Abnormalcolour + ';' + Stopcolour + ';' + Cancelcolour);
                int sult = ds.InsertSql(srt, out re);
                if (sult > 0)
                {
                    int ret = ds.DeleteSql(string.Format("UPDATE nfinebase.Sys_RunningState SET IsEffective=0 where id<{0}", re));

                    LogHelper.Info(string.Format("自动化线-运行状态-Insert执行成功:{0}条,Update执行成功:{1}条，时间：{2}", sult, ret, DateTime.Now.ToString()));
                }
                else
                {
                    LogHelper.Error("自动化线-运行状态-执行失败");
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

