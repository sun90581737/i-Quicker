using NFine.Domain._03_Entity.AutomationLine;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NFine.Mapping.AutomationLine
{
    public class DataAcquisitionDetailMap : EntityTypeConfiguration<DataAcquisitionDetailEntity>
    {
        public DataAcquisitionDetailMap()
        {
            this.ToTable("Sys_DataAcquisitionDetail");
            this.HasKey(t => t.id);
        }
    }
}
