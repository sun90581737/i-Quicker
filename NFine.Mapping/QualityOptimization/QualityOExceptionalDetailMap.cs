using NFine.Domain._03_Entity.QualityOptimization;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NFine.Mapping.QualityOptimization
{
    public class QualityOExceptionalDetailMap : EntityTypeConfiguration<QualityOExceptionalDetailEntity>
    {
        public QualityOExceptionalDetailMap()
        {
            this.ToTable("Sys_QualityOExceptionalDetail");
            this.HasKey(t => t.id);
        }
    }
}
