﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NFine.Domain._03_Entity.Electromechanical
{
    public class AVICAlarmEntity : IEntity<AVICAlarmEntity>
    {
        public int? id { get; set; }
        public string Type { get; set; }
        public int? Cost { get; set; }
        public string Ident { get; set; }
        public DateTime? CreationTime { get; set; }
        public int? IsEffective { get; set; }
    }
}
