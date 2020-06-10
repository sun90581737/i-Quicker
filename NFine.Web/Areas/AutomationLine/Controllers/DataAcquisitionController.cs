using NFine.Application.AutomationLine;
using NFine.Code;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NFine.Web.Areas.AutomationLine.Controllers
{
    public class DataAcquisitionController : ControllerBase
    {
        private DataAcquisitionApp daApp = new DataAcquisitionApp();

        [HttpGet]
        [HandlerAjaxOnly]
        public ActionResult GetDataAcquisition()
        {
            var data = daApp.GetList().Where(p => p.IsEffective == 1);
            return Content(data.ToJson());
        }
    }
}
