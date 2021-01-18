using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NFine.Domain._03_Entity.Electromechanical
{
    public class AVICTableEntity : IEntity<AVICTableEntity>
    {
        public int? id { get; set; }
        public string DeviceName { get; set; }
        public string DeviceNameShow { get; set; }
        public string InProcess { get; set; }
        public string DeviceLndicatorLight { get; set; }
        public string DeviceUrl { get; set; }
        public string DeviceRunStatus { get; set; }
        public string DeviceRunTime { get; set; }
        public int? TodayOutput { get; set; }
        public string Ident { get; set; }
        public DateTime? CreationTime { get; set; }
        public int? IsEffective { get; set; }
    }
}
