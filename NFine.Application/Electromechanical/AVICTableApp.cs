using NFine.Domain._03_Entity.Electromechanical;
using NFine.Domain._04_IRepository.Electromechanical;
using NFine.Repository.Electromechanical;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NFine.Application.Electromechanical
{
    public class AVICTableApp
    {
        private IAVICTableRepository service = new AVICTableRepository();

        public List<AVICTableEntity> GetList()
        {
            return service.IQueryable().ToList();
        }
    }
}
