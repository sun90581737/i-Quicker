using NFine.Application.OperationMonitoring;
using NFine.Code;
using NFine.Domain._03_Entity.OperationMonitoring;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NFine.Web.Areas.OperationMonitoring.Controllers
{
    public class EngineeringHomepageController : ControllerBase
    {
        private UserEngineeringApp ueApp = new UserEngineeringApp();
        private EHDeliveryCompletionRateApp EHdcrApp = new EHDeliveryCompletionRateApp();
        private EHProductionScheduleApp EHpsApp = new EHProductionScheduleApp();

        [HttpGet]
        [HandlerAjaxOnly]
        public ActionResult GetDataUserEngineeringList()
        {
            var data = ueApp.GetUserEngineeringList();
            return Content(data.ToJson());
        }

        [HttpGet]
        [HandlerAjaxOnly]
        public ActionResult GetDataEHDeliveryCompletionRate()
        {
            var data = EHdcrApp.GetList().Where(p => p.IsEffective == 1);
            return Content(data.ToJson());
        }

        [HttpGet]
        [HandlerAjaxOnly]
        public ActionResult GetDataEHProductionSchedule()
        {
            var data = EHpsApp.GetList().Where(p => p.IsEffective == 1);
            return Content(data.ToJson());
        }
    }
}
