using NFine.Domain._03_Entity.TeamTask;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NFine.Mapping.TeamTask
{
    public class EquipmentListMap : EntityTypeConfiguration<EquipmentListEntity>
    {
        public EquipmentListMap()
        {
            this.ToTable("Sys_EquipmentList");
            this.HasKey(t => t.id);
        }
    }
}
