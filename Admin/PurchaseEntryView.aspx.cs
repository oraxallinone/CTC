using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AutoMobileModel;
using System.Globalization;
public partial class Admin_PurchaseEntryView : System.Web.UI.Page
{
    AutoMobileEntities db = new AutoMobileEntities();
    public string uname;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString["id"] == null || Request.QueryString["year"] == null)
        {
            Response.Redirect("AccessDenied.aspx");
        }
        if (!IsPostBack)
        {
            FillSupplier();

            string sino = Request.QueryString["id"];
            //string VNo = Request.QueryString["No"];
            string year = Request.QueryString["year"];
            filldata(sino, year);
            SetTextBoxReadOnly<TextBox>(Master.FindControl("form1"), true);
            ddl_BSuplier.Enabled = false;
        }
    }

    private void SetTextBoxReadOnly<T>(Control parent, bool readOnly) where T : TextBox
    {
        foreach (var tb in parent.Controls.OfType<T>())
            tb.ReadOnly = readOnly;

        foreach (Control c in parent.Controls)
            SetTextBoxReadOnly<T>(c, readOnly);
    }
    //if purchaseentry stock is transfer its staus is false otherwise true
    private void FillSupplier()
    {
        var v = from c in db.AME_Master_Supplier.ToList()
                where c.Ms_Status = true && c.Branch_Name == Session["Branch"].ToString()
                select new
                {
                    Su_Name = c.Ms_Name,
                    Su_Code = c.Ms_code
                };
        ddl_BSuplier.DataSource = v.ToList();
        ddl_BSuplier.DataTextField = "Su_Name";
        ddl_BSuplier.DataValueField = "Su_Code";
        ddl_BSuplier.DataBind();
        ddl_BSuplier.Items.Insert(0, "--Select One--");
    }

    public void filldata(string sino, string year)
    {
        //if purchaseentry stock is transfer its staus is false otherwise true
       // int id = Convert.ToInt32(sino);
        int VouNo = Convert.ToInt32(sino);
        //string year = Request.QueryString["year"];
        var v = from c in db.AME_Spare_PurchaseEntryBillDetails.ToList().Where(t => t.Sp_VoucherNo == VouNo && t.Branch_Name == Session["Branch"].ToString() && t.Status == true && t.jc_year == year) select c;
        txt_BInvoiceDate.Text = Convert.ToDateTime(v.First().Sp_InvoiceDate).ToString("dd/MM/yyyy");
        txt_BRcvDate.Text = Convert.ToDateTime(v.First().Sp_ReceiptDate).ToString("dd/MM/yyyy");
        txt_BinvoiceNo.Text = v.First().Sp_InvoiceNo;
        txt_BVoucherNo.Text = Convert.ToString(v.First().Sp_VoucherNo);
        ddl_BSuplier.SelectedValue = v.First().Sp_SupplierCode;
        txt_BOrderNo.Text = Convert.ToString(v.First().Sp_OrderNo);
        txt_BLrNo.Text = Convert.ToString(v.First().Sp_LrNo);
        txt_BOrderDate.Text = Convert.ToDateTime(v.First().Sp_OrderDate).ToString("dd/MM/yyyy");
        txt_BLrDate.Text = Convert.ToDateTime(v.First().Sp_LrDate).ToString("dd/MM/yyyy");


        txt_AGrossAmount.Text = Convert.ToString(v.First().Sp_GrossAmount);
        txt_ADiscountAmount.Text = Convert.ToString(v.First().Sp_Discount);
        txt_ANetAmount.Text = Convert.ToString(v.First().Sp_NetAmount);
        txt_AVatAmount.Text = Convert.ToString(v.First().Sp_VatAmount);
        txt_ATotal.Text = Convert.ToString(v.First().Sp_TotalAmount);
        txt_APackagingAmt.Text = Convert.ToString(v.First().Sp_PackagingAmount);
        txt_AOtherAmount.Text = Convert.ToString(v.First().Sp_OtherAmount);
        txt_ABillAmount.Text = Convert.ToString(v.First().Sp_BillAmount);

        var details = (from c in db.AME_Spare_PurchaseEntry.ToList()
                       where c.Sp_VoucherNo == VouNo && c.Ss_Status == "PE" && c.Branch_Name == Session["Branch"].ToString() && c.Status == true && c.jc_year == year
                       select c);

        GridView2.DataSource = details.ToList();
        GridView2.DataBind();

    }
}