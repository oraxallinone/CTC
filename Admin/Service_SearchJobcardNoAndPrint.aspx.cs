using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AutoMobileModel;
using System.Globalization;
using System.Data;
public partial class Report_ProjectExpensesDetailsCodeDatewise : System.Web.UI.Page
{
    AutoMobileEntities db = new AutoMobileEntities();
    public string uname;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {

        }
    }

  
    protected void btn_Show_Click(object sender, EventArgs e)
    {

        try
        {

             
            if (txt_sino.Text == "")
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(string), "", "alert('Job Card  No. SHOULD NOT BE BLANK...!!');", true);
                txt_sino.Focus();
                return;
            }
          int sino= Convert.ToInt32(txt_sino.Text);
             string branchname = Session["Branch"].ToString();
             var quotationdetails = from c in db.AME_Service_JobCardEntry.Where(t => t.JC_No == sino && t.Branch_Name == branchname && t.Ms_Status != "STOP" && t.JC_year == txt_year.Text) select c;
          if (Convert.ToInt32(quotationdetails.Count()) > 0)
          {
              
              Session["sino"] = txt_sino.Text;
              Session["Year"] = txt_year.Text;

              if (branchname == "Cuttack")
              {
                  Response.Redirect("Service_Print_Jobcard.aspx");
              }
              else if (branchname == "Paradeep")
              {
                  Response.Redirect("Service_Print_Jobcard_Anugul.aspx");
              }
              else if (branchname == "Berhampur")
              {
                  Response.Redirect("Service_Print_Jobcard_Berhampur.aspx");
              }
              else
              {
                  Response.Redirect("Service_Print_Jobcard_Phulnakhara.aspx");
              }

             
          }
          else
          {
              ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "MessagePopUp", "<script language='JavaScript'>alert('Invalid Si no..!!!');</script>", false);
              txt_sino.Focus();
              txt_sino.Text = "";
              return;
          }

        }
        catch
        {

        }
    }


  
}
