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
        DateTime fromDate = Convert.ToDateTime(txt_FromDate.Text,SmitaClass.dateformat());
        DateTime toDate = Convert.ToDateTime(txt_ToDate.Text, SmitaClass.dateformat());
        var query = (from c in db.AME_Vehicle_SaleEntryDetails
                    join d in db.AME_Master_Customer on c.Vq_PartyName equals  d.Mc_Id
                     where c.Vs_Billdate >= fromDate && c.Vs_Billdate <= toDate && c.Branch_Name == Branch
                     && c.Vq_Status=="SE"
                    select new
                    {
                        d.Mc_Name,
                        c.Vs_Billno,
                        c.Vs_Billdate,
                         d.Mc_Address,
                         d.Mc_Mobileno,
                        c.Vs_InvType,
                        c.Vs_TinNo,
                        c.Vs_Sino

                    }).ToList();
        if (Convert.ToInt32(query.Count()) > 0)
        {
            GridView1.DataSource = query.ToList();
            GridView1.DataBind();

            foreach (GridViewRow gr in GridView1.Rows)
            {
                ImageButton edit = (ImageButton)gr.FindControl("imgbtnedit");
                ImageButton del = (ImageButton)gr.FindControl("imgbtndelete");

                if (Session["saletype"] != null)
                {
                    edit.Visible = false;
                    del.Visible = false;
                }
            }
        }
        else
        {
            ScriptManager.RegisterStartupScript(this.Page, typeof(string), "", "alert('"+txt_FromDate.Text+"  To  "+txt_ToDate.Text+"  No Sales Are Entry..!!');", true);
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


 
  
    protected void imgbtnview_Click(object sender, ImageClickEventArgs e)
    {
        ImageButton imgview = (ImageButton)sender;
        string sino = Convert.ToString(imgview.ToolTip);
        Response.Redirect("Vehicle_SaleEntry.aspx?id=" + sino + "&Type=" + "View");
    }
   
    protected void imgbtndelete_Click(object sender, ImageClickEventArgs e)
    {
        ImageButton imgdelete = (ImageButton)sender;
        string sino = Convert.ToString(imgdelete.ToolTip);
        string branchname = Session["Branch"].ToString();
        AME_Vehicle_SaleEntry vq = db.AME_Vehicle_SaleEntry.First(t => t.Vs_Billno == sino && t.Branch_Name == branchname);
        vq.Status = "SEC";
        AME_Vehicle_SaleEntryDetails vqs = db.AME_Vehicle_SaleEntryDetails.First(t => t.Vs_Billno == sino && t.Branch_Name == branchname);
        vqs.Vq_Status = "SEC";
        db.SaveChanges();
        var cancelstock = (from c in db.AME_Vehicle_SaleEntry
                           join d in db.AME_Vehicle_PurchaseEntry on c.Vp_Chassisno equals d.Vp_Chassisno
                           where c.Branch_Name == d.Branch_Name && c.Mv_VehicleType == d.Mv_VehicleType && c.Mv_ModelName == d.Mv_ModelName
                           select new

                           {
                               squantity=c.Vse_Quantity,
                               pquantity=d.Vp_NetQuantity,
                               branchname=c.Branch_Name,
                               vehicletype=c.Mv_VehicleType,
                               modelname=c.Mv_ModelName,
                               chessisno=c.Vp_Chassisno,
                           }
                           ).First();
        string branch = cancelstock.branchname;
        string vtype = cancelstock.vehicletype;
        int mname =Convert.ToInt32(cancelstock.modelname);
        string chesssisno=cancelstock.chessisno;
        decimal quantity=cancelstock.squantity;
        AME_Vehicle_PurchaseEntry vpe = db.AME_Vehicle_PurchaseEntry.First(t => t.Branch_Name == branch && t.Mv_VehicleType == vtype && t.Mv_ModelName == mname && t.Vp_Chassisno == chesssisno);
        vpe.Vp_NetQuantity = quantity;
        db.SaveChanges();
       

        ScriptManager.RegisterStartupScript(this.Page, typeof(string), "", "alert('Bill Cancel Sucessfully..!!');", true);
        fillgrid();

      
    }
    protected void imgbtn_print_Click(object sender, ImageClickEventArgs e)
    {
        ImageButton img = (ImageButton)sender;
        string BillNo = Convert.ToString(img.ToolTip);
        Response.Redirect("Vehicle_SalesInvoicePrint.aspx?id=" + BillNo);
    }
    protected void imgbtnedit_Click(object sender, ImageClickEventArgs e)
    {
        ImageButton imgedit = (ImageButton)sender;
        string sino = Convert.ToString(imgedit.ToolTip);
        Response.Redirect("Vehicle_SaleEntry.aspx?id=" + sino + "&Type=" + "Edit");
    }
}
