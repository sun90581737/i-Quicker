using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NFine.Domain._03_Entity.Bamt
{
    public class LineChartEntity : IEntity<LineChartEntity>
    {
        public int? id { get; set; }
        public string Name { get; set; }
        public string DeviceType { get; set; }
        public string DeviceName { get; set; }
        public double Number { get; set; }
        public DateTime? AcctDate { get; set; }
        public string Type { get; set; }
        public DateTime? CreationTime { get; set; }
        public int? IsEffective { get; set; }
    }
}
