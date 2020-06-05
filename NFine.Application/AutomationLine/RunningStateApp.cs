using NFine.Code;
using NFine.Domain._03_Entity.AutomationLine;
using NFine.Domain._04_IRepository.AutomationLine;
using NFine.Repository.AutomationLine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NFine.Application.AutomationLine
{
    public class RunningStateApp
    {
        private IRunningStateRepository service = new RunningStateRepository();

        public List<RunningStateEntity> GetList()
        {
            return service.IQueryable().ToList();
        }

        public List<RunningStateEntity> GetList(Pagination pagination, string queryJson)
        {
            var expression = ExtLinq.True<RunningStateEntity>();
            var queryParam = queryJson.ToJObject();
            expression = expression.And(t => t.IsEffective == 1);
            return service.FindList(expression, pagination);
        }
    }
}
