using NFine.Code;
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
    public class TotalCycleCostApp
    {
        private ITotalCycleCostRepository service = new TotalCycleCostRepository();
        public List<TotalCycleCostEntity> GetList()
        {
            return service.IQueryable().ToList();
        }

        public List<TotalCycleCostEntity> GetList(Pagination pagination, string queryJson)
        {
            var expression = ExtLinq.True<TotalCycleCostEntity>();
            var queryParam = queryJson.ToJObject();
            expression = expression.And(t => t.IsEffective == 1);
            return service.FindList(expression, pagination);
        }
        public TotalCycleCostEntity GetForm(string keyValue)
        {
            return service.FindEntity(keyValue);
        }
    }
}
