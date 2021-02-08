using Newtonsoft.Json;
using NFine.Code;
using NFine.Data;
using NFine.Data.DBContext;
using NFine.Domain._03_Entity.Bamt;
using NFine.Domain._05_API;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace NFine.WebAPI.Controllers
{
    public class AppletsController : ApiController
    {
        public AppletsController() 
        { 
        
        }

        [HttpPost]
        public QualifiedNumberResult QualifiedNumber([FromBody] APIParameter param)
        {
            QualifiedNumberResult result = new QualifiedNumberResult();
            result.code = "1000";
            result.msg = "success";
            if (param == null)
            {
                param = new APIParameter();
                this.Request.GetQueryNameValuePairs();

                HttpContextBase context = (HttpContextBase)Request.Properties["MS_HttpContext"];//获取传统context
                HttpRequestBase request = context.Request;//定义传统request对象
                param.operator_name = request.Form["operator_name"];
                param.operator_time = request.Form["operator_time"];
                param.sign = request.Form["sign"];

                LogHelper.Info("WXWebApi-QualifiedNumber param from forms");
            }
            if (!VerifyMiddleSign(param.operator_name, param.operator_time, param.sign))
            {
                LogHelper.Info(string.Format("operator_name{0},operation_time{1},sign{2}", param.operator_name, param.operator_time, param.sign));
                result.msg = "签名错误";
                result.code = "1040";
                return result;
            }
            try
            {
                DbService ds = new DbService(dbnfin, "SqlServer");
                string str = string.Format(@"SELECT  *  from Bamt_QualifiedNumber WHERE IsEffective=1;");
                DataTable sult = ds.Query(str);
                List<QualifiedNumberEntity> Qentity = new ModelHandler<QualifiedNumberEntity>().FillModel(sult);
                string strJson = JsonConvert.SerializeObject(Qentity);
                result.data = strJson;
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

        [HttpPost]
        public QualifiedNumberResult MainDetails([FromBody] APIParameter param)
        {
            QualifiedNumberResult result = new QualifiedNumberResult();
            result.code = "1000";
            result.msg = "success";
            if (param == null)
            {
                param = new APIParameter();
                this.Request.GetQueryNameValuePairs();

                HttpContextBase context = (HttpContextBase)Request.Properties["MS_HttpContext"];//获取传统context
                HttpRequestBase request = context.Request;//定义传统request对象
                param.operator_name = request.Form["operator_name"];
                param.operator_time = request.Form["operator_time"];
                param.sign = request.Form["sign"];

                LogHelper.Info("WXWebApi-MainDetails param from forms");
            }
            if (!VerifyMiddleSign(param.operator_name, param.operator_time, param.sign))
            {
                LogHelper.Info(string.Format("operator_name{0},operation_time{1},sign{2}", param.operator_name, param.operator_time, param.sign));
                result.msg = "签名错误";
                result.code = "1040";
                return result;
            }
            try
            {
                DbService ds = new DbService(dbnfin, "SqlServer");
                string str = string.Format(@"SELECT  *  from Bamt_MainDetails WHERE IsEffective=1;");
                DataTable sult = ds.Query(str);
                List<MainDetailsEntity> Qentity = new ModelHandler<MainDetailsEntity>().FillModel(sult);
                string strJson = JsonConvert.SerializeObject(Qentity);
                result.data = strJson;
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

        [HttpPost]
        public QualifiedNumberResult LineChart([FromBody] APIParameterLC param)
        {
            QualifiedNumberResult result = new QualifiedNumberResult();
            result.code = "1000";
            result.msg = "success";
            if (param == null)
            {
                param = new APIParameterLC();
                this.Request.GetQueryNameValuePairs();

                HttpContextBase context = (HttpContextBase)Request.Properties["MS_HttpContext"];//获取传统context
                HttpRequestBase request = context.Request;//定义传统request对象
                param.operator_name = request.Form["operator_name"];
                param.operator_time = request.Form["operator_time"];
                param.sign = request.Form["sign"];

                LogHelper.Info("WXWebApi-LineChart param from forms");
            }
            if (!VerifyMiddleSign(param.operator_name, param.operator_time, param.sign))
            {
                LogHelper.Info(string.Format("operator_name{0},operation_time{1},sign{2}", param.operator_name, param.operator_time, param.sign));
                result.msg = "签名错误";
                result.code = "1040";
                return result;
            }
            try
            {
                DbService ds = new DbService(dbnfin, "SqlServer");
                string str="";
                if (string.IsNullOrEmpty(param.type))
                {
                    param.type = "1";//默认显示第一个的数据。
                }
                if (string.IsNullOrEmpty(param.startdate) && string.IsNullOrEmpty(param.enddate))
                {
                    str = string.Format(@"SELECT  *  from Bamt_LineChart WHERE IsEffective=1 and Name='{0}' and Type='{1}';", param.devicename, param.type);
                }
                else
                {
                    str = string.Format(@"SELECT  *  from Bamt_LineChart WHERE IsEffective=1 and Name='{0}' and Type='{1}' and AcctDate between '{2}' AND '{3}';", param.devicename, param.type, param.startdate, param.enddate);
                }
                DataTable sult = ds.Query(str);
                List<LineChartEntity> Qentity = new ModelHandler<LineChartEntity>().FillModel(sult);
                string strJson = JsonConvert.SerializeObject(Qentity);
                result.data = strJson;
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
        [HttpPost]
        public QualifiedNumberResult SonDetails([FromBody] APIParameterSD param)
        {
            QualifiedNumberResult result = new QualifiedNumberResult();
            result.code = "1000";
            result.msg = "success";
            if (param == null)
            {
                param = new APIParameterSD();
                this.Request.GetQueryNameValuePairs();

                HttpContextBase context = (HttpContextBase)Request.Properties["MS_HttpContext"];//获取传统context
                HttpRequestBase request = context.Request;//定义传统request对象
                param.operator_name = request.Form["operator_name"];
                param.operator_time = request.Form["operator_time"];
                param.sign = request.Form["sign"];

                LogHelper.Info("WXWebApi-SonDetails param from forms");
            }
            if (!VerifyMiddleSign(param.operator_name, param.operator_time, param.sign))
            {
                LogHelper.Info(string.Format("operator_name{0},operation_time{1},sign{2}", param.operator_name, param.operator_time, param.sign));
                result.msg = "签名错误";
                result.code = "1040";
                return result;
            }
            try
            {
                DbService ds = new DbService(dbnfin, "SqlServer");
                string str = string.Format(@"SELECT  *  from Bamt_SonDetails WHERE IsEffective=1 and DeviceName='{0}';", param.devicename);
                DataTable sult = ds.Query(str);
                List<SonDetailsEntity> Qentity = new ModelHandler<SonDetailsEntity>().FillModel(sult);
                string strJson = JsonConvert.SerializeObject(Qentity);
                result.data = strJson;
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

        #region
        public static string Serialize(object obj)
        {
            if (obj == null)
            {
                return string.Empty;
            }
            return JsonConvert.SerializeObject(obj);
        }

        public static string dbnfin = "Server=192.168.2.195;Initial Catalog=WaterCloudNetDb;User ID=sa;Password=123;MultipleActiveResultSets=true;";//GetValue("conn_nfinebase");
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
        #endregion

    }
}