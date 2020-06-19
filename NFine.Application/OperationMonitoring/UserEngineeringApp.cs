using NFine.Code;
using NFine.Domain._03_Entity.OperationMonitoring;
using NFine.Domain._04_IRepository.OperationMonitoring;
using NFine.Repository.OperationMonitoring;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NFine.Application.OperationMonitoring
{
    public class UserEngineeringApp
    {
        private IUserEngineeringRepository service = new UserEngineeringRepository();

        public List<UserEngineeringEntity> GetList()
        {
            return service.IQueryable().ToList();
        }

        public List<UserEngineeringEntity> GetUserEngineeringList()
        {
            return service.GetUserEngineeringList(OperatorProvider.Provider.GetCurrent().UserCode);
        }
    }
}
