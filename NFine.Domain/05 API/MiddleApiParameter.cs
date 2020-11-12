﻿using NFine.Domain._03_Entity.AutomationLine;
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

    #region 数据采集B
    [DataContract]
    public class DataAcquisitionDetailAPIParameter
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
        public List<DataAcquisitionDetailDTO> data { get; set; }
    }
    public class DataAcquisitionDetailDTO
    {
        [DataMember]
        public string devicename { get; set; }
        [DataMember]
        public int spindlespeed { get; set; }
        [DataMember]
        public int feedspeed { get; set; }
        [DataMember]
        public string runtime { get; set; }
    }

    #endregion

    #region  数据采集C
    [DataContract]
    public class DataAcquisitionJiadongRateAPIParameter
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
        public List<DataAcquisitionJiadongRateDTO> data { get; set; }
    }
    public class DataAcquisitionJiadongRateDTO
    {
        [DataMember]
        public string devicename { get; set; }
        [DataMember]
        public int todayoutput { get; set; }
        [DataMember]
        public double todayjiadong { get; set; }
    }
    #endregion

    #region 设备清单 更新灯 加工
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
    #region 设备清单 更新产量  稼动率
    [DataContract]
    public class EquipmentListAPIParameterB
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
        public List<EquipmentListTwoDTO> data { get; set; }
    }
    public class EquipmentListTwoDTO
    {
        [DataMember]
        public string equipmentname { get; set; }
        [DataMember]
        public string team { get; set; }
        [DataMember]
        public string yield { get; set; }
        [DataMember]
        public double Jiadong { get; set; }

    }
    #endregion
    #region 任务清单 更新灯
    [DataContract]
    public class TaskListAPIParameter
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
        public List<TaskListDTO> data { get; set; }
    }
    public class TaskListDTO
    {
        [DataMember]
        public int processid { get; set; }
        [DataMember]
        public string colour { get; set; }
    }
    #endregion

}
