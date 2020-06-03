/*******************************************************************************
 * Copyright © 2016
 * 
 * Description: MVC快速开发平台
 *
*********************************************************************************/
using NFine.Domain.Entity.SystemManage;
using System.Data.Entity.ModelConfiguration;

namespace NFine.Mapping.SystemManage
{
    public class ItemsDetailMap : EntityTypeConfiguration<ItemsDetailEntity>
    {
        public ItemsDetailMap()
        {
            this.ToTable("Sys_ItemsDetail");
            this.HasKey(t => t.F_Id);
        }
    }
}
