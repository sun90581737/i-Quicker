using NFine.Domain._03_Entity.OperationMonitoring;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NFine.Mapping.OperationMonitoring
{
    public class KeyCustomersMap : EntityTypeConfiguration<KeyCustomersEntity>
    {
        public KeyCustomersMap()
        {
            this.ToTable("Sys_KeyCustomers");
            this.HasKey(t => t.id);
        }
    }
}
