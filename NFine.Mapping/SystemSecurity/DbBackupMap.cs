/*******************************************************************************
 * Copyright © 2016
 * 
 * Description: MVC快速开发平台
 *
*********************************************************************************/
using NFine.Domain.Entity.SystemSecurity;
using System.Data.Entity.ModelConfiguration;

namespace NFine.Mapping.SystemSecurity
{
    public class DbBackupMap : EntityTypeConfiguration<DbBackupEntity>
    {
        public DbBackupMap()
        {
            this.ToTable("Sys_DbBackup");
            this.HasKey(t => t.F_Id);
        }
    }
}
