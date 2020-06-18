using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NFine.Domain._03_Entity.OperationMonitoring
{
    public class MoldMakingProgressEntity : IEntity<MoldMakingProgressEntity>
    {
        public int? id { get; set; }
        public string MoldNo { get; set; }
        public string MoldTest { get; set; }
        public string Type { get; set; }
        public string State { get; set; }
        public string ProductName { get; set; }
        public DateTime? PlannedDeliveryDate { get; set; }
        public int? EarlyWarning { get; set; }
        public string EarlyWarningColor { get; set; }
        public int? IsEffective { get; set; }
    }
}
