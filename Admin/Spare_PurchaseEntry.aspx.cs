using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AutoMobileModel;
using System.Data;
using System.Globalization;

public partial class Admin_Spare_PurchaseEntry : System.Web.UI.Page
{
    AutoMobileEntities db = new AutoMobileEntities();
    static List<PartDetails> SPE = new List<PartDetails>();
    Clear cl = new Clear();
    public string uname , no;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (ViewState["ran_Key"] != null)
            {
                SPE.RemoveAll(t => t.key == ViewState["ran_Key"].ToString());
            }


            string ran_Key = CreateRandomPassword1(5);

            ViewState["ran_Key"] = ran_Key;
            int slmax = 0;

            if (DebasishGlobal.s5 > 0)
            {

                slmax = DebasishGlobal.s5 + 1;
                DebasishGlobal.s5 = slmax;
            }

            else
            {
                slmax = 1;
                DebasishGlobal.s5 = 1;
            }

            ViewState["maxs"] = Convert.ToString(slmax);
            txt_year.Text = "2018-19";
            FillSupplier();
           
          
            FillVoucherNo_submit();
           // SPE.RemoveAll(t => t.UserId == Session["Uid"].ToString());
           // FillGrid();
            FillSlno();
            txt_BInvoiceDate.Text = DateTime.Now.ToString("dd/MM/yyyy");
            txt_BRcvDate.Text = DateTime.Now.ToString("dd/MM/yyyy");
            txt_BLrDate.Text = DateTime.Now.ToString("dd/MM/yyyy");
            
        }
    }

    public static string CreateRandomPassword1(int PasswordLength)
    {
        string _allowedChars = "0123456789";
        Random randNum = new Random();
        char[] chars = new char[PasswordLength];
        int allowedCharCount = _allowedChars.Length;
        for (int i = 0; i < PasswordLength; i++)
        {
            chars[i] = _allowedChars[(int)((_allowedChars.Length) * randNum.NextDouble())];
        }
        return new string(chars);
    }
    //[System.Web.Services.WebMethod]
    //public static string[] Getyear(string prefixText, int count)
    //{

    //    AutoMobileEntities db = new AutoMobileEntities();
    //    return db.AME_FinacialYear.Where(n => n.finacialyear.Contains(prefixText)).OrderBy(n => n.finacialyear).Select(n => n.finacialyear).Distinct().Take(count).ToArray();
    //}
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

    private void FillVoucherNo()
    {
        string branchname = Session["Branch"].ToString();
        if ((from c in db.AME_Spare_PurchaseEntryBillDetails where c.Branch_Name == branchname && c.jc_year == txt_year.Text.Trim() select c.Sp_VoucherNo).Count() > 0)
        {
            int VNo = (int)(from c in db.AME_Spare_PurchaseEntryBillDetails where c.Branch_Name == branchname && c.jc_year == txt_year.Text.Trim() select c.Sp_VoucherNo).Max();
            txt_BVoucherNo.Text = Convert.ToString(VNo + 1);
        }
        else
        {
            txt_BVoucherNo.Text = "1";
        }
    }
    private void FillVoucherNo_submit()
    {
        Boolean isupdae = true;
        string branchname = Session["Branch"].ToString();
        if ((from c in db.AME_Spare_PurchaseEntryBillDetails where c.Branch_Name == branchname && c.jc_year==txt_year.Text.Trim() select c.Sp_VoucherNo).Count() > 0)
        {
            string param = "@Branch,@year";
            string year = txt_year.Text.Trim();
            string paramvalue = branchname + ","+year ;

            DataSet ds = smitaDbAccess.SPReturnDataSet("Getmaxpurchasevoucherno", param, paramvalue);
            int VNo = 0;
            try
            {
                VNo = int.Parse(ds.Tables[0].Rows[0].ItemArray[0].ToString());
            }
            catch (Exception)
            {
                isupdae = false;
                //throw;
            }
            if (isupdae == true)
            {

                txt_BVoucherNo.Text = Convert.ToString(VNo + 1);

            }

            else
            {
                txt_BVoucherNo.Text = "Error";
            }
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



            string param3 = "@txt_PartNo,@branchname";
            string paramvalue3 = txt_PartNo.Text + "," + branchname;
            DataSet dsall = smitaDbAccess.SPReturnDataSet("sp_GetDataNavlqty", param3, paramvalue3);
            //k.Itm_Partno,0
            //            k.Itm_PartDescrption,1
            //            k.Itm_SalePrice,2
            //            k.Itm_VatPercent,3
            //            k.Itm_CategoryName4



            txt_PartNo.Text = dsall.Tables[0].Rows[0][0].ToString();
            txt_PartDesc.Text = dsall.Tables[0].Rows[0][1].ToString();
            decimal rate = Convert.ToDecimal(dsall.Tables[0].Rows[0][2].ToString());
            txt_PartRate.Text = dsall.Tables[0].Rows[0][2].ToString();
            txt_PartDiscount.Text = "0";
            txt_PartDiscountper.Text = "0";

            txt_PartQuantity.Text = "0";
            txt_PartAmount.Text = "0";
            txt_PartTaxAmount.Text = "0";
            txt_PartTotal.Text = "0";
            DropDownList1.SelectedIndex = 0;
            txt_PartQuantity.Focus();



            //var v = from k in db.AME_Master_Item.ToList()
            //        where (k.Itm_Partno.Equals(txt_PartNo.Text) && k.Branch_Name==branchname)
            //        select new
            //        {
            //            k.Itm_Partno,
            //            k.Itm_PartDescrption,
            //            k.Itm_SalePrice,
            //            k.Itm_VatPercent
            //        };

            //txt_PartNo.Text = v.First().Itm_Partno;
            //txt_PartDesc.Text = Convert.ToString(v.First().Itm_PartDescrption).Trim();
            //decimal rate = v.First().Itm_SalePrice;
            //txt_PartRate.Text = Convert.ToString(v.First().Itm_SalePrice);
            //txt_PartDiscount.Text = "0";
            //txt_PartDiscountper.Text = "0";
            
            //txt_PartQuantity.Text = "0";
            //txt_PartAmount.Text = "0";
            //txt_PartTaxAmount.Text = "0";
            //txt_PartTotal.Text = "0";
            //DropDownList1.SelectedIndex = 0;
            //txt_PartQuantity.Focus();











            //txt_PartVat.Text = Convert.ToString(v.First().Itm_VatPercent);
           
            //decimal vat = Convert.ToDecimal(txt_PartVat.Text);
            //decimal rate = Convert.ToDecimal(txt_PartRate.Text);
            //decimal temp = Convert.ToDecimal(rate / (100 + vat));
           // txt_PartAmount.Text = (temp * 100).ToString("0.00");
            //txt_PartRate.Text = (temp * 100).ToString("0.00");
            //ViewState["rate"] = rate;
            




            //decimal amnt = temp * 100;

            //decimal qty = Convert.ToDecimal(txt_PartQuantity.Text);
            //txt_PartAmount.Text = (amnt * qty).ToString("0.00");
           
            //decimal amnt1 = Convert.ToDecimal(txt_PartAmount.Text);
            //decimal afterdisc = amnt1;
            //txt_PartTaxAmount.Text = (afterdisc * (vat / 100)).ToString("0.00");

            //decimal taxamnt = Convert.ToDecimal(txt_PartTaxAmount.Text);
            //txt_PartTotal.Text = (afterdisc + taxamnt).ToString("0.00");
        }
        catch
        {
           // txt_PartNo.Text = "";
            txt_PartDesc.Text = "";
            txt_PartRate.Text = "";
            //txt_PartVat.Text = "";
            txt_PartQuantity.Focus();
            
            txt_PartRate.Text = "";
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
                    where (k.Itm_PartDescrption.Equals(txt_PartDesc.Text) && k.Branch_Name == branchname)
                    select new
                    {
                        k.Itm_Partno,
                        k.Itm_PartDescrption,
                        k.Itm_SalePrice,
                        k.Itm_VatPercent
                    };

            txt_PartNo.Text = v.First().Itm_Partno;
            txt_PartDesc.Text = Convert.ToString(v.First().Itm_PartDescrption).Trim();
            decimal rate = v.First().Itm_SalePrice;
            txt_PartRate.Text = Convert.ToString(v.First().Itm_SalePrice);
            txt_PartDiscount.Text = "0";
            txt_PartDiscountper.Text = "0";

            txt_PartQuantity.Text = "0";
            txt_PartAmount.Text = "0";
            txt_PartTaxAmount.Text = "0";
            txt_PartTotal.Text = "0";
            DropDownList1.SelectedIndex = 0;
            txt_PartQuantity.Focus();
        }
        catch(Exception ex)
        {
            txt_PartNo.Text = "";
            txt_PartDesc.Text = "";
            txt_PartRate.Text = "";
            //txt_PartVat.Text = "";
           
            txt_PartQuantity.Focus();

            
        }
    }
    protected void btn_PartAdd_Click(object sender, EventArgs e)
    {
        //if (txt_BVoucherNo.Text == "")
        //{
        //    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "MessagePopUp", "<script language='JavaScript'>alert('Voucher Number Should Not Be Blank..!!'); </script>", false);
        //    txt_BVoucherNo.Focus();
        //    return;
        //}
        //if (ddl_BSuplier.SelectedIndex == 0)
        //{
        //    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "MessagePopUp", "<script language='JavaScript'>alert('Select Supplier Name..!!'); </script>", false);
        //    ddl_BSuplier.Focus();
        //    return;
        //}
        //if (txt_BinvoiceNo.Text == "")
        //{
        //    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "MessagePopUp", "<script language='JavaScript'>alert('Invoice Number Should Not Be Blank..!!'); </script>", false);
        //    txt_BinvoiceNo.Focus();
        //    return;
        //}
        //if (txt_BInvoiceDate.Text == "")
        //{
        //    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "MessagePopUp", "<script language='JavaScript'>alert('Invoice Date Should Not Be Blank..!!'); </script>", false);
        //    txt_BInvoiceDate.Focus();
        //    return;
        //}

        //if (txt_BRcvDate.Text == "")
        //{
        //    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "MessagePopUp", "<script language='JavaScript'>alert('Recieving Date Should Not Be Blank..!!'); </script>", false);
        //    txt_BRcvDate.Focus();
        //    return;
        //}

        //////////////////////////////////

        //if (txt_PartNo.Text == "")
        //{
        //    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "MessagePopUp", "<script language='JavaScript'>alert('Part Number Should Not Be Blank..!!'); </script>", false);
        //    txt_PartNo.Focus();
        //    return;
        //}
        //if (txt_PartDesc.Text == "")
        //{
        //    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "MessagePopUp", "<script language='JavaScript'>alert('Part Description Should Not Be Blank..!!'); </script>", false);
        //    txt_PartDesc.Focus();
        //    return;
        //}

        //if (txt_PartQuantity.Text == "")
        //{
        //    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "MessagePopUp", "<script language='JavaScript'>alert('Quantity Should Not Be Blank..!!'); </script>", false);
        //    txt_PartQuantity.Focus();
        //    return;
        //}

        //if (txt_PartRate.Text == "")
        //{
        //    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "MessagePopUp", "<script language='JavaScript'>alert('Rate Should Not Be Blank..!!'); </script>", false);
        //    txt_PartRate.Focus();
        //    return;
        //}
        //if (txt_PartAmount.Text == "")
        //{
        //    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "MessagePopUp", "<script language='JavaScript'>alert('Amount Should Not Be Blank..!!'); </script>", false);
        //    txt_PartAmount.Focus();
        //    return;
        //}
        //if (txt_PartDiscount.Text == "")
        //{
        //    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "MessagePopUp", "<script language='JavaScript'>alert('Discount Should Not Be Blank..!!'); </script>", false);
        //    txt_PartDiscount.Focus();
        //    return;
        //}
        //if (txt_PartVat.Text == "")
        //{
        //    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "MessagePopUp", "<script language='JavaScript'>alert('Vat Should Not Be Blank..!!'); </script>", false);
        //    txt_PartVat.Focus();
        //    return;
        //}
        //if (txt_PartTaxAmount.Text == "")
        //{
        //    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "MessagePopUp", "<script language='JavaScript'>alert('Tax Amount Should Not Be Blank..!!'); </script>", false);
        //    txt_PartTaxAmount.Focus();
        //    return;
        //}
        //if (txt_PartTotal.Text == "")
        //{
        //    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "MessagePopUp", "<script language='JavaScript'>alert('Total Should Not Be Blank..!!'); </script>", false);
        //    txt_PartTotal.Focus();
        //    return;
        //}

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

        PartDetails pr1 = new PartDetails();
        pr1.Itm_Partno = txt_PartNo.Text;
        pr1.Itm_PartDescrption = txt_PartDesc.Text;
        pr1.Ss_Quantity = Convert.ToDecimal(txt_PartQuantity.Text);
        pr1.Ss_Rate = Convert.ToDecimal(txt_PartRate.Text);
        pr1.Ss_Amount = Convert.ToDecimal(txt_PartAmount.Text);
        pr1.Ss_Discount = Convert.ToDecimal(txt_PartDiscount.Text);

        if (DropDownList1.SelectedIndex == 0)
        {
           pr1.Ss_Vat = 0;
            
        }
        else if (DropDownList1.SelectedIndex == 1)
        {
            string vat = "28.00";
            pr1.Ss_Vat = Convert.ToDecimal(vat);
        }
        else if (DropDownList1.SelectedIndex == 2)
        {
            string vat1 = "18.00";
            pr1.Ss_Vat = Convert.ToDecimal(vat1);
        }
        else if (DropDownList1.SelectedIndex == 3)
        {
            string vat2 = "14.5";
            pr1.Ss_Vat = Convert.ToDecimal(vat2);
        }
        else if (DropDownList1.SelectedIndex == 4)
        {
            pr1.Ss_Vat = 5;
        }
        else
        {
            pr1.Ss_Vat = 2;
        }
        
        pr1.Ss_TaxAmont = Convert.ToDecimal(txt_PartTaxAmount.Text);
        pr1.Ss_Total = Convert.ToDecimal(txt_PartTotal.Text);
        pr1.UserId = Session["Uid"].ToString();
        pr1.branch = Session["Branch"].ToString();
        pr1.maxslno = Convert.ToInt32(ViewState["maxs"].ToString());

      
        pr1.key = ViewState["ran_Key"].ToString();

        SPE.Add(pr1);

        FillGrid();

        txt_PartNo.Text = "";
        txt_PartDesc.Text = "";
        txt_PartQuantity.Text = "";
        txt_PartRate.Text = "";
        txt_PartAmount.Text = "";
        txt_PartDiscount.Text = "0";
        DropDownList1.SelectedIndex = 0;
        txt_PartTaxAmount.Text = "";
        txt_PartTotal.Text = "";
        FillSlno();
        txt_PartNo.Focus();
    }
    decimal tot1 = 0, tot2 = 0, tot3 = 0, tot4 = 0;
    private void FillGrid()
    {

        string branchname = Session["Branch"].ToString();
        uname = Session["Uid"].ToString();
        int mx = Convert.ToInt32(ViewState["maxs"].ToString());

        string key11 = ViewState["ran_Key"].ToString();
        var prd = (from c in SPE.ToList()
                  // where c.UserId == uname && c.branch==branchname
                   where c.key == key11
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
            txt_ABillAmount.Text = Convert.ToString(Convert.ToDecimal(txt_ATotal.Text) + Convert.ToDecimal(txt_APackagingAmt.Text) + Convert.ToDecimal(txt_AOtherAmount.Text));
        }
    }
    protected void imgbtn_PartDelete_Click(object sender, ImageClickEventArgs e)
    {
        ImageButton img_delete = (ImageButton)sender;
        int mx = Convert.ToInt32(ViewState["maxs"].ToString());
        string branchname = Session["Branch"].ToString();
        SPE.RemoveAll(t => t.Itm_Partno == img_delete.ToolTip && t.branch == branchname && t.maxslno == mx);
        FillGrid();
    }

    protected void btn_Submit_Click(object sender, EventArgs e)
    {

        //if (txt_year.Text == "")
        //{
        //    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "MessagePopUp", "<script language='JavaScript'>alert('Finacial Year Should Not Be Blank..!!'); </script>", false);
        //    txt_year.Focus();
        //    return;
        //}
        //if (txt_BVoucherNo.Text == "")
        //{
        //    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "MessagePopUp", "<script language='JavaScript'>alert('Voucher Number Should Not Be Blank..!!'); </script>", false);
        //    txt_BVoucherNo.Focus();
        //    return;
        //}
        //if (ddl_BSuplier.SelectedIndex == 0)
        //{
        //    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "MessagePopUp", "<script language='JavaScript'>alert('Select Supplier Name..!!'); </script>", false);
        //    ddl_BSuplier.Focus();
        //    return;
        //}
        //if (txt_BinvoiceNo.Text == "")
        //{
        //    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "MessagePopUp", "<script language='JavaScript'>alert('Invoice Number Should Not Be Blank..!!'); </script>", false);
        //    txt_BinvoiceNo.Focus();
        //    return;
        //}
        //if (txt_BInvoiceDate.Text == "")
        //{
        //    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "MessagePopUp", "<script language='JavaScript'>alert('Invoice Date Should Not Be Blank..!!'); </script>", false);
        //    txt_BInvoiceDate.Focus();
        //    return;
        //}

        //if (txt_BRcvDate.Text == "")
        //{
        //    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "MessagePopUp", "<script language='JavaScript'>alert('Recieving Date Should Not Be Blank..!!'); </script>", false);
        //    txt_BRcvDate.Focus();
        //    return;
        //}


        //if (txt_AGrossAmount.Text == "")
        //{
        //    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "MessagePopUp", "<script language='JavaScript'>alert('Gross Amount Should Not Be Blank..!!'); </script>", false);
        //    txt_AGrossAmount.Focus();
        //    return;
        //}
        //if (txt_ADiscountAmount.Text == "")
        //{
        //    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "MessagePopUp", "<script language='JavaScript'>alert('Discount Amount Should Not Be Blank..!!'); </script>", false);
        //    txt_ADiscountAmount.Focus();
        //    return;
        //}
        //if (txt_ANetAmount.Text == "")
        //{
        //    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "MessagePopUp", "<script language='JavaScript'>alert('Net Amount Should Not Be Blank..!!'); </script>", false);
        //    txt_ANetAmount.Focus();
        //    return;
        //}
        //if (txt_AVatAmount.Text == "")
        //{
        //    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "MessagePopUp", "<script language='JavaScript'>alert('Vat Amount Should Not Be Blank..!!'); </script>", false);
        //    txt_AVatAmount.Focus();
        //    return;
        //}
        //if (txt_ATotal.Text == "")
        //{
        //    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "MessagePopUp", "<script language='JavaScript'>alert('Total Amount Should Not Be Blank..!!'); </script>", false);
        //    txt_ATotal.Focus();
        //    return;
        //}
        //if (txt_APackagingAmt.Text == "")
        //{
        //    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "MessagePopUp", "<script language='JavaScript'>alert('Packaging Amount Should Not Be Blank..!!'); </script>", false);
        //    txt_APackagingAmt.Focus();
        //    return;
        //}
        //if (txt_AOtherAmount.Text == "")
        //{
        //    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "MessagePopUp", "<script language='JavaScript'>alert('Other Amount Should Not Be Blank..!!'); </script>", false);
        //    txt_AOtherAmount.Focus();
        //    return;
        //}
        //if (txt_ABillAmount.Text == "")
        //{
        //    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "MessagePopUp", "<script language='JavaScript'>alert('Bill Amount Should Not Be Blank..!!'); </script>", false);
        //    txt_ABillAmount.Focus();
        //    return;
        //}
        FillVoucherNo_submit();
        AME_Spare_PurchaseEntryBillDetails pd = new AME_Spare_PurchaseEntryBillDetails();
        pd.Sp_VoucherNo =Convert.ToInt32(txt_BVoucherNo.Text);
        pd.Sp_SupplierCode = ddl_BSuplier.SelectedValue.ToString();
        pd.jc_year = txt_year.Text.Trim();
        pd.Sp_InvoiceNo = txt_BinvoiceNo.Text;
        pd.Sp_InvoiceDate = Convert.ToDateTime(txt_BInvoiceDate.Text, SmitaClass.dateformat());
        pd.Sp_ReceiptDate = Convert.ToDateTime(txt_BRcvDate.Text, SmitaClass.dateformat());
        pd.Sp_LrNo = txt_BLrNo.Text;
        if (txt_BLrDate.Text != "")
        {
            pd.Sp_LrDate = Convert.ToDateTime(txt_BLrDate.Text, SmitaClass.dateformat());
        }
        pd.Sp_OrderNo = txt_BOrderNo.Text;
        if (txt_BOrderDate.Text != "")
        {
            pd.Sp_OrderDate = Convert.ToDateTime(txt_BOrderDate.Text, SmitaClass.dateformat());
        }
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
        db.AddToAME_Spare_PurchaseEntryBillDetails(pd);
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

            AME_Spare_PurchaseEntry pe = new AME_Spare_PurchaseEntry();
            pe.Sp_VoucherNo = Convert.ToInt32(txt_BVoucherNo.Text);
            pe.Itm_Partno = lbl_partno.Text;
            pe.jc_year = txt_year.Text.Trim();
            pe.Itm_PartDescrption = lbl_partDesc.Text;
            pe.Ss_Quantity = Convert.ToDecimal(lbl_Quantity.Text);
            pe.Ss_NetQuantity = Convert.ToDecimal(lbl_Quantity.Text);
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
            db.AddToAME_Spare_PurchaseEntry(pe);
            db.SaveChanges();
            string branch=Session["Branch"].ToString();
            AME_Master_Item itemupdate = db.AME_Master_Item.First(t => t.Itm_Partno == lbl_partno.Text && t.Branch_Name == branch);
            itemupdate.Itm_PurchasePrice = Convert.ToDecimal(lbl_Rate.Text);
            db.SaveChanges();
        }
        ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "MessagePopUp", "<script language='JavaScript'>alert('Purchase Entry done SuccessFully..!!'); </script>", false);
        cl.Clear_All(this);
        FillSupplier();

        FillVoucherNo_submit();
        
        //FillVoucherNo();
        txt_APackagingAmt.Text = "0";
        txt_AOtherAmount.Text = "0";
        SPE.RemoveAll(t => t.branch == Session["Branch"].ToString());
        FillSlno();
        FillGrid();
        txt_BInvoiceDate.Text = DateTime.Now.ToString("dd/MM/yyyy");
        txt_BRcvDate.Text = DateTime.Now.ToString("dd/MM/yyyy");
        txt_BLrDate.Text = DateTime.Now.ToString("dd/MM/yyyy");
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
        public int maxslno { get; set; }
      
        public string key { get; set; }

    }
    protected void txt_PartQuantity_TextChanged(object sender, EventArgs e)
    {
         string branchname = Session["Branch"].ToString();
         string no = txt_PartNo.Text;
            var v = from k in db.AME_Master_Item.ToList()
                    where (k.Itm_Partno.Equals(no) && k.Branch_Name == branchname)
                    select new
                    {
                        k.Itm_Partno,
                        k.Itm_PartDescrption,
                        k.Itm_SalePrice,
                        k.Itm_VatPercent
                    };
        decimal vat =v.First().Itm_VatPercent ;
        decimal rate = Convert.ToDecimal(txt_PartRate.Text);

        decimal qty = Convert.ToDecimal(txt_PartQuantity.Text);
        decimal amnt=rate * qty;
        txt_PartAmount.Text = (amnt).ToString("0.00");
        //txt_PartRate.Text = (rate*qty).ToString("0.00");
        decimal vatper = 0;
        if (DropDownList1.SelectedIndex == 0)
        {
            vatper = 0;
        }
        else if (DropDownList1.SelectedIndex == 1)
        {
            vatper = Convert.ToDecimal(DropDownList1.SelectedValue);
        }
        else
        {
            vatper = Convert.ToDecimal(DropDownList1.SelectedValue);
        }
        decimal va = vatper / 100;
        decimal vaamnt = amnt * va;
        txt_PartTaxAmount.Text = vaamnt.ToString("0.00");
        txt_PartTotal.Text = (amnt + vaamnt).ToString("0.00");

        txt_PartDiscount.Text = "0";
        txt_PartDiscountper.Text = "0";
        //txt_PartTaxAmount.Text = "0";
        //DropDownList1.SelectedIndex = 0;
        
        ////ViewState["rate"] = rate;
        ////decimal amnt = temp * 100;

        ////decimal qty = Convert.ToDecimal(txt_PartQuantity.Text);
        ////txt_PartAmount.Text = (amnt * qty).ToString("0.00");

        ////decimal amnt1 = Convert.ToDecimal(txt_PartAmount.Text);
        ////decimal afterdisc = amnt1;
        ////txt_PartTaxAmount.Text = (afterdisc * (vat / 100)).ToString("0.00");

        ////decimal taxamnt = Convert.ToDecimal(txt_PartTaxAmount.Text);
        ////txt_PartTotal.Text = (afterdisc + taxamnt).ToString("0.00");
        ////decimal vat = Convert.ToDecimal(txt_PartVat.Text);

        ////decimal rate = Convert.ToDecimal(ViewState["rate"]);
        ////decimal temp = Convert.ToDecimal(rate / (100 + vat));
        ////decimal amnt = temp * 100;

        ////decimal qty = Convert.ToDecimal(txt_PartQuantity.Text);
        ////txt_PartAmount.Text = (amnt * qty).ToString("0.00");
        ////txt_PartDiscount.Text = "0";
        ////txt_PartDiscountper.Text = "0";
        ////decimal amnt1 = Convert.ToDecimal(txt_PartAmount.Text);
        ////decimal afterdisc = amnt1;
        ////txt_PartTaxAmount.Text = (afterdisc * (vat / 100)).ToString("0.00");

        ////decimal taxamnt = Convert.ToDecimal(txt_PartTaxAmount.Text);
        ////txt_PartTotal.Text = (afterdisc + taxamnt).ToString("0.00");

        //decimal rate = Convert.ToDecimal(txt_PartRate.Text);
        //decimal qty = Convert.ToDecimal(txt_PartQuantity.Text);
        //decimal amnt = rate * qty;
        //txt_PartAmount.Text = amnt.ToString("0.00");
        //txt_PartTaxAmount.Text = "0";
        //DropDownList1.SelectedIndex = 0;
        //txt_PartTotal.Text = amnt.ToString("0.00");
    }
    protected void txt_PartDiscountper_TextChanged(object sender, EventArgs e)
    {
        //decimal vat = Convert.ToDecimal(txt_PartVat.Text);
        decimal amnt = Convert.ToDecimal(txt_PartAmount.Text);
        decimal disc = Convert.ToDecimal(txt_PartDiscountper.Text);
        decimal per = disc / 100;
        txt_PartDiscount.Text = (amnt * per).ToString("0.00");
        decimal descamnt = Convert.ToDecimal(txt_PartDiscount.Text);
        txt_PartTaxAmount.Text = "0";
        DropDownList1.SelectedIndex = 0;
        txt_PartTotal.Text = (amnt - descamnt).ToString("0.00");
        //decimal descamnt = Convert.ToDecimal(txt_PartDiscount.Text);

        //decimal amnt1 = Convert.ToDecimal(txt_PartAmount.Text);
        //decimal afterdisc = amnt1 - descamnt;
        //txt_PartTaxAmount.Text = (afterdisc * (vat / 100)).ToString("0.00");

        //decimal taxamnt = Convert.ToDecimal(txt_PartTaxAmount.Text);
        //txt_PartTotal.Text = (afterdisc + taxamnt).ToString("0.00");
    }
    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (DropDownList1.SelectedIndex == 0)
        {
            txt_PartTaxAmount.Text = "0";
            decimal amnt = Convert.ToDecimal(txt_PartAmount.Text);
            decimal descamnt = Convert.ToDecimal(txt_PartDiscount.Text);
            txt_PartTotal.Text = (amnt - descamnt).ToString("0.00");
        }
        else if (DropDownList1.SelectedIndex == 1)
        {

            decimal amnt = Convert.ToDecimal(txt_PartAmount.Text);
            decimal descamnt = Convert.ToDecimal(txt_PartDiscount.Text);
            decimal afterdisc = (amnt - descamnt);

            string tax = "28.00";
            decimal tax1 = Convert.ToDecimal(tax);
            txt_PartTaxAmount.Text = (afterdisc * tax1 / 100).ToString("0.00");
            decimal aftertax = Convert.ToDecimal(txt_PartTaxAmount.Text);
            txt_PartTotal.Text = (afterdisc + aftertax).ToString("0.00");
        }
        else if (DropDownList1.SelectedIndex == 2)
        {

            decimal amnt = Convert.ToDecimal(txt_PartAmount.Text);
            decimal descamnt = Convert.ToDecimal(txt_PartDiscount.Text);
            decimal afterdisc = (amnt - descamnt);

            string tax = "18";
            decimal tax1 = Convert.ToDecimal(tax);
            txt_PartTaxAmount.Text = (afterdisc * tax1 / 100).ToString("0.00");
            decimal aftertax = Convert.ToDecimal(txt_PartTaxAmount.Text);
            txt_PartTotal.Text = (afterdisc + aftertax).ToString("0.00");
        }
        else if (DropDownList1.SelectedIndex == 3)
        {

            decimal amnt = Convert.ToDecimal(txt_PartAmount.Text);
            decimal descamnt = Convert.ToDecimal(txt_PartDiscount.Text);
            decimal afterdisc = (amnt - descamnt);

            string tax = "14.5";
            decimal tax1 = Convert.ToDecimal(tax);
            txt_PartTaxAmount.Text = (afterdisc * tax1 / 100).ToString("0.00");
            decimal aftertax = Convert.ToDecimal(txt_PartTaxAmount.Text);
            txt_PartTotal.Text = (afterdisc + aftertax).ToString("0.00");
        }
        else if (DropDownList1.SelectedIndex == 4)
        {
            decimal amnt = Convert.ToDecimal(txt_PartAmount.Text);
            decimal descamnt = Convert.ToDecimal(txt_PartDiscount.Text);
            decimal afterdisc = (amnt - descamnt);
            string tax = "5";
            decimal tax1 = Convert.ToDecimal(tax);
            txt_PartTaxAmount.Text = (afterdisc * tax1 / 100).ToString("0.00");
            decimal aftertax = Convert.ToDecimal(txt_PartTaxAmount.Text);
            txt_PartTotal.Text = (afterdisc + aftertax).ToString("0.00");
        }
        else if (DropDownList1.SelectedIndex == 5)
        {
            decimal amnt = Convert.ToDecimal(txt_PartAmount.Text);
            decimal descamnt = Convert.ToDecimal(txt_PartDiscount.Text);
            decimal afterdisc = (amnt - descamnt);
            string tax = "2";
            decimal tax1 = Convert.ToDecimal(tax);
            txt_PartTaxAmount.Text = (afterdisc * tax1 / 100).ToString("0.00");
            decimal aftertax = Convert.ToDecimal(txt_PartTaxAmount.Text);
            txt_PartTotal.Text = (afterdisc + aftertax).ToString("0.00");
        }
    }
    protected void txt_PartRate_TextChanged(object sender, EventArgs e)
    {
        string branchname = Session["Branch"].ToString();
        var v = from k in db.AME_Master_Item.ToList()
                where (k.Itm_Partno.Equals(txt_PartNo.Text) && k.Branch_Name == branchname)
                select new
                {
                   // k.Itm_Partno,
                    k.Itm_PartDescrption,
                    k.Itm_SalePrice,
                    k.Itm_VatPercent
                };
        decimal vat = v.First().Itm_VatPercent;
        decimal rate = Convert.ToDecimal(txt_PartRate.Text);
        decimal temp = Convert.ToDecimal(rate / (100 + vat));
        decimal rt = temp * 100;

        decimal qty = Convert.ToDecimal(txt_PartQuantity.Text);

        decimal amnt = rate * qty;
        txt_PartAmount.Text = (amnt).ToString("0.00");
        //txt_PartRate.Text = (rate*qty).ToString("0.00");
        decimal vatper = 0;
        if (DropDownList1.SelectedIndex == 0)
        {
            vatper = 0;
        }
        else if (DropDownList1.SelectedIndex == 1)
        {
            vatper = Convert.ToDecimal(DropDownList1.SelectedValue);
        }
        else if (DropDownList1.SelectedIndex == 2)
        {
            vatper = Convert.ToDecimal(DropDownList1.SelectedValue);
        }
        else
        {
            vatper = Convert.ToDecimal(DropDownList1.SelectedValue);
        }
        decimal va = vatper / 100;
        decimal vaamnt = amnt * va;
        txt_PartTaxAmount.Text = vaamnt.ToString("0.00");
        txt_PartTotal.Text = (amnt + vaamnt).ToString("0.00");

        txt_PartDiscount.Text = "0";
        txt_PartDiscountper.Text = "0";
    }
}