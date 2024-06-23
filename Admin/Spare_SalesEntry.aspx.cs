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

    // static List<PartDetails> SPE = new List<PartDetails>();
    static List<PartDetails> SPE = new List<PartDetails>();

    Clear cl = new Clear();
    public string uname;

    decimal spare18 = 0, rate = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            //  SPE = new List<PartDetails>();
            if (ViewState["ran_Key"] != null)
            {
                SPE.RemoveAll(t => t.key == ViewState["ran_Key"].ToString());
            }


            string ran_Key = CreateRandomPassword1(5);

            ViewState["ran_Key"] = ran_Key;
            var mx = SPE.ToList();
            int slmax = 0;

            if (DebasishGlobal.sl > 0)
            {

                slmax = DebasishGlobal.sl + 1;
                DebasishGlobal.sl = slmax;
            }

            else
            {
                slmax = 1;
                DebasishGlobal.sl = 1;
            }

            //if (mx.Count > 0)
            //    slmax = (mx.Max(t => t.maxslno) + 1);
            //else
            //    slmax = 1;
            ViewState["maxs"] = Convert.ToString(slmax);
            // FillVoucherNo();
            FillVoucherNoSubmit();


            // SPE.RemoveAll(t => t.UserId == Session["Uid"].ToString());
            FillGrid();
            FillSlno();

            txt_BDate.Text = SmitaClass.IndianTime().ToString("dd/MM/yyyy");

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
    [System.Web.Services.WebMethod]
    public static string[] Getyear(string prefixText, int count)
    {

        AutoMobileEntities db = new AutoMobileEntities();
        return db.AME_FinacialYear.Where(n => n.finacialyear.Contains(prefixText)).OrderBy(n => n.finacialyear).Select(n => n.finacialyear).Distinct().Take(count).ToArray();
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
        string branch = HttpContext.Current.Session["Branch"].ToString();
        AutoMobileEntities db = new AutoMobileEntities();
        return db.AME_Master_Item.Where(n => n.Itm_Partno.Contains(prefixText) && n.Ms_Status == true && n.Branch_Name == branch).OrderBy(n => n.Itm_Partno).Select(n => n.Itm_Partno).Distinct().Take(count).ToArray();
    }

    [System.Web.Services.WebMethod]
    public static string[] GetPartDesc(string prefixText, int count)
    {
        string branch = HttpContext.Current.Session["Branch"].ToString();
        AutoMobileEntities db = new AutoMobileEntities();
        return db.AME_Master_Item.Where(n => n.Itm_PartDescrption.Contains(prefixText) && n.Ms_Status == true && n.Branch_Name == branch).OrderBy(n => n.Itm_PartDescrption).Select(n => n.Itm_PartDescrption).Distinct().Take(count).ToArray();
    }

    private void FillVoucherNo()
    {
       string branchname = Session["Branch"].ToString();
        string InvType = ddl_invtype.SelectedValue.ToString();
        if ((from c in db.AME_BillCounter where c.Branch_Name == branchname && c.BillType == "Spare_TaxSales" select c.BillCounter).Count() > 0)
        {
            int VNo = (int)(from c in db.AME_BillCounter where c.Branch_Name == branchname && c.BillType == "Spare_TaxSales" select c.BillCounter).Max();
           
            //if (ddl_invtype.SelectedItem.Text == "Tax Invoice")
            //{
            //    txt_BVoucherNo.Text = "T/" + Convert.ToString(VNo + 1);
            //}
            //else
            //{
            //    txt_BVoucherNo.Text = "R/" + Convert.ToString(VNo + 1);
            //}
            if (branchname == "Cuttack")
            {
                txt_BVoucherNo.Text = "LCTC/" + Convert.ToString(VNo + 1) + "/2018-19";
            }
            if (branchname == "Phulnakhara")
            {
                txt_BVoucherNo.Text = "LPHU/" + Convert.ToString(VNo + 1) + "/2018-19";
            }
            if (branchname == "Berhampur")
            {
                txt_BVoucherNo.Text = "LBRH/" + Convert.ToString(VNo + 1) + "/2018-19";
            }
            if (branchname == "Paradeep")
            {
                txt_BVoucherNo.Text = "PRD/" + Convert.ToString(VNo + 1) + "/2018-19";
            }
        }
        else
        {
            txt_BVoucherNo.Text = "Error";
        }
    
    }



    //this one call in pageload
    private bool FillVoucherNoSubmit()
    {
        Boolean isupdae = true;
        string branchname = Session["Branch"].ToString();
        string InvType = ddl_invtype.SelectedValue.ToString();

        string param = "@Billtype,@Branch";

        string paramvalue = InvType + "," + branchname;

        if ((from c in db.AME_BillCounter where c.Branch_Name == branchname && c.BillType == "Spare_TaxSales" select c.BillCounter).Count() > 0)
        {

            DataSet ds = smitaDbAccess.SPReturnDataSet("Getmaxcountersalesvoucherno", param, paramvalue);
            int V_No = 0;
            try
            {
                V_No = int.Parse(ds.Tables[0].Rows[0].ItemArray[0].ToString());
            }
            catch (Exception)
            {
                isupdae = false;
                //throw;
            }
            if (isupdae == true)
            {

                //if (ddl_invtype.SelectedItem.Text == "Tax Invoice")
                //{
                //    txt_BVoucherNo.Text = "T/" + Convert.ToString(V_No + 1);
                //}
                //else
                //{
                //    txt_BVoucherNo.Text = "R/" + Convert.ToString(V_No + 1);
                //}

                if (branchname == "Cuttack")
                {
                    txt_BVoucherNo.Text = "LCTC/" + Convert.ToString(V_No + 1) + "/2018-19";
                }
                if (branchname == "Phulnakhara")
                {
                    txt_BVoucherNo.Text = "LPHU/" + Convert.ToString(V_No + 1) + "/2018-19";
                }
                if (branchname == "Berhampur")
                {
                    txt_BVoucherNo.Text = "LBRH/" + Convert.ToString(V_No + 1) + "/2018-19";
                }
                if (branchname == "Paradeep")
                {
                    txt_BVoucherNo.Text = "PRD/" + Convert.ToString(V_No + 1) + "/2018-19";
                }

            }

            else
            {
                txt_BVoucherNo.Text = "Error";
            }
            //int VNo = (int)(from c in db.AME_BillCounter where c.Branch_Name == branchname && c.BillType == InvType select c.BillCounter).Max();

            //if (ddl_invtype.SelectedItem.Text == "Tax Invoice")
            //{
            //    txt_BVoucherNo.Text = "T/" + Convert.ToString(VNo + 1);
            //}
            //else
            //{
            //    txt_BVoucherNo.Text = "R/" + Convert.ToString(VNo + 1);
            //}
        }
        //else
        //{
        //    txt_BVoucherNo.Text = "Error";
        //}

        return isupdae;

    }
    private void FillSlno()
    {
        var v = SPE.ToList();
        if (v.Count() > 0)
        {
            txt_PartSlNo.Text = (v.Count() + 1).ToString();
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
            string branchname = Session["Branch"].ToString();
            //var v = from k in db.AME_Master_Customer.ToList()
            //        where (k.Mc_Name.Equals(txt_BName.Text) && k.Branch_Name==branchname)
            //        select new
            //        {
            //            k.Branch_Name,
            //            k.Mc_Address,
            //            k.Mc_code,
            //            k.Mc_Mobileno,
            //            k.Mc_Tin
            //        };

            DataSet ds1 = smitaDbAccess.returndataset("select Mc_Address AS Mc_Address , Mc_code as Mc_code , Mc_Mobileno as Mc_Mobileno , Mc_Tin as Mc_Tin    FROM AME_Master_Customer WHERE Mc_Name='" + txt_BName.Text.Trim() + "' AND Branch_Name='" + Session["Branch"].ToString() + "'");

            if (ds1.Tables[0].Rows[0].ItemArray[0].ToString() != "")
            {

                txt_BTinSrinNo.Text = ds1.Tables[0].Rows[0].ItemArray[3].ToString();
                txt_BName.ToolTip = ds1.Tables[0].Rows[0].ItemArray[1].ToString();
                txt_BAdress.Text = ds1.Tables[0].Rows[0].ItemArray[0].ToString();
                txt_PartNo.Focus();

            }



            else
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "MessagePopUp", "<script language='JavaScript'>alert('This Customer Not Registered..!!'); </script>", false);

                txt_BName.Text = "";
                txt_BName.ToolTip = "";
                txt_BTinSrinNo.Text = "";
                txt_BAdress.Text = "";
                return;
            }

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
            string branchname = Session["Branch"].ToString();
            
            
            
            string param3="@txt_PartNo,@branchname";
            string paramvalue3 =txt_PartNo.Text+","+branchname;
            DataSet dsall = smitaDbAccess.SPReturnDataSet("sp_GetDataNavlqty", param3, paramvalue3);
            
            
            txt_PartNo.Text = dsall.Tables[0].Rows[0][0].ToString();
            txt_PartDesc.Text = dsall.Tables[0].Rows[0][1].ToString();
            decimal rate = Convert.ToDecimal(dsall.Tables[0].Rows[0][2].ToString());
            txt_PartVat.Text = dsall.Tables[0].Rows[0][3].ToString();
            txt_category.Text = dsall.Tables[0].Rows[0][4].ToString();




            //var v = from k in db.AME_Master_Item.ToList()
            //        where (k.Itm_Partno.Equals(txt_PartNo.Text) && k.Branch_Name == branchname)
            //        select new
            //        {
            //            k.Itm_Partno,//0
            //            k.Itm_PartDescrption,//1
            //            k.Itm_SalePrice,//2
            //            k.Itm_VatPercent,//3
            //            k.Itm_CategoryName//4
            //        };


            //txt_PartNo.Text = v.First().Itm_Partno;
            //txt_PartDesc.Text = Convert.ToString(v.First().Itm_PartDescrption);
            //decimal rate = v.First().Itm_SalePrice;
            ////txt_PartRate.Text = Convert.ToString(v.First().Itm_SalePrice);
            //txt_PartVat.Text = Convert.ToString(v.First().Itm_VatPercent);
            //txt_category.Text = v.First().Itm_CategoryName;


           

            //DataSet ds = smitaDbAccess.returndataset("select SUM(Ss_NetQuantity) AS NetQuantity FROM AME_Spare_PurchaseEntry WHERE Itm_Partno='" + txt_PartNo.Text + "' AND Branch_Name='" + Session["Branch"].ToString() + "'");

            if (dsall.Tables[1].Rows[0].ItemArray[0].ToString() != "")
            {
                txt_AvlQty.Text = dsall.Tables[1].Rows[0].ItemArray[0].ToString();
            }
            else
            {
                txt_AvlQty.Text = "0";
            }
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
            txt_AvlQty.Text = "";
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
            //var v = from k in db.AME_Master_Item.ToList()
            //        where (k.Itm_PartDescrption.Equals(txt_PartDesc.Text) && k.Branch_Name == branchname)
            //        select new
            //        {
            //            k.Itm_Partno,
            //            k.Itm_PartDescrption,
            //            k.Itm_SalePrice,
            //            k.Itm_VatPercent,
            //            k.Itm_CategoryName
            //        };

            //txt_PartNo.Text = v.First().Itm_Partno;
            //txt_PartDesc.Text = Convert.ToString(v.First().Itm_PartDescrption);
            //txt_PartRate.Text = Convert.ToString(v.First().Itm_SalePrice);
            //txt_PartVat.Text = Convert.ToString(v.First().Itm_VatPercent);
            //txt_category.Text = v.First().Itm_CategoryName;

            DataSet ds1 = smitaDbAccess.returndataset("select Itm_Partno AS Itm_Partno , Itm_PartDescrption as Itm_PartDescrption ,Itm_SalePrice as Itm_SalePrice ,Itm_VatPercent as Itm_VatPercent , Itm_CategoryName as Itm_CategoryName   FROM AME_Master_Item WHERE Itm_PartDescrption='" + txt_PartDesc.Text.Trim() + "' AND Branch_Name='" + Session["Branch"].ToString() + "'");

            if (ds1.Tables[0].Rows[0].ItemArray[0].ToString() != "")
            {
                txt_PartNo.Text = ds1.Tables[0].Rows[0].ItemArray[0].ToString();
                txt_PartDesc.Text = ds1.Tables[0].Rows[0].ItemArray[1].ToString();
                // rate = Convert.ToDecimal( ds1.Tables[0].Rows[0].ItemArray[2]);
                txt_PartRate.Text = ds1.Tables[0].Rows[0].ItemArray[2].ToString();
                rate = Convert.ToDecimal(txt_PartRate.Text);
                txt_PartVat.Text = ds1.Tables[0].Rows[0].ItemArray[3].ToString();
                txt_category.Text = ds1.Tables[0].Rows[0].ItemArray[4].ToString();

            }
            else
            {
                txt_PartNo.Text = "0";
                txt_PartDesc.Text = "0";
                txt_PartRate.Text = "0";
                txt_PartVat.Text = "0";
                txt_category.Text = "0";
            }



            //DataSet ds = smitaDbAccess.returndataset("select SUM(Ss_NetQuantity) AS NetQuantity FROM AME_Spare_PurchaseEntry WHERE Itm_Partno='" + txt_PartNo.Text + "' AND Branch_Name='" + Session["Branch"].ToString() + "'");

            DataSet ds = smitaDbAccess.returndataset("select Ss_NetQuantity AS NetQuantity FROM AME_StockInventory WHERE Itm_Partno='" + txt_PartNo.Text.Trim() + "' AND Branch_Name='" + Session["Branch"].ToString() + "'");
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
    decimal countS5 = 0, countS13 = 0, countL5 = 0, countL13 = 0, countV13 = 0, countV5 = 0;
    decimal sparetot = 0, lubvaluetot = 0;
    decimal ttlspare28 = 0, ttldiccount28 = 0, ttltax28 = 0, ttlspare18 = 0, ttldiccount18 = 0, ttltax18 = 0;
    public void fillgrid()
    {

        foreach (GridViewRow gr in GridView2.Rows)
        {
            Label lbl_partno = (Label)gr.FindControl("Label10");
            Label lbl_partDesc = (Label)gr.FindControl("Label12");
            Label lbl_Quantity = (Label)gr.FindControl("Label11");
            Label lbl_Rate = (Label)gr.FindControl("Label14");
            Label lbl_Amount = (Label)gr.FindControl("Label13");//amount 143 after discount
            Label lbl_Discount = (Label)gr.FindControl("Label15");//dis count value
            Label lbl_Vat = (Label)gr.FindControl("Label16");//spare 18 na 28 janiba pain use heichi ...lol
            Label lbl_TaxAmt = (Label)gr.FindControl("Label17");//tax ammount
            Label lbl_Total = (Label)gr.FindControl("Label18");
            Label lblcategory = (Label)gr.FindControl("lblcategory");
            Label lbligst = (Label)gr.FindControl("Labeligst");
            Label lblsgst = (Label)gr.FindControl("LabelSGst");
            Label lblcgst = (Label)gr.FindControl("Labelcgst");
            decimal vat = Convert.ToDecimal(lbl_Vat.Text);
            decimal spre5amount = Convert.ToDecimal(lbl_Amount.Text);
            decimal igst = Convert.ToDecimal(lbligst.Text);

            if (txt_statecode.Text.Trim().Equals("21"))
            {
                lbligst.Visible = false;
                lblsgst.Visible = true;
                lblcgst.Visible = true;
            }

            else
            {
                lbligst.Visible = true;
                lblsgst.Visible = false;
                lblcgst.Visible = false;

            }
            if ((lblcategory.Text == "Spareparts" || lblcategory.Text == "Accessories" || lblcategory.Text == "Other") && lbl_Vat.Text == "5.00")
            {

                decimal vat13 = Convert.ToDecimal(lbl_TaxAmt.Text);

                countS5 = Convert.ToDecimal(countS5 + vat13);

                lbls5.Text = Convert.ToString(countS5);
                lbls5.Visible = true;
            }
            if ((lblcategory.Text == "Spareparts" || lblcategory.Text == "Accessories" || lblcategory.Text == "Other") && lbl_Vat.Text == "13.50")
            {

                decimal vat13 = Convert.ToDecimal(lbl_TaxAmt.Text);
                countS13 = Convert.ToDecimal(countS13 + vat13);

                lbls13.Text = Convert.ToString(countS13);

                lbls13.Visible = true;
            }

            else if (lblcategory.Text == "Lubricants" && lbl_Vat.Text == "28.00")
            {


                decimal vat13 = Convert.ToDecimal(lbl_TaxAmt.Text);
                decimal lubvalue = Convert.ToDecimal(lbl_Amount.Text);
                countL13 = Convert.ToDecimal(countL13 + vat13);
                lubvaluetot = Convert.ToDecimal(lubvaluetot + lubvalue);
                lbll13.Text = Convert.ToString(countL13);
                lbl_lubvalue.Text = Convert.ToString(lubvaluetot);
                //  lbll13.Visible = true;
            }
            else if (lblcategory.Text == "Lubricants" && lbl_Vat.Text == "18.00")
            {

                decimal vat13 = Convert.ToDecimal(lbl_TaxAmt.Text);

                countL5 = Convert.ToDecimal(countL5 + vat13);
                lbll5.Text = Convert.ToString(countL5);

                lbll5.Visible = true;
            }
            if ((lblcategory.Text == "Spareparts" || lblcategory.Text == "Accessories" || lblcategory.Text == "Other") && lbl_Vat.Text == "28.00")
            {

                decimal vat28 = Convert.ToDecimal(lbl_TaxAmt.Text);     //tax from grid last
                decimal spareamt28 = Convert.ToDecimal(lbl_Amount.Text);//spare ammount after discount
                decimal diccountamt28 = Convert.ToDecimal(lbl_Discount.Text);//discount value save here



                ttltax28 = Convert.ToDecimal(ttltax28 + vat28);
                ttlspare28 = Convert.ToDecimal(ttlspare28 + spareamt28);
                ttldiccount28 = Convert.ToDecimal(ttldiccount28 + diccountamt28);




                lbl_tax28final.Text = Convert.ToString(ttltax28);// output 28 %
                lbl_spate28final.Text = Convert.ToString(ttlspare28);//spare value 28
                lbl_dic28final.Text = Convert.ToString(ttldiccount28);

                // lblvat13.Visible = true;
            }
            else if ((lblcategory.Text == "Spareparts" || lblcategory.Text == "Accessories" || lblcategory.Text == "Other") && lbl_Vat.Text == "18.00")
            {


                decimal vat18 = Convert.ToDecimal(lbl_TaxAmt.Text);     //tax from grid last (output 28 as reoprst heading)
                decimal spareamt18 = Convert.ToDecimal(lbl_Amount.Text);//spare ammount after discount
                decimal diccountamt18 = Convert.ToDecimal(lbl_Discount.Text);//discount value save here



                ttltax18 = Convert.ToDecimal(ttltax18 + vat18);
                ttlspare18 = Convert.ToDecimal(ttlspare18 + spareamt18);
                ttldiccount18 = Convert.ToDecimal(ttldiccount18 + diccountamt18);




                lbl_tax18final.Text = Convert.ToString(ttltax18);// output 18 %
                lbl_spate18final.Text = Convert.ToString(ttlspare18); //spare value 18
                lbl_dic18final.Text = Convert.ToString(ttldiccount18); //dis aammt

                //decimal vat13 = Convert.ToDecimal(lbl_TaxAmt.Text);
                //decimal sparevalue = Convert.ToDecimal(lbl_Amount.Text);

                //countV5 = Convert.ToDecimal(countV5 + vat13);
                //spare18 = Convert.ToDecimal(spare18 + sparevalue);

                //lblvat5.Text = Convert.ToString(countV5);



                //lblvat5.Visible = true;
            }

        }
    }
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

            string branchname = Session["Branch"].ToString();
            var ChkPrdCode = from c in SPE.Where(t => t.Itm_Partno == txt_PartNo.Text && t.UserId == uname && t.branch == branchname && t.key == ViewState["ran_Key"].ToString()) select c;

            if (Convert.ToInt32(ChkPrdCode.Count()) > 0)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "MessagePopUp", "<script language='JavaScript'>alert('Same Part Already Added..!!!');</script>", false);
                txt_PartNo.Focus();
                return;
            }

            if (Convert.ToDecimal(txt_PartQuantity.Text) == 0)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "MessagePopUp", "<script language='JavaScript'>alert('You Have  Enter Quantity Is " + txt_PartQuantity.Text + "...!!!'); </script>", false);
                txt_PartQuantity.Focus();
                return;
            }
            if (Convert.ToDecimal(txt_AvlQty.Text) < Convert.ToDecimal(txt_PartQuantity.Text))
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "MessagePopUp", "<script language='JavaScript'>alert('You Dont Have More Stock,Your Available STock Is " + txt_AvlQty.Text + "...!!!'); </script>", false);
                txt_PartQuantity.Focus();
                return;
            }


            if (txt_PartVat.Text == "0.00" || txt_PartVat.Text == "0" || txt_PartVat.Text == "")
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "MessagePopUp", "<script language='JavaScript'>alert('Set gst Percentage first.....!!!!'); </script>", false);
                txt_PartVat.Focus();
                return;
            }





            









            PartDetails pr1 = new PartDetails();
            pr1.Itm_Partno = txt_PartNo.Text;
            pr1.Itm_PartDescrption = txt_PartDesc.Text;
            pr1.Ss_Quantity = Convert.ToDecimal(txt_PartQuantity.Text);
            pr1.Ss_Rate = Convert.ToDecimal(txt_PartRate.Text);
            pr1.Ss_Amount = Convert.ToDecimal(txt_PartAmount.Text);
            pr1.Ss_Discountper = Convert.ToDecimal(txt_PartDiscountper.Text);
            pr1.Ss_Discount = Convert.ToDecimal(txt_PartDiscount.Text);

            pr1.Ss_TaxAmont = Convert.ToDecimal(txt_PartTaxAmount.Text);
            pr1.Ss_Vat = Convert.ToDecimal(txt_PartVat.Text);
            pr1.Ss_CGst = Convert.ToDecimal(txt_PartTaxAmount.Text) / 2;
            pr1.Ss_SGst = Convert.ToDecimal(txt_PartTaxAmount.Text) / 2;
            pr1.Ss_Total = Convert.ToDecimal(txt_PartTotal.Text);
            pr1.UserId = Session["Uid"].ToString();
            pr1.branch = Session["Branch"].ToString();
            pr1.category = txt_category.Text;
            pr1.maxslno = Convert.ToInt32(ViewState["maxs"].ToString());
            pr1.key = ViewState["ran_Key"].ToString();
            SPE.Add(pr1);

            FillGrid();
            fillgrid();
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

            if (SPE.Count > 0)
                btn_Submit.Enabled = true;


        }
        catch
        {

        }
    }
    decimal tot1 = 0, tot2 = 0, tot3 = 0, tot4 = 0;
    private void FillGrid()
    {
        string branchname = Session["Branch"].ToString();
        int mx = Convert.ToInt32(ViewState["maxs"].ToString());
        string key11 = ViewState["ran_Key"].ToString();
        uname = Session["Uid"].ToString();
        var prd = (from c in SPE.ToList()
                   //where c.UserId == uname && c.branch==branchname && c.maxslno==mx
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
            txt_AFinalAmount.Text = Convert.ToString(Convert.ToDecimal(txt_ATotal.Text) + Convert.ToDecimal(txt_APackagingAmt.Text) + Convert.ToDecimal(txt_AOtherAmt.Text));
        }
    }
    protected void imgbtn_PartDelete_Click(object sender, ImageClickEventArgs e)
    {
        ImageButton img_delete = (ImageButton)sender;
        int mx = Convert.ToInt32(ViewState["maxs"].ToString());
        string branchname = Session["Branch"].ToString();
        SPE.RemoveAll(t => t.Itm_Partno == img_delete.ToolTip && t.branch == branchname && t.maxslno == mx);
        FillGrid();
        fillgrid();
        if (GridView2.Rows.Count <= 0)
        {
            txt_AGrossAmount.Text = "0.0";
            txt_ADiscountAmount.Text = "0.0";
            txt_ANetAmount.Text = "0.0";
            txt_AVatAmount.Text = "0.0";
            txt_ATotal.Text = "0.0";
            txt_APackagingAmt.Text = "0.0";
            txt_AOtherAmt.Text = "0.0";
            txt_AFinalAmount.Text = "0.0";
            btn_Submit.Enabled = false;

        }
    }


    protected void btn_Submit_Click(object sender, EventArgs e)
    {


        try
        {

            //if (txt_fcyear.SelectedValue.ToString() == "Select")
            //{
            //    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "MessagePopUp", "<script language='JavaScript'>alert('Please Select Finacial Year ..!!'); </script>", false);
            //    txt_fcyear.Focus();
            //    return;
            //}
            //if (txt_BVoucherNo.Text == "")
            //{
            //    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "MessagePopUp", "<script language='JavaScript'>alert('Invoice Number Should Not Be Blank..!!'); </script>", false);
            //    txt_BVoucherNo.Focus();
            //    return;
            //}
            //if (txt_BDate.Text == "")
            //{
            //    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "MessagePopUp", "<script language='JavaScript'>alert('Invoice Date Should Not Be Blank..!!'); </script>", false);
            //    txt_BDate.Focus();
            //    return;
            //}

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
            //if (txt_BName.Text == "")
            //{
            //    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "MessagePopUp", "<script language='JavaScript'>alert('Name Should Not Be Blank..!!'); </script>", false);
            //    txt_BName.Focus();
            //    return;
            //}
            //if (txt_BName.ToolTip == "")
            //{
            //    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "MessagePopUp", "<script language='JavaScript'>alert('Enter Name Again..!!'); </script>", false);
            //    txt_BName.Focus();
            //    return;
            //}

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
            //if (txt_BOrderDate.Text != "")
            //{
            //    if (!DateTime.TryParseExact(txt_BOrderDate.Text, formats, new CultureInfo("en-US"), DateTimeStyles.None, out expectedDate))
            //    {
            //        ScriptManager.RegisterStartupScript(this.Page, typeof(string), "", "alert('ENTER VALID DATE (DD/MMM/YYYY)..!!');", true);
            //        txt_BOrderDate.Focus();
            //        return;
            //    }
            //}

            //////////////////////////////////

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
            //if (txt_AOtherAmt.Text == "")
            //{
            //    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "MessagePopUp", "<script language='JavaScript'>alert('Other Amount Should Not Be Blank..!!'); </script>", false);
            //    txt_AOtherAmt.Focus();
            //    return;
            //}
            //if (txt_AFinalAmount.Text == "")
            //{
            //    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "MessagePopUp", "<script language='JavaScript'>alert('Final Amount Should Not Be Blank..!!'); </script>", false);
            //    txt_AFinalAmount.Focus();
            //    return;
            //}


            if (FillVoucherNoSubmit() == false)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "MessagePopUp", "<script language='JavaScript'>alert('Job Card Or Bill No already Closed..!!!');</script>", false);
                return;
            }


            Boolean check = true;
            string parts = "";
            foreach (GridViewRow gr in GridView2.Rows)
            {
                Label lbl_partno = (Label)gr.FindControl("Label10");
                Label lbl_partDesc = (Label)gr.FindControl("Label12");
                Label lbl_Quantity = (Label)gr.FindControl("Label11");
                Label lbl_Rate = (Label)gr.FindControl("Label14");
                Label lbl_Amount = (Label)gr.FindControl("Label13");
                Label lbl_Discountper = (Label)gr.FindControl("Label151");
                Label lbl_Discount = (Label)gr.FindControl("Label15");
                Label lbl_Vat = (Label)gr.FindControl("Label16");
                Label lbl_TaxAmt = (Label)gr.FindControl("Label17");
                Label lbl_Total = (Label)gr.FindControl("Label18");
                Label lblcategory = (Label)gr.FindControl("lblcategory");



                DataSet ds = smitaDbAccess.returndataset("select SUM(Ss_NetQuantity) AS NetQuantity FROM AME_Spare_PurchaseEntry WHERE Itm_Partno='" + lbl_partno.Text + "' AND Branch_Name='" + Session["Branch"].ToString() + "'");

                if (Convert.ToDecimal(ds.Tables[0].Rows[0].ItemArray[0].ToString()) < Convert.ToDecimal(lbl_Quantity.Text))
                {
                    check = false;
                    parts += lbl_partno.Text + ",";
                    //txt_netqty.Text = ds.Tables[0].Rows[0].ItemArray[0].ToString();
                }



            }


            if (check == false)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "MessagePopUp", "<script language='JavaScript'>alert('You Dont Have More Stock Of The Parts No " + parts + "...!!!'); </script>", false);
                return;
            }



            string branchname = Session["Branch"].ToString();
            var ChkInvoice = from c in db.AME_Service_JobcardFinalInvoice.Where(t => t.FI_InvoiceNo == txt_BVoucherNo.Text && t.Branch_Name == branchname) select c;
            FillVoucherNoSubmit();



            //if (Convert.ToInt32(ChkInvoice.Count()) > 0)
            //{
            //    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "MessagePopUp", "<script language='JavaScript'>alert('Please Press Submit button Again..!!!');</script>", false);
            //    FillVoucherNo();
            //    return;
            //}
            AME_Spare_SalesEntryBillDetails pd = new AME_Spare_SalesEntryBillDetails();
            pd.Sp_InvoiceNo = txt_BVoucherNo.Text;
            //  pd.jc_year = txt_year.Text.Trim();
            pd.jc_year = txt_fcyear.SelectedValue.ToString();
            pd.Sp_InvoiceDate = Convert.ToDateTime(txt_BDate.Text, SmitaClass.dateformat());
            pd.Sp_InvoiceType = ddl_invtype.SelectedValue.ToString();
            pd.Sp_SaleBy = ddl_BSaleBy.SelectedValue.ToString();
            pd.Sp_SaleType = ddl_BSaleType.SelectedValue.ToString();
            pd.Sp_ChalanNo = txt_BChalanNo0.Text;
            if (txt_BChallanDate.Text != "")
            {
                pd.Sp_ChalanDate = Convert.ToDateTime(txt_BChallanDate.Text, SmitaClass.dateformat());
            }
            //pd.Sp_OrderNo = txt_BOrderNo.Text;
            //if (txt_BOrderDate.Text != "")
            //{
            //    pd.Sp_OrderDate = Convert.ToDateTime(txt_BOrderDate.Text, SmitaClass.dateformat());
            //}
            pd.Sp_Mc_code = txt_BName.ToolTip;
            pd.Sp_Mc_Name = txt_BName.Text;
            pd.Sp_Adress = txt_BAdress.Text;
            pd.Sp_Vehicleno = txt_BVehicleno.Text;
            pd.Sp_GrossAmount = Convert.ToDecimal(txt_AGrossAmount.Text);
            pd.Sp_Discount = Convert.ToDecimal(txt_ADiscountAmount.Text);
            pd.Sp_NetAmount = Convert.ToDecimal(txt_ANetAmount.Text);
            pd.Sp_VatAmount = Convert.ToDecimal(txt_AVatAmount.Text);
            pd.Sp_TotalAmount = Convert.ToDecimal(txt_ATotal.Text);
            pd.Sp_PackagingAmount = Convert.ToDecimal(txt_APackagingAmt.Text);
            pd.Sp_OtherAmount = Convert.ToDecimal(txt_AOtherAmt.Text);
            pd.Sp_FinalAmount = Convert.ToDecimal(txt_AFinalAmount.Text);
            pd.Status = true;
            pd.Statecode = txt_statecode.Text;
            pd.placeofsupp = txt_place.Text;
            pd.gstflag = true;
            if (txt_statecode.Text.Trim().Equals("21"))
            {
                pd.scodeflag = false;
            }
            else
            {


                pd.scodeflag = true;
            }
            pd.Branch_Name = Session["Branch"].ToString();
            pd.Created_By = Session["Uid"].ToString();
            pd.Created_Date = SmitaClass.IndianTime();
            pd.Submittedby = submittedy.Text.Trim();
            db.AddToAME_Spare_SalesEntryBillDetails(pd);
            db.SaveChanges();

            foreach (GridViewRow gr in GridView2.Rows)
            {
                Label lbl_partno = (Label)gr.FindControl("Label10");
                Label lbl_partDesc = (Label)gr.FindControl("Label12");
                Label lbl_Quantity = (Label)gr.FindControl("Label11");
                Label lbl_Rate = (Label)gr.FindControl("Label14");
                Label lbl_Amount = (Label)gr.FindControl("Label13");
                Label lbl_Discountper = (Label)gr.FindControl("Label151");
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
                if (lbl_Quantity.Text != "" || lbl_Quantity.Text != "0")
                {

                    pe.Ss_Quantity = Convert.ToDecimal(lbl_Quantity.Text);
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "MessagePopUp", "<script language='JavaScript'>alert('Quantity Should Not Be Blank..!!'); </script>", false);
                    return;
                }
                pe.Ss_Rate = Convert.ToDecimal(lbl_Rate.Text);
                // pe.jc_year = txt_year.Text.Trim();
                pe.jc_year = txt_fcyear.SelectedValue.ToString();
                pe.Ss_Amount = Convert.ToDecimal(lbl_Amount.Text);
                pe.Ss_Discountper = Convert.ToDecimal(lbl_Discountper.Text);
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

                AME_Spare_SalesEntry1 pee = new AME_Spare_SalesEntry1();
                pee.Sp_InvoiceNo = txt_BVoucherNo.Text;
                pee.Itm_Partno = lbl_partno.Text;
                pee.Itm_PartDescrption = lbl_partDesc.Text;
                // pee.jc_year = txt_year.Text.Trim();
                pee.jc_year = txt_fcyear.SelectedValue.ToString();
                if (lbl_Quantity.Text != "" || lbl_Quantity.Text != "0")
                {

                    pee.Ss_Quantity = Convert.ToDecimal(lbl_Quantity.Text);
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "MessagePopUp", "<script language='JavaScript'>alert('Quantity Should Not Be Blank..!!'); </script>", false);
                    return;
                }
                pee.Ss_Rate = Convert.ToDecimal(lbl_Rate.Text);
                pee.Ss_Amount = Convert.ToDecimal(lbl_Amount.Text);
                pee.Ss_Discount = Convert.ToDecimal(lbl_Discount.Text);
                pee.Ss_Vat = Convert.ToDecimal(lbl_Vat.Text);
                pee.Ss_TaxAmont = Convert.ToDecimal(lbl_TaxAmt.Text);
                pee.Ss_Total = Convert.ToDecimal(lbl_Total.Text);
                pee.Ss_Status = "SE";
                pee.Status = true;
                pee.Itm_Category = lblcategory.Text;
                pee.Branch_Name = Session["Branch"].ToString();
                pee.Created_By = Session["Uid"].ToString();
                pee.Created_Date = SmitaClass.IndianTime();
                db.AddToAME_Spare_SalesEntry1(pee);
                db.SaveChanges();



                string[] CWParam1 = { "@Branch", "@Req_Qntity", "@ItmPartno" };
                string[] CWParamValue1 = { Session["Branch"].ToString(), lbl_Quantity.Text, lbl_partno.Text };



                smitaDbAccess.insertprocedurestockcoma("Sp_StockdispatchInSpareIssue", CWParam1, CWParamValue1);




            }
            AME_Daily_SpareSales_Report dsr = new AME_Daily_SpareSales_Report();
            dsr.DR_InvoiceNo = txt_BVoucherNo.Text;
            //  dsr.jc_year = txt_year.Text.Trim();
            dsr.jc_year = txt_fcyear.SelectedValue.ToString();

            dsr.DR_IDate = Convert.ToDateTime(txt_BDate.Text, SmitaClass.dateformat());
            dsr.DR_InvType = ddl_invtype.SelectedItem.Text;
            dsr.DR_InvStatus = "COUNTER";
            dsr.Dr_InvMode = ddl_BSaleBy.SelectedValue.ToString();
            dsr.JC_No = 0;



            //=================================================================================================final value save to database fro report

            dsr.Dr_Spare13_5 = Convert.ToDecimal(lbl_spate28final.Text);   //spare 28 spare value
            dsr.Dr_DiscountAmount3_5 = Convert.ToDecimal(lbl_dic28final.Text);
            dsr.Dr_Output13_5 = Convert.ToDecimal(lbl_tax28final.Text);



            dsr.Dr_Spare5 = Convert.ToDecimal(lbl_spate18final.Text);   //spare 18 spare value
            dsr.Dr_DiscountAmount5 = Convert.ToDecimal(lbl_dic18final.Text);
            dsr.Dr_Output5 = Convert.ToDecimal(lbl_tax18final.Text);









            //  dsr.Dr_Spare13_5 = Convert.ToDecimal(txt_ANetAmount.Text);
            //if (lbl_sparevale.Text == "")
            //{
            //    dsr.Dr_Spare13_5 = 0;
            //}
            //else
            //{

            //    dsr.Dr_Spare13_5 = Convert.ToDecimal(lbl_sparevale.Text);
            //}
            //dsr.Dr_Spare5 = spare18;
            //  dsr.Dr_Lub13_5 = Convert.ToDecimal(lbll13.Text);
            if (lbl_lubvalue.Text == "")
            {
                dsr.Dr_Lub13_5 = 0;
            }
            else
            {
                dsr.Dr_Lub13_5 = Convert.ToDecimal(lbl_lubvalue.Text);
            }

            dsr.Dr_Lub5 = Convert.ToDecimal(lbll5.Text);
            //dsr.Dr_DiscountAmount3_5 = Convert.ToDecimal(txt_ADiscountAmount.Text);
            //dsr.Dr_DiscountAmount5 = 0;

            //dsr.Dr_Output13_5 = Convert.ToDecimal(lblvat13.Text);
            // dsr.Dr_Output13_5 = Convert.ToDecimal(txt_AVatAmount.Text);

            //dsr.Dr_Output5 = Convert.ToDecimal(lblvat5.Text);
            dsr.Dr_OtherCharges = Convert.ToDecimal(txt_AOtherAmt.Text);
            dsr.Dr_Labourcharges = 0;
            dsr.Dr_NetLabourcharges = 0;
            dsr.Dr_Servtaxx12 = 0;
            dsr.Dr_Ecess2 = 0;
            dsr.Dr_Scess1 = 0;
            dsr.Dr_Roundoff = 0;
            dsr.Dr_Outsidejob = 0;
            dsr.Dr_Scess1 = Convert.ToDecimal(txt_APackagingAmt.Text);
            dsr.Dr_InvoiceTotal = Convert.ToDecimal(txt_AFinalAmount.Text);
            dsr.Dr_DisLabourcharges = 0;
            dsr.Statecode = txt_statecode.Text;
            dsr.placeofsupp = txt_place.Text;
            dsr.gstflag = true;
            if (txt_statecode.Text.Trim().Equals("21"))
            {
                dsr.scodeflag = false;
            }
            else
            {


                dsr.scodeflag = true;
            }
            dsr.Branch_Name = Session["Branch"].ToString();
            db.AddToAME_Daily_SpareSales_Report(dsr);
            db.SaveChanges();

            branchname = Session["Branch"].ToString();
            string InvType = ddl_invtype.SelectedValue.ToString();
            string year = txt_fcyear.SelectedValue.ToString();
            int id123 = (int)(from c in db.AME_BillCounter where c.Branch_Name == branchname && c.BillType == "Spare_TaxSales" select c.BillCounter).Max();
            AME_BillCounter OR = db.AME_BillCounter.First(t => t.Branch_Name == branchname && t.BillType == "Spare_TaxSales");
            OR.BillCounter = id123 + 1;
            db.SaveChanges();

            var v = from c in db.AME_Spare_SalesEntryBillDetails.Where(t => t.Branch_Name == branchname && t.Sp_InvoiceNo == txt_BVoucherNo.Text.Trim() && t.jc_year == year) select c.Sp_Id;
            Response.Redirect("Spare_SalesPrint.aspx?id=" + v.First() + "&No=" + txt_BVoucherNo.Text.Trim() + "&year=" + year);


            //ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "MessagePopUp", "<script language='JavaScript'>alert('Sale Done SuccessFully..!!'); </script>", false);
            //cl.Clear_All(this);
            //txt_PartDiscount.Text = "0";
            //txt_APackagingAmt.Text = "0";
            //txt_AOtherAmt.Text = "0";
            //lbls13.Text="0";
            //lbls13.Visible = false;
            //lbls5.Text="0";
            //lbls5.Visible=false;
            //lbll13.Text="0";
            //lbll13.Visible = false;
            //lbll5.Text = "0";
            //lbll5.Visible = false;
            //lblvat5.Text = "0";
            //lblvat5.Visible = false;
            //lblvat13.Text = "0";
            //lblvat13.Visible = false;
            //FillVoucherNo();
            //FillSlno();
            //SPE.RemoveAll(t => t.UserId == Session["Uid"].ToString());
            //FillGrid();
            SPE.RemoveAll(t => t.UserId == Session["Uid"].ToString());
            SPE.Clear();
        }
        catch
        {

        }
    }
    protected void btn_Cancel_Click(object sender, EventArgs e)
    {
        cl.Clear_All(this);
    }
    public void clear()
    {
        txt_PartNo.Text = "";
        txt_PartDesc.Text = "";
        txt_category.Text = "";
        txt_PartQuantity.Text = "";
        txt_AvlQty.Text = "";
        txt_PartRate.Text = "";
        txt_PartAmount.Text = "";
        txt_PartDiscount.Text = "0";
        txt_AVatAmount.Text = "";
        txt_ATotal.Text = "";
        txt_PartTaxAmount.Text = "";
    }
    public class PartDetails
    {
        public string Itm_Partno { get; set; }

        public string Itm_PartDescrption { get; set; }

        public decimal Ss_Quantity { get; set; }

        public decimal Ss_Rate { get; set; }

        public decimal Ss_Amount { get; set; }

        public decimal Ss_Discountper { get; set; }

        public decimal Ss_Discount { get; set; }

        public decimal Ss_Vat { get; set; }
        public decimal Ss_SGst { get; set; }
        public decimal Ss_CGst { get; set; }

        public decimal Ss_TaxAmont { get; set; }

        public decimal Ss_Total { get; set; }

        public string UserId { get; set; }

        public string category { get; set; }

        public string branch { get; set; }

        public int maxslno { get; set; }
        public string key { get; set; }

    }


    protected void ddl_invtype_SelectedIndexChanged(object sender, EventArgs e)
    {
        FillVoucherNo();
    }
    protected void txt_PartQuantity_TextChanged(object sender, EventArgs e)
    {
        decimal vat = Convert.ToDecimal(txt_PartVat.Text);

        decimal rate = Convert.ToDecimal(ViewState["rate"]);

        decimal rate1 = Convert.ToDecimal(txt_PartRate.Text);

        decimal temp = Convert.ToDecimal(rate / (100 + vat));
        decimal amnt = temp * 100;

        decimal qty = Convert.ToDecimal(txt_PartQuantity.Text);


        //   txt_PartAmount.Text = (amnt * qty).ToString("0.00");

        txt_PartAmount.Text = (rate1 * qty).ToString("0.00");

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
    protected void txt_APackagingAmt_TextChanged(object sender, EventArgs e)
    {

    }
    protected void btn_new_Click(object sender, EventArgs e)
    {
        ScriptManager.RegisterStartupScript(this.Page, typeof(string), "", "window.open('Master_CustomerRegistration.aspx','Graph','height=700,width=700');", true);

    }
}