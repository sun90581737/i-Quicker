using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NFine.Domain._03_Entity.ProductionManage
{
    public class PMHomeCapacityLoadEntity : IEntity<PMHomeCapacityLoadEntity>
    {
        public int id { get; set; }
        public string DeviceType { get; set; }
        public string DeviceName { get; set; }
        public int Number { get; set; }
        public int PrType { get; set; }
        public string Colour { get; set; }
        public DateTime? AcctDate { get; set; }
        public DateTime CreationTime { get; set; }
        public int IsEffective { get; set; }
    }
}
