using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NFine.Domain._03_Entity.Electromechanical
{
    public class AVICJiaDongRateEntity : IEntity<AVICJiaDongRateEntity>
    {
        public int? id { get; set; }
        public string Date { get; set; }
        public double JiaDongRate { get; set; }
        public string DeviceName { get; set; }
        public string Ident { get; set; }
        public DateTime? CreationTime { get; set; }
        public int? IsEffective { get; set; }
    }
}
