using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NFine.Domain._03_Entity.ProductionManage
{
    public class PMHomeJiadongRateEntity : IEntity<PMHomeJiadongRateEntity>
    {
        public int id { get; set; }	
        public string Month_Day { get; set; }
        public string Device_Name { get; set; }
        public decimal TrendRate { get; set; }
        public DateTime CreationTime { get; set; }
        public int IsEffective { get; set; }
    }
}
