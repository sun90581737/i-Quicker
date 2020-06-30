using NFine.Domain._03_Entity.QualityOptimization;
using NFine.Domain._04_IRepository.QualityOptimization;
using NFine.Repository.QualityOptimization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NFine.Application.QualityOptimization
{
    public class QualityOPassRateTrendApp
    {
        private IQualityOPassRateTrendRepository service = new QualityOPassRateTrendRepository();
        public List<QualityOPassRateTrendEntity> GetList()
        {
            return service.IQueryable().ToList();
        }
    }
}
