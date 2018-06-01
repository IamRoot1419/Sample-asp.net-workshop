using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using workshop101.Controller;
using workshop101.Repositories;
using System.Data.SqlClient;
namespace workshop101
{
    public partial class CustomerEdits : BasePage
    {
        CustRepositories custRepo = new CustRepositories();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                setData();
            }
        }
        protected void btnSubmitEdit_Click(object sender, EventArgs e)
        {
            try
            {
                float postalCode = float.Parse(txtPostalCode.Text);
                string parmId   = Request["id"];
                CustModel Mcust = new CustModel()
                {
                    custId      = txtId.Text,
                    Name        = txtName.Text,
                    contract    = txtContact.Text,
                    address     = txtAddress.Text,
                    city        = txtCity.Text,
                    country     = txtCountry.Text,
                    postalCode  = postalCode,
                    coverImg    = saveAsPicture(fuCoverImg)
                };
                custRepo.updateCustomerLlist(parmId, Mcust);
                Response.Redirect("CustomerList.aspx?Alert=Edit_Success");
                //showAlertSuccess("alertSuccess", "Edit success.");
            }
            catch(SqlException sqlEx)
            {
                showAlettError("alertSqlErr", sqlEx.Message);
            }
            catch(Exception ex)
            {
                showAlettError("alertErr", ex.Message);
            }
            
        }
        public void setData()
        {
            try
            {
                string parmId = Request["id"];
                if (string.IsNullOrEmpty(parmId))
                    showAlettError("alertErrParmId", "Parameter id is null");
                var data = custRepo.getDataById(parmId);
                if (data.Tables[0].Rows.Count == 0)
                    showAlettError("alertErrDataEmpty", "Data is empty");
                else
                {
                    var row = data.Tables[0].Rows[0];
                    txtId.Text          = row["CustomerID"].ToString();
                    txtName.Text        = row["CustomerName"].ToString();
                    txtContact.Text     = row["ContactName"].ToString();
                    txtAddress.Text     = row["Address"].ToString();
                    txtCity.Text        = row["City"].ToString();
                    txtCountry.Text     = row["Country"].ToString();
                    txtPostalCode.Text  = row["PostalCode"].ToString();
                    Img.ImageUrl        = row["coverImg"].ToString();
                }
            }
            catch (SqlException sqlEx)
            {
                showAlettError("alertSqlErr", sqlEx.Message);
            }
            catch (Exception ex)
            {
                showAlettError("alertErr", ex.Message);
            }
        }
    }
}