using NFine.Domain._03_Entity.QualityOptimization;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NFine.Mapping.QualityOptimization
{
    public class QualityOHandleExceptionalResultsMap : EntityTypeConfiguration<QualityOHandleExceptionalResultsEntity>
    {
        public QualityOHandleExceptionalResultsMap()
        {
            this.ToTable("Sys_QualityOHandleExceptionalResults");
            this.HasKey(t => t.id);
        }
    }
}
