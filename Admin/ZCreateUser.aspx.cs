using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AutoMobileModel;
using System.Globalization;

public partial class Admin_CreateUser : System.Web.UI.Page
{
    AutoMobileEntities db = new AutoMobileEntities();
    public string uname;
    protected void Page_Load(object sender, EventArgs e)
    {

        //if (Session["uname"] == null)
        //{
        //    Response.Write("<script>alert('Your Session Time is Expired..!! Login to continue..!!')</script>");
        //    Response.Redirect("AccessDenied.aspx");
        //}
        if (!IsPostBack)
        {
            fillBranch();
            fillUsertype();
        }
      
    }

    public void fillBranch()
    {
        var v = from c in db.AME_Branch_Creation.OrderBy(t => t.Branch_Id) 
                select new {
                    Sl_No = c.Branch_Id,
                    branchtype = c.Branch_Name };
        ddl_branch.DataSource = v.ToList();
        ddl_branch.DataValueField = "Sl_No";
        ddl_branch.DataTextField = "branchtype";
        ddl_branch.DataBind();
      
        ddl_branch.Items.Insert(0, "--- select ---");
    }
    public void fillUsertype()
    {
        var v = from c in db.AME_UserTypes.OrderBy(t => t.UserType_Id)
                select new
                {
                    Sl_No = c.UserType_Id,
                    user = c.User_Type
                };
        ddl_usertype.DataSource = v.ToList();
        ddl_usertype.DataValueField = "Sl_No";
        ddl_usertype.DataTextField = "user";
        ddl_usertype.DataBind();
        //ddl_usertype.Items.RemoveAt(0);
        ddl_usertype.Items.Insert(0, "--- select ---");
    }
    protected void btn_assign_Click(object sender, EventArgs e)
    {
        try
        {
            if (ddl_branch.SelectedIndex == 0)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "MessagePopUp", "<script language='JavaScript'>alert('Select BranchName..!!!');</script>", false);
                ddl_branch.Focus();
                return;
            }
            if (ddl_usertype.SelectedIndex == 0)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "MessagePopUp", "<script language='JavaScript'>alert('Select User Type..!!!');</script>", false);
                ddl_usertype.Focus();
                return;
            }

            if (txt_userName.Text == "")
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "MessagePopUp", "<script language='JavaScript'>alert('User Name SHOULD NOT BE BLANK..!!!');</script>", false);
                txt_userName.Focus();
                return;
            }

            if (txt_emailId.Text == "")
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "MessagePopUp", "<script language='JavaScript'>alert('User Email Id SHOULD NOT BE BLANK..!!!');</script>", false);
                txt_emailId.Focus();
                return;
            }

            if (txt_userId.Text == "")
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "MessagePopUp", "<script language='JavaScript'>alert('User ID SHOULD NOT BE BLANK..!!!');</script>", false);
                txt_userId.Focus();
                return;
            }
            if (txt_pwd.Text == "")
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "MessagePopUp", "<script language='JavaScript'>alert('Password SHOULD NOT BE BLANK..!!!');</script>", false);
                txt_pwd.Focus();
                return;
            }
            if (txt_conpwd.Text == "")
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "MessagePopUp", "<script language='JavaScript'>alert('Confirm Password SHOULD NOT BE BLANK..!!!');</script>", false);
                txt_conpwd.Focus();
                return;
            }
            if (txt_conpwd.Text != txt_pwd.Text)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "MessagePopUp", "<script language='JavaScript'>alert('Confirm Password and Password SHOULD BE Same..!!!');</script>", false);
                txt_conpwd.Focus();
                return;
            }

            var v = from c in db.AME_Users.Where(t => t.User_Id == txt_userId.Text) select c;
            if (Convert.ToInt32(v.Count()) > 0)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "MessagePopUp", "<script language='JavaScript'>alert('This User Id already Exist..!! Try Different..!!');</script>", false);
                txt_userId.Focus();
                return;
            }
            //if (Session["uname"] != null)
            //{
            //    uname = Session["uname"].ToString();
            //}
            //else
            //{
            //    uname = Session["Employee"].ToString();
            //}


            AME_Users ua = new AME_Users();
            ua.Branch_Name = ddl_branch.SelectedItem.Text;
            ua.User_Type = ddl_usertype.SelectedItem.Text;
            ua.User_Name = txt_userName.Text;
            ua.Email_Id = txt_emailId.Text;
            ua.User_Id = txt_userId.Text;
            ua.Password = txt_pwd.Text;
            ua.Old_Password = "smita";
            ua.Status = true;
            ua.Permission = Convert.ToInt32(ddl_usertype.SelectedValue);
            ua.Created_By = "SAdmin";
            ua.Created_Date = SmitaClass.IndianTime();
            db.AddToAME_Users(ua);
            db.SaveChanges();

            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "MessagePopUp", "<script language='JavaScript'>alert('USER CREATED SUCCESSFULLY..!!!');</script>", false);
            Clear cl = new Clear();
            cl.Clear_All(this);
            
        }
        catch
        {

        }
    }
    protected void btn_cancel_Click(object sender, EventArgs e)
    {
        Clear cl = new Clear();
        cl.Clear_All(this);
        
    }
 
}