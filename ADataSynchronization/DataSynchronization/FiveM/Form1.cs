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

namespace FiveM
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public static string dbnfin = GetValue("conn_nfinebase");//写入库
        public static string EnStr = DEncrypt.Decrypt(dbnfin);
        //任务清单
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
        //设备清单
        public string cnclimitdr = GetValue("cnc_device_running_top");
        public string cnccolourdr1 = GetValue("cnc_device_running_colour1");
        public string cnccolourdr2 = GetValue("cnc_device_running_colour2");
        public string cnccolourdr3 = GetValue("cnc_device_running_colour3");
        public string cnccolourdr4 = GetValue("cnc_device_running_colour4");

        public string edmlimitdr = GetValue("edm_device_running_top");
        public string edmcolourdr1 = GetValue("edm_device_running_colour1");
        public string edmcolourdr2 = GetValue("edm_device_running_colour2");
        public string edmcolourdr3 = GetValue("edm_device_running_colour3");
        public string edmcolourdr4 = GetValue("edm_device_running_colour4");

        public string welimitdr = GetValue("we_device_running_top");
        public string wecolourdr1 = GetValue("we_device_running_colour1");
        public string wecolourdr2 = GetValue("we_device_running_colour2");
        public string wecolourdr3 = GetValue("we_device_running_colour3");
        public string wecolourdr4 = GetValue("we_device_running_colour4");

        public string pass_rate_days = GetValue("pass_rate_days");
        public string DY_pass_rate_days_colour = GetValue("DY_pass_rate_days_colour");
        public string XY_pass_rate_days_colour = GetValue("XY_pass_rate_days_colour");

        public string TreatmentMethod = GetValue("Treatment_Method");
        public string TreatmentMethodColour = GetValue("Treatment_Method_Colour");
        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                #region  任务清单-班组任务
                int mp = 0;
                DbService ser = new DbService(EnStr, "MySQL");
                string srt = string.Format(@"INSERT INTO test_nfinebase.sys_tasklist(Process_Id,Mold_No,Part_Number,Process_Name,Planned_Equipment,Start_Time,END_Time,Latest_Start_Time,Working_Hours,Customer,
                    Mold_Kernel_Material,Category,Team,Colour)(SELECT  process_id,mold_no,part_no,process_name,device,begin_time,end_time,last_begin_time,process_hour,customer_name,material,group_name,
                    dept_name,CASE WHEN process_state=-1 THEN '{0}' WHEN process_state=0 THEN '{1}' WHEN process_state=1 THEN '{2}' WHEN process_state=2 THEN '{3}' ELSE '' 
                    END process_state FROM test_mes_center.b01_device_task  where (dept_name='CNC班组' OR dept_name='CNC') {4})", cnccolour1, cnccolour2, cnccolour3, cnccolour4, cnclimit);
                int result = ser.InsertSql(srt, out mp);
                if (result > 0)
                {
                    int ret = ser.DeleteSql(string.Format("DELETE from test_nfinebase.sys_tasklist where (Team='CNC班组' OR Team='CNC') and id<{0}", mp));

                    LogHelper.Info(string.Format("CNC任务清单Insert执行成功:{0}条,Update执行成功:{1}条，时间：{2}", result, ret, DateTime.Now.ToString()));
                }
                else
                {
                    LogHelper.Error("CNC任务清单执行失败");
                }

                int mp1 = 0;
                DbService ser1 = new DbService(EnStr, "MySQL");
                string srt1 = string.Format(@"INSERT INTO test_nfinebase.sys_tasklist(Process_Id,Mold_No,Part_Number,Process_Name,Planned_Equipment,Start_Time,END_Time,Latest_Start_Time,Working_Hours,Customer,
                    Mold_Kernel_Material,Category,Team,Colour)(SELECT  process_id,mold_no,part_no,process_name,device,begin_time,end_time,last_begin_time,process_hour,customer_name,material,group_name,
                    dept_name,CASE WHEN process_state=-1 THEN '{0}' WHEN process_state=0 THEN '{1}' WHEN process_state=1 THEN '{2}' WHEN process_state=2 THEN '{3}' ELSE '' 
                    END process_state FROM test_mes_center.b01_device_task  where (dept_name='EDM班组' OR dept_name='EDM') {4})", edmcolour1, edmcolour2, edmcolour3, edmcolour4, edmlimit);
                int result1 = ser1.InsertSql(srt1, out mp1);
                if (result1 > 0)
                {
                    int ret1 = ser1.DeleteSql(string.Format("DELETE from test_nfinebase.sys_tasklist where (Team='EDM班组' OR Team='EDM') and id<{0}", mp1));

                    LogHelper.Info(string.Format("EDM任务清单Insert执行成功:{0}条,Update执行成功:{1}条，时间：{2}", result1, ret1, DateTime.Now.ToString()));
                }
                else
                {
                    LogHelper.Error("EDM任务清单执行失败");
                }

                int mp2 = 0;
                DbService ser2 = new DbService(EnStr, "MySQL");
                string srt2 = string.Format(@"INSERT INTO test_nfinebase.sys_tasklist(Process_Id,Mold_No,Part_Number,Process_Name,Planned_Equipment,Start_Time,END_Time,Latest_Start_Time,Working_Hours,Customer,
                    Mold_Kernel_Material,Category,Team,Colour)(SELECT  process_id,mold_no,part_no,process_name,device,begin_time,end_time,last_begin_time,process_hour,customer_name,material,group_name,
                    dept_name,CASE WHEN process_state=-1 THEN '{0}' WHEN process_state=0 THEN '{1}' WHEN process_state=1 THEN '{2}' WHEN process_state=2 THEN '{3}' ELSE '' 
                    END process_state FROM test_mes_center.b01_device_task  where (dept_name='WE班组' OR dept_name='WE') {4})", wecolour1, wecolour2, wecolour3, wecolour4, welimit);
                int result2 = ser2.InsertSql(srt2, out mp2);
                if (result2 > 0)
                {
                    int ret2 = ser2.DeleteSql(string.Format("DELETE from test_nfinebase.sys_tasklist where (Team='WE班组' OR Team='WE') and id<{0}", mp2));

                    LogHelper.Info(string.Format("WE任务清单Insert执行成功:{0}条,Update执行成功:{1}条，时间：{2}", result2, ret2, DateTime.Now.ToString()));
                }
                else
                {
                    LogHelper.Error("WE任务清单执行失败");
                }
                #endregion

                #region 设备清单-班组任务
                int el = 0;
                DbService elser = new DbService(EnStr, "MySQL");
                string elsrt = string.Format(@"INSERT INTO test_nfinebase.sys_equipmentlist(Equipment_Name,Equipment_Url,Mold_No,Workpieces_Name,Workpieces_Url,Yield,Jiadong,Team,Colour,CreationTime)
                    (SELECT device_name,device_pic_url,mold_no,part_name,part_pic_url,process_count,activation,dept_name,CASE WHEN device_state=-1 THEN '{0}' WHEN device_state=0 THEN '{1}' 
                    WHEN device_state=1 THEN '{2}' WHEN device_state=2 THEN '{3}' ELSE '' END device_state ,now() from test_mes_center.b02_device_running_state 
                    where (dept_name='CNC班组' OR dept_name='CNC') {4})",
                    cnccolourdr1, cnccolourdr2, cnccolourdr3, cnccolourdr4, cnclimitdr);
                int elsult = elser.InsertSql(elsrt, out el);
                if (elsult > 0)
                {
                    int elret = elser.DeleteSql(string.Format("DELETE from test_nfinebase.sys_equipmentlist where (Team='CNC班组' OR Team='CNC') and id<{0}", el));

                    LogHelper.Info(string.Format("CNC设备清单Insert执行成功:{0}条,Update执行成功:{1}条，时间：{2}", elsult, elret, DateTime.Now.ToString()));
                }
                else
                {
                    LogHelper.Error("CNC设备清单执行失败");
                }

                int el1 = 0;
                DbService elser1 = new DbService(EnStr, "MySQL");
                string elsrt1 = string.Format(@"INSERT INTO test_nfinebase.sys_equipmentlist(Equipment_Name,Equipment_Url,Mold_No,Workpieces_Name,Workpieces_Url,Yield,Jiadong,Team,Colour,CreationTime)
                    (SELECT device_name,device_pic_url,mold_no,part_name,part_pic_url,process_count,activation,dept_name,CASE WHEN device_state=-1 THEN '{0}' WHEN device_state=0 THEN '{1}' 
                    WHEN device_state=1 THEN '{2}' WHEN device_state=2 THEN '{3}' ELSE '' END device_state ,now() from test_mes_center.b02_device_running_state 
                    where (dept_name='EDM班组' OR dept_name='EDM') {4})",
                    edmcolourdr1, edmcolourdr2, edmcolourdr3, edmcolourdr4, edmlimitdr);
                int elsult1 = elser1.InsertSql(elsrt1, out el1);
                if (elsult1 > 0)
                {
                    int elret1 = elser1.DeleteSql(string.Format("DELETE from test_nfinebase.sys_equipmentlist where (Team='EDM班组' OR Team='EDM') and id<{0}", el1));

                    LogHelper.Info(string.Format("EDM设备清单Insert执行成功:{0}条,Update执行成功:{1}条，时间：{2}", elsult1, elret1, DateTime.Now.ToString()));
                }
                else
                {
                    LogHelper.Error("EDM设备清单执行失败");
                }

                int el2 = 0;
                DbService elser2 = new DbService(EnStr, "MySQL");
                string elsrt2 = string.Format(@"INSERT INTO test_nfinebase.sys_equipmentlist(Equipment_Name,Equipment_Url,Mold_No,Workpieces_Name,Workpieces_Url,Yield,Jiadong,Team,Colour,CreationTime)
                    (SELECT device_name,device_pic_url,mold_no,part_name,part_pic_url,process_count,activation,dept_name,CASE WHEN device_state=-1 THEN '{0}' WHEN device_state=0 THEN '{1}' 
                    WHEN device_state=1 THEN '{2}' WHEN device_state=2 THEN '{3}' ELSE '' END device_state ,now() from test_mes_center.b02_device_running_state 
                    where (dept_name='WE班组' OR dept_name='WE') {4})",
                    wecolourdr1, wecolourdr2, wecolourdr3, wecolourdr4, welimitdr);
                int elsult2 = elser2.InsertSql(elsrt2, out el2);
                if (elsult2 > 0)
                {
                    int elret2 = elser2.DeleteSql(string.Format("DELETE from test_nfinebase.sys_equipmentlist where (Team='WE班组' OR Team='WE') and id<{0}", el2));

                    LogHelper.Info(string.Format("WE设备清单Insert执行成功:{0}条,Update执行成功:{1}条，时间：{2}", elsult2, elret2, DateTime.Now.ToString()));
                }
                else
                {
                    LogHelper.Error("WE设备清单执行失败");
                }
                #endregion

                #region 班组合格率-品质工程
                int re11 = 0;
                DbService ds11 = new DbService(EnStr, "MySQL");
                string srt11 = string.Format(@"INSERT INTO test_nfinebase.Sys_QualityOTeamPassRate(DeviceType,DeviceName,Number,Colour,CreationTime)
                    (
		                    SELECT dept_name,'合格率',pass_rate*100,CASE WHEN pass_rate>={0} THEN '{1}' ELSE '{2}' END Colour,now() FROM test_mes_center.e01_dept_pass_day 
		                    where acct_date >= DATE_FORMAT(DATE_SUB(NOW(), INTERVAL 30 DAY), '%Y-%m-%d') and acct_date <= CURDATE()
                    )", pass_rate_days, DY_pass_rate_days_colour, XY_pass_rate_days_colour);
                int sult11 = ds11.InsertSql(srt11, out re11);
                if (sult11 > 0)
                {
                    int ret11 = ds11.DeleteSql(string.Format("DELETE from test_nfinebase.Sys_QualityOTeamPassRate where id<{0}", re11));

                    LogHelper.Info(string.Format("品质工程-班组合格率-Insert执行成功:{0}条,Update执行成功:{1}条，时间：{2}", sult11, ret11, DateTime.Now.ToString()));
                }
                else
                {
                    LogHelper.Error("品质工程-班组合格率-执行失败");
                }
                #endregion

                #region 班组合格率趋势-品质工程
                int re12 = 0;
                DbService ds12 = new DbService(EnStr, "MySQL");
                string srt12 = string.Format(@"INSERT INTO test_nfinebase.Sys_QualityOPassRateTrend(Month_Day,Device_Name,TrendRate,CreationTime)
                    (
		                    select acct_date,dept_name,pass_rate*100,now() from test_mes_center.e02_dept_pass_month
		                    WHERE acct_date >= DATE_FORMAT(DATE_SUB(NOW(), INTERVAL 13 Month), '%Y-%m-%d') and acct_date <= date_format(CURDATE(),'%Y-%m')
                    )");
                int sult12 = ds12.InsertSql(srt12, out re12);
                if (sult12 > 0)
                {
                    int ret12 = ds12.DeleteSql(string.Format("DELETE from test_nfinebase.Sys_QualityOPassRateTrend where id<{0}", re12));

                    LogHelper.Info(string.Format("品质工程-班组合格率趋势-Insert执行成功:{0}条,Update执行成功:{1}条，时间：{2}", sult12, ret12, DateTime.Now.ToString()));
                }
                else
                {
                    LogHelper.Error("品质工程-班组合格率趋势-执行失败");
                }
                #endregion

                #region 异常处理结果统计-品质工程
                int re13 = 0;
                DbService ds13 = new DbService(EnStr, "MySQL");
                string srt13 = string.Format(@"INSERT INTO test_nfinebase.Sys_QualityOExceptionalResults(Type,Cost,CreationTime)
                    (
		                    SELECT exception_type,SUM(pass_rate)*100,now() FROM test_mes_center.e03_exception_summary 
		                    WHERE acct_date >= DATE_FORMAT(DATE_SUB(NOW(), INTERVAL 30 DAY), '%Y-%m-%d') and acct_date <= CURDATE()
		                    GROUP BY exception_type
                    )");
                int sult13 = ds13.InsertSql(srt13, out re13);
                if (sult13 > 0)
                {
                    int ret13 = ds13.DeleteSql(string.Format("DELETE from test_nfinebase.Sys_QualityOExceptionalResults where id<{0}", re13));

                    LogHelper.Info(string.Format("品质工程-异常处理结果统计-Insert执行成功:{0}条,Update执行成功:{1}条，时间：{2}", sult13, ret13, DateTime.Now.ToString()));
                }
                else
                {
                    LogHelper.Error("品质工程-异常处理结果统计-执行失败");
                }
                #endregion

                #region 异常处理单据明细-品质工程
                int re14 = 0;
                DbService ds14 = new DbService(EnStr, "MySQL");
                string srt14 = string.Format(@"INSERT INTO test_nfinebase.sys_qualityoexceptionaldetail(ProjectNo,ModuleNumber,WorkpieceNo,ExceptionalProcedure,TreatmentMethod,Colour,CreationTime)
                    (
		                    SELECT order_no,mold_no,part_sub_no,exception_process,treat_method,CASE WHEN  treat_method='{0}' THEN '{1}' ELSE '' END Colour,now()
		                    from test_mes_center.e04_exception_bill
		                    WHERE acct_date >= DATE_FORMAT(DATE_SUB(NOW(), INTERVAL 30 DAY), '%Y-%m-%d') and acct_date <= CURDATE()
                    )", TreatmentMethod, TreatmentMethodColour);
                int sult14 = ds14.InsertSql(srt14, out re14);
                if (sult14 > 0)
                {
                    int ret14 = ds14.DeleteSql(string.Format("DELETE from test_nfinebase.sys_qualityoexceptionaldetail where Id<{0}", re14));

                    LogHelper.Info(string.Format("品质工程-异常处理单据明细-Insert执行成功:{0}条,Update执行成功:{1}条，时间：{2}", sult14, ret14, DateTime.Now.ToString()));
                }
                else
                {
                    LogHelper.Error("品质工程-异常处理单据明细-执行失败");
                }
                #endregion

                #region 部门待处理/已处理异常统计-品质工程
                int re15 = 0;
                DbService ds15 = new DbService(EnStr, "MySQL");
                string srt15 = string.Format(@"INSERT INTO test_nfinebase.Sys_QualityOHandleExceptionalResults(DeviceType,DeviceName,TrendRate,CreationTime)
                    (
                        SELECT * from (
		                    SELECT dept_name,'待处理',wait_num,now() from  test_mes_center.e05_dept_exception_result WHERE acct_date >= DATE_FORMAT(DATE_SUB(NOW(), INTERVAL 30 DAY), '%Y-%m-%d') and acct_date <= CURDATE()
		                    UNION ALL
		                    SELECT dept_name,'已处理',finish_num,now() from  test_mes_center.e05_dept_exception_result WHERE acct_date >= DATE_FORMAT(DATE_SUB(NOW(), INTERVAL 30 DAY), '%Y-%m-%d') and acct_date <= CURDATE()
                        )b  ORDER BY dept_name
                    )");
                int sult15 = ds15.InsertSql(srt15, out re15);
                if (sult15 > 0)
                {
                    int ret15 = ds15.DeleteSql(string.Format("DELETE from test_nfinebase.Sys_QualityOHandleExceptionalResults where id<{0}", re15));

                    LogHelper.Info(string.Format("品质工程-部门待处理/已处理异常统计-Insert执行成功:{0}条,Update执行成功:{1}条，时间：{2}", sult15, ret15, DateTime.Now.ToString()));
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
