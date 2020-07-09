using MySql.Data.MySqlClient;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;

namespace TeamSynchronization
{
   public class DbService
    {

        #region 成员变量

        private string connectionString;
        public string ConntionString
        {
            get
            {
                return connectionString;
            }
            set
            {
                connectionString = value;
            }
        }

        private string dbType;
        public string DbType
        {
            get
            {
                if (dbType == string.Empty || dbType == null)
                {
                    return "Access";
                }
                else
                {
                    return dbType;
                }
            }
            set
            {
                if (value != string.Empty && value != null)
                {
                    dbType = value;
                }
                if (dbType == string.Empty || dbType == null)
                {
                    dbType = "Access";
                }
            }
        }
 
        public DbService(string strConnect, string dataType)
        {
            this.ConntionString = strConnect;
            this.DbType = dataType;
        }

        #endregion

        #region 获取连接

        private IDbConnection GetConnection()
        {
            switch (this.DbType)
            {
                case "SqlServer":
                    return new System.Data.SqlClient.SqlConnection(this.ConntionString);
                case "MySQL":
                    return new MySql.Data.MySqlClient.MySqlConnection(this.ConntionString);
                //case "Oracle":
                //    return new OracleConnection(this.ConntionString);
                case "Access":
                    return new System.Data.OleDb.OleDbConnection(this.ConntionString);
                default:
                    return new System.Data.SqlClient.SqlConnection(this.ConntionString);
            }
        }

        private IDbCommand GetCommand(string Sql, IDbConnection iConn)
        {
            switch (this.DbType)
            {
                case "SqlServer":
                    return new System.Data.SqlClient.SqlCommand(Sql, (SqlConnection)iConn);
                case "MySQL":
                    return new MySql.Data.MySqlClient.MySqlCommand(Sql, (MySqlConnection)iConn);
                //case "Oracle":
                //    return new OracleCommand(Sql, (OracleConnection)iConn);
                case "Access":
                    return new System.Data.OleDb.OleDbCommand(Sql, (OleDbConnection)iConn);
                default:
                    return new System.Data.SqlClient.SqlCommand(Sql, (SqlConnection)iConn);
            }
        }

        private MySqlCommand GetMySqlCommand(string Sql, IDbConnection iConn)
        {
            return new MySql.Data.MySqlClient.MySqlCommand(Sql, (MySqlConnection)iConn);
        }

        private IDbCommand GetCommand()
        {
            switch (this.DbType)
            {
                case "SqlServer":
                    return new System.Data.SqlClient.SqlCommand();
                case "MySQL":
                    return new MySql.Data.MySqlClient.MySqlCommand();
                //case "Oracle":
                //    return new OracleCommand();
                case "Access":
                    return new System.Data.OleDb.OleDbCommand();
                default:
                    return new System.Data.SqlClient.SqlCommand();
            }
        }

        private IDataAdapter GetAdapater(string Sql, IDbConnection iConn)
        {
            switch (this.DbType)
            {
                case "SqlServer":
                    return new System.Data.SqlClient.SqlDataAdapter(Sql, (SqlConnection)iConn);
                case "MySQL":
                    return new MySql.Data.MySqlClient.MySqlDataAdapter(Sql, (MySqlConnection)iConn);
                //case "Oracle":
                //    return new OracleDataAdapter(Sql, (OracleConnection)iConn);
                case "Access":
                    return new System.Data.OleDb.OleDbDataAdapter(Sql, (OleDbConnection)iConn);
                default:
                    return new System.Data.SqlClient.SqlDataAdapter(Sql, (SqlConnection)iConn); ;
            }
        }

        private IDataAdapter GetAdapater()
        {
            switch (this.DbType)
            {
                case "SqlServer":
                    return new System.Data.SqlClient.SqlDataAdapter();
                case "MySQL":
                    return new MySql.Data.MySqlClient.MySqlDataAdapter();
                //case "Oracle":
                //    return new OracleDataAdapter();
                case "Access":
                    return new System.Data.OleDb.OleDbDataAdapter();
                default:
                    return new System.Data.SqlClient.SqlDataAdapter();
            }
        }

        private IDataAdapter GetAdapater(IDbCommand iCmd)
        {
            switch (this.DbType)
            {
                case "SqlServer":
                    return new System.Data.SqlClient.SqlDataAdapter((SqlCommand)iCmd);
                case "MySQL":
                    return new MySql.Data.MySqlClient.MySqlDataAdapter((MySqlCommand)iCmd);
                //case "Oracle":
                //    return new OracleDataAdapter((OracleCommand)iCmd);
                case "Access":
                    return new System.Data.OleDb.OleDbDataAdapter((OleDbCommand)iCmd);
                default:
                    return new System.Data.SqlClient.SqlDataAdapter((SqlCommand)iCmd);
            }
        }

