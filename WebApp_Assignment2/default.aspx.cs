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

namespace WebApp_Assignment2
{
    public partial class _default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            articles.InnerHtml += getNewsAsHtmlString();

            if ((string)Session["loggedIn"] == "true")
            {
                login.Text = "Log Out";
            }
        }

        private string getNewsAsHtmlString()
        {
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



         //   List<newsData> news = DatabaseConnector.Inst.readNewsData(Server.MapPath("~/ ") + "/json/news.json");
         //   List<newsData> uNews = DatabaseConnector.Inst.readNewsData(Server.MapPath("~/ ") + "/json/updatableNews.json");
            string retString = "";

            for (int i = 0; i < uNews.Count; i++)
            {

                if (uNews[i].Image.Substring(uNews[i].Image.LastIndexOf('.') + 1) == "mp4")
                {
                    retString += createUpdatableNewsElementVideo(uNews[i]);
                }
                else
                    retString += createUpdatableNewsElement(uNews[i]);
            }

            for (int i = 0; i < news.Count; i++)
            {
                retString += createNewsElement(news[i]);
            }

            return retString;
        }

        private string createNewsElement(newsData e)
        {
            return string.Format("<div class=\"container\"><a href=\"{0}\"><img src =\"{1}\" class=\"image\"/><div class=\"overlay\" ><div class=\"title\">{2}</div><div class=\"text\">{3}</div></div></a></div>"
                , createNewsLink(e.Title), e.Image, e.Title, e.Text);
        }

        private string createUpdatableNewsElement(newsData e)
        {
            return string.Format("<div class=\"updatableNews\"><a href=\"{0}\"><img src =\"{1}\" class=\"image\"/><div class=\"textContent\" ><div class=\"title\">{2}</div><div class=\"text\">{3}</div></div></a></div>"
                , createNewsLink(e.Title), e.Image, e.Title, e.Text);
        }

        private string createUpdatableNewsElementVideo(newsData e)
        {
            return string.Format("<div class=\"updatableNews\"><a href=\"{0}\"><video controls class=\"updateVideo\"><source src=\"{1}\" type=\"video/mp4\"/></video><div class=\"textContent\" ><div class=\"title\">{2}</div><div class=\"text\">{3}</div></div></a></div>"
                , createNewsLink(e.Title), e.Image, e.Title, e.Text);
        }

        private string createNewsLink(string title)
        {
            return "newsArticle.aspx?title=" + title;
        }

        protected void login_Click(object sender, EventArgs e)
        {
            if ((string)Session["loggedIn"] != null)
            {
                Session.Abandon();
                Response.Redirect("default.aspx");
            }
            else
                Response.Redirect("login.aspx");
        }
    }
}