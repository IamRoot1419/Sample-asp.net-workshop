using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace workshop101.Repositories
{
    //<#.n1 kunanon photibanlung 20180531>
    interface ICustRepositories
    {
        DataSet selectCustomerList();
        DataSet getDataById(string custId);
        void insertCustomerList(CustModel data);
        void deleteCustomerList(string custId);
        void updateCustomerLlist(string whereId,CustModel data);
    }
    public class CustRepositories : Repositories, ICustRepositories
    {
        //Data method.
        public DataSet selectCustomerList()
        {
            string strSql = "select * from testdb1.dbo.CustTable;";
            return callDbWithValue(strSql);
        }
        public DataSet getDataById(string custId)
        {
            string cmdText = $"SELECT * FROM testdb1.dbo.CustTable WHERE CustomerId='{custId}';";
            return callDbWithValue(cmdText);
        }
        public void insertCustomerList(CustModel data)
        {
            CustModel dt = data;
            string cmdText1= "INSERT INTO testdb1.dbo.CustTable (CustomerID, CustomerName, ContactName, Address, City, Country, PostalCode, coverImg)"
                           + $"VALUES ('{dt.custId}','{dt.Name}','{dt.contract}','{dt.address}','{dt.city}','{dt.country}','{dt.postalCode}','{dt.coverImg}')";
            callDb(cmdText1);
        }
        public void deleteCustomerList(string custId)
        {
            string cmdText = $"DELETE FROM testdb1.dbo.CustTable WHERE CustTable.CustomerID='{custId}';";
            callDb(cmdText);
        }
        public void updateCustomerLlist(string whereId, CustModel data)
        {
            string cmdText = $"update testdb1.dbo.CustTable set CustomerID = '{data.custId}',"
                                                            + $"CustomerName = '{data.Name}',"
                                                            + $"ContactName = '{data.contract}',"
                                                            + $"Address = '{data.address}',"
                                                            + $"City = '{data.city}',"
                                                            + $"PostalCode = {data.postalCode},"
                                                            + $"Country = '{data.country}',"
                                                            + $"coverImg = '{data.coverImg}'"
                            + $"where CustomerID = '{whereId}';";
            callDb(cmdText);
        } 
    }
    public class CustModel
    {
        //Customer data model.
        public string custId { get; set; }
        public string Name { get; set; }
        public string contract { get; set; }
        public string address { get; set; }
        public string city { get; set; }
        public float  postalCode { get; set; }
        public string country { get; set; }
        public string coverImg { get; set; }
    }
    //</#.n1 kunanon photibanlung 20180531>
}