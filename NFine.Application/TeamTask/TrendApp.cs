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
    public class TrendApp
    {
        private ITrendRepository service = new TrendRepository();

        public List<TrendEntity> GetList()
        {
            return service.IQueryable().ToList();
        }

        public List<TrendEntity> GetList(Pagination pagination, string queryJson)
        {
            var expression = ExtLinq.True<TrendEntity>();
            var queryParam = queryJson.ToJObject();
            expression = expression.And(t => t.Team == "EDM" && t.IsEffective == 1);
            return service.FindList(expression, pagination);
        }
    }
}
