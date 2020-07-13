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

namespace TeamSynCapacityAndTrend
{
    public partial class Team2 : Form
    {
        public Team2()
        {
            InitializeComponent();
        }

        public static string dbcenter = GetValue("conn_center");//查询库
        public static string dbnfin = GetValue("conn_nfinebase");//写入库
        public static string EnStr = DEncrypt.Decrypt(dbnfin);
        //产能负荷
        public string cncdate = GetValue("cnc_process_plan_date");
        public string cnccolourcl1 = GetValue("cnc_process_plan_cl_zc");
        public string cnccolourcl2 = GetValue("cnc_process_plan_cl_fzc");
        public string cnccolourfh1 = GetValue("cnc_process_plan_fh_zc");
        public string cnccolourfh2 = GetValue("cnc_process_plan_fh_fzc");

        public string edmdate = GetValue("edm_process_plan_date");
        public string edmcolourcl1 = GetValue("edm_process_plan_cl_zc");
        public string edmcolourcl2 = GetValue("edm_process_plan_cl_fzc");
        public string edmcolourfh1 = GetValue("edm_process_plan_fh_zc");
        public string edmcolourfh2 = GetValue("edm_process_plan_fh_fzc");

        public string wedate = GetValue("edm_process_plan_date");
        public string wecolourcl1 = GetValue("edm_process_plan_cl_zc");
        public string wecolourcl2 = GetValue("edm_process_plan_cl_fzc");
        public string wecolourfh1 = GetValue("edm_process_plan_fh_zc");
        public string wecolourfh2 = GetValue("edm_process_plan_fh_fzc");

