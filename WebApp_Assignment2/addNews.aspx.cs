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

                List<newsData> _data = new List<newsData>();

                _data.Add(new newsData()
                {
                    Title = Title.Value.Replace(">", "").Replace("<", ""),
                    Image = "images/" + filename,
                    Text = Content.Value.Replace(">", "").Replace("<", "")
                });


                string CS = "Server=.\\MY_TEST_INSTANCE; Database = WebApp; Trusted_Connection = True";
                string cmdString = "UPDATE UpdatableNews Set [User]=@user, Title=@title, Text=@text, Image=@image";

                using (SqlConnection con = new SqlConnection(CS))
                {
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = con;
                        cmd.CommandText = cmdString;
                        cmd.Parameters.AddWithValue("@user", (string)Session["loggedIn"]);
                        cmd.Parameters.AddWithValue("@title", _data[0].Title);
                        cmd.Parameters.AddWithValue("@text", _data[0].Text);
                        cmd.Parameters.AddWithValue("@image", _data[0].Image);
                            con.Open();
                            cmd.ExecuteNonQuery();

                    }
                }

                //DatabaseConnector.Inst.saveNewsData(Server.MapPath("~/ ") + "/json/updatableNews.json", _data);

                Response.Redirect("default.aspx");
            }
        }

        protected void cancelBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("default.aspx");
        }   
    }
}