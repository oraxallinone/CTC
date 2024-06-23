using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AutoMobileModel;
using System.Globalization;

public partial class Admin_Spare_PurchaseEntry : System.Web.UI.Page
{
    AutoMobileEntities db = new AutoMobileEntities();
    public string uname;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString["id"] == null || Request.QueryString["No"] == null)
        {
            Response.Redirect("AccessDenied.aspx");
        }
        if (!IsPostBack)
        {
            string sino = Request.QueryString["id"];
            string VNo = Request.QueryString["No"];
            string year = Request.QueryString["year"];
            filldata(sino, VNo, year);
            SetTextBoxReadOnly<TextBox>(Master.FindControl("form1"), true);
            SetDropdownReadOnly<DropDownList>(Master.FindControl("form1"), false);
            
            txt_BVoucherNo.ReadOnly = true;
            txt_BVoucherNo.BackColor = System.Drawing.ColorTranslator.FromHtml("#FFFFFF");
            txt_BVoucherNo.BorderWidth = Unit.Pixel(0);
        }
    }

    private void SetTextBoxReadOnly<T>(Control parent, bool readOnly) where T : TextBox
    {
        foreach (var tb in parent.Controls.OfType<T>())
            tb.ReadOnly = readOnly;
        foreach (var tb in parent.Controls.OfType<T>())
            tb.BackColor = System.Drawing.ColorTranslator.FromHtml("#FFFFFF");
        foreach (var tb in parent.Controls.OfType<T>())
            tb.BorderWidth = Unit.Pixel(0);
        foreach (var tb in parent.Controls.OfType<T>())
            tb.CssClass = "";

        foreach (Control c in parent.Controls)
            SetTextBoxReadOnly<T>(c, readOnly);
    }
    private void SetDropdownReadOnly<T>(Control parent, bool readOnly) where T : DropDownList
    {
        foreach (var tb in parent.Controls.OfType<T>())
            tb.Enabled = readOnly;
        foreach (var tb in parent.Controls.OfType<T>())
            tb.BackColor = System.Drawing.ColorTranslator.FromHtml("#FFFFFF");
        foreach (var tb in parent.Controls.OfType<T>())
            tb.BorderWidth = Unit.Pixel(0);
        foreach (var tb in parent.Controls.OfType<T>())
            tb.CssClass = "";

        foreach (Control c in parent.Controls)
            SetDropdownReadOnly<T>(c, readOnly);
    }


    public void filldata(string sino, string VcNO , string year)
    {
        int id = Convert.ToInt32(sino);
        string VouNo = Convert.ToString(VcNO);
        string year1 = Request.QueryString["year"];

        var v = from c in db.AME_Spare_SalesEntryBillDetails.ToList().Where(t => t.Sp_Id == id && t.Sp_InvoiceNo == VouNo && t.Branch_Name == Session["Branch"].ToString() && t.jc_year==year) select c;
        txt_BVoucherNo.Text = Convert.ToString(v.First().Sp_InvoiceNo);
        txt_BDate.Text = Convert.ToDateTime(v.First().Sp_InvoiceDate).ToString("dd/MM/yyyy");
        ddl_BSaleBy.SelectedValue = Convert.ToString(v.First().Sp_SaleBy);
        ddl_BSaleType.SelectedValue = v.First().Sp_SaleType;
        txt_BChalanNo0.Text = v.First().Sp_ChalanNo;
        txt_BChallanDate.Text = Convert.ToDateTime(v.First().Sp_ChalanDate).ToString("dd/MM/yyyy");
        txt_BOrderNo.Text = Convert.ToString(v.First().Sp_OrderNo);
        txt_BOrderDate.Text = Convert.ToDateTime(v.First().Sp_InvoiceDate).ToString("dd/MM/yyyy");
        ddl_invtype.SelectedValue = Convert.ToString(v.First().Sp_InvoiceType);
        txt_BTinSrinNo.Text = v.First().Sp_Mc_Tin;
        txt_BName.Text = v.First().Sp_Mc_Name;

        txt_AGrossAmount.Text = Convert.ToString(v.First().Sp_GrossAmount);
        txt_ADiscountAmount.Text = Convert.ToString(v.First().Sp_Discount);
        txt_ANetAmount.Text = Convert.ToString(v.First().Sp_NetAmount);
        txt_AVatAmount.Text = Convert.ToString(v.First().Sp_VatAmount);
        txt_ATotal.Text = Convert.ToString(v.First().Sp_TotalAmount);
        txt_APackagingAmt.Text = Convert.ToString(v.First().Sp_PackagingAmount);
        txt_AOtherAmt.Text = Convert.ToString(v.First().Sp_OtherAmount);
        txt_AFinalAmount.Text = Convert.ToString(v.First().Sp_FinalAmount);

        var details = (from c in db.AME_Spare_SalesEntry.ToList()
                       where c.Sp_InvoiceNo == VouNo && c.Branch_Name == Session["Branch"].ToString()
                       && c.jc_year==year
                       select c);
        GridView2.DataSource = details.ToList();
        GridView2.DataBind();

    }

}