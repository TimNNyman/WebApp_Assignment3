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
    public partial class _default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            articles.InnerHtml += getNewsAsHtmlString();

            if ((string)Session["loggedIn"] == "true")
            {
            }
        }

        private string getNewsAsHtmlString()
        {
            List<newsData> news = DatabaseConnector.Inst.readNewsData(Server.MapPath("~/ ") + "/json/news.json");
            List<newsData> uNews = DatabaseConnector.Inst.readNewsData(Server.MapPath("~/ ") + "/json/updatableNews.json");
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

        private void LogOut()
        {
            if ((string)Session["loggedIn"] != null)
            {
                Session.Abandon();
            }
        }
    }
}