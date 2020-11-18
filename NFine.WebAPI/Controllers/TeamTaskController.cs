using Newtonsoft.Json;
using NFine.Code;
using NFine.Data;
using NFine.Domain._05_API;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace NFine.WebAPI.Controllers
{
    public class TeamTaskController : ApiController
    {
        public TeamTaskController()
        {

        }
        [System.Web.Http.HttpPost]
        public DataAcquisitionResult SaveEquipmentMachining([FromBody]EquipmentListAPIParameterA param)
        {
            //记时
            LogHelper.Info("SaveEquipmentMachining--开始");
            Stopwatch timeWatcher = new Stopwatch();
            long checkTime = 0;
            timeWatcher.Restart(); //开始计时
            DataAcquisitionResult result = new DataAcquisitionResult();
            result.code = "1000";
            result.msg = "success";
            if (param == null)
            {
                param = new EquipmentListAPIParameterA();
                this.Request.GetQueryNameValuePairs();

                HttpContextBase context = (HttpContextBase)Request.Properties["MS_HttpContext"];//获取传统context
                HttpRequestBase request = context.Request;//定义传统request对象
                param.operator_name = request.Form["operator_name"];
                param.operator_time = request.Form["operator_time"];
                param.sign = request.Form["sign"];
                param.strdata = request.Form["strdata"];

                LogHelper.Info("WebApi-SaveEquipmentMachining param from forms");
            }
            if (!VerifyMiddleSign(param.operator_name, param.operator_time, param.sign))
            {
                LogHelper.Info(string.Format("operator_name{0},operation_time{1},sign{2}", param.operator_name, param.operator_time, param.sign));
                result.msg = "签名错误";
                result.code = "1040";
                return result;
            }
            List<EquipmentListOneDTO> dto = new List<EquipmentListOneDTO>();
            try
            {
                dto = Deserialize<List<EquipmentListOneDTO>>(param.strdata);
                foreach (var item in dto)
                {
                    bool fla = UpdateEquipmentListOne(item);
                    if (!fla)
                    {
                        LogHelper.Error(Serialize(item));
                        result.msg = "数据更新失败";
                        result.code = "1050";
                        return result;
                    }
                }
            }
            catch (Exception ex)
            {
                LogHelper.Error(ex.Message);
                result.msg = ex.Message;
                result.code = "1060";
                return result;
            }
            timeWatcher.Stop();//结束计时
            checkTime = timeWatcher.ElapsedMilliseconds;
            LogHelper.Info(string.Format("SaveEquipmentMachining--结束,执行时间：{0} ", checkTime));
            return result;
        }
        [System.Web.Http.HttpPost]
        public DataAcquisitionResult SaveEquipmentJiadongRate([FromBody]EquipmentListAPIParameterB param)
        {
            //记时
            LogHelper.Info("SaveEquipmentJiadongRate--开始");
            Stopwatch timeWatcher = new Stopwatch();
            long checkTime = 0;
            timeWatcher.Restart(); //开始计时
            DataAcquisitionResult result = new DataAcquisitionResult();
            result.code = "1000";
            result.msg = "success";
            if (param == null)
            {
                param = new EquipmentListAPIParameterB();
                this.Request.GetQueryNameValuePairs();

                HttpContextBase context = (HttpContextBase)Request.Properties["MS_HttpContext"];//获取传统context
                HttpRequestBase request = context.Request;//定义传统request对象
                param.operator_name = request.Form["operator_name"];
                param.operator_time = request.Form["operator_time"];
                param.sign = request.Form["sign"];
                param.strdata = request.Form["strdata"];

                LogHelper.Info("WebApi-SaveEquipmentJiadongRate param from forms");
            }
            if (!VerifyMiddleSign(param.operator_name, param.operator_time, param.sign))
            {
                LogHelper.Info(string.Format("operator_name{0},operation_time{1},sign{2}", param.operator_name, param.operator_time, param.sign));
                result.msg = "签名错误";
                result.code = "1040";
                return result;
            }
            List<EquipmentListTwoDTO> dto = new List<EquipmentListTwoDTO>();
            try
            {
                dto = Deserialize<List<EquipmentListTwoDTO>>(param.strdata);
                foreach (var item in dto)
                {
                    bool fla = UpdateEquipmentListTwo(item);
                    if (!fla)
                    {
                        LogHelper.Error(Serialize(item));
                        result.msg = "数据更新失败";
                        result.code = "1050";
                        return result;
                    }
                }
            }
            catch (Exception ex)
            {
                LogHelper.Error(ex.Message);
                result.msg = ex.Message;
                result.code = "1060";
                return result;
            }
            timeWatcher.Stop();//结束计时
            checkTime = timeWatcher.ElapsedMilliseconds;
            LogHelper.Info(string.Format("SaveEquipmentJiadongRate--结束,执行时间：{0} ", checkTime));
            return result;
        }
        [System.Web.Http.HttpPost]
        public DataAcquisitionResult SaveTaskListColour([FromBody]TaskListAPIParameter param)
        {
            //记时
            LogHelper.Info("SaveTaskListColour--开始");
            Stopwatch timeWatcher = new Stopwatch();
            long checkTime = 0;
            timeWatcher.Restart(); //开始计时
            DataAcquisitionResult result = new DataAcquisitionResult();
            result.code = "1000";
            result.msg = "success";
            if (param == null)
            {
                param = new TaskListAPIParameter();
                this.Request.GetQueryNameValuePairs();

                HttpContextBase context = (HttpContextBase)Request.Properties["MS_HttpContext"];//获取传统context
                HttpRequestBase request = context.Request;//定义传统request对象
                param.operator_name = request.Form["operator_name"];
                param.operator_time = request.Form["operator_time"];
                param.sign = request.Form["sign"];
                param.strdata = request.Form["strdata"];

                LogHelper.Info("WebApi-SaveTaskListColour param from forms");
            }
            if (!VerifyMiddleSign(param.operator_name, param.operator_time, param.sign))
            {
                LogHelper.Info(string.Format("operator_name{0},operation_time{1},sign{2}", param.operator_name, param.operator_time, param.sign));
                result.msg = "签名错误";
                result.code = "1040";
                return result;
            }
            List<TaskListDTO> dto = new List<TaskListDTO>();
            try
            {
                dto = Deserialize<List<TaskListDTO>>(param.strdata);
                foreach (var item in dto)
                {
                    bool fla = UpdateTaskListColour(item);
                    if (!fla)
                    {
                        LogHelper.Error(Serialize(item));
                        result.msg = "数据更新失败";
                        result.code = "1050";
                        return result;
                    }
                }
            }
            catch (Exception ex)
            {
                LogHelper.Error(ex.Message);
                result.msg = ex.Message;
                result.code = "1060";
                return result;
            }
            timeWatcher.Stop();//结束计时
            checkTime = timeWatcher.ElapsedMilliseconds;
            LogHelper.Info(string.Format("SaveTaskListColour--结束,执行时间：{0} ", checkTime));
            return result;
        }
        [System.Web.Http.NonAction]
        public bool UpdateEquipmentListOne(EquipmentListOneDTO dto)
        {
            bool fla = false;
            try
            {
                int re = 0;
                DbService ds = new DbService(dbnfin, "MySQL");
                string srt = string.Format(@"UPDATE  Sys_EquipmentList set  Mold_No='{0}',Workpieces_Name='{1}',Colour='{2}' where Equipment_Name='{3}'", dto.moldno,dto.workpiecesname, dto.colour, dto.equipmentname);
                int sult = ds.InsertSql(srt, out re);
                if (sult > 0)
                {
                    fla = true;
                }
            }
            catch (Exception ex)
            {
                LogHelper.Error(ex.Message);
            }
            return fla;
        }
        [System.Web.Http.NonAction]
        public bool UpdateEquipmentListTwo(EquipmentListTwoDTO dto)
        {
            bool fla = false;
            try
            {
                int re = 0;
                DbService ds = new DbService(dbnfin, "MySQL");
                string srt = string.Format(@"UPDATE  Sys_EquipmentList set  Yield='{0}',Jiadong={1} where Equipment_Name='{2}'", dto.yield, dto.Jiadong, dto.equipmentname);
                int sult = ds.InsertSql(srt, out re);
                if (sult > 0)
                {
                    fla = true;
                }
            }
            catch (Exception ex)
            {
                LogHelper.Error(ex.Message);
            }
            return fla;
        }
        [System.Web.Http.NonAction]
        public bool UpdateEquipmentListThree(EquipmentListThreeDTO dto)
        {
            bool fla = false;
            try
            {
                int re = 0;
                DbService ds = new DbService(dbnfin, "MySQL");
                string srt = string.Format(@"UPDATE  Sys_EquipmentList set Workpieces_Name='{0}',Colour='{1}', Yield='{2}',Jiadong={3} where Equipment_Name='{4}'", dto.workpiecesname, dto.state, dto.yield, dto.Jiadong, dto.equipmentname);
                int sult = ds.InsertSql(srt, out re);
                if (sult > 0)
                {
                    fla = true;
                }
            }
            catch (Exception ex)
            {
                LogHelper.Error(ex.Message);
            }
            return fla;
        }
        [System.Web.Http.NonAction]
        public bool UpdateTaskListColour(TaskListDTO dto)
        {
            bool fla = false;
            try
            {
                int re = 0;
                DbService ds = new DbService(dbnfin, "MySQL");
                string srt = string.Format(@"UPDATE  Sys_TaskList set  Colour='{0}' where process_id={1}", dto.state, dto.processid);
                int sult = ds.InsertSql(srt, out re);
                if (sult > 0)
                {
                    fla = true;
                }
            }
            catch (Exception ex)
            {
                LogHelper.Error(ex.Message);
            }
            return fla;
        }
        public static string Serialize(object obj)
        {
            if (obj == null)
            {
                return string.Empty;
            }
            return JsonConvert.SerializeObject(obj);
        }

        public static string dbnfin = GetValue("conn_nfinebase");//写入库
        // 根据Key取Value值
        public static string GetValue(string key)
        {
            return (ConfigurationManager.AppSettings[key] + "").Trim();
        }
        public static T Deserialize<T>(string jsonValue)
        {
            return JsonConvert.DeserializeObject<T>(jsonValue);
        }
        public static bool VerifyMiddleSign(string customerId, string timeStamp, string dataSign)
        {
            //Logger.Info("B2C.TMSService.WebApiBaseService.VerifyMiddleSign  " + string.Format("CustomerId{0} timeStamp {1} dataSign{2}", customerId, timeStamp, dataSign));

            try
            {
                bool rtn = false;

                var mySign = GenSign(customerId.ToString(), timeStamp);
                //TODO 如果timestamp差异超过5分钟验证失败
                var serverTimeStamp = GenerateTimeStamp(DateTime.Now);
                long lServer, lClient;
                if (!long.TryParse(timeStamp, out lClient))
                {
                    LogHelper.Error(string.Format("时间戳格式错误{0}", timeStamp));
                    return false;
                }
                if (!long.TryParse(serverTimeStamp, out lServer))
                {
                    LogHelper.Error(string.Format("时间戳格式错误{0}", serverTimeStamp));
                    return false;
                }
                if (Math.Abs(lServer - lClient) > 300)
                {
                    LogHelper.Error(string.Format("客户端与服务器的时间戳相差超过5分钟{0} {1}", timeStamp, serverTimeStamp));
                    return false;
                }

                rtn = string.Compare(mySign, dataSign, true) == 0;
                return rtn;
            }
            catch (Exception ex)
            {
                LogHelper.Info(ex.Message);
                return false;
            }
        }
        public static string GenSign(string operatorName, string timeStamp)
        {
            string signStr = string.Format("{0}{1}", operatorName, timeStamp);
            return DESEncrypt.Encrypt(signStr);
        }
        public static string GenerateTimeStamp(DateTime dt)
        {
            // Default implementation of UNIX time of the current UTC time  
            TimeSpan ts = dt.ToUniversalTime() - new DateTime(1970, 1, 1, 0, 0, 0, 0);
            return Convert.ToInt64(ts.TotalSeconds).ToString();
        }
        [System.Web.Http.HttpPost]
        public TaskListResult TestLink([FromBody]TaskListTest param)
        {
            //记时
            LogHelper.Info("TestLink--开始");
            Stopwatch timeWatcher = new Stopwatch();
            long checkTime = 0;
            timeWatcher.Restart(); //开始计时
            TaskListResult result = new TaskListResult();
            result.val = "success";
            if (param == null)
            {
                param = new TaskListTest();
                this.Request.GetQueryNameValuePairs();

                HttpContextBase context = (HttpContextBase)Request.Properties["MS_HttpContext"];//获取传统context
                HttpRequestBase request = context.Request;//定义传统request对象
                param.type = request.Form["type"];
                param.val = request.Form["val"];

                LogHelper.Info("WebApi-TestLink param from forms");
            }
            try
            {
                result.val = param.val;
            }
            catch (Exception ex)
            {
                LogHelper.Error(ex.Message);
                result.val = ex.Message;
                return result;
            }
            timeWatcher.Stop();//结束计时
            checkTime = timeWatcher.ElapsedMilliseconds;
            LogHelper.Info(string.Format("TestLink--结束,执行时间：{0} ", checkTime));

            return result;
        }

        [System.Web.Http.HttpPost]
        public DataAcquisitionResult SaveEquipmentList([FromBody]EquipmentListAPIParameterC param)
        {
            //记时
            LogHelper.Info("SaveEquipmentList--开始");
            Stopwatch timeWatcher = new Stopwatch();
            long checkTime = 0;
            timeWatcher.Restart(); //开始计时
            DataAcquisitionResult result = new DataAcquisitionResult();
            result.code = "1000";
            result.msg = "success";
            if (param == null)
            {
                param = new EquipmentListAPIParameterC();
                this.Request.GetQueryNameValuePairs();

                HttpContextBase context = (HttpContextBase)Request.Properties["MS_HttpContext"];//获取传统context
                HttpRequestBase request = context.Request;//定义传统request对象
                param.operator_name = request.Form["operator_name"];
                param.operator_time = request.Form["operator_time"];
                param.sign = request.Form["sign"];
                param.strdata = request.Form["strdata"];

                LogHelper.Info("WebApi-SaveEquipmentList param from forms");
            }
            if (!VerifyMiddleSign(param.operator_name, param.operator_time, param.sign))
            {
                LogHelper.Info(string.Format("operator_name{0},operation_time{1},sign{2}", param.operator_name, param.operator_time, param.sign));
                result.msg = "签名错误";
                result.code = "1040";
                return result;
            }
            List<EquipmentListThreeDTO> dto = new List<EquipmentListThreeDTO>();
            try
            {
                dto = Deserialize<List<EquipmentListThreeDTO>>(param.strdata);
                foreach (var item in dto)
                {
                    bool fla = UpdateEquipmentListThree(item);
                    if (!fla)
                    {
                        LogHelper.Error(Serialize(item));
                        result.msg = "数据更新失败";
                        result.code = "1050";
                        return result;
                    }
                }
            }
            catch (Exception ex)
            {
                LogHelper.Error(ex.Message);
                result.msg = ex.Message;
                result.code = "1060";
                return result;
            }
            timeWatcher.Stop();//结束计时
            checkTime = timeWatcher.ElapsedMilliseconds;
            LogHelper.Info(string.Format("SaveEquipmentList--结束,执行时间：{0} ", checkTime));
            return result;
        }
    }
}