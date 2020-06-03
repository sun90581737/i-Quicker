using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NFine.Domain._03_Entity.TeamTask
{
    public class CapacityLoadEntity: IEntity<CapacityLoadEntity>
    {
        public int? id { get; set; }
        public string Task_Type { get; set; }
        public string Device_Name { get; set; }
        public int? Device_Number { get; set; }
        public string Team { get; set; }
        public string Colour { get; set; }
        public DateTime? CreationTime { get; set; }
        public int? IsEffective { get; set; }
    }
}
