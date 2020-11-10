using NFine.Domain._03_Entity.AutomationLine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace NFine.Domain._05_API
{

    [DataContract]
    public class DataAcquisitionAPIParameter
    {
        [DataMember]
        public string operator_name { get; set; }
        /// <summary>
        /// 时间戳
        /// </summary>
        [DataMember]
        public string operator_time { get; set; }
        [DataMember]
        public string ip { get; set; }
        /// <summary>
        /// md5(operator_name, app_key, operator_time, app_secret)
        /// </summary>
        [DataMember]
        public string sign { get; set; }
        [DataMember]
        public string strdata { get; set; }
        [DataMember]
        public List<DataAcquisitionEntity> data { get; set; }
    }
    public class DataAcquisitionResult
    {
        [DataMember]
        public string code { get; set; }
        [DataMember]
        public string msg { get; set; }
    }
}
