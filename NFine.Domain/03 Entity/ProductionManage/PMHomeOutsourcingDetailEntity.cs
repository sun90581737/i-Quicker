using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NFine.Domain._03_Entity.ProductionManage
{
    public class PMHomeOutsourcingDetailEntity : IEntity<PMHomeOutsourcingDetailEntity>
    {
        public int id { get; set; }
        public string OutsourcingNo { get; set; }
        public string ModuleNumber { get; set; }	
        public string WorkpieceNo { get; set; }	
        public string WorkingProcedure { get; set; }
        public string Supplier { get; set; }
        public DateTime PlannedDeliveryDate { get; set; }
        public int DaysOfExtension { get; set; }	
        public string DaysOfExtensionColor { get; set; }	
        public string GroupType { get; set; }	
        public DateTime CreationTime { get; set; }
        public int IsEffective { get; set; }
    }
}
