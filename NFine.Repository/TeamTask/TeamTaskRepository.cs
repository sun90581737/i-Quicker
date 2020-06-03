using NFine.Data;
using NFine.Domain._03_Entity.TeamTask;
using NFine.Domain.IRepository.TeamTask;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NFine.Repository.TeamTask
{
    public class TeamTaskRepository : RepositoryBase<TeamTaskEntity>, ITeamTaskRepository
    {
    }
}
