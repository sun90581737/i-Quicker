﻿using NFine.Domain._03_Entity.ProductionManage;
using NFine.Domain._04_IRepository.ProductionManage;
using NFine.Repository.ProductionManage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NFine.Application.ProductionManage
{
    public class PMHomeOutsourcingRateApp
    {
        private IPMHomeOutsourcingRateRepository service = new PMHomeOutsourcingRateRepository();
        public List<PMHomeOutsourcingRateEntity> GetList()
        {
            return service.IQueryable().ToList();
        }
    }
}
