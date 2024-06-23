using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AutoMobileModel;

public partial class sj1_Default : System.Web.UI.Page
{
    AutoMobileEntities db = new AutoMobileEntities();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            txt_UserId.Focus();
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
            var v = from c in db.AME_Login.Where(t => t.Lg_UserId == txt_UserId.Text && t.Lg_Password == txt_Password.Text.Trim())
                    select new
                    {
                        userid = c.Lg_UserId,
                        userType = c.Lg_UserType
                    };


            int id = v.Count();
            if (id > 0)
            {

                if (v.Single().userType == "SAdmin")
                {
                    AME_User_LoginDetails uld = new AME_User_LoginDetails();
                    uld.L_User_Id = txt_UserId.Text;
                    uld.L_lgnTime = SmitaClass.IndianTime();//*  SmitaClass *//
                    db.AddToAME_User_LoginDetails(uld);
                    db.SaveChanges();

                    Session["SAdmin"] = txt_UserId.Text;
                    Session["Usertype"] = v.First().userType;

                    Session.Timeout = 500;//* After 500 minutes (which is 8 hours and 20 minutes) of inactivity *//

                    Response.Redirect("SuperAdmin.aspx");//*  *//
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