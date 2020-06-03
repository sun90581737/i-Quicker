using NFine.Domain._03_Entity.TeamTask;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NFine.Mapping.TeamTask
{
    public class TrendMap : EntityTypeConfiguration<TrendEntity>
    {
        public TrendMap()
        {
            this.ToTable("Sys_Trend");
            this.HasKey(t => t.id);
        }
    }
}
