﻿using NFine.Application.OperationMonitoring;
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
        private EHDelayMoldListApp EHdmlApp = new EHDelayMoldListApp();
        private EHNumberMoldsDeliveredApp EHnmdApp = new EHNumberMoldsDeliveredApp();
        private CustomerListApp clApp = new CustomerListApp();
        private CustomerListDetailApp cldApp = new CustomerListDetailApp();

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
        public ActionResult GetDataEHNumberMoldsDelivered()
        {
            var data = EHnmdApp.GetList().Where(p => p.IsEffective == 1);
            return Content(data.ToJson());
        }

        [HttpGet]
        [HandlerAjaxOnly]
        public ActionResult GetDataEHProductionSchedule()
        {
            var data = EHpsApp.GetList().Where(p => p.IsEffective == 1);
            return Content(data.ToJson());
        }

        [HttpGet]
        [HandlerAjaxOnly]
        public ActionResult GetGridJson(Pagination pagination, string queryJson)
        {
            var data = new
            {
                rows = EHdmlApp.GetList(pagination, queryJson),
                total = pagination.total,
                page = pagination.page,
                records = pagination.records
            };
            return Content(data.ToJson());
        }

        [HttpGet]
        [HandlerAjaxOnly]
        public ActionResult GetTreeJson()
        {
            var data = clApp.GetList();
            var treeList = new List<TreeViewModel>();
            foreach (CustomerListEntity item in data)
            {
                TreeViewModel tree = new TreeViewModel();
                bool hasChildren = data.Count(t => t.ParentId == item.Id) == 0 ? false : true;
                tree.id = item.Id.ToString();
                tree.text = item.FullName;
                tree.value = item.EnCode;
                tree.parentId = item.ParentId.ToString();
                tree.isexpand = true;
                tree.complete = true;
                tree.hasChildren = hasChildren;
                treeList.Add(tree);
            }
            return Content(treeList.TreeViewJson());
        }

        [HttpGet]
        [HandlerAjaxOnly]
        public ActionResult GetDetailGridJson(string itemId)
        {
            var data = cldApp.GetList(itemId);
            return Content(data.ToJson());
        }
    }
}
