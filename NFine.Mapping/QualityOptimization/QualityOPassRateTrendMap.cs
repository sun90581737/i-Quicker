using NFine.Domain._03_Entity.QualityOptimization;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NFine.Mapping.QualityOptimization
{
    public class QualityOPassRateTrendMap : EntityTypeConfiguration<QualityOPassRateTrendEntity>
    {
        public QualityOPassRateTrendMap()
        {
            this.ToTable("Sys_QualityOPassRateTrend");
            this.HasKey(t => t.id);
        }
    }
}
