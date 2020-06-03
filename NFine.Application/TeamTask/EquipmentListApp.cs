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
    public class EquipmentListApp
    {
        private IEquipmentListRepository service = new EquipmentListRepository();

        public List<EquipmentListEntity> GetList()
        {
            return service.IQueryable().ToList();
        }

        public List<EquipmentListEntity> GetList(Pagination pagination, string queryJson)
        {
            var expression = ExtLinq.True<EquipmentListEntity>();
            var queryParam = queryJson.ToJObject();
            expression = expression.And(t => t.Team == "EDM" && t.IsEffective==1);
            return service.FindList(expression, pagination);
        }

        public List<EquipmentListEntity> GetListCNC(Pagination pagination, string queryJson)
        {
            var expression = ExtLinq.True<EquipmentListEntity>();
            var queryParam = queryJson.ToJObject();
            expression = expression.And(t => t.Team == "CNC" && t.IsEffective == 1);
            return service.FindList(expression, pagination);
        }

        public List<EquipmentListEntity> GetListWE(Pagination pagination, string queryJson)
        {
            var expression = ExtLinq.True<EquipmentListEntity>();
            var queryParam = queryJson.ToJObject();
            expression = expression.And(t => t.Team == "WE" && t.IsEffective == 1);
            return service.FindList(expression, pagination);
        }
    }
}
