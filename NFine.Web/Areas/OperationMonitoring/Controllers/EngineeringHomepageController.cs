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

        [HttpGet]
        [HandlerAjaxOnly]
        public ActionResult GetDataUserEngineeringList()
        {
            var data = ueApp.GetUserEngineeringList();
            return Content(data.ToJson());
        }
    }
}
