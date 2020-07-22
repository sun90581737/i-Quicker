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
        public ActionResult GetSelectJson()
        {
            var data = clApp.GetList().Where(p => p.ParentId == 0);
            var treeList = new List<TreeSelectModel>();
            foreach (CustomerListEntity item in data)
            {
                TreeSelectModel treeModel = new TreeSelectModel();
                treeModel.id = item.Id.ToString();
                treeModel.text = item.FullName;
                treeModel.parentId = item.ParentId.ToString();
                treeList.Add(treeModel);
            }
            return Content(treeList.TreeSelectJson());
        }
        [HttpGet]
        [HandlerAjaxOnly]
        public ActionResult GetSelectJsonTwo(string keyword)
        {
            var data = clApp.GetList().Where(p => p.ParentId.ToString() == keyword);
            var treeList = new List<TreeSelectModel>();
            foreach (CustomerListEntity item in data)
            {
                TreeSelectModel treeModel = new TreeSelectModel();
                bool hasChildren = data.Count(t => t.ParentId == item.Id) == 0 ? false : true;
                treeModel.id = item.Id.ToString();
                treeModel.text = item.FullName;
                treeModel.parentId = item.ParentId.ToString();
                treeList.Add(treeModel);
            }
            return Content(treeList.ToJson());
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
        public ActionResult GetGridJsonOn(Pagination pagination, string queryJson, string t)
        {
            var data = new
            {
                rows = cldApp.GetList(pagination, queryJson).Where(p => p.ListId.ToString() == t),
                total = pagination.total,
                page = pagination.page,
                records = pagination.records
            };
            return Content(data.ToJson());
        }
        [HttpGet]
        [HandlerAjaxOnly]
        public ActionResult GetTreeDetailJson(string value)
        {
            var temp = 0;
            List<CustomerListEntity> ListNew = new List<CustomerListEntity>();
            //父级
            List<CustomerListEntity> ListF = clApp.GetList().Where(p => p.ParentId == 0).ToList();
            //子级
            List<CustomerListEntity> ListZ = clApp.GetList().Where(p => p.FullName.IndexOf(value) >= 0).ToList();
            foreach (var item in ListF)
            {
                temp = 1;
                ListNew.Add(item);
                foreach (var item2 in ListZ)
                {
                    if (item2.ParentId == item.Id)
                    {
                        temp = 2;
                        ListNew.Add(item2);
                    }
                }
                if (temp == 1)
                {
                    ListNew.Remove(item);
                }
            }
            if (temp == 0)
            {
                ListNew = new List<CustomerListEntity>();
            }
            var treeList = new List<TreeViewModel>();
            foreach (CustomerListEntity item in ListNew)
            {
                TreeViewModel tree = new TreeViewModel();
                bool hasChildren = ListNew.Count(t => t.ParentId == item.Id) == 0 ? false : true;
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
            var data = cldApp.GetList().Where(p=>p.ListId.ToString()== itemId);
            return Content(data.ToJson());
        }
    }
}
