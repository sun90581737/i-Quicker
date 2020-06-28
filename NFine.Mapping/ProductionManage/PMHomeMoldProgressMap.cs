using NFine.Domain._03_Entity.ProductionManage;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NFine.Mapping.ProductionManage
{
    public class PMHomeMoldProgressMap : EntityTypeConfiguration<PMHomeMoldProgressEntity>
    {
        public PMHomeMoldProgressMap()
        {
            this.ToTable("Sys_PMHomeMoldProgress");
            this.HasKey(t => t.id);
        }
    }
}
