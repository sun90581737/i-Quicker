using NFine.Domain._03_Entity.Electromechanical;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NFine.Mapping.Electromechanical
{
    public class AVICAlarmMap : EntityTypeConfiguration<AVICAlarmEntity>
    {
        public AVICAlarmMap()
        {
            this.ToTable("Sys_AVICAlarm");
            this.HasKey(t => t.id);
        }
    }
}
