using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Data;
using System.Data.SqlClient;

namespace WebApp_Assignment2
{
    public partial class newsArticle : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string title = Request.QueryString["title"];
            if (title == null)
            {
                Response.Redirect("default.aspx");
            }

            newsData target = new newsData();


            List<newsData> news = new List<newsData>();
            List<newsData> uNews = new List<newsData>();
            string CS = "Server=.\\MY_TEST_INSTANCE; Database = WebApp; Trusted_Connection = True";
            using (SqlConnection con = new SqlConnection(CS))
            {
                con.Open();

                string query = "SELECT Title, Text, Image from Articles";
                SqlCommand cmd = new SqlCommand(query, con);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    var article = new newsData();
                    article.Title = reader.GetString(0).Trim();
                    article.Text = reader.GetString(1).Trim();
                    article.Image = reader.GetString(2).Trim();
                    news.Add(article);
                }
                reader.Close();
                string query2 = "SELECT TOP 1 * FROM UpdatableNews";
                cmd = new SqlCommand(query2, con);
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    var article = new newsData();
                    article.Title = reader.GetString(1).Trim();
                    article.Text = reader.GetString(2).Trim();
                    article.Image = reader.GetString(3).Trim();
                    uNews.Add(article);
                }
                reader.Close();
            }



            news = news.Concat(uNews).ToList(); ;

            for (int i = 0; i < news.Count; i++)
            {
                if(news[i].Title == title)
                {
                    target = news[i];
                    break;
                }
            }

 
            HtmlGenericControl myDiv = new HtmlGenericControl("div");
            myDiv.ID = "myDiv";

            if (target.Image.Substring(target.Image.LastIndexOf('.') + 1) == "mp4")
            {
                myDiv.InnerHtml += "<video controls class=\"updateVideo\"><source src=\"" + target.Image + "\" type=\"video/mp4\"/></video>";
            }

            else
                myDiv.InnerHtml += "<div class=\"image\">" + "<img src=\"" + target.Image + "\" />" + "</div>";

            myDiv.InnerHtml += "<div class=\"title\">" + title + "</div>";
            myDiv.InnerHtml += "<div class=\"text\">" + target.Text + "</div>";

            PlaceHolder1.Controls.Add(myDiv);
        }
    }
}