using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Web;
using System.Web.Configuration;
using System.Web.UI.WebControls;

namespace workshop101.Controller
{
    public class BasePage : System.Web.UI.Page
    {
        public void showAlettError(string key,string msg)
        {
            //Call function showAlertError form site.master and run it on web page.
            ClientScript.RegisterStartupScript(GetType(), key, "showAlertError('" + msg + "');", true); 
        }
        public void showAlertSuccess(string key, string msg)
        {
            //Call function showAlertSuccess form site.master and run it on web page.
            ClientScript.RegisterStartupScript(GetType(), key, "showAlertSuccess('" + msg + "');", true);
        }
        public string saveAsPicture(FileUpload picture)
        {
            string folderImg     = "/imgCover";
            string pathFolderImg = Server.MapPath("~/" + folderImg);
            if (!Directory.Exists(pathFolderImg))
            {
                Directory.CreateDirectory(pathFolderImg);//Create directory if imgCover wasn't exists in web server.
            }
            string extFile       = Path.GetExtension(picture.FileName);
            string fileName      = Guid.NewGuid().ToString();
            string fileNameExt   = "/" + fileName + extFile;
            picture.SaveAs(pathFolderImg + fileNameExt); //save file uploaded to web server.
            string coverImg      = folderImg + fileNameExt;
            return coverImg;//img path
        }
        public string getValueFromGridViews(object senderBtnEvent)
        {
            var btnCurrent = (Button)senderBtnEvent;//ไปอ่าน casting กับ event ใน onenote แล้วจะเข้าใจ
            var row = (GridViewRow)btnCurrent.NamingContainer;//อ่าน record จาก custlist แล้ว casting เป็น GridViewRow มาให้ row
            var img = (Image)row.FindControl("img");//อ่านชื่อไฟล์ img จาก row ที่ casting เป็น Image
            string pathImg = Server.MapPath("~") + img.ImageUrl;//อ่าน path จาก server(localhost)
            //if (File.Exists(pathImg))
            //{
                //File.Delete(pathImg);
            //}
            string id = row.Cells[0].Text;
            return id;
        }
        
    }
}