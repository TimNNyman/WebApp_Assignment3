using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApp_Assignment2
{
    public partial class Search : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string search = Request.QueryString["search"];
            Response.Clear();
            Response.Write(createLinkCollection(DatabaseConnector.Inst.get5Searches(search)));
            Response.End();
        }

        private string createLinkCollection(List<string> elem)
        {
            string ret = "";
            for (int i = 0; i < elem.Count; i++)
            {
                ret += createLinkElement(elem[i]);
            }
            return ret;
        }
        private string createLinkElement(string title)
        {
            string ret = "<a class=seachLink href=\"newsArticle.aspx?title=" + title + "\">" + title + "</a>";
            return ret;
        }
    }
}