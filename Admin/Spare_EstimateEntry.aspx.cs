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
    static List<PartDetails> SPE = new List<PartDetails>();
    Clear cl = new Clear();
    public string uname;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            txt_BDate.Text = JaguClass.IndianTime().ToString("dd/MM/yyyy");
            FillModel();
            FillVoucherNo();
            SPE.RemoveAll(t => t.UserId == Session["Uid"].ToString());
            FillGrid();
            FillSlno();
        }
    }

    [System.Web.Services.WebMethod]
    public static string[] GetPartNo(string prefixText, int count)
    {
        string branch = HttpContext.Current.Session["Branch"].ToString();
        AutoMobileEntities db = new AutoMobileEntities();
        return db.AME_Master_Item.Where(n => n.Itm_Partno.Contains(prefixText) && n.Branch_Name==branch).OrderBy(n => n.Itm_Partno).Select(n => n.Itm_Partno).Distinct().Take(count).ToArray();
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

    private void FillVoucherNo()
    {
        string branchname = Session["Branch"].ToString();
        if ((from c in db.AME_Spare_EstimateEntryBillDetails where c.Branch_Name == branchname select c.Sp_EstimationNo).Count() > 0)
        {
            int VNo = (int)(from c in db.AME_Spare_EstimateEntryBillDetails where c.Branch_Name == branchname select c.Sp_EstimationNo).Max();
            txt_BVoucherNo.Text = Convert.ToString(VNo + 1);
        }
        else
        {
            txt_BVoucherNo.Text = "1";
        }
    }
    private void FillSlno()
    {
        var v = SPE.ToList();
        if (v.Count() > 0)
        {
            txt_PartSlNo.Text = (v.Count()+1).ToString();
        }
        else
        {
            txt_PartSlNo.Text = "1";
        }
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
            decimal rate = v.First().Itm_SalePrice;
            //txt_PartRate.Text = Convert.ToString(v.First().Itm_SalePrice);
            txt_PartVat.Text = Convert.ToString(v.First().Itm_VatPercent);
            // txt_PartQuantity.Focus();

            decimal vat = Convert.ToDecimal(txt_PartVat.Text);
            //decimal rate = Convert.ToDecimal(txt_PartRate.Text);
            decimal temp = Convert.ToDecimal(rate / (100 + vat));
            txt_PartAmount.Text = (temp * 100).ToString("0.00");
            txt_PartRate.Text = (temp * 100).ToString("0.00");
            ViewState["rate"] = rate;
            txt_PartQuantity.Focus();
            txt_PartQuantity.Text = "1";



            decimal amnt = temp * 100;

            decimal qty = Convert.ToDecimal(txt_PartQuantity.Text);
            txt_PartAmount.Text = (amnt * qty).ToString("0.00");
            txt_PartDiscount.Text = "0";
            txt_PartDiscountper.Text = "0";
            decimal amnt1 = Convert.ToDecimal(txt_PartAmount.Text);
            decimal afterdisc = amnt1;
            txt_PartTaxAmount.Text = (afterdisc * (vat / 100)).ToString("0.00");

            decimal taxamnt = Convert.ToDecimal(txt_PartTaxAmount.Text);
            txt_PartTotal.Text = (afterdisc + taxamnt).ToString("0.00");
        }
        catch
        {
            txt_PartNo.Text = "";
            txt_PartDesc.Text = "";
            txt_PartRate.Text = "";
            txt_PartVat.Text = "";

            txt_PartDiscount.Text = "0";
            txt_PartQuantity.Focus();
            txt_PartQuantity.Text = "0";
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
        //if (txt_BRegdNo.Text == "")
        //{
        //    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "MessagePopUp", "<script language='JavaScript'>alert('Regd. No. Should Not Be Blank..!!'); </script>", false);
        //    txt_BRegdNo.Focus();
        //    return;
        //}

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

        PartDetails pr1 = new PartDetails();
        pr1.Itm_Partno = txt_PartNo.Text;
        pr1.Itm_PartDescrption = txt_PartDesc.Text;
        pr1.Ss_Quantity = Convert.ToDecimal(txt_PartQuantity.Text);
        pr1.Ss_Rate = Convert.ToDecimal(txt_PartRate.Text);
        pr1.Ss_Amount = Convert.ToDecimal(txt_PartAmount.Text);
        pr1.Ss_Discount = Convert.ToDecimal(txt_PartDiscount.Text);
        pr1.Ss_Vat = Convert.ToDecimal(txt_PartVat.Text);
        pr1.Ss_TaxAmont = Convert.ToDecimal(txt_PartTaxAmount.Text);
        pr1.Ss_Total = Convert.ToDecimal(txt_PartTotal.Text);
        pr1.UserId = Session["Uid"].ToString();
        pr1.branch = Session["Branch"].ToString();
        SPE.Add(pr1);

        FillGrid();

        txt_PartNo.Text = "";
        txt_PartDesc.Text = "";
        txt_PartQuantity.Text = "";
        txt_PartRate.Text = "";
        txt_PartAmount.Text = "";
        txt_PartDiscount.Text = "";
        txt_PartVat.Text = "";
        txt_PartTaxAmount.Text = "";
        txt_PartTotal.Text = "";
        FillSlno();
        txt_PartNo.Focus();
    }
    decimal tot1 = 0, tot2 = 0, tot3 = 0, tot4 = 0;
    private void FillGrid()
    {
        uname = Session["Uid"].ToString();

        string branchname = Session["Branch"].ToString();
        var prd = (from c in SPE.ToList()
                   where c.UserId == uname && c.branch==branchname
                   select c).ToList();
        GridView2.DataSource = prd.ToList();
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
        string branchname = Session["Branch"].ToString();
        SPE.RemoveAll(t => t.Itm_Partno == img_delete.ToolTip && t.branch==branchname);
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
        //if (txt_BRegdNo.Text == "")
        //{
        //    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "MessagePopUp", "<script language='JavaScript'>alert('Regd. No. Should Not Be Blank..!!'); </script>", false);
        //    txt_BRegdNo.Focus();
        //    return;
        //}

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

        AME_Spare_EstimateEntryBillDetails pd = new AME_Spare_EstimateEntryBillDetails();
        pd.Sp_EstimationNo = Convert.ToInt32(txt_BVoucherNo.Text);
        pd.Sp_EstimationDate = Convert.ToDateTime(txt_BDate.Text, SmitaClass.dateformat());
        pd.Sp_Name = txt_BName.Text;
        pd.Sp_Address = txt_BAddress.Text;
        pd.Sp_MobNo = txt_BMobileNo.Text;
        if (ddl_BModel.SelectedIndex == 0)
        {
            pd.Mv_Code = "";
        }
        else
        {
            pd.Mv_Code = ddl_BModel.SelectedValue.ToString();
        }
        
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
        db.AddToAME_Spare_EstimateEntryBillDetails(pd);
        db.SaveChanges();

        foreach (GridViewRow gr in GridView2.Rows)
        {
            Label lbl_partno = (Label)gr.FindControl("Label10");
            Label lbl_partDesc = (Label)gr.FindControl("Label12");
            Label lbl_Quantity = (Label)gr.FindControl("Label11");
            Label lbl_Rate = (Label)gr.FindControl("Label14");
            Label lbl_Amount = (Label)gr.FindControl("Label13");
            Label lbl_Discount = (Label)gr.FindControl("Label15");
            Label lbl_Vat = (Label)gr.FindControl("Label16");
            Label lbl_TaxAmt = (Label)gr.FindControl("Label17");
            Label lbl_Total = (Label)gr.FindControl("Label18");

            AME_Spare_EstimateEntry pe = new AME_Spare_EstimateEntry();
            pe.Sp_EstimationNo = Convert.ToInt32(txt_BVoucherNo.Text);
            pe.Itm_Partno = lbl_partno.Text;
            pe.Itm_PartDescrption = lbl_partDesc.Text;
            pe.Ss_Quantity = Convert.ToDecimal(lbl_Quantity.Text);
            pe.Ss_Rate = Convert.ToDecimal(lbl_Rate.Text);
            pe.Ss_Amount = Convert.ToDecimal(lbl_Amount.Text);
            pe.Ss_Discount = Convert.ToDecimal(lbl_Discount.Text);
            pe.Ss_Vat = Convert.ToDecimal(lbl_Vat.Text);
            pe.Ss_TaxAmont = Convert.ToDecimal(lbl_TaxAmt.Text);
            pe.Ss_Total = Convert.ToDecimal(lbl_Total.Text);
            pe.Ss_Status = "PE";
            pe.Status = true;

            pe.Branch_Name = Session["Branch"].ToString();
            pe.Created_By = Session["Uid"].ToString();
            pe.Created_Date = SmitaClass.IndianTime();
            db.AddToAME_Spare_EstimateEntry(pe);
            db.SaveChanges();
        }
        ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "MessagePopUp", "<script language='JavaScript'>alert('Estimate Entry done SuccessFully..!!'); </script>", false);
        cl.Clear_All(this);
        FillModel();
        FillVoucherNo();
        FillSlno();
        SPE.RemoveAll(t => t.UserId == Session["Uid"].ToString());
        FillGrid();
    }
    protected void btn_Cancel_Click(object sender, EventArgs e)
    {
        cl.Clear_All(this);
    }

    public class PartDetails
    {
        public string Itm_Partno { get; set; }

        public string Itm_PartDescrption { get; set; }

        public decimal Ss_Quantity { get; set; }

        public decimal Ss_Rate { get; set; }

        public decimal Ss_Amount { get; set; }

        public decimal Ss_Discount { get; set; }

        public decimal Ss_Vat { get; set; }

        public decimal Ss_TaxAmont { get; set; }

        public decimal Ss_Total { get; set; }

        public string UserId { get; set; }

        public string branch { get; set; }

    }
    protected void txt_PartQuantity_TextChanged(object sender, EventArgs e)
    {
        decimal vat = Convert.ToDecimal(txt_PartVat.Text);

        decimal rate = Convert.ToDecimal(ViewState["rate"]);
        decimal temp = Convert.ToDecimal(rate / (100 + vat));
        decimal amnt = temp * 100;

        decimal qty = Convert.ToDecimal(txt_PartQuantity.Text);
        txt_PartAmount.Text = (amnt * qty).ToString("0.00");
        txt_PartDiscount.Text = "0";
        txt_PartDiscountper.Text = "0";
        decimal amnt1 = Convert.ToDecimal(txt_PartAmount.Text);
        decimal afterdisc = amnt1;
        txt_PartTaxAmount.Text = (afterdisc * (vat / 100)).ToString("0.00");

        decimal taxamnt = Convert.ToDecimal(txt_PartTaxAmount.Text);
        txt_PartTotal.Text = (afterdisc + taxamnt).ToString("0.00");
    }
    protected void txt_PartDiscountper_TextChanged(object sender, EventArgs e)
    {
        decimal vat = Convert.ToDecimal(txt_PartVat.Text);
        decimal amnt = Convert.ToDecimal(txt_PartAmount.Text);
        decimal disc = Convert.ToDecimal(txt_PartDiscountper.Text);
        decimal per = disc / 100;
        txt_PartDiscount.Text = (amnt * per).ToString("0.00");

        decimal descamnt = Convert.ToDecimal(txt_PartDiscount.Text);

        decimal amnt1 = Convert.ToDecimal(txt_PartAmount.Text);
        decimal afterdisc = amnt1 - descamnt;
        txt_PartTaxAmount.Text = (afterdisc * (vat / 100)).ToString("0.00");

        decimal taxamnt = Convert.ToDecimal(txt_PartTaxAmount.Text);
        txt_PartTotal.Text = (afterdisc + taxamnt).ToString("0.00");
    }
}