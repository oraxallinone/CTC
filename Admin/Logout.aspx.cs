using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;

public partial class Admin_Logout : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Session.Abandon();
            Session.Clear();

            //Response.Cookies["Uid"].Expires = DateTime.Now.AddDays(-1);
            //Response.Cookies["SAdmin"].Expires = DateTime.Now.AddDays(-1);
            Response.Redirect("../Login.aspx");

        }

    }
}
