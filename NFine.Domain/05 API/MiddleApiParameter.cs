using NFine.Domain._03_Entity.AutomationLine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace NFine.Domain._05_API
{

    #region  数据采集A
    [DataContract]
    public class DataAcquisitionAPIParameter
    {
        [DataMember]
        public string operator_name { get; set; }
        [DataMember]
        public string operator_time { get; set; }
        [DataMember]
        public string ip { get; set; }
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
    #endregion

    #region
    [DataContract]
    public class EquipmentListAPIParameterA 
    {
        [DataMember]
        public string operator_name { get; set; }
        [DataMember]
        public string operator_time { get; set; }
        [DataMember]
        public string ip { get; set; }
        [DataMember]
        public string sign { get; set; }
        [DataMember]
        public string strdata { get; set; }

        [DataMember]
        public List<EquipmentListOneDTO> data { get; set; }
        
    }
    public class EquipmentListOneDTO
    {
        [DataMember]
        public string equipmentname { get; set; }
        [DataMember]
        public string team { get; set; }
        [DataMember]
        public string moldno { get; set; }
        [DataMember]
        public string workpiecesname { get; set; }
        [DataMember]
        public string colour { get; set; }
    }

    #endregion
}
