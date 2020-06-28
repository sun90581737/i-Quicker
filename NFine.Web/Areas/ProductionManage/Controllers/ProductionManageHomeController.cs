using NFine.Application.AutomationLine;
using NFine.Application.ProductionManage;
using NFine.Code;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NFine.Web.Areas.ProductionManage.Controllers
{
    public class ProductionManageHomeController : ControllerBase
    {
        private PMHomeMoldProgressApp PMhmpApp = new PMHomeMoldProgressApp();
        private PMHomeDelayMoldApp PMhdmApp = new PMHomeDelayMoldApp();
        private PMHomeCapacityLoadApp PMhclApp = new PMHomeCapacityLoadApp();

        [HttpGet]
        [HandlerAjaxOnly]
        public ActionResult GetDataPMHomeMoldProgress()
        {
            var data = PMhmpApp.GetList().Where(p => p.IsEffective == 1);
            return Content(data.ToJson());
        }

        [HttpGet]
        [HandlerAjaxOnly]
        public ActionResult GetGridJson(Pagination pagination, string queryJson)
        {
            var data = new
            {
                rows = PMhdmApp.GetList(pagination, queryJson),
                total = pagination.total,
                page = pagination.page,
                records = pagination.records
            };
            return Content(data.ToJson());
        }

        [HttpGet]
        [HandlerAjaxOnly]
        public ActionResult GetDataPMHomeCapacityLoad(string keyValue)
        {
            var data = PMhclApp.GetList().Where(p => p.IsEffective == 1 && p.PrType == Convert.ToInt32(keyValue));
            return Content(data.ToJson());
        }
    }
}
