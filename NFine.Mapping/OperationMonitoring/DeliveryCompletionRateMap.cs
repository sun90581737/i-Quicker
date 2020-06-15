using NFine.Domain._03_Entity.OperationMonitoring;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NFine.Mapping.OperationMonitoring
{
    public class DeliveryCompletionRateMap : EntityTypeConfiguration<DeliveryCompletionRateEntity>
    {
        public DeliveryCompletionRateMap()
        {
            this.ToTable("Sys_DeliveryCompletionRate");
            this.HasKey(t => t.id);
        }
    }
}
