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

namespace TeamSynchronization
{
    public partial class Team : Form
    {
        public Team()
        {
            InitializeComponent();
        }

        public static string dbcenter = GetValue("conn_center");//查询库
        public static string dbnfin = GetValue("conn_nfinebase");//写入库
        public static string tip= DEncrypt.Decrypt(dbnfin);

        public string cnclimit = GetValue("cnc_device_task_top");
        public string cnccolour1 = GetValue("cnc_device_task_colour1");
        public string cnccolour2 = GetValue("cnc_device_task_colour2");
        public string cnccolour3 = GetValue("cnc_device_task_colour3");
        public string cnccolour4 = GetValue("cnc_device_task_colour4");

        public string edmlimit = GetValue("edm_device_task_top");
        public string edmcolour1 = GetValue("edm_device_task_colour1");
        public string edmcolour2 = GetValue("edm_device_task_colour2");
        public string edmcolour3 = GetValue("edm_device_task_colour3");
        public string edmcolour4 = GetValue("edm_device_task_colour4");

        public string welimit = GetValue("we_device_task_top");
        public string wecolour1 = GetValue("we_device_task_colour1");
        public string wecolour2 = GetValue("we_device_task_colour2");
        public string wecolour3 = GetValue("we_device_task_colour3");
        public string wecolour4 = GetValue("we_device_task_colour4");
        private void Team_Load(object sender, EventArgs e)
        {
            try
            {
                #region  任务清单
                int mp = 0;
                DbService ser = new DbService(tip, "MySQL");
                string srt = string.Format(@"INSERT INTO nfinebase.sys_tasklist(Mold_No,Part_Number,Planned_Equipment,Start_Time,END_Time,Latest_Start_Time,Working_Hours,Customer,
                    Mold_Kernel_Material,Category,Team,Colour)(SELECT  mold_no,part_no,device,begin_time,end_time,last_begin_time,process_hour,customer_name,material,group_name,
                    dept_name,CASE WHEN process_state=-1 THEN '{0}' WHEN process_state=0 THEN '{1}' WHEN process_state=1 THEN '{2}' WHEN process_state=2 THEN '{3}' ELSE '' 
                    END process_state FROM mes_center.b01_device_task  where (dept_name='CNC班组' OR dept_name='CNC') {4})", cnccolour1, cnccolour2, cnccolour3, cnccolour4, cnclimit);
                int result = ser.InsertSql(srt, out mp);
                if (result > 0)
                {
                    int ret = ser.DeleteSql(string.Format("UPDATE nfinebase.sys_tasklist SET IsEffective=0 where (Team='CNC班组' OR Team='CNC') and id<{0}", mp));

                    LogHelper.Info(string.Format("CNCInsert执行成功:{0}条,Update执行成功:{1}条，时间：{2}", result, ret, DateTime.Now.ToString()));
                }
                else
                {
                    LogHelper.Error("CNC执行失败");
                }

                int mp1 = 0;
                DbService ser1 = new DbService(tip, "MySQL");
                string srt1 = string.Format(@"INSERT INTO nfinebase.sys_tasklist(Mold_No,Part_Number,Planned_Equipment,Start_Time,END_Time,Latest_Start_Time,Working_Hours,Customer,
                    Mold_Kernel_Material,Category,Team,Colour)(SELECT  mold_no,part_no,device,begin_time,end_time,last_begin_time,process_hour,customer_name,material,group_name,
                    dept_name,CASE WHEN process_state=-1 THEN '{0}' WHEN process_state=0 THEN '{1}' WHEN process_state=1 THEN '{2}' WHEN process_state=2 THEN '{3}' ELSE '' 
                    END process_state FROM mes_center.b01_device_task  where (dept_name='EDM班组' OR dept_name='EDM') {4})", edmcolour1, edmcolour2, edmcolour3, edmcolour4, edmlimit);
                int result1 = ser1.InsertSql(srt1, out mp1);
                if (result1 > 0)
                {
                    int ret1 = ser1.DeleteSql(string.Format("UPDATE nfinebase.sys_tasklist SET IsEffective=0 where (Team='EDM班组' OR Team='EDM') and id<{0}", mp1));

                    LogHelper.Info(string.Format("EDMInsert执行成功:{0}条,Update执行成功:{1}条，时间：{2}", result1, ret1, DateTime.Now.ToString()));
                }
                else
                {
                    LogHelper.Error("EDM执行失败");
                }

                int mp2 = 0;
                DbService ser2 = new DbService(tip, "MySQL");
                string srt2 = string.Format(@"INSERT INTO nfinebase.sys_tasklist(Mold_No,Part_Number,Planned_Equipment,Start_Time,END_Time,Latest_Start_Time,Working_Hours,Customer,
                    Mold_Kernel_Material,Category,Team,Colour)(SELECT  mold_no,part_no,device,begin_time,end_time,last_begin_time,process_hour,customer_name,material,group_name,
                    dept_name,CASE WHEN process_state=-1 THEN '{0}' WHEN process_state=0 THEN '{1}' WHEN process_state=1 THEN '{2}' WHEN process_state=2 THEN '{3}' ELSE '' 
                    END process_state FROM mes_center.b01_device_task  where (dept_name='WE班组' OR dept_name='WE') {4})", wecolour1, wecolour2, wecolour3, wecolour4, welimit);
                int result2 = ser2.InsertSql(srt2, out mp2);
                if (result2 > 0)
                {
                    int ret2 = ser2.DeleteSql(string.Format("UPDATE nfinebase.sys_tasklist SET IsEffective=0 where (Team='WE班组' OR Team='WE') and id<{0}", mp2));

                    LogHelper.Info(string.Format("WEInsert执行成功:{0}条,Update执行成功:{1}条，时间：{2}", result2, ret2, DateTime.Now.ToString()));
                }
                else
                {
                    LogHelper.Error("WE执行失败");
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
