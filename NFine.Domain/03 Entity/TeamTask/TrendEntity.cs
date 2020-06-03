using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NFine.Domain._03_Entity.TeamTask
{
    public class TrendEntity : IEntity<TrendEntity>
    {
        public int? id { get; set; }
        public string Device_Name { get; set; }
        public string Month_Day { get; set; }
        public double TrendRate { get; set; }
        public string Team { get; set; }
        public DateTime? CreationTime { get; set; }
        public int? IsEffective { get; set; }
    }
}
