using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

namespace WebApp_Assignment2
{
    public partial class login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            GridView1.Visible = false;
        }

        protected void loginBtn_Click(object sender, EventArgs e)
        {
            if (username.Text != "" && password.Text != "")
            {
                string CS = "Server=.\\MY_TEST_INSTANCE; Database = WebApp; Trusted_Connection = True";
                using (SqlConnection con = new SqlConnection(CS))
                {
                    con.Open();

                    string query = "SELECT COUNT(1) from Login WHERE [User]=@username AND Password=@password";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@username", username.Text.Trim());
                    cmd.Parameters.AddWithValue("@password", password.Text.Trim());
                    int count = Convert.ToInt32(cmd.ExecuteScalar());

                    if (count == 1)
                    {
                        Session["loggedIn"] = username.Text;
                        Response.Redirect("addNews.aspx");
                    }
                    
                }
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "alert('Login failed!');", true);
                username.Text = "";
                password.Text = "";
            }
        }

        protected void cancelBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("default.aspx");
        }

        protected void VerifyInput(object sender, EventArgs e)
        {
            if (username.Text != "" && password.Text != "")
            {
                loginBtn.BackColor = System.Drawing.Color.Green;
            }
            else
            {
                loginBtn.BackColor = System.Drawing.Color.Gray;
            }
        }
    }
}