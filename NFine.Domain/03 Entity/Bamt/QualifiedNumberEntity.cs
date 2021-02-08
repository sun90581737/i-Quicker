using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NFine.Domain._03_Entity.Bamt
{
    public class QualifiedNumberEntity : IEntity<QualifiedNumberEntity>
    {
        public int? id { get; set; }
        public string Type { get; set; }
        public int? Number { get; set; }
        public DateTime? CreationTime { get; set; }
        public int? IsEffective { get; set; }
    }
}
