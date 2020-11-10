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
            dto.DeviceName = "CNC1发那科999";
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
            dto.DeviceName = "CNC2发那科888";
            dto.DeviceRunStatus = "宕机";
            dto.DeviceUrl = "";
            dto.DeviceLndicatorLight = "red";
            dtos.Add(dto);
            string server = "http://localhost:15988/api/AutomationLine/SaveDataAcquisition";
            DataAcquisitionAPIParameter param = new DataAcquisitionAPIParameter();
            param.operator_name = "WebApi";
            param.sign = DESEncrypt.Encrypt("WebApi");
            param.data = dtos;
            Dictionary<string, string> dic = new Dictionary<string, string>();
            dic.Add("operator_name", param.operator_name);
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
    }
}
