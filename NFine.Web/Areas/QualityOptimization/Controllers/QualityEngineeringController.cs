using NFine.Application.QualityOptimization;
using NFine.Code;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NFine.Web.Areas.QualityOptimization.Controllers
{
    public class QualityEngineeringController : ControllerBase
    {
        private QualityOTeamPassRateApp  QOtprApp=new QualityOTeamPassRateApp();
        private QualityOExceptionalResultsApp QOerApp = new QualityOExceptionalResultsApp();
        private QualityOExceptionalDetailApp QOed = new QualityOExceptionalDetailApp();
        private QualityOPassRateTrendApp QOprt = new QualityOPassRateTrendApp();
        private QualityOHandleExceptionalResultsApp QOherApp = new QualityOHandleExceptionalResultsApp();

        [HttpGet]
        [HandlerAjaxOnly]
        public ActionResult GetDataQualityOTeamPassRate()
        {
            var data = QOtprApp.GetList().Where(p => p.IsEffective == 1);
            return Content(data.ToJson());
        }
        [HttpGet]
        [HandlerAjaxOnly]
        public ActionResult GetDataQualityOExceptionalResults()
        {
            var data = QOerApp.GetList().Where(p => p.IsEffective == 1);
            return Content(data.ToJson());
        }
        [HttpGet]
        [HandlerAjaxOnly]
        public ActionResult GetGridJson(Pagination pagination, string queryJson)
        {
            var data = new
            {
                rows = QOed.GetList(pagination, queryJson).Where(p => p.IsEffective == 1),
                total = pagination.total,
                page = pagination.page,
                records = pagination.records
            };
            return Content(data.ToJson());
        }
        [HttpGet]
        [HandlerAjaxOnly]
        public ActionResult GetDataQualityOPassRateTrend()
        {
            var data = QOprt.GetList().Where(p => p.IsEffective == 1);
            return Content(data.ToJson());
        }
    }
}
