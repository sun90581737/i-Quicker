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
    public class DataAcquisitionApp
    {
        private IDataAcquisitionRepository service = new DataAcquisitionRepository();

        public List<DataAcquisitionEntity> GetList()
        {
            return service.IQueryable().ToList();
        }

        public List<DataAcquisitionEntity> GetList(Pagination pagination, string queryJson)
        {
            var expression = ExtLinq.True<DataAcquisitionEntity>();
            var queryParam = queryJson.ToJObject();
            expression = expression.And(t => t.IsEffective == 1);
            return service.FindList(expression, pagination);
        }
    }
}
