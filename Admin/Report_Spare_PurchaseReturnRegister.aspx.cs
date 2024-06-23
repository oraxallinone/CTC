using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AutoMobileModel;
using System.Globalization;
using System.Data;
using System.Drawing;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Text;
using System.IO;
public partial class admin_StockMaster : System.Web.UI.Page
{
    AutoMobileEntities db = new AutoMobileEntities();
    public string uname;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            txt_FromDate.Text = SmitaClass.IndianTime().ToString("dd/MM/yyyy");
            txt_ToDate.Text = SmitaClass.IndianTime().AddDays(1).ToString("dd/MM/yyyy");
            FillGrid();
        }
    }


    decimal tot1 = 0;
    private void FillGrid()
    {

        string Branch = Session["Branch"].ToString();
        var v = from c in db.AME_Spare_PurchaseReturn.ToList()
                join d in db.AME_Master_Supplier on c.Sp_SupplierCode equals d.Ms_code
                where c.Branch_Name == Branch
                    && c.Purchase_ReturnDate >= Convert.ToDateTime(txt_FromDate.Text, SmitaClass.dateformat())
                    && c.Purchase_ReturnDate <= Convert.ToDateTime(txt_ToDate.Text, SmitaClass.dateformat())
                select new
                {
                    c.Itm_PartDescrption,
                    c.Itm_Partno,
                    c.Purchase_ReturnDate,
                    c.Sp_InvoiceNo,
                    c.Sp_SupplierCode,
                    c.Ss_Amount,
                    c.Ss_Discount,
                    c.Ss_Quantity,
                    c.Ss_Rate,
                    c.Ss_ReturnQuantity,
                    c.Ss_TaxAmont,
                    c.Ss_Total,
                    c.Ss_Vat,
                    c.Status,
                    d.Ms_Name,
                    d.Ms_Tin
                };
        if (v.Count() > 0)
        {
        GridView1.DataSource = v.ToList();
        GridView1.DataBind();

        var zzz = from c in db.AME_Branch_Creation.ToList() where c.Branch_Name == Session["Branch"].ToString() select c;
        lbl_BranchAddress.Text = zzz.First().Branch_Address + ", " + zzz.First().Branch_PhoneNo;
        lbltin.Text = zzz.First().Branch_TIN;
        lbl_from.Text = txt_FromDate.Text;
        lbl_to.Text = txt_ToDate.Text;
        Panel1.Visible = true;
        }
        else
        {
            ScriptManager.RegisterStartupScript(this.Page, typeof(string), "", "alert('" + txt_FromDate.Text + "  To  " + txt_ToDate.Text + "  No DATA fOUND..!!');", true);
            Panel1.Visible = false;
            txt_FromDate.Focus();
            return;
        }
        foreach (GridViewRow gr in GridView1.Rows)
        {
            Label Sales_TotalAmount = (Label)gr.FindControl("lblprdamnt11");

            decimal TotAmt = Convert.ToDecimal(Sales_TotalAmount.Text);

            tot1 = tot1 + TotAmt;

            Label LabelF1 = (Label)GridView1.FooterRow.FindControl("LabelF1");
            LabelF1.Text = Convert.ToString(SmitaClass.SignificantTruncate(tot1, 2));
        }
    }



    protected void btn_Show_Click(object sender, EventArgs e)
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
        FillGrid();
    }
    protected void btn_excel_Click(object sender, EventArgs e)
    {
         if (GridView1.Rows.Count <= 0)
        {
            ScriptManager.RegisterStartupScript(this.Page, typeof(string), "", "alert('There Is No Data To Download..!!');", true);

            return;
        }
        else
        {

            string Branch = Session["Branch"].ToString();
            string attachment = "attachment; filename=" + lbl_InvoiceType.Text + "(" + Branch + ")" + "(" + txt_FromDate.Text + " " + "To" + " " + txt_ToDate.Text + ")" + ".xls";
            Response.ClearContent();
            Response.AddHeader("content-disposition", attachment);
            Response.ContentType = "application/ms-excel";
            StringWriter sw = new StringWriter();
            HtmlTextWriter htw = new HtmlTextWriter(sw);
            HtmlForm frm = new HtmlForm();
            GridView1.Parent.Controls.Add(frm);
            frm.Attributes["runat"] = "server";
            frm.Controls.Add(GridView1);
            frm.RenderControl(htw);
            Response.Write(sw.ToString());
            Response.End();
        }
    
    
    }
    
}