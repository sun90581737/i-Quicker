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
        public string CNC1colour = GetValue("CNC1_colour");
        public string CNC2colour = GetValue("CNC2_colour");
        public string CNC3colour = GetValue("CNC3_colour");
        public string CMM2colour = GetValue("CMM2_colour");
        public string Robotcolour = GetValue("Robot_colour");
        public string QXJcolour = GetValue("QXJ_colour");

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
                         '{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}'
		                FROM mes_center.r01_device_state
                )", CNC1colour, CNC2colour, CNC3colour, CMM2colour, Robotcolour, QXJcolour, NotStartedcolour + ';' + Conductcolour + ';' + Completedcolour + ';' + Abnormalcolour + ';' + Stopcolour + ';' + Cancelcolour, NotStartedcolour + ';' + Conductcolour + ';' + Completedcolour + ';' + Abnormalcolour + ';' + Stopcolour + ';' + Cancelcolour);
                int sult = ds.InsertSql(srt, out re);
                if (sult > 0)
                {
                    int ret = ds.DeleteSql(string.Format("UPDATE nfinebase.Sys_RunningState SET IsEffective=0 where id<{0}", re));

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

