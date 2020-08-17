using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NFine.Domain._03_Entity.OperationMonitoring
{
    public class TotalCycleCostEntity : IEntity<TotalCycleCostEntity>
    {
        public int? id { get; set; }
        public string Name { get; set; }
        public double Cost { get; set; }
        //public double TotalCost { get; set; }
        public int? PrType { get; set; }
        public DateTime? AcctDate { get; set; }
        public DateTime? CreationTime { get; set; }
        public int? IsEffective { get; set; }
    }
}
