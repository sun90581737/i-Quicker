using NFine.Domain._03_Entity.AutomationLine;
using NFine.Domain._04_IRepository.AutomationLine;
using NFine.Repository.AutomationLine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NFine.Application.AutomationLine
{
    public class DataAcquisitionDetailApp
    {
        private IDataAcquisitionDetailRepository service = new DataAcquisitionDetailRepository();

        public List<DataAcquisitionDetailEntity> GetList()
        {
            return service.IQueryable().ToList();
        }

        public List<DataAcquisitionDetailEntity> GetDataAcquisitionDetail(string ConfTime)
        {
            return service.DataAcquisitionDetail(ConfTime);
        }
    }
}
