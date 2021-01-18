using NFine.Code;
using NFine.Domain._03_Entity.Electromechanical;
using NFine.Domain._04_IRepository.Electromechanical;
using NFine.Repository.Electromechanical;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NFine.Application.Electromechanical
{
    public class AVICDetailApp
    {
        private IAVICDetailRepository service = new AVICDetailRepository();

        public List<AVICDetailEntity> GetList()
        {
            return service.IQueryable().ToList();
        }

        public List<AVICDetailEntity> GetList(Pagination pagination, string queryJson,string keyValue)
        {
            var expression = ExtLinq.True<AVICDetailEntity>();
            var queryParam = queryJson.ToJObject();
            expression = expression.And(t => t.IsEffective == 1 && t.Ident == "GF" && t.DeviceName == keyValue);
            return service.FindList(expression, pagination);
        }
    }
}
