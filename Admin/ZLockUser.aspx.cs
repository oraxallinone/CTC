using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AutoMobileModel;
using System.Globalization;

public partial class Admin_ViewAssignedUser : System.Web.UI.Page
{
    AutoMobileEntities db = new AutoMobileEntities();
    public string uname;
    public string uid;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["SAdmin"] == null)
        {
            Response.Redirect("AccessDenied.aspx");
        }
        if (!IsPostBack)
        {
            fillgrid();
        }
    }

    public void fillgrid()
    {
        string branchname = Session["Branch"].ToString();
        var grid = from c in db.AME_Users.Where(t => t.Branch_Name == branchname) select c;
        grdType.DataSource = grid;
        grdType.DataBind();
        foreach (GridViewRow gr in grdType.Rows)
        {
            Label lblbranch = (Label)gr.FindControl("lblbranch");
            string code = Convert.ToString(lblbranch.ToolTip);
            TextBox txtUserType = (TextBox)gr.FindControl("txtUserType");
            string txtUserType1 = Convert.ToString(txtUserType.ToolTip);

            ImageButton imglock = (ImageButton)gr.FindControl("imglock");
            ImageButton imgonlock = (ImageButton)gr.FindControl("imgonlock");
            if (Convert.ToInt32(imglock.CommandArgument) == 0)
            {
                imglock.Visible = true;
                imgonlock.Visible = false;

            }
            else
            {
                imglock.Visible = false;
                imgonlock.Visible = true;
            }
        }


    }

  
    protected void lnkbtn_ShowPwd_Click(object sender, EventArgs e)
    {
        LinkButton img = (LinkButton)sender;
        string imgid = img.ToolTip;
        foreach (GridViewRow gr in grdType.Rows)
        {
            LinkButton imgFc = (LinkButton)gr.FindControl("lnkbtn_ShowPwd");
            string id = imgFc.ToolTip;
            if (imgid == id)
            {
                LinkButton lnkbtn_HidePwd = (LinkButton)gr.FindControl("lnkbtn_HidePwd");
                LinkButton lnkbtn_ShowPwd = (LinkButton)gr.FindControl("lnkbtn_ShowPwd");
                TextBox txtPassword = (TextBox)gr.FindControl("txtPassword");

                lnkbtn_HidePwd.Visible = true;
                lnkbtn_ShowPwd.Visible = false;
                txtPassword.Visible = false;
            }
        }
    }
    protected void lnkbtn_HidePwd_Click(object sender, EventArgs e)
    {
        LinkButton img = (LinkButton)sender;
        string imgid = img.CommandArgument;
        foreach (GridViewRow gr in grdType.Rows)
        {
            LinkButton imgFc = (LinkButton)gr.FindControl("lnkbtn_HidePwd");
            string id = imgFc.CommandArgument;
            if (imgid == id)
            {
                LinkButton lnkbtn_HidePwd = (LinkButton)gr.FindControl("lnkbtn_HidePwd");
                LinkButton lnkbtn_ShowPwd = (LinkButton)gr.FindControl("lnkbtn_ShowPwd");
                TextBox txtPassword = (TextBox)gr.FindControl("txtPassword");

                lnkbtn_HidePwd.Visible = false;
                lnkbtn_ShowPwd.Visible = true;
                txtPassword.Visible = false;
            }
        }
    }

    protected void imglock_Click(object sender, ImageClickEventArgs e)
    {
        ImageButton img = (ImageButton)sender;
        string imgid = img.ToolTip;
        foreach (GridViewRow gr in grdType.Rows)
        {
            ImageButton imglock = (ImageButton)gr.FindControl("imglock");
            string id = imglock.ToolTip;
            int slno = Convert.ToInt32(id);
            if (imgid == id)
            {

                TextBox txtPassword = (TextBox)gr.FindControl("txtPassword");

                LinkButton lnkbtn_HidePwd = (LinkButton)gr.FindControl("lnkbtn_HidePwd");
                LinkButton lnkbtn_ShowPwd = (LinkButton)gr.FindControl("lnkbtn_ShowPwd");

                ImageButton imgonlock = (ImageButton)gr.FindControl("imgonlock");


                AME_Users mu = db.AME_Users.First(t => t.Sl_No == slno);
                if (mu.User_Type == "Admin")
                {
                    mu.Permission = 1;
                }
                if (mu.User_Type == "User")
                {
                    mu.Permission = 1;
                }
                else if (mu.User_Type == "Service")
                {
                    mu.Permission = 2;
                }
                else if (mu.User_Type == "Sparepart")
                {
                    mu.Permission = 3;
                }
                else if (mu.User_Type == "VehiclesSale")
                {
                    mu.Permission = 4;
                }
                db.SaveChanges();

                txtPassword.ReadOnly = true;

                lnkbtn_HidePwd.Visible = false;
                lnkbtn_ShowPwd.Visible = true;
                txtPassword.Visible = false;



                imglock.Visible = false;
                imgonlock.Visible = true;
            }
        }
    }
    protected void imgonlock_Click(object sender, ImageClickEventArgs e)
    {
        ImageButton img = (ImageButton)sender;
        string imgid = img.ToolTip;
        foreach (GridViewRow gr in grdType.Rows)
        {
            ImageButton imgonlock = (ImageButton)gr.FindControl("imgonlock");
            string id = imgonlock.ToolTip;
            int slno = Convert.ToInt32(id);
            if (imgid == id)
            {

                TextBox txtPassword = (TextBox)gr.FindControl("txtPassword");

                ImageButton imglock = (ImageButton)gr.FindControl("imglock");
                LinkButton lnkbtn_HidePwd = (LinkButton)gr.FindControl("lnkbtn_HidePwd");
                LinkButton lnkbtn_ShowPwd = (LinkButton)gr.FindControl("lnkbtn_ShowPwd");

                AME_Users mu = db.AME_Users.First(t => t.Sl_No == slno);
                mu.Permission = 0;
                db.SaveChanges();


                txtPassword.ReadOnly = true;

                lnkbtn_HidePwd.Visible = false;
                lnkbtn_ShowPwd.Visible = true;
                txtPassword.Visible = false;

                imgonlock.Visible = true;
                imglock.Visible = false;
                fillgrid();
            }
        }
    }
}