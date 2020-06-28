using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NFine.Domain._03_Entity.ProductionManage
{
    public class PMHomeDelayMoldEntity : IEntity<PMHomeDelayMoldEntity>
    {
        public int id { get; set; }
        public string MoldNo { get; set; }
        public string Edition { get; set; }
        public string Type { get; set; }
        public DateTime PlannedDeliveryDate { get; set; }
        public int Progress { get; set; }
        public string ProgressColor { get; set; }	
        public int IsEffective { get; set; }
    }
}
