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

        public string dbcenter = GetValue("conn_center");//查询库
        public string dbnfin = GetValue("conn_nfinebase");//写入库
        public string cnclimit = GetValue("cnc_device_task_top");//top多少条
        public string cnccolour1 = GetValue("cnc_device_task_colour1");//CNC颜色
        public string cnccolour2 = GetValue("cnc_device_task_colour2");
        public string cnccolour3 = GetValue("cnc_device_task_colour3");
        public string cnccolour4 = GetValue("cnc_device_task_colour4");
        private void Team_Load(object sender, EventArgs e)
        {
            try
            {
                var tip = DEncrypt.Decrypt(dbnfin);
                int mp = 0;
                DbService ser = new DbService(tip, "MySQL");
                string srt = string.Format(@"INSERT INTO nfinebase.sys_tasklist(Mold_No,Part_Number,Planned_Equipment,Start_Time,END_Time,Latest_Start_Time,Working_Hours,Customer,
                    Mold_Kernel_Material,Category,Team,Colour)(SELECT  mold_no,part_no,device,begin_time,end_time,last_begin_time,process_hour,customer_name,material,group_name,
                    dept_name,CASE WHEN process_state=-1 THEN '{0}' WHEN process_state=0 THEN '{1}' WHEN process_state=1 THEN '{2}' WHEN process_state=2 THEN '{3}' ELSE '' 
                    END process_state FROM mes_center.b01_device_task {4})", cnccolour1, cnccolour2, cnccolour3, cnccolour4, cnclimit);
                int result = ser.InsertSql(srt, out mp);
                if (result > 0)
                {
                    int ret = ser.DeleteSql(string.Format("UPDATE nfinebase.sys_tasklist SET IsEffective=0 where id<{0}", mp));

                    LogHelper.Info(string.Format("Insert执行成功:{0}条,Update执行成功:{1}条，时间：{2}", result, ret, DateTime.Now.ToString()));
                    this.Close();
                }
                else
                {
                    LogHelper.Error("执行失败");
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                LogHelper.Error(ex.Message);
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