        public void OpenConn()
        {
            using (IDbConnection iConn = this.GetConnection())
            {
                if (iConn.State != ConnectionState.Open)
                {
                    try
                    {
                        iConn.Open();
                    }
                    catch
                    {
                        return;
                    }
                }
            }
        }

        public void CloseConn()
        {
            using (IDbConnection iConn = this.GetConnection())
            {
                if (iConn.State != ConnectionState.Closed)
                {
                    try
                    {
                        iConn.Close();
                    }
                    catch
                    {
                        return;
                    }
                }
            }
        }

        public void DisposeConn()
        {
            using (IDbConnection iConn = this.GetConnection())
            {
                try
                {
                    if (iConn.State != ConnectionState.Closed)
                    {
                        try
                        {
                            iConn.Close();
                        }
                        catch
                        {
                            return;
                        }
                    }
                }
                catch
                {
                    return;
                }
            }
        }

        #endregion

        #region 查询语句

        public int ExecuteSql(string sSql)
        {
            using (IDbConnection iConn = this.GetConnection())
            {
                using (IDbCommand iCmd = GetCommand(sSql, iConn))
                {
                    iConn.Open();
                    try
                    {
                        int rows = iCmd.ExecuteNonQuery();
                        return rows;
                    }
                    catch (System.Exception E)
                    {
                        //throw new Exception(E.Message);
                        return 0;
                    }
                    finally
                    {
                        if (iConn.State != ConnectionState.Closed)
                        {
                            iConn.Close();
                        }
                    }
                }
            }
            return 0;
        }

        public int InsertSql(string sSql, out int internal_id)
        {
            internal_id = 0;
            using (IDbConnection iConn = this.GetConnection())
            {
                using (MySqlCommand iCmd = GetMySqlCommand(sSql, iConn))
                {
                    iConn.Open();
                    try
                    {
                        int rows = iCmd.ExecuteNonQuery();
                        internal_id = (int)iCmd.LastInsertedId;

                        return rows;
                    }
                    catch (System.Exception E)
                    {
                        //throw new Exception(E.Message);
                        LogHelper.Error(E.Message + ":" + sSql);
                        return 0;
                    }
                    finally
                    {
                        if (iConn.State != ConnectionState.Closed)
                        {
                            iConn.Close();
                        }
                    }
                }
            }
            return 0;
        }

        public int DeleteSql(string sSql)
        {
            using (IDbConnection iConn = this.GetConnection())
            {
                using (MySqlCommand iCmd = GetMySqlCommand(sSql, iConn))
                {
                    iConn.Open();
                    try
                    {
                        int rows = iCmd.ExecuteNonQuery();

                        return rows;
                    }
                    catch (System.Exception E)
                    {
                        LogHelper.Error(E.Message + ":" + sSql);
                        return 0;
                    }
                    finally
                    {
                        if (iConn.State != ConnectionState.Closed)
                        {
                            iConn.Close();
                        }
                    }
                }
            }
            return 0;
        }


        public DataTable Query(string sSql)
        {
            DataTable dt = null;
            using (IDbConnection iConn = this.GetConnection())
            {
                using (IDbCommand iCmd = GetCommand(sSql, iConn))
                {
                    DataSet ds = new DataSet();
                    iConn.Open();
                    try
                    {
                        IDataAdapter iAdapter = this.GetAdapater(sSql, iConn);
                        iAdapter.Fill(ds);

                        if (ds != null && ds.Tables.Count > 0)
                        {
                            dt = ds.Tables[0];
                        }
        
                    }
                    catch (System.Exception ex)
                    {
                        //throw new Exception(ex.Message);

                    }
                    finally
                    {
                        if (iConn.State != ConnectionState.Closed)
                        {
                            iConn.Close();
                        }
                    }
                }
            }
            return dt;
        }

        public bool IsExistRecord(string sSql)
        {
            bool bRet = false;

            DataTable dt = Query(sSql);
            if (dt != null && dt.Rows.Count > 0)
            {
                bRet = true;
            }

            return bRet;
        }

        public string GetFirstValue(string sSql)
        {
            string sRet = "";

            DataTable dt = Query(sSql);
            if (dt != null && dt.Rows.Count > 0)
            {
                sRet = dt.Rows[0][0].ToString();
            }

            return sRet;
        }

        #endregion
        

    }
}




