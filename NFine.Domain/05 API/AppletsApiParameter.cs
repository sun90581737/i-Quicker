using NFine.Domain._03_Entity.Bamt;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace NFine.Domain._05_API
{
    [DataContract]
    public class APIParameter
    {
        [DataMember]
        public string operator_name { get; set; }
        [DataMember]
        public string operator_time { get; set; }
        [DataMember]
        public string sign { get; set; }
    }
    [DataContract]
    public class APIParameterLC
    {
        [DataMember]
        public string operator_name { get; set; }
        [DataMember]
        public string operator_time { get; set; }
        [DataMember]
        public string sign { get; set; }
        [DataMember]
        public string devicename { get; set; }
        [DataMember]
        public string startdate { get; set; }
        [DataMember]
        public string enddate { get; set; }
        [DataMember]
        public string type { get; set; }
    }
    [DataContract]
    public class APIParameterSD
    {
        [DataMember]
        public string operator_name { get; set; }
        [DataMember]
        public string operator_time { get; set; }
        [DataMember]
        public string sign { get; set; }
        [DataMember]
        public string devicename { get; set; }
    }
    [DataContract]
    public class QualifiedNumberResult
    {
        [DataMember]
        public string code { get; set; }
        [DataMember]
        public string msg { get; set; }
        [DataMember]
        //public List<QualifiedNumberEntity> data { get; set; }
        public string data { get; set; }
    }
}
