using NFine.Application.SystemManage;
using NFine.Code;
using NFine.Domain.Entity.SystemManage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NFine.Web.Areas.SystemManage.Controllers
{
    public class RegionalController : ControllerBase
    {
        private AreaApp areaNew = new AreaApp();
        [HttpGet]
        [HandlerAjaxOnly]

        public ActionResult GetTreeSelectJson()
        {
            var data = areaNew.GetList().Where(p => p.F_Layers == 1);
            var treeList = new List<TreeSelectModel>();
            foreach (AreaEntity item in data)
            {
                TreeSelectModel treeModel = new TreeSelectModel();
                treeModel.id = item.F_Id;
                treeModel.text = item.F_FullName;
                treeModel.parentId = item.F_ParentId;
                treeList.Add(treeModel);
            }
            return Content(treeList.TreeSelectJson());
        }


        [HttpGet]
        [HandlerAjaxOnly]
        public ActionResult GetTreeSelectJsonCity(string keyword)
        {
            var data = areaNew.GetList().Where(p => p.F_ParentId== keyword);
            var treeList = new List<TreeSelectModel>();
            foreach (AreaEntity item in data)
            {
                TreeSelectModel treeModel = new TreeSelectModel();
                bool hasChildren = data.Count(t => t.F_ParentId == item.F_Id) == 0 ? false : true;
                treeModel.id = item.F_Id;
                treeModel.text = item.F_FullName;
                treeModel.parentId = item.F_ParentId;
                treeList.Add(treeModel);
            }
            return Content(treeList.ToJson());
        }
    }
}
