using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Data;
using System.Data.SqlClient;
namespace workshop101.Repositories
{
    //<#.n1 kunanon photibanlung 20180531>
    interface IRepositories
    {
        DataSet callDbWithValue(string strSql);
        void callDb(string cmdText);
    }
    public class Repositories: IRepositories
    {
        private string connStr = WebConfigurationManager.ConnectionStrings["connStrMyDB"].ConnectionString;
        public string ConnectionString { get { return connStr; } set { connStr = value; } }//This property use to 
        public virtual void callDb(string cmdText)
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                SqlCommand cmd = new SqlCommand(cmdText, conn);
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
                conn.Dispose();
            }
        }
        public virtual DataSet callDbWithValue(string strSql)
        {
            DataSet ds = new DataSet();
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                SqlCommand cmd = new SqlCommand(strSql, conn);
                SqlDataAdapter ad = new SqlDataAdapter(cmd);
                ad.Fill(ds);
            }
            return ds;
        }
    }
    //</#.n1 kunanon photibanlung 20180531>
}