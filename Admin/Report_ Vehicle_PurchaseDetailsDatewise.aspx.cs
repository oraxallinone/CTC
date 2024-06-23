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
            txt_FromDate.Text = SmitaClass.IndianTime().ToString("dd/MM/yyyy");
            txt_ToDate.Text = SmitaClass.IndianTime().ToString("dd/MM/yyyy");
            fillgrid();
        }
    }



    public void fillgrid()
    {
        string Branch = Session["Branch"].ToString();
        DateTime fromDate = Convert.ToDateTime(txt_FromDate.Text, SmitaClass.dateformat());
        DateTime toDate = Convert.ToDateTime(txt_ToDate.Text, SmitaClass.dateformat());
        var query = (from c in db.AME_Vehicle_PurchaseEntryDetails
                    join d in db.AME_Master_Supplier on c.Vp_Supplier equals d.Ms_Id
                    where c.Vp_Billdate >= fromDate && c.Vp_Billdate <= toDate && c.Branch_Name == Branch
                    select new
                    {
                        d.Ms_Name,
                        c.Vp_Billdate,
                        c.Vp_Address,
                        c.Vp_Invoiceno,
                        c.Vp_Phno,
                        c.Vpd_Id

                    }).ToList();
       
        if (Convert.ToInt32(query.Count) > 0)
        {
            GridView1.DataSource = query.ToList();
            GridView1.DataBind();
            var zzz = from c in db.AME_Branch_Creation.ToList() where c.Branch_Name == Session["Branch"].ToString() select c;
            lbl_BranchAddress.Text = zzz.First().Branch_Address + ", " + zzz.First().Branch_PhoneNo;
            lbltinno.Text = zzz.First().Branch_TIN;
            lbl_from.Text = txt_FromDate.Text;
            lbl_to.Text = txt_ToDate.Text;
            Panel1.Visible = true;
        }
        else
        {
            ScriptManager.RegisterStartupScript(this.Page, typeof(string), "", "alert('" + txt_FromDate.Text + "  To  " + txt_ToDate.Text + "  No Purchase Are Entry..!!');", true);
            txt_FromDate.Focus();
            return;
        }
    }

    protected void btn_Show_Click(object sender, EventArgs e)
    {
        try
        {
            if (txt_FromDate.Text == "")
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(string), "", "alert('From Date SHOULD NOT BE BLANK...!!');", true);
                txt_FromDate.Focus();
                return;
            }
            if (txt_ToDate.Text == "")
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(string), "", "alert('To Date SHOULD NOT BE BLANK...!!');", true);
                txt_ToDate.Focus();
                return;
            }
            
            if (Convert.ToDateTime(txt_ToDate.Text, SmitaClass.dateformat()) < Convert.ToDateTime(txt_FromDate.Text, SmitaClass.dateformat()))
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(string), "", "alert('To Date Must Be Greater Than From Date..!!');", true);
                txt_ToDate.Focus();
                return;
            }
            string[] formats = { "dd/MM/yyyy", "d/M/yyyy", "dd/M/yyyy", "d/MM/yyyy", "dd/MMM/yyyy","dd-MM-yyyy" };
            DateTime expectedDate;
            if (!DateTime.TryParseExact(txt_FromDate.Text, formats, new CultureInfo("en-US"), DateTimeStyles.None, out expectedDate))
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(string), "", "alert('ENTER VALID DATE (DD/MMM/YYYY)..!!');", true);
                txt_FromDate.Focus();
                return;
            }
            if (!DateTime.TryParseExact(txt_ToDate.Text, formats, new CultureInfo("en-US"), DateTimeStyles.None, out expectedDate))
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(string), "", "alert('ENTER VALID DATE (DD/MMM/YYYY)..!!');", true);
                txt_ToDate.Focus();
                return;
            }


            fillgrid();

        }
        catch
        {

        }
    }


 
    protected void imgbtnedit_Click(object sender, ImageClickEventArgs e)
    {
        ImageButton imgedit = (ImageButton)sender;
        int sino = Convert.ToInt32(imgedit.ToolTip);
        Response.Redirect("Vehicle_PurchaseEntryEdit.aspx?id=" + sino + "&Type=" + "Edit");
    }
    protected void imgbtnview_Click(object sender, ImageClickEventArgs e)
    {
        ImageButton imgview = (ImageButton)sender;
        int sino = Convert.ToInt32(imgview.ToolTip);
        Response.Redirect("Vehicle_PurchaseEntryEdit.aspx?id=" + sino + "&Type=" + "View");
    }
   
    protected void imgbtndelete_Click(object sender, ImageClickEventArgs e)
    {
        ImageButton imgdelete = (ImageButton)sender;
        int sino = Convert.ToInt32(imgdelete.ToolTip);
        string branchname = Session["Branch"].ToString();
        AME_Vehicle_PurchaseEntryDetails vq = db.AME_Vehicle_PurchaseEntryDetails.First(t => t.Vpd_Id == sino && t.Branch_Name == branchname);
        db.DeleteObject(vq);

        db.AME_Vehicle_PurchaseEntry.Where(t => t.Vpd_Id == sino && t.Branch_Name == branchname).ToList().ForEach(db.AME_Vehicle_PurchaseEntry.DeleteObject);
        db.SaveChanges();

        ScriptManager.RegisterStartupScript(this.Page, typeof(string), "", "alert('Data Deleted Sucessfully..!!');", true);
        fillgrid();

      
    }
    
}
