using MySql.Data.MySqlClient;
using NFine.Data;
using NFine.Domain._03_Entity.OperationMonitoring;
using NFine.Domain._04_IRepository.OperationMonitoring;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NFine.Repository.OperationMonitoring
{
    public class UserEngineeringRepository : RepositoryBase<UserEngineeringEntity>, IUserEngineeringRepository
    {
        public List<UserEngineeringEntity> GetUserEngineeringList(string account)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(@"SELECT b.F_RealName as RealName,a.* FROM	Sys_UserEngineering a LEFT JOIN Sys_User b ON b.F_Account=a.Account WHERE a.IsEffective=1 and b.F_Account=@account");
            DbParameter[] parameter =
            {
                 //new SqlParameter("@account",account)
                 new MySqlParameter("@account",account)
            };
            return this.FindList(strSql.ToString(), parameter);
        }
    }
}
