using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NFine.Domain.IRepository.TeamTask;
using NFine.Repository.TeamTask;
using NFine.Domain._03_Entity.TeamTask;
using NFine.Code;

namespace NFine.Application.TeamTask
{
    public class TeamTaskApp
    {
        private ITeamTaskRepository service = new TeamTaskRepository();

        public List<TeamTaskEntity> GetList()
        {
            return service.IQueryable().ToList();
        }

        public List<TeamTaskEntity> GetList(Pagination pagination, string queryJson)
        {
            var expression = ExtLinq.True<TeamTaskEntity>();
            var queryParam = queryJson.ToJObject();
            expression = expression.And(t => (t.Team == "EDM" || t.Team == "EDM班组") && t.IsEffective==1);
            return service.FindList(expression, pagination);
        }

        public List<TeamTaskEntity> GetListCNC(Pagination pagination, string queryJson)
        {
            var expression = ExtLinq.True<TeamTaskEntity>();
            var queryParam = queryJson.ToJObject();
            expression = expression.And(t => (t.Team == "CNC" || t.Team == "CNC班组") && t.IsEffective == 1);
            return service.FindList(expression, pagination);
        }

        public List<TeamTaskEntity> GetListWE(Pagination pagination, string queryJson)
        {
            var expression = ExtLinq.True<TeamTaskEntity>();
            var queryParam = queryJson.ToJObject();
            expression = expression.And(t => (t.Team == "WE" || t.Team == "WE班组") && t.IsEffective == 1);
            return service.FindList(expression, pagination);
        }
    }
}
