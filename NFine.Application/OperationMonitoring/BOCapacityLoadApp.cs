using NFine.Domain._03_Entity.OperationMonitoring;
using NFine.Domain._04_IRepository.OperationMonitoring;
using NFine.Repository.OperationMonitoring;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NFine.Application.OperationMonitoring
{
    public class BOCapacityLoadApp
    {
        private IBOCapacityLoadRepository service = new BOCapacityLoadRepository();

        public List<BOCapacityLoadEntity> GetList()
        {
            return service.IQueryable().ToList();
        }
    }
}
