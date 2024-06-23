using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AutoMobileModel;

public partial class Branch_Login : System.Web.UI.Page
{
    AutoMobileEntities db = new AutoMobileEntities();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["SAdmin"] == null)
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
            string branch=Session["Branch"].ToString();
            var v = from c in db.AME_Users.Where(t => t.User_Id == txt_UserId.Text && t.Password == txt_Password.Text.Trim() && t.Branch_Name == branch)
                    select new
                    {
                        userName = c.User_Name,
                        userid = c.User_Id,
                        permission = c.Permission,
                        userType = c.User_Type,
                        branchnm = c.Branch_Name,
                    };

          
            int id = v.Count();
           
            if (id > 0)
            {
                if (Convert.ToInt32(v.Single().permission) > 0)
                {
                    if (v.Single().userType == "Admin" || v.Single().userType == "User" )
                    {
                        AME_User_LoginDetails uld = new AME_User_LoginDetails();
                        uld.L_User_Id = txt_UserId.Text;
                        uld.L_lgnTime = SmitaClass.IndianTime();
                        db.AddToAME_User_LoginDetails(uld);
                        db.SaveChanges();

                        MLogin.CallSession(txt_UserId.Text, v.First().branchnm.ToString(), v.First().userType.ToString(), v.First().userName.ToString());

                        //HttpCookie UidCookies = new HttpCookie("Uid");
                        //UidCookies.Value = txt_UserId.Text;
                        //UidCookies.Expires = DateTime.Now.AddHours(1);
                        //Response.Cookies.Add(UidCookies);
                        Session["Branch"] = v.First().branchnm;
                        Session["Uname"]=v.First().userName;
                        Session["UType"] = v.First().userType;

                        Session.Timeout = 500;
                        if (Session["UType"].ToString() == "User")
                        {
                            Session["Uname"] = v.First().userName;
                            Session["UType"] = v.First().userType;
                            Session["id"] = v.First().userid;
                            Session.Timeout = 500;
                            Response.Redirect("Sale_Service_Login.aspx");
                        }
                        else
                        {
                            Session["Uname"] = v.First().userName;
                            Session["UType"] = "Admin";
                            Session.Timeout = 500;
                            Response.Redirect("~/Admin/Home.aspx");
                        }
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "MessagePopUp", "<script language='JavaScript'>alert('You Do not Have Permission...!! Contact to System Administrator');</script>", false);
                        txt_UserId.Focus();
                        return;
                    }
                }

                else
                {
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "MessagePopUp", "<script language='JavaScript'>alert('You Do not Have Permission...!! Contact to System Administrator');</script>", false);
                    txt_UserId.Focus();
                    return;
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