using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using DataSetTableAdapters;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class home : System.Web.UI.Page
{
    private static UserDBTableAdapter u = new UserDBTableAdapter();
    private string username = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        if(Request.Cookies["loginDetails"] != null)
        {
            if(Request.Cookies["loginDetails"]["username"] != null)
            {
                username = Request.Cookies["loginDetails"]["username"].ToString();
            }
        }
        if (Request.QueryString["type"] != null)
        {
            if (Request.QueryString["type"].ToString() == "chas")
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "a", "initMap()", true);
            }
            else if (Request.QueryString["type"].ToString() == "dengue")
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "a", "initDengue()", true);

            }
            else if (Request.QueryString["type"].ToString() == "poly")
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "a", "initPoly()", true);

            }
        }
        else
        {
            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "a", "initMap()", true);

        }
    }




}