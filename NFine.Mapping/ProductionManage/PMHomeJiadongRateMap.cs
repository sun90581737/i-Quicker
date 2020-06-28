using NFine.Domain._03_Entity.ProductionManage;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NFine.Mapping.ProductionManage
{
    public class PMHomeJiadongRateMap : EntityTypeConfiguration<PMHomeJiadongRateEntity>
    {
        public PMHomeJiadongRateMap()
        {
            this.ToTable("Sys_PMHomeJiadongRate");
            this.HasKey(t => t.id);
        }
    }
}
