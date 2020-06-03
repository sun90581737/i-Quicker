using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NFine.Domain._03_Entity.TeamTask
{
    public class EquipmentListEntity : IEntity<EquipmentListEntity>
    {
        public int? id { get; set; }
        public string Equipment_Name { get; set; }
        public string Equipment_Url { get; set; }
        public string Workpieces_Url { get; set; }
        public string Yield { get; set; }
        public string Jiadong { get; set; }
        public string Team { get; set; }
        public string Colour { get; set; }
        public DateTime? CreationTime { get; set; }
        public int? IsEffective { get; set; }
    }
}
