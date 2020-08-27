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

namespace SynEngineeringHomepage
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public static string dbnfin = GetValue("conn_nfinebase");//写入库
        public static string EnStr = DEncrypt.Decrypt(dbnfin);
        public string CustomerAmountColor = GetValue("CustomerAmountColor");
        public string DeliveryCompletionRateColor = GetValue("DeliveryCompletionRateColor");
        public string OnTimeDeliveryMoldColor = GetValue("OnTimeDeliveryMoldColor");
        public string LateDeliveryMoldColor = GetValue("LateDeliveryMoldColor");
        public string MoldInProcessColor = GetValue("MoldInProcessColor");
        public string NormalProgressColor = GetValue("NormalProgressColor");
        public string ScheduleDelayColor = GetValue("ScheduleDelayColor");
        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                #region 员工工程表
                int re = 0;
                DbService ds = new DbService(EnStr, "MySQL");
                string srt = string.Format(@"INSERT INTO nfinebase.Sys_UserEngineering(Account,CustomerAmount,DeliveryCompletionRate,OnTimeDeliveryMold,LateDeliveryMold,MoldInProcess,
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
                     FROM mes_center.d01_project_main
                    )", CustomerAmountColor, DeliveryCompletionRateColor, OnTimeDeliveryMoldColor, LateDeliveryMoldColor, MoldInProcessColor, NormalProgressColor, ScheduleDelayColor);
                int sult = ds.InsertSql(srt, out re);
                if (sult > 0)
                {
                    int ret = ds.DeleteSql(string.Format("UPDATE nfinebase.Sys_UserEngineering SET IsEffective=0 where id<{0}", re));

                    LogHelper.Info(string.Format("工程主页-员工工程表-Insert执行成功:{0}条,Update执行成功:{1}条，时间：{2}", sult, ret, DateTime.Now.ToString()));
                }
                else
                {
                    LogHelper.Error("工程主页-员工工程表-执行失败");
                }
                #endregion

                #region 交期达成率趋势
                int re2 = 0;
                DbService ds2 = new DbService(EnStr, "MySQL");
                string srt2 = string.Format(@"INSERT INTO nfinebase.Sys_EHDeliveryCompletionRate(Month,DeliveryRate,CreationTime)
                    (
                        SELECT acct_date, plan_finished_rate, now() from mes_center.d02_scheduled_rate
                            WHERE acct_date >= DATE_FORMAT(DATE_SUB(NOW(), INTERVAL 1 YEAR), '%Y-%m-%d') and acct_date <= date_format(CURDATE(),'%Y-%m')
                    )");
                int sult2 = ds2.InsertSql(srt2, out re2);
                if (sult2 > 0)
                {
                    int ret2 = ds2.DeleteSql(string.Format("UPDATE nfinebase.Sys_EHDeliveryCompletionRate SET IsEffective=0 where id<{0}", re2));

                    LogHelper.Info(string.Format("工程主页-交期达成率-Insert执行成功:{0}条,Update执行成功:{1}条，时间：{2}", sult2, ret2, DateTime.Now.ToString()));
                }
                else
                {
                    LogHelper.Error("工程主页-交期达成率-执行失败");
                }
                #endregion

                #region 上月交付模具数量
                int re3 = 0;
                DbService ds3 = new DbService(EnStr, "MySQL");
                string srt3 = string.Format(@"INSERT INTO nfinebase.Sys_EHNumberMoldsDelivered(Type,Number,CreationTime)
                    (
		                   SELECT * FROM (
	                            SELECT '按期' Type,normal_num Number,now()  from mes_center.d03_finish_mold_num  
	                            UNION ALL
	                            SELECT '延期' Type,delay_num Number,now()  from mes_center.d03_finish_mold_num 
	                       )b	
                    )");
                int sult3 = ds3.InsertSql(srt3, out re3);
                if (sult3 > 0)
                {
                    int ret3 = ds3.DeleteSql(string.Format("UPDATE nfinebase.Sys_EHNumberMoldsDelivered SET IsEffective=0 where id<{0}", re3));

                    LogHelper.Info(string.Format("工程主页-上月交付模具数量-Insert执行成功:{0}条,Update执行成功:{1}条，时间：{2}", sult3, ret3, DateTime.Now.ToString()));
                }
                else
                {
                    LogHelper.Error("工程主页-上月交付模具数量-执行失败");
                }
                #endregion

                #region 生产进度
                int re4 = 0;
                DbService ds4 = new DbService(EnStr, "MySQL");
                string srt4 = string.Format(@"INSERT INTO nfinebase.Sys_EHProductionSchedule(Name,Number,CreationTime)
                    (
                        SELECT * From (
		                    SELECT '进度正常' Name,normal_num Number,now()  from mes_center.d04_on_make_mold  
		                    UNION ALL
		                    SELECT '已过交期' Name,delay_make_num+delay_other_num Number,now()  from mes_center.d04_on_make_mold  
		                    UNION ALL
		                    SELECT '生产延误' Name,delay_make_num Number,now()  from mes_center.d04_on_make_mold  
                            )b
                    )");
                int sult4 = ds4.InsertSql(srt4, out re4);
                if (sult4 > 0)
                {
                    int ret4 = ds4.DeleteSql(string.Format("UPDATE nfinebase.Sys_EHProductionSchedule SET IsEffective=0 where id<{0}", re4));

                    LogHelper.Info(string.Format("工程主页-生产进度-Insert执行成功:{0}条,Update执行成功:{1}条，时间：{2}", sult4, ret4, DateTime.Now.ToString()));
                }
                else
                {
                    LogHelper.Error("工程主页-生产进度-执行失败");
                }
                #endregion

                #region 延期模具列表
                int re5 = 0;
                DbService ds5 = new DbService(EnStr, "MySQL");
                string srt5 = string.Format(@"INSERT INTO nfinebase.Sys_EHDelayMoldList(MoldNo,Customers,Type,PlannedDeliveryDate,EarlyWarning)
	                (
			                SELECT mold_no, version, mold_type, plan_date,
			                CASE WHEN warning_rate1 = 0 AND warning_rate2 > 0 THEN warning_rate2
			                WHEN warning_rate1 > 0 AND warning_rate2 = 0  THEN  warning_rate1
			                WHEN warning_rate1 > 0 AND warning_rate2 > 0  THEN  CONCAT(warning_rate1 ,';', warning_rate2) ELSE 0 END EarlyWarning
			                FROM  mes_center.d05_delay_mold
	                )");
                int sult5 = ds5.InsertSql(srt5, out re5);
                if (sult5 > 0)
                {
                    int ret5 = ds5.DeleteSql(string.Format("UPDATE nfinebase.Sys_EHDelayMoldList SET IsEffective=0 where id<{0}", re5));

                    LogHelper.Info(string.Format("工程主页-延期模具列表-Insert执行成功:{0}条,Update执行成功:{1}条，时间：{2}", sult5, ret5, DateTime.Now.ToString()));
                }
                else
                {
                    LogHelper.Error("工程主页-延期模具列表-执行失败");
                }
                #endregion

                #region 客户订单表
                //int re6 = 0;
                //DbService ds6 = new DbService(EnStr, "MySQL");
                //string srt6 = string.Format(@"");
                //int sult6 = ds6.InsertSql(srt6, out re6);
                //if (sult6 > 0)
                //{
                //    int ret6 = ds6.DeleteSql(string.Format("", re6));

                //    LogHelper.Info(string.Format("工程主页-客户订单表-Insert执行成功:{0}条,Update执行成功:{1}条，时间：{2}", sult6, ret6, DateTime.Now.ToString()));
                //}
                //else
                //{
                //    LogHelper.Error("工程主页-客户订单表-执行失败");
                //}
                #endregion

                #region 模具列表
                int re7 = 0;
                DbService ds7 = new DbService(EnStr, "MySQL");
                string srt7 = string.Format(@"INSERT INTO nfinebase.Sys_CustomerListDetail(ListId,MoldName,MoldNo,CustomerName,ContactPerson,TN,MoldType,MoldState,MoldDate,MoldMaterial,Category,Colour,CreationTime)
                    (
		                    SELECT internal_id,mold_name,mold_no,version,customer_name,contact_person,mold_type,order_state,tryout_date,module_material,
		                    order_group,CASE WHEN light_state=1 THEN 'green' WHEN light_state=2 THEN 'yellow' WHEN light_state=3 THEN 'red' ELSE '' END Colour,now()
   	                    FROM mes_center.d07_mold_info
                    )");
                int sult7 = ds7.InsertSql(srt7, out re7);
                if (sult7 > 0)
                {
                    int ret7 = ds7.DeleteSql(string.Format("UPDATE nfinebase.Sys_CustomerListDetail SET IsEffective=0 where id<{0}", re7));

                    LogHelper.Info(string.Format("工程主页-模具列表-Insert执行成功:{0}条,Update执行成功:{1}条，时间：{2}", sult7, ret7, DateTime.Now.ToString()));
                }
                else
                {
                    LogHelper.Error("工程主页-模具列表-执行失败");
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
