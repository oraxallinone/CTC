using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AutoMobileModel;
using System.Globalization;
using System.Data;

public partial class Admin_Spare_SalesEntryList_Invoice : System.Web.UI.Page
{
    AutoMobileEntities db = new AutoMobileEntities();
    public string uname;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
        }
    }
    [System.Web.Services.WebMethod]
    public static string[] GetInvoice(string prefixText, int count)
    {
        string branch = HttpContext.Current.Session["Branch"].ToString();
        AutoMobileEntities db = new AutoMobileEntities();
        return db.AME_Spare_SalesEntryBillDetails.Where(n => n.Sp_InvoiceNo.Contains(prefixText) && n.Branch_Name == branch).OrderBy(n => n.Sp_InvoiceNo).Select(n => n.Sp_InvoiceNo).Distinct().Take(count).ToArray();


    }


    [System.Web.Services.WebMethod]
    public static string[] Getyear(string prefixText, int count)
    {

        AutoMobileEntities db = new AutoMobileEntities();
        return db.AME_FinacialYear.Where(n => n.finacialyear.Contains(prefixText)).OrderBy(n => n.finacialyear).Select(n => n.finacialyear).Distinct().Take(count).ToArray();
    }

    public void FillGrid()
    {
        string Branch = Session["Branch"].ToString();
        string year = txt_year.Text.Trim();
        string param = "@Invoice,@Branch,@year";
        string paramvalue = txt_invoice.Text.Trim() + "," + Branch + "," + year;

        DataTable dtr = smitaDbAccess.SPReturnDataTable("sp_Spare_SalesList_Invoice", param, paramvalue);
        if (dtr.Rows.Count > 0)
        {
            GridView1.DataSource = dtr;
            GridView1.DataBind();
            decimal tot1 = 0;
            foreach (GridViewRow gr in GridView1.Rows)
            {
                ImageButton edit = (ImageButton)gr.FindControl("imgbtnedit");

                if (Session["saletype"] != null)
                {
                    edit.Visible = false;
                }

                Label lblamount0 = (Label)gr.FindControl("lbl008");

                decimal gamnt = Convert.ToDecimal(lblamount0.Text);

                tot1 = tot1 + gamnt;

                Label lbl_fgamnt = (Label)GridView1.FooterRow.FindControl("lbl_fgamnt");
                lbl_fgamnt.Text = tot1.ToString("0.00");
            }
        }
        else
        {
            ScriptManager.RegisterStartupScript(this.Page, typeof(string), "", "alert('" + txt_invoice.Text + "  No Sales Are Entry..!!');", true);
            txt_invoice.Focus();
            return;
        }

    }
    protected void btn_Show_Click(object sender, EventArgs e)
    {

        if (txt_year.Text == "")
        {
            ScriptManager.RegisterStartupScript(this.Page, typeof(string), "", "alert('Finacial Year Should Not Be Blanck..!!');", true);
            txt_year.Focus();
            return;

        }
        try
        {
            FillGrid();

        }
        catch
        {

        }
    }



    protected void imgbtnedit_Click(object sender, ImageClickEventArgs e)
    {
        ImageButton imgedit = (ImageButton)sender;
        int sino = Convert.ToInt32(imgedit.ToolTip);
        Response.Redirect("Spare_SalesEntryEdit.aspx?id=" + sino + "&No=" + imgedit.CommandArgument +"&year="+ txt_year.Text.Trim());
    }
    protected void imgbtnview_Click(object sender, ImageClickEventArgs e)
    {
        ImageButton imgview = (ImageButton)sender;
        int sino = Convert.ToInt32(imgview.ToolTip);
        Response.Redirect("Spare_SalesEntryView.aspx?id=" + sino + "&No=" + imgview.CommandArgument + "&year=" + txt_year.Text.Trim());
    }

    //protected void imgbtndelete_Click(object sender, ImageClickEventArgs e)
    //{
    //    ImageButton imgdelete = (ImageButton)sender;
    //    int sino = Convert.ToInt32(imgdelete.ToolTip);
    //    string No = Convert.ToString(imgdelete.CommandArgument);

    //    AME_Spare_SalesEntryBillDetails vq = db.AME_Spare_SalesEntryBillDetails.ToList().First(t => t.Sp_Id == sino);
    //    db.DeleteObject(vq);

    //    db.AME_Spare_SalesEntry.ToList().Where(t => t.Sp_InvoiceNo == No && t.Branch_Name == Session["Branch"].ToString()).ToList().ForEach(db.AME_Spare_SalesEntry.DeleteObject);
    //    db.SaveChanges();

    //    ScriptManager.RegisterStartupScript(this.Page, typeof(string), "", "alert('Invoice Deleted Sucessfully..!!');", true);
    //    FillGrid();
    //}
    protected void imgbtn_print_Click(object sender, ImageClickEventArgs e)
    {
       // ImageButton imgPrint = (ImageButton)sender;
       // int sino = Convert.ToInt32(imgPrint.ToolTip);
       //// Response.Redirect("Spare_SalesPrint.aspx?id=" + sino + "&No=" + imgPrint.CommandArgument);
       // Response.Redirect("Spare_sale_print1.aspx?id=" + sino + "&No=" + imgPrint.CommandArgument + "&year=" + txt_year.Text.Trim());



        
        ImageButton imgPrint = (ImageButton)sender;
        int sino = Convert.ToInt32(imgPrint.ToolTip);

        var check = from c in db.AME_Spare_SalesEntryBillDetails.Where(t => t.Sp_Id == sino) select c;

        if (check.First().gstflag == false)
        {


            Response.Redirect("Counter_SalePrint.aspx?id=" + sino + "&No=" + imgPrint.CommandArgument + "&year=" + txt_year.Text.Trim());
        
        
        }

        else
        {




            Response.Redirect("Spare_sale_print1.aspx?id=" + sino + "&No=" + imgPrint.CommandArgument + "&year=" + txt_year.Text.Trim());
        }
    }
    
}