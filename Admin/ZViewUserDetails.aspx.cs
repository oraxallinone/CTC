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
       
        if(!IsPostBack)
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
    protected void imgbtnedit_Click(object sender, ImageClickEventArgs e)
    {
        ImageButton img = (ImageButton)sender;
        string imgid = img.ToolTip;
        foreach (GridViewRow gr in grdType.Rows)
        {
            ImageButton imgFc = (ImageButton)gr.FindControl("imgbtnedit");
            string id = imgFc.ToolTip;
            if (imgid == id)
            {
                TextBox txtUserName = (TextBox)gr.FindControl("txtUserName");
                TextBox txtEmail = (TextBox)gr.FindControl("txtEmail");
                TextBox txtUserId = (TextBox)gr.FindControl("txtUserId");
                TextBox txtPassword = (TextBox)gr.FindControl("txtPassword");

                LinkButton lnkbtn_HidePwd = (LinkButton)gr.FindControl("lnkbtn_HidePwd");
                LinkButton lnkbtn_ShowPwd = (LinkButton)gr.FindControl("lnkbtn_ShowPwd");

                ImageButton imgFcc = (ImageButton)gr.FindControl("imgbtnview");

                txtUserName.ReadOnly = false;
                txtEmail.ReadOnly = false;
                txtUserId.ReadOnly = false;
                txtPassword.ReadOnly = false;

                lnkbtn_HidePwd.Visible = false;
                lnkbtn_ShowPwd.Visible = false;
                txtPassword.Visible = true;

                txtUserName.BackColor = System.Drawing.Color.Cyan;
                txtEmail.BackColor = System.Drawing.Color.Yellow;
                txtUserId.BackColor = System.Drawing.Color.Cyan;
                txtPassword.BackColor = System.Drawing.Color.Yellow;

                imgFc.Visible = false;
                imgFcc.Visible = true;
            }
        }
    }
    protected void imgbtnview_Click(object sender, ImageClickEventArgs e)
    {
        ImageButton img = (ImageButton)sender;
        string imgid = img.ToolTip;
        foreach (GridViewRow gr in grdType.Rows)
        {
            ImageButton imgFc = (ImageButton)gr.FindControl("imgbtnview");
            string id = imgFc.ToolTip;
            int slno = Convert.ToInt32(id);
            if (imgid == id)
            {
                TextBox txtUserName = (TextBox)gr.FindControl("txtUserName");
                TextBox txtEmail = (TextBox)gr.FindControl("txtEmail");
                TextBox txtUserId = (TextBox)gr.FindControl("txtUserId");
                TextBox txtPassword = (TextBox)gr.FindControl("txtPassword");

                ImageButton imgFcc = (ImageButton)gr.FindControl("imgbtnedit");
                LinkButton lnkbtn_HidePwd = (LinkButton)gr.FindControl("lnkbtn_HidePwd");
                LinkButton lnkbtn_ShowPwd = (LinkButton)gr.FindControl("lnkbtn_ShowPwd");

                var v = from c in db.AME_Users.Where(t => t.User_Id == txtUserId.Text && t.Sl_No != slno) select c;
                if (Convert.ToInt32(v.Count()) > 0)
                {
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "MessagePopUp", "<script language='JavaScript'>alert('This User Id already Exist..!! Try Different..!!');</script>", false);
                    txtUserId.Focus();
                    return;
                }
                AME_Users mu = db.AME_Users.First(t => t.Sl_No == slno);
                mu.User_Name = txtUserName.Text;
                mu.Email_Id = txtEmail.Text;
                mu.User_Id = txtUserId.Text;
                mu.Password = txtPassword.Text;
                if (txtPassword.Text != lnkbtn_HidePwd.Text)
                {
                    mu.Old_Password = lnkbtn_HidePwd.Text;
                }
                mu.Updated_By = uid;
                mu.Updated_Date = SmitaClass.IndianTime();
                db.SaveChanges();

                txtUserName.ReadOnly = true;
                txtEmail.ReadOnly = true;
                txtUserId.ReadOnly = true;
                txtPassword.ReadOnly = true;

                lnkbtn_HidePwd.Visible = false;
                lnkbtn_ShowPwd.Visible = true;
                txtPassword.Visible = false;

                imgFc.Visible = true;
                imgFcc.Visible = false;
                fillgrid();
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "MessagePopUp", "<script language='JavaScript'>alert('Data Updated Sucessfully..!!!');</script>", false);
                return;
            }
        }
    }
   
}