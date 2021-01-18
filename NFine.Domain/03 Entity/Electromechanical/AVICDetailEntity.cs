using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NFine.Domain._03_Entity.Electromechanical
{
    public class AVICDetailEntity : IEntity<AVICDetailEntity>
    {
        public int? id { get; set; }
        public string AlarmNumber { get; set; }
        public string AlarmContent { get; set; }
        public DateTime? AlarmTime { get; set; }
        public DateTime? ReleaseTime { get; set; }
        public string TimeConsuming { get; set; }
        public string DeviceName { get; set; }
        public string Ident { get; set; }
        public DateTime? CreationTime { get; set; }
        public int? IsEffective { get; set; }
    }
}