        private void Team2_Load(object sender, EventArgs e)
        {
            try
            {
                #region 产能负荷
                int cl = 0;
                DbService clser = new DbService(EnStr, "MySQL");
                string elsrt = string.Format(@"INSERT into nfinebase.sys_capacityload(Task_Type,Device_Name,Device_Number,Team,Colour,CreationTime) 
                (SELECT TaskType,DeviceName,DeviceNumber,dept_name,Colour,now() FROM(
                SELECT acct_date,'产能' TaskType,process_name DeviceName,SUM(capacity_hours) DeviceNumber,
                CASE WHEN plan_hours>capacity_hours THEN '{0}' ELSE '{1}' end Colour,dept_name
                from mes_center.b03_process_plan where (dept_name='CNC班组' OR dept_name='CNC')
                and acct_date>=CURDATE() and acct_date<=CURDATE()+{4}  GROUP  BY process_name
                UNION ALL
                SELECT acct_date,'负荷' TaskType,process_name DeviceName,SUM(plan_hours) DeviceNumber,
                CASE WHEN plan_hours>capacity_hours THEN '{2}' ELSE '{3}' end Colour,dept_name
                from mes_center.b03_process_plan  where (dept_name='CNC班组' OR dept_name='CNC')
                and acct_date>=CURDATE() and acct_date<=CURDATE()+{5} GROUP  BY process_name) b  
                ORDER BY DeviceName,TaskType ASC)", cnccolourcl2, cnccolourcl1, cnccolourfh2, cnccolourfh1, cncdate, cncdate);
                int clsult = clser.InsertSql(elsrt, out cl);
                if (clsult > 0)
                {
                    int elret = clser.DeleteSql(string.Format("UPDATE nfinebase.sys_capacityload SET IsEffective=0 where (Team='CNC班组' OR Team='CNC') and id<{0}", cl));

                    LogHelper.Info(string.Format("CNC产能负荷Insert执行成功:{0}条,Update执行成功:{1}条，时间：{2}", clsult, elret, DateTime.Now.ToString()));
                }
                else
                {
                    LogHelper.Error("CNC产能负荷执行失败");
                }

                int cl1 = 0;
                DbService clser1 = new DbService(EnStr, "MySQL");
                string elsrt1 = string.Format(@"INSERT into nfinebase.sys_capacityload(Task_Type,Device_Name,Device_Number,Team,Colour,CreationTime) 
                (SELECT TaskType,DeviceName,DeviceNumber,dept_name,Colour,now() FROM(
                SELECT acct_date,'产能' TaskType,process_name DeviceName,SUM(capacity_hours) DeviceNumber,
                CASE WHEN plan_hours>capacity_hours THEN '{0}' ELSE '{1}' end Colour,dept_name
                from mes_center.b03_process_plan where (dept_name='EDM班组' OR dept_name='EDM')
                and acct_date>=CURDATE() and acct_date<=CURDATE()+{4}  GROUP  BY process_name
                UNION ALL
                SELECT acct_date,'负荷' TaskType,process_name DeviceName,SUM(plan_hours) DeviceNumber,
                CASE WHEN plan_hours>capacity_hours THEN '{2}' ELSE '{3}' end Colour,dept_name
                from mes_center.b03_process_plan  where (dept_name='EDM班组' OR dept_name='EDM')
                and acct_date>=CURDATE() and acct_date<=CURDATE()+{5} GROUP  BY process_name) b  
                ORDER BY DeviceName,TaskType ASC)", edmcolourcl2, edmcolourcl1, edmcolourfh2, edmcolourfh1, edmdate, edmdate);
                int clsult1 = clser1.InsertSql(elsrt1, out cl1);
                if (clsult1 > 0)
                {
                    int elret1 = clser1.DeleteSql(string.Format("UPDATE nfinebase.sys_capacityload SET IsEffective=0 where (Team='EDM班组' OR Team='EDM') and id<{0}", cl1));

                    LogHelper.Info(string.Format("EDM产能负荷Insert执行成功:{0}条,Update执行成功:{1}条，时间：{2}", clsult1, elret1, DateTime.Now.ToString()));
                }
                else
                {
                    LogHelper.Error("EDM产能负荷执行失败");
                }

                int cl2 = 0;
                DbService clser2 = new DbService(EnStr, "MySQL");
                string elsrt2 = string.Format(@"INSERT into nfinebase.sys_capacityload(Task_Type,Device_Name,Device_Number,Team,Colour,CreationTime) 
                (SELECT TaskType,DeviceName,DeviceNumber,dept_name,Colour,now() FROM(
                SELECT acct_date,'产能' TaskType,process_name DeviceName,SUM(capacity_hours) DeviceNumber,
                CASE WHEN plan_hours>capacity_hours THEN '{0}' ELSE '{1}' end Colour,dept_name
                from mes_center.b03_process_plan where (dept_name='WE班组' OR dept_name='WE')
                and acct_date>=CURDATE() and acct_date<=CURDATE()+{4}  GROUP  BY process_name
                UNION ALL
                SELECT acct_date,'负荷' TaskType,process_name DeviceName,SUM(plan_hours) DeviceNumber,
                CASE WHEN plan_hours>capacity_hours THEN '{2}' ELSE '{3}' end Colour,dept_name
                from mes_center.b03_process_plan  where (dept_name='WE班组' OR dept_name='WE')
                and acct_date>=CURDATE() and acct_date<=CURDATE()+{5} GROUP  BY process_name) b  
                ORDER BY DeviceName,TaskType ASC)", wecolourcl2, wecolourcl1, wecolourfh2, wecolourfh1, wedate, wedate);
                int clsult2 = clser2.InsertSql(elsrt2, out cl2);
                if (clsult2 > 0)
                {
                    int elret2 = clser2.DeleteSql(string.Format("UPDATE nfinebase.sys_capacityload SET IsEffective=0 where (Team='WE班组' OR Team='WE') and id<{0}", cl2));

                    LogHelper.Info(string.Format("WE产能负荷Insert执行成功:{0}条,Update执行成功:{1}条，时间：{2}", clsult2, elret2, DateTime.Now.ToString()));
                }
                else
                {
                    LogHelper.Error("WE产能负荷执行失败");
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

        public static string GetValue(string key)
        {
            return ConfigurationManager.AppSettings[key].ToString().Trim();
        }
    }
}
