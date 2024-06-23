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
    static List<ServiceDetails> SD = new List<ServiceDetails>();
    Clear cl = new Clear();
    public static string uname;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            FillCustomer();
            FillVModel();
            FillEstimateNo();
          //  if(uname != Session["Uid"].ToString())
            SPE.RemoveAll(t => t.UserId == Session["Uid"].ToString());
            FillGrid();
            FillSlno();
            txt_BEstimateDate.Text = SmitaClass.IndianTime().ToString("dd/MM/yyyy");
            SD.RemoveAll(t => t.UserId == Session["Uid"].ToString());
            FillServiceGrid();
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

    [System.Web.Services.WebMethod]
    public static string[] GetServiceCode(string prefixText, int count)
    {

        
        string branch = HttpContext.Current.Session["Branch"].ToString();
        if (HttpContext.Current.Session["saletype"]!=null)
        {
            string Sale = HttpContext.Current.Session["saletype"].ToString();
            AutoMobileEntities db = new AutoMobileEntities();
            return db.AME_Master_ServiceHead.Where(n => n.Mh_ServiceCode.Contains(prefixText) && n.Branch_Name == branch && n.Mh_SaleStatus == Sale).OrderBy(n => n.Mh_ServiceCode).Select(n => n.Mh_ServiceCode).Distinct().Take(count).ToArray();
        }
        else
        {
           
            AutoMobileEntities db = new AutoMobileEntities();
            return db.AME_Master_ServiceHead.Where(n => n.Mh_ServiceCode.Contains(prefixText) && n.Branch_Name == branch).OrderBy(n => n.Mh_ServiceCode).Select(n => n.Mh_ServiceCode).Distinct().Take(count).ToArray();
        }
       
    }
    [System.Web.Services.WebMethod]
    public static string[] GetServiceDesc(string prefixText, int count)
    {

        string Sale = HttpContext.Current.Session["saletype"].ToString();
        string branch = HttpContext.Current.Session["Branch"].ToString();
        if (HttpContext.Current.Session["saletype"] != null)
        {
            AutoMobileEntities db = new AutoMobileEntities();
            return db.AME_Master_ServiceHead.Where(n => n.Mh_ServiceHead.Contains(prefixText) && n.Branch_Name == branch && n.Mh_SaleStatus == Sale).OrderBy(n => n.Mh_ServiceHead).Select(n => n.Mh_ServiceHead).Distinct().Take(count).ToArray();
        }
        else
        {
            AutoMobileEntities db = new AutoMobileEntities();
            return db.AME_Master_ServiceHead.Where(n => n.Mh_ServiceHead.Contains(prefixText) && n.Branch_Name == branch).OrderBy(n => n.Mh_ServiceHead).Select(n => n.Mh_ServiceHead).Distinct().Take(count).ToArray();
        }

    }
    private void FillCustomer()
    {
        string Sale = Convert.ToString(Session["saletype"]);
        if (Session["saletype"] != null)
        {
            var v = from c in db.AME_Master_Customer.ToList().OrderBy(t => t.Mc_Name)
                    where c.Mc_Status = true && c.Branch_Name == Session["Branch"].ToString() && c.Mc_SaleStatus == Sale
                    select new
                    {
                        Cu_Name = c.Mc_Name + " - " + c.Mc_Mobileno,
                        Cu_Code = c.Mc_code
                    };
            ddl_BCustomer.DataSource = v.ToList();
            ddl_BCustomer.DataTextField = "Cu_Name";
            ddl_BCustomer.DataValueField = "Cu_Code";
            ddl_BCustomer.DataBind();
            ddl_BCustomer.Items.Insert(0, "--Select One--");
        }
        else
        {
            var v = from c in db.AME_Master_Customer.ToList().OrderBy(t => t.Mc_Name)
                    where c.Mc_Status = true && c.Branch_Name == Session["Branch"].ToString()
                    select new
                    {
                        Cu_Name = c.Mc_Name + " - " + c.Mc_Mobileno,
                        Cu_Code = c.Mc_code
                    };
            ddl_BCustomer.DataSource = v.ToList();
            ddl_BCustomer.DataTextField = "Cu_Name";
            ddl_BCustomer.DataValueField = "Cu_Code";
            ddl_BCustomer.DataBind();
            ddl_BCustomer.Items.Insert(0, "--Select One--");
        }
        
    }

    private void FillVModel()
    {
        string Sale = Convert.ToString(Session["saletype"]);
        if (Session["saletype"] != null)
        {
            var v = from c in db.AME_Master_VehicleModel.ToList().OrderBy(t => t.Mv_ModelName)
                    where c.Status = true && c.Branch_Name == Session["Branch"].ToString() && c.Mv_SaleStatus == Sale
                    select new
                    {
                        Cu_Name = c.Mv_ModelName,
                        Cu_Code = c.Mv_Code
                    };
            ddl_BModel.DataSource = v.ToList();
            ddl_BModel.DataTextField = "Cu_Name";
            ddl_BModel.DataValueField = "Cu_Code";
            ddl_BModel.DataBind();
            ddl_BModel.Items.Insert(0, "--Select One--");
        }
        else
        {
            var v = from c in db.AME_Master_VehicleModel.ToList().OrderBy(t => t.Mv_ModelName)
                    where c.Status = true && c.Branch_Name == Session["Branch"].ToString()
                    select new
                    {
                        Cu_Name = c.Mv_ModelName,
                        Cu_Code = c.Mv_Code
                    };
            ddl_BModel.DataSource = v.ToList();
            ddl_BModel.DataTextField = "Cu_Name";
            ddl_BModel.DataValueField = "Cu_Code";
            ddl_BModel.DataBind();
            ddl_BModel.Items.Insert(0, "--Select One--");
        }
       
    }
    private void FillEstimateNo()
    {
        string branchname = Session["Branch"].ToString();
        if ((from c in db.AME_Service_EstimateEntryDetails where c.Branch_Name == branchname select c.Se_EstimateNo).Count() > 0)
        {
            int VNo = (int)(from c in db.AME_Service_EstimateEntryDetails where c.Branch_Name == branchname select c.Se_EstimateNo).Max();
            txt_BEstimateNo.Text = Convert.ToString(VNo + 1);
        }
        else
        {
            txt_BEstimateNo.Text = "1";
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
            string branch = Session["Branch"].ToString();
            var v = from k in db.AME_Master_Item.ToList()
                    where (k.Itm_Partno.Equals(txt_PartNo.Text) && k.Branch_Name==branch)
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
            txt_PartQuantity.Focus();
        }
        catch(Exception ex)
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
            var v = from k in db.AME_Master_Item.ToList()
                    where (k.Itm_PartDescrption.Trim().Equals(txt_PartDesc.Text.Trim()))
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
        if (txt_BEstimateNo.Text == "")
        {
            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "MessagePopUp", "<script language='JavaScript'>alert('Voucher Number Should Not Be Blank..!!'); </script>", false);
            txt_BEstimateNo.Focus();
            return;
        }
        if (ddl_BCustomer.SelectedIndex == 0)
        {
            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "MessagePopUp", "<script language='JavaScript'>alert('Select Supplier Name..!!'); </script>", false);
            ddl_BCustomer.Focus();
            return;
        }
        if (txt_BEstimateDate.Text == "")
        {
            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "MessagePopUp", "<script language='JavaScript'>alert('Estimate Date Should Not Be Blank..!!'); </script>", false);
            txt_BEstimateDate.Focus();
            return;
        }

        if (ddl_BModel.SelectedIndex == 0)
        {
            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "MessagePopUp", "<script language='JavaScript'>alert('Select Model Name..!!'); </script>", false);
            ddl_BModel.Focus();
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

        string[] formats = { "dd/MM/yyyy", "d/M/yyyy", "dd/M/yyyy", "d/MM/yyyy", "dd/MMM/yyyy", "dd-MM-yyyy" };
        DateTime expectedDate;
        if (!DateTime.TryParseExact(txt_BEstimateDate.Text, formats, new CultureInfo("en-US"), DateTimeStyles.None, out expectedDate))
        {
            ScriptManager.RegisterStartupScript(this.Page, typeof(string), "", "alert('ENTER VALID DATE (DD/MMM/YYYY)..!!');", true);
            txt_BEstimateDate.Focus();
            return;
        }


        PartDetails pr1 = new PartDetails();
         var v = SPE.ToList();
         int max = 0;
        if(v.Count > 0)
          max =  v.Max(t => t.slno);
        pr1.slno = max + 1;
        pr1.Itm_Partno = txt_PartNo.Text;
        pr1.Itm_PartDescrption = txt_PartDesc.Text;
        pr1.Ss_Quantity = Convert.ToDecimal(txt_PartQuantity.Text);
        pr1.Ss_Rate = Convert.ToDecimal(txt_PartRate.Text);
        pr1.Ss_Amount = Convert.ToDecimal(txt_PartAmount.Text);
        pr1.Ss_DiscountPer = Convert.ToDecimal(txt_PartDiscountper.Text);
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
        txt_PartDiscount.Text = "0";
        txt_PartDiscountper.Text = "0";
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
       string branch = Session["Branch"].ToString();
        var prd = (from c in SPE.ToList()
                   where c.UserId == uname && c.branch==branch 
                   select c).ToList();
        GridView2.DataSource = prd.ToList();
        GridView2.DataBind();
        //if (Convert.ToInt32(prd.Count())>0)
        if (GridView2.Rows.Count > 0)
        {
            foreach (GridViewRow gr in GridView2.Rows)
            {
                Label lbl_amnt = (Label)gr.FindControl("Label13");
                decimal amnt = Convert.ToDecimal(lbl_amnt.Text);

                Label lbl_Total = (Label)gr.FindControl("Label18");
                decimal Total = Convert.ToDecimal(lbl_Total.Text);

                Label lbl_disc = (Label)gr.FindControl("Label15");
                decimal disc = Convert.ToDecimal(lbl_disc.Text);

                Label lbl_tax = (Label)gr.FindControl("Label17");
                decimal tax = Convert.ToDecimal(lbl_tax.Text);

                tot1 = tot1 + Total;
                tot2 = tot2 + amnt;
                tot3 = tot3 + disc;
                tot4 = tot4 + tax;


                txt_AVatAmount.Text = Convert.ToString(SmitaClass.SignificantTruncate(tot4, 2));
                txt_AGrossAmount.Text = Convert.ToString(SmitaClass.SignificantTruncate(tot2, 2));
                txt_ASerDiscountAmount.Text = Convert.ToString(SmitaClass.SignificantTruncate(tot3, 2));

                txt_ATotalSpareAmount.Text = Convert.ToString(SmitaClass.SignificantTruncate(tot1, 2));
                txt_ttotalAmount.Text = Convert.ToString(SmitaClass.SignificantTruncate(tot1, 2));
                //txt_BillAmount.Text = Convert.ToString(Convert.ToDecimal(txt_StotalAmount.Text) + Convert.ToDecimal(txt_TotalSpareAmount.Text));
                txt_ANetAmount.Text = Convert.ToString(Convert.ToDecimal(txt_AGrossAmount.Text) - Convert.ToDecimal(txt_ASerDiscountAmount.Text));

                decimal totallabour = Convert.ToDecimal(txt_ALabourCharges.Text);
                decimal totalspare = Convert.ToDecimal(txt_ATotalSpareAmount.Text);
                decimal serviceper = Convert.ToDecimal(txt_AServiceTaxPer.Text);
                decimal afterservice = totallabour * (serviceper / 100);
                txt_AServiceTaxAmt.Text = afterservice.ToString("0.00");
                decimal bill = afterservice + totalspare + totallabour;
                txt_ABillAmount.Text = bill.ToString("0.00");
            }
        }
        else 
        {

            txt_AVatAmount.Text = "0.00";

            txt_AGrossAmount.Text = "0.00";
            txt_ASerDiscountAmount.Text = "0.00";

            txt_ATotalSpareAmount.Text = "0.00";
            txt_ttotalAmount.Text = "0.00";
           
            txt_ANetAmount.Text = "0.00";
            decimal totallabour = Convert.ToDecimal(txt_ALabourCharges.Text);
            decimal totalspare = Convert.ToDecimal(txt_ATotalSpareAmount.Text);
            decimal serviceper = Convert.ToDecimal(txt_AServiceTaxPer.Text);
            decimal afterservice = totallabour * (serviceper / 100);
            txt_AServiceTaxAmt.Text = afterservice.ToString("0.00");
            decimal bill = afterservice + totalspare + totallabour;
            txt_ABillAmount.Text = bill.ToString("0.00");
        }
       
        
    }
    protected void imgbtn_PartDelete_Click(object sender, ImageClickEventArgs e)
    {
        ImageButton img_delete = (ImageButton)sender;
        string branch = Session["Branch"].ToString();
        int deleteno = 0;
        //foreach (GridViewRow gr in GridView2.Rows)
        //{
        //    Label lbl_delete_Sl = (Label)gr.FindControl("lbl_SL_NO_Delete");
        //     deleteno = Convert.ToInt32(lbl_delete_Sl.Text);
        //}
        GridViewRow row = (GridViewRow)img_delete.NamingContainer;
        //int rowind = row.RowIndex;
        Label deletelbl = (Label)row.FindControl("lbl_SL_NO_Delete");
        deleteno = Convert.ToInt32(deletelbl.Text);
        //SPE.RemoveAll(t => t.Itm_Partno == img_delete.ToolTip && t.branch==branch && t.slno == 1);
        if(deleteno > 0)
            SPE.RemoveAll(t => t.Itm_Partno == img_delete.ToolTip && t.branch == branch && t.slno == deleteno);
        FillGrid();
    }

    protected void btn_Submit_Click(object sender, EventArgs e)
    {
        try
        {
            if (txt_BEstimateNo.Text == "")
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "MessagePopUp", "<script language='JavaScript'>alert('Voucher Number Should Not Be Blank..!!'); </script>", false);
                txt_BEstimateNo.Focus();
                return;
            }
            if (ddl_BCustomer.SelectedIndex == 0)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "MessagePopUp", "<script language='JavaScript'>alert('Select Supplier Name..!!'); </script>", false);
                ddl_BCustomer.Focus();
                return;
            }
            if (txt_BEstimateDate.Text == "")
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "MessagePopUp", "<script language='JavaScript'>alert('Estimate Date Should Not Be Blank..!!'); </script>", false);
                txt_BEstimateDate.Focus();
                return;
            }

            if (ddl_BModel.SelectedIndex == 0)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "MessagePopUp", "<script language='JavaScript'>alert('Select Model Name..!!'); </script>", false);
                ddl_BModel.Focus();
                return;
            }


            if (txt_AGrossAmount.Text == "")
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "MessagePopUp", "<script language='JavaScript'>alert('Gross Amount Should Not Be Blank..!!'); </script>", false);
                txt_AGrossAmount.Focus();
                return;
            }
            if (txt_ASerDiscountAmount.Text == "")
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "MessagePopUp", "<script language='JavaScript'>alert('Discount Amount Should Not Be Blank..!!'); </script>", false);
                txt_ASerDiscountAmount.Focus();
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

            if (txt_AOtherAmount.Text == "")
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "MessagePopUp", "<script language='JavaScript'>alert('Other Amount Should Not Be Blank..!!'); </script>", false);
                txt_AOtherAmount.Focus();
                return;
            }
            if (txt_ABillAmount.Text == "" || txt_ABillAmount.Text == "0" || txt_ABillAmount.Text == "0.00")
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "MessagePopUp", "<script language='JavaScript'>alert('Bill Amount Should Not Be Blank Or Zero..!!'); </script>", false);
                txt_ABillAmount.Focus();
                return;
            }
            string[] formats = { "dd/MM/yyyy", "d/M/yyyy", "dd/M/yyyy", "d/MM/yyyy", "dd/MMM/yyyy", "dd-MM-yyyy" };
            DateTime expectedDate;
            if (!DateTime.TryParseExact(txt_BEstimateDate.Text, formats, new CultureInfo("en-US"), DateTimeStyles.None, out expectedDate))
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(string), "", "alert('ENTER VALID DATE (DD/MMM/YYYY)..!!');", true);
                txt_BEstimateDate.Focus();
                return;
            }
            decimal billamount = Convert.ToDecimal(txt_ABillAmount.Text);
            decimal no = Math.Round(billamount,2);

            AME_Service_EstimateEntryDetails pd = new AME_Service_EstimateEntryDetails();
            pd.Se_EstimateNo = Convert.ToInt32(txt_BEstimateNo.Text);
            pd.Se_EstimateDate = Convert.ToDateTime(txt_BEstimateDate.Text, SmitaClass.dateformat());
            pd.Se_CustomerCode = ddl_BCustomer.SelectedValue.ToString();
            pd.Se_VehicleModel = ddl_BModel.SelectedValue.ToString();
            pd.Se_RegdNo = txt_BRegdNo.Text;
            pd.Se_ChasisNo = txt_BChasisNo.Text;
            pd.Se_EngineNo = txt_BEngineNo.Text;
            if (txt_BSaleDate.Text != "")
            {
                pd.Se_SaleDate = Convert.ToDateTime(txt_BSaleDate.Text, SmitaClass.dateformat());
            }
            pd.Se_Kilometer = txt_BKiloMeter.Text;
            pd.Se_ServiceGrossAmount = Convert.ToDecimal(txt_AGrossAmount.Text);
            //pd.Se_ServiceDiscountPer = Convert.ToDecimal(txt_ASerDiscountPer.Text);
            pd.Se_ServiceDiscountAmt = Convert.ToDecimal(txt_ASerDiscountAmount.Text);
            pd.Se_ServiceNetAmount = Convert.ToDecimal(txt_ANetAmount.Text);
            pd.Se_VatAmount = Convert.ToDecimal(txt_AVatAmount.Text);
            pd.Se_TotalSpareAmount = Convert.ToDecimal(txt_ATotalSpareAmount.Text);
            pd.Se_TotalDiscountPerSpare = Convert.ToDecimal(txt_tdiscper.Text);
            pd.Se_TotalDiscountSpare = Convert.ToDecimal(txt_tdiscamnt.Text);
            pd.Se_GTotalOfSpare = Convert.ToDecimal(txt_ttotalAmount.Text);

            pd.Se_LabourCharges = Convert.ToDecimal(txt_ALabourCharges.Text);
            pd.Se_LabourDiscountPer = Convert.ToDecimal(txt_ALabDiscountPer.Text);
            pd.Se_LabourDiscountAmount = Convert.ToDecimal(txt_ALabDiscountAmount.Text);
            pd.Se_NetLabourCharges = Convert.ToDecimal(txt_ALabourChargesAftDisc.Text);
            pd.Se_ServiceTaxPer = Convert.ToDecimal(txt_AServiceTaxPer.Text);
            pd.Se_ServiceTaxAmount = Convert.ToDecimal(txt_AServiceTaxAmt.Text);
            pd.Se_OtherCharges = Convert.ToDecimal(txt_AOtherAmount.Text);
            pd.Se_BillAmount = no;
            pd.Status = true;
            //pd.Statecode = txt_statecode.Text.Trim();
            //pd.placeofsupp = txt_supp.Text;
            //if (txt_statecode.Text.Trim().Equals("21"))
            //{
            //    pd.scodeflag = false;
            //}
            //else
            //{


            //    pd.scodeflag = true;
            //}
            //pd.gstflag = true;
            pd.Branch_Name = Session["Branch"].ToString();
            pd.Created_By = Session["Uid"].ToString();
            pd.Created_Date = SmitaClass.IndianTime();
            db.AddToAME_Service_EstimateEntryDetails(pd);
            db.SaveChanges();

            foreach (GridViewRow gr in GridView2.Rows)
            {
                Label lbl_partno = (Label)gr.FindControl("Label10");
                Label lbl_partDesc = (Label)gr.FindControl("Label12");
                Label lbl_Quantity = (Label)gr.FindControl("Label11");
                Label lbl_Rate = (Label)gr.FindControl("Label14");
                Label lbl_Amount = (Label)gr.FindControl("Label13");
                Label lbl_Discount = (Label)gr.FindControl("Label15");
                Label lbl_discper = (Label)gr.FindControl("lbl_discper");
                Label lbl_Vat = (Label)gr.FindControl("Label16");
                Label lbl_TaxAmt = (Label)gr.FindControl("Label17");
                Label lbl_Total = (Label)gr.FindControl("Label18");

                AME_Service_EstimateSpareDetails pe = new AME_Service_EstimateSpareDetails();
                pe.Se_EstimateNo = Convert.ToInt32(txt_BEstimateNo.Text);
                pe.Itm_Partno = lbl_partno.Text;
                pe.Itm_PartDescrption = lbl_partDesc.Text;
                pe.Se_Quantity = Convert.ToDecimal(lbl_Quantity.Text);
                pe.Se_Rate = Convert.ToDecimal(lbl_Rate.Text);
                pe.Se_Amount = Convert.ToDecimal(lbl_Amount.Text);
                pe.Se_Discount = Convert.ToDecimal(lbl_Discount.Text);
                pe.Se_DiscountPer = Convert.ToDecimal(lbl_discper.Text);
                pe.Se_Vat = Convert.ToDecimal(lbl_Vat.Text);
                pe.Se_TaxAmont = Convert.ToDecimal(lbl_TaxAmt.Text);
                pe.Se_Total = Convert.ToDecimal(lbl_Total.Text);
                pe.Status = true;
                //pe.Statecode = txt_statecode.Text.Trim();
                //pe.placeofsupp = txt_supp.Text;
                //if (txt_statecode.Text.Trim().Equals("21"))
                //{
                //    pe.scodeflag = false;
                //}
                //else
                //{


                //    pe.scodeflag = true;
                //}
                //pe.gstflag = true;
                pe.Branch_Name = Session["Branch"].ToString();
                pe.Created_By = Session["Uid"].ToString();
                pe.Created_Date = SmitaClass.IndianTime();
                db.AddToAME_Service_EstimateSpareDetails(pe);
                db.SaveChanges();
            }

            foreach (GridViewRow gr in GridView1.Rows)
            {
                Label lbl_ServiceCode = (Label)gr.FindControl("Labels2");
                Label lbl_Desc = (Label)gr.FindControl("Labels3");
                Label lbl_Quantity = (Label)gr.FindControl("Labels4");
                Label lbl_Rate = (Label)gr.FindControl("Labels5");
                Label lbl_Amount = (Label)gr.FindControl("Labels6");

                AME_Service_EstimateServiceDetails pe = new AME_Service_EstimateServiceDetails();
                pe.Se_EstimateNo = Convert.ToInt32(txt_BEstimateNo.Text);
                pe.Mh_ServiceCode = lbl_ServiceCode.Text;
                pe.Mh_ServiceHead = lbl_Desc.Text;
                pe.Se_Quantity = Convert.ToDecimal(lbl_Quantity.Text);
                pe.Se_Rate = Convert.ToDecimal(lbl_Rate.Text);
                pe.Se_Amount = Convert.ToDecimal(lbl_Amount.Text);
                pe.Status = true;
                //pe.Statecode = txt_statecode.Text.Trim();
                //pe.placeofsupp = txt_supp.Text;
                //if (txt_statecode.Text.Trim().Equals("21"))
                //{
                //    pe.scodeflag = false;
                //}
                //else
                //{


                //    pe.scodeflag = true;
                //}
                //pe.gstflag = true;
                pe.Branch_Name = Session["Branch"].ToString();
                pe.Created_By = Session["Uid"].ToString();
                pe.Created_Date = SmitaClass.IndianTime();
                db.AddToAME_Service_EstimateServiceDetails(pe);
                db.SaveChanges();
            }
            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "MessagePopUp", "<script language='JavaScript'>alert('ESTIMATE Entry done SuccessFully..!!'); </script>", false);

            FillCustomer();
            FillVModel();

            SPE.RemoveAll(t => t.UserId == Session["Uid"].ToString());
            FillGrid();

            SD.RemoveAll(t => t.UserId == Session["Uid"].ToString());
            FillServiceGrid();
            Session["Estimationno"] = txt_BEstimateNo.Text;
            Response.Redirect("Print_JobEstimation.aspx");
        }
        catch
        {

        }
    }
    protected void btn_Cancel_Click(object sender, EventArgs e)
    {
        cl.Clear_All(this);
        FillCustomer();
        FillVModel();
        FillEstimateNo();
        SPE.RemoveAll(t => t.UserId == Session["Uid"].ToString());
        FillGrid();
        FillSlno();
        SD.RemoveAll(t => t.UserId == Session["Uid"].ToString());
        FillServiceGrid();
    }

    protected void txt_SCode_TextChanged(object sender, EventArgs e)
    {
        try
        {
            string branch = Session["Branch"].ToString();
            var v = from k in db.AME_Master_ServiceHead.ToList()
                    where (k.Mh_ServiceCode.Equals(txt_SCode.Text) && k.Branch_Name==branch)
                    select new
                    {
                        k.Mh_ServiceHead,
                        k.Mh_ServiceCode,
                        k.Mh_ServiceRate
                    };

            txt_SCode.Text = v.First().Mh_ServiceCode;
            txt_SDescription.Text = Convert.ToString(v.First().Mh_ServiceHead);
            txt_SRate.Text = Convert.ToString(v.First().Mh_ServiceRate);
            txt_SQuantity.Focus();
        }
        catch
        {
            txt_SCode.Text = "";
            txt_SDescription.Text = "";
            txt_SRate.Text = "";
            txt_SQuantity.Focus();
        }
    }
    protected void txt_SDescription_TextChanged(object sender, EventArgs e)
    {
        try
        {
            string branch = Session["Branch"].ToString();
            var v = from k in db.AME_Master_ServiceHead.ToList()
                    where (k.Mh_ServiceHead.Equals(txt_SDescription.Text.Trim()) && k.Branch_Name == branch)
                    select new
                    {
                        k.Mh_ServiceHead,
                        k.Mh_ServiceCode,
                        k.Mh_ServiceRate
                    };

            txt_SCode.Text = v.First().Mh_ServiceCode;
            txt_SDescription.Text = Convert.ToString(v.First().Mh_ServiceHead);
            txt_SRate.Text = Convert.ToString(v.First().Mh_ServiceRate);
            txt_SQuantity.Focus();
        }
        catch
        {
            txt_SCode.Text = "";
            txt_SDescription.Text = "";
            txt_SRate.Text = "";
            txt_SQuantity.Focus();
        }
    }
    protected void btn_ServiceAdd_Click(object sender, EventArgs e)
    {
        if (txt_BEstimateNo.Text == "")
        {
            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "MessagePopUp", "<script language='JavaScript'>alert('Voucher Number Should Not Be Blank..!!'); </script>", false);
            txt_BEstimateNo.Focus();
            return;
        }
        if (ddl_BCustomer.SelectedIndex == 0)
        {
            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "MessagePopUp", "<script language='JavaScript'>alert('Select Customer Name..!!'); </script>", false);
            ddl_BCustomer.Focus();
            return;
        }
        if (txt_BEstimateDate.Text == "")
        {
            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "MessagePopUp", "<script language='JavaScript'>alert('Estimate Date Should Not Be Blank..!!'); </script>", false);
            txt_BEstimateDate.Focus();
            return;
        }

        if (ddl_BModel.SelectedIndex == 0)
        {
            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "MessagePopUp", "<script language='JavaScript'>alert('Select Model Name..!!'); </script>", false);
            ddl_BModel.Focus();
            return;
        }

        //////////////////////////////////

        if (txt_SCode.Text == "")
        {
            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "MessagePopUp", "<script language='JavaScript'>alert('Service Code Should Not Be Blank..!!'); </script>", false);
            txt_SCode.Focus();
            return;
        }
        if (txt_SDescription.Text == "")
        {
            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "MessagePopUp", "<script language='JavaScript'>alert('Description Should Not Be Blank..!!'); </script>", false);
            txt_SDescription.Focus();
            return;
        }

        if (txt_SQuantity.Text == "")
        {
            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "MessagePopUp", "<script language='JavaScript'>alert('Quantity Should Not Be Blank..!!'); </script>", false);
            txt_SQuantity.Focus();
            return;
        }

        if (txt_SRate.Text == "")
        {
            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "MessagePopUp", "<script language='JavaScript'>alert('Rate Should Not Be Blank..!!'); </script>", false);
            txt_SRate.Focus();
            return;
        }
        if (txt_SAmount.Text == "")
        {
            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "MessagePopUp", "<script language='JavaScript'>alert('Amount Should Not Be Blank..!!'); </script>", false);
            txt_SAmount.Focus();
            return;
        }


        ServiceDetails pr1 = new ServiceDetails();
        pr1.Mh_ServiceCode = txt_SCode.Text;
        pr1.Mh_ServiceHead = txt_SDescription.Text;
        pr1.Se_Quantity = Convert.ToDecimal(txt_SQuantity.Text);
        pr1.Se_Rate = Convert.ToDecimal(txt_SRate.Text);
        pr1.Se_Amount = Convert.ToDecimal(txt_SAmount.Text);
        pr1.UserId = Session["Uid"].ToString();
        pr1.branch = Session["Branch"].ToString();
        pr1.sale = "Service_Spareparts";
      
        SD.Add(pr1);

        FillServiceGrid();

        txt_SCode.Text = "";
        txt_SDescription.Text = "";
        txt_SQuantity.Text = "";
        txt_SRate.Text = "";
        txt_SAmount.Text = "";
        pr1.sale = Session["saletype"].ToString();
        try
        {
         
        }
        catch (Exception)
        {
            
          //  throw;
        }
        txt_SCode.Focus();
    }
    decimal tots1 = 0;
    private void FillServiceGrid()
    {
        uname = Session["Uid"].ToString();

        string Sale = Convert.ToString(Session["saletype"]);
        string branch = Session["Branch"].ToString();
        var prd = (from c in SD.ToList()
                   where c.UserId == uname && c.branch==branch && c.sale==Sale
                   select c).ToList();
        GridView1.DataSource = prd.ToList();
        GridView1.DataBind();
        if (Convert.ToInt32(prd.Count()) > 0)
        {
            foreach (GridViewRow gr in GridView1.Rows)
            {
                Label lbl_Amount = (Label)gr.FindControl("Labels6");
                decimal TotAmt = Convert.ToDecimal(lbl_Amount.Text);

                tots1 = tots1 + TotAmt;

                //lblgrandtotal.Text = Convert.ToString(SmitaClass.SignificantTruncate(tots1, 2));

                //txt_SGrossAmount.Text = Convert.ToString(SmitaClass.SignificantTruncate(total, 2));
                txt_ALabourCharges.Text = Convert.ToString(SmitaClass.SignificantTruncate(tots1, 2));
                txt_ALabourChargesAftDisc.Text = Convert.ToString(SmitaClass.SignificantTruncate(tots1, 2));
                //txt_StotalAmount.Text = Convert.ToString(SmitaClass.SignificantTruncate(total, 2));
                txt_ABillAmount.Text = Convert.ToString(Convert.ToDecimal(txt_AServiceTaxAmt.Text) + Convert.ToDecimal(txt_ALabourChargesAftDisc.Text) + Convert.ToDecimal(txt_ttotalAmount.Text));

                decimal totallabour = Convert.ToDecimal(txt_ALabourCharges.Text);
                decimal totalspare = Convert.ToDecimal(txt_ttotalAmount.Text);
                decimal serviceper = Convert.ToDecimal(txt_AServiceTaxPer.Text);
                decimal afterservice = totallabour * (serviceper / 100);
                txt_AServiceTaxAmt.Text = afterservice.ToString("0.00");
                decimal bill = afterservice + totalspare + totallabour;
                txt_ABillAmount.Text = bill.ToString("0.00");
            }
        }
        else
        {
            txt_ALabourCharges.Text = "0.00";
            txt_ALabourChargesAftDisc.Text = "0.00";
            decimal totallabour = Convert.ToDecimal(txt_ALabourCharges.Text);
            decimal totalspare = Convert.ToDecimal(txt_ttotalAmount.Text);
            decimal serviceper = Convert.ToDecimal(txt_AServiceTaxPer.Text);
            decimal afterservice = totallabour * (serviceper / 100);
            txt_AServiceTaxAmt.Text = afterservice.ToString("0.00");
            decimal bill = afterservice + totalspare;
            txt_ABillAmount.Text = bill.ToString("0.00");
        }
        
    }

    protected void imgbtn_SDelete_Click(object sender, ImageClickEventArgs e)
    {
        ImageButton imgbtn_SDelete = (ImageButton)sender;
        string branch = Session["Branch"].ToString();
        SD.RemoveAll(t => t.Mh_ServiceCode == imgbtn_SDelete.ToolTip && t.branch==branch);
        FillServiceGrid();
    }
    public class PartDetails
    {
        public int slno { get; set; }
        public string Itm_Partno { get; set; }

        public string Itm_PartDescrption { get; set; }

        public decimal Ss_Quantity { get; set; }

        public decimal Ss_Rate { get; set; }

        public decimal Ss_Amount { get; set; }

        public decimal Ss_DiscountPer { get; set; }

        public decimal Ss_Discount { get; set; }

        public decimal Ss_Vat { get; set; }

        public decimal Ss_TaxAmont { get; set; }

        public decimal Ss_Total { get; set; }

        public string UserId { get; set; }

        public string branch { get; set; }



    }
    public class ServiceDetails
    {
        public string Mh_ServiceCode { get; set; }

        public string Mh_ServiceHead { get; set; }

        public decimal Se_Quantity { get; set; }

        public decimal Se_Rate { get; set; }

        public decimal Se_Amount { get; set; }

        public string UserId { get; set; }
        public string branch { get; set; }
        public string sale { get; set; }

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
    protected void txt_disc_TextChanged(object sender, EventArgs e)
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
    //protected void txt_SQuantity_TextChanged(object sender, EventArgs e)
    //{
    //    decimal qty = Convert.ToDecimal(txt_SQuantity.Text);
    //    decimal rate = Convert.ToDecimal(txt_SRate.Text);
    //    txt_SAmount.Text = (rate * qty).ToString("0.00");
    //}
    protected void txt_ALabDiscountPer_TextChanged(object sender, EventArgs e)
    {
        decimal discper = Convert.ToDecimal(txt_ALabDiscountPer.Text);
        decimal disc = Convert.ToDecimal(txt_ALabourCharges.Text);
        decimal discamnt = disc * (discper / 100);
        txt_ALabDiscountAmount.Text = Convert.ToDecimal(discamnt).ToString("0.00");

        txt_ALabourChargesAftDisc.Text = Convert.ToDecimal(disc-discamnt).ToString("0.00");

        decimal labourafterdisc = Convert.ToDecimal(txt_ALabourChargesAftDisc.Text);
        decimal totalspare = Convert.ToDecimal(txt_ATotalSpareAmount.Text);
        decimal service = Convert.ToDecimal(txt_AServiceTaxAmt.Text);
        decimal other = Convert.ToDecimal(txt_AOtherAmount.Text);
        txt_ABillAmount.Text = Convert.ToDecimal(labourafterdisc + totalspare + service + other).ToString("0.00");

    }

}