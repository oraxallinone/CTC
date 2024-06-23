using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AutoMobileModel;

public partial class Sale_Service_Login : System.Web.UI.Page
{
    AutoMobileEntities db = new AutoMobileEntities();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["SAdmin"] == null && Session["Branch"]==null)
        {
            Response.Redirect("Login.aspx");
        }
        if (!IsPostBack)
        {
            string branch = Session["Branch"].ToString();
            lbl_brnch.Text = branch;
        }
    }
    protected void btn_Login_Click(object sender, EventArgs e)
    {
        try
        {
            if (txt_UserId.Text == "")
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "MessagePopUp", "<script language='JavaScript'>alert('User Id Should Not Be Blank...!!'); </script>", false);

                txt_UserId.Focus();
                return;
            }
            if (txt_Password.Text == "")
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "MessagePopUp", "<script language='JavaScript'>alert('Password Should Not Be Blank...!!'); </script>", false);

                txt_Password.Focus();
                return;
            }
            string branch = Session["Branch"].ToString();
            var v = from c in db.AME_UserTypes.ToList().Where(t => t.User_Id == txt_UserId.Text && t.User_Password == txt_Password.Text.Trim() )
                    select new
                    {
                        userName = c.User_Type,
                        userid = c.User_Id,
                        permission = c.User_Permission,
                        userType = c.User_Type
                    };


            int id = v.Count();

            if (id > 0)
            {
                if (Convert.ToInt32(v.Single().permission) ==2 )
                {
                    Session["saletype"] = v.First().userType;
                    Session.Timeout = 500;
                        Response.Redirect("~/Admin/Home.aspx");
                        
                     
                }

                else if (Convert.ToInt32(v.Single().permission) == 3)
                {
                    Session["saletype"] = v.First().userType;
                    Session.Timeout = 500;
                    Response.Redirect("~/Admin/Home.aspx");
                   
                }
                
               
            }

            else
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "MessagePopUp", "<script language='JavaScript'>alert('User Id and Password Not Match..!!');</script>", false);
            }
        }
        catch
        {

        }
    }
}