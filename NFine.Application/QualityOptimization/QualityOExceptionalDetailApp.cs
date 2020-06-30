using NFine.Code;
using NFine.Domain._03_Entity.QualityOptimization;
using NFine.Domain._04_IRepository.QualityOptimization;
using NFine.Repository.QualityOptimization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NFine.Application.QualityOptimization
{
    public class QualityOExceptionalDetailApp
    {
        private IQualityOExceptionalDetailRepository service = new QualityOExceptionalDetailRepository();
        public List<QualityOExceptionalDetailEntity> GetList()
        {
            return service.IQueryable().ToList();
        }
        public List<QualityOExceptionalDetailEntity> GetList(Pagination pagination, string queryJson)
        {
            var expression = ExtLinq.True<QualityOExceptionalDetailEntity>();
            var queryParam = queryJson.ToJObject();
            expression = expression.And(t => t.IsEffective == 1);
            return service.FindList(expression, pagination);
        }
    }
}
