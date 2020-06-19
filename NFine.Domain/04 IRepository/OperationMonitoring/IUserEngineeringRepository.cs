using NFine.Data;
using NFine.Domain._03_Entity.OperationMonitoring;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NFine.Domain._04_IRepository.OperationMonitoring
{
    public interface IUserEngineeringRepository : IRepositoryBase<UserEngineeringEntity>
    {
        List<UserEngineeringEntity> GetUserEngineeringList(string account);
    }
}
