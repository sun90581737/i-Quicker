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
    public class CustomerListDetailApp
    {
        private ICustomerListDetailRepository service = new CustomerListDetailRepository();

        public List<CustomerListDetailEntity> GetList()
        {
            return service.IQueryable().ToList();
        }
        public List<CustomerListDetailEntity> GetList(Pagination pagination, string queryJson)
        {
            var expression = ExtLinq.True<CustomerListDetailEntity>();
            var queryParam = queryJson.ToJObject();
            expression = expression.And(t => t.IsEffective == 1);
            return service.FindList(expression, pagination);
        }

        public List<CustomerListDetailEntity> GetList(string itemId = "")
        {
            var expression = ExtLinq.True<CustomerListDetailEntity>();
            if (!string.IsNullOrEmpty(itemId))
            {
                expression = expression.And(t => t.ListId.ToString() == itemId);
            }
            return service.IQueryable(expression).OrderBy(t => t.Id).ToList();
        }
    }
}
