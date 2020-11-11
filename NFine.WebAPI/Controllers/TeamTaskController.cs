using Newtonsoft.Json;
using NFine.Code;
using NFine.Data;
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
    public class TeamTaskController : ApiController
    {
        public TeamTaskController()
        {

        }
        [System.Web.Http.HttpPost]
        public DataAcquisitionResult SaveEquipmentMachining([FromBody]EquipmentListAPIParameterA param)
        {
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
            return result;
        }
        //[System.Web.Http.HttpPost]
        //public DataAcquisitionResult SaveEquipmentJiadongRate([FromBody]EquipmentListAPIParameterB param)
        //{
        //    DataAcquisitionResult result = new DataAcquisitionResult();
        //    result.code = "1000";
        //    result.msg = "success";
        //    if (param == null)
        //    {
        //        param = new EquipmentListAPIParameterB();
        //        this.Request.GetQueryNameValuePairs();

        //        HttpContextBase context = (HttpContextBase)Request.Properties["MS_HttpContext"];//获取传统context
        //        HttpRequestBase request = context.Request;//定义传统request对象
        //        param.operator_name = request.Form["operator_name"];
        //        param.operator_time = request.Form["operator_time"];
        //        param.sign = request.Form["sign"];
        //        param.strdata = request.Form["strdata"];

        //        LogHelper.Info("WebApi-SaveEquipmentJiadongRate param from forms");
        //    }
        //    if (!VerifyMiddleSign(param.operator_name, param.operator_time, param.sign))
        //    {
        //        LogHelper.Info(string.Format("operator_name{0},operation_time{1},sign{2}", param.operator_name, param.operator_time, param.sign));
        //        result.msg = "签名错误";
        //        result.code = "1040";
        //        return result;
        //    }
        //    List<EquipmentListTwoDTO> dto = new List<EquipmentListTwoDTO>();
        //    try
        //    {
        //        dto = Deserialize<List<EquipmentListTwoDTO>>(param.strdata);
        //        foreach (var item in dto)
        //        {
        //            bool fla = UpdateEquipmentListTwo(item);
        //            if (!fla)
        //            {
        //                LogHelper.Error(Serialize(item));
        //                result.msg = "数据更新失败";
        //                result.code = "1050";
        //                return result;
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        LogHelper.Error(ex.Message);
        //        result.msg = ex.Message;
        //        result.code = "1060";
        //        return result;
        //    }
        //    return result;
        //}
        [System.Web.Http.NonAction]
        public bool UpdateEquipmentListOne(EquipmentListOneDTO dto)
        {
            bool fla = false;
            try
            {
                int re = 0;
                DbService ds = new DbService(dbnfin, "MySQL");
                string srt = string.Format(@"UPDATE  Sys_EquipmentList set  Mold_No='{0}',Workpieces_Name='{1}',Colour='{2}' where Equipment_Name='{3}' AND Team='{4}'", dto.moldno,dto.workpiecesname, dto.colour, dto.equipmentname, dto.team);
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
        //public bool UpdateEquipmentListTwo(EquipmentListTwoDTO dto)
        //{
        //    bool fla = false;
        //    try
        //    {
        //        int re = 0;
        //        DbService ds = new DbService(dbnfin, "MySQL");
        //        string srt = string.Format(@"UPDATE  Sys_EquipmentList set  Yield='{0}',Jiadong={1} where Equipment_Name='{2}' AND Team='{3}'", dto.yield, dto.Jiadong, dto.equipmentname, dto.team);
        //        int sult = ds.InsertSql(srt, out re);
        //        if (sult > 0)
        //        {
        //            fla = true;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        LogHelper.Error(ex.Message);
        //    }
        //    return fla;
        //}
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
    }
}