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
            FillModel();

            string sino = Request.QueryString["id"];
            string VNo = Request.QueryString["No"];
            filldata(sino, VNo);
            FillGrid();
            FillSlno();
           
        }
    }

    [System.Web.Services.WebMethod]
    public static string[] GetPartNo(string prefixText, int count)
    {
        string branch = HttpContext.Current.Session["Branch"].ToString();
        AutoMobileEntities db = new AutoMobileEntities();
        return db.AME_Master_Item.Where(n => n.Itm_Partno.Contains(prefixText) && n.Branch_Name == branch).OrderBy(n => n.Itm_Partno).Select(n => n.Itm_Partno).Distinct().Take(count).ToArray();
    }

    [System.Web.Services.WebMethod]
    public static string[] GetPartDesc(string prefixText, int count)
    {
        string branch = HttpContext.Current.Session["Branch"].ToString();
        AutoMobileEntities db = new AutoMobileEntities();
        return db.AME_Master_Item.Where(n => n.Itm_PartDescrption.Contains(prefixText) && n.Branch_Name == branch).OrderBy(n => n.Itm_PartDescrption).Select(n => n.Itm_PartDescrption).Distinct().Take(count).ToArray();
    }

    private void FillModel()
    {
         string Sale = Convert.ToString(Session["saletype"]);
         if (Session["saletype"] != null)
         {
             string branchname = Session["Branch"].ToString();
             var v = from c in db.AME_Master_VehicleModel.ToList()
                     where c.Status = true && c.Branch_Name == branchname && c.Mv_SaleStatus==Sale
                     select new
                     {
                         Mv_ModelName = c.Mv_ModelName,
                         Mv_Code = c.Mv_Code
                     };
             ddl_BModel.DataSource = v.ToList();
             ddl_BModel.DataTextField = "Mv_ModelName";
             ddl_BModel.DataValueField = "Mv_Code";
             ddl_BModel.DataBind();
             ddl_BModel.Items.Insert(0, "--Select One--");
         }
         else
         {
             string branchname = Session["Branch"].ToString();
             var v = from c in db.AME_Master_VehicleModel.ToList()
                     where c.Status = true && c.Branch_Name == branchname
                     select new
                     {
                         Mv_ModelName = c.Mv_ModelName,
                         Mv_Code = c.Mv_Code
                     };
             ddl_BModel.DataSource = v.ToList();
             ddl_BModel.DataTextField = "Mv_ModelName";
             ddl_BModel.DataValueField = "Mv_Code";
             ddl_BModel.DataBind();
             ddl_BModel.Items.Insert(0, "--Select One--");
         }
        
    }

    private void FillSlno()
    {
        int VNo =Convert.ToInt32(Request.QueryString["No"]);
        var v = (from c in db.AME_Spare_EstimateEntry.ToList()
                 where c.Sp_EstimationNo == VNo && c.Ss_Status == "PE"
                 && c.Branch_Name == Session["Branch"].ToString()
                       select c);
        if (v.Count() > 0)
        {
            txt_PartSlNo.Text = (v.Count()+1).ToString();
        }
        else
        {
            txt_PartSlNo.Text = "1";
        }
    }
    public void filldata(string sino, string VcNO)
    {
        int id = Convert.ToInt32(sino);
        int VouNo = Convert.ToInt32(VcNO);

        var v = from c in db.AME_Spare_EstimateEntryBillDetails.ToList().Where(t => t.Sp_Id == id && t.Sp_EstimationNo == VouNo && t.Branch_Name == Session["Branch"].ToString()) select c;
        txt_BVoucherNo.Text = Convert.ToString(v.First().Sp_EstimationNo);
        txt_BDate.Text = Convert.ToDateTime(v.First().Sp_EstimationDate).ToString("dd/MM/yyyy");
        ddl_BModel.SelectedValue = v.First().Mv_Code;
        txt_BName.Text = v.First().Sp_Name;
        txt_BAddress.Text = Convert.ToString(v.First().Sp_Address);
        txt_BMobileNo.Text = Convert.ToString(v.First().Sp_MobNo);
        txt_BRegdNo.Text = Convert.ToString(v.First().Sp_RegdNo);

        txt_AGrossAmount.Text = Convert.ToString(v.First().Sp_GrossAmount);
        txt_ADiscountAmount.Text = Convert.ToString(v.First().Sp_Discount);
        txt_ANetAmount.Text = Convert.ToString(v.First().Sp_NetAmount);
        txt_AVatAmount.Text = Convert.ToString(v.First().Sp_VatAmount);
        txt_ATotal.Text = Convert.ToString(v.First().Sp_TotalAmount);

        var details = (from c in db.AME_Spare_EstimateEntry.ToList()
                       where c.Sp_EstimationNo == VouNo && c.Branch_Name == Session["Branch"].ToString()
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
                    where (k.Itm_PartDescrption.Equals(txt_PartDesc.Text) && k.Branch_Name==branchname)
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
        if (ddl_BModel.SelectedIndex == 0)
        {
            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "MessagePopUp", "<script language='JavaScript'>alert('Select Model Name..!!'); </script>", false);
            ddl_BModel.Focus();
            return;
        }
        if (txt_BDate.Text == "")
        {
            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "MessagePopUp", "<script language='JavaScript'>alert('Date Should Not Be Blank..!!'); </script>", false);
            txt_BDate.Focus();
            return;
        }
        if (txt_BRegdNo.Text == "")
        {
            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "MessagePopUp", "<script language='JavaScript'>alert('Regd. No. Should Not Be Blank..!!'); </script>", false);
            txt_BRegdNo.Focus();
            return;
        }

        if (txt_BName.Text == "")
        {
            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "MessagePopUp", "<script language='JavaScript'>alert('Name Should Not Be Blank..!!'); </script>", false);
            txt_BName.Focus();
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

        string[] formats = { "dd/MM/yyyy", "d/M/yyyy", "dd/M/yyyy", "d/MM/yyyy", "dd/MMM/yyyy" };
        DateTime expectedDate;
        if (!DateTime.TryParseExact(txt_BDate.Text, formats, new CultureInfo("en-US"), DateTimeStyles.None, out expectedDate))
        {
            ScriptManager.RegisterStartupScript(this.Page, typeof(string), "", "alert('ENTER VALID DATE (DD/MMM/YYYY)..!!');", true);
            txt_BDate.Focus();
            return;
        }

        if (btn_PartAdd.Text == "Add")
        {
            AME_Spare_EstimateEntry pr1 = new AME_Spare_EstimateEntry();
            pr1.Sp_EstimationNo = Convert.ToInt32(txt_BVoucherNo.Text);
            pr1.Itm_Partno = txt_PartNo.Text;
            pr1.Itm_PartDescrption = txt_PartDesc.Text;
            pr1.Ss_Quantity = Convert.ToDecimal(txt_PartQuantity.Text);
            pr1.Ss_Rate = Convert.ToDecimal(txt_PartRate.Text);
            pr1.Ss_Amount = Convert.ToDecimal(txt_PartAmount.Text);
            pr1.Ss_Discount = Convert.ToDecimal(txt_PartDiscount.Text);
            pr1.Ss_Vat = Convert.ToDecimal(txt_PartVat.Text);
            pr1.Ss_TaxAmont = Convert.ToDecimal(txt_PartTaxAmount.Text);
            pr1.Ss_Total = Convert.ToDecimal(txt_PartTotal.Text);
            pr1.Ss_Status = "PE";
            pr1.Status = true;

            pr1.Branch_Name = Session["Branch"].ToString();
            pr1.Created_By = Session["Uid"].ToString();
            pr1.Created_Date = SmitaClass.IndianTime();
            db.AddToAME_Spare_EstimateEntry(pr1);
            db.SaveChanges();
        }
        else if (btn_PartAdd.Text == "Update")
        {
            int vcNo=Convert.ToInt32(txt_BVoucherNo.Text);

            AME_Spare_EstimateEntry pr1 = db.AME_Spare_EstimateEntry.First(t => t.Itm_Partno == txt_PartNo.Text && t.Sp_EstimationNo == vcNo);
            pr1.Ss_Quantity = Convert.ToDecimal(txt_PartQuantity.Text);
            pr1.Ss_Rate = Convert.ToDecimal(txt_PartRate.Text);
            pr1.Ss_Amount = Convert.ToDecimal(txt_PartAmount.Text);
            pr1.Ss_Discount = Convert.ToDecimal(txt_PartDiscount.Text);
            pr1.Ss_Vat = Convert.ToDecimal(txt_PartVat.Text);
            pr1.Ss_TaxAmont = Convert.ToDecimal(txt_PartTaxAmount.Text);
            pr1.Ss_Total = Convert.ToDecimal(txt_PartTotal.Text);
            pr1.Ss_Status = "PE";
            pr1.Status = true;

            pr1.Branch_Name = Session["Branch"].ToString();
            pr1.Created_By = Session["Uid"].ToString();
            pr1.Created_Date = SmitaClass.IndianTime();
            db.SaveChanges();
            btn_PartAdd.Text = "Add";
        }
        FillGrid();

        int id = Convert.ToInt32(Request.QueryString["id"]);
        int VouNo = Convert.ToInt32(Request.QueryString["No"]);
        string Bname = Session["Branch"].ToString();

        AME_Spare_EstimateEntryBillDetails pd = db.AME_Spare_EstimateEntryBillDetails.First(t => t.Sp_Id == id && t.Sp_EstimationNo == VouNo && t.Branch_Name == Bname);
        
        pd.Sp_GrossAmount = Convert.ToDecimal(txt_AGrossAmount.Text);
        pd.Sp_Discount = Convert.ToDecimal(txt_ADiscountAmount.Text);
        pd.Sp_NetAmount = Convert.ToDecimal(txt_ANetAmount.Text);
        pd.Sp_VatAmount = Convert.ToDecimal(txt_AVatAmount.Text);
        pd.Sp_TotalAmount = Convert.ToDecimal(txt_ATotal.Text);
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

        txt_PartNo.Enabled =true;
        txt_PartDesc.Enabled = true;
        FillSlno();
        txt_PartNo.Focus();
    }
    decimal tot1 = 0, tot2 = 0, tot3 = 0, tot4 = 0;
    private void FillGrid()
    {
        int VNo = Convert.ToInt32(Request.QueryString["No"]);
        var details = (from c in db.AME_Spare_EstimateEntry.ToList()
                       where c.Sp_EstimationNo == VNo && c.Ss_Status == "PE"
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
        }
    }
    protected void imgbtn_PartDelete_Click(object sender, ImageClickEventArgs e)
    {
        ImageButton img_delete = (ImageButton)sender;
        string PartNo=Convert.ToString(img_delete.ToolTip);

        int VNo = Convert.ToInt32(Request.QueryString["No"]);
        
        AME_Spare_PurchaseEntry pe = db.AME_Spare_PurchaseEntry.ToList().First(t => t.Sp_VoucherNo == VNo && t.Itm_Partno == PartNo && t.Ss_Status == "PE" && t.Branch_Name == Session["Branch"].ToString());
        db.DeleteObject(pe);
        db.SaveChanges();
        FillGrid();
    }

    protected void btn_Submit_Click(object sender, EventArgs e)
    {

        if (txt_BVoucherNo.Text == "")
        {
            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "MessagePopUp", "<script language='JavaScript'>alert('Voucher Number Should Not Be Blank..!!'); </script>", false);
            txt_BVoucherNo.Focus();
            return;
        }
        if (ddl_BModel.SelectedIndex == 0)
        {
            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "MessagePopUp", "<script language='JavaScript'>alert('Select Model Name..!!'); </script>", false);
            ddl_BModel.Focus();
            return;
        }
        if (txt_BDate.Text == "")
        {
            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "MessagePopUp", "<script language='JavaScript'>alert('Date Should Not Be Blank..!!'); </script>", false);
            txt_BDate.Focus();
            return;
        }
        if (txt_BRegdNo.Text == "")
        {
            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "MessagePopUp", "<script language='JavaScript'>alert('Regd. No. Should Not Be Blank..!!'); </script>", false);
            txt_BRegdNo.Focus();
            return;
        }

        if (txt_BName.Text == "")
        {
            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "MessagePopUp", "<script language='JavaScript'>alert('Name Should Not Be Blank..!!'); </script>", false);
            txt_BName.Focus();
            return;
        }


        if (txt_AGrossAmount.Text == "")
        {
            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "MessagePopUp", "<script language='JavaScript'>alert('Gross Amount Should Not Be Blank..!!'); </script>", false);
            txt_AGrossAmount.Focus();
            return;
        }
        if (txt_ADiscountAmount.Text == "")
        {
            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "MessagePopUp", "<script language='JavaScript'>alert('Discount Amount Should Not Be Blank..!!'); </script>", false);
            txt_ADiscountAmount.Focus();
            return;
        }
        if (txt_ANetAmount.Text == "")
        {
            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "MessagePopUp", "<script language='JavaScript'>alert('Net Amount Should Not Be Blank..!!'); </script>", false);
            txt_ANetAmount.Focus();
            return;
        }
        if (txt_AVatAmount.Text == "")
        {
            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "MessagePopUp", "<script language='JavaScript'>alert('Vat Amount Should Not Be Blank..!!'); </script>", false);
            txt_AVatAmount.Focus();
            return;
        }
        if (txt_ATotal.Text == "")
        {
            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "MessagePopUp", "<script language='JavaScript'>alert('Total Amount Should Not Be Blank..!!'); </script>", false);
            txt_ATotal.Focus();
            return;
        }

        int id = Convert.ToInt32(Request.QueryString["id"]);
        int VouNo = Convert.ToInt32(Request.QueryString["No"]);
        string Bname = Session["Branch"].ToString();

        AME_Spare_EstimateEntryBillDetails pd = db.AME_Spare_EstimateEntryBillDetails.First(t => t.Sp_Id == id && t.Sp_EstimationNo == VouNo && t.Branch_Name == Bname);
        pd.Sp_EstimationDate = Convert.ToDateTime(txt_BDate.Text, SmitaClass.dateformat());
        pd.Sp_Name = txt_BName.Text;
        pd.Sp_Address = txt_BAddress.Text;
        pd.Sp_MobNo = txt_BMobileNo.Text;
        pd.Mv_Code = ddl_BModel.SelectedValue.ToString();
        pd.Sp_RegdNo = txt_BRegdNo.Text;
        pd.Sp_GrossAmount = Convert.ToDecimal(txt_AGrossAmount.Text);
        pd.Sp_Discount = Convert.ToDecimal(txt_ADiscountAmount.Text);
        pd.Sp_NetAmount = Convert.ToDecimal(txt_ANetAmount.Text);
        pd.Sp_VatAmount = Convert.ToDecimal(txt_AVatAmount.Text);
        pd.Sp_TotalAmount = Convert.ToDecimal(txt_ATotal.Text);
        pd.Status = true;

        pd.Branch_Name = Session["Branch"].ToString();
        pd.Created_By = Session["Uid"].ToString();
        pd.Created_Date = SmitaClass.IndianTime();
        db.SaveChanges();

        ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "MessagePopUp", "<script language='JavaScript'>alert('Bill Updated SuccessFully..!!'); </script>", false);
    }

    protected void ImgEdit_Click(object sender, ImageClickEventArgs e)
    {
        ImageButton imgEdit = (ImageButton)sender;
        string pno = Convert.ToString(imgEdit.ToolTip);

        int VNo = Convert.ToInt32(Request.QueryString["No"]);
        var details = (from c in db.AME_Spare_EstimateEntry.ToList()
                       where c.Sp_EstimationNo == VNo && c.Itm_Partno == pno && c.Ss_Status == "PE"
                       && c.Branch_Name == Session["Branch"].ToString()
                       select c);

        txt_PartNo.Text = details.First().Itm_Partno;
        txt_PartDesc.Text = details.First().Itm_PartDescrption;
        txt_PartQuantity.Text =Convert.ToString(details.First().Ss_Quantity);
        txt_PartRate.Text = Convert.ToString(details.First().Ss_Rate);
        txt_PartAmount.Text = Convert.ToString(details.First().Ss_Amount);
        txt_PartDiscount.Text = Convert.ToString(details.First().Ss_Discount);
        txt_PartVat.Text = Convert.ToString(details.First().Ss_Vat);
        txt_PartTaxAmount.Text = Convert.ToString(details.First().Ss_TaxAmont);
        txt_PartTotal.Text = Convert.ToString(details.First().Ss_Total);

        btn_PartAdd.Text = "Update";
        txt_PartNo.Enabled = false;
        txt_PartDesc.Enabled = false;
    }
}