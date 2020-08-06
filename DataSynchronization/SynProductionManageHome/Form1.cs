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

namespace SynProductionManageHome
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public static string dbnfin = GetValue("conn_nfinebase");//写入库
        public static string EnStr = DEncrypt.Decrypt(dbnfin);
        //外协追踪-延期天数
        public string wxdelaydays = GetValue("wx_delay_days");
        //外协追踪-延期天数-颜色
        public string wxdelaydayscolour = GetValue("wx_delay_days_colour");
        //物料追踪-延期天数
        public string wldelaydays = GetValue("wl_delay_days");
        //物料追踪-延期天数-颜色
        public string wldelaydayscolour = GetValue("wl_delay_days_colour");
        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                #region  在制模具进度汇总
                int re = 0;
                DbService ds = new DbService(EnStr, "MySQL");
                string srt = string.Format(@"INSERT INTO nfinebase.sys_totalcyclecost(ProgressStatus,Cost,Display,CreationTime)
                    (
                        SELECT ProgressStatus, Cost, acct_date, now() from(
                        SELECT '进度正常' ProgressStatus, normal_num Cost, total_num from mes_center.a01_manufacture_all_cost
                        UNION ALL
                        SELECT '进度延误' ProgressStatus, delay_num Cost, total_num from mes_center.a01_manufacture_all_cost
                        )b
                    )");
                int sult = ds.InsertSql(srt, out re);
                if (sult > 0)
                {
                    int ret = ds.DeleteSql(string.Format("UPDATE nfinebase.sys_totalcyclecost SET IsEffective=0 where id<{0}",re));

                    LogHelper.Info(string.Format("生管主页-在制模具进度汇总-Insert执行成功:{0}条,Update执行成功:{1}条，时间：{2}", sult, ret, DateTime.Now.ToString()));
                }
                else
                {
                    LogHelper.Error("生管主页-在制模具进度汇总-执行失败");
                }
                #endregion

                #region  延误模具明细
                int re2 = 0;
                DbService ds2 = new DbService(EnStr, "MySQL");
                string srt2 = string.Format(@"INSERT INTO nfinebase.Sys_PMHomeDelayMold(MoldNo,Edition,Type,PlannedDeliveryDate,Progress)
                    (
                         SELECT mold_no, version, mold_type, plan_date,
                         CASE WHEN progress_rate1 = 0 AND progress_rate2 > 0 THEN progress_rate2

                         WHEN progress_rate1 > 0 AND progress_rate2 = 0  THEN  progress_rate1

                         WHEN progress_rate1 > 0 AND progress_rate2 > 0  THEN  progress_rate1 + ';' + progress_rate2 END progress
                       from mes_center.c02_delay_process
                    )");
                int sult2 = ds2.InsertSql(srt2, out re2);
                if (sult2 > 0)
                {
                    int ret2 = ds2.DeleteSql(string.Format("UPDATE nfinebase.Sys_PMHomeDelayMold SET IsEffective=0 where id<{0}",re2));

                    LogHelper.Info(string.Format("生管主页-延误模具明细-Insert执行成功:{0}条,Update执行成功:{1}条，时间：{2}", sult2, ret2, DateTime.Now.ToString()));
                }
                else
                {
                    LogHelper.Error("生管主页-延误模具明细-执行失败");
                }
                #endregion

                #region  产能/负荷
                int re3 = 0;
                DbService ds3 = new DbService(EnStr, "MySQL");
                string srt3 = string.Format(@"INSERT INTO nfinebase.Sys_PMHomeCapacityLoad(DeviceType,DeviceName,Number,AcctDate,CreationTime)
                    (
                            SELECT dept_name, '产能' DeviceName, capacity_hours Number, acct_date, now()  from mes_center.c03_depart_capacity_plan where acct_date >= DATE_FORMAT(DATE_SUB(NOW(), INTERVAL 7 DAY), '%Y-%m-%d') and acct_date <= CURDATE()
                            UNION ALL
                            SELECT dept_name, '负荷' DeviceName, plan_hours Number, acct_date, now()  from mes_center.c03_depart_capacity_plan where acct_date >= DATE_FORMAT(DATE_SUB(NOW(), INTERVAL 7 DAY), '%Y-%m-%d') and acct_date <= CURDATE()
                    )");
                int sult3 = ds3.InsertSql(srt3, out re3);
                if (sult3 > 0)
                {
                    int ret3 = ds3.DeleteSql(string.Format("UPDATE nfinebase.Sys_PMHomeCapacityLoad SET IsEffective=0 where id<{0}",re3));

                    LogHelper.Info(string.Format("生管主页-产能/负荷-Insert执行成功:{0}条,Update执行成功:{1}条，时间：{2}", sult3, ret3, DateTime.Now.ToString()));
                }
                else
                {
                    LogHelper.Error("生管主页-产能/负荷-执行失败");
                }
                #endregion

                #region  外协按期交付率
                int re4 = 0;
                DbService ds4 = new DbService(EnStr, "MySQL");
                string srt4 = string.Format(@"INSERT INTO nfinebase.Sys_PMHomeOutsourcingRate(Type,Cost,GroupType,CreationTime)
                    (
		                    SELECT '按期' Type,COUNT(CASE WHEN delay_days=0 THEN 1 ELSE 0 END) Cost,'WX',now()  from mes_center.c05_wx_plan_bill  where acct_date >= DATE_FORMAT(DATE_SUB(NOW(), INTERVAL 7 DAY), '%Y-%m-%d') and acct_date <= CURDATE()
		                    UNION ALL
		                    SELECT '延期' Type,COUNT(CASE WHEN delay_days>0 THEN 1 ELSE 0 END) Cost,'WX',now()  from mes_center.c05_wx_plan_bill  where acct_date >= DATE_FORMAT(DATE_SUB(NOW(), INTERVAL 7 DAY), '%Y-%m-%d') and acct_date <= CURDATE()
                    )");
                int sult4 = ds4.InsertSql(srt4, out re4);
                if (sult4 > 0)
                {
                    int ret4 = ds4.DeleteSql(string.Format("UPDATE nfinebase.Sys_PMHomeOutsourcingRate SET IsEffective=0 where id<{0}  And GroupType='WX'", re4));

                    LogHelper.Info(string.Format("生管主页-外协按期交付率-Insert执行成功:{0}条,Update执行成功:{1}条，时间：{2}", sult4, ret4, DateTime.Now.ToString()));
                }
                else
                {
                    LogHelper.Error("生管主页-外协按期交付率-执行失败");
                }
                #endregion

                #region  外协单据明细
                int re5 = 0;
                DbService ds5 = new DbService(EnStr, "MySQL");
                string srt5 = string.Format(@"INSERT INTO nfinebase.Sys_PMHomeOutsourcingDetail(OutsourcingNo,ModuleNumber,WorkpieceNo,WorkingProcedure,Supplier,PlannedDeliveryDate,DaysOfExtension,DaysOfExtensionColor,GroupType,CreationTime)
                    (
                            SELECT wx_bill_no, mold_no, part_sub_no, process_name, provider, plan_date, delay_days,CASE WHEN delay_days>{0} THEN '{1}' ELSE '' End  Color, 'WX', now()  from mes_center.c05_wx_plan_bill
                            where acct_date >= DATE_FORMAT(DATE_SUB(NOW(), INTERVAL 7 DAY), '%Y-%m-%d') and acct_date <= CURDATE()
                    )", wxdelaydays, wxdelaydayscolour);
                int sult5 = ds5.InsertSql(srt5, out re5);
                if (sult5 > 0)
                {
                    int ret5 = ds5.DeleteSql(string.Format("UPDATE nfinebase.Sys_PMHomeOutsourcingDetail SET IsEffective=0 where id<{0}  And GroupType='WX'",re5));

                    LogHelper.Info(string.Format("生管主页-外协单据明细-Insert执行成功:{0}条,Update执行成功:{1}条，时间：{2}", sult5, ret5, DateTime.Now.ToString()));
                }
                else
                {
                    LogHelper.Error("生管主页-外协单据明细-执行失败");
                }
                #endregion

                #region  物料按期交付率
                int re6 = 0;
                DbService ds6 = new DbService(EnStr, "MySQL");
                string srt6 = string.Format(@"INSERT INTO nfinebase.Sys_PMHomeOutsourcingRate(Type,Cost,GroupType,CreationTime)
                    (
                            SELECT '按期' Type, COUNT(CASE WHEN delay_days = 0 THEN 1 ELSE 0 END) Cost, 'WL', now()  from mes_center.c07_stor_plan_bill  where acct_date >= DATE_FORMAT(DATE_SUB(NOW(), INTERVAL 7 DAY), '%Y-%m-%d') and acct_date <= CURDATE()
                            UNION ALL
                            SELECT '延期' Type, COUNT(CASE WHEN delay_days > 0 THEN 1 ELSE 0 END) Cost, 'WL', now()  from mes_center.c07_stor_plan_bill  where acct_date >= DATE_FORMAT(DATE_SUB(NOW(), INTERVAL 7 DAY), '%Y-%m-%d') and acct_date <= CURDATE()
                    )");
                int sult6 = ds6.InsertSql(srt6, out re6);
                if (sult6 > 0)
                {
                    int ret6 = ds6.DeleteSql(string.Format("UPDATE nfinebase.Sys_PMHomeOutsourcingRate SET IsEffective=0 where id<{0}  And GroupType='WL'",re6));

                    LogHelper.Info(string.Format("生管主页-物料按期交付率-Insert执行成功:{0}条,Update执行成功:{1}条，时间：{2}", sult6, ret6, DateTime.Now.ToString()));
                }
                else
                {
                    LogHelper.Error("生管主页-物料按期交付率-执行失败");
                }
                #endregion

                #region  物料单据明细
                int re7 = 0;
                DbService ds7 = new DbService(EnStr, "MySQL");
                string srt7 = string.Format(@"INSERT INTO nfinebase.Sys_PMHomeOutsourcingDetail(OutsourcingNo,ModuleNumber,WorkpieceNo,WorkingProcedure,Supplier,PlannedDeliveryDate,DaysOfExtension,DaysOfExtensionColor,GroupType,CreationTime)
                    (
                            SELECT wx_bill_no, mold_no, part_sub_no, process_name, provider, plan_date, delay_days, CASE WHEN delay_days >{0} THEN '{1}' ELSE '' End Color, 'WL', now()  from mes_center.c07_stor_plan_bill
                            where acct_date >= DATE_FORMAT(DATE_SUB(NOW(), INTERVAL 7 DAY), '%Y-%m-%d') and acct_date <= CURDATE()
                    )", wldelaydays, wldelaydayscolour);
                int sult7 = ds7.InsertSql(srt7, out re7);
                if (sult7 > 0)
                {
                    int ret7 = ds7.DeleteSql(string.Format("UPDATE nfinebase.Sys_PMHomeOutsourcingDetail SET IsEffective=0 where id<{0}  And GroupType='WL'",re7));

                    LogHelper.Info(string.Format("生管主页-物料单据明细-Insert执行成功:{0}条,Update执行成功:{1}条，时间：{2}", sult7, ret7, DateTime.Now.ToString()));
                }
                else
                {
                    LogHelper.Error("生管主页-物料单据明细-执行失败");
                }
                #endregion

                #region  稼动率趋势
                int re8 = 0;
                DbService ds8 = new DbService(EnStr, "MySQL");
                string srt8 = string.Format(@"INSERT INTO nfinebase.Sys_PMHomeJiadongRate(Month_Day,Device_Name,TrendRate,CreationTime)
                    (
                            SELECT acct_date, dept_name, activation, now()  from mes_center.c08_activation_curve
                               WHERE acct_date >= DATE_FORMAT(DATE_SUB(NOW(), INTERVAL 1 YEAR), '%Y-%m-%d') and acct_date <= CURDATE()
                    )");
                int sult8 = ds8.InsertSql(srt8, out re8);
                if (sult8 > 0)
                {
                    int ret8 = ds8.DeleteSql(string.Format("UPDATE nfinebase.Sys_PMHomeJiadongRate SET IsEffective=0 where id<{0}", re8));

                    LogHelper.Info(string.Format("生管主页-稼动率趋势-Insert执行成功:{0}条,Update执行成功:{1}条，时间：{2}", sult8, ret8, DateTime.Now.ToString()));
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
        // 根据Key取Value值
        public static string GetValue(string key)
        {
            return ConfigurationManager.AppSettings[key].ToString().Trim();
        }
    }
}
