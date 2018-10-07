using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApp_Assignment2
{
    public partial class login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void loginBtn_Click(object sender, EventArgs e)
        {
            if (username.Text != "" && password.Text != "")
            {
                Session["loggedIn"] = "true";
                Response.Redirect("addNews.aspx");
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