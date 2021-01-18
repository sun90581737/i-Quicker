﻿using NFine.Domain._03_Entity.Electromechanical;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NFine.Mapping.Electromechanical
{
    public class AVICQualifiedAndCropRateMap : EntityTypeConfiguration<AVICQualifiedAndCropRateEntity>
    {
        public AVICQualifiedAndCropRateMap()
        {
            this.ToTable("Sys_AVICQualifiedAndCropRate");
            this.HasKey(t => t.id);
        }
    }
}