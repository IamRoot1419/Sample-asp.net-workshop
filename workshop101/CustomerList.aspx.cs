using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using workshop101.Repositories;
using workshop101.Controller;

namespace workshop101
{
    public partial class CustomerList : BasePage
    {
        private CustRepositories custRepo = new CustRepositories();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
                bindCustList();

            if (Request["Alert"] == "Edit_Success")
                showAlertSuccess("alertEditSuccess", "Edit Success");
        }
        void bindCustList()
        {
            gvCustTable.DataSource = custRepo.selectCustomerList();
            gvCustTable.DataBind();
        }

        protected void btnDel_Click(object sender, EventArgs e)
        {
            try
            {
                custRepo.deleteCustomerList(getValueFromGridViews(sender));//แก้ sender
                bindCustList();
                showAlertSuccess("alertSuccess", "Delete success");
            }
            catch(SqlException sqlEx)
            {
                showAlettError("alertSqlErr",sqlEx.Message);
            }
            catch(Exception ex)
            {
                showAlettError("alertErr", ex.Message);
            }
        }

        protected void btnEdit_Click(object sender, EventArgs e) => Response.Redirect("CustomerEdits.aspx?id="+ getValueFromGridViews(sender));
    }
}