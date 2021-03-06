﻿using NFine.Application.Electromechanical;
using NFine.Code;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NFine.Web.Areas.Electromechanical.Controllers
{
    public class AVICTableTwoController : ControllerBase
    {
        private AVICTableApp tApp = new AVICTableApp();

        private AVICJiaDongRateApp jdrApp = new AVICJiaDongRateApp();

        private AVICDetailApp dApp = new AVICDetailApp();

        private AVICQualifiedAndCropRateApp qacrApp = new AVICQualifiedAndCropRateApp();

        private AVICAlarmApp aApp = new AVICAlarmApp();

        private AVICDeviceOutputApp doApp = new AVICDeviceOutputApp();

        [HttpGet]
        [HandlerAjaxOnly]
        public ActionResult GetDataAVICTable()
        {
            var data = tApp.GetList().Where(p => p.IsEffective == 1 && p.Ident == "MY");
            return Content(data.ToJson());
        }
        [HttpGet]
        [HandlerAjaxOnly]
        public ActionResult GetDataAVICJiaDongRate(string keyValue)
        {
            var data = jdrApp.GetList().Where(p => p.IsEffective == 1 && p.Ident == "MY" && p.DeviceName == keyValue);
            return Content(data.ToJson());
        }
        [HttpGet]
        [HandlerAjaxOnly]
        public ActionResult GetGridJson(Pagination pagination, string queryJson, string t)
        {
            var data = new
            {
                rows = dApp.GetListMY(pagination, queryJson, t),
                total = pagination.total,
                page = pagination.page,
                records = pagination.records
            };
            return Content(data.ToJson());
        }

        [HttpGet]
        [HandlerAjaxOnly]
        public ActionResult GetDataAVICQualifiedAndCropRate(string keyValue)
        {
            var data = qacrApp.GetList().Where(p => p.IsEffective == 1 && p.Ident == "MY" && p.Type == keyValue);
            return Content(data.ToJson());
        }

        [HttpGet]
        [HandlerAjaxOnly]
        public ActionResult GetDataAVICAlarm()
        {
            var data = aApp.GetList().Where(p => p.IsEffective == 1 && p.Ident == "MY");
            return Content(data.ToJson());
        }

        [HttpGet]
        [HandlerAjaxOnly]
        public ActionResult GetDataAVICDeviceOutput(string keyValue)
        {
            var data = doApp.GetList().Where(p => p.IsEffective == 1 && p.Ident == "MY" && p.DeviceName == keyValue);
            return Content(data.ToJson());
        }
    }
}
