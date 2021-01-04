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

namespace ThirtyM
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
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

        //稼动率趋势
        public string cncdatepr = GetValue("cnc_process_real_date");
        public string edmdatepr = GetValue("edm_process_real_date");
        public string wedatepr = GetValue("we_process_real_date");
        //运行状态
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
        //工程主页
        public string CustomerAmountColor = GetValue("CustomerAmountColor");
        public string DeliveryCompletionRateColor = GetValue("DeliveryCompletionRateColor");
        public string OnTimeDeliveryMoldColor = GetValue("OnTimeDeliveryMoldColor");
        public string LateDeliveryMoldColor = GetValue("LateDeliveryMoldColor");
        public string MoldInProcessColor = GetValue("MoldInProcessColor");
        public string NormalProgressColor = GetValue("NormalProgressColor");
        public string ScheduleDelayColor = GetValue("ScheduleDelayColor");
        //生管主页
        public string wxdelaydays = GetValue("wx_delay_days");
        public string wxdelaydayscolour = GetValue("wx_delay_days_colour");
        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                #region 产能负荷-班组任务
                int cl = 0;
                DbService clser = new DbService(EnStr, "MySQL");
                string elsrt = string.Format(@"INSERT into test_nfinebase.sys_capacityload(Task_Type,Device_Name,Device_Number,Team,Colour,CreationTime) 
                (SELECT TaskType,DeviceName,DeviceNumber,dept_name,Colour,now() FROM(
                SELECT acct_date,'产能' TaskType,process_name DeviceName,SUM(capacity_hours) DeviceNumber,
                CASE WHEN plan_hours>capacity_hours THEN '{0}' ELSE '{1}' end Colour,dept_name
                from test_mes_center.b03_process_plan where (dept_name='CNC班组' OR dept_name='CNC')
                and acct_date>=CURDATE() and acct_date<=CURDATE()+{4}  GROUP  BY process_name
                UNION ALL
                SELECT acct_date,'负荷' TaskType,process_name DeviceName,SUM(plan_hours) DeviceNumber,
                CASE WHEN plan_hours>capacity_hours THEN '{2}' ELSE '{3}' end Colour,dept_name
                from test_mes_center.b03_process_plan  where (dept_name='CNC班组' OR dept_name='CNC')
                and acct_date>=CURDATE() and acct_date<=CURDATE()+{5} GROUP  BY process_name) b  
                ORDER BY DeviceName,TaskType ASC)", cnccolourcl2, cnccolourcl1, cnccolourfh2, cnccolourfh1, cncdate, cncdate);
                int clsult = clser.InsertSql(elsrt, out cl);
                if (clsult > 0)
                {
                    int elret = clser.DeleteSql(string.Format("DELETE from test_nfinebase.sys_capacityload  where (Team='CNC班组' OR Team='CNC') and id<{0}", cl));

                    LogHelper.Info(string.Format("CNC产能负荷Insert执行成功:{0}条,Update执行成功:{1}条，时间：{2}", clsult, elret, DateTime.Now.ToString()));
                }
                else
                {
                    LogHelper.Error("CNC产能负荷执行失败");
                }

                int cl1 = 0;
                DbService clser1 = new DbService(EnStr, "MySQL");
                string elsrt1 = string.Format(@"INSERT into test_nfinebase.sys_capacityload(Task_Type,Device_Name,Device_Number,Team,Colour,CreationTime) 
                (SELECT TaskType,DeviceName,DeviceNumber,dept_name,Colour,now() FROM(
                SELECT acct_date,'产能' TaskType,process_name DeviceName,SUM(capacity_hours) DeviceNumber,
                CASE WHEN plan_hours>capacity_hours THEN '{0}' ELSE '{1}' end Colour,dept_name
                from test_mes_center.b03_process_plan where (dept_name='EDM班组' OR dept_name='EDM')
                and acct_date>=CURDATE() and acct_date<=CURDATE()+{4}  GROUP  BY process_name
                UNION ALL
                SELECT acct_date,'负荷' TaskType,process_name DeviceName,SUM(plan_hours) DeviceNumber,
                CASE WHEN plan_hours>capacity_hours THEN '{2}' ELSE '{3}' end Colour,dept_name
                from test_mes_center.b03_process_plan  where (dept_name='EDM班组' OR dept_name='EDM')
                and acct_date>=CURDATE() and acct_date<=CURDATE()+{5} GROUP  BY process_name) b  
                ORDER BY DeviceName,TaskType ASC)", edmcolourcl2, edmcolourcl1, edmcolourfh2, edmcolourfh1, edmdate, edmdate);
                int clsult1 = clser1.InsertSql(elsrt1, out cl1);
                if (clsult1 > 0)
                {
                    int elret1 = clser1.DeleteSql(string.Format("DELETE from test_nfinebase.sys_capacityload where (Team='EDM班组' OR Team='EDM') and id<{0}", cl1));

                    LogHelper.Info(string.Format("EDM产能负荷Insert执行成功:{0}条,Update执行成功:{1}条，时间：{2}", clsult1, elret1, DateTime.Now.ToString()));
                }
                else
                {
                    LogHelper.Error("EDM产能负荷执行失败");
                }

                int cl2 = 0;
                DbService clser2 = new DbService(EnStr, "MySQL");
                string elsrt2 = string.Format(@"INSERT into test_nfinebase.sys_capacityload(Task_Type,Device_Name,Device_Number,Team,Colour,CreationTime) 
                (SELECT TaskType,DeviceName,DeviceNumber,dept_name,Colour,now() FROM(
                SELECT acct_date,'产能' TaskType,process_name DeviceName,SUM(capacity_hours) DeviceNumber,
                CASE WHEN plan_hours>capacity_hours THEN '{0}' ELSE '{1}' end Colour,dept_name
                from test_mes_center.b03_process_plan where (dept_name='WE班组' OR dept_name='WE')
                and acct_date>=CURDATE() and acct_date<=CURDATE()+{4}  GROUP  BY process_name
                UNION ALL
                SELECT acct_date,'负荷' TaskType,process_name DeviceName,SUM(plan_hours) DeviceNumber,
                CASE WHEN plan_hours>capacity_hours THEN '{2}' ELSE '{3}' end Colour,dept_name
                from test_mes_center.b03_process_plan  where (dept_name='WE班组' OR dept_name='WE')
                and acct_date>=CURDATE() and acct_date<=CURDATE()+{5} GROUP  BY process_name) b  
                ORDER BY DeviceName,TaskType ASC)", wecolourcl2, wecolourcl1, wecolourfh2, wecolourfh1, wedate, wedate);
                int clsult2 = clser2.InsertSql(elsrt2, out cl2);
                if (clsult2 > 0)
                {
                    int elret2 = clser2.DeleteSql(string.Format("DELETE from test_nfinebase.sys_capacityload where (Team='WE班组' OR Team='WE') and id<{0}", cl2));

                    LogHelper.Info(string.Format("WE产能负荷Insert执行成功:{0}条,Update执行成功:{1}条，时间：{2}", clsult2, elret2, DateTime.Now.ToString()));
                }
                else
                {
                    LogHelper.Error("WE产能负荷执行失败");
                }
                #endregion

                #region 稼动率趋势-班组任务
                int td = 0;
                DbService tdser = new DbService(EnStr, "MySQL");
                string tdsrt = string.Format(@"INSERT INTO test_nfinebase.sys_trend(Month_Day,Device_Name,TrendRate,Team,CreationTime)
                (select SUBSTR(acct_date,6,5),process_name,activation,dept_name,now() from test_mes_center.b04_process_real  
                where  DATE_SUB(CURDATE(), INTERVAL {0} DAY) <= date(acct_date) and (dept_name='CNC班组' OR dept_name='CNC')  ORDER BY acct_date ASC)", cncdatepr);
                int tdresult = tdser.InsertSql(tdsrt, out td);
                if (tdresult > 0)
                {
                    int tdret = tdser.DeleteSql(string.Format("DELETE from test_nfinebase.sys_trend where (Team='CNC班组' OR Team='CNC') and id<{0}", td));

                    LogHelper.Info(string.Format("CNC稼动率Insert执行成功:{0}条,Update执行成功:{1}条，时间：{2}", tdresult, tdret, DateTime.Now.ToString()));
                }
                else
                {
                    LogHelper.Error("CNC稼动率执行失败");
                }

                int td1 = 0;
                DbService tdser1 = new DbService(EnStr, "MySQL");
                string tdsrt1 = string.Format(@"INSERT INTO test_nfinebase.sys_trend(Month_Day,Device_Name,TrendRate,Team,CreationTime)
                (select SUBSTR(acct_date,6,5),process_name,activation,dept_name,now() from test_mes_center.b04_process_real  
                where  DATE_SUB(CURDATE(), INTERVAL {0} DAY) <= date(acct_date) and (dept_name='EDM班组' OR dept_name='EDM')  ORDER BY acct_date ASC)", edmdatepr);
                int tdresult1 = tdser1.InsertSql(tdsrt1, out td1);
                if (tdresult1 > 0)
                {
                    int tdret1 = tdser1.DeleteSql(string.Format("DELETE from test_nfinebase.sys_trend where (Team='EDM班组' OR Team='EDM') and id<{0}", td1));

                    LogHelper.Info(string.Format("EDM稼动率Insert执行成功:{0}条,Update执行成功:{1}条，时间：{2}", tdresult1, tdret1, DateTime.Now.ToString()));
                }
                else
                {
                    LogHelper.Error("CNC稼动率执行失败");
                }

                int td2 = 0;
                DbService tdser2 = new DbService(EnStr, "MySQL");
                string tdsrt2 = string.Format(@"INSERT INTO test_nfinebase.sys_trend(Month_Day,Device_Name,TrendRate,Team,CreationTime)
                (select SUBSTR(acct_date,6,5),process_name,activation,dept_name,now() from test_mes_center.b04_process_real  
                where  DATE_SUB(CURDATE(), INTERVAL {0} DAY) <= date(acct_date) and (dept_name='WE班组' OR dept_name='WE')  ORDER BY acct_date ASC)", wedatepr);
                int tdresult2 = tdser2.InsertSql(tdsrt2, out td2);
                if (tdresult2 > 0)
                {
                    int tdret2 = tdser2.DeleteSql(string.Format("DELETE from test_nfinebase.sys_trend where (Team='WE班组' OR Team='WE') and id<{0}", td2));

                    LogHelper.Info(string.Format("WE稼动率Insert执行成功:{0}条,Update执行成功:{1}条，时间：{2}", tdresult2, tdret2, DateTime.Now.ToString()));
                }
                else
                {
                    LogHelper.Error("WE稼动率执行失败");
                }
                #endregion

                #region 运行状态
                //int re = 0;
                //DbService ds = new DbService(EnStr, "MySQL");
                //string srt = string.Format(@"INSERT INTO test_nfinebase.Sys_RunningState(Picture_Tip,Picture_Url,Describe1,Describe2,Describe3,Describe4,Describe5,Describe6,Describe7,Describe8,CreationTime,DescribeColor1,DescribeColor2,DescribeColor3,DescribeColor4,DescribeColor5,DescribeColor6,DescribeColor7,DescribeColor8)
                //(
		              //  SELECT '测试显示' Picture_Tip,'/Content/img/product/runningstate/01.png' Picture_Url,
		              //  MAX(CASE WHEN device_name  = 'CNC1发那科' THEN  CONCAT(device_name ,'<br>',state_name) END) AS Describe1,
		              //  MAX(CASE WHEN device_name  = 'CNC2发那科' THEN  CONCAT(device_name ,'<br>',state_name) END) AS Describe2,
		              //  MAX(CASE WHEN device_name  = 'CNC3发那科' THEN  CONCAT(device_name ,'<br>',state_name) END) AS Describe3,
		              //  MAX(CASE WHEN device_name  = 'CMM2海克斯康' THEN  CONCAT(device_name ,'<br>',state_name) END) AS Describe4,
		              //  MAX(CASE WHEN device_name  = 'Robot' THEN  CONCAT(device_name ,'<br>',state_name) END) AS Describe5,
		              //  MAX(CASE WHEN device_name  = '清洗机' THEN  CONCAT(device_name ,'<br>',state_name) END) AS Describe6,
		              //  (SELECT group_concat((state_num)SEPARATOR ';') FROM test_mes_center.r02_shelf_state  WHERE shelf_name='料架A') AS Describe7,
		              //  (SELECT group_concat((state_num)SEPARATOR ';') FROM test_mes_center.r02_shelf_state  WHERE shelf_name='料架B') AS Describe8,now(),
                //        MAX(CASE WHEN device_name  = 'CNC1发那科' AND state_code=0 THEN '{0}'  WHEN device_name  = 'CNC1发那科' AND state_code=1 THEN '{1}'                 //        WHEN device_name  = 'CNC1发那科' AND state_code=2 THEN '{2}' WHEN device_name  = 'CNC1发那科' AND state_code=3 THEN '{3}'
                //        WHEN device_name  = 'CNC1发那科' AND state_code=4 THEN '{4}' WHEN device_name  = 'CNC1发那科' AND state_code=5 THEN '{5}'
                //        WHEN device_name  = 'CNC1发那科' AND state_code=6 THEN '{6}' END) AS DescribeColor1,
                //        MAX(CASE WHEN device_name  = 'CNC2发那科' AND state_code=0 THEN '{0}'  WHEN device_name  = 'CNC2发那科' AND state_code=1 THEN '{1}' 
                //        WHEN device_name  = 'CNC2发那科' AND state_code=2 THEN '{2}' WHEN device_name  = 'CNC2发那科' AND state_code=3 THEN '{3}'
                //        WHEN device_name  = 'CNC2发那科' AND state_code=4 THEN '{4}' WHEN device_name  = 'CNC2发那科' AND state_code=5 THEN '{5}'
                //        WHEN device_name  = 'CNC2发那科' AND state_code=6 THEN '{6}' END) AS DescribeColor2,
                //        MAX(CASE WHEN device_name  = 'CNC2发那科' AND state_code=0 THEN '{0}'  WHEN device_name  = 'CNC2发那科' AND state_code=1 THEN '{1}' 
                //        WHEN device_name  = 'CNC3发那科' AND state_code=2 THEN '{2}' WHEN device_name  = 'CNC2发那科' AND state_code=3 THEN '{3}'
                //        WHEN device_name  = 'CNC3发那科' AND state_code=4 THEN '{4}' WHEN device_name  = 'CNC2发那科' AND state_code=5 THEN '{5}'
                //        WHEN device_name  = 'CNC3发那科' AND state_code=6 THEN '{6}' END) AS DescribeColor3,
                //        MAX(CASE WHEN device_name  = 'CMM2海克斯康' AND state_code=0 THEN '{0}'  WHEN device_name  = 'CMM2海克斯康' AND state_code=1 THEN '{1}' 
                //        WHEN device_name  = 'CMM2海克斯康' AND state_code=2 THEN '{2}' WHEN device_name  = 'CMM2海克斯康' AND state_code=3 THEN '{3}'
                //        WHEN device_name  = 'CMM2海克斯康' AND state_code=4 THEN '{4}' WHEN device_name  = 'CMM2海克斯康' AND state_code=5 THEN '{5}'
                //        WHEN device_name  = 'CMM2海克斯康' AND state_code=6 THEN '{6}' END) AS DescribeColor4,
                //        MAX(CASE WHEN device_name  = 'Robot' AND state_code=0 THEN '{0}'  WHEN device_name  = 'Robot' AND state_code=1 THEN '{1}' 
                //        WHEN device_name  = 'Robot' AND state_code=2 THEN '{2}' WHEN device_name  = 'Robot' AND state_code=3 THEN '{3}'
                //        WHEN device_name  = 'Robot' AND state_code=4 THEN '{4}' WHEN device_name  = 'Robot' AND state_code=5 THEN '{5}'
                //        WHEN device_name  = 'Robot' AND state_code=6 THEN '{6}' END) AS DescribeColor5,
                //        MAX(CASE WHEN device_name  = '清洗机' AND state_code=0 THEN '{0}'  WHEN device_name  = '清洗机' AND state_code=1 THEN '{1}' 
                //        WHEN device_name  = '清洗机' AND state_code=2 THEN '{2}' WHEN device_name  = '清洗机' AND state_code=3 THEN '{3}'
                //        WHEN device_name  = '清洗机' AND state_code=4 THEN '{4}' WHEN device_name  = '清洗机' AND state_code=5 THEN '{5}'
                //        WHEN device_name  = '清洗机' AND state_code=6 THEN '{6}' END) AS DescribeColor6,'{7}','{8}'
		              //  FROM test_mes_center.r01_device_state
                //)", offlinecolour, standbycolour, inoperationcolour, suspendcolour, giveanalarmcolour, notreadycolour, stopitcolour, NotStartedcolour + ';' + Conductcolour + ';' + Completedcolour + ';' + Abnormalcolour + ';' + Stopcolour + ';' + Cancelcolour, NotStartedcolour + ';' + Conductcolour + ';' + Completedcolour + ';' + Abnormalcolour + ';' + Stopcolour + ';' + Cancelcolour);
                //int sult = ds.InsertSql(srt, out re);
                //if (sult > 0)
                //{
                //    int ret = ds.DeleteSql(string.Format("DELETE from test_nfinebase.Sys_RunningState where id<{0}", re));

                //    LogHelper.Info(string.Format("自动化线-运行状态-Insert执行成功:{0}条,Update执行成功:{1}条，时间：{2}", sult, ret, DateTime.Now.ToString()));
                //}
                //else
                //{
                //    LogHelper.Error("自动化线-运行状态-执行失败");
                //}
                #endregion

                #region 总生产成本-经营概览
                int re11 = 0;
                DbService ds11 = new DbService(EnStr, "MySQL");
                //SELECT '物料' Name, material_cost Cost, acct_date from test_mes_center.a01_manufacture_all_cost where acct_date >= DATE_FORMAT(DATE_SUB(NOW(), INTERVAL 30 DAY), '%Y-%m-%d') and acct_date <= CURDATE()
                //    UNION ALL
                string srt11 = string.Format(@"INSERT INTO test_nfinebase.sys_totalcyclecost(Name,Cost,AcctDate,CreationTime)
                    (
                        SELECT Name, Cost, acct_date, now() from(
                    SELECT '外协' Name, outsource_cost Cost, acct_date from test_mes_center.a01_manufacture_all_cost where acct_date >= DATE_FORMAT(DATE_SUB(NOW(), INTERVAL 30 DAY), '%Y-%m-%d') and acct_date <= CURDATE()
                    UNION ALL
                    SELECT '自制' Name, selfmake_cost Cost, acct_date from test_mes_center.a01_manufacture_all_cost where acct_date >= DATE_FORMAT(DATE_SUB(NOW(), INTERVAL 30 DAY), '%Y-%m-%d') and acct_date <= CURDATE()
                    UNION ALL
                    SELECT '异常' Name, exception_cost Cost, acct_date from test_mes_center.a01_manufacture_all_cost where acct_date >= DATE_FORMAT(DATE_SUB(NOW(), INTERVAL 30 DAY), '%Y-%m-%d') and acct_date <= CURDATE()
                    )b ORDER BY b.acct_date
                    )");
                int sult11 = ds11.InsertSql(srt11, out re11);
                if (sult11 > 0)
                {
                    int ret11 = ds11.DeleteSql(string.Format("DELETE from  test_nfinebase.sys_totalcyclecost where id<{0}", re11));

                    LogHelper.Info(string.Format("经营概览-总生产成本-Insert执行成功:{0}条,Update执行成功:{1}条，时间：{2}", sult11, ret11, DateTime.Now.ToString()));
                }
                else
                {
                    LogHelper.Error("经营概览-总生产成本-执行失败");
                }
                #endregion

                #region 自制部门成本-经营概览
                int re12 = 0;
                DbService ds12 = new DbService(EnStr, "MySQL");
                string srt12 = string.Format(@"INSERT INTO test_nfinebase.sys_CostByDepartment(Name,Cost,AcctDate,CreationTime)
                    (
                        SELECT dept_name, selfmake_cost, acct_date, now() from test_mes_center.a02_manufacture_self_cost
                           WHERE acct_date >= DATE_FORMAT(DATE_SUB(NOW(), INTERVAL 30 DAY), '%Y-%m-%d') and acct_date <= CURDATE()
                    )");
                int sult12 = ds12.InsertSql(srt12, out re12);
                if (sult12 > 0)
                {
                    int ret12 = ds12.DeleteSql(string.Format("DELETE from  test_nfinebase.sys_CostByDepartment where id<{0}", re12));

                    LogHelper.Info(string.Format("经营概览-自制部门成本-Insert执行成功:{0}条,Update执行成功:{1}条，时间：{2}", sult12, ret12, DateTime.Now.ToString()));
                }
                else
                {
                    LogHelper.Error("经营概览-自制部门成本-执行失败");
                }
                #endregion

                #region 交期达成率-经营概览
                int re13 = 0;
                DbService ds13 = new DbService(EnStr, "MySQL");
                string srt13 = string.Format(@"INSERT INTO test_nfinebase.Sys_DeliveryCompletionRate(Month,DeliveryRate,CreationTime)
                    (
                        SELECT acct_date, scheduled_rate*100, now() from test_mes_center.a03_scheduled_rate
                            WHERE acct_date >= DATE_FORMAT(DATE_SUB(NOW(), INTERVAL 1 YEAR), '%Y-%m-%d') and acct_date <= date_format(CURDATE(),'%Y-%m')
                    )");
                int sult13 = ds13.InsertSql(srt13, out re13);
                if (sult13 > 0)
                {
                    int ret13 = ds13.DeleteSql(string.Format("DELETE from  test_nfinebase.Sys_DeliveryCompletionRate where id<{0}", re13));

                    LogHelper.Info(string.Format("经营概览-交期达成率-Insert执行成功:{0}条,Update执行成功:{1}条，时间：{2}", sult13, ret13, DateTime.Now.ToString()));
                }
                else
                {
                    LogHelper.Error("经营概览-交期达成率-执行失败");
                }
                #endregion

                #region 在制模具进度-经营概览
                int re14 = 0;
                DbService ds14 = new DbService(EnStr, "MySQL");
                string srt14 = string.Format(@"INSERT INTO test_nfinebase.Sys_MoldMakingProgress(MoldNo,MoldTest,Type,State,ProductName,PlannedDeliveryDate,EarlyWarning)
                    (
                        SELECT mold_no, version, mold_type, mold_state, order_name, plan_date,
                        CASE WHEN warning_rate1 = 0 AND warning_rate2 > 0 THEN warning_rate2
                        WHEN warning_rate1 > 0 AND warning_rate2 = 0  THEN  warning_rate1
                        WHEN warning_rate1 > 0 AND warning_rate2 > 0  THEN  CONCAT(warning_rate1 ,';', warning_rate2) ELSE 0 END EarlyWarning
                        FROM  test_mes_center.a04_on_make_process
                    )");
                int sult14 = ds14.InsertSql(srt14, out re14);
                if (sult14 > 0)
                {
                    int ret14 = ds14.DeleteSql(string.Format("DELETE from  test_nfinebase.Sys_MoldMakingProgress where id<{0}", re14));

                    LogHelper.Info(string.Format("经营概览-在制模具进度-Insert执行成功:{0}条,Update执行成功:{1}条，时间：{2}", sult14, ret14, DateTime.Now.ToString()));
                }
                else
                {
                    LogHelper.Error("经营概览-在制模具进度-执行失败");
                }
                #endregion

                #region 产能负载-经营概览
                int re15 = 0;
                DbService ds15 = new DbService(EnStr, "MySQL");
                string srt15 = string.Format(@"INSERT INTO test_nfinebase.Sys_BOCapacityLoad(DeviceType,DeviceName,Number,CreationTime)
                    (
                            SELECT dept_name,DeviceName,Number,CreationTime FROM(
                            SELECT dept_name, '产能' DeviceName, SUM(capacity_hours) Number, now() CreationTime  from test_mes_center.a05_capacity_plan_hours
                            where acct_date >= DATE_FORMAT(DATE_SUB(NOW(), INTERVAL 7 DAY), '%Y-%m-%d') and acct_date <= CURDATE() GROUP BY dept_name
                            UNION ALL
                            SELECT dept_name, '产能缺口' DeviceName, SUM(capacity_gap) Number, now()  from test_mes_center.a05_capacity_plan_hours
                            where acct_date >= DATE_FORMAT(DATE_SUB(NOW(), INTERVAL 7 DAY), '%Y-%m-%d') and acct_date <= CURDATE() GROUP BY dept_name
                            UNION ALL
                            SELECT dept_name, '负荷' DeviceName, SUM(plan_hours) Number, now()  from test_mes_center.a05_capacity_plan_hours
                            where acct_date >= DATE_FORMAT(DATE_SUB(NOW(), INTERVAL 7 DAY), '%Y-%m-%d') and acct_date <= CURDATE() GROUP BY dept_name
                            )b ORDER BY  dept_name,DeviceName ASC
                    )");
                int sult15 = ds15.InsertSql(srt15, out re15);
                if (sult15 > 0)
                {
                    int ret15 = ds15.DeleteSql(string.Format("DELETE from  test_nfinebase.Sys_BOCapacityLoad where id<{0}", re15));

                    LogHelper.Info(string.Format("经营概览-产能负载-Insert执行成功:{0}条,Update执行成功:{1}条，时间：{2}", sult15, ret15, DateTime.Now.ToString()));
                }
                else
                {
                    LogHelper.Error("经营概览-产能负载-执行失败");
                }
                #endregion

                #region 主要客户-经营概览
                int re16 = 0;
                DbService ds16 = new DbService(EnStr, "MySQL");
                string srt16 = string.Format(@"INSERT INTO test_nfinebase.Sys_KeyCustomers(Name,Number,CreationTime)
                    (
                            SELECT customer_name,mold_num*10, now()  from test_mes_center.a06_main_customer ORDER BY sort_id ASC
                    )");
                int sult16 = ds16.InsertSql(srt16, out re16);
                if (sult16 > 0)
                {
                    int ret16 = ds16.DeleteSql(string.Format("DELETE from test_nfinebase.Sys_KeyCustomers where id<{0}", re16));

                    LogHelper.Info(string.Format("经营概览-主要客户-Insert执行成功:{0}条,Update执行成功:{1}条，时间：{2}", sult16, ret16, DateTime.Now.ToString()));
                }
                else
                {
                    LogHelper.Error("经营概览-主要客户-执行失败");
                }
                #endregion

                #region 员工工程表-工程主页
                int re2 = 0;
                DbService ds2 = new DbService(EnStr, "MySQL");
                string srt2 = string.Format(@"INSERT INTO test_nfinebase.Sys_UserEngineering(Account,CustomerAmount,DeliveryCompletionRate,OnTimeDeliveryMold,LateDeliveryMold,MoldInProcess,
                    NormalProgress,ScheduleDelay,CreationTime,CustomerAmountColor,DeliveryCompletionRateColor,OnTimeDeliveryMoldColor,LateDeliveryMoldColor,MoldInProcessColor,NormalProgressColor,ScheduleDelayColor)
                    (
                    SELECT  MAX(CASE WHEN sort_id  = '1' THEN item_value END) AS Account,
			                MAX(CASE WHEN sort_id  = '2' THEN item_value END) AS CustomerAmount,
			                MAX(CASE WHEN sort_id  = '3' THEN item_value END) AS DeliveryCompletionRate,
			                MAX(CASE WHEN sort_id  = '4' THEN item_value END) AS OnTimeDeliveryMold,
			                MAX(CASE WHEN sort_id  = '5' THEN item_value END) AS LateDeliveryMold,
			                MAX(CASE WHEN sort_id  = '6' THEN item_value END) AS MoldInProcess,
			                MAX(CASE WHEN sort_id  = '7' THEN item_value END) AS NormalProgress,
			                MAX(CASE WHEN sort_id  = '8' THEN item_value END) AS ScheduleDelay,now(),'{0}','{1}','{2}','{3}','{4}','{5}','{6}'
                     FROM test_mes_center.d01_project_main
                    )", CustomerAmountColor, DeliveryCompletionRateColor, OnTimeDeliveryMoldColor, LateDeliveryMoldColor, MoldInProcessColor, NormalProgressColor, ScheduleDelayColor);
                int sult2 = ds2.InsertSql(srt2, out re2);
                if (sult2 > 0)
                {
                    int ret2 = ds2.DeleteSql(string.Format("DELETE from test_nfinebase.Sys_UserEngineering where id<{0}", re2));

                    LogHelper.Info(string.Format("工程主页-员工工程表-Insert执行成功:{0}条,Update执行成功:{1}条，时间：{2}", sult2, ret2, DateTime.Now.ToString()));
                }
                else
                {
                    LogHelper.Error("工程主页-员工工程表-执行失败");
                }
                #endregion

                #region 交期达成率趋势-工程主页
                int re21 = 0;
                DbService ds21 = new DbService(EnStr, "MySQL");
                string srt21 = string.Format(@"INSERT INTO test_nfinebase.Sys_EHDeliveryCompletionRate(Month,DeliveryRate,CreationTime)
                    (
                        SELECT acct_date, plan_finished_rate*100, now() from test_mes_center.d02_scheduled_rate
                            WHERE acct_date >= DATE_FORMAT(DATE_SUB(NOW(), INTERVAL 1 YEAR), '%Y-%m-%d') and acct_date <= date_format(CURDATE(),'%Y-%m')
                    )");
                int sult21 = ds21.InsertSql(srt21, out re21);
                if (sult21 > 0)
                {
                    int ret21 = ds21.DeleteSql(string.Format("DELETE from test_nfinebase.Sys_EHDeliveryCompletionRate where id<{0}", re21));

                    LogHelper.Info(string.Format("工程主页-交期达成率-Insert执行成功:{0}条,Update执行成功:{1}条，时间：{2}", sult21, ret21, DateTime.Now.ToString()));
                }
                else
                {
                    LogHelper.Error("工程主页-交期达成率-执行失败");
                }
                #endregion

                #region 上月交付模具数量-工程主页
                int re23 = 0;
                DbService ds23 = new DbService(EnStr, "MySQL");
                string srt23 = string.Format(@"INSERT INTO test_nfinebase.Sys_EHNumberMoldsDelivered(Type,Number,CreationTime)
                    (
		                   SELECT * FROM (
	                            SELECT '按期' Type,normal_num Number,now()  from test_mes_center.d03_finish_mold_num  
	                            UNION ALL
	                            SELECT '延期' Type,delay_num Number,now()  from test_mes_center.d03_finish_mold_num 
	                       )b	
                    )");
                int sult23 = ds23.InsertSql(srt23, out re23);
                if (sult23 > 0)
                {
                    int ret23 = ds23.DeleteSql(string.Format("DELETE from test_nfinebase.Sys_EHNumberMoldsDelivered where id<{0}", re23));

                    LogHelper.Info(string.Format("工程主页-上月交付模具数量-Insert执行成功:{0}条,Update执行成功:{1}条，时间：{2}", sult23, ret23, DateTime.Now.ToString()));
                }
                else
                {
                    LogHelper.Error("工程主页-上月交付模具数量-执行失败");
                }
                #endregion

                #region 生产进度-工程主页
                int re24 = 0;
                DbService ds24 = new DbService(EnStr, "MySQL");
                string srt24 = string.Format(@"INSERT INTO test_nfinebase.Sys_EHProductionSchedule(Name,Number,CreationTime)
                    (
                        SELECT * From (
		                    SELECT '进度正常' Name,normal_num Number,now()  from test_mes_center.d04_on_make_mold  
		                    UNION ALL
		                    SELECT '已过交期' Name,delay_make_num+delay_other_num Number,now()  from test_mes_center.d04_on_make_mold  
                            )b
                    )");
                int sult24 = ds24.InsertSql(srt24, out re24);
                if (sult24 > 0)
                {
                    int ret24 = ds24.DeleteSql(string.Format("DELETE from test_nfinebase.Sys_EHProductionSchedule where id<{0}", re24));

                    LogHelper.Info(string.Format("工程主页-生产进度-Insert执行成功:{0}条,Update执行成功:{1}条，时间：{2}", sult24, ret24, DateTime.Now.ToString()));
                }
                else
                {
                    LogHelper.Error("工程主页-生产进度-执行失败");
                }
                #endregion

                #region 延期模具列表-工程主页
                int re25 = 0;
                DbService ds25 = new DbService(EnStr, "MySQL");

                //特殊情况，先删除再插入
                int ret25 = ds25.DeleteSql(string.Format("DELETE from test_nfinebase.Sys_EHDelayMoldList"));
                string srt25 = string.Format(@"INSERT INTO test_nfinebase.Sys_EHDelayMoldList(MoldNo,Customers,Type,PlannedDeliveryDate,EarlyWarning)
	                (
			                SELECT mold_no, version, mold_type, plan_date,
			                CASE WHEN warning_rate1 = 0 AND warning_rate2 > 0 THEN warning_rate2
			                WHEN warning_rate1 > 0 AND warning_rate2 = 0  THEN  warning_rate1
			                WHEN warning_rate1 > 0 AND warning_rate2 > 0  THEN  CONCAT(warning_rate1 ,';', warning_rate2) ELSE 0 END EarlyWarning
			                FROM  test_mes_center.d05_delay_mold
	                )");
                int sult25 = ds25.InsertSql(srt25, out re25);

                LogHelper.Info(string.Format("工程主页-延期模具列表-Insert执行成功:{0}条,Update执行成功:{1}条，时间：{2}", sult25, ret25, DateTime.Now.ToString()));
                //if (sult25 > 0)
                //{
                //    //int ret25 = ds25.DeleteSql(string.Format("DELETE from test_nfinebase.Sys_EHDelayMoldList where id<{0}", re25));
                //    //LogHelper.Info(string.Format("工程主页-延期模具列表-Insert执行成功:{0}条,Update执行成功:{1}条，时间：{2}", sult25, ret25, DateTime.Now.ToString()));
                //}
                //else
                //{
                //    LogHelper.Error("工程主页-延期模具列表-执行失败");
                //}
                #endregion

                #region 模具列表-工程主页
                int re27 = 0;
                DbService ds27 = new DbService(EnStr, "MySQL");
                string srt27 = string.Format(@"INSERT INTO test_nfinebase.Sys_CustomerListDetail(ListId,MoldName,MoldNo,CustomerName,ContactPerson,TN,MoldType,MoldState,MoldDate,MoldMaterial,Category,Colour,CreationTime)
                    (
		                    SELECT internal_id,mold_name,mold_no,version,customer_name,contact_person,mold_type,order_state,tryout_date,module_material,
		                    order_group,CASE WHEN light_state=1 THEN 'green' WHEN light_state=2 THEN 'yellow' WHEN light_state=3 THEN 'red' ELSE '' END Colour,now()
   	                    FROM test_mes_center.d07_mold_info
                    )");
                int sult27 = ds27.InsertSql(srt27, out re27);
                if (sult27 > 0)
                {
                    int ret27 = ds27.DeleteSql(string.Format("DELETE from test_nfinebase.Sys_CustomerListDetail where id<{0}", re27));

                    LogHelper.Info(string.Format("工程主页-模具列表-Insert执行成功:{0}条,Update执行成功:{1}条，时间：{2}", sult27, ret27, DateTime.Now.ToString()));
                }
                else
                {
                    LogHelper.Error("工程主页-模具列表-执行失败");
                }
                #endregion

                #region  在制模具进度汇总-生管主页
                int re3 = 0;
                DbService ds3 = new DbService(EnStr, "MySQL");
                string srt3 = string.Format(@"INSERT INTO test_nfinebase.Sys_PMHomeMoldProgress(ProgressStatus,Cost,Display,CreationTime)
                    (
                        SELECT ProgressStatus, Cost, total_num, now() from(
                        SELECT '进度正常' ProgressStatus, normal_num Cost, total_num from test_mes_center.c01_on_make_process_total
                        UNION ALL
                        SELECT '进度延误' ProgressStatus, delay_num Cost, total_num from test_mes_center.c01_on_make_process_total
                        )b
                    )");
                int sult3 = ds3.InsertSql(srt3, out re3);
                if (sult3 > 0)
                {
                    int ret3 = ds3.DeleteSql(string.Format("DELETE from test_nfinebase.Sys_PMHomeMoldProgress where id<{0}", re3));

                    LogHelper.Info(string.Format("生管主页-在制模具进度汇总-Insert执行成功:{0}条,Update执行成功:{1}条，时间：{2}", sult3, ret3, DateTime.Now.ToString()));
                }
                else
                {
                    LogHelper.Error("生管主页-在制模具进度汇总-执行失败");
                }
                #endregion

                #region  延误模具明细-生管主页
                int re32 = 0;
                DbService ds32 = new DbService(EnStr, "MySQL");

                //特殊情况，先删除再插入
                int ret32 = ds32.DeleteSql(string.Format("DELETE from test_nfinebase.Sys_PMHomeDelayMold"));
                string srt32 = string.Format(@"INSERT INTO test_nfinebase.Sys_PMHomeDelayMold(MoldNo,Edition,Type,PlannedDeliveryDate,Progress)
                    (
                         SELECT mold_no, version, mold_type, plan_date,
                         CASE WHEN progress_rate1 = 0 AND progress_rate2 > 0 THEN progress_rate2
                         WHEN progress_rate1 > 0 AND progress_rate2 = 0  THEN  progress_rate1
                         WHEN progress_rate1 > 0 AND progress_rate2 > 0  THEN  CONCAT(progress_rate1 ,';', progress_rate2) ELSE 0 END progress
                       from test_mes_center.c02_delay_process
                    )");
                int sult32 = ds32.InsertSql(srt32, out re32);

                LogHelper.Info(string.Format("工程主页-延期模具列表-Insert执行成功:{0}条,Update执行成功:{1}条，时间：{2}", sult32, ret32, DateTime.Now.ToString()));
                #endregion

                #region  产能/负荷-生管主页
                int re33 = 0;
                DbService ds33 = new DbService(EnStr, "MySQL");
                string srt33 = string.Format(@"INSERT INTO test_nfinebase.Sys_PMHomeCapacityLoad(DeviceType,DeviceName,Number,CreationTime)
                    (
                            SELECT dept_name,DeviceName,Number,CreationTime FROM(
                            SELECT dept_name, '产能' DeviceName, SUM(capacity_hours) Number, now() CreationTime  from test_mes_center.c03_depart_capacity_plan where acct_date >= DATE_FORMAT(DATE_SUB(NOW(), INTERVAL 7 DAY), '%Y-%m-%d') and acct_date <= CURDATE()  GROUP BY dept_name
                            UNION ALL
                            SELECT dept_name, '负荷' DeviceName, SUM(plan_hours) Number, now()  from test_mes_center.c03_depart_capacity_plan where acct_date >= DATE_FORMAT(DATE_SUB(NOW(), INTERVAL 7 DAY), '%Y-%m-%d') and acct_date <= CURDATE()  GROUP BY dept_name
                            )b ORDER BY  dept_name,DeviceName ASC		
                    )");
                int sult33 = ds33.InsertSql(srt33, out re33);
                if (sult33 > 0)
                {
                    int ret33 = ds33.DeleteSql(string.Format("DELETE from test_nfinebase.Sys_PMHomeCapacityLoad where id<{0}", re33));

                    LogHelper.Info(string.Format("生管主页-产能/负荷-Insert执行成功:{0}条,Update执行成功:{1}条，时间：{2}", sult33, ret33, DateTime.Now.ToString()));
                }
                else
                {
                    LogHelper.Error("生管主页-产能/负荷-执行失败");
                }
                #endregion

                #region  外协按期交付率-生管主页
                int re34 = 0;
                DbService ds34 = new DbService(EnStr, "MySQL");
                string srt34 = string.Format(@"INSERT INTO test_nfinebase.Sys_PMHomeOutsourcingRate(Type,Cost,CreationTime)
                    (
                          SELECT * From(
		                    SELECT '按期' Type,SUM(CASE WHEN delay_days=0 THEN 1 ELSE 0 END) Cost,now()  from test_mes_center.c05_wx_plan_bill  where acct_date >= DATE_FORMAT(DATE_SUB(NOW(), INTERVAL 7 DAY), '%Y-%m-%d') and acct_date <= CURDATE()
		                    UNION ALL
		                    SELECT '延期' Type,SUM(CASE WHEN delay_days>0 THEN 1 ELSE 0 END) Cost,now()  from test_mes_center.c05_wx_plan_bill  where acct_date >= DATE_FORMAT(DATE_SUB(NOW(), INTERVAL 7 DAY), '%Y-%m-%d') and acct_date <= CURDATE()
                            )b
                    )");
                int sult34 = ds34.InsertSql(srt34, out re34);
                if (sult34 > 0)
                {
                    int ret34 = ds34.DeleteSql(string.Format("DELETE from test_nfinebase.Sys_PMHomeOutsourcingRate where id<{0}", re34));

                    LogHelper.Info(string.Format("生管主页-外协按期交付率-Insert执行成功:{0}条,Update执行成功:{1}条，时间：{2}", sult34, ret34, DateTime.Now.ToString()));
                }
                else
                {
                    LogHelper.Error("生管主页-外协按期交付率-执行失败");
                }
                #endregion

                #region  外协单据明细-生管主页
                int re35 = 0;
                DbService ds35 = new DbService(EnStr, "MySQL");
                string srt35 = string.Format(@"INSERT INTO test_nfinebase.Sys_PMHomeOutsourcingDetail(ModuleNumber,WorkpieceNo,WxBillNo,WorkingProcedure,Supplier,PlannedDeliveryDate,DaysOfExtension,DaysOfExtensionColor,OrderStatus,CreationTime)
                    (
                            SELECT  mold_no, part_sub_no, wx_bill_no, process_name, provider, plan_date, delay_days,CASE WHEN delay_days>{0} THEN '{1}' ELSE '' End  Color,wx_state, now()  from test_mes_center.c05_wx_plan_bill
                            where acct_date >= DATE_FORMAT(DATE_SUB(NOW(), INTERVAL 7 DAY), '%Y-%m-%d') and acct_date <= CURDATE()
                    )", wxdelaydays, wxdelaydayscolour);
                int sult35 = ds35.InsertSql(srt35, out re35);
                if (sult35 > 0)
                {
                    int ret35 = ds35.DeleteSql(string.Format("DELETE from test_nfinebase.Sys_PMHomeOutsourcingDetail where id<{0}", re35));

                    LogHelper.Info(string.Format("生管主页-外协单据明细-Insert执行成功:{0}条,Update执行成功:{1}条，时间：{2}", sult35, ret35, DateTime.Now.ToString()));
                }
                else
                {
                    LogHelper.Error("生管主页-外协单据明细-执行失败");
                }
                #endregion

                #region  稼动率趋势-生管主页
                int re38 = 0;
                DbService ds38 = new DbService(EnStr, "MySQL");
                string srt38 = string.Format(@"INSERT INTO test_nfinebase.Sys_PMHomeJiadongRate(Month_Day,Device_Name,TrendRate,CreationTime)
                    (
                            SELECT acct_date, dept_name, activation*100, now()  from test_mes_center.c08_activation_curve
                               WHERE acct_date >= DATE_FORMAT(DATE_SUB(NOW(), INTERVAL 1 YEAR), '%Y-%m-%d') and acct_date <= CURDATE()
                    )");
                int sult38 = ds38.InsertSql(srt38, out re38);
                if (sult38 > 0)
                {
                    int ret38 = ds38.DeleteSql(string.Format("DELETE from test_nfinebase.Sys_PMHomeJiadongRate where id<{0}", re38));

                    LogHelper.Info(string.Format("生管主页-稼动率趋势-Insert执行成功:{0}条,Update执行成功:{1}条，时间：{2}", sult38, ret38, DateTime.Now.ToString()));
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
        public static string GetValue(string key)
        {
            return ConfigurationManager.AppSettings[key].ToString().Trim();
        }
    }
}
