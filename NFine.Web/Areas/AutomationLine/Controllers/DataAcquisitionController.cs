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

        private DataAcquisitionDetailApp daDeApp = new DataAcquisitionDetailApp();

        [HttpGet]
        [HandlerAjaxOnly]
        public ActionResult GetDataAcquisition()
        {
            var data = daApp.GetList().Where(p => p.IsEffective == 1);
            return Content(data.ToJson());
        }
        [HttpGet]
        [HandlerAjaxOnly]
        public ActionResult GetDataAcquisitionDetail()
        {
            var ConfTime = Configs.GetValue("RefreshDataAcquisition");
            var data = daDeApp.GetDataAcquisitionDetail(ConfTime);
            return Content(data.ToJson());
        }
    }
}
