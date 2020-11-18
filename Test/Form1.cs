using Newtonsoft.Json;
using NFine.Code;
using NFine.Domain._03_Entity.AutomationLine;
using NFine.Domain._05_API;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Test
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DataAcquisitionResult result = new DataAcquisitionResult();
            List<DataAcquisitionEntity> dtos = new List<DataAcquisitionEntity>();
            DataAcquisitionEntity dto = new DataAcquisitionEntity();
            dto.DeviceName = "CNC1发那科";
            dto.DeviceRunStatus = "运行中";
            dto.DeviceUrl = "";
            dto.DeviceLndicatorLight = "yellow";
            dto.TodayOutput = 10;
            dto.TodayJiadong = 10;
            dto.SpindleSpeed = 10;
            dto.FeedSpeed = 10;
            dto.SpindleRatio = 10;
            dto.FeedRatio = 10;
            dto.LoadRatio = 10;
            dtos.Add(dto);
            dto = new DataAcquisitionEntity();
            dto.DeviceName = "CNC2发那科";
            dto.DeviceRunStatus = "宕机";
            dto.DeviceUrl = "";
            dto.DeviceLndicatorLight = "red";
            dto.TodayOutput = 0;
            dto.TodayJiadong = 0;
            dto.SpindleSpeed = 0;
            dto.FeedSpeed = 0;
            dto.SpindleRatio = 0;
            dto.FeedRatio = 0;
            dto.LoadRatio = 0;
            dtos.Add(dto);
            string server = "http://localhost:15988/api/AutomationLine/SaveDataAcquisition";
            DataAcquisitionAPIParameter param = new DataAcquisitionAPIParameter();
            param.operator_name = "WebApi";
            param.operator_time = GenerateTimeStamp(DateTime.Now);
            param.sign = GenSign(param.operator_name, param.operator_time);
            param.data = dtos;
            Dictionary<string, string> dic = new Dictionary<string, string>();
            dic.Add("operator_name", param.operator_name);
            dic.Add("operator_time", param.operator_time);
            dic.Add("sign", param.sign);
            dic.Add("strdata", Serialize(param.data));

            try
            {
                HttpWebResponse response = CreatePostHttpResponse(server, dic, null, null, Encoding.UTF8, null);
                System.IO.StreamReader sr = new System.IO.StreamReader(response.GetResponseStream());
                string responseContent = sr.ReadToEnd();
                sr.Close();

                DataAcquisitionResult rtn = Deserialize<DataAcquisitionResult>(responseContent);
                if (rtn.code != "1000")
                {
                    return;
                }
            }
            catch (Exception ex)
            {
                return;
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            DataAcquisitionResult result = new DataAcquisitionResult();
            List<DataAcquisitionDetailDTO> dtos = new List<DataAcquisitionDetailDTO>();
            DataAcquisitionDetailDTO dto = new DataAcquisitionDetailDTO();
            dto.devicename = "CNC1发那科";
            dto.spindlespeed = 1100;
            dto.feedspeed = 8000;
            dto.runtime = DateTime.Now.ToString();
            dtos.Add(dto);
            dto = new DataAcquisitionDetailDTO();
            dto.devicename = "CNC2发那科";
            dto.spindlespeed = 1100;
            dto.feedspeed = 8000;
            dto.runtime = DateTime.Now.ToString();
            dtos.Add(dto);
            string server = "http://localhost:15988/api/AutomationLine/SaveDataAcquisitionDetail";
            DataAcquisitionDetailAPIParameter param = new DataAcquisitionDetailAPIParameter();
            param.operator_name = "WebApi";
            param.operator_time = GenerateTimeStamp(DateTime.Now);
            param.sign = GenSign(param.operator_name, param.operator_time);
            param.data = dtos;
            Dictionary<string, string> dic = new Dictionary<string, string>();
            dic.Add("operator_name", param.operator_name);
            dic.Add("operator_time", param.operator_time);
            dic.Add("sign", param.sign);
            dic.Add("strdata", Serialize(param.data));

            try
            {
                HttpWebResponse response = CreatePostHttpResponse(server, dic, null, null, Encoding.UTF8, null);
                System.IO.StreamReader sr = new System.IO.StreamReader(response.GetResponseStream());
                string responseContent = sr.ReadToEnd();
                sr.Close();

                DataAcquisitionResult rtn = Deserialize<DataAcquisitionResult>(responseContent);
                if (rtn.code != "1000")
                {
                    return;
                }
            }
            catch (Exception ex)
            {
                return;
            }
        }
        private void button7_Click(object sender, EventArgs e)
        {
            DataAcquisitionResult result = new DataAcquisitionResult();
            List<DataAcquisitionJiadongRateDTO> dtos = new List<DataAcquisitionJiadongRateDTO>();
            DataAcquisitionJiadongRateDTO dto = new DataAcquisitionJiadongRateDTO();
            dto.devicename = "CNC1发那科";
            dto.todayoutput = 21;
            dto.todayjiadong = 0.68;
            dtos.Add(dto);
            dto = new DataAcquisitionJiadongRateDTO();
            dto.devicename = "CNC2发那科";
            dto.todayoutput = 3;
            dto.todayjiadong = 0.34;
            dtos.Add(dto);
            string server = "http://localhost:15988/api/AutomationLine/SaveDataAcquisitionJiadongRate";
            DataAcquisitionJiadongRateAPIParameter param = new DataAcquisitionJiadongRateAPIParameter();
            param.operator_name = "WebApi";
            param.operator_time = GenerateTimeStamp(DateTime.Now);
            param.sign = GenSign(param.operator_name, param.operator_time);
            param.data = dtos;
            Dictionary<string, string> dic = new Dictionary<string, string>();
            dic.Add("operator_name", param.operator_name);
            dic.Add("operator_time", param.operator_time);
            dic.Add("sign", param.sign);
            dic.Add("strdata", Serialize(param.data));

            try
            {
                HttpWebResponse response = CreatePostHttpResponse(server, dic, null, null, Encoding.UTF8, null);
                System.IO.StreamReader sr = new System.IO.StreamReader(response.GetResponseStream());
                string responseContent = sr.ReadToEnd();
                sr.Close();

                DataAcquisitionResult rtn = Deserialize<DataAcquisitionResult>(responseContent);
                if (rtn.code != "1000")
                {
                    return;
                }
            }
            catch (Exception ex)
            {
                return;
            }
        }
        #region
        public static string GenerateTimeStamp(DateTime dt)
        {
            // Default implementation of UNIX time of the current UTC time  
            TimeSpan ts = dt.ToUniversalTime() - new DateTime(1970, 1, 1, 0, 0, 0, 0);
            return Convert.ToInt64(ts.TotalSeconds).ToString();
        }
        public static string GenSign(string operatorName, string timeStamp)
        {
            string signStr = string.Format("{0}{1}", operatorName, timeStamp);
            return DESEncrypt.Encrypt(signStr);
        }
        /// <summary>
        /// 组装普通文本请求参数。
        /// </summary>
        /// <param name="parameters">Key-Value形式请求参数字典</param>
        /// <returns>URL编码后的请求数据</returns>
        protected static string PostData(IDictionary<string, string> parameters)
        {
            StringBuilder postData = new StringBuilder();
            bool hasParam = false;
            IEnumerator<KeyValuePair<string, string>> dem = parameters.GetEnumerator();
            while (dem.MoveNext())
            {
                string name = dem.Current.Key;
                string value = dem.Current.Value;
                // 忽略参数名或参数值为空的参数
                if (!string.IsNullOrEmpty(name) && !string.IsNullOrEmpty(value))
                {
                    if (hasParam)
                    {
                        postData.Append("&");
                    }
                    postData.Append(name);
                    postData.Append("=");
                    postData.Append(Uri.EscapeDataString(value));
                    hasParam = true;
                }
            }
            return postData.ToString();
        }
        public static string Serialize(object obj)
        {
            if (obj == null)
            {
                return string.Empty;
            }
            return JsonConvert.SerializeObject(obj);
        }
        public static T Deserialize<T>(string jsonValue)
        {
            return JsonConvert.DeserializeObject<T>(jsonValue);
        }

        private static readonly string DefaultUserAgent = "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.1; SV1; .NET CLR 2.0.50727; .NET CLR  3.0.04506.648; .NET CLR 3.5.21022; .NET CLR 3.0.4506.2152; .NET CLR 3.5.30729)";
        /// <summary>  
        /// 创建POST方式的HTTP请求  
        /// </summary>  
        /// <param name="url">请求的URL</param>  
        /// <param name="parameters">随同请求POST的参数名称及参数值字典</param>  
        /// <param name="timeout">请求的超时时间</param>  
        /// <param name="userAgent">请求的客户端浏览器信息，可以为空</param>  
        /// <param name="requestEncoding">发送HTTP请求时所用的编码</param>  
        /// <param name="cookies">随同HTTP请求发送的Cookie信息，如果不需要身份验证可以为空</param>  
        /// <returns></returns>  
        public static HttpWebResponse CreatePostHttpResponse(string url, IDictionary<string, string> parameters, int? timeout, string userAgent, Encoding requestEncoding, CookieCollection cookies)
        {
            if (string.IsNullOrEmpty(url))
            {
                throw new ArgumentNullException("url");
            }
            if (requestEncoding == null)
            {
                throw new ArgumentNullException("requestEncoding");
            }
            HttpWebRequest request = null;
            //如果是发送HTTPS请求  
            if (url.StartsWith("https", StringComparison.OrdinalIgnoreCase))
            {
                ServicePointManager.ServerCertificateValidationCallback = new RemoteCertificateValidationCallback(CheckValidationResult);
                request = WebRequest.Create(url) as HttpWebRequest;
                request.ProtocolVersion = HttpVersion.Version10;
            }
            else
            {
                request = WebRequest.Create(url) as HttpWebRequest;
            }
            request.Method = "POST";
            request.ContentType = "application/x-www-form-urlencoded";

            if (!string.IsNullOrEmpty(userAgent))
            {
                request.UserAgent = userAgent;
            }
            else
            {
                request.UserAgent = DefaultUserAgent;
            }
            if (timeout.HasValue)
            {
                request.Timeout = timeout.Value;
            }
            if (cookies != null)
            {
                request.CookieContainer = new CookieContainer();
                request.CookieContainer.Add(cookies);
            }
            //如果需要POST数据  
            if (!(parameters == null || parameters.Count == 0))
            {
                StringBuilder buffer = new StringBuilder();
                int i = 0;
                foreach (string key in parameters.Keys)
                {
                    if (i > 0)
                    {
                        buffer.AppendFormat("&{0}={1}", key, parameters[key]);
                    }
                    else
                    {
                        buffer.AppendFormat("{0}={1}", key, parameters[key]);
                    }
                    i++;
                }
                byte[] data = requestEncoding.GetBytes(buffer.ToString());
                using (Stream stream = request.GetRequestStream())
                {
                    stream.Write(data, 0, data.Length);
                }
            }
            return request.GetResponse() as HttpWebResponse;
        }
        private static bool CheckValidationResult(object sender, System.Security.Cryptography.X509Certificates.X509Certificate certificate, X509Chain chain, SslPolicyErrors errors)
        {
            return true; //总是接受  
        }
        #endregion
        private void button3_Click(object sender, EventArgs e)
        {
            DataAcquisitionResult result = new DataAcquisitionResult();
            List<EquipmentListOneDTO> dtos = new List<EquipmentListOneDTO>();
            EquipmentListOneDTO dto = new EquipmentListOneDTO();
            dto.equipmentname = "CNC01";
            dto.moldno = "JD1";
            dto.workpiecesname = "JDM-007";
            dto.colour = "red";
            dtos.Add(dto);
            dto = new EquipmentListOneDTO();
            dto.equipmentname = "CNC02";
            dto.moldno = "JD2";
            dto.workpiecesname = "JDM-008";
            dto.colour = "yellow";
            dtos.Add(dto);
            string server = "http://localhost:15988/api/TeamTask/SaveEquipmentMachining";
            EquipmentListAPIParameterA param = new EquipmentListAPIParameterA();
            param.operator_name = "WebApi";
            param.operator_time = GenerateTimeStamp(DateTime.Now);
            param.sign = GenSign(param.operator_name, param.operator_time);
            param.data = dtos;
            Dictionary<string, string> dic = new Dictionary<string, string>();
            dic.Add("operator_name", param.operator_name);
            dic.Add("operator_time", param.operator_time);
            dic.Add("sign", param.sign);
            dic.Add("strdata", Serialize(param.data));

            try
            {
                HttpWebResponse response = CreatePostHttpResponse(server, dic, null, null, Encoding.UTF8, null);
                System.IO.StreamReader sr = new System.IO.StreamReader(response.GetResponseStream());
                string responseContent = sr.ReadToEnd();
                sr.Close();

                DataAcquisitionResult rtn = Deserialize<DataAcquisitionResult>(responseContent);
                if (rtn.code != "1000")
                {
                    return;
                }
            }
            catch (Exception ex)
            {
                return;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            DataAcquisitionResult result = new DataAcquisitionResult();
            List<EquipmentListTwoDTO> dtos = new List<EquipmentListTwoDTO>();
            EquipmentListTwoDTO dto = new EquipmentListTwoDTO();
            dto.equipmentname = "CNC01";
            dto.yield = "8";
            dto.Jiadong = 0.56;
            dtos.Add(dto);
            dto = new EquipmentListTwoDTO();
            dto.equipmentname = "CNC02";
            dto.yield = "0";
            dto.Jiadong = 1;
            dtos.Add(dto);
            string server = "http://localhost:15988/api/TeamTask/SaveEquipmentJiadongRate";
            EquipmentListAPIParameterB param = new EquipmentListAPIParameterB();
            param.operator_name = "WebApi";
            param.operator_time = GenerateTimeStamp(DateTime.Now);
            param.sign = GenSign(param.operator_name, param.operator_time);
            param.data = dtos;
            Dictionary<string, string> dic = new Dictionary<string, string>();
            dic.Add("operator_name", param.operator_name);
            dic.Add("operator_time", param.operator_time);
            dic.Add("sign", param.sign);
            dic.Add("strdata", Serialize(param.data));

            try
            {
                HttpWebResponse response = CreatePostHttpResponse(server, dic, null, null, Encoding.UTF8, null);
                System.IO.StreamReader sr = new System.IO.StreamReader(response.GetResponseStream());
                string responseContent = sr.ReadToEnd();
                sr.Close();

                DataAcquisitionResult rtn = Deserialize<DataAcquisitionResult>(responseContent);
                if (rtn.code != "1000")
                {
                    return;
                }
            }
            catch (Exception ex)
            {
                return;
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            DataAcquisitionResult result = new DataAcquisitionResult();
            List<TaskListDTO> dtos = new List<TaskListDTO>();
            TaskListDTO dto = new TaskListDTO();
            dto.processid = 1008;
            dto.state = "yellow";
            dtos.Add(dto);
            dto = new TaskListDTO();
            dto.processid = 1010;
            dto.state = "red";
            dtos.Add(dto);
            string server = "http://localhost:15988/api/TeamTask/SaveTaskListColour";
            TaskListAPIParameter param = new TaskListAPIParameter();
            param.operator_name = "WebApi";
            param.operator_time = GenerateTimeStamp(DateTime.Now);
            param.sign = GenSign(param.operator_name, param.operator_time);
            param.data = dtos;
            Dictionary<string, string> dic = new Dictionary<string, string>();
            dic.Add("operator_name", param.operator_name);
            dic.Add("operator_time", param.operator_time);
            dic.Add("sign", param.sign);
            dic.Add("strdata", Serialize(param.data));

            try
            {
                HttpWebResponse response = CreatePostHttpResponse(server, dic, null, null, Encoding.UTF8, null);
                System.IO.StreamReader sr = new System.IO.StreamReader(response.GetResponseStream());
                string responseContent = sr.ReadToEnd();
                sr.Close();

                DataAcquisitionResult rtn = Deserialize<DataAcquisitionResult>(responseContent);
                if (rtn.code != "1000")
                {
                    return;
                }
            }
            catch (Exception ex)
            {
                return;
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            DataAcquisitionResult result = new DataAcquisitionResult();
            RunningStateDTOA dto = new RunningStateDTOA();
            dto.Describe1 = "CNC1发那科<br>运行中";
            dto.DescribeColor1 = "#23ab33";
            dto.Describe2 = "CNC2发那科<br>运行中";
            dto.DescribeColor2 = "#23ab33";
            dto.Describe3 = "CNC3发那科<br>待机";
            dto.DescribeColor3 = "yellow";
            dto.Describe4 = "CMM2海克斯康<br>离线";
            dto.DescribeColor4 = "#c8c8c8";
            dto.Describe5 = "Robot<br>未就绪";
            dto.DescribeColor5 = "#0fcdfd";
            dto.Describe6 = "清洗机<br>待机";
            dto.DescribeColor6 = "#0865e3";

            string server = "http://localhost:15988/api/AutomationLine/SaveRunningState";
            RunningStateAPIParameterA param = new RunningStateAPIParameterA();
            param.operator_name = "WebApi";
            param.operator_time = GenerateTimeStamp(DateTime.Now);
            param.sign = GenSign(param.operator_name, param.operator_time);
            param.data = dto;
            Dictionary<string, string> dic = new Dictionary<string, string>();
            dic.Add("operator_name", param.operator_name);
            dic.Add("operator_time", param.operator_time);
            dic.Add("sign", param.sign);
            dic.Add("strdata", Serialize(param.data));

            try
            {
                HttpWebResponse response = CreatePostHttpResponse(server, dic, null, null, Encoding.UTF8, null);
                System.IO.StreamReader sr = new System.IO.StreamReader(response.GetResponseStream());
                string responseContent = sr.ReadToEnd();
                sr.Close();

                DataAcquisitionResult rtn = Deserialize<DataAcquisitionResult>(responseContent);
                if (rtn.code != "1000")
                {
                    return;
                }
            }
            catch (Exception ex)
            {
                return;
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            DataAcquisitionResult result = new DataAcquisitionResult();
            RunningStateDTOB dto = new RunningStateDTOB();
            dto.Describe7 = "38;2;3;0;0;10";
            dto.DescribeColor7 = "#D24D57;#26A65B;#EB7347;#84AF9B;#FC9D99;#00CCFF";
            dto.Describe8 = "39;0;29;0;0;20";
            dto.DescribeColor8 = "#D24D57;#26A65B;#EB7347;#84AF9B;#FC9D99;#00CCFF";

            string server = "http://localhost:15988/api/AutomationLine/SaveRunningStateStockBin";
            RunningStateAPIParameterB param = new RunningStateAPIParameterB();
            param.operator_name = "WebApi";
            param.operator_time = GenerateTimeStamp(DateTime.Now);
            param.sign = GenSign(param.operator_name, param.operator_time);
            param.data = dto;
            Dictionary<string, string> dic = new Dictionary<string, string>();
            dic.Add("operator_name", param.operator_name);
            dic.Add("operator_time", param.operator_time);
            dic.Add("sign", param.sign);
            dic.Add("strdata", Serialize(param.data));

            try
            {
                HttpWebResponse response = CreatePostHttpResponse(server, dic, null, null, Encoding.UTF8, null);
                System.IO.StreamReader sr = new System.IO.StreamReader(response.GetResponseStream());
                string responseContent = sr.ReadToEnd();
                sr.Close();

                DataAcquisitionResult rtn = Deserialize<DataAcquisitionResult>(responseContent);
                if (rtn.code != "1000")
                {
                    return;
                }
            }
            catch (Exception ex)
            {
                return;
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            TaskListResult result = new TaskListResult();
            TaskListTest param = new TaskListTest();
            string server = "http://localhost:15988/api/TeamTask/TestLink";
           
            param.type = "test";
            param.val = "123654";
            Dictionary<string, string> dic = new Dictionary<string, string>();
            dic.Add("type", param.type);
            dic.Add("val", param.val);

            try
            {
                HttpWebResponse response = CreatePostHttpResponse(server, dic, null, null, Encoding.UTF8, null);
                System.IO.StreamReader sr = new System.IO.StreamReader(response.GetResponseStream());
                string responseContent = sr.ReadToEnd();
                sr.Close();

                TaskListResult rtn = Deserialize<TaskListResult>(responseContent);

                MessageBox.Show(rtn.val);
            }
            catch (Exception ex)
            {
                return;
            }
        }
    }
}
