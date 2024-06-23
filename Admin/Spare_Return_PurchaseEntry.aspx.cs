using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AutoMobileModel;
using System.Globalization;
using System.Data;

public partial class Admin_Spare_PurchaseEntry123 : System.Web.UI.Page
{
    AutoMobileEntities db = new AutoMobileEntities();
    Clear cl = new Clear();
    public string uname;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString["id"] == null || Request.QueryString["No"] == null)
        {
            Response.Redirect("AccessDenied.aspx");
        }
        if (!IsPostBack)
        {
            FillSupplier();

            string sino = Request.QueryString["id"];
            string VNo = Request.QueryString["No"];
            string year = Request.QueryString["year"];
            filldata(sino, VNo , year);
            FillGrid();
            txt_BInvoiceDate.Text = Convert.ToDateTime(DateTime.Now).ToString("dd/MM/yyyy");
            txt_BLrDate.Text = Convert.ToDateTime(DateTime.Now).ToString("dd/MM/yyyy");
            txt_BRcvDate.Text = Convert.ToDateTime(DateTime.Now).ToString("dd/MM/yyyy");
            txt_BOrderDate.Text = Convert.ToDateTime(DateTime.Now).ToString("dd/MM/yyyy");
        }
    }

    [System.Web.Services.WebMethod]
    public static string[] GetPartNo(string prefixText, int count)
    {
        string branch = HttpContext.Current.Session["Branch"].ToString();
        AutoMobileEntities db = new AutoMobileEntities();
        return db.AME_Master_Item.Where(n => n.Itm_Partno.StartsWith(prefixText) && n.Branch_Name == branch).OrderBy(n => n.Itm_Partno).Select(n => n.Itm_Partno).Distinct().Take(count).ToArray();
    }

    [System.Web.Services.WebMethod]
    public static string[] GetPartDesc(string prefixText, int count)
    {
        string branch = HttpContext.Current.Session["Branch"].ToString();
        AutoMobileEntities db = new AutoMobileEntities();
        return db.AME_Master_Item.Where(n => n.Itm_PartDescrption.StartsWith(prefixText) && n.Branch_Name == branch).OrderBy(n => n.Itm_PartDescrption).Select(n => n.Itm_PartDescrption).Distinct().Take(count).ToArray();
    }

    private void FillSupplier()
    {
        var v = from c in db.AME_Master_Supplier.ToList()
                where c.Ms_Status = true && c.Branch_Name==Session["Branch"].ToString() 
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


    public void filldata(string sino, string VcNO , string year)
    {
        int id = Convert.ToInt32(sino);
        int VouNo = Convert.ToInt32(VcNO);
        string year1 = Request.QueryString["year"];
        var v = from c in db.AME_Spare_PurchaseEntryBillDetails.ToList().Where(t => t.Sp_Id == id && t.Sp_VoucherNo == VouNo && t.Branch_Name == Session["Branch"].ToString() && t.jc_year==year) select c;
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
                       where c.Sp_VoucherNo == VouNo && c.jc_year==year && c.Ss_Status == "PE" && c.Branch_Name == Session["Branch"].ToString()
                       select c);

        GridView2.DataSource = details.ToList();
        GridView2.DataBind();

    }
    protected void txt_PartNo_TextChanged(object sender, EventArgs e)
    {
        try
        {
            string branchname = Session["Branch"].ToString();
            var v = from k in db.AME_Master_Item.ToList()
                    where (k.Itm_Partno.Equals(txt_PartNo.Text) && k.Branch_Name==branchname)
                    select new
                    {
                        k.Itm_Partno,
                        k.Itm_PartDescrption,
                        k.Itm_SalePrice,
                        k.Itm_VatPercent
                    };

            txt_PartNo.Text = v.First().Itm_Partno;
            txt_PartDesc.Text = Convert.ToString(v.First().Itm_PartDescrption);
            txt_PartRate.Text = Convert.ToString(v.First().Itm_SalePrice);
            txt_PartVat.Text = Convert.ToString(v.First().Itm_VatPercent);
            txt_PartQuantity.Focus();
        }
        catch
        {
            txt_PartNo.Text = "";
            txt_PartDesc.Text = "";
            txt_PartRate.Text = "";
            txt_PartVat.Text = "";
            txt_PartQuantity.Focus();
        }
    }
    protected void txt_PartDesc_TextChanged(object sender, EventArgs e)
    {
        try
        {
            string branchname = Session["Branch"].ToString();
            var v = from k in db.AME_Master_Item.ToList()
                    where (k.Itm_PartDescrption.Equals(txt_PartDesc.Text) && k.Branch_Name == branchname)
                    select new
                    {
                        k.Itm_Partno,
                        k.Itm_PartDescrption,
                        k.Itm_SalePrice,
                        k.Itm_VatPercent
                    };

            txt_PartNo.Text = v.First().Itm_Partno;
            txt_PartDesc.Text = Convert.ToString(v.First().Itm_PartDescrption);
            txt_PartRate.Text = Convert.ToString(v.First().Itm_SalePrice);
            txt_PartVat.Text = Convert.ToString(v.First().Itm_VatPercent);
            txt_PartQuantity.Focus();
        }
        catch
        {
            txt_PartNo.Text = "";
            txt_PartDesc.Text = "";
            txt_PartRate.Text = "";
            txt_PartVat.Text = "";
            txt_PartQuantity.Focus();
        }
    }
    protected void btn_PartAdd_Click(object sender, EventArgs e)
    {
        if (txt_BVoucherNo.Text == "")
        {
            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "MessagePopUp", "<script language='JavaScript'>alert('Voucher Number Should Not Be Blank..!!'); </script>", false);
            txt_BVoucherNo.Focus();
            return;
        }
        if (ddl_BSuplier.SelectedIndex == 0)
        {
            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "MessagePopUp", "<script language='JavaScript'>alert('Select Supplier Name..!!'); </script>", false);
            ddl_BSuplier.Focus();
            return;
        }
        if (txt_BinvoiceNo.Text == "")
        {
            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "MessagePopUp", "<script language='JavaScript'>alert('Invoice Number Should Not Be Blank..!!'); </script>", false);
            txt_BinvoiceNo.Focus();
            return;
        }
        if (txt_BInvoiceDate.Text == "")
        {
            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "MessagePopUp", "<script language='JavaScript'>alert('Invoice Date Should Not Be Blank..!!'); </script>", false);
            txt_BInvoiceDate.Focus();
            return;
        }

        if (txt_BRcvDate.Text == "")
        {
            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "MessagePopUp", "<script language='JavaScript'>alert('Recieving Date Should Not Be Blank..!!'); </script>", false);
            txt_BRcvDate.Focus();
            return;
        }

        //////////////////////////////////

        if (txt_PartNo.Text == "")
        {
            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "MessagePopUp", "<script language='JavaScript'>alert('Part Number Should Not Be Blank..!!'); </script>", false);
            txt_PartNo.Focus();
            return;
        }
        if (txt_PartDesc.Text == "")
        {
            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "MessagePopUp", "<script language='JavaScript'>alert('Part Description Should Not Be Blank..!!'); </script>", false);
            txt_PartDesc.Focus();
            return;
        }

        if (txt_PartQuantity.Text == "")
        {
            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "MessagePopUp", "<script language='JavaScript'>alert('Quantity Should Not Be Blank..!!'); </script>", false);
            txt_PartQuantity.Focus();
            return;
        }

        if (txt_PartRate.Text == "")
        {
            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "MessagePopUp", "<script language='JavaScript'>alert('Rate Should Not Be Blank..!!'); </script>", false);
            txt_PartRate.Focus();
            return;
        }
        if (txt_PartAmount.Text == "")
        {
            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "MessagePopUp", "<script language='JavaScript'>alert('Amount Should Not Be Blank..!!'); </script>", false);
            txt_PartAmount.Focus();
            return;
        }
        if (txt_PartDiscount.Text == "")
        {
            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "MessagePopUp", "<script language='JavaScript'>alert('Discount Should Not Be Blank..!!'); </script>", false);
            txt_PartDiscount.Focus();
            return;
        }
        if (txt_PartVat.Text == "")
        {
            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "MessagePopUp", "<script language='JavaScript'>alert('Vat Should Not Be Blank..!!'); </script>", false);
            txt_PartVat.Focus();
            return;
        }
        if (txt_PartTaxAmount.Text == "")
        {
            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "MessagePopUp", "<script language='JavaScript'>alert('Tax Amount Should Not Be Blank..!!'); </script>", false);
            txt_PartTaxAmount.Focus();
            return;
        }
        if (txt_PartTotal.Text == "")
        {
            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "MessagePopUp", "<script language='JavaScript'>alert('Total Should Not Be Blank..!!'); </script>", false);
            txt_PartTotal.Focus();
            return;
        }
        if (txt_BReturnDate.Text == "")
        {
            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "MessagePopUp", "<script language='JavaScript'>alert('Return Date Should Not Be Blank..!!'); </script>", false);
            txt_BReturnDate.Focus();
            return;
        }

        string[] formats = { "dd/MM/yyyy", "d/M/yyyy", "dd/M/yyyy", "d/MM/yyyy", "dd/MMM/yyyy" };
        DateTime expectedDate;
        if (!DateTime.TryParseExact(txt_BInvoiceDate.Text, formats, new CultureInfo("en-US"), DateTimeStyles.None, out expectedDate))
        {
            ScriptManager.RegisterStartupScript(this.Page, typeof(string), "", "alert('ENTER VALID DATE (DD/MMM/YYYY)..!!');", true);
            txt_BInvoiceDate.Focus();
            return;
        }
        if (!DateTime.TryParseExact(txt_BRcvDate.Text, formats, new CultureInfo("en-US"), DateTimeStyles.None, out expectedDate))
        {
            ScriptManager.RegisterStartupScript(this.Page, typeof(string), "", "alert('ENTER VALID DATE (DD/MMM/YYYY)..!!');", true);
            txt_BRcvDate.Focus();
            return;
        }
        if (!DateTime.TryParseExact(txt_BReturnDate.Text, formats, new CultureInfo("en-US"), DateTimeStyles.None, out expectedDate))
        {
            ScriptManager.RegisterStartupScript(this.Page, typeof(string), "", "alert('ENTER VALID DATE (DD/MMM/YYYY)..!!');", true);
            txt_BReturnDate.Focus();
            return;
        }
        if (Convert.ToDecimal(txt_RetrnQty.Text) > Convert.ToDecimal(txt_PartQuantity.Text))
        {
            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "MessagePopUp", "<script language='JavaScript'>alert('Return Quantity Should Not Be Greater than Part Quantity..!!'); </script>", false);
            txt_PartQuantity.Focus();
            return;
        }
        if (Convert.ToDecimal(txt_RetrnQty.Text) > Convert.ToDecimal(txt_AvlQty.Text))
        {
            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "MessagePopUp", "<script language='JavaScript'>alert('Return Quantity Should Not Be Greater than Available Quantity..!!'); </script>", false);
            txt_RetrnQty.Focus();
            return;
        }
        

        string CWParam1 = "@Branch,@Req_Qntity,@ItmPartno";
        string CWParamValue1 = Session["Branch"].ToString() + "," + txt_RetrnQty.Text + "," + txt_PartNo.Text;
        smitaDbAccess.insertprocedure("Sp_StockdispatchInSpareIssue", CWParam1, CWParamValue1);

        int Ss_Id = Convert.ToInt32(btn_PartAdd.CommandArgument);
        string year = Request.QueryString["year"];
        AME_Spare_PurchaseEntry fse = db.AME_Spare_PurchaseEntry.First(t => t.Itm_Partno == txt_PartNo.Text && t.Ss_Id == Ss_Id && t.jc_year==year);
        fse.Ss_Quantity = fse.Ss_Quantity - Convert.ToDecimal(txt_RetrnQty.Text);
        fse.Ss_Amount = Convert.ToDecimal(txt_PartAmount.Text);
        fse.Ss_Discount = Convert.ToDecimal(txt_PartDiscount.Text);
        fse.Ss_TaxAmont = Convert.ToDecimal(txt_PartTaxAmount.Text);
        fse.Ss_Total = Convert.ToDecimal(txt_PartTotal.Text);
        db.SaveChanges();

        int sino = Convert.ToInt32(Request.QueryString["id"]);
        //string year = Request.QueryString["year"];
        AME_Spare_PurchaseReturn pr = new AME_Spare_PurchaseReturn();
        pr.Sp_Id = sino;
        pr.jc_year = year;
        pr.Sp_InvoiceNo = txt_BinvoiceNo.Text;
        pr.Sp_SupplierCode = ddl_BSuplier.SelectedValue;
        pr.Itm_Partno = txt_PartNo.Text;
        pr.Itm_PartDescrption = txt_PartDesc.Text;
        pr.Ss_Rate = Convert.ToDecimal(txt_PartRate.Text);
        pr.Ss_Quantity = Convert.ToDecimal(txt_PartQuantity.Text);
        pr.Ss_ReturnQuantity = Convert.ToDecimal(txt_RetrnQty.Text);
        pr.Ss_Amount = Convert.ToDecimal(txt_PartRate.Text) * Convert.ToDecimal(txt_RetrnQty.Text);
        pr.Ss_Discount = Convert.ToDecimal(0);
        pr.Ss_Vat = Convert.ToDecimal(txt_PartVat.Text);
        pr.Ss_TaxAmont = Convert.ToDecimal(txt_PartRate.Text) * Convert.ToDecimal(txt_RetrnQty.Text) * Convert.ToDecimal(txt_PartVat.Text)/100;
        pr.Ss_Total = pr.Ss_Amount + pr.Ss_TaxAmont;
        pr.Purchase_ReturnDate = Convert.ToDateTime(txt_BReturnDate.Text, JaguClass.dateformat103());
        pr.Status = true;
        pr.Branch_Name = Session["Branch"].ToString();
        pr.Created_By = Session["Uid"].ToString();
        pr.Created_Date = JaguClass.IndianTime();
        db.AddToAME_Spare_PurchaseReturn(pr);
        db.SaveChanges();

        FillGrid();

        string Bnane = Session["Branch"].ToString();
        int Vno = Convert.ToInt32(txt_BVoucherNo.Text);

        AME_Spare_PurchaseEntryBillDetails pd = db.AME_Spare_PurchaseEntryBillDetails.First(t => t.Sp_Id == sino && t.Sp_VoucherNo == Vno && t.Branch_Name == Bnane && t.jc_year==year);
        pd.Sp_GrossAmount = Convert.ToDecimal(txt_AGrossAmount.Text);
        pd.Sp_Discount = Convert.ToDecimal(txt_ADiscountAmount.Text);
        pd.Sp_NetAmount = Convert.ToDecimal(txt_ANetAmount.Text);
        pd.Sp_VatAmount = Convert.ToDecimal(txt_AVatAmount.Text);
        pd.Sp_TotalAmount = Convert.ToDecimal(txt_ATotal.Text);
        pd.Sp_PackagingAmount = Convert.ToDecimal(txt_APackagingAmt.Text);
        pd.Sp_OtherAmount = Convert.ToDecimal(txt_AOtherAmount.Text);
        pd.Sp_BillAmount = Convert.ToDecimal(txt_ABillAmount.Text);
        pd.Status = true;
        pd.Branch_Name = Session["Branch"].ToString();
        pd.Created_By = Session["Uid"].ToString();
        pd.Created_Date = SmitaClass.IndianTime();
        db.SaveChanges();

        txt_PartNo.Text = "";
        txt_PartDesc.Text = "";
        txt_PartQuantity.Text = "";
        txt_PartRate.Text = "";
        txt_PartAmount.Text = "";
        txt_PartDiscount.Text = "";
        txt_PartVat.Text = "";
        txt_PartTaxAmount.Text = "";
        txt_PartTotal.Text = "";
        txt_AvlQty.Text = "0";
        txt_RetrnQty.Text = "0";
        btn_PartAdd.Visible = false;
        txt_PartNo.Focus();
        ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "MessagePopUp", "<script language='JavaScript'>alert('Return Done SuccessFully..!!'); </script>", false);
    }
    decimal tot1 = 0, tot2 = 0, tot3 = 0, tot4 = 0;
    private void FillGrid()
    {
        string year = Request.QueryString["year"];
        int VNo = Convert.ToInt32(Request.QueryString["No"]);
        var details = (from c in db.AME_Spare_PurchaseEntry.ToList()
                       where c.Sp_VoucherNo == VNo && c.Ss_Status == "PE" && c.jc_year==year
                       && c.Branch_Name == Session["Branch"].ToString()
                       select c);
        GridView2.DataSource = details.ToList();
        GridView2.DataBind();

        foreach (GridViewRow gr in GridView2.Rows)
        {
            Label lbl_Amount = (Label)gr.FindControl("Label13");
            decimal TotAmt = Convert.ToDecimal(lbl_Amount.Text);

            Label lbl_Discount = (Label)gr.FindControl("Label15");
            decimal TotDiscount = Convert.ToDecimal(lbl_Discount.Text);

            Label lbl_TaxAmt = (Label)gr.FindControl("Label17");
            decimal TaxAmt = Convert.ToDecimal(lbl_TaxAmt.Text);

            Label lbl_Total = (Label)gr.FindControl("Label18");
            decimal Total = Convert.ToDecimal(lbl_Total.Text);

            tot1 = tot1 + TotAmt;
            tot2 = tot2 + TotDiscount;
            tot3 = tot3 + TaxAmt;
            tot4 = tot4 + Total;

            txt_AGrossAmount.Text = Convert.ToString(SmitaClass.SignificantTruncate(tot1, 2));
            txt_ADiscountAmount.Text = Convert.ToString(SmitaClass.SignificantTruncate(tot2, 2));
            txt_ANetAmount.Text = Convert.ToString(Convert.ToDecimal(txt_AGrossAmount.Text) - Convert.ToDecimal(txt_ADiscountAmount.Text));
            txt_AVatAmount.Text = Convert.ToString(SmitaClass.SignificantTruncate(tot3, 2));
            txt_ATotal.Text = Convert.ToString(SmitaClass.SignificantTruncate(tot4, 2));
            txt_ABillAmount.Text = Convert.ToString(Convert.ToDecimal(txt_ATotal.Text) + Convert.ToDecimal(txt_APackagingAmt.Text) + Convert.ToDecimal(txt_AOtherAmount.Text));
        }
    }
     
    protected void txt_RetrnQty_TextChanged(object sender, EventArgs e)
    {
        if (Convert.ToDecimal(txt_RetrnQty.Text) > Convert.ToDecimal(txt_PartQuantity.Text))
        {
            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "MessagePopUp", "<script language='JavaScript'>alert('Return Quantitry Must Be Less Than The Total Quantity..!!'); </script>", false);
            txt_RetrnQty.Focus();
            txt_RetrnQty.Text = "0";
            return;
        }
        decimal avlqnty = Convert.ToDecimal(txt_PartQuantity.Text) - Convert.ToDecimal(txt_RetrnQty.Text);
        txt_PartAmount.Text = Convert.ToString(avlqnty * Convert.ToDecimal(txt_PartRate.Text));
        txt_PartTaxAmount.Text = Convert.ToString(Convert.ToDecimal(txt_PartAmount.Text) * Convert.ToDecimal(txt_PartVat.Text)/100);
        txt_PartTotal.Text = Convert.ToString(Convert.ToDecimal(txt_PartAmount.Text) + Convert.ToDecimal(txt_PartDiscount.Text) + Convert.ToDecimal(txt_PartTaxAmount.Text));
    }
    protected void btnreturn_Click(object sender, EventArgs e)
    {
        Button imgEdit = (Button)sender;
        string pno = Convert.ToString(imgEdit.ToolTip);
        int Ss_Id = Convert.ToInt32(imgEdit.CommandArgument);
        string year = Request.QueryString["year"];
        int VNo = Convert.ToInt32(Request.QueryString["No"]);
        var details = (from c in db.AME_Spare_PurchaseEntry.ToList()
                       where c.Ss_Id == Ss_Id && c.Itm_Partno == pno && c.Ss_Status == "PE" && c.jc_year==year
                       select c);
        if (Convert.ToDecimal(details.First().Ss_Quantity) <=0)
        {
            ScriptManager.RegisterStartupScript(this.Page, typeof(string), "", "alert('Error..!! Stock Already Zero Now You Cant Return Stock..!!');", true);
            txt_PartNo.Text = "";
            txt_PartDesc.Text = "";
            txt_PartQuantity.Text = "";
            txt_PartRate.Text = "";
            txt_PartAmount.Text = "";
            txt_PartDiscount.Text = "";
            txt_PartVat.Text = "";
            txt_PartTaxAmount.Text = "";
            txt_PartTotal.Text = "";
            btn_PartAdd.ToolTip = "";
            btn_PartAdd.CommandArgument = "";
            btn_PartAdd.Visible = false;
            return;
        }

        txt_PartNo.Text = details.First().Itm_Partno;
        txt_PartDesc.Text = details.First().Itm_PartDescrption;
        txt_PartQuantity.Text = Convert.ToString(details.First().Ss_Quantity);
        txt_PartRate.Text = Convert.ToString(details.First().Ss_Rate);
        txt_PartAmount.Text = Convert.ToString(details.First().Ss_Amount);
        txt_PartDiscount.Text = Convert.ToString(details.First().Ss_Discount);
        txt_PartVat.Text = Convert.ToString(details.First().Ss_Vat);
        txt_PartTaxAmount.Text = Convert.ToString(details.First().Ss_TaxAmont);
        txt_PartTotal.Text = Convert.ToString(details.First().Ss_Total);
        btn_PartAdd.ToolTip = pno;
        btn_PartAdd.CommandArgument = Ss_Id.ToString();
        btn_PartAdd.Visible = true;

        DataSet ds = smitaDbAccess.returndataset("select SUM(Ss_NetQuantity) AS NetQuantity FROM AME_Spare_PurchaseEntry WHERE Itm_Partno='" + txt_PartNo.Text + "' AND Branch_Name='" + Session["Branch"].ToString() + "'");
        if (ds.Tables[0].Rows[0].ItemArray[0].ToString() != "")
        {
            txt_AvlQty.Text = ds.Tables[0].Rows[0].ItemArray[0].ToString();
        }
        else
        {
            txt_AvlQty.Text = "0";
        }
    }
}