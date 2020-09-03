using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NFine.Domain._03_Entity.AutomationLine
{
    public class DataAcquisitionDetailEntity : IEntity<DataAcquisitionDetailEntity>
    {
        public int? id { get; set; }
        public DateTime? RunTime { get; set; }
        public string DeviceName { get; set; }
        public int? SpindleSpeed { get; set; }
        public int? FeedSpeed { get; set; }
        public int? SpindleRatio { get; set; }
        public int? FeedRatio { get; set; }
        public int? LoadRatio { get; set; }
        public DateTime? CreationTime { get; set; }
        public int? IsEffective { get; set; }
    }
}
