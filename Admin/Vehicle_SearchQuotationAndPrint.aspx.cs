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
                ScriptManager.RegisterStartupScript(this.Page, typeof(string), "", "alert('Quotation Si No. SHOULD NOT BE BLANK...!!');", true);
                txt_sino.Focus();
                return;
            }
          int sino= Convert.ToInt32(txt_sino.Text);
             string branchname = Session["Branch"].ToString();
          var quotationdetails = from c in db.AME_Vehicle_Quotation.Where(t => t.Vq_Id == sino && t.Branch_Name==branchname) select c;
          if (Convert.ToInt32(quotationdetails.Count()) > 0)
          {
              Session["sino"] = txt_sino.Text;
              Response.Redirect("Vehicle_PrintQuotation.aspx");
          }
          else
          {
              ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "MessagePopUp", "<script language='JavaScript'>alert('Invalid Si no..!!!');</script>", false);
              txt_sino.Focus();
              return;
          }

        }
        catch
        {

        }
    }


 
  
   
   
}
