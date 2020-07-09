using NFine.Code;
using NFine.Domain._03_Entity.TeamTask;
using NFine.Domain._04_IRepository.TeamTask;
using NFine.Repository.TeamTask;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NFine.Application.TeamTask
{
    public class CapacityLoadApp
    {
        private ICapacityLoadRepository service = new CapacityLoadRepository();

        public List<CapacityLoadEntity> GetList()
        {
            return service.IQueryable().ToList();
        }

        public List<CapacityLoadEntity> GetList(Pagination pagination, string queryJson)
        {
            var expression = ExtLinq.True<CapacityLoadEntity>();
            var queryParam = queryJson.ToJObject();
            expression = expression.And(t => (t.Team == "EDM" || t.Team == "EDM班组") && t.IsEffective == 1);
            return service.FindList(expression, pagination);
        }
    }
}
