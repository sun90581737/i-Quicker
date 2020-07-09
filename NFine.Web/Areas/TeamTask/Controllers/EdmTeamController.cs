using NFine.Application.TeamTask;
using NFine.Code;
using NFine.Domain._03_Entity.TeamTask;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NFine.Web.Areas.TeamTask.Controllers
{
    public class EdmTeamController : ControllerBase
    {
        private TeamTaskApp teamApp = new TeamTaskApp();

        private EquipmentListApp elApp = new EquipmentListApp();

        private CapacityLoadApp clApp = new CapacityLoadApp();

        private TrendApp tApp = new TrendApp();

        [HttpGet]
        [HandlerAjaxOnly]
        public ActionResult GetGridJson(Pagination pagination, string queryJson)
        {
            var data = new
            {
                rows = teamApp.GetList(pagination, queryJson),
                total = pagination.total,
                page = pagination.page,
                records = pagination.records
            };
            return Content(data.ToJson());
        }
        [HttpGet]
        [HandlerAjaxOnly]
        public ActionResult OnGetGridJson(Pagination pagination, string queryJson)
        {
            var data = new
            {
                rows = elApp.GetList(pagination, queryJson),
                total = pagination.total,
                page = pagination.page,
                records = pagination.records
            };
            return Content(data.ToJson());
        }
        [HttpGet]
        [HandlerAjaxOnly]
        public ActionResult GetCapacityLoad()
        {
            var data = clApp.GetList().Where(t => (t.Team == "EDM" || t.Team == "EDM班组") && t.IsEffective == 1);
            return Content(data.ToJson());
        }
        [HttpGet]
        [HandlerAjaxOnly]
        public ActionResult GetTrend()
        {
            var data = tApp.GetList().Where(t => (t.Team == "EDM" || t.Team == "EDM班组") && t.IsEffective == 1);
            return Content(data.ToJson());
        }
    }
}
