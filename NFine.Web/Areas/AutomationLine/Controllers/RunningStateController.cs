using NFine.Application.AutomationLine;
using NFine.Code;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NFine.Web.Areas.AutomationLine.Controllers
{
    public class RunningStateController : ControllerBase
    {
        private RunningStateApp stateApp = new RunningStateApp();

        [HttpGet]
        [HandlerAjaxOnly]
        public ActionResult GetRunningState()
        {
            var data = stateApp.GetList().Where(p => p.IsEffective == 1);
            return Content(data.ToJson());
        }
    }
}
