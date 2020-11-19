using Newtonsoft.Json;
using NFine.Code;
using NFine.Data;
using NFine.Domain._03_Entity.AutomationLine;
using NFine.Domain._05_API;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace NFine.WebAPI.Controllers
{
    public class AutomationLineController : ApiController
    {
        public AutomationLineController()
        {

        }
        [System.Web.Http.HttpPost]
        public DataAcquisitionResult SaveDataAcquisition([FromBody]DataAcquisitionAPIParameter param)
        {
            DataAcquisitionResult result = new DataAcquisitionResult();
            result.code = "1000";
            result.msg = "success";
            if (param == null)
            {
                param = new DataAcquisitionAPIParameter();
                this.Request.GetQueryNameValuePairs();

                HttpContextBase context = (HttpContextBase)Request.Properties["MS_HttpContext"];//获取传统context
                HttpRequestBase request = context.Request;//定义传统request对象
                param.operator_name = request.Form["operator_name"];
                param.operator_time = request.Form["operator_time"];
                param.sign = request.Form["sign"];
                param.strdata = request.Form["strdata"];

                LogHelper.Info("WebApi-SaveDataAcquisition param from forms");
            }
            //else LogHelper.Info(string.Format("WebApi-SaveDataAcquisition param from body{0}", Serialize(param)));
            if (!VerifyMiddleSign(param.operator_name, param.operator_time, param.sign))
            {
                LogHelper.Info(string.Format("operator_name{0},operation_time{1},sign{2}", param.operator_name, param.operator_time, param.sign));
                result.msg = "签名错误";
                result.code = "1040";
                return result;
            }
            List<DataAcquisitionEntity> dto = new List<DataAcquisitionEntity>();
            try
            {
                dto = Deserialize<List<DataAcquisitionEntity>>(param.strdata);
                foreach (var item in dto)
                {
                    bool fla = InsertDataAcquisition(item);
                    if (!fla)
                    {
                        LogHelper.Error(string.Format(Serialize(item), "新增失败-SaveDataAcquisition"));
                        //result.msg = "数据插入失败";
                        //result.code = "1050";
                        //return result;
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
            return result;
        }
        [System.Web.Http.HttpPost]
        public DataAcquisitionResult SaveDataAcquisitionDetail([FromBody]DataAcquisitionDetailAPIParameter param)
        {
            DataAcquisitionResult result = new DataAcquisitionResult();
            result.code = "1000";
            result.msg = "success";
            if (param == null)
            {
                param = new DataAcquisitionDetailAPIParameter();
                this.Request.GetQueryNameValuePairs();

                HttpContextBase context = (HttpContextBase)Request.Properties["MS_HttpContext"];//获取传统context
                HttpRequestBase request = context.Request;//定义传统request对象
                param.operator_name = request.Form["operator_name"];
                param.operator_time = request.Form["operator_time"];
                param.sign = request.Form["sign"];
                param.strdata = request.Form["strdata"];

                LogHelper.Info("WebApi-SaveDataAcquisitionDetail param from forms");
            }
            //else LogHelper.Info(string.Format("WebApi-SaveDataAcquisition param from body{0}", Serialize(param)));
            if (!VerifyMiddleSign(param.operator_name, param.operator_time, param.sign))
            {
                LogHelper.Info(string.Format("operator_name{0},operation_time{1},sign{2}", param.operator_name, param.operator_time, param.sign));
                result.msg = "签名错误";
                result.code = "1040";
                return result;
            }
            List<DataAcquisitionDetailDTO> dto = new List<DataAcquisitionDetailDTO>();
            try
            {
                dto = Deserialize<List<DataAcquisitionDetailDTO>>(param.strdata);
                foreach (var item in dto)
                {
                    bool fla = InsertDataAcquisitionDetail(item);
                    if (!fla)
                    {
                        LogHelper.Error(string.Format(Serialize(item), "新增失败-SaveDataAcquisitionDetail"));
                        //result.msg = "数据插入失败";
                        //result.code = "1050";
                        //return result;
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
            return result;
        }
        [System.Web.Http.HttpPost]
        public DataAcquisitionResult SaveDataAcquisitionJiadongRate([FromBody]DataAcquisitionJiadongRateAPIParameter param)
        {
            DataAcquisitionResult result = new DataAcquisitionResult();
            result.code = "1000";
            result.msg = "success";
            if (param == null)
            {
                param = new DataAcquisitionJiadongRateAPIParameter();
                this.Request.GetQueryNameValuePairs();

                HttpContextBase context = (HttpContextBase)Request.Properties["MS_HttpContext"];//获取传统context
                HttpRequestBase request = context.Request;//定义传统request对象
                param.operator_name = request.Form["operator_name"];
                param.operator_time = request.Form["operator_time"];
                param.sign = request.Form["sign"];
                param.strdata = request.Form["strdata"];

                LogHelper.Info("WebApi-SaveDataAcquisitionJiadongRate param from forms");
            }
            //else LogHelper.Info(string.Format("WebApi-SaveDataAcquisition param from body{0}", Serialize(param)));
            if (!VerifyMiddleSign(param.operator_name, param.operator_time, param.sign))
            {
                LogHelper.Info(string.Format("operator_name{0},operation_time{1},sign{2}", param.operator_name, param.operator_time, param.sign));
                result.msg = "签名错误";
                result.code = "1040";
                return result;
            }
            List<DataAcquisitionJiadongRateDTO> dto = new List<DataAcquisitionJiadongRateDTO>();
            try
            {
                dto = Deserialize<List<DataAcquisitionJiadongRateDTO>>(param.strdata);
                foreach (var item in dto)
                {
                    bool fla = UpdateDataAcquisitionJiadongRate(item);
                    if (!fla)
                    {
                        LogHelper.Error(string.Format(Serialize(item), "更新失败-SaveDataAcquisitionJiadongRate"));
                        //result.msg = "数据更新失败";
                        //result.code = "1050";
                        //return result;
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
            return result;
        }

        /// <summary>
        /// 自动化线-运行状态
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        [System.Web.Http.HttpPost]
        public DataAcquisitionResult SaveRunningState([FromBody]RunningStateAPIParameterA param)
        {
            DataAcquisitionResult result = new DataAcquisitionResult();
            result.code = "1000";
            result.msg = "success";
            if (param == null)
            {
                param = new RunningStateAPIParameterA();
                this.Request.GetQueryNameValuePairs();

                HttpContextBase context = (HttpContextBase)Request.Properties["MS_HttpContext"];//获取传统context
                HttpRequestBase request = context.Request;//定义传统request对象
                param.operator_name = request.Form["operator_name"];
                param.operator_time = request.Form["operator_time"];
                param.sign = request.Form["sign"];
                param.strdata = request.Form["strdata"];

                LogHelper.Info("WebApi-SaveRunningState param from forms");
            }
            //else LogHelper.Info(string.Format("WebApi-SaveDataAcquisition param from body{0}", Serialize(param)));
            if (!VerifyMiddleSign(param.operator_name, param.operator_time, param.sign))
            {
                LogHelper.Info(string.Format("operator_name{0},operation_time{1},sign{2}", param.operator_name, param.operator_time, param.sign));
                result.msg = "签名错误";
                result.code = "1040";
                return result;
            }
            RunningStateDTOA dto = new RunningStateDTOA();
            try
            {
                dto = Deserialize<RunningStateDTOA>(param.strdata);
                bool fla = InsertRunningState(dto);
                if (!fla)
                {
                    LogHelper.Error(string.Format(Serialize(dto), "新增失败-SaveRunningState"));
                    //result.msg = "数据插入失败";
                    //result.code = "1050";
                    //return result;
                }
            }
            catch (Exception ex)
            {
                LogHelper.Error(ex.Message);
                result.msg = ex.Message;
                result.code = "1060";
                return result;
            }
            return result;
        }
        [System.Web.Http.HttpPost]
        public DataAcquisitionResult SaveRunningStateStockBin([FromBody]RunningStateAPIParameterB param)
        {
            DataAcquisitionResult result = new DataAcquisitionResult();
            result.code = "1000";
            result.msg = "success";
            if (param == null)
            {
                param = new RunningStateAPIParameterB();
                this.Request.GetQueryNameValuePairs();

                HttpContextBase context = (HttpContextBase)Request.Properties["MS_HttpContext"];//获取传统context
                HttpRequestBase request = context.Request;//定义传统request对象
                param.operator_name = request.Form["operator_name"];
                param.operator_time = request.Form["operator_time"];
                param.sign = request.Form["sign"];
                param.strdata = request.Form["strdata"];

                LogHelper.Info("WebApi-SaveRunningStateStockBin param from forms");
            }
            //else LogHelper.Info(string.Format("WebApi-SaveDataAcquisition param from body{0}", Serialize(param)));
            if (!VerifyMiddleSign(param.operator_name, param.operator_time, param.sign))
            {
                LogHelper.Info(string.Format("operator_name{0},operation_time{1},sign{2}", param.operator_name, param.operator_time, param.sign));
                result.msg = "签名错误";
                result.code = "1040";
                return result;
            }
            RunningStateDTOB dto = new RunningStateDTOB();
            try
            {
                dto = Deserialize<RunningStateDTOB>(param.strdata);
                bool fla = UpdateRunningStateStockBin(dto);
                if (!fla)
                {
                    LogHelper.Error(string.Format(Serialize(dto), "新增失败-SaveRunningStateStockBin"));
                    //result.msg = "数据插入失败";
                    //result.code = "1050";
                    //return result;
                }
            }
            catch (Exception ex)
            {
                LogHelper.Error(ex.Message);
                result.msg = ex.Message;
                result.code = "1060";
                return result;
            }
            return result;
        }
        [System.Web.Http.NonAction]
        public bool InsertDataAcquisition(DataAcquisitionEntity dto)
        {
            bool fla = false;
            try
            {
                int re = 0; 
                DbService ds = new DbService(dbnfin, "MySQL");
                string str1 = string.Format(@"SELECT  *  from Sys_DataAcquisition WHERE DeviceName='{0}' AND IsEffective=1;", dto.DeviceName);
                bool sult1 = ds.IsExistRecord(str1);
                if (sult1)
                {
                    string srt = string.Format(@"UPDATE Sys_DataAcquisition SET DeviceRunStatus='{0}',DeviceUrl='{1}',DeviceLndicatorLight='{2}',TodayOutput={3},TodayJiadong={4},SpindleSpeed={5},FeedSpeed={6},SpindleRatio={7},FeedRatio={8},LoadRatio={9} WHERE DeviceName='{10}' AND IsEffective=1",
                        dto.DeviceRunStatus, dto.DeviceUrl, dto.DeviceLndicatorLight, dto.TodayOutput, dto.TodayJiadong, dto.SpindleSpeed, dto.FeedSpeed, dto.SpindleRatio, dto.FeedRatio, dto.LoadRatio, dto.DeviceName);
                    int sult = ds.InsertSql(srt, out re);
                    if (sult > 0)
                    {
                        fla = true;
                    }
                }
                else
                {
                    string srt = string.Format(@"INSERT INTO Sys_DataAcquisition(DeviceName,DeviceRunStatus,DeviceUrl,DeviceLndicatorLight,TodayOutput,TodayJiadong,SpindleSpeed,FeedSpeed,SpindleRatio,FeedRatio,LoadRatio,CreationTime)
                    VALUES  ( '{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}',NOW())", dto.DeviceName, dto.DeviceRunStatus, dto.DeviceUrl, dto.DeviceLndicatorLight, dto.TodayOutput, dto.TodayJiadong, dto.SpindleSpeed, dto.FeedSpeed, dto.SpindleRatio, dto.FeedRatio, dto.LoadRatio);
                    int sult = ds.InsertSql(srt, out re);
                    if (sult > 0)
                    {
                        fla = true;
                    }
                } 
            }
            catch (Exception ex)
            {
                LogHelper.Error(ex.Message);
            }
            return fla;
        }
        [System.Web.Http.NonAction]
        public bool InsertDataAcquisitionDetail(DataAcquisitionDetailDTO dto)
        {
            bool fla = false;
            try
            {
                int re = 0;
                DbService ds = new DbService(dbnfin, "MySQL");
                string srt = string.Format(@"INSERT INTO Sys_DataAcquisitionDetail(DeviceName,SpindleSpeed,FeedSpeed,RunTime,CreationTime)
                VALUES  ( '{0}',{1},{2},'{3}',NOW())", dto.devicename, dto.spindlespeed, dto.feedspeed, dto.runtime);
                int sult = ds.InsertSql(srt, out re);
                if (sult > 0)
                {
                    //ds.DeleteSql(string.Format("DELETE from Sys_DataAcquisitionDetail where CreationTime<{0}", DateTime.Now.AddHours(-1).ToShortDateString()));
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
        public bool UpdateDataAcquisitionJiadongRate(DataAcquisitionJiadongRateDTO dto)
        {
            bool fla = false;
            try
            {
                int re = 0;
                DbService ds = new DbService(dbnfin, "MySQL");
                string srt = string.Format(@"UPDATE  Sys_DataAcquisition set  TodayOutput={0},TodayJiadong={1} where DeviceName='{2}'", dto.todayoutput, dto.todayjiadong, dto.devicename);
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
        public bool InsertRunningState(RunningStateDTOA dto)
        {
            bool fla = false;
            try
            {
                int re = 0;
                DbService ds = new DbService(dbnfin, "MySQL");
                string str1 = string.Format(@"SELECT  *  from Sys_RunningState WHERE IsEffective=1;");
                bool sult1 = ds.IsExistRecord(str1);
                if (sult1)
                {
                    string srt = string.Format(@"UPDATE Sys_RunningState SET Describe1='{0}',DescribeColor1='{1}',Describe2='{2}',DescribeColor2='{3}',Describe3='{4}',DescribeColor3='{5}',Describe4='{6}',DescribeColor4='{7}',Describe5='{8}',DescribeColor5='{9}',Describe6='{10}',DescribeColor6='{11}' WHERE IsEffective=1",
                        dto.Describe1, dto.DescribeColor1, dto.Describe2, dto.DescribeColor2, dto.Describe3, dto.DescribeColor3, dto.Describe4, dto.DescribeColor4, dto.Describe5, dto.DescribeColor5, dto.Describe6, dto.DescribeColor6);
                    int sult = ds.InsertSql(srt, out re);
                    if (sult > 0)
                    {
                        fla = true;
                    }
                }
                else
                {
                    string srt = string.Format(@"INSERT INTO Sys_RunningState(Picture_Tip,Picture_Url,Describe1,DescribeColor1,Describe2,DescribeColor2,Describe3,DescribeColor3,Describe4,DescribeColor4,Describe5,DescribeColor5,Describe6,DescribeColor6,CreationTime)
                    VALUES  ( '测试显示','/Content/img/product/runningstate/01.png','{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}','{11}',NOW())", dto.Describe1, dto.DescribeColor1, dto.Describe2, dto.DescribeColor2, dto.Describe3, dto.DescribeColor3, dto.Describe4, dto.DescribeColor4, dto.Describe5, dto.DescribeColor5, dto.Describe6, dto.DescribeColor6);
                    int sult = ds.InsertSql(srt, out re);
                    if (sult > 0)
                    {
                        fla = true;
                    }
                }
            }
            catch (Exception ex)
            {
                LogHelper.Error(ex.Message);
            }
            return fla;
        }
        [System.Web.Http.NonAction]
        public bool UpdateRunningStateStockBin(RunningStateDTOB dto)
        {
            bool fla = false;
            try
            {
                int re = 0;
                DbService ds = new DbService(dbnfin, "MySQL");
                string srt = string.Format(@"UPDATE  Sys_RunningState set  Describe7='{0}',DescribeColor7='{1}',Describe8='{2}',DescribeColor8='{3}'", dto.Describe7, dto.DescribeColor7, dto.Describe8, dto.DescribeColor8);
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
        #region
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
            return (ConfigurationManager.AppSettings[key]+"").Trim();
        }
        public static T Deserialize<T>(string jsonValue)
        {
            return JsonConvert.DeserializeObject<T>(jsonValue);
        }
        public static bool VerifyMiddleSign(string customerId, string timeStamp, string dataSign)
        {
            try
            {
                bool rtn = false;

                var mySign = GenSign(customerId.ToString(),timeStamp);
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
        #endregion
    }
}