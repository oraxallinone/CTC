using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_SuperAdmin : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["SAdmin"] == null)
        {
            Response.Redirect("Login.aspx");
        }
        if (!IsPostBack)
        {
            imgbtnberhmpur.Visible = false;
            imgbtnanugul.Visible = false;
            hulnakhara.Visible = false;
        }
    }

    protected void imgbtnlogout_Click(object sender, ImageClickEventArgs e)
    {
        Session.Abandon();//*  *//
        Session.Clear();//*  *//
        Response.Redirect("Login.aspx");
    }

    protected void imgbtnctc_Click(object sender, ImageClickEventArgs e)//* only this one needed  *//
    {
        if (Session["SAdmin"] == null)
        {
            Response.Redirect("Login.aspx");
        }
        Session["Uid"] = Session["SAdmin"].ToString();//*  *//
        Session["Branch"] = "Cuttack";
        Session.Timeout = 500;//*  *//
        Response.Redirect("~/Branch_Login.aspx");
    }

    #region--------------------------- no need --------------------
    protected void imgbtnberhmpur_Click(object sender, ImageClickEventArgs e)
    {
        if (Session["SAdmin"] == null)
        {
            Response.Redirect("Login.aspx");
        }
        Session["Uid"] = Session["SAdmin"].ToString();
        Session["Branch"] = "Berhampur";
        Session.Timeout = 500;
        Response.Redirect("~/Branch_Login.aspx");

    }

    protected void imgbtnanugul_Click(object sender, ImageClickEventArgs e)
    {
        if (Session["SAdmin"] == null)
        {
            Response.Redirect("Login.aspx");
        }
        Session["Uid"] = Session["SAdmin"].ToString();
        Session["Branch"] = "Paradeep";
        Session.Timeout = 500;
        Response.Redirect("~/Branch_Login.aspx");

    }

    protected void hulnakhara_Click(object sender, ImageClickEventArgs e)
    {
        if (Session["SAdmin"] == null)
        {
            Response.Redirect("Login.aspx");
        }
        Session["Uid"] = Session["SAdmin"].ToString();
        Session["Branch"] = "Phulnakhara";
        Session.Timeout = 500;
        Response.Redirect("~/Branch_Login.aspx");

    }
    #endregion
    
}