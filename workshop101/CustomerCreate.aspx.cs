using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using workshop101.Repositories;
using workshop101.Controller;
using System.Data.SqlClient;

namespace workshop101
{
    public partial class CustomerCreate : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                txtDate.Value = DateTime.Now.ToString("yyyy/mm/dd");
            }
        }
        protected void btnSubmitDelete_Click(object sender, EventArgs e)
        {
            try
            {
                float postalCode = float.Parse(txtPostalCode.Text);
                DateTime Tdatetime = DateTime.Parse(txtDate.Value);
                CustRepositories Rcust = new CustRepositories();
                CustModel Mcust = new CustModel()
                {
                    custId = txtId.Text,
                    Name = txtName.Text,
                    contract = txtContact.Text,
                    address = txtAddress.Text,
                    city = txtCity.Text,
                    country = txtCountry.Text,
                    postalCode = postalCode,
                    coverImg = saveAsPicture(fuCoverImg)
                };
                Rcust.insertCustomerList(Mcust);
                showAlertSuccess("alertSuccess", "Insert success");
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