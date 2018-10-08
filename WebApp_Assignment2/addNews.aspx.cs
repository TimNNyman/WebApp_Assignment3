using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Data.Sql;

namespace WebApp_Assignment2
{
    public partial class addNews : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if ((string)Session["loggedIn"] == null)
            {
                Response.Redirect("login.aspx");
            } 
        }

        protected void submitBtn_Click(object sender, EventArgs e)
        {

            if (FileUploadControl.HasFile)
            {
                string filename;
                try
                {
                    filename = Path.GetFileName(FileUploadControl.FileName);
                    FileUploadControl.SaveAs(Server.MapPath("~/images/") + filename);
                }
                catch (Exception ex)
                {
                    return;
                }

                newsData _data = new newsData()
                {
                    Title = Title.Value.Replace(">", "").Replace("<", ""),
                    Image = "images/" + filename,
                    Text = Content.Value.Replace(">", "").Replace("<", "")
                };

                DatabaseConnector.Inst.saveNewsData(Server.MapPath("~/ ") + "/json/updatableNews.json", _data, (string)Session["loggedIn"]);

                Response.Redirect("default.aspx");
            }
        }

        protected void cancelBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("default.aspx");
        }   
    }
}