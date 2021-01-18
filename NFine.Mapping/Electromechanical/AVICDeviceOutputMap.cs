using NFine.Domain._03_Entity.Electromechanical;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NFine.Mapping.Electromechanical
{
    public class AVICDeviceOutputMap : EntityTypeConfiguration<AVICDeviceOutputEntity>
    {
        public AVICDeviceOutputMap()
        {
            this.ToTable("Sys_AVICDeviceOutput");
            this.HasKey(t => t.id);
        }
    }
}
