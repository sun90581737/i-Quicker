using MySql.Data.MySqlClient;
using NFine.Data;
using NFine.Domain._03_Entity.AutomationLine;
using NFine.Domain._04_IRepository.AutomationLine;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NFine.Repository.AutomationLine
{
    public class DataAcquisitionDetailRepository : RepositoryBase<DataAcquisitionDetailEntity>, IDataAcquisitionDetailRepository
    {
        public List<DataAcquisitionDetailEntity> DataAcquisitionDetail(string ConfTime)
        {
            var Time = 0;
            if (string.IsNullOrEmpty(ConfTime))
            {
                Time = 0;
            }
            else
            {
                Time = Convert.ToInt32(ConfTime);
            }
            var GetDateTime= DateTime.Now.AddMinutes(-1);
            StringBuilder strSql = new StringBuilder();
            strSql.Append(@"SELECT * FROM  Sys_DataAcquisitionDetail 
            where IsEffective=1 AND RunTime between @starttime and @endtime  GROUP BY DeviceName");
            DbParameter[] parameter =
            {
                 //new SqlParameter("@account",account)
                 new MySqlParameter("@starttime",GetDateTime.ToString()),
                 new MySqlParameter("@endtime",GetDateTime.AddSeconds(Time).ToString())
            };
            return this.FindList(strSql.ToString(), parameter);
        }
    }
}
