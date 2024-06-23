using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using AutoMobileModel;
using System.Globalization;
using System.Data.SqlClient;
using System.Data;
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
            FillVoucherNo();
            SPE.RemoveAll(t => t.UserId == Session["Uid"].ToString());
            FillGrid();
            FillSlno();
        }
    }


    [System.Web.Services.WebMethod]
    public static string[] GetTagCNames(string prefixText, int count)
    {

        string br = Convert.ToString(HttpContext.Current.Session["Branch"]);
        string Sale = Convert.ToString(HttpContext.Current.Session["saletype"]);
        if (HttpContext.Current.Session["saletype"] != null)
        {
            AutoMobileEntities db = new AutoMobileEntities();

            return db.AME_Master_Customer.Where(n => n.Mc_Name.StartsWith(prefixText) && n.Branch_Name == br && n.Mc_SaleStatus == Sale).OrderBy(n => n.Mc_Name).Select(n => n.Mc_Name).Distinct().Take(count).ToArray();

        }
        else
        {
            AutoMobileEntities db = new AutoMobileEntities();

            return db.AME_Master_Customer.Where(n => n.Mc_Name.StartsWith(prefixText) && n.Branch_Name == br).OrderBy(n => n.Mc_Name).Select(n => n.Mc_Name).Distinct().Take(count).ToArray();

        }
    }


  

    [System.Web.Services.WebMethod]
    public static string[] GetPartNo(string prefixText, int count)
    {
        AutoMobileEntities db = new AutoMobileEntities();
        return db.AME_Master_Item.Where(n => n.Itm_Partno.Contains(prefixText) && n.Ms_Status == true).OrderBy(n => n.Itm_Partno).Select(n => n.Itm_Partno).Distinct().Take(count).ToArray();
    }
   
    [System.Web.Services.WebMethod]
    public static string[] GetPartDesc(string prefixText, int count)
    {
        AutoMobileEntities db = new AutoMobileEntities();
        return db.AME_Master_Item.Where(n => n.Itm_PartDescrption.Contains(prefixText)).OrderBy(n => n.Itm_PartDescrption).Select(n => n.Itm_PartDescrption).Distinct().Take(count).ToArray();
    }

    private void FillVoucherNo()
    {
        string branchname = Session["Branch"].ToString();
        string InvType = ddl_invtype.SelectedValue.ToString();
        if ((from c in db.AME_BillCounter where c.Branch_Name == branchname && c.BillType==InvType select c.BillCounter).Count() > 0)
        {
            int VNo = (int)(from c in db.AME_BillCounter where c.Branch_Name == branchname && c.BillType == InvType select c.BillCounter).Max();
            if (ddl_invtype.SelectedItem.Text == "Tax Invoice")
            {
                txt_BVoucherNo.Text = "T/"+Convert.ToString(VNo + 1);
            }
            else
            {
                txt_BVoucherNo.Text = "R/" + Convert.ToString(VNo + 1);
            }
        }
        else
        {
            txt_BVoucherNo.Text = "Error";
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
    protected void txt_BName_TextChanged(object sender, EventArgs e)
    {
        try
        {
            var v = from k in db.AME_Master_Customer.ToList()
                    where (k.Mc_Name.Equals(txt_BName.Text))
                    select new
                    {
                        k.Branch_Name,
                        k.Mc_Address,
                        k.Mc_code,
                        k.Mc_Mobileno,
                        k.Mc_Tin
                    };

            txt_BTinSrinNo.Text = v.First().Mc_Tin;
            txt_BName.ToolTip = v.First().Mc_code;
            txt_PartNo.Focus();
        }
        catch
        {
            txt_BName.Text = "";
            txt_BName.ToolTip = "";
            txt_BTinSrinNo.Text = "";
            txt_BName.Focus();
        }
    }
    protected void txt_PartNo_TextChanged(object sender, EventArgs e)
    {
        try
        {
            var v = from k in db.AME_Master_Item.ToList()
                    where (k.Itm_Partno.Equals(txt_PartNo.Text))
                    select new
                    {
                        k.Itm_Partno,
                        k.Itm_PartDescrption,
                        k.Itm_SalePrice,
                        k.Itm_VatPercent,
                        k.Itm_CategoryName
                    };

            txt_PartNo.Text = v.First().Itm_Partno;
            txt_PartDesc.Text = Convert.ToString(v.First().Itm_PartDescrption);
            txt_PartRate.Text = Convert.ToString(v.First().Itm_SalePrice);
            txt_PartVat.Text = Convert.ToString(v.First().Itm_VatPercent);
            txt_category.Text = v.First().Itm_CategoryName;
            DataSet ds = smitaDbAccess.returndataset("select SUM(Ss_NetQuantity) AS NetQuantity FROM AME_Spare_PurchaseEntry WHERE Itm_Partno='" + txt_PartNo.Text + "' AND Branch_Name='" + Session["Branch"].ToString() + "'");
            if (ds.Tables[0].Rows[0].ItemArray[0].ToString() != "")
            {
                txt_AvlQty.Text = ds.Tables[0].Rows[0].ItemArray[0].ToString();
            }
            else
            {
                txt_AvlQty.Text = "0";
            }

            txt_PartQuantity.Focus();
        }
        catch
        {
            txt_PartNo.Text = "";
            txt_PartDesc.Text = "";
            txt_PartRate.Text = "";
            txt_PartVat.Text = "";
            txt_AvlQty.Text = "";
            txt_PartRate.Text = "";
            txt_PartDiscount.Text = "0";
            txt_PartQuantity.Focus();
        }
    }
    protected void txt_PartDesc_TextChanged(object sender, EventArgs e)
    {
        try
        {
            var v = from k in db.AME_Master_Item.ToList()
                    where (k.Itm_PartDescrption.Equals(txt_PartDesc.Text))
                    select new
                    {
                        k.Itm_Partno,
                        k.Itm_PartDescrption,
                        k.Itm_SalePrice,
                        k.Itm_VatPercent,
                        k.Itm_CategoryName
                    };

            txt_PartNo.Text = v.First().Itm_Partno;
            txt_PartDesc.Text = Convert.ToString(v.First().Itm_PartDescrption);
            txt_PartRate.Text = Convert.ToString(v.First().Itm_SalePrice);
            txt_PartVat.Text = Convert.ToString(v.First().Itm_VatPercent);
            txt_category.Text = v.First().Itm_CategoryName;
            DataSet ds = smitaDbAccess.returndataset("select SUM(Ss_NetQuantity) AS NetQuantity FROM AME_Spare_PurchaseEntry WHERE Itm_Partno='" + txt_PartNo.Text + "' AND Branch_Name='" + Session["Branch"].ToString() + "'");
            if (ds.Tables[0].Rows[0].ItemArray[0].ToString() != "")
            {
                txt_AvlQty.Text = ds.Tables[0].Rows[0].ItemArray[0].ToString();
            }
            else
            {
                txt_AvlQty.Text = "0";
            }

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
    public decimal countS5 = 0;
    public decimal countS13 = 0;
    public decimal countL5 = 0;
    public decimal countL13 = 0;
    protected void btn_PartAdd_Click(object sender, EventArgs e)
    {
        try
        {
            if (Session["Uid"] != null)
            {
                uname = Session["Uid"].ToString();
            }
            else
            {
                Response.Redirect("AccessDenied.aspx");
            }
            if (txt_BVoucherNo.Text == "")
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "MessagePopUp", "<script language='JavaScript'>alert('Invoice Number Should Not Be Blank..!!'); </script>", false);
                txt_BVoucherNo.Focus();
                return;
            }
            if (txt_BDate.Text == "")
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "MessagePopUp", "<script language='JavaScript'>alert('Invoice Date Should Not Be Blank..!!'); </script>", false);
                txt_BDate.Focus();
                return;
            }

            //if (txt_BChalanNo0.Text == "")
            //{
            //    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "MessagePopUp", "<script language='JavaScript'>alert('Challan No. Should Not Be Blank..!!'); </script>", false);
            //    txt_BChalanNo0.Focus();
            //    return;
            //}
            //if (txt_BChallanDate.Text == "")
            //{
            //    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "MessagePopUp", "<script language='JavaScript'>alert('Challan Date Should Not Be Blank..!!'); </script>", false);
            //    txt_BChallanDate.Focus();
            //    return;
            //}

            //if (txt_BOrderNo.Text == "")
            //{
            //    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "MessagePopUp", "<script language='JavaScript'>alert('Order No Should Not Be Blank..!!'); </script>", false);
            //    txt_BOrderNo.Focus();
            //    return;
            //}
            //if (txt_BOrderDate.Text == "")
            //{
            //    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "MessagePopUp", "<script language='JavaScript'>alert('Order Date Should Not Be Blank..!!'); </script>", false);
            //    txt_BOrderDate.Focus();
            //    return;
            //}
            if (txt_BName.Text == "")
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "MessagePopUp", "<script language='JavaScript'>alert('Name Should Not Be Blank..!!'); </script>", false);
                txt_BName.Focus();
                return;
            }
            if (txt_BName.ToolTip == "")
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "MessagePopUp", "<script language='JavaScript'>alert('Enter Name Again..!!'); </script>", false);
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
            if (txt_BChallanDate.Text != "")
            {
                if (!DateTime.TryParseExact(txt_BChallanDate.Text, formats, new CultureInfo("en-US"), DateTimeStyles.None, out expectedDate))
                {
                    ScriptManager.RegisterStartupScript(this.Page, typeof(string), "", "alert('ENTER VALID DATE (DD/MMM/YYYY)..!!');", true);
                    txt_BChallanDate.Focus();
                    return;
                }
            }
            if (txt_BOrderDate.Text != "")
            {
                if (!DateTime.TryParseExact(txt_BOrderDate.Text, formats, new CultureInfo("en-US"), DateTimeStyles.None, out expectedDate))
                {
                    ScriptManager.RegisterStartupScript(this.Page, typeof(string), "", "alert('ENTER VALID DATE (DD/MMM/YYYY)..!!');", true);
                    txt_BOrderDate.Focus();
                    return;
                }
            }

            var ChkPrdCode = from c in SPE.Where(t => t.Itm_Partno == txt_PartNo.Text && t.UserId == uname) select c;

            if (Convert.ToInt32(ChkPrdCode.Count()) > 0)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "MessagePopUp", "<script language='JavaScript'>alert('Same Part Already Added..!!!');</script>", false);
                txt_PartNo.Focus();
                return;
            }
            if (Convert.ToDecimal(txt_AvlQty.Text) < Convert.ToDecimal(txt_PartQuantity.Text))
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "MessagePopUp", "<script language='JavaScript'>alert('You Dont Have More Stock,Your Available STock Is " + txt_AvlQty.Text + "...!!!'); </script>", false);
                txt_PartQuantity.Focus();
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
            pr1.category = txt_category.Text;
            SPE.Add(pr1);

            FillGrid();

            txt_PartNo.Text = "";
            txt_PartDesc.Text = "";
            txt_PartQuantity.Text = "";
            txt_PartRate.Text = "";
            txt_PartAmount.Text = "";
            txt_PartDiscount.Text = "0";
            txt_PartVat.Text = "";
            txt_PartTaxAmount.Text = "";
            txt_PartTotal.Text = "";
            FillSlno();
            txt_PartNo.Focus();


            /////

         

            
            
        }
        catch
        {

        }
    }
    decimal tot1 = 0, tot2 = 0, tot3 = 0, tot4 = 0;
    private void FillGrid()
    {
        uname = Session["Uid"].ToString();
        var prd = (from c in SPE.ToList()
                   where c.UserId == uname
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
            txt_AFinalAmount.Text = Convert.ToString(Convert.ToDecimal(txt_ATotal.Text) + Convert.ToDecimal(txt_APackagingAmt.Text) + Convert.ToDecimal(txt_AOtherAmt.Text));
        }
    }
    protected void imgbtn_PartDelete_Click(object sender, ImageClickEventArgs e)
    {
        ImageButton img_delete = (ImageButton)sender;

        SPE.RemoveAll(t => t.Itm_Partno == img_delete.ToolTip);
        FillGrid();
    }
  

    protected void btn_Submit_Click(object sender, EventArgs e)
    {
        if (txt_BVoucherNo.Text == "")
        {
            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "MessagePopUp", "<script language='JavaScript'>alert('Invoice Number Should Not Be Blank..!!'); </script>", false);
            txt_BVoucherNo.Focus();
            return;
        }
        if (txt_BDate.Text == "")
        {
            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "MessagePopUp", "<script language='JavaScript'>alert('Invoice Date Should Not Be Blank..!!'); </script>", false);
            txt_BDate.Focus();
            return;
        }
       
        //if (txt_BChalanNo0.Text == "")
        //{
        //    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "MessagePopUp", "<script language='JavaScript'>alert('Challan No. Should Not Be Blank..!!'); </script>", false);
        //    txt_BChalanNo0.Focus();
        //    return;
        //}
        //if (txt_BChallanDate.Text == "")
        //{
        //    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "MessagePopUp", "<script language='JavaScript'>alert('Challan Date Should Not Be Blank..!!'); </script>", false);
        //    txt_BChallanDate.Focus();
        //    return;
        //}

        //if (txt_BOrderNo.Text == "")
        //{
        //    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "MessagePopUp", "<script language='JavaScript'>alert('Order No Should Not Be Blank..!!'); </script>", false);
        //    txt_BOrderNo.Focus();
        //    return;
        //}
        //if (txt_BOrderDate.Text == "")
        //{
        //    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "MessagePopUp", "<script language='JavaScript'>alert('Order Date Should Not Be Blank..!!'); </script>", false);
        //    txt_BOrderDate.Focus();
        //    return;
        //}
        if (txt_BName.Text == "")
        {
            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "MessagePopUp", "<script language='JavaScript'>alert('Name Should Not Be Blank..!!'); </script>", false);
            txt_BName.Focus();
            return;
        }
        if (txt_BName.ToolTip == "")
        {
            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "MessagePopUp", "<script language='JavaScript'>alert('Enter Name Again..!!'); </script>", false);
            txt_BName.Focus();
            return;
        }

        /////////////////////////


        string[] formats = { "dd/MM/yyyy", "d/M/yyyy", "dd/M/yyyy", "d/MM/yyyy", "dd/MMM/yyyy" };
        DateTime expectedDate;
        if (!DateTime.TryParseExact(txt_BDate.Text, formats, new CultureInfo("en-US"), DateTimeStyles.None, out expectedDate))
        {
            ScriptManager.RegisterStartupScript(this.Page, typeof(string), "", "alert('ENTER VALID DATE (DD/MMM/YYYY)..!!');", true);
            txt_BDate.Focus();
            return;
        }
        if (txt_BChallanDate.Text != "")
        {
            if (!DateTime.TryParseExact(txt_BChallanDate.Text, formats, new CultureInfo("en-US"), DateTimeStyles.None, out expectedDate))
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(string), "", "alert('ENTER VALID DATE (DD/MMM/YYYY)..!!');", true);
                txt_BChallanDate.Focus();
                return;
            }
        }
        if (txt_BOrderDate.Text != "")
        {
            if (!DateTime.TryParseExact(txt_BOrderDate.Text, formats, new CultureInfo("en-US"), DateTimeStyles.None, out expectedDate))
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(string), "", "alert('ENTER VALID DATE (DD/MMM/YYYY)..!!');", true);
                txt_BOrderDate.Focus();
                return;
            }
        }

        //////////////////////////////////

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
        if (txt_APackagingAmt.Text == "")
        {
            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "MessagePopUp", "<script language='JavaScript'>alert('Packaging Amount Should Not Be Blank..!!'); </script>", false);
            txt_APackagingAmt.Focus();
            return;
        }
        if (txt_AOtherAmt.Text == "")
        {
            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "MessagePopUp", "<script language='JavaScript'>alert('Other Amount Should Not Be Blank..!!'); </script>", false);
            txt_AOtherAmt.Focus();
            return;
        }
        if (txt_AFinalAmount.Text == "")
        {
            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "MessagePopUp", "<script language='JavaScript'>alert('Final Amount Should Not Be Blank..!!'); </script>", false);
            txt_AFinalAmount.Focus();
            return;
        }

        AME_Spare_SalesEntryBillDetails pd = new AME_Spare_SalesEntryBillDetails();
        pd.Sp_InvoiceNo = txt_BVoucherNo.Text;
        pd.Sp_InvoiceDate = Convert.ToDateTime(txt_BDate.Text, SmitaClass.dateformat());
        pd.Sp_InvoiceType = ddl_invtype.SelectedValue.ToString();
        pd.Sp_SaleBy = ddl_BSaleBy.SelectedValue.ToString();
        pd.Sp_SaleType = ddl_BSaleType.SelectedValue.ToString();
        pd.Sp_ChalanNo = txt_BChalanNo0.Text;
        if (txt_BChallanDate.Text != "")
        {
            pd.Sp_ChalanDate = Convert.ToDateTime(txt_BChallanDate.Text, SmitaClass.dateformat());
        }
        pd.Sp_OrderNo = txt_BOrderNo.Text;
        if (txt_BOrderDate.Text != "")
        {
            pd.Sp_OrderDate = Convert.ToDateTime(txt_BOrderDate.Text, SmitaClass.dateformat());
        }
        pd.Sp_Mc_code = txt_BName.ToolTip;
        pd.Sp_Mc_Name = txt_BName.Text;
        pd.Sp_GrossAmount = Convert.ToDecimal(txt_AGrossAmount.Text);
        pd.Sp_Discount = Convert.ToDecimal(txt_ADiscountAmount.Text);
        pd.Sp_NetAmount = Convert.ToDecimal(txt_ANetAmount.Text);
        pd.Sp_VatAmount = Convert.ToDecimal(txt_AVatAmount.Text);
        pd.Sp_TotalAmount = Convert.ToDecimal(txt_ATotal.Text);
        pd.Sp_PackagingAmount = Convert.ToDecimal(txt_APackagingAmt.Text);
        pd.Sp_OtherAmount = Convert.ToDecimal(txt_AOtherAmt.Text);
        pd.Sp_FinalAmount = Convert.ToDecimal(txt_AFinalAmount.Text);
        pd.Status = true;

        pd.Branch_Name = Session["Branch"].ToString();
        pd.Created_By = Session["Uid"].ToString();
        pd.Created_Date = SmitaClass.IndianTime();
        db.AddToAME_Spare_SalesEntryBillDetails(pd);
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
            Label lblcategory = (Label)gr.FindControl("lblcategory");
            decimal vat = Convert.ToDecimal(lbl_Vat.Text);

            AME_Spare_SalesEntry pe = new AME_Spare_SalesEntry();
            pe.Sp_InvoiceNo = txt_BVoucherNo.Text;
            pe.Itm_Partno = lbl_partno.Text;
            pe.Itm_PartDescrption = lbl_partDesc.Text;
            pe.Ss_Quantity = Convert.ToDecimal(lbl_Quantity.Text);
            pe.Ss_Rate = Convert.ToDecimal(lbl_Rate.Text);
            pe.Ss_Amount = Convert.ToDecimal(lbl_Amount.Text);
            pe.Ss_Discount = Convert.ToDecimal(lbl_Discount.Text);
            pe.Ss_Vat = Convert.ToDecimal(lbl_Vat.Text);
            pe.Ss_TaxAmont = Convert.ToDecimal(lbl_TaxAmt.Text);
            pe.Ss_Total = Convert.ToDecimal(lbl_Total.Text);
            pe.Ss_Status = "SE";
            pe.Status = true;
            pe.Itm_Category = lblcategory.Text;
            pe.Branch_Name = Session["Branch"].ToString();
            pe.Created_By = Session["Uid"].ToString();
            pe.Created_Date = SmitaClass.IndianTime();
            db.AddToAME_Spare_SalesEntry(pe);
            db.SaveChanges();


            AME_Daily_SpareSales_Report dsr = new AME_Daily_SpareSales_Report();
            dsr.DR_InvoiceNo = txt_BVoucherNo.Text;
            dsr.DR_IDate = Convert.ToDateTime(txt_BDate.Text, SmitaClass.dateformat());
            dsr.DR_InvType = ddl_invtype.SelectedItem.Text;
            dsr.DR_InvStatus = "COUNTER";
            dsr.Dr_InvMode = ddl_BSaleBy.SelectedValue.ToString();
            dsr.JC_No = 0;
            if (lblcategory.Text == "Spareparts" && lbl_Vat.Text == "5.00")
            {


                decimal spre5amount = Convert.ToDecimal(lbl_Amount.Text);
                countS5 = Convert.ToDecimal(countS5 + spre5amount);

                if (lbls5.Text=="")
                {
                    lbls5.Text = "0";
                    dsr.Dr_Spare5 = 0;
                }
               
                lbls5.Text = Convert.ToString(countS5);
                dsr.Dr_Spare5 =Convert.ToDecimal(lbls5.Text);
            }
            if (lblcategory.Text == "Spareparts" && lbl_Vat.Text == "13.50")
            {


                decimal spre5amount = Convert.ToDecimal(lbl_Amount.Text);
                countS13 = Convert.ToDecimal(countS13 + spre5amount);
                if (lbls13.Text == "")
                {
                    lbls13.Text = "0";
                    dsr.Dr_Spare13_5 = 0;
                }
               
                lbls13.Text = Convert.ToString(countS13);
                dsr.Dr_Spare13_5 = Convert.ToDecimal(lbls13.Text);
               

            }
            //else if (lblcategory.Text == "Lubricants" && lbl_Vat.Text == "5.00")
            //{


            //    decimal spre5amount = Convert.ToDecimal(lbl_Amount.Text);
            //    countL5 = Convert.ToDecimal(countL5 + spre5amount);
            //    //lbll5.Text = Convert.ToString(countL5);

            //}
            else if (lblcategory.Text == "Lubricants" && lbl_Vat.Text == "13.50")
            {
                decimal spre5amount = Convert.ToDecimal(lbl_Amount.Text);
                countL13 = Convert.ToDecimal(countL13 + spre5amount);

                if (lbls13.Text == "")
                {
                    lbll13.Text = "0";
                    dsr.Dr_Spare13_5 = 0;
                }
                lbll13.Text = Convert.ToString(countL13);
                dsr.Dr_Lub13_5 = Convert.ToDecimal(lbll13);
            }

           
            //else
            //{
            //    dsr.Dr_Lub13_5 = Convert.ToDecimal(txt_AGrossAmount.Text);
            //    dsr.Dr_Spare13_5 = 0;
            //}
           
            decimal discountamount = Convert.ToDecimal(txt_ADiscountAmount.Text);
            dsr.Dr_DiscountAmount3_5 = discountamount; 
            dsr.Dr_DiscountAmount5 = 0;
            decimal output = (Convert.ToDecimal(lbll13.Text) + Convert.ToDecimal(lbls13.Text));
            decimal output1 = (Convert.ToDecimal(output) * Convert.ToDecimal(13 * 5)) / 100;
            dsr.Dr_Output13_5 = output1;
            dsr.Dr_Output5 = 0;
            dsr.Dr_OtherCharges = Convert.ToDecimal(txt_AOtherAmt.Text);
            dsr.Dr_Labourcharges = 0;
            dsr.Dr_NetLabourcharges = 0;
            dsr.Dr_Servtaxx12 = 0;
            dsr.Dr_Ecess2 = 0;
            dsr.Dr_Scess1 = 0;
            dsr.Dr_Roundoff = 0;
            dsr.Dr_Outsidejob = 0;
            dsr.Dr_InvoiceTotal = output+output1;
            dsr.Dr_DisLabourcharges = 0;
            dsr.Branch_Name = Session["Branch"].ToString();
            db.AddToAME_Daily_SpareSales_Report(dsr);
            db.SaveChanges();

            string CWParam1 = "@Branch,@Req_Qntity,@ItmPartno";
            string CWParamValue1 = Session["Branch"].ToString() + "," + lbl_Quantity.Text + "," + lbl_partno.Text;
            smitaDbAccess.insertprocedure("Sp_StockdispatchInSpareIssue", CWParam1, CWParamValue1);
        }
        string branchname = Session["Branch"].ToString();
        string InvType = ddl_invtype.SelectedValue.ToString();
        int id123 = (int)(from c in db.AME_BillCounter where c.Branch_Name == branchname && c.BillType == InvType select c.BillCounter).Max();
        AME_BillCounter OR = db.AME_BillCounter.First(t => t.Branch_Name == branchname && t.BillType == InvType);
        OR.BillCounter = id123 + 1;
        db.SaveChanges();
        ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "MessagePopUp", "<script language='JavaScript'>alert('Sale Done SuccessFully..!!'); </script>", false);
        cl.Clear_All(this);
        txt_ADiscountAmount.Text = "0";
        txt_AvlQty.Text= "";
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

        public string category { get; set; }
    }


    protected void ddl_invtype_SelectedIndexChanged(object sender, EventArgs e)
    {
        FillVoucherNo();
    }
}