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
                param.sign = request.Form["sign"];
                param.strdata = request.Form["strdata"];

                LogHelper.Info("WebApi-SaveDataAcquisition param from forms");
            }
            else LogHelper.Info(string.Format("WebApi-SaveDataAcquisition param from body{0}", Serialize(param)));
            string signStr = string.Format("{0}", param.operator_name);
            if (DESEncrypt.Encrypt(signStr) != param.sign)
            {
                LogHelper.Info(string.Format("operator_name{0},sign{1}", param.operator_name, param.sign));
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
                        LogHelper.Error(Serialize(item));
                        result.msg = "数据插入失败";
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

        public static string Serialize(object obj)
        {
            if (obj == null)
            {
                return string.Empty;
            }
            return JsonConvert.SerializeObject(obj);
        }

        public static string dbnfin = GetValue("conn_nfinebase");//写入库
        [System.Web.Http.NonAction]
        public bool InsertDataAcquisition(DataAcquisitionEntity dto)
        {
            bool fla = false;
            try
            {
                int re = 0;
                DbService ds = new DbService(dbnfin, "MySQL");
                string srt = string.Format(@"INSERT INTO Sys_DataAcquisition(DeviceName,DeviceRunStatus,DeviceUrl,DeviceLndicatorLight,TodayOutput,TodayJiadong,SpindleSpeed,FeedSpeed,SpindleRatio,FeedRatio,LoadRatio,CreationTime)
                VALUES  ( '{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}',NOW())", dto.DeviceName, dto.DeviceRunStatus, dto.DeviceUrl, dto.DeviceLndicatorLight, dto.TodayOutput, dto.TodayJiadong, dto.SpindleSpeed,dto.FeedSpeed,dto.SpindleRatio, dto.FeedRatio, dto.LoadRatio);
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

        // 根据Key取Value值
        public static string GetValue(string key)
        {
            return (ConfigurationManager.AppSettings[key]+"").Trim();
        }
        public static T Deserialize<T>(string jsonValue)
        {
            return JsonConvert.DeserializeObject<T>(jsonValue);
        }
    }
}